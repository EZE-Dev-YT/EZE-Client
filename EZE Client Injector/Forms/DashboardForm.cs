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

namespace EZ_Client_Injector
{
	public partial class DashboardForm : Form
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
			uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		static extern IntPtr CreateRemoteThread(IntPtr hProcess,
			IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[System.Runtime.InteropServices.DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
		const int PROCESS_CREATE_THREAD = 0x0002;
		const int PROCESS_QUERY_INFORMATION = 0x0400;
		const int PROCESS_VM_OPERATION = 0x0008;
		const int PROCESS_VM_WRITE = 0x0020;
		const int PROCESS_VM_READ = 0x0010;
		// used for memory allocation
		const uint MEM_COMMIT = 0x00001000;
		const uint MEM_RESERVE = 0x00002000;
		const uint PAGE_READWRITE = 4;
		static bool alreadyAttemptedInject = false;
		string DllPath;

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
		public static void applyAppPackages(string DLLPath)
		{
			FileInfo InfoFile = new FileInfo(DLLPath);
			FileSecurity fSecurity = InfoFile.GetAccessControl();
			fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier("S-1-15-2-1"), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
			InfoFile.SetAccessControl(fSecurity);
		}
		private void InitialValues() // sets values needed first
		{
			ProgressBar.Width = 0;
		}
		public static void InjectDLL(string DownloadedDllFilePath, Control label, Control panel, Control Form1)//creates the function and the controls so it can modify values outside of it
		{
			Form1.Refresh(); // refreshes the form
			Process[] targetProcessIndex = Process.GetProcessesByName("Minecraft.Windows"); //gets the prosss from the prosseslisy
			if (targetProcessIndex.Length > 0) //if the prosses list is more then 0 it means its active
			{
				applyAppPackages(DownloadedDllFilePath); //runs the function apply app packeges allowing the dll to inject without administrater

				Process targetProcess = Process.GetProcessesByName("Minecraft.Windows")[0];//gets the prosses now that it knows minecraft is open
				IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id); // creates a handle so it can do shiz

				IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA"); //loads library a due to every app using it       this is how it actully injects

				IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE); //makes some space in the memory to hold the dll

				UIntPtr bytesWritten; // byteswritten value L
				WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(DownloadedDllFilePath), (uint)((DownloadedDllFilePath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten); // basicly copys the dll to the memory that just got made
				CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero); //loads the dll with dloadlibrarya into the prosses

				alreadyAttemptedInject = false;

				label.Text = ("Injected EZE Client/Custom!"); // changes the text valuse so the user knows its done
				Form1.Refresh(); // refreshes the page so the user can see /|\
			}
			else
			{
				if (!alreadyAttemptedInject) // if its 0 and it has failed to inject then minecraft aint open
				{
					alreadyAttemptedInject = true;
					panel.Width = 0;
					label.Text = "Error Injection Failed";
					Form1.Refresh();
					MessageBox.Show("Open Minecraft First Bro");
				}
				else // this means they a fking idiot and trying to idn inject it into minecraft java or smt
				{
					panel.Width = 0;
					label.Text = "Not Injected";
					Form1.Refresh();
					MessageBox.Show("You Kinda Need Minecraft Bedrock To Inject... idiot"); //stuped
					alreadyAttemptedInject = false;
				}
			}
		}
		private void InjectButton_Click(object sender, EventArgs e)
		{
			bool internet = InternetCheck();
			if (devmodewthing.Text == "devmodeFalse")
			{
				if (internet == true)
				{
					Process[] targetProcessIndex = Process.GetProcessesByName("Minecraft.Windows"); //gets the prosss from the prosseslisy
					if (targetProcessIndex.Length > 0) //if the prosses list is more then 0 it means its active
					{
						string Title = "EZ Injector"; // sets the useragent's title
						WebClient webClient = new WebClient(); // new webclient kinda self explanitory
						webClient.Headers.Add(HttpRequestHeader.UserAgent, Title);
						webClient.Proxy = null;
						string DownloadUrl = ("https://github.com/EZE-Dev-YT/EZE-Client/releases/latest/download/EZEClientPublic.dll"); // gets the dll 
						string DownloadedDllFilePath = Path.GetTempPath() + "/EZEClientPublic.dll"; //gets the temp path and merges it with the dll name
						startDownload(DownloadUrl, DownloadedDllFilePath); //runs the cool af download function
					}
					else
					{
						ProgressBar.Width = 0;
						InfoText.Text = "Error, Injection Failed"; // you can probly understand this section fine
						this.Refresh();
						MessageBox.Show("Open Minecraft First BRO");
					}
				}
				else
				{
					ProgressBar.Width = 0;
					InfoText.Text = "Error Injection Failed. No Internet"; // you can probly understand this section fine
					Refresh();
					MessageBox.Show("     Cannot Connect To Server\n       Check Your Connection");
				}
			}
			else if (devmodewthing.Text == "devmodeTrue")
			{
				
			}
		}
		private void startDownload(string toDownload, string saveLocation) // starts the download loop on a new thread so the gui doesnt oof
		{
			Thread thread = new Thread(() =>
			{
				WebClient client = new WebClient();
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.DownloadFileAsync(new Uri(toDownload), saveLocation);
			});
			thread.Start();
		}
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) //runs every time the download has changed
		{
			this.BeginInvoke((MethodInvoker)delegate
			{
				double BytesDownloaded = double.Parse(e.BytesReceived.ToString()); // gets how much data has been downloaded
				double TotalBytes = double.Parse(e.TotalBytesToReceive.ToString());//gets total ammount
				double percentage = BytesDownloaded / TotalBytes * 100; //makes it divisible by 100 so it can be a %
				InfoText.Text = "Downloading " + Convert.ToInt32(percentage) + "%  -  " + Convert.ToInt32(BytesDownloaded / 1024 / 1024) + " / " + Convert.ToInt32(TotalBytes / 1024 / 1024) + " mb"; //gets the %, ammount downloaded and ammount total rounded to mbs
				double PanelPercent = Math.Round(2.7 * percentage, 0); //takes 2.7 and multiplys it by the current %     devide the with *270 by *100 and plug it in if you ever change the %bar size
				ProgressBar.Width = int.Parse(Math.Truncate(PanelPercent).ToString()); // takes the value on the line above and makes the progress bar = to the current value
			});
		}
		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate
			{
				InjectDLL(Path.GetTempPath() + "/EZEClientPublic.dll", InfoText, ProgressBar, this); //runs the function inject dll with the temp path being merged with the dll name, the seccond will carry the lable over so the function can modify the labe, the third will bring the progress bar so it can change the with and lastly the "this" so it can do things like this.refresh();
			});
		}
		public DashboardForm()
		{
			InitializeComponent();
			CustomDLLButton.Hide();
		}
		private void DevModeToggle_CheckedChanged(object sender, EventArgs e)
		{
			if (DevModeToggle.Checked)
			{
				CustomDLLButton.Show();
				InjectButton.Width = CustomDLLButton.Width;
				InjectButton.Location = InjectLocationButton.Location;
				devmodewthing.Text = "devmodeTrue";
			}
			else
			{
				CustomDLLButton.Hide();
				InjectButton.Width = LaunchMinecraftButton.Width;
				InjectButton.Location = InjectButtonlocation.Location;
				devmodewthing.Text = "devmodeFalse";
			}
		}
		private void LaunchMinecraftButton_Click(object sender, EventArgs e)
		{
			Process.Start("minecraft://");
		}
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/h9WrD6rxE2");
		}
		private void CustomDLLButton_Click(object sender, EventArgs e)
		{
			var FileIn = new OpenFileDialog()
			{
				RestoreDirectory = true,
				Filter = "DLL Files (*.dll)|*.dll|DLL Files (*.*)|*,*"
			};

			if (FileIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (FileIn.SafeFileName.ToLower().EndsWith("*.dll"))
				{
					DllPath = FileIn.FileName;
					InfoText.Text = "Dll Selected";
					Refresh();
				}
				else
				{
					InfoText.Text = "No Dll Selected";
					Refresh();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			
		}
	}
}