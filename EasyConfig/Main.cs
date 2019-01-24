using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using EasyConfig.Properties;

namespace EasyConfig
{
	public partial class Main : Form
	{
		private string cPath;
		private readonly Dictionary<string, string> configCache;
		private readonly Dictionary<string, Plugin> loadedPlugins;

		public Main()
		{
			configCache = new Dictionary<string, string>();
			loadedPlugins = new Dictionary<string, Plugin>();
			if (Settings.Default.lastplugins == null)
			{
				Settings.Default.lastplugins = new StringCollection();
			}
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			cPath = Settings.Default.lastconfig;
			if (!string.IsNullOrEmpty(cPath) && File.Exists(cPath))
			{
				LoadConfig(cPath);
				foreach (string path in Settings.Default.lastplugins)
				{
					AddPluginAssembly(path);
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

		private void LoadConfig(string path)
		{
			configCache.Clear();
			ConfigListBox.Items.Clear();
			string[] configs = File.ReadAllLines(path);
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

			AddConfigButton.Enabled = true;
			OpenPluginButton.Enabled = true;
			SaveButton.Enabled = true;
		}

		private void DeleteConfig()
		{
			int index = ConfigListBox.SelectedIndex;

			if (index != -1)
			{
				string item = (string) ConfigListBox.Items[index];

				configCache.Remove(item);
				ConfigListBox.Items.RemoveAt(index);
			}

			ConfigListBox.SelectedIndex = index;
		}

		private void OpenConfigButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Config files (*.txt)|*.txt|All files (*.*)|*.*",
				RestoreDirectory = true
			})
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					cPath = openFileDialog.FileName;
					Settings.Default.lastconfig = cPath;
					Settings.Default.Save();

					LoadConfig(cPath);
				}
			}
		}

		private void AddConfigButton_Click(object sender, EventArgs e)
		{
			string input = Interaction.InputBox("Enter config entry to add\n\nFormat: key:value OR key", "Config Adder").Trim();

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
							MessageBox.Show(
								"Config entry key already exists. Please edit the existing entry before add a new entry.",
								"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else
					{
						MessageBox.Show("No value in new config entry found. Please put a value to the right of the colon or do not insert a colon at all.", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					if (!configCache.ContainsKey(input))
					{
						AddConfig(input, string.Empty);
					}
					else
					{
						MessageBox.Show(
							"Config entry key already exists. Please edit the existing entry before adding a new entry.",
							"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		
		private void SaveButton_Click(object sender, EventArgs e)
		{
			List<string> savedEntries = new List<string>();

			File.WriteAllLines(cPath, File.ReadAllLines(cPath)
				.Select(x =>
				{
					x = x.Trim();

					if (x.Length == 0 || x[0] == '#')
					{
						return x;
					}

					int index = x.IndexOf(':');
					if (index != -1 && index != x.Length - 1)
					{
						string[] splits = x.Split(':');
						if (configCache.ContainsKey(splits[0]))
						{
							savedEntries.Add(splits[0]);
							return $"{splits[0]}: {configCache[splits[0]]}";
						}

						return null;
					}

					return x;
				})
				.Where(x => x != null)
				.Concat(configCache.Where(x => !savedEntries.Contains(x.Key)).Select(x => $"{x.Key}: {x.Value}"))
			);

			MessageBox.Show("All changes saved.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			else
			{
				ConfigListBox.Items.AddRange(configCache
					.Where(entry => entry.Key.Contains(SearchTextbox.Text))
					.Select(x => (object)x.Key)
					.ToArray()
				);
			}
		}

		private void AddPluginAssembly(string path)
		{
			Plugin[] plugins = Plugin.Load(path);

			foreach (Plugin plugin in plugins)
			{
				foreach (ConfigEntry config in plugin.Configs.Where(x => !configCache.ContainsKey(x.Key)))
				{
					AddConfig(config.Key, config.DefaultValue);
				}

				if (!loadedPlugins.ContainsKey(plugin.Name))
				{
					loadedPlugins.Add(plugin.Name, plugin);
				}
			}
		}

		private void RemovePlugin(Plugin plugin)
		{
			foreach (ConfigEntry otherConfig in plugin.Configs)
			{
				RemoveConfig(otherConfig.Key);
			}

			loadedPlugins.Remove(plugin.Name);
			Settings.Default.lastplugins.Remove(plugin.Path);
			Settings.Default.Save();
		}

		private void ConfigListBox_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete when (ModifierKeys & Keys.Shift) == Keys.Shift:
				{
					string key = (string) ConfigListBox.SelectedItem;
					Plugin plugin = loadedPlugins.Values.FirstOrDefault(x => x.Configs.Any(y => y.Key == key));
					if (plugin != null) RemovePlugin(plugin);
					break;
				}

				case Keys.Delete:
					DeleteConfig();
					break;

				case Keys.Enter:
					InspectSelected();
					break;
			}
		}

		private (Plugin plugin, ConfigEntry config) GetConfigByKey(string key)
		{
			foreach (Plugin plugin in loadedPlugins.Values)
			{
				foreach (ConfigEntry config in plugin.Configs)
				{
					if (config.Key == key)
					{
						return (plugin, config);
					}
				}
			}

			return (null, null);
		}

		private void InspectSelected()
		{
			string key = (string)ConfigListBox.SelectedItem;
			// Nothing selected
			if (key == null)
			{
				return;
			}

			var (plugin, config) = GetConfigByKey(key);
			bool valid;

			do
			{
				valid = true;

				InspectConfig window = plugin == null
					? new InspectConfig(key, configCache[key])
					: new InspectConfig(key, configCache[key], plugin, config);
				window.ShowDialog();
				window.ValueTextbox.Text = window.ValueTextbox.Text.Trim();

				switch (window.Action)
				{
					case InspectAction.ChangeValue:
						if (config != null && !config.TryValue(window.ValueTextbox.Text))
						{
							if (MessageBox.Show("Invalid value type.", 
								    "Error", 
								    MessageBoxButtons.RetryCancel,
								    MessageBoxIcon.Error, 
								    MessageBoxDefaultButton.Button1) != DialogResult.Cancel)
							{
								valid = false;
							}
						}
						else
						{
							configCache[key] = window.ValueTextbox.Text;
						}
						break;

					case InspectAction.Remove:
						RemoveConfig(key);
						break;

					case InspectAction.RemovePlugin:
						if (plugin == null)
						{
							throw new NullReferenceException(
								$"{nameof(plugin)} is null but {nameof(window)} returned {InspectAction.RemovePlugin}. Something has gone terribly wrong in {nameof(InspectConfig)}.");
						}

						RemovePlugin(plugin);
						break;
				}

				window.Dispose();
			} while (!valid);
		}

		private void InspectButton_Click(object sender, EventArgs e)
		{
			InspectSelected();
		}

		private void ConfigListBox_DoubleClick(object sender, EventArgs e)
		{
			InspectSelected();
		}

		private void OpenPluginButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Smod2 Plugins (*.dll)|*.dll",
				RestoreDirectory = true
			})
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					AddPluginAssembly(openFileDialog.FileName);

					Settings.Default.lastplugins.Add(openFileDialog.FileName);
					Settings.Default.Save();
				}
			}
		}

		private void ConfigListBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right) return;
			int index = ConfigListBox.IndexFromPoint(e.X, e.Y);
			if (index != -1)
			{
				ConfigListBox.SelectedIndex = index;
				rightClickMenu.Show(Cursor.Position);
			}
		}

		private void rightClickMenu_Opened(object sender, EventArgs e)
		{
			var (plugin, config) = GetConfigByKey((string)ConfigListBox.SelectedItem);
			if (plugin != null) rightClickMenu.Items[2].Visible = true;
			else rightClickMenu.Items[2].Visible = false;
		}

		private void rightClickMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Text.ToLower())
			{
				case "inspect":
					InspectSelected();
					break;
				case "delete":
					DeleteConfig();
					break;
				case "remove plugin":
					Plugin plugin = loadedPlugins.Values.FirstOrDefault(x => x.Configs.Any(y => y.Key == (string)ConfigListBox.SelectedItem));
					RemovePlugin(plugin);
					break;
			}
		}
	}
}
