using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;
using WinFrmTalk.View.list;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserLabel : UserControl
    {
        private List<Control> controlLst = new List<Control>();
        // 标签列表适配器
        private LabelAdapter labelAdapter;
        // 当前选中标签
        private UserLabelItem mSelectItem;

        private bool isLoadData;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnCreate.Text = LanguageXmlUtils.GetValue("btn_create_label", btnCreate.Text);
            lblTitle.Text = LanguageXmlUtils.GetValue("userLabel_title", lblTitle.Text);
        }

        public UserLabel()
        {
            InitializeComponent();
            LoadLanguageText();

            labelAdapter = new LabelAdapter();
            // labelAdapter.UserLabel = this;

            // 更新标签页
            Messenger.Default.Register<string>(this, MessageActions.UPDATE_LABLE_LIST, (str) =>
            {
                isLoadData = false;
                controlLst.Clear();
                tabpal.Controls.Clear();
                mSelectItem = null;
            });


            Messenger.Default.Register<Friend>(this, MessageActions.UPDATE_FRIEND_REMARKS, (str) =>
            {
                isLoadData = false;
            });

            // 删除好友 禅道#8160
            Messenger.Default.Register<Friend>(this, MessageActions.DELETE_FRIEND, (str) =>
            {
                FriendLabelDao.Instance.UpdateLableByHttp(() =>
                {
                    controlLst.Clear();
                    tabpal.Controls.Clear();
                });

            });

            // 被拉黑 禅道#8160
            Messenger.Default.Register<Friend>(this, MessageActions.ADD_BLACKLIST, (str) =>
            {
                DataLoad(false);

            });
        }

        // 主窗口切换到标签的事件
        public void DataLableLoad()
        {
            if (!isLoadData)
            {
                DataLoad();
            }
        }

        // 标签数据加载
        private void DataLoad(bool showload = true)
        {
            LodingUtils loding = null;

            if (showload)
            {
                loding = new LodingUtils();
                loding.parent = pnlLabel;
                loding.start();
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/list")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        isLoadData = true;
                        JArray array = JArray.Parse(UIUtils.DecodeString(data, "data"));
                        List<FriendLabel> flabellst = new List<FriendLabel>();
                        foreach (var item in array)
                        {
                            FriendLabel friendLabel = new FriendLabel();
                            friendLabel.groupId = UIUtils.DecodeString(item, "groupId");
                            friendLabel.groupName = UIUtils.DecodeString(item, "groupName");
                            friendLabel.userIdList = UIUtils.DecodeString(item, "userIdList");
                            friendLabel.userId = UIUtils.DecodeString(item, "userId");

                            flabellst.Add(friendLabel);
                        }

                        FriendLabelDao.Instance.DeleteAllLabel();
                        FriendLabelDao.Instance.AddFriendLabels(flabellst);
                        labelAdapter.BindDatas(flabellst);
                        pnlLabel.SetAdapter(labelAdapter);
                    }

                    if (loding != null)
                    {
                        loding.stop();
                    }

                });
        }
        private void AdddataTopal(List<Friend> memberlsts)
        {
            controlLst.Clear();
            tabpal.Controls.Clear();

            int k = 0;// k = 0;

            for (int i = 0; i < memberlsts.Count; i++)
            {

                USEpicAddName uSEpicAddName = new USEpicAddName();
                uSEpicAddName.pics.Size = new Size(55, 55);
                uSEpicAddName.Size = new Size(70, 90);
                uSEpicAddName.LabelFont = new Font(Applicate.SetFont, 8F);
                // uSEpicAddName.Tag = memberlsts[i].role;
                uSEpicAddName.NickName = memberlsts[i].NickName;
                uSEpicAddName.Userid = memberlsts[i].UserId;
                //ImageLoader.Instance.DisplayAvatar(memberlsts[i].UserId, uSEpicAddName.pics);
                ImageLoader.Instance.DisplayAvatar(memberlsts[i].UserId, memberlsts[i].NickName, uSEpicAddName.pics);
                // 放置群成员头像
                uSEpicAddName.Margin = new Padding(0, 0, 0, 2);

                uSEpicAddName.pics.Click -= uSEpicAddName.pics_Click;
                // uSEpicAddName.pics.MouseHover += uSEpicAddName.pics_MouseHover;
                controlLst.Add(uSEpicAddName);
                tabpal.Controls.Add(controlLst[k]);
                k++;


            }

        }

        private void Pics_Click(object sender, EventArgs e)
        {
            // 双击开始聊天
            PictureBox item = (PictureBox)sender;
            USEpicAddName uSEpicAddName = (USEpicAddName)item.Parent;
            Friend friend = new Friend { UserId = uSEpicAddName.Userid }.GetByUserId();
            if (friend.Status != Friend.STATUS_BLACKLIST && friend.Status != Friend.STATUS_18 && friend.Status != Friend.STATUS_19)
            {
                Messenger.Default.Send(friend, FrmMain.START_NEW_CHAT);//通知各页面收到消息
            }
            else
            {
                HttpUtils.Instance.ShowTip("黑名单状态不能发送消息");
            }
        }

        // 绑定右键菜单
        public void BindContextMenu(UserLabelItem item)
        {
            var addfriend = new MenuItem() { Text = LanguageXmlUtils.GetValue("label_add_member", "添加成员") };
            var updatename = new MenuItem { Text = LanguageXmlUtils.GetValue("label_edit_name", "修改名称") };
            var delleble = new MenuItem { Text = LanguageXmlUtils.GetValue("label_delete", "删除标签") };
            var alldel = new MenuItem { Text = LanguageXmlUtils.GetValue("label_batch_delete", "批量删除") };

            addfriend.Click += OnAddLableFriend;
            updatename.Click += OnUpdateLableName;
            delleble.Click += OnDeleteLable;
            alldel.Click += OnBatchDelete;

            //设置右键菜单
            var menuList = new ContextMenu();
            menuList.MenuItems.Add(addfriend);
            menuList.MenuItems.Add(updatename);
            menuList.MenuItems.Add(delleble);
            menuList.MenuItems.Add(alldel);
            item.ContextMenu = menuList;
        }

        #region 标签右键菜单事件

        // 创建标签
        public void OnCreateLable(object sender, EventArgs eve)
        {
            btnCreate.Enabled = false;

            if (Applicate.GetWindow<FrmMyColleagueEidt>() != null)
            {
                Applicate.GetWindow<FrmMyColleagueEidt>().Activate();
                Applicate.GetWindow<FrmMain>().ShowTip("窗口已打开");
                btnCreate.Enabled = true;
                return;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.FormClosed += Frm_FormClosed;
            frm.ColleagueName((groupName) =>
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/add")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("groupName", groupName)
                    .Build().Execute((suss, jsonData) =>
                    {

                        frm.Close();
                        frm.Dispose();

                        if (suss)
                        {
                            FriendLabel newLabel = new FriendLabel(jsonData);

                            // 更新本地
                            FriendLabelDao.Instance.AddFriendLabel(newLabel);

                            // 刷新本地标签列表
                            var flabelist = FriendLabelDao.Instance.GetAllFriendLabel();
                            labelAdapter.BindDatas(flabelist);
                            pnlLabel.SetAdapter(labelAdapter);

                            // 打开好友选择器
                            FrmSortSelect select = new FrmSortSelect();
                            select.TopMost = true;//(如果加上这句代码，在好友选择器界面输入回车，会导致界面卡死，而且还不能关闭)
                            select.LoadFriendsData(false, true, false, false, false);
                            select.Focus();
                            select.Show();
                            select.FormClosed += Select_FormClosed;
                            //快速点击多次确定会创建多个标签
                            select.AddConfrmListener((disc) =>
                            {
                                string listUserID = String.Empty;
                                foreach (var friend in disc.Values)
                                {
                                    listUserID += friend.UserId + ",";
                                }
                                if (listUserID.Length > 0)
                                {
                                    listUserID = listUserID.Remove(listUserID.Length - 1, 1);
                                }

                                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                                    .AddParams("access_token", Applicate.Access_Token)
                                    .AddParams("groupId", newLabel.groupId)
                                    .AddParams("userIdListStr", listUserID)
                                    .Build().Execute((susee, datalist) =>
                                    {
                                        btnCreate.Enabled = true;

                                        if (susee)
                                        {
                                            string ids = "[" + listUserID + "]";
                                            // 更新本地
                                            FriendLabelDao.Instance.UpdateFriendIdListById(newLabel.groupId, ids);

                                            // 刷新本地标签列表
                                            flabelist = FriendLabelDao.Instance.GetAllFriendLabel();
                                            labelAdapter.BindDatas(flabelist);
                                            pnlLabel.SetAdapter(labelAdapter);

                                            // 刷新好友列表
                                            //newLabel.userIdList = ids;
                                            var friendList = newLabel.GetFriendList();
                                            //labelFrienfInfoAdapter.BindDatas(friendList);
                                            //pnlFriend.SetAdapter(labelFrienfInfoAdapter);
                                            AdddataTopal(friendList);

                                            HttpUtils.Instance.ShowTip("创建成功");
                                        }
                                    });
                            });
                        }
                        else
                        {
                            btnCreate.Enabled = true;
                            return;
                        }

                    });
            });

            string title = LanguageXmlUtils.GetValue("title_create_label", "创建标签");
            string name = LanguageXmlUtils.GetValue("name_label_name", "标签名称", true);
            frm.ShowThis(title, name);
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnCreate.Enabled = true;
        }

        // 修改标签名称
        public void OnUpdateLableName(object sender, EventArgs e)
        {
            if (Applicate.GetWindow<FrmMyColleagueEidt>() != null)
            {
                Applicate.GetWindow<FrmMain>().ShowTip("窗口已打开");
                return;
            }

            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            frm.NameEdit = mSelectItem.FriendLabel.groupName;

            frm.ColleagueName((labelName) =>
            {
                labelName = labelName.TrimStart().Trim();

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("groupId", mSelectItem.FriendLabel.groupId)
                    .AddParams("groupName", labelName)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            FriendLabelDao.Instance.UpdateLabelNameById(mSelectItem.FriendLabel.groupId, labelName);

                            string[] names = new string[2];
                            names = mSelectItem.lblName.Text.Split('(');
                            mSelectItem.lblName.Text = labelName + "(" + names[1];

                            mSelectItem.FriendLabel.groupName = labelName;
                            frm.Close();
                            HttpUtils.Instance.PopView(frm);
                            HttpUtils.Instance.ShowTip("修改成功");
                        }
                    });

            });

            string title = LanguageXmlUtils.GetValue("title_modify_label", "修改标签");
            string name = LanguageXmlUtils.GetValue("name_label_name", "标签名称", true);
            frm.ShowThis(title, name);
        }

        // 删除标签
        public void OnDeleteLable(object sender, EventArgs e)
        {
            string groupId = mSelectItem.FriendLabel.groupId;

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/delete")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("groupId", groupId)
                .Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        HttpUtils.Instance.ShowTip("删除标签成功");

                        // 更新本地
                        FriendLabelDao.Instance.DeleteLabelById(groupId);

                        // 清空好友列表
                        controlLst.Clear();
                        tabpal.Controls.Clear();

                        // 刷新标签列表
                        var flabelist = FriendLabelDao.Instance.GetAllFriendLabel();
                        labelAdapter.BindDatas(flabelist);
                        pnlLabel.SetAdapter(labelAdapter);

                    }
                });
        }

        // 在标签下添加成员
        public void OnAddLableFriend(object sender, EventArgs e)
        {
            // 需要排除现有的数据
            List<RoomMember> excludes = GetRoomMemberList(mSelectItem.FriendLabel.userIdList);

            FrmFriendSelect frm = new FrmFriendSelect();
            frm.LoadFriendsData(excludes, false);
            frm.AddConfrmListener((listFriend) =>
            {
                if (listFriend == null || listFriend.Count == 0)
                {
                    return;
                }
                //List<Friend> addfriend = new List<Friend>(); 
                string listUserID = string.Empty;
                foreach (var friend in listFriend.Values)
                {
                    //addfriend.Add(friend);
                    listUserID += friend.UserId + ",";
                }
                foreach (var item in excludes)
                {
                    listUserID += item.userId + ",";
                }

                listUserID = listUserID.Remove(listUserID.Length - 1, 1);


                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("groupId", mSelectItem.FriendLabel.groupId)
                    .AddParams("userIdListStr", listUserID)
                    .Build().Execute((susee, datalist) =>
                    {
                        if (susee)
                        {
                            FriendLabel label = mSelectItem.FriendLabel;
                            label.userIdList = "[" + listUserID + "]";

                            // 更新本地
                            FriendLabelDao.Instance.UpdateFriendIdListById(label.groupId, label.userIdList);

                            // 刷新标签项
                            mSelectItem.FriendLabel = label;

                            // 刷新好友列表
                            List<Friend> friendList = label.GetFriendList();
                            AdddataTopal(friendList);
                            //labelFrienfInfoAdapter.BindDatas(friendList);
                            //pnlFriend.SetAdapter(labelFrienfInfoAdapter);

                            HttpUtils.Instance.ShowTip("添加成功");
                        }
                    });
            });
        }

        // 删除标签下的好友
        public void OnDeleteLableFriend(Friend friend)
        {
            string Useridstr = String.Empty;

            List<Friend> data = mSelectItem.FriendLabel.GetFriendList();

            foreach (var item in data)
            {
                if (!friend.UserId.Equals(item.UserId))
                {
                    Useridstr += item.UserId + ",";
                }
            }

            if (!string.IsNullOrEmpty(Useridstr))
            {
                Useridstr = Useridstr.Remove(Useridstr.Length - 1, 1);
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("groupId", mSelectItem.FriendLabel.groupId)
                .AddParams("userIdListStr", Useridstr)
                .Build().Execute((suss1, data1) =>
                {
                    if (suss1)
                    {
                        FriendLabel label = mSelectItem.FriendLabel;
                        label.userIdList = "[" + Useridstr + "]";

                        // 更新本地
                        FriendLabelDao.Instance.UpdateFriendIdListById(label.groupId, label.userIdList);

                        // 刷新标签项
                        mSelectItem.FriendLabel = label;

                        // 刷新好友列表
                        List<Friend> friendList = label.GetFriendList();
                        AdddataTopal(friendList);
                        //labelFrienfInfoAdapter.BindDatas(friendList);
                        //pnlFriend.SetAdapter(labelFrienfInfoAdapter);

                        HttpUtils.Instance.ShowTip("删除成功");
                    }
                });
        }

        // 批量删除标签下的好友
        public void OnBatchDelete(object sender, EventArgs e)
        {
            List<Friend> friendList = mSelectItem.FriendLabel.GetFriendList();

            if (UIUtils.IsNull(friendList))
            {
                HttpUtils.Instance.ShowTip("没有可以批量删除的好友");
                return;
            }


            FrmFriendSelect frm = new FrmFriendSelect();

            frm.LoadFriendsData(friendList);

            frm.AddConfrmListener((disFriend) =>
            {
                if (disFriend == null || disFriend.Count == 0)
                {
                    return;
                }

                string userstr = string.Empty;

                for (int i = friendList.Count - 1; i >= 0; i--)
                {
                    if (disFriend.ContainsKey(friendList[i].UserId))
                    {
                        friendList.RemoveAt(i);
                        continue;
                    }

                    userstr += friendList[i].UserId + ",";
                }

                if (friendList.Count > 0)
                {
                    userstr = userstr.Remove(userstr.Length - 1, 1);
                    Console.WriteLine(userstr);
                }

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/updateGroupUserList")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("groupId", mSelectItem.FriendLabel.groupId)
                    .AddParams("userIdListStr", userstr)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            HttpUtils.Instance.ShowTip("批量删除成功");
                            FriendLabel label = mSelectItem.FriendLabel;
                            label.userIdList = "[" + userstr + "]";

                            // 更新本地
                            FriendLabelDao.Instance.UpdateFriendIdListById(label.groupId, label.userIdList);

                            // 刷新标签项
                            mSelectItem.FriendLabel = label;

                            // 刷新好友列表
                            AdddataTopal(friendList);
                            //labelFrienfInfoAdapter.BindDatas(friendList);
                            //pnlFriend.SetAdapter(labelFrienfInfoAdapter);
                        }
                    });
            });
        }

        #endregion


        private void Select_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnCreate.Enabled = true;
        }

        // 标签点击事件
        public void OnMouseDownLable(object sender, MouseEventArgs e)
        {
            UserLabelItem item = (UserLabelItem)sender;

            // 右键判断是否可以批量删除
            if (e.Button == MouseButtons.Right)
            {

                int count = item.FriendLabel.GetFriendCount();
                if (count == 0)
                {
                    //item.ContextMenu.GetContextMenu().FindMenuItem();
                }
                mSelectItem = item;
                return;
            }

            if (item == mSelectItem)
            {
                return;
            }

            mSelectItem = item;
            List<Friend> friendlst = item.FriendLabel.GetFriendList();
            AdddataTopal(friendlst);
            //labelFrienfInfoAdapter.BindDatas(friendlst);
            //pnlFriend.SetAdapter(labelFrienfInfoAdapter);
        }

        // 好友列表的双击事件
        public void OnStartChat(object sender, EventArgs eve)
        {
            // 双击开始聊天
            FriendItem item = (FriendItem)sender;

            var friend = item.FriendData.GetByUserId();
            if (friend.Status != Friend.STATUS_BLACKLIST && friend.Status != Friend.STATUS_18 && friend.Status != Friend.STATUS_19)
            {
                Messenger.Default.Send(friend, FrmMain.START_NEW_CHAT);//通知各页面收到消息
            }
            else
            {
                HttpUtils.Instance.ShowTip("黑名单状态不能发送消息");
            }
        }

        /// <summary>
        /// 获取需要剔出的好友
        /// </summary>
        /// <returns></returns>
        public List<RoomMember> GetRoomMemberList(string userIdList)
        {
            if (userIdList == null || userIdList.Length < 2)
            {
                return null;
            }

            JArray array = JArray.Parse(userIdList);

            List<RoomMember> friendlst = new List<RoomMember>();
            for (int i = 0; i < array.Count; i++)
            {
                string userid = array[i].ToString();
                RoomMember friend = new RoomMember() { userId = userid };
                friendlst.Add(friend);
            }

            return friendlst;
        }
    }
}
