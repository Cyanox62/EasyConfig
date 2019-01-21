using System;
using Smod2;

using System.Reflection;

namespace EasyConfig
{
	public class Plugin
	{
		public string Path { get; }
		public Assembly Assembly { get; }

		public string Name { get; }

		private Plugin() { }

		public static Plugin Load(string path)
		{
			return null;
		}
	}
}
