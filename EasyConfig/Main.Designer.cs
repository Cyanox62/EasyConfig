namespace EasyConfig
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.ConfigListBox = new System.Windows.Forms.ListBox();
			this.OpenConfigButton = new System.Windows.Forms.Button();
			this.fileDialog = new System.Windows.Forms.OpenFileDialog();
			this.AddConfigButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SearchTextbox = new System.Windows.Forms.TextBox();
			this.OpenPluginButton = new System.Windows.Forms.Button();
			this.InspectButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ConfigListBox
			// 
			this.ConfigListBox.FormattingEnabled = true;
			this.ConfigListBox.Location = new System.Drawing.Point(12, 116);
			this.ConfigListBox.Name = "ConfigListBox";
			this.ConfigListBox.Size = new System.Drawing.Size(287, 316);
			this.ConfigListBox.Sorted = true;
			this.ConfigListBox.TabIndex = 0;
			this.ConfigListBox.DoubleClick += new System.EventHandler(this.ConfigListBox_DoubleClick);
			this.ConfigListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigListBox_KeyDown);
			// 
			// OpenConfigButton
			// 
			this.OpenConfigButton.Location = new System.Drawing.Point(12, 12);
			this.OpenConfigButton.Name = "OpenConfigButton";
			this.OpenConfigButton.Size = new System.Drawing.Size(139, 23);
			this.OpenConfigButton.TabIndex = 1;
			this.OpenConfigButton.Text = "Open File";
			this.OpenConfigButton.UseVisualStyleBackColor = true;
			this.OpenConfigButton.Click += new System.EventHandler(this.OpenConfigButton_Click);
			// 
			// fileDialog
			// 
			this.fileDialog.FileName = "fileDialog";
			// 
			// AddConfigButton
			// 
			this.AddConfigButton.Location = new System.Drawing.Point(12, 41);
			this.AddConfigButton.Name = "AddConfigButton";
			this.AddConfigButton.Size = new System.Drawing.Size(139, 23);
			this.AddConfigButton.TabIndex = 2;
			this.AddConfigButton.Text = "Add Config";
			this.AddConfigButton.UseVisualStyleBackColor = true;
			this.AddConfigButton.Click += new System.EventHandler(this.AddConfigButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(157, 41);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(139, 23);
			this.SaveButton.TabIndex = 5;
			this.SaveButton.Text = "Save Changes";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 439);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Search";
			// 
			// SearchTextbox
			// 
			this.SearchTextbox.Location = new System.Drawing.Point(62, 436);
			this.SearchTextbox.Name = "SearchTextbox";
			this.SearchTextbox.Size = new System.Drawing.Size(237, 20);
			this.SearchTextbox.TabIndex = 8;
			this.SearchTextbox.TextChanged += new System.EventHandler(this.SearchTextbox_TextChanged);
			// 
			// OpenPluginButton
			// 
			this.OpenPluginButton.Location = new System.Drawing.Point(156, 12);
			this.OpenPluginButton.Name = "OpenPluginButton";
			this.OpenPluginButton.Size = new System.Drawing.Size(139, 23);
			this.OpenPluginButton.TabIndex = 10;
			this.OpenPluginButton.Text = "Open Plugin";
			this.OpenPluginButton.UseVisualStyleBackColor = true;
			this.OpenPluginButton.Click += new System.EventHandler(this.OpenPluginButton_Click);
			// 
			// InspectButton
			// 
			this.InspectButton.Location = new System.Drawing.Point(13, 71);
			this.InspectButton.Name = "InspectButton";
			this.InspectButton.Size = new System.Drawing.Size(282, 32);
			this.InspectButton.TabIndex = 11;
			this.InspectButton.Text = "Inspect Selected";
			this.InspectButton.UseVisualStyleBackColor = true;
			this.InspectButton.Click += new System.EventHandler(this.InspectButton_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(311, 468);
			this.Controls.Add(this.InspectButton);
			this.Controls.Add(this.OpenPluginButton);
			this.Controls.Add(this.SearchTextbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.AddConfigButton);
			this.Controls.Add(this.OpenConfigButton);
			this.Controls.Add(this.ConfigListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "EasyConfig v1.0.0 - Cyanox";
			this.Load += new System.EventHandler(this.Main_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox ConfigListBox;
		private System.Windows.Forms.Button OpenConfigButton;
		private System.Windows.Forms.OpenFileDialog fileDialog;
		private System.Windows.Forms.Button AddConfigButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SearchTextbox;
		private System.Windows.Forms.Button OpenPluginButton;
		private System.Windows.Forms.Button InspectButton;
	}
}

