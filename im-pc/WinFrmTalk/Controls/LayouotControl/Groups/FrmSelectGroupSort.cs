using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class FrmSelectGroupSort : FrmBase
    {
        public Action<int> SortSelected;

        public FrmSelectGroupSort()
        {
            this.ControlBox = false;
            this.Stacked = false;
            InitializeComponent();
            this.Deactivate += Frm_Deactivate;
        }


        private int deactivateCount;

        private void Frm_Deactivate(object sender, EventArgs e)
        {
            if (deactivateCount++ > 0)
            {
                this.Close();
            }
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            var item = sender as Label;
            item.BackColor = Color.Transparent;
        }

        private void Item_MouseEnter(object sender, EventArgs e)
        {
            var item = sender as Label;
            item.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            var item = sender as Label;
            var data = item.Tag as SubclassListItem;

            this.Close();
        }
    }
}
