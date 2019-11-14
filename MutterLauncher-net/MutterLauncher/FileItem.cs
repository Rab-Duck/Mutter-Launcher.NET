using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public enum FileType
    {
        NORMAL = 1,
        CLSID = 2,
    }

    [Serializable]
    class FileItem : Item
    {
        private static bool bIconCached = false; // false fixed for accurate icons
        private string path;
        private string name=null;
        [NonSerialized] private int iconIndex = -1;
        private ItemType itemType;
        private FileType fileType;
        private string convName = null;

        public FileItem(string fullPath)
        {
            fileType = FileType.NORMAL;
            setItemPath(fullPath);
        }

        public FileItem(string clsidpath, string name)
        {
            this.fileType = FileType.CLSID;
            this.name = name;
            setItemPath(clsidpath);
        }

        public Item cloneItem()
        {
            return (Item)MemberwiseClone();
        }

        public bool execute(string strExec, Keys modifiers)
        {
            string curdir = System.Environment.CurrentDirectory;


            if (fileType == FileType.NORMAL)
            {
                System.Environment.CurrentDirectory = Path.GetDirectoryName(path);
            }

            try
            {
                SearchCmd sc = Util.analyzeSearchCmd(strExec);
                if ((modifiers & Keys.Shift) == Keys.Shift)
                {
                    try
                    {
                        System.Diagnostics.Process.Start("explorer", "/select,\"" + path + "\"");
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Exception when explorer start");
                        Trace.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    }
                }
                else if ((modifiers & Keys.Control) == Keys.Control)
                {
                    // run as admin
                    // SHFILEINFO shFileInfo = new SHFILEINFO();

                    //reference: http://dobon.net/vb/dotnet/system/runelevated.html
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = path;
                    psi.Verb = "runas"; // as Admin
                    psi.Arguments = sc.strOption;
                    psi.ErrorDialog = false;
                    System.Diagnostics.Process.Start(psi);

                }
                else
                {
                    // run
                    if (string.IsNullOrEmpty(sc.strOption))
                        System.Diagnostics.Process.Start(path);
                    else
                        System.Diagnostics.Process.Start(path, sc.strOption);
                }
            }
            finally
            {
                if (fileType == FileType.NORMAL)
                {
                    System.Environment.CurrentDirectory = curdir;
                }
            }

            return true;
        }

        public int getIconIndex()
        {
            setIconIndex();

            return iconIndex;
        }

        public string getItemName()
        {
            return name;
        }

        public string getItemPath()
        {
            return path;
        }

        public ItemType getItemType()
        {
            return itemType;
        }

        public bool historyEquals(Item item)
        {
            if (item.GetType() == typeof(FileItem)) {
                return (item.getItemPath() == this.getItemPath());
            }
            return false;
        }

        private void setItemPath(string path)
        {
            itemType = ItemType.TYPE_NORMAL;

            // set path
            this.path = path;

            if (bIconCached)
            {
                // set icon
                setIconIndex();
            }

            if (name == null)
            {
                // set name
                SHFILEINFO shFileInfo = new SHFILEINFO();
                NativeMethods.SHGetFileInfo(path, 0, out shFileInfo, (uint)Marshal.SizeOf(shFileInfo), NativeMethods.SHGFI_DISPLAYNAME);
                if (shFileInfo.szDisplayName != null && shFileInfo.szDisplayName.Length > 0)
                {
                    name = shFileInfo.szDisplayName;
                }
                else
                {
                    name = Path.GetFileName(path);
                }
            }

            if (convName == null)
            {
                // set convName
                convName = Util.SafeStrConv(name);
            }
        }

        public void setItemType(ItemType type)
        {
            this.itemType = type;
        }

        public override string ToString()
        {
            return getItemName();
        }

        private void setIconIndex()
        {
            if (bIconCached || iconIndex == -1 || iconIndex == 0) // 0 は serialize 対策
            {
                // reference: http://acha-ya.cocolog-nifty.com/blog/2010/11/2-f06c.html
                SHFILEINFO shFileInfo = new SHFILEINFO();
                shFileInfo.iIcon = -1;
                shFileInfo.hIcon = IntPtr.Zero;
                if (fileType == FileType.NORMAL)
                {
                    NativeMethods.SHGetFileInfo(path, 0, out shFileInfo,
                        (uint)Marshal.SizeOf(shFileInfo), 
                        NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SYSICONINDEX |
                        NativeMethods.SHGFI_OVERLAYINDEX);

                }
                else if (fileType == FileType.CLSID)
                {
                    IntPtr pidl;
                    uint sfgaoOut;
                    NativeMethods.SHParseDisplayName(path, IntPtr.Zero, out pidl, 0, out sfgaoOut);
                    NativeMethods.SHGetFileInfo(pidl, 0, out shFileInfo,
                        (uint)Marshal.SizeOf(shFileInfo),
                        NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SYSICONINDEX |
                        NativeMethods.SHGFI_OVERLAYINDEX | NativeMethods.SHGFI_PIDL);

                }

                if (shFileInfo.iIcon == -1)
                {
                    iconIndex = 1; // for dummy
                }
                else
                {
                    iconIndex = shFileInfo.iIcon;
                }
                if (shFileInfo.hIcon != IntPtr.Zero)
                {
                    NativeMethods.DestroyIcon(shFileInfo.hIcon);
                }
            }
        }

        public string getConvItemName()
        {
            return convName;
        }

        public bool exists()
        {
            if (path.StartsWith(@"\\") || path.Substring(1,2) == @":\" )
            {
                // \\～ か ?:\ のパス表現だったら、ファイルの実際の有無をチェック
                bool result = File.Exists(path);
                Trace.WriteLine($"{path} exists: {result}");
                return result;
            }
            else
            {
                // それ以外（shell:AppsFolder とか）は true で固定
                return true;
            }

        }
    }
}
