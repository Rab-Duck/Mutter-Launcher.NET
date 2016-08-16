using System;
using System.Runtime.InteropServices;

namespace MutterLauncher
{
	[ StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto) ]
	public struct SHFILEINFO 
	{
		public IntPtr hIcon;
		public int iIcon;
		public uint dwAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}
	[ StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto) ]
	public struct LVITEM
	{
		public uint mask;
		public int  iItem;
		public int  iSubItem;
		public int  state;
		public int  stateMask;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string pszText;
		public int  cchTextMax;
		public int  iImage;
		public uint lParam;
		public int  iIndent;
	}
	/// <summary>
	/// NativeMethods ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public class NativeMethods
	{
		public const int SHGFI_LARGEICON        = 0x00000000;
		public const int SHGFI_SMALLICON        = 0x00000001;
        public const int SHGFI_PIDL             = 0x00000008;
        public const int SHGFI_USEFILEATTRIBUTES= 0x00000010;
		public const int SHGFI_OVERLAYINDEX     = 0x00000040;
		public const int SHGFI_ICON             = 0x00000100;
		public const int SHGFI_SYSICONINDEX     = 0x00004000;
		public const int LVSIL_NORMAL = 0;
		public const int LVSIL_SMALL  = 1;
		public const int LVIS_OVERLAYMASK = 0x0F00;
		public const int LVM_SETIMAGELIST = 0x1003;
		public const int LVM_SETITEMSTATE = 0x102B;
		[DllImport("shell32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
			out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(IntPtr pIDL, uint dwFileAttributes,
            out SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, ref LVITEM lParam);
		[DllImport("user32.dll", SetLastError=true)]
		public static extern bool DestroyIcon(IntPtr hIcon);
        [DllImport("shell32.dll")]
        public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string name, IntPtr bindingContext, [Out()] out IntPtr pidl, uint sfgaoIn, [Out()] out uint psfgaoOut);
        public NativeMethods()
		{
		}
	}
}
