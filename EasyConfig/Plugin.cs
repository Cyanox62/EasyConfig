using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace EasyConfig
{
	public class Plugin
	{
		public string Path { get; }
		public AssemblyDefinition Definition { get; }

		public string Name { get; }
		public Config[] Configs { get; }

		private Plugin(string path, AssemblyDefinition definition, string name, Config[] configs)
		{
			Path = path;
			Definition = definition;

			Name = name;
			Configs = configs;
		}

		private static Config ProcessConfig(Instruction start)
		{
			return null;
		}

		public static Plugin[] Load(string path)
		{
			AssemblyDefinition definition;
			try
			{
				definition = AssemblyDefinition.ReadAssembly(path);
			}
			catch
			{
				return null;
			}

			return definition.MainModule.GetTypes()
				.Where(x => x.BaseType?.FullName == "Smod2.Plugin")
				.Select(x =>
				{
					string name = (string) x.CustomAttributes
						.FirstOrDefault(y => y.AttributeType.FullName == "Smod2.Attributes.PluginDetails")?.Fields
						?.FirstOrDefault(y => y.Name == "name").Argument.Value;
					if (name == null)
					{
						return null;
					}

					MethodDefinition registerMethod = x.Methods.FirstOrDefault(y => y.Name == "Register");
					if (registerMethod == null || !registerMethod.HasBody)
					{
						return null;
					}

					List<Config> configs = new List<Config>();
					for (int i = 0; i < registerMethod.Body.Instructions.Count; i++)
					{
						Config config = Config.TryInstruction(registerMethod.Body.Instructions[i]);
						if (config != null)
						{
							configs.Add(config);
							// Skip chunk just read
							i += 9;
						}
					}

					return new Plugin(path, definition, name, configs.ToArray());
				}).ToArray();
		}
	}
}
