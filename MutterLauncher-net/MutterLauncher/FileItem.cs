using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    class FileItem : Item
    {
        private static bool bIconCached = true;
        private string path;
        private int iconIndex = -1;
        private ItemType type;

        public FileItem(string fullPath)
        {
            setItemPath(fullPath);
        }

        public Item cloneItem()
        {
            return (Item)MemberwiseClone();
        }

        public bool execute(string option, Keys modifiers)
        {
            if((modifiers & Keys.Shift) == Keys.Shift)
            {
                if (System.Diagnostics.Process.Start(Path.GetDirectoryName(path), "/select,\"" + Path.GetFileName(path) + "\"" ) == null)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if(System.Diagnostics.Process.Start(path, option) == null)
                {
                    return false;
                }
                return true;
            }
        }

        public int getIconIndex()
        {
            setIconIndex();

            return iconIndex;
        }

        public string getItemName()
        {
            return Path.GetFileName(path);
        }

        public string getItemPath()
        {
            return path;
        }

        public ItemType getType()
        {
            return type;
        }

        public bool historyEquals(Item item)
        {
            throw new NotImplementedException();
        }

        public void setItemPath(string path)
        {
            type = ItemType.TYPE_NORMAL;
            this.path = path;
            if (bIconCached)
            {
                setIconIndex();
            }
        }

        public void setType(ItemType type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return getItemName();
        }

        private void setIconIndex()
        {
            if (iconIndex == -1)
            {
                // reference: http://acha-ya.cocolog-nifty.com/blog/2010/11/2-f06c.html
                SHFILEINFO shFileInfo = new SHFILEINFO();
                shFileInfo.iIcon = -1;
                shFileInfo.hIcon = IntPtr.Zero;
                NativeMethods.SHGetFileInfo(path, 0, out shFileInfo,
                    (uint)Marshal.SizeOf(shFileInfo), NativeMethods.SHGFI_ICON |
                    NativeMethods.SHGFI_SYSICONINDEX | NativeMethods.SHGFI_OVERLAYINDEX);
                if (shFileInfo.iIcon == -1)
                {
                    iconIndex = 1;
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
    }
}
