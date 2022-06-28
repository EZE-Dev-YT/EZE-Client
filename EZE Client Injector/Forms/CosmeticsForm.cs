using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using Octokit;
using WK.Libraries.BetterFolderBrowserNS;

namespace EZ_Client_Injector
{
	public partial class CosmeticsForm : Form
	{
		private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
		public static bool OnlineCheck()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://github.com/");
			request.Timeout = 15000;
			request.Method = "HEAD";
			try
			{
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					return response.StatusCode == HttpStatusCode.OK;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}
		public static bool InternetCheck()
		{
			int desc;
			bool internetcheckone = InternetGetConnectedState(out desc, 0);
			bool internetchecktwo = OnlineCheck();

			if (internetcheckone == true && internetchecktwo == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public CosmeticsForm()
		{
			InitializeComponent();

			bool internet = InternetCheck();
			if (internet)
			{
				resetCapes();
				resetAnimated();

				//Auto Download
				//await DownloadManager.DownloadAsync(string.Format(@"https://github.com/" + link_settings.repoOwner + "/" + link_settings.downloadRepo + @"/blob/main/Cosmetics/{0}?raw=true", "BlackVentileCape.zip"), minecraftResourcePacks, "BlackVentileCape.zip");
			}
			else
			{
				MessageBox.Show("Internet", "You do not a wifi connection");
			}
		}
		private async void resetCapes()
		{
		}
		private async void resetAnimated()
		{
		}
		private void startDownload(string toDownload, string saveLocation) // starts the download loop on a new thread so the gui doesnt oof
		{
			Thread thread = new Thread(() =>
			{
				WebClient client = new WebClient();
				client.DownloadFileAsync(new Uri(toDownload), saveLocation);
			});
			thread.Start();
		}
	}
}