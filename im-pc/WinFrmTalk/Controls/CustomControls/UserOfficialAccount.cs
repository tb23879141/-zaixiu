using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserOfficialAccount : UserControl
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblTitle.Text = LanguageXmlUtils.GetValue("userOfficialAccount_title", lblTitle.Text);
        }

        public UserOfficialAccount()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        private List<Control> controlLst = new List<Control>();//加入面板中数据的集合

        public List<Friend> FriendLst = new List<Friend>();

        public void LoadData()
        {
            Friend MyFriend = new Friend { UserId = Applicate.MyAccount.userId, NickName = Applicate.MyAccount.nickname };

            FriendLst = MyFriend.GetByOfficialAccountLst();
            for (int i = 0; i < FriendLst.Count; i++)
            {
                InsertItembyList(FriendLst[i]);
            }

        }
        private void Pics_Click(object sender, EventArgs e)
        {
            RoundPicBox pic = (RoundPicBox)sender;
            USEpicAddName uSEpicAddName = (USEpicAddName)pic.Parent;
            FrmFriendsBasic frmFriendsBasic = new FrmFriendsBasic();
            frmFriendsBasic.ShowOAInfoById(uSEpicAddName.Userid);
            frmFriendsBasic.Show();
        }


        private int FontWidth(Font font, Control control, string str)
        {
            using (Graphics g = control.CreateGraphics())
            {
                SizeF siF = g.MeasureString(str, font); return (int)siF.Width;
            }
        }

        public void ChangeLine()
        {
            int wid = FontWidth(lblTitle.Font, lblTitle, lblTitle.Text);
            int line = wid / lblTitle.Width;
        }

        private void UserOfficialAccount_Load(object sender, EventArgs e)
        {
            LoadData();
            RegisterMessengers();
        }

        public void RegisterMessengers()
        {

            Messenger.Default.Register<string>(this, FriendListLayout.ADD_EXISTS_FRIEND, CreateFriendItem);
        }

        private delegate void ProcesMainString(string userid);

        #region 添加一个好友到好友列表中
        private void CreateFriendItem(string userId)
        {
            if (Thread.CurrentThread.IsBackground)
            {
                var main = new ProcesMainString(CreateFriendItem);
                Invoke(main, userId);
                return;
            }


            var friend = new Friend { UserId = userId }.GetByUserId();//尝试获取好友
            if (friend != null && friend.UserType == FriendType.PUBLICIZE_TYPE)
            {
                foreach (var item in FriendLst)
                {
                    if (item.UserId.Equals(userId))
                    {
                        return;
                    }
                }


                FriendLst.Add(friend);
                InsertItembyList(friend);
            }
        }


        public void InsertItembyList(Friend friend)
        {
            USEpicAddName uSEpicAddName = new USEpicAddName();
            uSEpicAddName.pics.Size = new Size(55, 55);
            uSEpicAddName.Size = new Size(70, 100);
            //uSEpicAddName.CurrentRole = CurrentRole;
            uSEpicAddName.LabelFont = new Font(Applicate.SetFont, 8F);
            // uSEpicAddName.Tag = FriendLst[i].role;
            uSEpicAddName.NickName = friend.NickName;
            uSEpicAddName.Userid = friend.UserId;
            ImageLoader.Instance.DisplayAvatar(friend.UserId, uSEpicAddName.pics);
            uSEpicAddName.Margin = new Padding(10, 8, 3, 3);

            uSEpicAddName.pics.Click -= uSEpicAddName.pics_Click;
            uSEpicAddName.pics.Click += Pics_Click;

            controlLst.Add(uSEpicAddName);
            tabpal.Controls.Add(uSEpicAddName);
        }

        #endregion

        private void Lab_detial_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //打开搜索公众号面板
            var search = HttpUtils.Instance.FindFrm(typeof(FrmOfficialAccount));

            if (search == null)
            {
                var search1 = new FrmOfficialAccount();
                search1.Show();
            }
            else
            {
                var frm = search as FrmOfficialAccount;
                frm.Activate();
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}