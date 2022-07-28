using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class FrmSelectGroupType : FrmBase
    {
        public Action<SubclassListItem> ItemSelected;

        public FrmSelectGroupType()
        {
            this.ControlBox = false;
            this.Stacked = false;
            InitializeComponent();
            this.Deactivate += Frm_Deactivate;
        }



        private int deactivateCount;

        private void Frm_Deactivate(object sender, EventArgs e)
        {
            Console.WriteLine("Frm_Deactivate");
            if (deactivateCount++ > 0)
            {
                this.Close();
            }
        }


        public void SetContentData(List<SubclassListItem> dataList, string cId)
        {
            this.SuspendLayout();
            foreach (var data in dataList)
            {
                var item = CreateControlItem(data, cId);
                flowLayoutPanel1.Controls.Add(item);
            }

            this.ResumeLayout();
            this.Height = dataList.Count * 34;
        }

        private Control CreateControlItem(SubclassListItem data, string id)
        {
            var item = new Label();
            item.Size = new Size(134, 34);
            item.Text = data.cname;

            if (id == data.cid)
            {
                item.ForeColor = Color.FromArgb(12, 206, 99);
            }
            else
            {
                item.ForeColor = Color.FromArgb(51, 51, 51);
            }

            item.TextAlign = ContentAlignment.MiddleCenter;
            item.Location = new Point(0, flowLayoutPanel1.Controls.Count * 34);

            item.Tag = data;

            item.MouseEnter += Item_MouseEnter;
            item.MouseLeave += Item_MouseLeave;
            item.MouseClick += Item_MouseClick;
            return item;

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
            ItemSelected?.Invoke(data);
            this.Close();
        }
    }
}
