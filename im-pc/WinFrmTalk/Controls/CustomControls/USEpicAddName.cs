using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class USEpicAddName : UserControl
    {
        private string _NickName;
        private string _Userid;
        private string _roomjid;
        private int _currentRole;

        /// <summary>
        /// userid
        /// </summary>
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }

        internal void ChangeSizeLabel()
        {
            Size = new Size(70, 90);
            this.pics.Size = new Size(55, 55);
            this.pics.Location = new Point(7, 5);
            this.lblName.Location = new Point(0, 60);
            lblName.Width = 70;
        }

        /// <summary>
        /// 群roojid
        /// </summary>
        public string roomjid
        {
            get { return _roomjid; }
            set { _roomjid = value; }
        }

        public int CurrentRole
        {
            get { return _currentRole; }
            set { _currentRole = value; }
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }

        public Font LabelFont
        {
            get
            {
                return lblName.Font;
            }
            internal set
            {
                lblName.Font = value;
            }
        }

        public USEpicAddName()
        {
            InitializeComponent();

            pics.MouseClick += Pics_MouseClick;
            lblName.MouseClick += Pics_MouseClick;
        }

        private void Pics_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }


        private void USEpicAddName_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 鼠标放在图像上显示卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pics_Click(object sender, EventArgs e)
        {
            FrmFriendsBasic frmFriendsBasic = new FrmFriendsBasic();
            frmFriendsBasic.ShowUserInfoByRoom(Userid, roomjid, CurrentRole);

            frmFriendsBasic.Show();

        }
        /// <summary>
        /// 手势
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pics_MouseHover(object sender, EventArgs e)
        {
            //RoundPicBox pics = (RoundPicBox)sender;
            //pics.Cursor = Cursors.Hand;
        }


        private void Pics_Click(object sender, MouseEventArgs e)
        {

            if (Userid == "add")
            {

            }
            else if (Userid == "delete")
            {


            }
            else
            {
                // 双击开始聊天
                Friend friend = new Friend { UserId = this.Userid }.GetByUserId();
                if (friend.Status != Friend.STATUS_BLACKLIST && friend.Status != Friend.STATUS_18 && friend.Status != Friend.STATUS_19)
                {
                    Messenger.Default.Send(friend, FrmMain.START_NEW_CHAT);//通知各页面收到消息
                }
                else
                {
                    HttpUtils.Instance.ShowTip("黑名单状态不能发送消息");
                }
            }

        }
    }
}

