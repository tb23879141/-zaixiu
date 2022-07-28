using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Properties;
using WinFrmTalk.socket;

namespace WinFrmTalk
{
    public partial class LeftLayout : UserControl
    {

        #region Private Properties
        private MainTabIndex mCurrSelect;
        private MainTabIndex mLastSelect = MainTabIndex.RecentListPage_null;
        private MouseModel mouseModel = new MouseModel();
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
                    btnRecent.Image = isPress ? Resources.msg02 : Resources.msg01;
                    mouseModel = new MouseModel();//初始化赋值
                    mouseModel.Recent = false;
                    break;
                case MainTabIndex.FriendsPage:
                    btnContacts.Image = isPress ? Resources.contact02 : Resources.contact01;
                    //DisplayContactUnReadCount(totalContactUnreadCount);//重绘联系人未读角标
                    mouseModel = new MouseModel();
                    mouseModel.Contacts = false;
                    break;
                case MainTabIndex.GroupPage:
                    btnGroup.Image = isPress ? Resources.group02 : Resources.group01;
                    mouseModel = new MouseModel();
                    mouseModel.Group = false;
                    break;
                case MainTabIndex.Square:
                    btnColleague.Image = isPress ? Resources.company02 : Resources.company01;
                    mouseModel = new MouseModel();
                    mouseModel.Colleague = false;
                    break;
                case MainTabIndex.Saves:
                    btnCollect.Image = isPress ? Resources.collection02 : Resources.collection01;
                    mouseModel = new MouseModel();
                    mouseModel.Collect = false;
                    break;
                case MainTabIndex.TagPage:
                    btnTags.Image = isPress ? Resources.tap_groups02 : Resources.tap_groups01;
                    mouseModel = new MouseModel();
                    mouseModel.Tags = false;
                    break;
            }
        }


        #region Constructor
        public LeftLayout()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 初始化字体图标
        /// <summary>
        /// 初始化字体图标
        /// </summary>
        private void InitialIconFont()
        {
            //btnRecent.Font = new Font(Program.ApplicationFontCollection.Families.Last(), 20f);
            //btnContacts.Font = new Font(Program.ApplicationFontCollection.Families.Last(), 20f);
            //btnGroup.Font = new Font(Program.ApplicationFontCollection.Families.Last(), 20f);
            btnSettings.Font = new Font(Program.ApplicationFontCollection.Families.Last(), 20f);
        }
        #endregion

        #region 加载事件

        private void LeftLayout_Load(object sender, EventArgs e)
        {
            try
            {
                toolTips.SetToolTip(btnRecent, "消息");
                toolTips.SetToolTip(btnContacts, "通讯录");
                toolTips.SetToolTip(btnGroup, "群组");
                toolTips.SetToolTip(btnColleague, "公司");
                toolTips.SetToolTip(btnCollect, "保存");
                toolTips.SetToolTip(btnTags, "标签");
                toolTips.SetToolTip(btnSettings, "设置");

                InitialIconFont();//初始化字体图标

                InitialMyDetail(false);//设置用户信息
                RegisterMessenger();

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
            Messenger.Default.Register<int>(this, LeftLayout.NOTIFY_CHAT_UNREADCOUNT, (count) =>
            {
                DisplayChatUnReadCount(count);
            });

            #endregion


            #region 朋友列表的未读角标
            Messenger.Default.Register<int>(this, LeftLayout.NOTIFY_CONTACT_UNREADCOUNT, (count) =>
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



        }
        #endregion

        #region 显示联系人未读角标
        public void DisplayContactUnReadCount(int unreadcount)
        {
            if (unreadcount > 999)
            {
                unreadcount = 999;
            }

            btnContacts.UnreadCount = unreadcount;
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

            btnRecent.UnreadCount = unreadcount;
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
        private void Settings_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            //FrmTest test = new FrmTest();
            //test.Show();
            //return;

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
        private void btnRecent_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            Console.WriteLine("btnRecent_Click");
            SelectIndex = MainTabIndex.RecentListPage;
            MainForm.SelectIndex = MainTabIndex.RecentListPage;
        }
        #endregion

        #region 最近消息双击
        private void OnDoubleClickRecent(object sender, EventArgs e)
        {
            Console.WriteLine("OnDoubleClickRecent");
            var recent = MainForm.GetRecentList();
            var uncount = recent.NextUnpoint();
            // 重绘消息未读角标
            DisplayChatUnReadCount(uncount);
        }
        #endregion

        #region 联系人点击
        private void btnContacts_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            SelectIndex = MainTabIndex.FriendsPage;
            MainForm.SelectIndex = MainTabIndex.FriendsPage;
        }
        #endregion

        #region 群组点击
        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            SelectIndex = MainTabIndex.GroupPage;
            MainForm.SelectIndex = MainTabIndex.GroupPage;
        }
        #endregion

        #region 群广场
        private void BtnCon_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            SelectIndex = MainTabIndex.Square;
            MainForm.SelectIndex = MainTabIndex.Square;
        }
        #endregion

        #region 标签显示
        private void BtnTags_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            SelectIndex = MainTabIndex.TagPage;
            MainForm.SelectIndex = MainTabIndex.TagPage;
        }
        #endregion

        #region 收藏点击
        private void BtnCollect_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;

            SelectIndex = MainTabIndex.Saves;
            MainForm.SelectIndex = MainTabIndex.Saves;
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

        #region 鼠标进入事件
        private void btnSettings_MouseMove(object sender, MouseEventArgs e)
        {
            btnSettings.Image = Resources.setting_press;
            panelSettings.BackColor = Color.FromArgb(39, 28, 255);
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {

            btnSettings.Image = Resources.setting;
            panelSettings.BackColor = Color.Transparent;
        }

        private void btnRecent_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Recent)
            {
                btnRecent.Image = Resources.msg1;
                panelRecent.BackColor = Color.FromArgb(39, 28, 255);
            }
        }

        private void btnRecent_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Recent)
            {
                btnRecent.Image = Resources.msg01;
            }
            panelRecent.BackColor = Color.Transparent;
        }

        private void btnContacts_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Contacts)
            {
                btnContacts.Image = Resources.contact;
                panelContacts.BackColor = Color.FromArgb(39, 28, 255);
            }
        }

        private void btnContacts_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Contacts)
            {
                btnContacts.Image = Resources.contact01;
            }
            panelContacts.BackColor = Color.Transparent;
        }

        private void btnGroup_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Group)
            {
                btnGroup.Image = Resources.group;
                panelGroup.BackColor = Color.FromArgb(39, 28, 255);
            }
        }
        private void btnGroup_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Group)
            {
                btnGroup.Image = Resources.group01;
            }
            panelGroup.BackColor = Color.Transparent;
        }
        private void btnColleague_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Colleague)
            {
                btnColleague.Image = Resources.company;
                panelColleague.BackColor = Color.FromArgb(39, 28, 255);
            }
        }

        private void btnColleague_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Colleague)
            {
                btnColleague.Image = Resources.company01;
            }
            panelColleague.BackColor = Color.Transparent;
        }
        private void btnCollect_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Collect)
            {
                btnCollect.Image = Resources.collection;
                panelCollect.BackColor = Color.FromArgb(39, 28, 255);
            }
        }

        private void btnCollect_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Collect)
            {
                btnCollect.Image = Resources.collection01;
            }
            panelCollect.BackColor = Color.Transparent;
        }
        private void btnTags_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseModel.Tags)
            {
                btnTags.Image = Resources.tap_groups;
                panelTags.BackColor = Color.FromArgb(39, 28, 255);
            }
        }

        private void btnTags_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Tags)
            {
                btnTags.Image = Resources.tap_groups01;
            }
            panelTags.BackColor = Color.Transparent;
        }
        #endregion
    }

    internal class MouseModel
    {
        /// <summary>
        /// 最新消息
        /// </summary>
        public bool Recent { get; set; } = true;
        /// <summary>
        /// 好友列表
        /// </summary>
        public bool Contacts { get; set; } = true;
        /// <summary>
        /// 群组
        /// </summary>
        public bool Group { get; set; } = true;
        /// <summary>
        ///公司
        /// </summary>
        public bool Colleague { get; set; } = true;
        /// <summary>
        /// 收藏
        /// </summary>
        public bool Collect { get; set; } = true;
        /// <summary>
        /// 标签
        /// </summary>
        public bool Tags { get; set; } = true;
    }
}
