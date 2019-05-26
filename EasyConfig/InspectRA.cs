using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyConfig
{
	public partial class InspectRA : Form
	{
		string rank;
		string cPath;
		RankStats r;

		public InspectRA(string rank, RankStats r, string cPath)
		{
			InitializeComponent();

			this.rank = rank;
			this.cPath = cPath;
			this.r = r;
			Text = $"{rank} - Rank Editor";

			BadgeTextbox.Text = r.rBadge;
			ColorTextbox.Text = r.rColor;
			CoverCheckBox.Checked = r.rCover;
			HiddenCheckBox.Checked = r.rHidden;

			foreach (KeyValuePair<string, bool> perm in r.rPerms) PermissionsListBox.Items.Add(perm.Key, perm.Value);
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			string[] lines = File.ReadAllLines(cPath);
			// TODO: PERMIOSSIONS
			/*int index = 0;
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].ToLower().Contains("permissions:"))
				{
					index = i;
					break;
				}
			}

			for (int i = index + 1; i < lines.Length; i++)
			{
				if (lines[i].StartsWith(" - "))
				{
					int indx = lines[i].IndexOf(':');
					if (!r.rPerms[lines[i].Substring(3, indx - 3)])
					{
						lines[i] = lines[i].Replace("]", $", {rank}]");
						MessageBox.Show(lines[i]);
					}
				}
				else
				{
					break;
				}
			}*/
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].StartsWith($"{rank}_"))
				{
					switch (lines[i].Substring(rank.Length + 1, lines[i].IndexOf(':') - rank.Length - 1))
					{
						case "badge":
							lines[i] = $"{rank}_badge: {BadgeTextbox.Text}";
							r.rBadge = BadgeTextbox.Text;
							break;
						case "color":
							lines[i] = $"{rank}_color: {ColorTextbox.Text}";
							r.rColor = ColorTextbox.Text;
							break;
						case "cover":
							lines[i] = $"{rank}_cover: {(CoverCheckBox.Checked ? "true" : "false")}";
							r.rCover = CoverCheckBox.Checked;
							break;
						case "hidden":
							lines[i] = $"{rank}_hidden: {(HiddenCheckBox.Checked ? "true" : "false")}";
							r.rHidden = HiddenCheckBox.Checked;
							break;
					}
				}
			}

			File.WriteAllLines(cPath, lines);
			Close();
		}

		private void PermissionsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			r.rPerms[(string)PermissionsListBox.SelectedItem] = !r.rPerms[(string)PermissionsListBox.SelectedItem];
		}
	}
}
