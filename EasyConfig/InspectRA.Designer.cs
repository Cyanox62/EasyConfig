namespace EasyConfig
{
	partial class InspectRA
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectRA));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.BadgeTextbox = new System.Windows.Forms.TextBox();
			this.ColorTextbox = new System.Windows.Forms.TextBox();
			this.CoverCheckBox = new System.Windows.Forms.CheckBox();
			this.HiddenCheckBox = new System.Windows.Forms.CheckBox();
			this.SaveButton = new System.Windows.Forms.Button();
			this.PermissionsListBox = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Badge:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Color:";
			// 
			// BadgeTextbox
			// 
			this.BadgeTextbox.Location = new System.Drawing.Point(57, 10);
			this.BadgeTextbox.Name = "BadgeTextbox";
			this.BadgeTextbox.Size = new System.Drawing.Size(191, 20);
			this.BadgeTextbox.TabIndex = 4;
			// 
			// ColorTextbox
			// 
			this.ColorTextbox.Location = new System.Drawing.Point(57, 36);
			this.ColorTextbox.Name = "ColorTextbox";
			this.ColorTextbox.Size = new System.Drawing.Size(191, 20);
			this.ColorTextbox.TabIndex = 5;
			// 
			// CoverCheckBox
			// 
			this.CoverCheckBox.AutoSize = true;
			this.CoverCheckBox.Location = new System.Drawing.Point(13, 62);
			this.CoverCheckBox.Name = "CoverCheckBox";
			this.CoverCheckBox.Size = new System.Drawing.Size(54, 17);
			this.CoverCheckBox.TabIndex = 6;
			this.CoverCheckBox.Text = "Cover";
			this.CoverCheckBox.UseVisualStyleBackColor = true;
			// 
			// HiddenCheckBox
			// 
			this.HiddenCheckBox.AutoSize = true;
			this.HiddenCheckBox.Location = new System.Drawing.Point(13, 85);
			this.HiddenCheckBox.Name = "HiddenCheckBox";
			this.HiddenCheckBox.Size = new System.Drawing.Size(60, 17);
			this.HiddenCheckBox.TabIndex = 7;
			this.HiddenCheckBox.Text = "Hidden";
			this.HiddenCheckBox.UseVisualStyleBackColor = true;
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(13, 240);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(234, 23);
			this.SaveButton.TabIndex = 8;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// PermissionsListBox
			// 
			this.PermissionsListBox.CheckOnClick = true;
			this.PermissionsListBox.FormattingEnabled = true;
			this.PermissionsListBox.Location = new System.Drawing.Point(13, 108);
			this.PermissionsListBox.Name = "PermissionsListBox";
			this.PermissionsListBox.Size = new System.Drawing.Size(235, 124);
			this.PermissionsListBox.TabIndex = 9;
			this.PermissionsListBox.SelectedIndexChanged += new System.EventHandler(this.PermissionsListBox_SelectedIndexChanged);
			// 
			// InspectRA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(259, 275);
			this.Controls.Add(this.PermissionsListBox);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.HiddenCheckBox);
			this.Controls.Add(this.CoverCheckBox);
			this.Controls.Add(this.ColorTextbox);
			this.Controls.Add(this.BadgeTextbox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InspectRA";
			this.Text = "InspectRA";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox BadgeTextbox;
		private System.Windows.Forms.TextBox ColorTextbox;
		private System.Windows.Forms.CheckBox CoverCheckBox;
		private System.Windows.Forms.CheckBox HiddenCheckBox;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.CheckedListBox PermissionsListBox;
	}
}