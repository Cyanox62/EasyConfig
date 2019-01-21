using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace EasyConfig
{
	public partial class Main : Form
	{
		private string cPath = null;
		private readonly Dictionary<string, string> configCache;

		public Main()
		{
			configCache = new Dictionary<string, string>();
			if (Properties.Settings.Default.lastplugins == null)
			{
				Properties.Settings.Default.lastplugins = new StringCollection();
			}

			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			string prop = Properties.Settings.Default.lastconfig;
			if (prop.Length > 0 && File.Exists(prop))
			{
				cPath = prop;
				LoadConfig(prop);
			}

			foreach (string path in Properties.Settings.Default.lastplugins)
			{
				Plugin[] plugins = Plugin.Load(path);
				foreach (Config config in plugins.SelectMany(x => x.Configs))
				{
					AddConfig(config.Key, config.Value);
				}
			}
		}

		private void AddConfig(string key, string value)
		{
			configCache.Add(key, value);
			ConfigListBox.Items.Add(key);
		}

		private void RemoveConfig(string key)
		{
			configCache.Remove(key);
			ConfigListBox.Items.Remove(key);
		}

		private void LoadConfig(string cPath)
		{
			if (cPath == null)
				MessageBox.Show("Error", "Can't find file", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			// I know this looks like an abomination, but it parses each line asynchronously so large configs don't halt the UI
			string[] configs = File.ReadAllLines(cPath);
			foreach (string config in configs.Select(x => x.Trim()))
			{
				if (config.Length > 0 &&
				    config[0] != '#')
				{
					int cIndex = config.IndexOf(':');
					int valueIndex = cIndex + 1;

					if (cIndex != -1 && valueIndex < config.Length && !configCache.ContainsKey(config.Substring(0, cIndex)))
					{
						AddConfig(config.Substring(0, cIndex), config.Substring(valueIndex).Trim());
					}
				}
			}
		}

		private void OpenConfigButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
				FilterIndex = 2,
				RestoreDirectory = true
			})
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					cPath = openFileDialog.FileName;
					Properties.Settings.Default.lastconfig = cPath;
					Properties.Settings.Default.Save();

					LoadConfig(cPath);
				}
			}
		}

		private void AddConfigButtom_Click(object sender, EventArgs e)
		{
			string input = Interaction.InputBox("Enter config to add\n\nFormat: key:value", "Config Adder", "", -1, -1).Trim();

			if (input != string.Empty)
			{
				int cIndex = input.IndexOf(':');

				if (cIndex != -1)
				{
					int valueIndex = cIndex + 1;

					if (valueIndex < input.Length)
					{
						if (!configCache.ContainsKey(input.Substring(0, cIndex)))
						{
							AddConfig(input.Substring(0, cIndex), input.Substring(valueIndex).Trim());
						}
						else
						{
							MessageBox.Show("Error", "Key already exists. Please edit the existing config before adding a new config.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("Error", "No value in new config line found. Please put a value next time.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Error", "No value in new config line found. Please make sure you have a colon to separate the key from the value.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ConfigListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ConfigValueTextbox.Text = ConfigListBox.SelectedItem != null ? 
				configCache[ConfigListBox.SelectedItem.ToString()] : 
				string.Empty;
		}

		private void RemoveConfigButton_Click(object sender, EventArgs e)
		{
			if (ConfigListBox.SelectedItem != null)
			{
				configCache.Remove(ConfigListBox.SelectedItem.ToString());
				ConfigListBox.Items.Remove(ConfigListBox.SelectedItem);
			}
		}
		
		private void SaveButton_Click(object sender, EventArgs e)
		{
			List<string> lines = new List<string>(File.ReadAllLines(cPath));
			for (int i = 0; i < lines.Count; i++)
			{
				int cIndex = lines[i].IndexOf(':');
				if (lines[i].Length > 0 && cIndex != -1 && !lines[i].StartsWith("port_queue:") && !lines[i].Contains("#"))
				{
					if (configCache.ContainsKey(lines[i].Substring(0, cIndex)))
					{
						lines[i] = $"{lines[i].Substring(0, cIndex)}: {configCache[lines[i].Substring(0, cIndex)]}";
					}
					else
					{
						lines.Remove(lines[i]);
					}
				}
			}

			foreach (KeyValuePair<string, string> entry in configCache)
			{
				if (!lines.Contains($"{entry.Key}: {entry.Value}"))
				{
					lines.Add($"{entry.Key}: {entry.Value}");
				}
			}
			File.WriteAllLines(cPath, lines);
			MessageBox.Show("All changes saved", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ConfigValueTextbox_TextChanged(object sender, EventArgs e)
		{
			if (ConfigListBox.SelectedItem != null)
			{
				configCache[ConfigListBox.SelectedItem.ToString()] = ConfigValueTextbox.Text;
			}
		}

		private void SearchTextbox_TextChanged(object sender, EventArgs e)
		{
			ConfigListBox.Items.Clear();

			if (SearchTextbox.Text == string.Empty)
			{
				foreach (KeyValuePair<string, string> entry in configCache)
				{
					ConfigListBox.Items.Add(entry.Key);
				}
			}

			ConfigListBox.Items.AddRange(configCache
				.Where(entry => SearchTextbox.Text != string.Empty && entry.Key.Contains(SearchTextbox.Text))
				.Select(x => (object) x.Key)
				.ToArray()
			);
		}

		private async void AddPluginButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Smod2 Plugins (*.dll)|*.dll",
				RestoreDirectory = true
			})
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					cPath = openFileDialog.FileName;
					Properties.Settings.Default.lastplugins.Add(cPath);
					Properties.Settings.Default.Save();

					Plugin[] plugins = Plugin.Load(cPath);
					foreach (Config config in plugins.SelectMany(x => x.Configs))
					{
						AddConfig(config.Key, config.Value);
					}
				}
			}

			await Task.CompletedTask;
		}

		private void RemovePluginButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Smod2 Plugins (*.dll)|*.dll",
				RestoreDirectory = true
			})
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					cPath = openFileDialog.FileName;
					Properties.Settings.Default.lastplugins.Remove(cPath);
					Properties.Settings.Default.Save();

					Plugin[] plugins = Plugin.Load(cPath);
					foreach (Config config in plugins.SelectMany(x => x.Configs))
					{
						RemoveConfig(config.Key);
					}
				}
			}
		}
	}
}
