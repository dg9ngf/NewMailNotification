using System;
using System.Runtime.InteropServices;

namespace NewMailNotification
{
	public static class SafeNativeMethods
	{
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPLACEMENT
		{
			public int Length;
			public int Flags;
			public int ShowCmd;
			public POINT MinPosition;
			public POINT MaxPosition;
			public RECT NormalPosition;

			public static WINDOWPLACEMENT Default
			{
				get
				{
					WINDOWPLACEMENT result = new WINDOWPLACEMENT();
					result.Length = Marshal.SizeOf(result);
					return result;
				}
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left, Top, Right, Bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X, Y;
		}
	}
}
