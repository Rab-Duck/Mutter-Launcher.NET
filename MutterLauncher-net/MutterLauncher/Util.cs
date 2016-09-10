using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutterLauncher
{
    public struct SearchCmd
    {
        public int matchingType;
        public string strSearch;
        public string strOption;

        public SearchCmd(int matchingType, string strSearch, string strOption)
        {
            this.matchingType = matchingType;
            this.strSearch = strSearch;
            this.strOption = strOption;
        }
    }

    public class Util
    {
        /*
         * 
         *
         * 
         */
        public static SearchCmd analyzeSearchCmd(string strCmd)
        {
            string str = strCmd;

            SearchCmd sc = new SearchCmd(0, null, null);
        
            if (String.IsNullOrEmpty(str))
            {
                return sc;
            }

            // check matching type
            sc.strSearch = "";
            if (str[0] == Properties.Settings.Default.ChrStartWith)
                sc.matchingType = 1; // StartsWith
            else if (str[0] == Properties.Settings.Default.ChrEqual)
                sc.matchingType = 3; // equal
            else if (str[0] == Properties.Settings.Default.ChrSkipMatching)
                sc.matchingType = 4; // skip-matching

            if (sc.matchingType > 0)
            {
                str = str.Substring(1);
                if (String.IsNullOrEmpty(str))
                {
                    return sc;
                }
            }

            int pos = -1;
            if (!Properties.Settings.Default.SpaceIsOption || (pos = str.IndexOf(' ')) == -1)
            {
                pos = str.Length;
            }
            if (pos > 0 && str[pos - 1] == Properties.Settings.Default.ChrEndWith)
            {
                if (sc.matchingType == 1)
                {
                    sc.matchingType = 3; // equal
                }
                else
                {
                    sc.matchingType = 2; // EndWith
                }
                str = str.Substring(0, pos-1) + str.Substring(pos);
                pos--;
            }

            if (String.IsNullOrEmpty(str))
            {
                return sc;
            }

            // check search-string
            if (pos == str.Length)
            {
                sc.strSearch = str;
                return sc;
            }

            sc.strSearch = str.Substring(0, pos);
            sc.strOption = str.Substring(pos + 1);

            return sc;
        }

        static int convType = 0;
        public static string SafeStrConv(string str)
        {
            string strConv;

            switch (convType)
            {
                case 0:
                    try
                    {
                        strConv = Strings.StrConv(str, VbStrConv.Uppercase | VbStrConv.Wide | VbStrConv.Hiragana);
                        convType = 1;
                    }
                    catch (ArgumentException)
                    {
                        strConv = Strings.StrConv(str, VbStrConv.Uppercase);
                        convType = -1;
                    }
                    break;
                case 1:
                    strConv = Strings.StrConv(str, VbStrConv.Uppercase | VbStrConv.Wide | VbStrConv.Hiragana);
                    break;
                default:
                    strConv = Strings.StrConv(str, VbStrConv.Uppercase);
                    break;
            }


            return strConv;
        }
    }
}
