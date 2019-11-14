using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MutterLauncher
{
    public enum ItemType
    {
        TYPE_NORMAL = 0,
        TYPE_HISTORY = 1,
        TYPE_FIX = 10,
    }
    public interface Item
    {
        string ToString();
        Item cloneItem();

        string getItemName();
        string getConvItemName();

        string getItemPath();

        void setItemType(ItemType type);
        ItemType getItemType();
        bool historyEquals(Item item);
        int getIconIndex();
        bool exists();
        bool execute(string strExec, System.Windows.Forms.Keys modifiers);
    }
}
