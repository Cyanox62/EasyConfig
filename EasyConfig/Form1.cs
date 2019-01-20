using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace EasyConfig
{
	public partial class Form1 : Form
	{
		private string cPath = null;
		private Dictionary<string, string> ConfigCache = new Dictionary<string, string>();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string prop = Properties.Settings.Default["lastconfig"].ToString();
			if (prop.Length > 0)
			{
				cPath = prop;
				LoadConfig(prop);
			}
		}

		private void LoadConfig(string cPath)
		{
			if (cPath == null) MessageBox.Show("Error", "Can't find file");

			foreach (string config in File.ReadAllLines(cPath))
			{
				int cIndex = config.IndexOf(':');
				if (config.Length > 0 && cIndex != -1 && !config.StartsWith("port_queue:") && !config.Contains("#"))
				{
					if (!ConfigCache.ContainsKey(config.Substring(0, cIndex)))
					{
						ConfigCache.Add(config.Substring(0, cIndex), config.Substring(cIndex + 2));
						ConfigListBox.Items.Add(config.Substring(0, cIndex));
					}
				}
			}
		}

		private void OpenConfigButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					cPath = openFileDialog.FileName;
					Properties.Settings.Default["lastconfig"] = cPath;
					Properties.Settings.Default.Save();
					LoadConfig(cPath);
				}
			}
		}

		private void AddConfigButtom_Click(object sender, EventArgs e)
		{
			string input = Interaction.InputBox("Enter config to add\n\nFormat: config: value", "Config Adder", "", -1, -1);
			if (input != string.Empty)
			{
				int cIndex = input.IndexOf(':');
				ConfigListBox.Items.Add(input.Substring(0, cIndex));
				ConfigCache.Add(input.Substring(0, cIndex), input.Substring(cIndex + 2));
			}
		}

		private void ConfigListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ConfigListBox.SelectedItem != null)
				ConfigValueTextbox.Text = ConfigCache[ConfigListBox.SelectedItem.ToString()];
			else
				ConfigValueTextbox.Text = string.Empty;
		}

		private void RemoveConfigButton_Click(object sender, EventArgs e)
		{
			if (ConfigListBox.SelectedItem != null)
			{
				ConfigCache.Remove(ConfigListBox.SelectedItem.ToString());
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
					if (ConfigCache.ContainsKey(lines[i].Substring(0, cIndex)))
					{
						lines[i] = $"{lines[i].Substring(0, cIndex)}: {ConfigCache[lines[i].Substring(0, cIndex)]}";
					}
					else
					{
						lines.Remove(lines[i]);
					}
				}
			}

			foreach (KeyValuePair<string, string> entry in ConfigCache)
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
				ConfigCache[ConfigListBox.SelectedItem.ToString()] = ConfigValueTextbox.Text;
			}
		}

		private void SearchTextbox_TextChanged(object sender, EventArgs e)
		{
			ConfigListBox.Items.Clear();
			if (SearchTextbox.Text == string.Empty)
			{
				foreach (KeyValuePair<string, string> entry in ConfigCache)
				{
					ConfigListBox.Items.Add(entry.Key);
				}
			}
			foreach (KeyValuePair<string, string> entry in ConfigCache)
			{
				if (entry.Key.Contains(SearchTextbox.Text) && SearchTextbox.Text != string.Empty)
				{
					ConfigListBox.Items.Add(entry.Key);
				}
			}
		}
	}
}
