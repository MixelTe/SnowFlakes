using System.Runtime.InteropServices;
using System.Text;
using HWND = nint;

namespace SnowFlakes
{
	public static class OpenWindowGetter
	{
		public static IDictionary<HWND, Tuple<string, Rectangle>> GetOpenWindows()
		{
			var shellWindow = GetShellWindow();
			var windows = new Dictionary<HWND, Tuple<string, Rectangle>>();

			EnumWindows(delegate (HWND hWnd, int lParam)
			{
				if (hWnd == shellWindow) return true;
				if (!IsWindowVisible(hWnd) || IsIconic(hWnd)) return true;

				var length = GetWindowTextLength(hWnd);
				if (length == 0) return true;

				var builder = new StringBuilder(length);
				GetWindowText(hWnd, builder, length + 1);

				if (!GetWindowRectangle(hWnd, out RECT rct)) return true;

				windows[hWnd] = new(builder.ToString(), Rectangle.FromLTRB(rct.Left, rct.Top, rct.Right, rct.Bottom));
				return true;

			}, 0);

			return windows;
		}

		private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

		[DllImport("USER32.DLL")]
		private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowTextLength(HWND hWnd);

		[DllImport("USER32.DLL")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWindowVisible(HWND hWnd);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool IsIconic(IntPtr hWnd);

		[DllImport("USER32.DLL")]
		private static extern HWND GetShellWindow();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowRect(HWND hWnd, out RECT lpRect);

		[DllImport("dwmapi.dll")]
		public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out RECT pvAttribute, int cbAttribute);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
		[Flags]
		private enum DwmWindowAttribute : uint
		{
			DWMWA_NCRENDERING_ENABLED = 1,
			DWMWA_NCRENDERING_POLICY,
			DWMWA_TRANSITIONS_FORCEDISABLED,
			DWMWA_ALLOW_NCPAINT,
			DWMWA_CAPTION_BUTTON_BOUNDS,
			DWMWA_NONCLIENT_RTL_LAYOUT,
			DWMWA_FORCE_ICONIC_REPRESENTATION,
			DWMWA_FLIP3D_POLICY,
			DWMWA_EXTENDED_FRAME_BOUNDS,
			DWMWA_HAS_ICONIC_BITMAP,
			DWMWA_DISALLOW_PEEK,
			DWMWA_EXCLUDED_FROM_PEEK,
			DWMWA_CLOAK,
			DWMWA_CLOAKED,
			DWMWA_FREEZE_REPRESENTATION,
			DWMWA_LAST
		}

		public static bool GetWindowRectangle(IntPtr hWnd, out RECT rect)
		{
			var size = Marshal.SizeOf(typeof(RECT));
			var r = DwmGetWindowAttribute(hWnd, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);
			return r == 0;
		}
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("a5cd92ff-29be-454c-8d04-d82879fb3f1b")]
	[System.Security.SuppressUnmanagedCodeSecurity]
	public partial interface IVirtualDesktopManager
	{
		[PreserveSig]
		int IsWindowOnCurrentVirtualDesktop(
			[In] IntPtr TopLevelWindow,
			[Out] out int OnCurrentDesktop
			);
		[PreserveSig]
		int GetWindowDesktopId(
			[In] IntPtr TopLevelWindow,
			[Out] out Guid CurrentDesktop
			);

		[PreserveSig]
		int MoveWindowToDesktop(
			[In] IntPtr TopLevelWindow,
			[MarshalAs(UnmanagedType.LPStruct)]
			[In]Guid CurrentDesktop
			);
	}

	[ComImport, Guid("aa509086-5ca9-4c25-8f95-589d3c07b48a")]
	public class CVirtualDesktopManager
	{

	}
	public class VirtualDesktopManager
	{
		public VirtualDesktopManager()
		{
			cmanager = new CVirtualDesktopManager();
			manager = (IVirtualDesktopManager)cmanager;
		}
		~VirtualDesktopManager()
		{
			manager = null;
			cmanager = null;
		}
		private CVirtualDesktopManager cmanager = null;
		private IVirtualDesktopManager manager;

		public bool IsWindowOnCurrentVirtualDesktop(IntPtr TopLevelWindow)
		{
			int result;
			int hr;
			if ((hr = manager.IsWindowOnCurrentVirtualDesktop(TopLevelWindow, out result)) != 0)
			{
				Marshal.ThrowExceptionForHR(hr);
			}
			return result != 0;
		}

		public Guid GetWindowDesktopId(IntPtr TopLevelWindow)
		{
			Guid result;
			int hr;
			if ((hr = manager.GetWindowDesktopId(TopLevelWindow, out result)) != 0)
			{
				Marshal.ThrowExceptionForHR(hr);
			}
			return result;
		}

		public void MoveWindowToDesktop(IntPtr TopLevelWindow, Guid CurrentDesktop)
		{
			int hr;
			if ((hr = manager.MoveWindowToDesktop(TopLevelWindow, CurrentDesktop)) != 0)
			{
				Marshal.ThrowExceptionForHR(hr);
			}
		}
	}

}