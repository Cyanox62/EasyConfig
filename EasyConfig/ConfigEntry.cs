using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace EasyConfig
{
	public enum ConfigType
	{
		Undefined = -1,
		Integer = 0,
		Float = 1,
		String = 2,
		Boolean = 3,
		List = 4,
		IntegerList = 5,
		Dictionary = 6,
		IntegerDictionary = 7
	}

	public class ConfigEntry
	{
		public string Key { get; }
		public string DefaultValue { get; }
		public ConfigType Type { get; }
		public string Description { get; }

		public ConfigEntry(string key, string defaultValue, ConfigType type, string description)
		{
			Key = key;
			DefaultValue = defaultValue;
			Type = type;
			Description = description;
		}

		public bool TryValue(string newValue)
		{
			switch (Type)
			{
				case ConfigType.List:
				case ConfigType.String:
					break;

				case ConfigType.Boolean:
					newValue = newValue.ToLower();
					if (!bool.TryParse(newValue, out _))
					{
						return false;
					}
					break;

				case ConfigType.Integer:
					if (!int.TryParse(newValue, out _))
					{
						return false;
					}
					break;

				case ConfigType.Float:
					if (!float.TryParse(newValue, out _))
					{
						return false;
					}
					break;

				case ConfigType.IntegerList:
					foreach (string str in newValue.Split(','))
					{
						if (!int.TryParse(str.Trim(), out _))
						{
							return false;
						}
					}
					break;

				default:
					return false;
					// TODO: add list support
			}
			
			return true;
		}

		public static ConfigEntry TryInstruction(Instruction instruction)
		{
			// ldarg.0 (getting instance of itself as a Plugin)
			if (instruction.OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}

			// Make sure the instruction in 8 lines calls Plugin.AddConfig().
			Instruction addConfigCall = GetInstructionAfter(instruction, 8);
			if (addConfigCall == null || 
			    addConfigCall.OpCode.Code != Code.Call ||
			    (addConfigCall.Operand as MethodReference)?.FullName != "System.Void Smod2.Plugin::AddConfig(Smod2.Config.ConfigSetting)")
			{
				return null;
			}
			
			Instruction curInstruction = instruction;

			// Value of ldstr (string), represents the "key" argument in new ConfigSetting()
			string configKey = (string) (curInstruction = curInstruction.Next).Operand;

			object value;
			// Raw value of config value.
			switch ((curInstruction = curInstruction.Next).OpCode.Code)
			{
				case Code.Ldc_I4_0:
				case Code.Ldc_I4_1:
				case Code.Ldc_I4_2:
				case Code.Ldc_I4_3:
				case Code.Ldc_I4_4:
				case Code.Ldc_I4_5:
				case Code.Ldc_I4_6:
				case Code.Ldc_I4_7:
				case Code.Ldc_I4_8:
					// Probably an integer boxed in instruction code, so get the integer from the number at the end of it.
					value = (int) curInstruction.OpCode.Code - 22;
					break;

				case Code.Ldc_I4_S:
					// Actually an integer
					value = curInstruction.Operand;
					break;

				case Code.Ldc_R4:
					// Single (float). Remember it as R4 by remembering I means whole number so R means the opposite, and R4 / 4 bytes = 1 so it is a single
					value = (float) curInstruction.Operand;
					break;

				case Code.Ldstr:
					// String
					value = (string) curInstruction.Operand;
					break;

				default:
					// Just in case it is something else but the gods of typing made it the right type.
					value = curInstruction.Operand;
					break;
			}

			string configValue = value.ToString();

			// If the value instruction declares that the value is string, we don't need to box (convert) the raw value we just got.
			if (curInstruction.OpCode.Code != Code.Ldstr)
			{
				Instruction boxInstruction = curInstruction.Next;
				// The the possible box instruction is a box instruction and it is asking to convert to boolean, set value appropriately. Otherwise just set values to their string counterparts.
				if (boxInstruction.OpCode.Code == Code.Box && (boxInstruction.Operand as TypeReference)?.FullName == "System.Boolean")
				{
					configValue = (int)value == 1 ? "true" : "false";
				}
			}

			int type;
			// ConfigType as integer
			switch ((curInstruction = curInstruction.Next.Next).OpCode.Code)
			{
				case Code.Ldc_I4_0:
				case Code.Ldc_I4_1:
				case Code.Ldc_I4_2:
				case Code.Ldc_I4_3:
				case Code.Ldc_I4_4:
				case Code.Ldc_I4_5:
				case Code.Ldc_I4_6:
				case Code.Ldc_I4_7:
				case Code.Ldc_I4_8:
					type = (int) curInstruction.OpCode.Code - 22;
					break;

				default:
					type = -1;
					break;
			}
			// Convert integer to ConfigType
			ConfigType configType = (ConfigType) type;
			// Get last ldstr instruction and use it to get description.
			string configDescription = (string) curInstruction.Next.Next.Operand;

			return new ConfigEntry(configKey, configValue, configType, configDescription);
		}

		private static Instruction GetInstructionAfter(Instruction instruction, int offset)
		{
			for (int i = 0; i < offset; i++)
			{
				if (instruction == null)
				{
					return null;
				}
				
				instruction = instruction.Next;
			}

			return instruction;
		}

		public override string ToString()
		{
			return $"{Key}: {DefaultValue}";
		}
	}
}
