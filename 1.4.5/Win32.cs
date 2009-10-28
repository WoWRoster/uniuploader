using System.Runtime.InteropServices;

namespace WindowsApplication10
{
	/// <summary>
	/// Summary description for Win32.
	/// </summary>
	public class Win32
	{
		public const int WM_SYSCOMMAND = 0x0112; 
		public const int SC_CLOSE = 0xF060; 

		[DllImport("user32.dll")] 
		public static extern int FindWindow( 
			string lpClassName, // class name 
			string lpWindowName // window name 
			); 

		[DllImport("user32.dll")] 
		public static extern int SendMessage( 
			int hWnd, // handle to destination window 
			uint Msg, // message 
			int wParam, // first message parameter 
			int lParam // second message parameter 
			); 
	}
}
