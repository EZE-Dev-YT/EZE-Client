using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Threading;
using DiscordRPC;

namespace EZ_Client_Injector
{
	public partial class Form1 : Form
	{
		public Label RCT;
		public static Form1 instance;

		// rounded corners thing Start
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect,     // x-coordinate of upper-left corner
			int nTopRect,      // y-coordinate of upper-left corner
			int nRightRect,    // x-coordinate of lower-right corner
			int nBottomRect,   // y-coordinate of lower-right corner
			int nWidthEllipse, // height of ellipse
			int nHeightEllipse // width of ellipse
		);// rounded corners thing End
		public Form1()
		{
			InitializeComponent();
			Process Process = new Process();
			timer1.Start();
			RCT = label2;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
			DashboardTitleLabel.Text = "Dashboard";
			DashboardForm dashboardForm_Vbr = new DashboardForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			dashboardForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(dashboardForm_Vbr);
			dashboardForm_Vbr.Show();
			instance = this;
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});
		}
		private void Form1_load(object sender, EventArgs e)
		{
			timer1.Start();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});
		}//Time
		private void timer1_Tick(object sender, EventArgs e)
		{
			DateLabel.Text = DateTime.Now.ToLongDateString();
			TimeLabel.Text = DateTime.Now.ToLongTimeString();
		}//Time
		bool drag = false;
		Point start_point = new Point(0, 0);
		private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
		{
			drag = true; //drag is your variable flag.
			start_point = new Point(e.X, e.Y);
		}//Move
		private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
		{
			drag = false;
		}//Move
		private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
		{
			if (drag)
			{
				Point p = PointToScreen(e.Location);
				this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
			}
		}//Move
		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}//MinimizeButton
		private void CloseButton_Click(object sender, EventArgs e)
		{
			Close();
		}//CloseButton
		private void DashboardButton_Click(object sender, EventArgs e)
		{
			DashboardTitleLabel.Text = "Dashboard";
			this.PnlFormLoader.Controls.Clear();
			DashboardForm dashboardForm_Vbr = new DashboardForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			dashboardForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(dashboardForm_Vbr);
			dashboardForm_Vbr.Show();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector | Dashboard",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});

		}//Dashboard
		private void CosmeticsButton_Click(object sender, EventArgs e)
		{
			DashboardTitleLabel.Text = "Cosmetics";
			this.PnlFormLoader.Controls.Clear();
			CosmeticsForm CosmeticsForm_Vbr = new CosmeticsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			CosmeticsForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(CosmeticsForm_Vbr);
			CosmeticsForm_Vbr.Show();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector | Cosmetics",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});
		}//Cosmetics
		private void VersionsButton_Click(object sender, EventArgs e)
		{
			DashboardTitleLabel.Text = "Versions";
			this.PnlFormLoader.Controls.Clear();
			VersionsForm VersionsForm_Vbr = new VersionsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			VersionsForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(VersionsForm_Vbr);
			VersionsForm_Vbr.Show();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector | Versions",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});
		}//Versions
		private void AboutButton_Click(object sender, EventArgs e)
		{
			DashboardTitleLabel.Text = "About";
			this.PnlFormLoader.Controls.Clear();
			AboutForm AboutForm_Vbr = new AboutForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			AboutForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(AboutForm_Vbr);
			AboutForm_Vbr.Show();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector | About",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});
		}//About
		private void SettingsButton_Click(object sender, EventArgs e)
		{
			DashboardTitleLabel.Text = "Settings";
			this.PnlFormLoader.Controls.Clear();
			SettingsForm SettingsForm_Vbr = new SettingsForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
			SettingsForm_Vbr.FormBorderStyle = FormBorderStyle.None;
			this.PnlFormLoader.Controls.Add(SettingsForm_Vbr);
			SettingsForm_Vbr.Show();
			DiscordRpcClient client = new DiscordRpcClient("866924923338620978");
			client.Initialize();
			client.SetPresence(new RichPresence()
			{
				State = "",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageText = "EZE Injector | Settings",
					SmallImageText = "Minecraft: Bedrock Edition",
					LargeImageKey = "EZE",
					SmallImageKey = "mcbe"
				}
			});

		}//Settings
		public void refresh()
		{
			/*if (label2.Text == "works")
			{
				Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
			}
			else if (label2.Text == "false")
			{
				Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
			}*/
		}
		private void timer2_Tick(object sender, EventArgs e)
		{
			refresh();
		}
		private void UserNameLabel_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCx6JmvxqakKXyr_FvsraQQw");
		}
	}
}
