using System;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupIndicateLayout : UserControl
    {
        private bool Chatpage { get; set; }
        private bool ShowTopic { get; set; }

        public GroupIndicateLayout()
        {
            InitializeComponent();
        }


        private void btnNotify_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectIndex == GroupTabIndex.notify)
            {
                ChangeViewSelect(mLastSelect, false);
                btnTopic_Click(sender, e);
                return;
            }
            SelectIndex = GroupTabIndex.notify;
            ChangeGroupFunc?.Invoke(SelectIndex);
        }

        private void btnActive_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectIndex == GroupTabIndex.active)
            {
                ChangeViewSelect(mLastSelect, false);
                btnTopic_Click(sender, e);
                return;
            }
            SelectIndex = GroupTabIndex.active;
            ChangeGroupFunc?.Invoke(SelectIndex);
        }

        private void btnFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectIndex == GroupTabIndex.files)
            {
                ChangeViewSelect(mLastSelect, false);
                btnTopic_Click(sender, e);
                return;
            }
            SelectIndex = GroupTabIndex.files;
            ChangeGroupFunc?.Invoke(SelectIndex);
        }

        private void btnVideo_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectIndex == GroupTabIndex.video)
            {
                ChangeViewSelect(mLastSelect, false);
                btnTopic_Click(sender, e);
                return;
            }
            SelectIndex = GroupTabIndex.video;
            ChangeGroupFunc?.Invoke(SelectIndex);
        }

        internal void SwitchGroupPage(GroupTabIndex tabLayout, Friend friend)
        {
            SelectIndex = tabLayout;

            // 2官方群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
            if (friend.GroupType == 2 || friend.GroupType == 11 || friend.GroupType == 12 || friend.GroupType == 13 || friend.GroupType == 14)
            {
                ShowTopic = false;
                // btnTopic.Visible = false;
                flowLayoutPanel1.Height = this.Height;
            }
            else
            {
                btnTopic.Text = "群话题";
                ShowTopic = true;
                //btnTopic.Visible = ShowTopic;
                flowLayoutPanel1.Height = ShowTopic ? 331 : this.Height;
            }

        }

        private void btnPhotos_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectIndex == GroupTabIndex.image)
            {
                ChangeViewSelect(mLastSelect, false);
                btnTopic_Click(sender, e);
                return;
            }

            SelectIndex = GroupTabIndex.image;
            ChangeGroupFunc?.Invoke(SelectIndex);
        }

        private void btnMainPage_MouseClick(object sender, MouseEventArgs e)
        {
            //SelectIndex = GroupTabIndex.main;
            //ChangeGroupFunc?.Invoke(SelectIndex);
        }

        private GroupTabIndex mCurrSelect;
        private GroupTabIndex mLastSelect = GroupTabIndex.main;

        /// <summary>
        /// 设置选中的对象
        /// </summary>
        public GroupTabIndex SelectIndex
        {
            get { return mCurrSelect; }
            set
            {
                mCurrSelect = value;
                ChangeSelect(SelectIndex);
            }
        }

        public Action<GroupTabIndex> ChangeGroupFunc { get; internal set; }

        private void ChangeSelect(GroupTabIndex index)
        {
            if (index == mLastSelect)
            {
                return;
            }
            // 取消选中上一个项
            ChangeViewSelect(mLastSelect, false);
            // 选中当前项
            ChangeViewSelect(index, true);

            btnTopic.Text = SelectIndex != GroupTabIndex.chat ? "群聊天" : "群话题";
            btnTopic.Margin = new Padding();
            mLastSelect = index;
        }


        private void ChangeViewSelect(GroupTabIndex index, bool isPress)
        {

            switch (index)
            {
                case GroupTabIndex.notify:
                    btnNotify.Image = isPress ? Resources.ic_group_tab_n1 : Resources.ic_group_tab_n0;
                    btnNotify.FocusChanged(isPress);
                    break;
                case GroupTabIndex.active:
                    btnActive.Image = isPress ? Resources.ic_group_tab_a1 : Resources.ic_group_tab_a0;
                    btnActive.FocusChanged(isPress);
                    break;
                case GroupTabIndex.files:
                    btnFiles.Image = isPress ? Resources.ic_group_tab_f1 : Resources.ic_group_tab_f0;
                    btnFiles.FocusChanged(isPress);
                    break;
                case GroupTabIndex.video:
                    btnVideo.Image = isPress ? Resources.ic_group_tab_v1 : Resources.ic_group_tab_v0;
                    btnVideo.FocusChanged(isPress);
                    break;
                case GroupTabIndex.image:
                    btnPhotos.Image = isPress ? Resources.ic_group_tab_p1 : Resources.ic_group_tab_p0;
                    btnPhotos.FocusChanged(isPress);
                    break;
                default:
                    break;
            }

        }


        internal void SetShowmsgPanel()
        {
            //btnTopic = label1;//.Visible = true;
        }

        private void btnTopic_Click(object sender, EventArgs e)
        {
            ChangeViewSelect(mLastSelect, false);
            if (SelectIndex == GroupTabIndex.chat)
            {
                mCurrSelect = GroupTabIndex.main;
                mLastSelect = GroupTabIndex.main;
                btnTopic.Text = "群聊天";
            }
            else
            {
                mCurrSelect = Chatpage ? GroupTabIndex.chat : GroupTabIndex.main;
                mLastSelect = Chatpage ? GroupTabIndex.chat : GroupTabIndex.main;
                btnTopic.Text = "群话题";
                flowLayoutPanel1.Height = ShowTopic ? 331 : this.Height;
                //btnTopic.Visible = ShowTopic;

            }
            unreadCount = 0;
            ChangeGroupFunc?.Invoke(mCurrSelect);
        }

        internal void SwitchFriend(Friend friend, bool http = true)
        {
            Chatpage = true;

            // 2官方群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
            if (friend.GroupType == 2 || friend.GroupType == 11 || friend.GroupType == 12 || friend.GroupType == 13 || friend.GroupType == 14)
            {
                ShowTopic = false;
                // btnTopic.Visible = false;
                flowLayoutPanel1.Height = this.Height;
            }
            else
            {
                btnTopic.Text = "群话题";
                ShowTopic = http;
                //btnTopic.Visible = ShowTopic;
                flowLayoutPanel1.Height = ShowTopic ? 331 : this.Height;
            }
            flowLayoutPanel1.BringToFront();
            // btnTopic.Visible = ShowTopic;
            // 取消选中上一个项
            ChangeViewSelect(mLastSelect, false);
            mCurrSelect = GroupTabIndex.chat;
            mLastSelect = GroupTabIndex.chat;
        }


        public bool isResource
        {
            get
            {
                return mCurrSelect != GroupTabIndex.chat;
            }
        }


        private int unreadCount = 0;
        internal void AddUnreadCount()
        {
            unreadCount++;
            if (unreadCount < 99)
            {
                btnTopic.Text = String.Format("{0} 消息", unreadCount);
            }
            else
            {
                btnTopic.Text = String.Format("99+消息");
            }

            btnTopic.Visible = true;
        }
    }


    public enum GroupTabIndex
    {
        main,
        notify,
        active,
        files,
        video,
        image,
        chat,
        other,
    }
}