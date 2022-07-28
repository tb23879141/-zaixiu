using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;
using WinFrmTalk.View;
using WinFrmTalk.View.list;

namespace WinFrmTalk
{
    /// <summary>
    /// 群广场
    /// </summary>
    public partial class GroupListLayoutSquare : UserControl
    {

        #region Private Member

        private delegate void ProcesssMessage(MessageObject msg);
        private delegate void ProcesssFriend(Friend msg);

        /// <summary>
        ///  1按群活跃度倒序 2按群人数倒序（默认）
        /// </summary>
        private int Sort { get; set; } = 1;
        private SubclassListItem subItem;

        /// <summary>
        /// 当前选中的项目
        /// </summary>
        public FriendItem SelectedItem { get; set; }

        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        #endregion

        #region 常量
        /// <summary>
        /// 删除群组Token
        /// </summary>
        public const string DELETE_GROUP_ITEM = nameof(DELETE_GROUP_ITEM);

        /// <summary>
        /// 发送群组消息Token
        /// </summary>
        public const string SEND_GROUP_MSG = nameof(SEND_GROUP_MSG);

        private delegate void DelegateString(string msg);

        private GroupListAdapter mAdapter;
        private int pageIndex;
        private bool loading;
        #endregion

        public GroupListLayoutSquare()
        {
            InitializeComponent();
            groupTypeGrid1.GroupTypeSelected = GroupTypeSelected;
            if (Program.Started)
            {
                mAdapter = new GroupListAdapter();
                mAdapter.MouseDown += MouseDownItem;

                this.Load += new System.EventHandler(this.GroupListLayout_Load);

                xListView.FooterRefresh += XListView_FooterRefresh;

            }
        }

        private void XListView_FooterRefresh()
        {

            if (!loading)
            {
                loading = true;
                pageIndex++;

                if (tabLabel.Name == "tab0")
                {
                    HttpLoadMainData();
                }
                else if (tabLabel.Name == "tab1")
                {
                    //if (subItem != null)
                    //{
                    //    HttpLoadOtherData(subItem.parentId, subItem.cid);
                    //}
                }
            }

        }



        private void GroupTypeSelected(bool check, SubclassListItem subData)
        {
            this.subItem = subData;

            if (check)
            {
                groupTypeGrid1.SendToBack();
                tvSortName.Text = GetTypeLabelText();
                pageIndex = 0;
                HttpLoadOtherData(subData.parentId, subData.cid);
            }
        }


        #region 加载事件
        private void GroupListLayout_Load(object sender, EventArgs e)
        {
            RegisterMessenger();

            mAdapter.ListWidth = xListView.Width - 10;

            var v1 = CreateTabItem("官群", true);
            tabLayoutPanel1.AppendControl(v1, true);

            var v2 = CreateTabItem("社群");
            tabLayoutPanel1.AppendControl(v2);

            tabLayoutPanel1.ItemSelected += TabLayout_ItemSelected;

            tvSortName.Text = GetSortLabelText();

            // 加载数据
            HttpLoadMainData();
        }

        private string GetSortLabelText()
        {
            if (Sort == 1)
            {
                return "按活跃度排列";
            }
            else
            {
                return "按群人数排列";
            }

        }

        internal string GetTypeLabelText()
        {
            return string.Format(@"{0}-{1}", subItem.parentName, subItem.cname);
        }

        private Control CreateTabItem(string name, bool foucs = false)
        {
            var item = new TabTextItem();
            item.AutoSize = true;
            item.Text = name;
            item.Name = "tab" + tabLayoutPanel1.Controls.Count;
            item.TextAlign = ContentAlignment.MiddleCenter;

            if (foucs)
            {
                tabLabel = item;
            }
            return item;
        }

        private void TabLayout_ItemSelected(object sender, MouseEventArgs e)
        {
            // 切换列表项
            pageIndex = 0;
            tabLabel = sender as Label;
            if (tabLabel.Name == "tab0")
            {
                tvSortName.Text = GetSortLabelText();
                tvSortName.AccessibleName = "tab0";
                xListView.BringToFront();

                HttpLoadMainData();
            }
            else if (tabLabel.Name == "tab1")
            {
                tvSortName.Text = GetTypeLabelText();
                tvSortName.AccessibleName = "tab1";

                if (UIUtils.IsNull(mOtherpDatas))
                {
                    HttpLoadOtherData(subItem.parentId, subItem.cid);
                }
                else
                {
                    mAdapter.BindFriendData(mOtherpDatas);
                    xListView.SetAdapter(mAdapter);
                }
            }
        }
        #endregion
        #region 加载群列表
        private List<Friend> mMainDatas;
        private List<Friend> mOtherpDatas;

        #region 等待符

        private LodingUtils mLoding = null;

        public void ShowLoading()
        {
            if (mLoding == null)
            {
                mLoding = new LodingUtils { parent = this.xListView, Title = "加载中" };
                mLoding.start();
            }
        }


        public void StopLoading()
        {
            if (mLoding != null)
            {
                mLoding.stop();
                mLoding = null;
            }
        }

        #endregion

        /// <summary>
        /// 获取管群数据统计
        /// </summary>
        private void HttpLoadMainData()
        {
            loading = true;
            ShowLoading();

            HttpUtils.Instance.InitHttp(this);
            string RequestUrl = Applicate.URLDATA.data.apiUrl + "officialGroup/searchOfficial";
            HttpUtils.Instance.Get()
                .Url(RequestUrl)
                .AddParams("sort", Convert.ToString(Sort))
                .AddParams("pageIndex", Convert.ToString(pageIndex))
                .AddParams("pageSize", "40")
                .Build().ExecuteJson<List<MyGroupGQModel>>((sccess, dataList) =>
                {
                    if (sccess && !UIUtils.IsNull(dataList))
                    {
                        if (pageIndex == 0)
                        {
                            mMainDatas = new List<Friend>();
                        }

                        int index = mMainDatas.Count;
                        var curr = TimeUtils.CurrentIntTime();
                        Friend friend = null;

                        foreach (var item in dataList)
                        {
                            friend = item.ToRoom(false);
                            // 是否可以围观
                            if (item.watchTime > curr)
                            {
                                friend.isLook = 1;
                            }
                            else
                            {
                                friend.isLook = -1;
                            }
                            mMainDatas.Add(friend);
                        }


                        if (pageIndex == 0)
                        {
                            // 绑定数据
                            mAdapter.BindFriendData(mMainDatas);
                            xListView.SetAdapter(mAdapter);
                        }
                        else
                        {
                            // 绑定数据
                            mAdapter.BindFriendData(mMainDatas);
                            xListView.InsertRange(index);
                        }


                    }
                    else
                    {
                        // 绑定数据
                        mAdapter.BindFriendData(new List<Friend>());
                        xListView.SetAdapter(mAdapter);
                    }


                    StopLoading();

                    loading = false;
                });
        }

        /// <summary>
        /// 获取社群列表
        /// </summary>
        private void HttpLoadOtherData(string id, string cid)
        {
            loading = true;
            ShowLoading();

            HttpUtils.Instance.InitHttp(this);
            string RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getGroupByCommunityType";
            HttpUtils.Instance.Get()
                .Url(RequestUrl)
                .AddParams("id", id)
                .AddParams("cid", cid)
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "2000")
                .Build().ExecuteJson<List<DownRoom>>((sccess, dataList) =>
                {
                    if (sccess && !UIUtils.IsNull(dataList))
                    {

                        var curr = TimeUtils.CurrentIntTime();
                        mOtherpDatas = new List<Friend>();
                        Friend friend = null;
                        foreach (var item in dataList)
                        {
                            friend = item.ToRoom(true);
                            // 是否可以围观
                            if (item.watchTime > curr)
                            {
                                friend.isLook = 1;
                            }
                            else
                            {
                                friend.isLook = -1;
                            }

                            mOtherpDatas.Add(friend);
                        }

                        // 绑定数据
                        mAdapter.BindFriendData(mOtherpDatas);
                        xListView.SetAdapter(mAdapter);
                    }
                    else
                    {
                        // 绑定数据
                        mAdapter.BindFriendData(new List<Friend>());
                        xListView.SetAdapter(mAdapter);
                    }


                    StopLoading();
                    loading = false;
                });
        }


        #endregion




        #region 注册通知
        private void RegisterMessenger()
        {
            Messenger.Default.Register<bool>(this, GroupListLayout.DELETE_GROUP_ITEM, DeleteGroup);
            Messenger.Default.Register<bool>(this, GroupListLayout.SEND_GROUP_MSG, (_) =>
            {
                MainForm.SendMessageToFriend(SelectedItem.FriendData);
            });

            // 修改群组名称
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_CHANGE_MESSAGE, UpdateRommItem);

            // 我退出了一个群
            Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_DELETE, UpdateRommItem);

            // 我被邀请进入了一个群
            Messenger.Default.Register<Friend>(this, MessageActions.ROOM_UPDATE_INVITE, CreteItemView);

            Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, RefreshFriendHead);

            Messenger.Default.Register<string>(this, MessageActions.SearchEventSquare, SearchEvent);
            Messenger.Default.Register<string>(this, MessageActions.MenuEventSquare, btnPlus_Click);
        }

        #endregion

        #region 刷新用户头像
        private void RefreshFriendHead(string userId)
        {

            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(RefreshFriendHead);
                Invoke(main, userId);
                return;
            }

            int index = mAdapter.GetIndexByFriendId(userId);
            if (xListView.DataCreated(index))
            {
                FriendItem item = xListView.GetItemControl(index) as FriendItem;
                // 刷新用户头像
                item.LoadHeadImage();
            }
        }
        #endregion

        #region 刷新群组名称
        private void UpdateRommName(Friend friend)
        {
            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);

                if (xListView.DataCreated(index))
                {
                    FriendItem item = xListView.GetItemControl(index) as FriendItem;
                    // 修改名称
                    item.FriendData.NickName = friend.NickName;
                    item.ChangeFriendName();

                    MainForm.mainPageLayout.ChangeGroupName(item.FriendData);
                }
            }
        }
        #endregion

        #region 修改群名称
        private void UpdateRommItem(MessageObject message)
        {
            if (Thread.CurrentThread.IsBackground == true)
            {
                var tmp = new ProcesssMessage(UpdateRommItem);
                this.Invoke(tmp, message);
                return;
            }


            switch (message.type)
            {
                case kWCMessageType.RoomNameChange:
                    Friend friend = message.GetFriend();
                    if (friend != null)
                    {
                        friend.NickName = message.content;
                        UpdateRommName(friend);
                        int index = mAdapter.GetIndexByFriendId(message.ChatJid);
                        if (index > -1)
                        {
                            // 删除数据    
                            RemoveItemView(message.ChatJid);

                            CreteItemView(friend);

                        }
                    }
                    break;
                case kWCMessageType.RoomDismiss:
                case kWCMessageType.RoomExit:
                    if (!UIUtils.IsNull(message.toUserId))
                    {
                        if (string.Equals(message.toUserId, Applicate.MyAccount.userId))
                        {
                            RemoveItemView(message.ChatJid);
                        }
                    }
                    else
                    {
                        RemoveItemView(message.ChatJid);
                    }

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 根据RoomJId删除项
        private void RemoveItemView(string roomjid)
        {
            int index = mAdapter.GetIndexByFriendId(roomjid);
            if (index > -1)
            {
                xListView.RemoveItem(index);
                mAdapter.RemoveData(index);

                if (MainForm.mainPageLayout.IsCurrtGroup(roomjid))
                {
                    SelectedItem = new FriendItem();
                    MainForm.mainPageLayout.SelectedIndex = MainTabIndex.RecentListPage_null;
                }

                // 删除比较靠下的元素需要自动收缩列表
                if (xListView.Progress > 90 && index > mAdapter.GetItemCount() * 0.7)
                {
                    int locy = xListView.ListPanelLocationY() + mAdapter.OnMeasureHeight(0);
                    if (locy < 0)
                    {
                        xListView.MovePanelLocation(locy);
                        Console.WriteLine("向下移动列表" + locy);
                    }

                }
            }
        }
        #endregion

        #region 根据Friend创建项
        private void CreteItemView(Friend room)
        {
            if (Thread.CurrentThread.IsBackground == true)
            {
                var tmp = new ProcesssFriend(CreteItemView);
                this.Invoke(tmp, room);
                return;
            }

            int index = mAdapter.GetIndexByFriendId(room.UserId);

            // 没有就添加
            if (index == -1)
            {
                mAdapter.InsertData(0, room);
                xListView.InsertItem(0);
            }
        }
        #endregion

        #region 右键菜单-删除|退出群聊
        private void DeleteGroup(bool para)
        {


            var group = SelectedItem.FriendData.Clone();//获取选中群组
            if (CurrIsLeader(Applicate.MyAccount.userId, group.RoomId))
            {
                if (MessageBox.Show("是否解散  " + group.NickName + " ？", "删除群聊", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "加载中" };
                    load.start();
                    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.DeleteRoom)
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", SelectedItem.FriendData.RoomId)
                        .AddErrorListener((code, msg) =>
                        {
                            HttpUtils.Instance.ShowTip(msg);
                        })
                        .Build().Execute((state, data) =>
                        {
                            load.stop();

                            if (state)
                            {
                                RemoveItemView(SelectedItem.FriendData.UserId);
                            }

                        });
                }
            }
            else
            {
                if (MessageBox.Show("是否退出  " + group.NickName + " ？", "退出群聊", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "加载中" };
                    load.start();
                    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + ApplicateConst.DeleteRoomMember)
                        .AddParams("access_token", Applicate.Access_Token)
                        .AddParams("roomId", SelectedItem.FriendData.RoomId)
                        .AddParams("userId", Applicate.MyAccount.userId).NoErrorTip()
                        .AddErrorListener((code, msg) =>
                        {
                            load.stop();
                            RemoveItemView(SelectedItem.FriendData.UserId);
                            //HttpUtils.Instance.ShowTip(msg);
                        })
                        .Build().Execute((state, data) =>
                        {
                            load.stop();
                            if (state)
                            {
                                RemoveItemView(SelectedItem.FriendData.UserId);
                            }
                        });
                }
            }
        }
        #endregion

        #region 设置右键菜单
        public FriendItem BindContextMenu(FriendItem item)
        {

            var sendmsgitem = new MenuItem("发送消息", (sender, eve) =>
            {
                Messenger.Default.Send(true, GroupListLayout.SEND_GROUP_MSG);

            });
            //var detailitem = new MenuItem("群组详情", (sen, eve) => { Messenger.Default.Send(true, GroupListLayout.SHOW_GROUP_DETAIL); });
            string str = CurrIsLeader(Applicate.MyAccount.userId, item.FriendData.RoomId) ? "解散群组" : "退出群组";
            var blockitem = new MenuItem(str, (sender, eve) =>
            {
                Messenger.Default.Send(true, GroupListLayout.DELETE_GROUP_ITEM);
            });

            var cm = new ContextMenu();
            cm.MenuItems.Add(sendmsgitem);
            //cm.MenuItems.Add(detailitem);
            cm.MenuItems.Add(blockitem);
            item.ContextMenu = cm;//设置右键菜单
            return item;
        }
        #endregion

        #region 判断我在某个群里是否是群主
        private bool CurrIsLeader(string useruId, string roomid)
        {
            int role = new RoomMember() { userId = useruId, roomId = roomid }.GetRoleByUserId();
            return role == 1;
        }
        #endregion

        #region 双击群组开始聊天
        public void DoubleGroupItem(object sender, EventArgs e)
        {
            FriendItem item = sender as FriendItem;
            MainForm.SendMessageToFriend(item.FriendData);
        }

        #endregion

        #region 左键和右键选中事件
        public void MouseDownItem(object sender, MouseEventArgs e)
        {
            // 过滤重复点击项
            FriendItem temp = sender as FriendItem;
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                //if (temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
                //{
                //    return;
                //}
            }

            // 改变选中背景颜色
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                if (!temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
                {
                    // 把上一个取消选中
                    SelectedItem.IsSelected = false;
                }
            }
            temp.IsSelected = true;

            SelectedItem = temp;

            if (e == null || e.Button == MouseButtons.Left)
            {
                if (SelectedItem.FriendData.isLook == -1)
                {
                    MainForm.ShowTip("当期群组不可围观");
                }
                else
                {
                    MainForm.SelectGroup(SelectedItem.FriendData);
                }
            }
        }

        #endregion

        #region +号点击
        private void btnPlus_Click(string sender)
        {
            if (Applicate.URLDATA.data.isOpenRoomSearch == 0)
            {
                #region 打开搜索群功能
                var tmpset = Applicate.GetWindow<FrmGroupQuery>();
                var parent = Applicate.GetWindow<FrmMain>();
                if (tmpset == null)//单例打开好友添加窗口
                {
                    var query = new FrmGroupQuery();
                    query.Location = new Point(parent.Location.X + (parent.Width - query.Width) / 2, parent.Location.Y + (parent.Height - query.Height) / 2);//居中
                    query.Show();
                }
                else
                {
                    tmpset.Activate();
                }
                #endregion
            }
            else
            {
                #region 创建群
                FrmBuildGroups create = new FrmBuildGroups();
                var parent = Applicate.GetWindow<FrmMain>();
                create.Location = new Point(parent.Location.X + (parent.Width - create.Width) / 2, parent.Location.Y + (parent.Height - create.Height) / 2);//居中
                create.Show();
                #endregion
            }
        }
        #endregion

        #region 搜索文本改变时

        private string lastSearchText;
        private Label tabLabel;

        public void SearchEvent(string currText)
        {

            if (string.IsNullOrEmpty(currText) && string.IsNullOrEmpty(lastSearchText))
            {
                LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, currText))
            {
                LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            // 清空了搜索框
            if (string.IsNullOrEmpty(currText) && !string.IsNullOrEmpty(lastSearchText))
            {
                lastSearchText = currText;
                // 恢复原列表
                SearchList();
                return;
            }

            lastSearchText = currText;
            if (!string.IsNullOrEmpty(currText))
            {
                // 加载搜索数据
                SearchList(currText);
                return;
            }
        }

        /// <summary>
        /// 加载群列表
        /// </summary>
        public void SearchList(string searchText = "")
        {
            if (UIUtils.IsNull(searchText))
            {
                // 恢复列表
                TabLayout_ItemSelected(tabLabel, null);
            }
            else
            {
                if (tabLabel.Name == "role0")
                {
                    mAdapter.BindFriendData(mMainDatas);
                }
                else if (tabLabel.Name == "role1")
                {
                    mAdapter.BindFriendData(mOtherpDatas);
                }

                var data = mAdapter.GetListBySearch(searchText);
                mAdapter.BindFriendData(data);
                xListView.SetAdapter(mAdapter);
            }
        }
        #endregion

        private void SortName_Click(object sender, EventArgs e)
        {
            if (this.tvSortName.AccessibleName == "tab1")
            {
                // 切换显示标签选择
                groupTypeGrid1.BringToFront();
            }
            else
            {
                // 切换排序方式
                contextMenuStrip1.Show(tvSortName, 0, 0);
            }

        }

        private void ItemSort_Click(object sender, EventArgs e)
        {
            var select = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.Checked = select == item;
            }

            Sort = Convert.ToInt32(select.Tag);
            tvSortName.Text = GetSortLabelText();
            // 刷新数据
            xListView.ClearList();
            HttpLoadMainData();
        }
    }
}