using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    [Serializable]
    public class UserItem : Item
    {
        private string name;
        private string cmd;
        private ItemType itemType;
        private string convName = null;
        [NonSerialized]
        private int iconIndex = -1;

        public bool bCmdOption { get;  }
        public bool bUrlEncode { get;  }
        public string encoding { get;  }

        /*
         * 
         * name: display name
         * cmd: cmd 
         * bFix: 
         * 
         */
        public UserItem(string name, string cmd, bool bFix, bool bCmdOption, bool bUrlEncode, string encoding)
        {
            this.name = name;
            // set convName
            convName = Util.SafeStrConv(name);

            this.cmd = cmd;
            if (bFix)
            {
                this.itemType = ItemType.TYPE_FIX;
            }
            else
            {
                this.itemType = ItemType.TYPE_NORMAL;
            }
            this.bCmdOption = bCmdOption;
            this.bUrlEncode = bUrlEncode;
            this.encoding = encoding;
        }

        public Item cloneItem()
        {
            return (Item)MemberwiseClone();
        }

        public bool execute(string strExec, Keys modifiers)
        {
            string execCmd;

            if ((modifiers & Keys.Shift) == Keys.Shift)
            {
                throw new ArgumentException(Properties.Resources.ErrNotSupportOpenDir);
            }

            // fix exec cmd string
            if (itemType == ItemType.TYPE_FIX)
            {
                execCmd = strExec;
            }
            else
            {
                SearchCmd sc = Util.analyzeSearchCmd(strExec);
                if (sc.strOption == null)
                {
                    sc.strOption = "";
                }
                execCmd = sc.strOption;
            }
            if (bUrlEncode)
            {
                execCmd = urlEncode(execCmd);
            }
            execCmd = cmd.Replace("%1", execCmd);

            // fix cmd option string
            string[] args;
            if (bCmdOption)
            {
                // reference: https://www.pinvoke.net/default.aspx/shell32.commandlinetoargvw
                int numberOfArgs;
                IntPtr ptrToSplitArgs;
                string[] splitArgs;

                ptrToSplitArgs = NativeMethods.CommandLineToArgvW(execCmd, out numberOfArgs);

                // CommandLineToArgvW returns NULL upon failure.
                if (ptrToSplitArgs == IntPtr.Zero)
                    return false;

                // Make sure the memory ptrToSplitArgs to is freed, even upon failure.
                try
                {
                    splitArgs = new string[numberOfArgs];

                    // ptrToSplitArgs is an array of pointers to null terminated Unicode strings.
                    // Copy each of these strings into our split argument array.
                    for (int i = 0; i < numberOfArgs; i++)
                    {
                        splitArgs[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(ptrToSplitArgs, i * IntPtr.Size));
                    }
                }
                finally
                {
                    // Free memory obtained by CommandLineToArgW.
                    NativeMethods.LocalFree(ptrToSplitArgs);
                }
                args = new string[] { splitArgs[0], splitArgs.Length > 1 ? string.Join(" ", splitArgs.ToList().GetRange(1, splitArgs.Length-1).ToArray()) : null };
            }
            else
            {
                args = new string[]{ execCmd };
            }

            if ((modifiers & Keys.Control) == Keys.Control)
            {
                // run as admin
                //reference: http://dobon.net/vb/dotnet/system/runelevated.html
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = args[0];
                psi.Verb = "runas"; // as Admin
                SearchCmd sc = Util.analyzeSearchCmd(strExec);
                psi.Arguments = args.Length > 1 ? args[1] : null;
                psi.ErrorDialog = false;
                System.Diagnostics.Process.Start(psi);

                 return true;
            }

            // exec
            if (args.Length == 1)
            {
                System.Diagnostics.Process.Start(args[0]);
            }
            else
            {
                System.Diagnostics.Process.Start(args[0], args[1]);
            }

            return true;
        }

        private string urlEncode(string str)
        {
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(encoding);
            return System.Web.HttpUtility.UrlEncode(str, enc);
        }

        public string getConvItemName()
        {
            return convName;
        }

        public int getIconIndex()
        {
            SHFILEINFO shFileInfo = new SHFILEINFO();
            shFileInfo.iIcon = -1;
            shFileInfo.hIcon = IntPtr.Zero;

            string iconpath;
            if (itemType == ItemType.TYPE_FIX)
            {
                iconpath = System.IO.Path.GetFullPath(System.Environment.SystemDirectory + "\\..\\explorer.exe");
            }
            else
            {
                iconpath = System.Environment.SystemDirectory + "\\taskmgr.exe";
            }

            NativeMethods.SHGetFileInfo(iconpath, 0, out shFileInfo,
                (uint)Marshal.SizeOf(shFileInfo),
                NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SYSICONINDEX |
                NativeMethods.SHGFI_OVERLAYINDEX);

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

            return iconIndex;
        }

        public string getItemName()
        {
            return name;
        }

        public string getItemPath()
        {
            return cmd;
        }

        public ItemType getItemType()
        {
            return itemType;
        }

        public bool historyEquals(Item item)
        {
            if (item.GetType() == typeof(UserItem))
            {
                return (item.getItemName() == this.getItemName()) && (item.getItemPath() == this.getItemPath());
            }
            return false;
        }

        public void setItemType(ItemType type)
        {
            this.itemType = type;
        }
    }
}
