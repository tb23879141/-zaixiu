using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;
using WinFrmTalk.View;
using WinFrmTalk.View.list;

namespace WinFrmTalk
{
    /// <summary>
    /// Ⱥ���б�
    /// </summary>
    public partial class GroupSquareLayout : UserControl
    {

        #region Private Member

        private delegate void ProcesssMessage(MessageObject msg);
        private delegate void ProcesssFriend(Friend msg);

        /// <summary>
        /// ��ǰѡ�е���Ŀ
        /// </summary>
        private FriendItem SelectedItem { get; set; }

        /// <summary>
        /// �����ڶ���
        /// </summary>
        public FrmMain MainForm { get; set; }

        #endregion

        #region ����
        /// <summary>
        /// ɾ��Ⱥ��Token
        /// </summary>
        public const string DELETE_GROUP_ITEM = nameof(DELETE_GROUP_ITEM);

        /// <summary>
        /// ����Ⱥ����ϢToken
        /// </summary>
        public const string SEND_GROUP_MSG = nameof(SEND_GROUP_MSG);

        private delegate void DelegateString(string msg);

        private GroupSquareAdapter mAdapter;

        #endregion

        public GroupSquareLayout()
        {
            InitializeComponent();

            mAdapter = new GroupSquareAdapter();

            // ���ڳ������ʱ����ʾ�������Ϣ�б������б�����أ�����load�¼����ᱻ���ã���������xmpp���߹����ļ�Ⱥ��Ϣ������Ⱥ���б�ͳһ
            RegisterMessenger();


            xListView.HeaderRefresh += XListView_HeaderRefresh;
            xListView.FooterRefresh += XListView_FooterRefresh;
            GroupSearch.tips = LanguageXmlUtils.GetValue("search", "����");
            GroupSearch.SearchEvent += Search;
        }

        private void XListView_FooterRefresh()
        {
            // Console.WriteLine("XListView_FooterRefresh" + isLock);

            if (UIUtils.IsNull(GroupSearch.txt_Search.Text) && limitPage)
            {
                if (!isLock)
                {
                    isLock = true;
                    pageindex++;
                    LoadLimitPageData(false);
                }
            }
        }

        private void XListView_HeaderRefresh()
        {
            // Console.WriteLine("XListView_HeaderRefresh" + isLock);
            if (UIUtils.IsNull(GroupSearch.txt_Search.Text) && limitPage)
            {
                if (!isLock && pageindex > 0)
                {
                    isLock = true;
                    pageindex--;
                    LoadLimitPageData(true);
                }

            }
        }


        #region �����¼�
        private void GroupSquareLayout_Load(object sender, EventArgs e)
        {
            //this.txtSearch.GotFocus += SearchFocused;
            //this.txtSearch.LostFocus += SearchUnFocused;
        }
        #endregion
        #region ����Ⱥ�б�

        bool limitPage = false;
        bool isLock = false;
        int pageindex = 0;

        private void LoadLimitPageData(bool isHead)
        {
            if (pageindex < 0)
            {
                pageindex = 0;
            }

            var friends = new Friend() { IsGroup = 1 }.GetGroupsList();
            int start = pageindex * 200;
            limitPage = friends.Count > start;
            if (limitPage)
            {
                int count = Math.Min(friends.Count - start, 200);
                var data = friends.GetRange(start, count);

                mAdapter.BindFriendData(data);
                xListView.SetAdapter(mAdapter);

                if (isHead)
                {
                    xListView.ShowRangeEnd(data.Count - 1, 0, true);
                }
            }

            isLock = false;
        }
        List<Friend> rooms = null;
        //��ȡ��Ⱥ
        private void getGroupGQ(string keyword = "")
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "officialGroup/searchOfficial";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                 .AddParams("keyword", keyword)
                  .AddParams("sort", "")
                   .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            string jsonStr = data["data"].ToString();
                            List<MyGroupGQModel> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupGQModel>>(data["data"].ToString());
                            rooms = new List<Friend>() { };
                            foreach (var item in myGroupContentList)
                                rooms.Add(new Friend()
                                {
                                    RoomId = item.id,
                                    UserId = item.userId.ToString(),
                                    IsGroup = 1,
                                    NickName = item.nickname,
                                    UserType = item.type,
                                    IsSecretGroup = item.isLook,
                                });
                            mAdapter.BindFriendData(rooms);
                            xListView.SetAdapter(mAdapter);

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }

                    }
                });
        }

        //��ȡ��Ⱥ
        private void getGroupSQ(string id = "", string cid = "", string keyword = "")
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getGroupByCommunityType";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                 .AddParams("keyword", keyword)
                  .AddParams("id", id)
                   .AddParams("cid", cid)
                  .AddParams("sort", "")
                   .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            string jsonStr = data["data"].ToString();
                            List<MyGroupGQModel> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupGQModel>>(data["data"].ToString());
                            rooms = new List<Friend>() { };
                            foreach (var item in myGroupContentList)
                                rooms.Add(new Friend()
                                {
                                    RoomId = item.id,
                                    UserId = item.userId.ToString(),
                                    IsGroup = 1,
                                    NickName = item.nickname,
                                    UserType = item.type,


                                });
                            mAdapter.BindFriendData(rooms);
                            xListView.SetAdapter(mAdapter);

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }

                    }
                });
        }
        //��ȡ��Ⱥ����
        List<MyGroupFLModel> myGroupFLList;
        private void getGroupSQFL(string keyword = "")
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getCommunityClassify";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                 .AddParams("keyword", keyword)
                  .AddParams("sort", "")
                   .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            string jsonStr = data["data"].ToString();
                            myGroupFLList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupFLModel>>(data["data"].ToString());
                            flowLayoutPanelFL.Controls.Clear();
                            foreach (var item in myGroupFLList)
                            {
                                Label btn = new Label();
                                btn.Text = item.name;
                                btn.Tag = item.id;
                                btn.AutoSize = false;
                                btn.Size = new Size(60, 30);
                                btn.BackColor = Color.WhiteSmoke;
                                btn.TextAlign = ContentAlignment.MiddleCenter;
                                btn.Click += btnFL_Click;
                                //btn.Padding = new Padding(3, 3, 3, 3);
                                btn.Margin = new Padding(3, 3, 3, 3);
                                flowLayoutPanelFL.Controls.Add(btn);
                            }


                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }

                    }
                });
        }
        string cid1 = "";
        string cid2 = "";
        private void btnFL_Click(object sender, EventArgs e)
        {
            Label tmpLabel = (Label)sender;
            cid1 = tmpLabel.Tag.ToString();
            var tmpFLModel = myGroupFLList.Find(x => x.name.Equals(tmpLabel.Text));
            flowLayoutPanelFL2.Controls.Clear();
            foreach (var item in tmpFLModel.subclassList)
            {
                Label btn = new Label();
                btn.Tag = item.cid;
                btn.Text = item.cname;
                btn.AutoSize = false;
                btn.Size = new Size(80, 30);
                btn.BackColor = Color.Transparent;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Click += btnFL2_Click;
                flowLayoutPanelFL2.Controls.Add(btn);
            }
            flowLayoutPanelFL2.Location = new Point(tmpLabel.Location.X + tmpLabel.Width + 5, tmpLabel.Location.Y);
            if (tmpLabel.Location.X>140)
            flowLayoutPanelFL2.Location = new Point(tmpLabel.Location.X - flowLayoutPanelFL2.Width - 5, tmpLabel.Location.Y);

            flowLayoutPanelFL2.Visible = true;
            flowLayoutPanelFL2.BringToFront();
        }
        private void btnFL2_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFL2.Visible = false;
            flowLayoutPanelFL.Visible = false;
            Label tmpLabel = (Label)sender;
            cid2 = tmpLabel.Tag.ToString();
            getGroupSQ(cid1, cid2, "");
        }
        /// <summary>
        /// ����Ⱥ�б�
        /// </summary>
        public void LoadRoomList(string searchText = "")
        {
            var load = new LodingUtils { parent = this.xListView, Title = "������" };
            load.start();

            Application.DoEvents();
            MainForm.SuspendLayout();

            rooms = null;
            if (grouptype == "GroupManage") getGroupGQ();
            else getGroupSQ();

            //if (string.IsNullOrEmpty(searchText))
            //{

            //    pageindex = 0;
            //    rooms = new Friend() { IsGroup = 1 }.GetGroupsList();//��ȡ�б�

            //    int start = pageindex * 200;
            //    limitPage = rooms.Count > start;
            //    if (rooms.Count > start)
            //    {
            //        limitPage = true;
            //        int count = Math.Min(rooms.Count - start, 200);
            //        rooms = rooms.GetRange(start, count);
            //    }
            //}
            //else
            //{
            //    rooms = new Friend() { IsGroup = 1 }.SearchFriendsByName(searchText, 1);
            //}


            mAdapter.MainForm = MainForm;
            mAdapter.GroupSquare = this;

            //mAdapter.BindFriendData(rooms);
            //xListView.SetAdapter(mAdapter);

            //List<Control> roomsControls = new List<Control>();
            //foreach (var room in rooms)
            //{
            //    var item = ModelToControl(room);
            //    roomsControls.Add(item);
            //}
            //tlpRoomList.AddViewsToPanel(roomsControls);

            MainForm.ResumeLayout();


            labelGroupMain_Click(null, null);
            load.stop();
        }
        #endregion

        #region ע��֪ͨ
        private void RegisterMessenger()
        {
            //Messenger.Default.Register<bool>(this, GroupSquareLayout.DELETE_GROUP_ITEM, DeleteGroup);
            //Messenger.Default.Register<bool>(this, GroupSquareLayout.SEND_GROUP_MSG, (_) =>
            //{
            //    MainForm.SendMessageToFriend(SelectedItem.FriendData);
            //});

            //// �޸�Ⱥ������
            //Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_CHANGE_MESSAGE, UpdateRommItem);

            //// ���˳���һ��Ⱥ
            //Messenger.Default.Register<MessageObject>(this, MessageActions.XMPP_UPDATE_ROOM_DELETE, UpdateRommItem);

            //// �ұ����������һ��Ⱥ
            //Messenger.Default.Register<Friend>(this, MessageActions.ROOM_UPDATE_INVITE, CreteItemView);

            //Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, RefreshFriendHead);
        }

        #endregion

        #region ˢ���û�ͷ��
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
                // ˢ���û�ͷ��
                item.LoadHeadImage();
            }
        }
        #endregion

        #region ˢ��Ⱥ������
        private void UpdateRommName(Friend friend)
        {
            int index = mAdapter.GetIndexByFriendId(friend.UserId);
            if (index > -1)
            {
                mAdapter.ChangeData(index, friend);

                if (xListView.DataCreated(index))
                {
                    FriendItem item = xListView.GetItemControl(index) as FriendItem;
                    // �޸�����
                    item.FriendData.NickName = friend.NickName;
                    item.ChangeFriendName();

                    MainForm.mainPageLayout.ChangeGroupName(item.FriendData);
                }
            }
        }
        #endregion

        #region �޸�Ⱥ����
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
                            // ɾ������    
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

        #region ����RoomJIdɾ����
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

                // ɾ���ȽϿ��µ�Ԫ����Ҫ�Զ������б�
                if (xListView.Progress > 90 && index > mAdapter.GetItemCount() * 0.7)
                {
                    int locy = xListView.ListPanelLocationY() + mAdapter.OnMeasureHeight(0);
                    if (locy < 0)
                    {
                        xListView.MovePanelLocation(locy);
                        Console.WriteLine("�����ƶ��б�" + locy);
                    }

                }
            }
        }
        #endregion

        #region ����Friend������
        private void CreteItemView(Friend room)
        {
            if (Thread.CurrentThread.IsBackground == true)
            {
                var tmp = new ProcesssFriend(CreteItemView);
                this.Invoke(tmp, room);
                return;
            }

            int index = mAdapter.GetIndexByFriendId(room.UserId);

            // û�о����
            if (index == -1)
            {
                mAdapter.InsertData(0, room);
                xListView.InsertItem(0);
            }
        }
        #endregion

        #region �Ҽ��˵�-ɾ��|�˳�Ⱥ��
        private void DeleteGroup(bool para)
        {


            var group = SelectedItem.FriendData.Clone();//��ȡѡ��Ⱥ��
            if (CurrIsLeader(Applicate.MyAccount.userId, group.RoomId))
            {
                if (MessageBox.Show("�Ƿ��ɢ  " + group.NickName + " ��", "ɾ��Ⱥ��", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "������" };
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
                if (MessageBox.Show("�Ƿ��˳�  " + group.NickName + " ��", "�˳�Ⱥ��", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var load = new LodingUtils { parent = this.xListView, Title = "������" };
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

        #region �����Ҽ��˵�
        public FriendItem BindContextMenu(FriendItem item)
        {
            return null;

            //var sendmsgitem = new MenuItem("������Ϣ", (sender, eve) =>
            //{
            //    Messenger.Default.Send(true, GroupSquareLayout.SEND_GROUP_MSG);

            //});
            ////var detailitem = new MenuItem("Ⱥ������", (sen, eve) => { Messenger.Default.Send(true, GroupSquareLayout.SHOW_GROUP_DETAIL); });
            //string str = CurrIsLeader(Applicate.MyAccount.userId, item.FriendData.RoomId) ? "��ɢȺ��" : "�˳�Ⱥ��";
            //var blockitem = new MenuItem(str, (sender, eve) =>
            //{
            //    Messenger.Default.Send(true, GroupSquareLayout.DELETE_GROUP_ITEM);
            //});

            //var cm = new ContextMenu();
            //cm.MenuItems.Add(sendmsgitem);
            ////cm.MenuItems.Add(detailitem);
            //cm.MenuItems.Add(blockitem);
            //item.ContextMenu = cm;//�����Ҽ��˵�
            //return item;
        }
        #endregion

        #region �ж�����ĳ��Ⱥ���Ƿ���Ⱥ��
        private bool CurrIsLeader(string useruId, string roomid)
        {
            int role = new RoomMember() { userId = useruId, roomId = roomid }.GetRoleByUserId();
            return role == 1;
        }
        #endregion

        #region ˫��Ⱥ�鿪ʼ����
        public void DoubleGroupItem(object sender, EventArgs e)
        {
            FriendItem item = sender as FriendItem;
            if (item.FriendData.IsSecretGroup == 1) MainForm.SendMessageToFriend(item.FriendData);
        }

        public void GroupItemWG_Click(object sender, EventArgs e)
        {
            Messenger.Default.Send("", MessageActions.groupmsg_wg);
        }
        #endregion
        public void GroupItem_Click(object sender, EventArgs e)
        {
            // �����ظ������
            FriendItem temp = sender as FriendItem;
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                if (temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
                {
                    return;
                }
            }

            // �ı�ѡ�б�����ɫ
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                // ����һ��ȡ��ѡ��
                SelectedItem.IsSelected = false;
            }
            temp.IsSelected = true;

            SelectedItem = temp;


            MainForm.SelectGroup(SelectedItem.FriendData);
            MainForm.SelectIndex = MainTabIndex.Square;//��ʾȺ�������Ҳ����

        }
        #region ������Ҽ�ѡ���¼�
        public void MouseDownItem(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                return;
            }
            // �����ظ������
            FriendItem temp = sender as FriendItem;
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                if (temp.FriendData.UserId.Equals(SelectedItem.FriendData.UserId))
                {
                    return;
                }
            }

            // �ı�ѡ�б�����ɫ
            if (SelectedItem != null && SelectedItem.FriendData != null)
            {
                // ����һ��ȡ��ѡ��
                SelectedItem.IsSelected = false;
            }
            temp.IsSelected = true;

            SelectedItem = temp;

            if (e == null || e.Button == MouseButtons.Left)
            {
                MainForm.SelectGroup(SelectedItem.FriendData);
                MainForm.SelectIndex = MainTabIndex.GroupPage;//��ʾȺ�������Ҳ����
            }
        }

        #endregion

        #region +�ŵ��
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Applicate.URLDATA.data.isOpenRoomSearch == 0)
            {
                #region ������Ⱥ����
                var tmpset = Applicate.GetWindow<FrmGroupQuery>();
                var parent = Applicate.GetWindow<FrmMain>();
                if (tmpset == null)//�����򿪺�����Ӵ���
                {
                    var query = new FrmGroupQuery();
                    query.Location = new Point(parent.Location.X + (parent.Width - query.Width) / 2, parent.Location.Y + (parent.Height - query.Height) / 2);//����
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
                #region ����Ⱥ
                FrmBuildGroups create = new FrmBuildGroups();
                var parent = Applicate.GetWindow<FrmMain>();
                create.Location = new Point(parent.Location.X + (parent.Width - create.Width) / 2, parent.Location.Y + (parent.Height - create.Height) / 2);//����
                create.Show();
                #endregion
            }
        }
        #endregion

        #region �����ı��ı�ʱ

        private string lastSearchText;



        public void Search(string currText)
        {

            if (string.IsNullOrEmpty(currText) && string.IsNullOrEmpty(lastSearchText))
            {
                //LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, currText))
            {
                //LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            // �����������
            if (string.IsNullOrEmpty(currText) && !string.IsNullOrEmpty(lastSearchText))
            {
                lastSearchText = currText;
                // �ָ�ԭ�б�
                //LoadRoomList();
                return;
            }

            lastSearchText = currText;
            if (!string.IsNullOrEmpty(currText))
            {
                // ������������
                //LoadRoomList(currText);
                return;
            }
        }



        private void TimerSearch_Tick(object sender, EventArgs e)
        {

        }

        #endregion
        string grouptype = "GroupMain";
        private void labelGroupMain_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFL.Visible = false;
            flowLayoutPanelFL2.Visible = false;
            grouptype = "GroupMain";
            labelGroupMain.Font = new Font("����", 9, FontStyle.Bold);
            labelGroupManage.Font = new Font("����", 9);
            //List<Friend> groupGQList = rooms.FindAll(x => x.UserType == 1);
            //mAdapter.BindFriendData(rooms);
            //xListView.SetAdapter(mAdapter);
            rooms = null;
            xListView.ClearList();
            getGroupGQ();
        }

        private void labelGroupManage_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFL.Visible = false;
            flowLayoutPanelFL2.Visible = false;
            grouptype = "GroupManage";
            labelGroupMain.Font = new Font("����", 9);
            labelGroupManage.Font = new Font("����", 9, FontStyle.Bold);
            //List<Friend> groupSQList = rooms.FindAll(x => x.UserType == 2);
            //mAdapter.BindFriendData(groupSQList);
            //xListView.SetAdapter(mAdapter);
            rooms = null;
            xListView.ClearList();
            getGroupSQ();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            getGroupSQFL();
            flowLayoutPanelFL.Visible = true;
        }

        private void panelGroupType_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}