using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EZ_Client_Injector
{
	public partial class SettingsForm : Form
	{
		public Label SRCT;
		public static SettingsForm instance;


		public SettingsForm()
		{
			InitializeComponent();
			SRCT = Toggleshti;
			instance = this;

		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{

		}

		private void RoundedCornersRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			/*if (RoundedCornersRadioButton.Checked)
			{
				Form1.instance.RCT.Text = "works";
			}
			else
			{
				Form1.instance.RCT.Text = "false";
			}*/
		}
	}
}