using Mono.Cecil;
using Mono.Cecil.Cil;

namespace EasyConfig
{
	public enum ConfigType
	{
		UNDEFINED = -1,
		NUMERIC = 0,
		FLOAT = 1,
		STRING = 2,
		BOOL = 3,
		LIST = 4,
		NUMERIC_LIST = 5,
		DICTIONARY = 6,
		NUMERIC_DICTIONARY = 7
	}

	public class Config
	{
		public string Key { get; }
		public string Value { get; }
		public ConfigType Type { get; }
		public string Description { get; }

		public Config(string key, string value, ConfigType type, string description)
		{
			Key = key;
			Value = value;
			Type = type;
			Description = description;
		}

		public static Config TryInstruction(Instruction instruction)
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
					value = (int) curInstruction.Operand;
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

			return new Config(configKey, configValue, configType, configDescription);
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
			return $"{Key}: {Value}";
		}
	}
}
