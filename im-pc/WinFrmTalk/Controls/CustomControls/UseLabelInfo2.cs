using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UseLabelInfo2 : UserControl
    {

        public string LabelName
        {
            get
            {
                return tvName.Text;
            }
        }
        public UseLabelInfo2()
        {
            InitializeComponent();
        }

        private Control CreateItemControl(Friend data)
        {
            var item = new USEpicAddName();

            item.ChangeSizeLabel();
            item.LabelFont = new Font(Applicate.SetFont, 10F);
            item.NickName = data.NickName;
            item.Userid = data.UserId;
            item.CurrentRole = -1;
            //ImageLoader.Instance.DisplayAvatar(item.Userid, item.pics);
            ImageLoader.Instance.DisplayAvatar(data.UserId, data.GetRemarkName(), item.pics);
            item.Margin = new Padding(0, 20, 10, 0);
            return item;
        }



        private Control CreateItemControl(string id)
        {
            var item = new USEpicAddName();
            item.pics.Size = new Size(55, 55);
            item.Size = new Size(70, 90);
            item.LabelFont = new Font(Applicate.SetFont, 8F);
            item.Margin = new Padding(0, 0, 0, 0);

            if ("add" == id)
            {
                item.NickName = LanguageXmlUtils.GetValue("add", "添加");
                item.Userid = id;
                item.pics.Image = WinFrmTalk.Properties.Resources.Add_01;
                item.MouseClick += ItemAdd_MouseClick;
            }
            else
            {
                item.NickName = LanguageXmlUtils.GetValue("delete", "删除");
                item.Userid = id;
                item.pics.Image = WinFrmTalk.Properties.Resources.Aum;
                item.MouseClick += ItemDel_MouseClick;
            }
            return item;
        }

        private void ItemDel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ItemAdd_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void SetFriendLabelData(string name, List<Friend> dataList)
        {
            tvName.Text = name;
            flowLayoutPanel1.Controls.Clear();

            //// 添加成员按钮
            //var add = CreateItemControl("add");
            //flowLayoutPanel1.Controls.Add(add);

            //if (!UIUtils.IsNull(dataList))
            //{
            //    // 删除成员按钮
            //    var del = CreateItemControl("delete");
            //    flowLayoutPanel1.Controls.Add(del);
            //}

            foreach (var data in dataList)
            {
                var item = CreateItemControl(data);
                flowLayoutPanel1.Controls.Add(item);
            }
        }
    }
}