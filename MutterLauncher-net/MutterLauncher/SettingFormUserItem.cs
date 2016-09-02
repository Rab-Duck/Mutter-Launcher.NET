using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class SettingFormUserItem : Form
    {
        private UserItem _userItem;
        public UserItem userItem { get { return _userItem; } }

        public SettingFormUserItem()
        {
            InitializeComponent();
        }

        public SettingFormUserItem(UserItem userItem)
        {
            InitializeComponent();
            this._userItem = userItem;
        }

        private void SettingFormUserItem_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            if (userItem == null)
            {
                return;
            }

            cbName.Text = _userItem.getItemName();
            txtCmd.Text = _userItem.getItemPath();

            chkFixedItem.Checked = _userItem.getItemType() == ItemType.TYPE_FIX ? true : false;
            chkUseCmdOption.Checked = _userItem.bCmdOption;
            chkUseUrlEncode.Checked = _userItem.bUrlEncode;
            txtEncoding.Text = _userItem.encoding;

            _userItem = null;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _userItem = new UserItem(
                cbName.Text, 
                txtCmd.Text,
                chkFixedItem.Checked,
                chkUseCmdOption.Checked,
                chkUseUrlEncode.Checked, txtEncoding.Text
                );
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _userItem = null;
            this.Close();
        }

        private void chkUseUrlEncode_CheckedChanged(object sender, EventArgs e)
        {
            txtEncoding.Enabled = chkUseUrlEncode.Checked;
        }
    }
}
