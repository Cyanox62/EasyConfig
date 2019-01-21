using System;
using System.Windows.Forms;

namespace EasyConfig
{
	public enum InspectAction
	{
		ChangeValue,
		Remove,
		RemovePlugin
	}

	public partial class InspectConfig : Form
	{
		public InspectAction Action { get; private set; }

		private InspectConfig(string key)
		{
			InitializeComponent();

			Name = key + " - Config Inspector";
		}

		public InspectConfig(string key, string value) : this(key)
		{
			ValueTextbox.Text = value;
			SourceLabel.Text += "Base game";
			DefaultLabel.Text += "???";
			TypeLabel.Text += "???";
			DescriptionText.Text = "???";
		}

		public InspectConfig(string key, string value, Plugin plugin, ConfigEntry config) : this(key)
		{
			ValueTextbox.Text = value;
			SourceLabel.Text += plugin.Name;
			DefaultLabel.Text += config.DefaultValue;
			TypeLabel.Text += config.Type;
			DescriptionText.Text = config.Description == string.Empty ? "No description provided." : config.Description;

			removePluginButton.Enabled = true;
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			Action = InspectAction.Remove;
			Close();
		}

		private void RemovePluginButton_Click(object sender, EventArgs e)
		{
			Action = InspectAction.RemovePlugin;
			Close();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			Action = InspectAction.ChangeValue;
			Close();
		}

		private void ValueTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Action = InspectAction.ChangeValue;
				Close();
			}
		}
	}
}
