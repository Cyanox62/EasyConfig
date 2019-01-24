namespace EasyConfig
{
	partial class InspectConfig
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectConfig));
			this.SourceLabel = new System.Windows.Forms.Label();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.DefaultLabel = new System.Windows.Forms.Label();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ValueTextbox = new System.Windows.Forms.TextBox();
			this.removeButton = new System.Windows.Forms.Button();
			this.removePluginButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.DescriptionText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SourceLabel
			// 
			this.SourceLabel.AutoSize = true;
			this.SourceLabel.Location = new System.Drawing.Point(12, 9);
			this.SourceLabel.Name = "SourceLabel";
			this.SourceLabel.Size = new System.Drawing.Size(47, 13);
			this.SourceLabel.TabIndex = 0;
			this.SourceLabel.Text = "Source: ";
			// 
			// TypeLabel
			// 
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(12, 22);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(37, 13);
			this.TypeLabel.TabIndex = 1;
			this.TypeLabel.Text = "Type: ";
			// 
			// DefaultLabel
			// 
			this.DefaultLabel.AutoSize = true;
			this.DefaultLabel.Location = new System.Drawing.Point(12, 35);
			this.DefaultLabel.Name = "DefaultLabel";
			this.DefaultLabel.Size = new System.Drawing.Size(47, 13);
			this.DefaultLabel.TabIndex = 2;
			this.DefaultLabel.Text = "Default: ";
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.AutoSize = true;
			this.DescriptionLabel.Location = new System.Drawing.Point(12, 48);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
			this.DescriptionLabel.TabIndex = 3;
			this.DescriptionLabel.Text = "Description:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Value: ";
			// 
			// ValueTextbox
			// 
			this.ValueTextbox.Location = new System.Drawing.Point(59, 112);
			this.ValueTextbox.Name = "ValueTextbox";
			this.ValueTextbox.Size = new System.Drawing.Size(273, 20);
			this.ValueTextbox.TabIndex = 5;
			this.ValueTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValueTextbox_KeyDown);
			// 
			// removeButton
			// 
			this.removeButton.Location = new System.Drawing.Point(12, 151);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(106, 23);
			this.removeButton.TabIndex = 6;
			this.removeButton.Text = "Remove";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// removePluginButton
			// 
			this.removePluginButton.Enabled = false;
			this.removePluginButton.Location = new System.Drawing.Point(124, 151);
			this.removePluginButton.Name = "removePluginButton";
			this.removePluginButton.Size = new System.Drawing.Size(156, 23);
			this.removePluginButton.TabIndex = 7;
			this.removePluginButton.Text = "Remove Plugin";
			this.removePluginButton.UseVisualStyleBackColor = true;
			this.removePluginButton.Click += new System.EventHandler(this.RemovePluginButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(287, 151);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(45, 23);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// DescriptionText
			// 
			this.DescriptionText.BackColor = System.Drawing.SystemColors.Control;
			this.DescriptionText.Location = new System.Drawing.Point(82, 48);
			this.DescriptionText.Multiline = true;
			this.DescriptionText.Name = "DescriptionText";
			this.DescriptionText.ReadOnly = true;
			this.DescriptionText.Size = new System.Drawing.Size(250, 58);
			this.DescriptionText.TabIndex = 9;
			// 
			// InspectConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 186);
			this.Controls.Add(this.DescriptionText);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.removePluginButton);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.ValueTextbox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.DefaultLabel);
			this.Controls.Add(this.TypeLabel);
			this.Controls.Add(this.SourceLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InspectConfig";
			this.Text = "Config Inspector";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label SourceLabel;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.Label DefaultLabel;
		private System.Windows.Forms.Label DescriptionLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button removePluginButton;
		private System.Windows.Forms.Button okButton;
		public System.Windows.Forms.TextBox ValueTextbox;
		private System.Windows.Forms.TextBox DescriptionText;
	}
}