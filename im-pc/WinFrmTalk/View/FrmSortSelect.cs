using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;
using WinFrmTalk.View.list;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class FrmSortSelect : FrmBase
    {
        public delegate void FrinedLeftHandler(UserItem item);

        public MyColleague myColleague = null;//我的同事所有信息
        private SelectedFriendAdapter mRightAdapter;
        private SelectFriendAdapter mLeftAdapter;
        private LodingUtils loding;//等待符控件全局
        public int max_number = 15;//最多选择多少好友
        public Dictionary<string, Friend> checkDatas = new Dictionary<string, Friend>();//选中好友
        private Action<Dictionary<string, Friend>> mListener;
       
       // private bool isLock;
        public bool fristSearch = true;
        private List<Friend> AllDataLst = new List<Friend>();//所有的好友集合数据
        private Dictionary<string, Friend> AllLst = new Dictionary<string, Friend>();

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmSortSelect_title", this.Text);
            lbltips.Text = LanguageXmlUtils.GetValue("frmSortSelect_tips", lbltips.Text);
            btnConfirm.Text = LanguageXmlUtils.GetValue("btn_ok", btnConfirm.Text);
            btnClose.Text = LanguageXmlUtils.GetValue("btn_cancel", btnClose.Text);
            tsAllselct.Text = LanguageXmlUtils.GetValue("check_all", tsAllselct.Text);
            tsCnlAllselct.Text = LanguageXmlUtils.GetValue("check_none", tsCnlAllselct.Text);
        }

        public FrmSortSelect()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            mLeftAdapter = new SelectFriendAdapter();
            mLeftAdapter.frmSortSelect = this;
            mLeftAdapter.isSort = false;
            mRightAdapter = new SelectedFriendAdapter();
            mRightAdapter.frmSortSelect = this;
            mRightAdapter.isSort = false;
            BindDataToList();
            
            max_number = Applicate.ForwardMaxCount;
            if (max_number>= 999)
            {
                lblCount.Visible = false;
            }
            else
            {
                lblCount.Text = "0/" + max_number + LanguageXmlUtils.GetValue("people", "人");
            }
            userSearch.tips = LanguageXmlUtils.GetValue("search", "搜索");
            userSearch.SearchEvent += SearchMeesageContent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="showrecent">是否显示最近消息列表</param>
        /// <param name="showfriend">是否显示好友列表</param>
        /// <param name="showgroup">是否显示群组列表</param>
        /// <param name="showrlabel">是否显示好友标签</param>
        /// <param name="showmycolleage">是否显示我的同事</param>
        public void LoadFriendsData(bool showrecent, bool showfriend, bool showgroup, bool showrlabel, bool showmycolleage)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/company/getByUserId")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("userId", Applicate.MyAccount.userId)
                   .Build().Execute((suss, resultData) =>
                   {
                       if (suss)
                       {
                           myColleague = JsonConvert.DeserializeObject<MyColleague>(JsonConvert.SerializeObject(resultData));//数据泛型解析
                           loadTreedata(showrecent, showfriend, showgroup, showrlabel, showmycolleage);
                       }
                   });
        }

        /// <summary>
        /// 加载树的数据
        /// </summary>
        /// 并不是所有的树都需要显示
        public void loadTreedata(bool showrecent, bool showfriend, bool showgroup, bool showrlabel, bool showmycolleage)
        {
            Friend f = new Friend { UserId = Applicate.MyAccount.userId };
            List<Friend> friendAllLst = new List<Friend>();
            bool state2 = true;
            #region 最近消息
            if (showrecent)
            {
                SortSelectNode tn1 = new SortSelectNode(LanguageXmlUtils.GetValue("recent_news", "最近消息"));
                tn1.ContextMenuStrip = cmtSelct;
                tn1.Name = LanguageXmlUtils.GetValue("recent_news", "最近消息");
                //  tn1.Tag = itemData.departments[0];
                tvwColleague.Nodes.Add(tn1);
                if (state2)
                {
                    tvwColleague.SelectedNode = tn1;//默认选中的节点
                                                    //Clicknode = tn1;
                                                    //lblNodeName.Text = itemData.departments[0].departName;
                    state2 = false;
                }

                List<Friend> friends = new List<Friend>();
                friends = f.GetRecentList();//获取最近消息列表

                foreach (Friend friend in friends)
                {
                    SortSelectNode tn2_1 = new SortSelectNode(friend.NickName);
                    tn2_1.Name = friend.NickName;
                    tn2_1.Tag = friend;
                    tn2_1.ImageKey = "not_icon";
                    tn1.Nodes.Add(tn2_1);
                    //去重
                    if (!AllLst.ContainsKey(friend.UserId))
                    {
                        AllDataLst.Add(friend);
                        AllLst.Add(friend.UserId, friend);
                    }

                }
            }

            #endregion
            #region 所有的好友
            if (showfriend)
            {
                SortSelectNode tnfriend = new SortSelectNode(LanguageXmlUtils.GetValue("choose_fd", "选择好友"));
                tnfriend.Name = LanguageXmlUtils.GetValue("choose_fd", "选择好友");
                //  tn1.Tag = itemData.departments[0];
                tnfriend.ContextMenuStrip = cmtSelct;
                
                tvwColleague.Nodes.Add(tnfriend);
                if (state2)
                {
                    // tvwColleague.SelectedNode = tn1;//默认选中的节点
                    //Clicknode = tn1;
                    //lblNodeName.Text = itemData.departments[0].departName;
                    state2 = false;
                }
                friendAllLst = f.GetFriendsByIsGroup();//获取最近消息列表

                foreach (Friend friend in friendAllLst)
                {
                    SortSelectNode tn2_1 = new SortSelectNode(friend.NickName);
                    tn2_1.Name = friend.NickName;
                    tn2_1.Tag = friend;
                    tn2_1.ImageKey = "not_icon"; 
                    tnfriend.Nodes.Add(tn2_1);

                    if (!AllLst.ContainsKey(friend.UserId))
                    {
                        AllDataLst.Add(friend);
                        AllLst.Add(friend.UserId, friend);
                    }
                }
                // tnfriend.ExpandAll();
            }

            #endregion
            #region 群组
            if (showgroup)
            {
                SortSelectNode tnroom = new SortSelectNode(LanguageXmlUtils.GetValue("group", "群组"));
                tnroom.Name = LanguageXmlUtils.GetValue("group", "群组");
                //  tn1.Tag = itemData.departments[0];
                tnroom.ImageKey = "";
                tnroom.ContextMenuStrip = cmtSelct;
                tvwColleague.Nodes.Add(tnroom);
                if (state2)
                {
                    // tvwColleague.SelectedNode = tn1;//默认选中的节点
                    //Clicknode = tn1;
                    //lblNodeName.Text = itemData.departments[0].departName;
                    state2 = false;
                }

                List<Friend> RoomLst = new List<Friend>();
                friendAllLst = f.GetGroupsList();//获取最近消息列表
                foreach (Friend friend in friendAllLst)
                {
                    SortSelectNode tn2_1 = new SortSelectNode(friend.NickName);
                    tn2_1.Name = friend.NickName;
                    tn2_1.Tag = friend;
                    tn2_1.ImageKey = "not_icon";
                    tnroom.Nodes.Add(tn2_1);
                    if (!AllLst.ContainsKey(friend.UserId))
                    {
                        AllDataLst.Add(friend);
                        AllLst.Add(friend.UserId, friend);
                    }
                }
            }

            #endregion
            #region 好友标签
            if (showrlabel)
            {
                SortSelectNode tnfriendLabel = new SortSelectNode(LanguageXmlUtils.GetValue("fd_label", "好友标签"));
               
                tnfriendLabel.Name = LanguageXmlUtils.GetValue("fd_label", "好友标签");
                //  tn1.Tag = itemData.departments[0];
                tnfriendLabel.ImageKey = "";
                tvwColleague.Nodes.Add(tnfriendLabel);
                if (state2)
                {
                    // tvwColleague.SelectedNode = tn1;//默认选中的节点
                    //Clicknode = tn1;
                    //lblNodeName.Text = itemData.departments[0].departName;
                    state2 = false;
                }

                // 跟目录 ：好友标签，1级子目录：好友标签名称2级目录：好友
                List<FriendLabel> LabelLst = FriendLabelDao.Instance.GetAllFriendLabel();
                if (UIUtils.IsNull(LabelLst))
                {
                    return;
                }

                foreach (FriendLabel label in LabelLst)
                {
                    SortSelectNode tn2_1 = new SortSelectNode(label.groupName);
                    tn2_1.Name = label.groupName;
                    tn2_1.ImageKey = "not_icon";
                    tn2_1.Tag = label.groupId;//标签id
                    tn2_1.ImageKey = "";
                    tn2_1.ContextMenuStrip = cmtSelct;
                    tnfriendLabel.Nodes.Add(tn2_1);
                    List<Friend> friendlst = label.GetFriendList();
                    if(friendlst!=null)
                    {
                        foreach (Friend friend in friendlst)
                        {
                            SortSelectNode tnfriends = new SortSelectNode(friend.NickName);
                            tnfriends.Name = friend.NickName;
                            tnfriends.Tag = friend;
                            tnfriends.ImageKey = "not_icon";
                            tn2_1.Nodes.Add(tnfriends);
                            if (!AllLst.ContainsKey(friend.UserId))
                            {
                                AllDataLst.Add(friend);
                                AllLst.Add(friend.UserId, friend);
                            }
                        }
                    }
                    
                }
            }
            #endregion
            #region 我的同事
            if (showmycolleage)
            {
                SortSelectNode tnmycolleage = new SortSelectNode(LanguageXmlUtils.GetValue("my_colleague", "我的同事"));
                tnmycolleage.Name = LanguageXmlUtils.GetValue("my_colleague", "我的同事");
                //  tn1.Tag = itemData.departments[0];
                tnmycolleage.ImageKey = "";
                
                tvwColleague.Nodes.Add(tnmycolleage);


                if (myColleague.data == null)
                {
                    return;
                }
                foreach (ItemData itemData in myColleague.data)
                {
                    //公司层
                    SortSelectNode tncompany = new SortSelectNode(itemData.departments[0].departName);
                    tncompany.Name = itemData.departments[0].id;
                    tncompany.Tag = itemData.departments[0];
                    tncompany.ImageKey = "";
                    tnmycolleage.Nodes.Add(tncompany);
                    if (state2)
                    {
                        //tvwColleague.SelectedNode = tn1;//默认选中的节点
                        //Clicknode = tn1;
                        //lblNodeName.Text = itemData.departments[0].departName;
                        state2 = false;
                    }
                    foreach (DepartmentsItem itemDataDepartment1 in itemData.departments)
                    {
                        //第一层部门层
                        SortSelectNode tnDepartment1 = new SortSelectNode();
                        if (itemDataDepartment1.parentId == itemData.departments[0].id)
                        {
                            tnDepartment1.Text = itemDataDepartment1.departName;
                            tnDepartment1.Name = itemDataDepartment1.id;
                            tnDepartment1.ImageKey = "";
                            tnDepartment1.ContextMenuStrip = cmtSelct;
                            tnDepartment1.Tag = itemDataDepartment1;
                            tncompany.Expand();
                            tncompany.Nodes.Add(tnDepartment1);

                            //员工层
                            foreach (employeesItem employeesItem in itemDataDepartment1.employees)
                            {
                                SortSelectNode tn3 = new SortSelectNode(employeesItem.nickname);
                                tn3.ImageKey = "not_icon";
                                tn3.IsmyColleage = true;
                                tn3.Tag = employeesItem;
                                tnDepartment1.Nodes.Add(tn3);
                                Friend friend = employeesToFriend(employeesItem);
                                if (!AllLst.ContainsKey(friend.UserId))
                                {
                                    AllDataLst.Add(friend);
                                    AllLst.Add(friend.UserId, friend);
                                }
                            }
                            //第二层员工层
                            foreach (DepartmentsItem itemDataDepartment2 in itemData.departments)
                            {
                                if (itemDataDepartment1.id == itemDataDepartment2.parentId)
                                {
                                    SortSelectNode tn2_1 = new SortSelectNode(itemDataDepartment2.departName);
                                    tn2_1.ContextMenuStrip = cmtSelct;
                                    tn2_1.Name = itemDataDepartment2.id;
                                    tn2_1.Tag = itemDataDepartment2;
                                    tn2_1.ImageKey = "";
                                    tnDepartment1.Nodes.Add(tn2_1);
                                    foreach (employeesItem employeesItem in itemDataDepartment1.employees)
                                    {
                                        SortSelectNode tn3 = new SortSelectNode(employeesItem.nickname);
                                        tn3.Tag = employeesItem;
                                        tn3.ImageKey = "not_icon";
                                        tn3.IsmyColleage = true;
                                        tn2_1.Nodes.Add(tn3);
                                        Friend friend = employeesToFriend(employeesItem);
                                        if (!AllLst.ContainsKey(friend.UserId))
                                        {
                                            AllDataLst.Add(friend);
                                            AllLst.Add(friend.UserId, friend);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion
        public void OnSelectFriend(SortSelectNode item)
        {
            Friend f = new Friend();
            if (item.IsmyColleage)
            {
                //将同事的数据转换为friend
                employeesItem employeesItem = (employeesItem)item.Tag;
                f = employeesToFriend(employeesItem);
            }
            else
            {
                f = (Friend)item.Tag;
            }
            if (item.ischeck)
            {
                //取消选中

                //移除数据
                //选中的是同事则无法传friend

                ChangeCheckData(false, f);
                // 清除右边项
                int index = mRightAdapter.GetIndexById(f.UserId);
                if (index > -1)
                {
                    rightList.RemoveItem(index);
                    mRightAdapter.RemoveData(index);
                }
            }
            else
            {
                if ("not_icon".Equals(item.ImageKey))
                {
                    if (checkDatas.Count >= max_number)
                    {
                        ShowTip("最多只能选择" + max_number + "个人");
                        return;
                    }

                    ChangeCheckData(true, f);
                    // 添加右边项


                }

                // 选中

            }
        }

        private void addtopanel(Friend friend)
        {
            int index = mRightAdapter.GetItemCount();
            mRightAdapter.InsertData(index, friend);
            rightList.InsertItem(index);
        }
        private Friend employeesToFriend(employeesItem employeesItem)
        {
            Friend f = new Friend
            {
                UserId = employeesItem.userId,
                NickName = employeesItem.nickname,
            };
            return f;
        }
        private void BindDataToList()
        {
            mRightAdapter.BindFriendData(new List<Friend>());
            rightList.SetAdapter(mRightAdapter);
        }

        public void OnUnSelectFriend(Friend friend)
        {
            SortSelectNode newNode = new SortSelectNode();
            newNode.Tag = friend;
            newNode.ischeck = true;
            // 查询左边项位置
            //int index = mLeftAdapter.GetIndexById(friend.UserId);
            //if (index > -1)
            //{
            //    var item = leftList.GetItemControl(index) as UserItem;
            OnSelectFriend(newNode);

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
                    addtopanel(friend);

                }
            }
            else
            {
                checkDatas.Remove(friend.UserId);


            }
            lblCount.Text = checkDatas.Count.ToString() + "/" + max_number + LanguageXmlUtils.GetValue("people", "人");
        }

        private void tvwColleague_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SortSelectNode treeNode = (SortSelectNode)e.Node;
            if ("not_icon".Equals(treeNode.ImageKey))
            {
                OnSelectFriend(treeNode);
            }
        }
        internal void AddConfrmListener(Action<Dictionary<string, Friend>> action)
        {
            mListener = action;
        }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 使用等待符
        /// </summary>
        private void ShowLodingDialog()
        {
            loding = new LodingUtils();
            loding.parent = tvwColleague;
            loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
            loding.start();
        }
        private void SearchMeesageContent(string inputStr)
        {
            leftList.Visible = true;

            if (!string.IsNullOrEmpty(inputStr))
            {
                this.leftList.SuspendLayout();
                this.SuspendLayout();


                if (loding != null)
                {
                    loding.stop();
                }

                loding = new LodingUtils { parent = this.leftList, Title = LanguageXmlUtils.GetValue("loading", "加载中") };
                loding.start();

                //if (!isLock)
                //{
                //    return;
                //}
                //timer.Stop();
                //isLock = false;
                loding.stop();


                if (string.IsNullOrEmpty(inputStr))
                {
                    // 还原数据
                    RevertData();
                }
                else
                {
                    List<Friend> search = SearchNickName(inputStr);
                    fristSearch = false;
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
            else
            {
                tvwColleague.Visible = true;
                leftList.Visible = false;
               // isLock = false;
                //LoadFriendsData(is,true,true,true,true);
                //txtSearch.Focus();
            }


        }
        private List<Friend> SearchNickName(string text)
        {
            List<Friend> data = new List<Friend>();
            foreach (var item in AllDataLst)
            {
                if (UIUtils.Contains(item.NickName, text) || UIUtils.Contains(item.RemarkName, text))
                {
                    item.UserType = 0;
                    data.Add(item);
                }
            }

            return data;
        }
        /// <summary>
        /// 还原数据
        /// </summary>
        private void RevertData()
        {
            fristSearch = true;

            List<Friend> select = mRightAdapter.GetFriendDatas();

            foreach (var friend in AllDataLst)
            {
                friend.UserType = 0;
            }

            foreach (var item in select)
            {
                foreach (var friend in AllDataLst)
                {
                    if (item.UserId.Equals(friend.UserId))
                    {
                        friend.UserType = 10;
                        break;
                    }
                }
            }
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
                // 选中
                item.CheckState = !item.CheckState;
                // 添加数据
                ChangeCheckData(true, item.Friend);
                // 添加右边项
                //int index = mRightAdapter.GetItemCount();
                //mRightAdapter.InsertData(index, item.Friend);
                //rightList.InsertItem(index);
            }
        }
        TreeNode SelctNodes;

        /// <summary>
        /// 全选或者取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAllselct_Click(object sender, EventArgs e)
        {
            //OnSelectFriend
            SelctNodes = tvwColleague.SelectedNode;
            //获取当前的项
            if (tsAllselct.Text == LanguageXmlUtils.GetValue("check_all", "全选"))
            {
                if (SelctNodes != null && SelctNodes.Nodes.Count > 0)
                {
                    for (int i = 0; i < SelctNodes.Nodes.Count; i++)
                    {
                        SortSelectNode newNode = (SortSelectNode)SelctNodes.Nodes[i];

                        newNode.ischeck = false;
                        OnSelectFriend(newNode);
                    }
                }

                //tsAllselct.Text = "取消全选";
            }

        }

        private void tsCnlAllselct_Click(object sender, EventArgs e)
        {
            SelctNodes = tvwColleague.SelectedNode;

            if (SelctNodes != null && SelctNodes.Nodes.Count > 0)
            {
                for (int i = 0; i < SelctNodes.Nodes.Count; i++)
                {
                    //Friend f = (Friend)SelctNodes.Nodes[i].Tag;
                    //int index = mRightAdapter.GetIndexById(f.UserId);
                    //if (index > -1)
                    //{
                    //    rightList.RemoveItem(index);
                    //    mRightAdapter.RemoveData(index);
                    //}
                    SortSelectNode newNode = (SortSelectNode)SelctNodes.Nodes[i];

                    newNode.ischeck = true;
                    OnSelectFriend(newNode);
                }
            }


        }
    }
}



