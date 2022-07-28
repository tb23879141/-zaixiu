using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Properties;
using WinFrmTalk.socket;

namespace WinFrmTalk
{
    public partial class LeftLayoutTab : UserControl
    {

        #region Private Properties
        private MainTabIndex mCurrSelect;
        private MainTabIndex mLastSelect = MainTabIndex.RecentListPage_null;
        #endregion

        #region Const
        /// <summary>
        /// 显示固定总聊天消息未读数量
        /// </summary>
        public const string NOTIFY_CHAT_UNREADCOUNT = nameof(NOTIFY_CHAT_UNREADCOUNT);
        /// <summary>
        /// 显示固定总联系人未读数量
        /// </summary>
        public const string NOTIFY_CONTACT_UNREADCOUNT = nameof(NOTIFY_CONTACT_UNREADCOUNT);
        #endregion

        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        /// <summary>
        /// 设置选中的对象
        /// </summary>
        public MainTabIndex SelectIndex
        {
            get { return mCurrSelect; }
            set
            {
                mCurrSelect = value;
                ChangeSelect(SelectIndex);
            }
        }


        private void ChangeSelect(MainTabIndex index)
        {
            //if (index == mLastSelect)
            //{
            //    return;
            //}

            // 取消选中上一个项
            ChangeViewSelect(mLastSelect, false);
            // 选中当前项
            ChangeViewSelect(index, true);

            mLastSelect = index;
        }


        private void ChangeViewSelect(MainTabIndex index, bool isPress)
        {
            switch (index)
            {
                case MainTabIndex.RecentListPage:
                    btnRecent.Image = isPress ? Resources.ic_nav_tab01 : Resources.ic_nav_tab00;
                    btnRecent.ItemFousced(isPress);
                    break;
                case MainTabIndex.FriendsPage:
                    btnContact.Image = isPress ? Resources.ic_nav_tab11 : Resources.ic_nav_tab10;
                    btnContact.ItemFousced(isPress);
                    break;
                case MainTabIndex.GroupPage:
                    btnGroup.Image = isPress ? Resources.ic_nav_tab21 : Resources.ic_nav_tab20;
                    btnGroup.ItemFousced(isPress);
                    break;
                case MainTabIndex.Square:
                    btnSquare.Image = isPress ? Resources.ic_nav_tab31 : Resources.ic_nav_tab30;
                    btnSquare.ItemFousced(isPress);
                    break;
                case MainTabIndex.Saves:
                    btnFiles.Image = isPress ? Resources.ic_nav_tab41 : Resources.ic_nav_tab40;
                    btnFiles.ItemFousced(isPress);
                    break;
                case MainTabIndex.TagPage:
                    btnLabels.Image = isPress ? Resources.ic_nav_tab51 : Resources.ic_nav_tab50;
                    btnLabels.ItemFousced(isPress);
                    break;
            }
        }


        #region Constructor
        public LeftLayoutTab()
        {
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 加载事件

        private void LeftLayout_Load(object sender, EventArgs e)
        {
            try
            {
                toolTips.SetToolTip(btnRecent, "消息");
                toolTips.SetToolTip(btnContact, "通讯录");
                toolTips.SetToolTip(btnGroup, "群组");
                toolTips.SetToolTip(btnSquare, "群广场");
                toolTips.SetToolTip(btnFiles, "保存");
                toolTips.SetToolTip(btnLabels, "标签");
                toolTips.SetToolTip(btnSetting, "设置");

                InitialMyDetail(false);//设置用户信息
                RegisterMessenger();

                ChangeViewSelect(MainTabIndex.RecentListPage, true);
                mLastSelect = MainTabIndex.RecentListPage;
            }
            catch (Exception ex)
            {
                LogUtils.Log("LeftLayout_Load" + ex.Message);
            }
        }
        #endregion

        #region 注册通知
        private void RegisterMessenger()
        {
            #region 最近消息未读角标
            Messenger.Default.Register<int>(this, LeftLayoutTab.NOTIFY_CHAT_UNREADCOUNT, (count) =>
            {
                DisplayChatUnReadCount(count);
            });

            #endregion


            #region 朋友列表的未读角标
            Messenger.Default.Register<int>(this, LeftLayoutTab.NOTIFY_CONTACT_UNREADCOUNT, (count) =>
            {
                DisplayContactUnReadCount(count);
            });

            #endregion

            Messenger.Default.Register<SocketConnectionState>(this, MessageActions.XMPP_UPDATE_STATE, (count) =>
            {
                ChangeXmppState(count);
            });

            #region 刷新头像
            Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, (userId) =>
             {
                 if (Applicate.MyAccount.userId.Equals(userId))
                 {
                     InitialMyDetail(true);
                 }
             });
            #endregion

            #region 围观消息
            Messenger.Default.Register<string>(this, MessageActions.groupmsg_wg, (str) =>
            {
                btnRecent_MouseClick(btnRecent, null);
            });
            #endregion



        }
        #endregion

        #region 显示联系人未读角标
        public void DisplayContactUnReadCount(int unreadcount)
        {
            if (unreadcount > 999)
            {
                unreadcount = 999;
            }

            btnContact.UnreadCount(unreadcount);
        }
        #endregion

        #region 显示聊天时的未读总数
        /// <summary>
        /// 显示聊天时的未读总数
        /// </summary>
        /// <param name="unreadcount"></param>
        /// 
        public void DisplayChatUnReadCount(int unreadcount)
        {
            if (unreadcount > 99)
            {
                unreadcount = 99;
            }

            btnRecent.UnreadCount(unreadcount);
        }
        #endregion

        #region 设置主窗口自己的信息
        /// <summary>
        /// 设置主窗口自己的信息
        /// </summary>
        private void InitialMyDetail(bool louk)
        {
            if (louk)
            {
                Task.Factory.StartNew(() =>
                {
                    // 修改禅道 #8760
                    Thread.Sleep(1600);

                    //    DisplayAvatar(userId, null, true, compte, friend.GetRemarkName());
                    // 设置头像
                    ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, Applicate.MyAccount.nickname, pic_myIcon);
                });
            }
            else
            {
                //设置头像
                //ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, null, true, (bitmap) =>
                //{
                //    pic_myIcon.Image = bitmap;
                //}, Applicate.MyAccount.nickname);

                ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, Applicate.MyAccount.nickname, pic_myIcon);
            }
        }
        #endregion

        #region 设置点击事件
        /// <summary>
        /// 设置点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_MouseClick(object sender, MouseEventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;
            SettingsClick();
        }
        private void SettingsClick()
        {


            var tmpset = Applicate.GetWindow<FrmSet>();
            var parent = Applicate.GetWindow<FrmMain>();
            if (tmpset == null)
            {
                var set = new FrmSet();
                set.Location = new Point(parent.Location.X + (parent.Width - set.Width) / 2, parent.Location.Y + (parent.Height - set.Height) / 2);//居中
                set.Show();
            }
            else
            {
                tmpset.Activate();
                tmpset.WindowState = FormWindowState.Normal; ;
            }
        }
        #endregion

        #region 最近消息点击
        private void btnRecent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.RecentListPage;
                MainForm.SelectIndex = MainTabIndex.RecentListPage;
            }
        }

        #endregion

        #region 最近消息双击

        private void btnRecent_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("OnDoubleClickRecent");
            var recent = MainForm.GetRecentList();
            var uncount = recent.NextUnpoint();
            // 重绘消息未读角标
            DisplayChatUnReadCount(uncount);
        }
        #endregion

        #region 联系人点击
        private void btnContact_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.FriendsPage;
                MainForm.SelectIndex = MainTabIndex.FriendsPage;
            }
        }
        #endregion

        #region 群组点击
        private void btnGroup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.GroupPage;
                MainForm.SelectIndex = MainTabIndex.GroupPage;
            }
        }
        #endregion

        #region 群广场
        private void btnSquare_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.Square;
                MainForm.SelectIndex = MainTabIndex.Square;
            }
        }
        #endregion

        #region 标签显示
        private void btnLabels_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.TagPage;
                MainForm.SelectIndex = MainTabIndex.TagPage;
            }
        }
        #endregion

        #region 收藏点击

        private void btnFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectIndex = MainTabIndex.Saves;
                MainForm.SelectIndex = MainTabIndex.Saves;
            }
        }

        #endregion

        #region 头像点击
        private void pic_myIcon_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            FrmFriendsBasic detial = new FrmFriendsBasic();
            detial.ShowUserInfoById(Applicate.MyAccount.userId);//显示个人详情
        }
        #endregion

        public Color Statebrg = Color.Gray;

        private void ChangeXmppState(SocketConnectionState state)
        {
            //Console.WriteLine("ChangeXmppState" + state);
            switch (state)
            {
                case SocketConnectionState.Authenticated:
                    Statebrg = ColorTranslator.FromHtml("#0AD007"); // 变绿色 - 在线
                    this.Refresh();
                    break;
                case SocketConnectionState.Disconnected:
                    Statebrg = ColorTranslator.FromHtml("#BBBBBB"); // 变灰色 - 离线
                    this.Refresh();
                    break;

                default:
                    Statebrg = Color.Yellow;// 变黄色 - 连接中
                    this.Refresh();
                    break;
            }
        }

        private void pic_myIcon_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawEllipse(new Pen(Statebrg), new Rectangle(pic_myIcon.Width - 14, pic_myIcon.Height - 14, 12, 12));
            Brush b = new SolidBrush(Statebrg);
            g.FillEllipse(b, new Rectangle(pic_myIcon.Width - 14, pic_myIcon.Height - 14, 12, 12));
        }

        #region 拖拽事件
        // 利用Windows 的 API 函数：SendMessage 和 ReleaseCapture   
        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_MOVE = 0xF010;
        private const uint HTCAPTION = 0x0002;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.MainForm.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }



        #endregion


    }
}
