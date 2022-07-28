using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class ListLayoutTitleBar : UserControl
    {
        internal FrmMain MainForm { get; set; }

        public ListLayoutTitleBar()
        {
            InitializeComponent();

            this.MouseDown += Item_MouseDown1;
            this.btnMenu.MouseDown += Item_MouseDown1;

            RecentSearch.LostFocus += RecentSearch_LostFocus;
        }

        private void RecentSearch_LostFocus(object sender, System.EventArgs e)
        {
            RecentSearch.Visible = false;
        }

        private void Item_MouseDown1(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
            SendKeys.Send("{Tab}");
        }



        /// <summary>
        /// 搜索事件
        /// </summary>
        private void Search_Click(object sender, System.EventArgs e)
        {
            RecentSearch.Visible = true;
            RecentSearch.BringToFront();
            RecentSearch.lbl_Search_Click(RecentSearch, e);
        }

        /// <summary>
        /// 点击更多菜单
        /// </summary>
        private void Menu_Click(object sender, System.EventArgs e)
        {
            switch (MainForm.SelectIndex)
            {
                case MainTabIndex.RecentListPage:
                    Messenger.Default.Send("0", MessageActions.MenuEventRecent);
                    break;
                case MainTabIndex.FriendsPage:
                    Messenger.Default.Send("0", MessageActions.MenuEventFriend);
                    break;
                case MainTabIndex.GroupPage:
                    Messenger.Default.Send("0", MessageActions.MenuEventGroups);
                    break;
                case MainTabIndex.Square:
                    Messenger.Default.Send("0", MessageActions.MenuEventSquare);
                    break;
                case MainTabIndex.Saves:
                    Messenger.Default.Send("0", MessageActions.MenuEventCollec);
                    break;
                case MainTabIndex.TagPage:
                    Messenger.Default.Send("0", MessageActions.MenuEventLabels);
                    break;
                default:
                    break;
            }



        }

        private void Search_SearchEvent(string text)
        {
            switch (MainForm.SelectIndex)
            {
                case MainTabIndex.RecentListPage:
                    Messenger.Default.Send(text, MessageActions.SearchEventRecent);
                    break;
                case MainTabIndex.FriendsPage:
                    Messenger.Default.Send(text, MessageActions.SearchEventFriend);
                    break;
                case MainTabIndex.GroupPage:
                    Messenger.Default.Send(text, MessageActions.SearchEventGroups);
                    break;
                case MainTabIndex.Square:
                    Messenger.Default.Send(text, MessageActions.SearchEventSquare);
                    break;
                case MainTabIndex.Saves:
                    Messenger.Default.Send(text, MessageActions.SearchEventCollec);
                    break;
                case MainTabIndex.TagPage:
                    Messenger.Default.Send(text, MessageActions.SearchEventLabels);
                    break;
                default:
                    break;
            }
        }

        public bool mSignle = false;

        public void ChangeButtonLocation(bool single = false)
        {
            if (mSignle != single)
            {
                this.mSignle = single;
                if (single)
                {
                    btnSearch.Location = new System.Drawing.Point(300, btnSearch.Location.Y);
                    RecentSearch.Location = new System.Drawing.Point(124, RecentSearch.Location.Y);
                    btnMenu.Visible = false;
                }
                else
                {
                    btnSearch.Location = new System.Drawing.Point(267, btnSearch.Location.Y);
                    RecentSearch.Location = new System.Drawing.Point(93, RecentSearch.Location.Y);
                    btnMenu.Visible = true;
                }
            }
        }
    }
}
