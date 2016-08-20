using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MutterLauncher
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct NMHDR
    {
        public IntPtr hwndFrom;
        public IntPtr idFrom;
        public int code;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LV_DISPINFO
    {
        public NMHDR hwndFrom;
        public LVITEM item;
    }

    class ImageCallback : IMessageFilter
    {

        private const int WM_NOTIFY = 0x004E;
        private const int LVN_GETDISPINFO = 0 - 100 - 77;


        private IntPtr hLsv;
                               
        public ImageCallback(IntPtr hLsv)
        {
            this.hLsv = hLsv;
            Application.AddMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if(m.Msg != WM_NOTIFY)
            {
                return false;
            }
            var notify = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
            if (notify.code == LVN_GETDISPINFO)
            {
                var dispinfo = (LV_DISPINFO)Marshal.PtrToStructure(m.LParam, typeof(LV_DISPINFO));
                // System.Console.WriteLine(dispinfo);
                return true;
            }
            return false;
        }
    }
}
