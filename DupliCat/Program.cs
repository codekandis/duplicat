using System;
using System.Windows.Forms;
using CodeKandis.DupliCat.Forms;

namespace CodeKandis.DupliCat
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point of the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run(
				new Main()
			);
		}
	}
}
