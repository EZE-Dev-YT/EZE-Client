using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZ_Client_Injector
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string procName = Process.GetCurrentProcess().ProcessName;
			Process[] proc = Process.GetProcessesByName(procName);
			if (proc.Length > 1) // 1 because of the current process
			{
				MessageBox.Show("the launcher is already open!");

				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
