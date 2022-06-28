namespace EZ_Client_Injector
{
	partial class SettingsForm
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
			this.components = new System.ComponentModel.Container();
			this.Toggleshti = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.RoundedCornersRadioButton = new EZE_Injector.Controls.ToggleButton();
			this.SuspendLayout();
			// 
			// Toggleshti
			// 
			this.Toggleshti.AutoSize = true;
			this.Toggleshti.Location = new System.Drawing.Point(31, 18);
			this.Toggleshti.Name = "Toggleshti";
			this.Toggleshti.Size = new System.Drawing.Size(90, 13);
			this.Toggleshti.TabIndex = 112;
			this.Toggleshti.Text = "Rounded Corners";
			// 
			// RoundedCornersRadioButton
			// 
			this.RoundedCornersRadioButton.Checked = true;
			this.RoundedCornersRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.RoundedCornersRadioButton.Location = new System.Drawing.Point(34, 34);
			this.RoundedCornersRadioButton.MinimumSize = new System.Drawing.Size(45, 22);
			this.RoundedCornersRadioButton.Name = "RoundedCornersRadioButton";
			this.RoundedCornersRadioButton.OffBackColor = System.Drawing.Color.Gray;
			this.RoundedCornersRadioButton.OffBackColor1 = System.Drawing.Color.Gray;
			this.RoundedCornersRadioButton.OffToggleColor = System.Drawing.Color.Gainsboro;
			this.RoundedCornersRadioButton.OffToggleColor1 = System.Drawing.Color.Gainsboro;
			this.RoundedCornersRadioButton.OnBackColor = System.Drawing.Color.MediumSlateBlue;
			this.RoundedCornersRadioButton.OnBackColor1 = System.Drawing.Color.MediumSlateBlue;
			this.RoundedCornersRadioButton.OnToggleColor = System.Drawing.Color.WhiteSmoke;
			this.RoundedCornersRadioButton.OnToggleColor1 = System.Drawing.Color.WhiteSmoke;
			this.RoundedCornersRadioButton.Size = new System.Drawing.Size(87, 22);
			this.RoundedCornersRadioButton.TabIndex = 113;
			this.RoundedCornersRadioButton.UseVisualStyleBackColor = true;
			this.RoundedCornersRadioButton.CheckedChanged += new System.EventHandler(this.RoundedCornersRadioButton_CheckedChanged);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SlateGray;
			this.ClientSize = new System.Drawing.Size(765, 513);
			this.Controls.Add(this.RoundedCornersRadioButton);
			this.Controls.Add(this.Toggleshti);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SettingsForm";
			this.Text = "SettingsForm";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label Toggleshti;
		private EZE_Injector.Controls.ToggleButton RoundedCornersRadioButton;
		private System.Windows.Forms.Timer timer1;
	}
}