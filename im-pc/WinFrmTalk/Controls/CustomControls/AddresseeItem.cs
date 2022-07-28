using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class AddresseeItem : UserControl
    {
        private Action<string> remove_item = null;
        public string UserId { get; set; }

        private AddresseeItem()
        {
            InitializeComponent();
        }

        public AddresseeItem(Action<string> remove_item)
        {
            InitializeComponent();
            this.remove_item = remove_item;
        }

        private void labRemove_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            remove_item?.Invoke(UserId);
        }

        public void SetAddresseeName(string nickName)
        {
            using(Label lblName = new Label())
            {
                lblName.Anchor = this.lblName.Anchor;
                lblName.AutoSize = false;
                lblName.Font = this.lblName.Font;
                lblName.Text = nickName;
                EQControlManager.StrAddEllipsis(lblName, lblName.Font, 150);

                int diff_width = lblName.Width - this.lblName.Width;
                this.Width += diff_width;
                this.lblName.Text = nickName;
            }
        }
    }
}
