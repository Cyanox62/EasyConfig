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
			this.AddConfigButtom = new System.Windows.Forms.Button();
			this.RemoveConfigButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ConfigValueTextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SearchTextbox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ConfigListBox
			// 
			this.ConfigListBox.FormattingEnabled = true;
			this.ConfigListBox.Location = new System.Drawing.Point(9, 96);
			this.ConfigListBox.Name = "ConfigListBox";
			this.ConfigListBox.Size = new System.Drawing.Size(287, 303);
			this.ConfigListBox.Sorted = true;
			this.ConfigListBox.TabIndex = 0;
			this.ConfigListBox.SelectedIndexChanged += new System.EventHandler(this.ConfigListBox_SelectedIndexChanged);
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
			// AddConfigButtom
			// 
			this.AddConfigButtom.Location = new System.Drawing.Point(12, 41);
			this.AddConfigButtom.Name = "AddConfigButtom";
			this.AddConfigButtom.Size = new System.Drawing.Size(139, 23);
			this.AddConfigButtom.TabIndex = 2;
			this.AddConfigButtom.Text = "Add Config";
			this.AddConfigButtom.UseVisualStyleBackColor = true;
			this.AddConfigButtom.Click += new System.EventHandler(this.AddConfigButtom_Click);
			// 
			// RemoveConfigButton
			// 
			this.RemoveConfigButton.Location = new System.Drawing.Point(156, 41);
			this.RemoveConfigButton.Name = "RemoveConfigButton";
			this.RemoveConfigButton.Size = new System.Drawing.Size(139, 23);
			this.RemoveConfigButton.TabIndex = 3;
			this.RemoveConfigButton.Text = "Remove Selected Config";
			this.RemoveConfigButton.UseVisualStyleBackColor = true;
			this.RemoveConfigButton.Click += new System.EventHandler(this.RemoveConfigButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(156, 12);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(139, 23);
			this.SaveButton.TabIndex = 5;
			this.SaveButton.Text = "Save Changes";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ConfigValueTextbox
			// 
			this.ConfigValueTextbox.Location = new System.Drawing.Point(49, 70);
			this.ConfigValueTextbox.Name = "ConfigValueTextbox";
			this.ConfigValueTextbox.Size = new System.Drawing.Size(245, 20);
			this.ConfigValueTextbox.TabIndex = 6;
			this.ConfigValueTextbox.TextChanged += new System.EventHandler(this.ConfigValueTextbox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 406);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Search";
			// 
			// SearchTextbox
			// 
			this.SearchTextbox.Location = new System.Drawing.Point(59, 403);
			this.SearchTextbox.Name = "SearchTextbox";
			this.SearchTextbox.Size = new System.Drawing.Size(237, 20);
			this.SearchTextbox.TabIndex = 8;
			this.SearchTextbox.TextChanged += new System.EventHandler(this.SearchTextbox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Value";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 431);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SearchTextbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ConfigValueTextbox);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.RemoveConfigButton);
			this.Controls.Add(this.AddConfigButtom);
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
		private System.Windows.Forms.Button AddConfigButtom;
		private System.Windows.Forms.Button RemoveConfigButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.TextBox ConfigValueTextbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SearchTextbox;
		private System.Windows.Forms.Label label2;
	}
}

