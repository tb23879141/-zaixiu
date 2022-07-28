using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk
{
    /// <summary>
    /// 好友选择器
    /// <para>lxq-3.12</para>
    /// </summary>
    public partial class FrmFriendSelect : FrmBase
    {
        public delegate void FrinedSelectHandler(Friend friend);
        public delegate void FrinedLeftHandler(UserItem item);

        private SelectFriendAdapter mLeftAdapter;
        private SelectedFriendAdapter mRightAdapter;

        private LodingUtils loding;//等待符控件全局
        public int max_number = 15;//最多选择多少好友
        public Dictionary<string, Friend> checkDatas = new Dictionary<string, Friend>();//选中好友
        private Action<Dictionary<string, Friend>> mListener;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmFriendSelect_title", this.Text);
            lbltips.Text = LanguageXmlUtils.GetValue("frmFriendSelect_tips", lbltips.Text);
            btnConfirm.Text = LanguageXmlUtils.GetValue("btn_ok", btnConfirm.Text);
            btnClose.Text = LanguageXmlUtils.GetValue("btn_cancel", btnClose.Text);
        }
        public bool isPagesize = true;
        // private bool isLock;
        public FrmFriendSelect()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标

            mLeftAdapter = new SelectFriendAdapter();
            mRightAdapter = new SelectedFriendAdapter();

            mLeftAdapter.FrmFriend = this;
            mRightAdapter.FrmFriend = this;
            userSearch.tips = LanguageXmlUtils.GetValue("search", "搜索");
            userSearch.SearchEvent += SearchFriend;

            // 增加分页

            leftList.FooterRefresh += LoadNextPageMenber;

        }



        private bool isLoading;

        // 分页加载群成员
        private void LoadNextPageMenber()
        {
            if (isLoading)
            {
                return;
            }

            if (UIUtils.IsNull(RoomId))
            {
                return;
            }

            isLoading = true;
            ShowLodingDialog();

            // 分页获取群成员
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/getMemberListByPage")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", RoomId)
                .AddParams("joinTime", GetLastTime())
                .AddParams("pageSize", "50")
                .Build()
                .ExecuteJson<List<RoomMember>>((sccess, datas) =>
                {

                    if (sccess && !UIUtils.IsNull(datas))
                    {
                        isLoading = datas.Count != 50;

                        List<Friend> friends = new List<Friend>();

                        foreach (var item in datas)
                        {
                            Friend friend = new Friend();
                            friend.UserId = item.userId;
                            friend.NickName = item.GetRoomShowName();
                            lastTime = Convert.ToString(item.createTime + 1);
                            friends.Add(friend);

                        }


                        int count = mLeftAdapter.GetItemCount();
                        mLeftAdapter.InsertRange(count, friends);
                        leftList.InsertRange(count);
                    }
                    else
                    {
                        isLoading = false;
                    }
                    if (loding != null)
                    {
                        loding.stop();
                    }


                });
        }


        private string lastTime;
        private string GetLastTime()
        {
            return lastTime;
        }



        /// <summary>
        /// 窗体打开后数据加载
        /// <para>默认0只有好友，1好友群组都有</para>
        /// </summary>
        public void LoadFriendsData(int haveGroup = 0)
        {
            List<Friend> queryList = new List<Friend>();

            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
            CenterOpen();

            ShowLodingDialog();//使用等待符

            if (haveGroup == 1)
            {
                queryList = new Friend().GetRecordSortList();
            }
            else
            {
                queryList = new Friend() { IsGroup = 0 }.GetFriendsByIsGroup(1);
            }

            BindDataToList(queryList);
            loding.stop();

        }


        private bool isOpenSSLVerify;
        /// <summary>
        /// 挑选合法的朋友
        /// <para>默认0只有好友，1好友群组都有</para>
        /// </summary>
        public void LoadSSLFriends()
        {
            isOpenSSLVerify = true;
            LoadFriendsData();
        }


        /// <summary>
        /// 加载传入过来的数据
        /// </summary>
        /// <param name="friends"></param>
        public void LoadFriendsData(List<Friend> friends)
        {
            CenterOpen();

            ShowLodingDialog();
            BindDataToList(friends);
            LogUtils.Log("加载完成");
            loding.stop();
        }

        /// <summary>
        /// 需要剔除的好友
        /// </summary>
        /// <param name="removes"></param>
        public void LoadFriendsData(List<RoomMember> removes, bool ispagesize, bool isEncrypt = false)
        {

            isPagesize = ispagesize;
            if (!isPagesize)
            {
                leftList.FooterRefresh -= LoadNextPageMenber;
            }
            isOpenSSLVerify = isEncrypt;
            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
            CenterOpen();
            ShowLodingDialog();

            Friend query2 = new Friend() { IsGroup = 0 };
            List<Friend> queryList = query2.GetFriendsByIsGroup();
            for (int i = (queryList.Count - 1); i > -1; i--)
            {
                foreach (var reme in removes)
                {
                    if (queryList[i].UserId.Equals(reme.userId) || queryList[i].UserType > 1)
                    {
                        queryList.Remove(queryList[i]);
                        break;
                    }
                }
            }

            BindDataToList(queryList);
            LogUtils.Log("加载完成");
            loding.stop();
        }


        private bool isAtMember = false;
        public string RoomId = "";
        /// <summary>
        /// 群视频电话
        /// </summary>
        /// <param name="Room"></param>
        public void LoadFriendsData(Friend Room, bool isAt = false)
        {
            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
            CenterOpen();
            ShowLodingDialog();

            isAtMember = isAt;
            RoomId = Room.RoomId;
            // List<Friend> queryList = new List<Friend>();
            //111

            lastTime = "0";

            // 分页获取群成员
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/getMemberListByPage")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", RoomId)
                .AddParams("joinTime", GetLastTime())
                .AddParams("pageSize", "50")
                .Build()
                .ExecuteJson<List<RoomMember>>((sccess, members) =>
                {
                    //    string mendata = UIUtils.DecodeString(result, "members");
                    //  List<RoomMember> members = JsonConvert.DeserializeObject<List<RoomMember>>(mendata);
                    if (members == null || members.Count < 50)
                    {
                        isLoading = true;
                    }

                    List<Friend> friends = new List<Friend>();
                    foreach (var item in members)
                    {

                        if (isAt && string.Equals(Applicate.MyAccount.userId, item.userId))
                        {
                            if (item.role == 1 || item.role == 2)
                            {
                                Friend allRoomMember = new Friend();
                                allRoomMember.UserId = "allRoomMember";
                                allRoomMember.NickName = "全体成员";
                                friends.Add(allRoomMember);
                            }
                        }


                        if (item.role != 4)
                        {
                            Friend allRoomMember = new Friend();
                            allRoomMember.UserId = item.userId;
                            allRoomMember.NickName = item.nickName;
                            allRoomMember.RemarkName = item.remarkName;//群主备注
                            friends.Add(allRoomMember);
                        }


                        lastTime = Convert.ToString(item.createTime + 1);

                    }



                    BindDataToList(friends);
                    loding.stop();

                });
        }


        /// <summary>
        /// 语音通话专用
        /// </summary>
        /// <param name="Room"></param>
        /// <param name="joined"></param>
        /// <param name="isAt"></param>
        public void LoadFriendsData(Friend Room, List<RoomMember> joined)
        {
            isAtMember = true;
            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
            CenterOpen();
            ShowLodingDialog();
            RoomId = Room.RoomId;
            lastTime = "0";

            // 分页获取群成员
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/getMemberListByPage")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", RoomId)
                .AddParams("joinTime", GetLastTime())
                .AddParams("pageSize", "50")
                .Build()
                .ExecuteJson<List<RoomMember>>((sccess, members) =>
                {
                    if (members == null || members.Count < 50)
                    {
                        isLoading = true;
                    }

                    List<Friend> friends = new List<Friend>();
                    for (int i = (members.Count - 1); i >= 0; i--)
                    {
                        if (string.Equals(Applicate.MyAccount.userId, members[i].userId))
                        {
                            members.Remove(members[i]);
                            continue;
                        }

                        for (int j = 0; j < joined.Count; j++)
                        {
                            if (members[i].userId.Equals(joined[j].userId))
                            {
                                members.Remove(members[i]);
                                break;
                            }
                        }

                        Friend allRoomMember = new Friend();
                        allRoomMember.UserId = members[i].userId;
                        allRoomMember.NickName = members[i].nickName;
                        friends.Add(allRoomMember);
                    }

                    BindDataToList(friends);
                    loding.stop();
                });




            //HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/list")
            //    .AddParams("access_token", Applicate.Access_Token)
            //    .AddParams("roomId", Room.RoomId)
            //    .Build().Execute((suss, data) =>
            //    {
            //        if (suss)
            //        {
            //            JArray array = JArray.Parse(UIUtils.DecodeString(data, "data"));
            //            foreach (var arrayItem in array)
            //            {
            //                Friend friend = JsonConvert.DeserializeObject<Friend>(arrayItem.ToString());
            //                if (friend.UserId == Applicate.MyAccount.userId)
            //                {
            //                    if (isAt && UIUtils.DecodeString(arrayItem, "role") == "1" ||
            //                        UIUtils.DecodeString(arrayItem, "role") == "2")
            //                    {
            //                        Friend allRoomMember = new Friend();
            //                        allRoomMember.UserId = "allRoomMember";
            //                        allRoomMember.NickName = "全体成员";
            //                        queryList.Add(allRoomMember);
            //                    }
            //                }

            //                if (friend.UserId != Applicate.MyAccount.userId)
            //                {
            //                    //不显示隐身人
            //                    if (!UIUtils.DecodeString(arrayItem, "role").Equals("4"))
            //                        queryList.Add(friend);
            //                }
            //            }

            //            //Console.WriteLine("queryLIst");
            //            BindDataToList(queryList);
            //            // HaoShiTask(list1, queryList);
            //            // paging(list1);
            //            //LogUtils.Log("加载完成");
            //            loding.stop();
            //            // leftList.Controls.Remove(userLoding);
            //        }
            //    });
        }



        private void BindDataToList(List<Friend> list)
        {
            mLeftAdapter.BindFriendData(list);
            leftList.SetAdapter(mLeftAdapter);

            mRightAdapter.BindFriendData(new List<Friend>());
            rightList.SetAdapter(mRightAdapter);
        }

        public void OnSelectFriend(UserItem item)
        {
            if (item.CheckState)
            {
                // 取消选中
                item.CheckState = !item.CheckState;
                // 移除数据
                ChangeCheckData(false, item.Friend);
                // 清除右边项
                int index = mRightAdapter.GetIndexById(item.Friend.UserId);
                if (index > -1)
                {
                    rightList.RemoveItem(index);
                    mRightAdapter.RemoveData(index);
                }
            }
            else
            {
                if (checkDatas.Count >= max_number)
                {
                    ShowTip("最多只能选择" + max_number + "个人");
                    return;
                }


                if (isOpenSSLVerify)
                {
                    if (UIUtils.IsNull(item.Friend.RsaPublicKey))
                    {
                        ShowTip("加密群组只能邀请新版用户");
                        return;
                    }
                }

                // 选中
                item.CheckState = !item.CheckState;
                // 添加数据
                ChangeCheckData(true, item.Friend);
                // 添加右边项
                int index = mRightAdapter.GetItemCount();
                mRightAdapter.InsertData(index, item.Friend);
                rightList.InsertItem(index);
            }
        }

        // 取消选中
        public void OnUnSelectFriend(Friend friend)
        {
            // 查询左边项位置
            int index = mLeftAdapter.GetIndexById(friend.UserId);
            if (index > -1)
            {
                var item = leftList.GetItemControl(index) as UserItem;
                OnSelectFriend(item);
            }
        }



        /// <summary>
        /// 修改数据集合
        /// </summary>
        /// <param name="check"></param>
        /// <param name="friend"></param>
        public void ChangeCheckData(bool check, Friend friend)
        {
            if (check)
            {
                if (!checkDatas.ContainsKey(friend.UserId))
                {
                    checkDatas.Add(friend.UserId, friend);
                }
            }
            else
            {
                checkDatas.Remove(friend.UserId);


            }
            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
        }

        /// <summary>
        /// 使用等待符
        /// </summary>
        private void ShowLodingDialog()
        {
            loding = new LodingUtils();
            loding.parent = leftList;
            loding.Title = "加载中";
            loding.start();
        }
        internal void AddConfrmListener(Action<Dictionary<string, Friend>> action)
        {
            mListener = action;
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (checkDatas == null || checkDatas.Count <= 0)
            {
                return;
            }
            if (!this.btnConfirm.Enabled)
            { return; }
            this.btnConfirm.Enabled = false;
            //我将业务放在线程里处理,若不让在线程里,this.btnConfirm.Enabled = false;不会有禁止效果,因为本次主线程没有完成。
            Task task = new Task(() =>
            {
                if (mListener != null)
                {
                    this.Close();
                    mListener(checkDatas);
                }
            }

            );
            task.Start();

        }
        private void RevertData()
        {
            fristSearch = true;

            List<Friend> select = mRightAdapter.GetFriendDatas();

            foreach (var friend in mFriends)
            {
                friend.UserType = 0;
            }

            foreach (var item in select)
            {
                foreach (var friend in mFriends)
                {
                    if (item.UserId.Equals(friend.UserId))
                    {
                        friend.UserType = 10;
                        break;
                    }
                }
            }

            mLeftAdapter.BindFriendData(mFriends);
            leftList.SetAdapter(mLeftAdapter);
        }


        public bool fristSearch = true;

        public void SearchFriend(string text)
        {
            //if (!isLock)
            //{
            //    return;
            //}

            //isLock = false;
            leftList.FooterRefresh -= LoadNextPageMenber;
            loding.stop();

            if (fristSearch)
            {
                mFriends = mLeftAdapter.GetDataFriends();
            }


            if (string.IsNullOrEmpty(text))
            {
                // 还原数据
                if (!isPagesize)
                {
                    leftList.FooterRefresh -= LoadNextPageMenber;
                }
                leftList.FooterRefresh += LoadNextPageMenber;
                RevertData();
            }
            else
            {
                List<Friend> search = SearchNickName(text);
                fristSearch = false;
                if (isAtMember)
                {
                    mFriends = mLeftAdapter.GetDataFriends();
                    HttpSearchMembes(RoomId, text, search);
                    return;
                }


                if (UIUtils.IsNull(search))
                {
                    mLeftAdapter.BindFriendData(new List<Friend>());
                    leftList.SetAdapter(mLeftAdapter);

                    return;
                }

                List<Friend> select = mRightAdapter.GetFriendDatas();
                foreach (var item in select)
                {
                    foreach (var friend in search)
                    {
                        if (item.UserId.Equals(friend.UserId))
                        {
                            friend.UserType = 10;
                            break;
                        }
                    }
                }

                mLeftAdapter.BindFriendData(search);
                leftList.SetAdapter(mLeftAdapter);
            }
        }

        private void HttpSearchMembes(string roomId, string keyword, List<Friend> search)
        {

            ShowLodingDialog();

            // 搜索群成员
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/list")
                .AddParams("roomId", roomId)
                .AddParams("keyword", keyword)
                .Build()
                .ExecuteJson<List<RoomMember>>((sccess, datas) =>
                {

                    if (UIUtils.IsNull(datas) && UIUtils.IsNull(search))
                    {
                        leftList.ClearList();
                    }
                    else
                    {
                        List<Friend> result = MergeSearchResult(datas, search);

                        if (UIUtils.IsNull(result))
                        {
                            leftList.ClearList();

                            if (loding != null)
                            {
                                loding.stop();
                            }
                            return;
                        }


                        List<Friend> select = mRightAdapter.GetFriendDatas();
                        foreach (var item in select)
                        {
                            foreach (var friend in result)
                            {
                                if (item.UserId.Equals(friend.UserId))
                                {
                                    friend.UserType = 10;
                                    break;
                                }
                            }
                        }

                        mLeftAdapter.BindFriendData(result);
                        leftList.SetAdapter(mLeftAdapter);

                    }



                    if (loding != null)
                    {
                        loding.stop();
                    }

                });

        }

        private List<Friend> MergeSearchResult(List<RoomMember> datas, List<Friend> search)
        {
            if (UIUtils.IsNull(datas))
            {
                return search;
            }


            List<Friend> server = new List<Friend>();


            for (int i = 0; i < datas.Count; i++)
            {
                Friend friend = new Friend();
                friend.UserId = datas[i].userId;
                friend.NickName = datas[i].GetRoomShowName();
                server.Add(friend);

            }

            if (UIUtils.IsNull(search))
            {

                return server;
            }


            search.AddRange(server);

            Dictionary<string, int> ddr = new Dictionary<string, int>();
            List<Friend> dd = new List<Friend>();

            for (int i = search.Count - 1; i > -1; i--)
            {
                var friend = search[i];
                if (!ddr.ContainsKey(friend.UserId))
                {
                    ddr.Add(friend.UserId, 0);
                    dd.Add(friend);
                }
            }

            return dd;

        }

        private List<Friend> SearchNickName(string text)
        {
            List<Friend> data = new List<Friend>();
            foreach (var item in mFriends)
            {
                if (UIUtils.Contains(item.NickName, text) || UIUtils.Contains(item.RemarkName, text))
                {
                    item.UserType = 0;
                    data.Add(item);
                }
            }

            return data;
        }

        private List<Friend> mFriends;
        internal bool isDialog;

        public string Mark { get; internal set; }




        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


            //
            //timer.Tick += (sen, eve) =>
            //{
            //    timer.Stop();
            //    leftList.ClearTabel(false);
            //    List<Control> listSearch = new List<Control>();
            //    if (string.IsNullOrEmpty(txtSearch.Text))
            //    {

            //        leftList.AddViewsToPanel(list1);
            //        return;
            //    }
            //    foreach (Control item in list1)
            //    {
            //        if (item is UserItem)
            //        {
            //            UserItem u_item= item as UserItem;
            //           LogUtils.Log(((Friend)item.Tag).nickName);
            //           if (u_item.nickName.Contains(txtSearch.Text.Trim()) || u_item.nickName.Contains(txtSearch.Text.Trim().ToUpper()) || u_item.nickName.Contains(txtSearch.Text.Trim().ToLower()))
            //            {
            //                listSearch.Add(item);
            //            }
            //          LogUtils.Log(u_item.nickName);
            //        }
            //    }
            //    leftList.AddViewsToPanel(listSearch);
            //};
            //timer.Stop();
            //timer.Start();
        }


        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体居中打开
        /// </summary>
        private void CenterOpen()
        {
            var parea = Applicate.GetWindow<FrmMain>();
            this.Location = new Point(parea.Location.X + (parea.Width - this.Width) / 2, parea.Location.Y + (parea.Height - this.Height) / 2);

            if (isDialog)
            {
                this.TopMost = true;
            }

            this.Show();
        }

        private void FrmFriendSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                return;
            }
        }
    }
}
