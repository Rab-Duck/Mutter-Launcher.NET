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
        private string name;
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
            fileType = FileType.CLSID;
            this.name = name;
            this.path = clsidpath;
        }

        public Item cloneItem()
        {
            return (Item)MemberwiseClone();
        }

        public bool execute(string option, Keys modifiers)
        {
            string curdir = System.Environment.CurrentDirectory;

            if (fileType == FileType.NORMAL)
            {
                System.Environment.CurrentDirectory = Path.GetDirectoryName(path);
            }

            try
            {
                if ((modifiers & Keys.Shift) == Keys.Shift)
                {
                    System.Diagnostics.Process.Start("explorer", "/select,\"" + path + "\"");
                }
                else
                {
                    System.Diagnostics.Process.Start(path, option);
                }
            }
            finally
            {
                if (fileType == FileType.NORMAL)
                {
                    System.Environment.CurrentDirectory = Path.GetDirectoryName(curdir);
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
            if(name == null)
            {
                SHFILEINFO shFileInfo = new SHFILEINFO();
                NativeMethods.SHGetFileInfo(path, 0, out shFileInfo, (uint)Marshal.SizeOf(shFileInfo), NativeMethods.SHGFI_DISPLAYNAME);
                if(shFileInfo.szDisplayName != null && shFileInfo.szDisplayName.Length > 0)
                {
                    name = shFileInfo.szDisplayName;
                }
                else
                {
                    name = Path.GetFileName(path);
                }
            }
            return name;
        }

        public string getItemPath()
        {
            return path;
        }

        public ItemType getType()
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

        public void setItemPath(string path)
        {
            itemType = ItemType.TYPE_NORMAL;
            this.path = path;
            if (bIconCached)
            {
                setIconIndex();
            }
        }

        public void setType(ItemType type)
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
        public void setConvItemName(string convName)
        {
            this.convName = convName;
        }

        public string getConvItemName()
        {
            return convName;
        }
    }
}
