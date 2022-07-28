using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.Groups;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    /// <summary>
    /// 群主页
    /// </summary>
    public partial class UseGroupInfo2 : UserControl
    {
        private Friend mFriend;


        public string UserId
        {
            get
            {
                if (mFriend == null)
                {
                    return "";
                }

                return mFriend.UserId;
            }
        }

        public Action<Friend> SendAction { get; internal set; }

        public UseGroupInfo2()
        {
            InitializeComponent();
            this.useGroupInfo1.SendAction = (f) =>
            {
                if (f.GroupType == 2)
                {
                    // 官群
                    ShowGroupFunc(f);
                }
                else
                {

                    SendAction?.Invoke(f);
                }

            };
            this.Load += LeftlayoutItem_Load;
        }


        private void LeftlayoutItem_Load(object sender, EventArgs e)
        {
            this.rightLayout.ChangeGroupFunc += Layout_ChangeGroupFunc;
        }


        public void Layout_ChangeGroupFunc(GroupTabIndex tabIndex)
        {
            groupPageMain1.Visible = tabIndex == GroupTabIndex.main;
            groupPageFunc1.Visible = tabIndex != GroupTabIndex.main;
            groupPageFunc1.SwitchGroupPage(tabIndex);
        }

        public void SetDataContent(Friend friend)
        {
            this.mFriend = friend;
            this.jumpFrom = null;
            if (friend == null || friend.UserId == "")
            {
                return;
            }

            HttpLoadData(mFriend.RoomId, friend.NickName);
        }

        private Friend jumpFrom { get; set; }

        private bool fromChat { get; set; }
        private bool isMember { get; set; }

        public void JumpMainGroup(Friend friend, bool fromChat = true)
        {
            var mainRoom = friend.OfficialGroupId;
            // 保存跳转数据,便于返回
            this.fromChat = fromChat;
            this.isMember = friend.Role != "-1";
            this.jumpFrom = friend.Clone();

            HttpLoadData(mainRoom, friend.NickName);
        }

        private void JumpLogical(Friend friend)
        {
            // 官群
            if (friend.GroupType == 2)
            {
                // 官群
                if (friend.Role == "-1")
                {
                    // 不是群成员 进聊天界面,但是不能聊天
                    ShowGroupFunc(friend);
                }
                else
                {
                    // 是群成员 看群成员列表
                    useGroupInfo1.Visible = true;
                    useGroupInfo1.BringToFront();
                    useGroupInfo1.DisplayGroup(friend);
                }
            }
            else
            {
                // 社群
                if (friend.Role == "-1")
                {
                    // 不是群成员 进聊天界面,但是不能聊天
                    SendAction?.Invoke(friend);
                }
                else
                {
                    // 是群成员 看群成员列表
                    useGroupInfo1.Visible = true;
                    useGroupInfo1.BringToFront();
                    useGroupInfo1.DisplayGroup(friend);
                }
            }
        }

        private void ShowGroupFunc(Friend friend)
        {
            // 官群
            useGroupInfo1.Visible = false;
            groupPageFunc1.BindRoomData(friend);

            rightLayout.SwitchGroupPage(GroupTabIndex.main, friend);
            Layout_ChangeGroupFunc(GroupTabIndex.main);

            if (mFriend.GroupType == 2)
            {
                tvName.Text = friend.NickName;
                panel1.Location = new Point(tvName.Width + 52, panel1.Location.Y);
            }

            HttpLoadData1();
        }


        private void HttpLoadData(string roomId, string nickName = "")
        {
            string RequestUrl = string.Empty;

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/get")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("roomId", roomId)
                .AddParams("type", "1")
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "10")
                .Build().ExecuteJson<DownRoom>((sccess, data) =>
                {
                    if (sccess)
                    {
                        mFriend = data.ToRoom(true);

                        if (mFriend.GroupType == 2 && nickName != null)
                        {
                            mFriend.NickName = nickName;
                        }

                        mFriend.isLook = data.watchTime > TimeUtils.CurrentIntTime() ? 1 : -1;

                        if (mFriend.Role == "-1" && mFriend.isLook != 1)
                        {
                            ((FrmBase)this.FindForm()).ShowTip("该官群未开启围观功能");
                            return;
                        }

                        JumpLogical(mFriend);


                    }
                });
        }


        private void HttpLoadData1()
        {
            string RequestUrl = string.Empty;

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/getOfficialGroup")
                .AddParams("control", "1")
                .AddParams("roomId", mFriend.RoomId)
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        var memberSize = UIUtils.DecodeInt(data, "userSize");

                        // 主群 8
                        var mainGroupSize = UIUtils.DecodeInt(data, "mainGroupSize");

                        // 分群 6
                        var branchGroupSize = UIUtils.DecodeInt(data, "branchGroupSize");

                        // 支群 5
                        var ofGroupSize = UIUtils.DecodeInt(data, "ofGroupSize");

                        // 子群 1
                        var subGroupSize = UIUtils.DecodeInt(data, "subGroupSize");

                        //tvDescsize.Text = string.Format(@"(总群员:{0}人 主群/{1} 分群/{2} 支群/{3} 子群/{4})",
                        //    memberSize, mainGroupSize, branchGroupSize, ofGroupSize, subGroupSize);

                        //panel1.Location = new Point(tvDescsize.Location.X + tvDescsize.Width + 15, panel1.Location.Y);

                        // 群信息
                        var roomnews = JsonConvert.DeserializeObject<GroupNewsInfo>(UIUtils.DecodeString(data, "news"));
                        groupPageMain1.SetContentData(roomnews, mFriend);

                    }
                });
        }

        internal void ChangeGroupName(string nickName)
        {
            useGroupInfo1.ChangeGroupName(nickName);

            if (mFriend.GroupType == 2)
            {
                mFriend.NickName = nickName;
                tvName.Text = nickName;
                panel1.Location = new Point(tvName.Width + 52, panel1.Location.Y);

            }
        }

        private void Descsize_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }


        private void btnMainPage_MouseEnter(object sender, EventArgs e)
        {
            lab_detial.BackColor = Color.FromArgb(220, 220, 220);//悬浮颜色
        }

        private void btnMainPage_MouseLeave(object sender, EventArgs e)
        {
            lab_detial.BackColor = Color.Transparent;//悬浮颜色
        }

        private void lab_detial_MouseClick(object sender, MouseEventArgs e)
        {
            //如果聊天对象为群组
            var frmSet = new FrmSMPGroupSet() { room = mFriend };

            //获取三个点控件相对屏幕的位置
            Point point = PointToScreen(groupPageMain1.Location);
            point = new Point(point.X + (this.Width - frmSet.Width - 1), point.Y);

            frmSet.StartPosition = FormStartPosition.Manual;
            frmSet.Location = point;
            frmSet.Height = groupPageMain1.Height;
            frmSet.Show();
        }

        /// <summary>
        /// 打开组织结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupOrganiz_Click(object sender, EventArgs e)
        {
            //如果聊天对象为群组
            var frmSet = new FrmGroupOrganizTree() { mFriend = mFriend };

            //获取三个点控件相对屏幕的位置
            Point point = PointToScreen(groupPageMain1.Location);
            point = new Point(point.X + (this.Width - frmSet.Width - 1), point.Y);

            frmSet.StartPosition = FormStartPosition.Manual;
            frmSet.Location = point;
            frmSet.Height = groupPageMain1.Height;
            frmSet.Show();
        }

        private void ivLevelSwitch_Click(object sender, EventArgs e)
        {
            // 作为返回
            if (jumpFrom != null)
            {
                if (fromChat && isMember)
                {
                    // 跳回到聊天界面
                    SendAction?.Invoke(jumpFrom);
                }
                else
                {
                    // 本页面跳转
                    SetDataContent(jumpFrom);
                }
            }
            else
            {
                // 主动跳
                if (mFriend.GroupType == 2 || UIUtils.IsNull(mFriend.OfficialGroupId))
                {
                    ((FrmBase)this.FindForm()).ShowTip("没有可以跳转的群组");
                }
                else
                {
                    JumpMainGroup(mFriend, false);
                }
            }
        }

        private void tvDescsize_TextChanged(object sender, EventArgs e)
        {


        }
    }
}