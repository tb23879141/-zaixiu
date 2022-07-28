using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.CustomControls.ItemControl
{
    public partial class OfficialAccountItem : UserControl
    {
        public Friend friendData { get => friendItem1.FriendData; set => friendItem1.FriendData = value; }

        public OfficialAccountItem()
        {
            InitializeComponent();
        }

        private void OfficialAccountItem_MouseEnter(object sender, EventArgs e)
        {
            //label1.BackColor = ColorTranslator.FromHtml("#D8D8D9");
        }

        private void friendItem_MouseLeave(object sender, EventArgs e)
        {
            //label1.BackColor = Color.Transparent;
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            string requesttype = "6";   //关注公众号
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.AddFriend)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("toUserId", friendData.UserId)
                .AddParams("fromAddType", requesttype)
                .NoErrorTip()
                .Build()
                .Execute((success, result) =>
                {

                });
        }

        private void FriendItem1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            FrmFriendsBasic frmFriendsBasic = new FrmFriendsBasic();
            frmFriendsBasic.ShowOAInfoById(friendData.UserId);
        }
    }
}
