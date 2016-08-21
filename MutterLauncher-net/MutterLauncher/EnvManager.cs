using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    class EnvManager
    {
        private string historyFilename = "HistoryList.ser";
        private string itemListFilename = "ItemList.bin";
        private string envDir;
        private Object lockItemList = new Object();

        public static EnvManager envmngr;
        public static EnvManager getInstance()
        {
            if (envmngr == null)
            {
                envmngr = new EnvManager();
            }
            return envmngr;
        }

        private EnvManager()
        {
            envDir = Path.GetFullPath(Application.LocalUserAppDataPath + "\\..");
            itemListFilename = envDir + "\\" + itemListFilename;
            historyFilename = envDir + "\\" + historyFilename;
        }

        public void setItemList(List<Item> itemList)
        {
            lock (lockItemList)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream=null;
                try
                {
                    stream = new FileStream(itemListFilename, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, itemList);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    throw e;
                }
                finally
                {
                    if(stream != null)
                    {
                        stream.Close();
                    }
                }
            }
        }
        public List<Item> getItemList()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            List<Item> itemList = new List<Item>();
            lock (lockItemList)
            {
                try
                {
                    stream = new FileStream(itemListFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    itemList = (List<Item>)formatter.Deserialize(stream);
                }
                catch (FileNotFoundException fnfex)
                {

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    throw e;
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }

            return itemList;
        }

    }
}
