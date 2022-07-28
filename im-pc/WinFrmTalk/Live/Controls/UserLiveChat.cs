using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserLiveChat : UserControl
    {
        #region 变量
        private bool firstLoadRoom = true;
        private bool textboxHasText;
        private bool isLoading;
        public LiveChatAdapter mAdapter;
        public List<MessageObject> messageObjectLst = new List<MessageObject>();//聊天室消息集合
        public List<LiveMember> liveMembers = new List<LiveMember>();//直播室成员集合
        public bool IsLoadRoom = true;//当前界面加载的是聊天还是成员列表（默认聊天）
        public Friend fdSend = new Friend();//
        public LiveCardBean LiveRoomInfo = new LiveCardBean();//直播间的实体类
        public FansInfoAdapter mFansAdapter;
        public int Role = 1;//当前成员的角色
        public int TalkState;//1:取消禁言，0:禁言
        public USEMange SelectItems = new USEMange();//成员列表中当前选中的项
        private USEMange use = new USEMange();
        private USEMange BeforeItem;//上一次选中的项
        public bool CheckBarrage = false;
        private LodingUtils loding;//等待符
        #endregion
        public UserLiveChat()
        {
            InitializeComponent();
            mAdapter = new LiveChatAdapter();
            mFansAdapter = new FansInfoAdapter();
            ChatList.SetAdapter(mAdapter);
        }
        /// <summary>
        /// 等待符
        /// </summary>
        /// <param name="control"></param>
        private void ShowLodingDialog(Control control)
        {
            loding = new LodingUtils { };


            loding.parent = control;
            loding.Title = "加载中";
            loding.start();
        }
        private void UserLiveChat_Load(object sender, EventArgs e)
        {

            mFansAdapter.SetMaengForm(this);
            FansLst.FooterRefresh += LoadNextPageMenber;

        }

        #region 聊天室的数据插入
        /// <summary>
        ///发送文字（插入数据）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JudgeMsgIsAddToPanel(MessageObject txt_msg)
        {
            if (txt_msg.content.Length > 300)
            {
                txt_msg.content = txt_msg.content.TrimEnd().Substring(0, 300);
            }
            int count = mAdapter.GetItemCount();
            mAdapter.InsertData(count, txt_msg);
            ChatList.InsertItem(count);
            ChatList.ShowRangeEnd(count, 0, true);
            //if(count>30)
            //{
            //    ChatList.DeleteRange(0, 15);
            //    for (int i = 15; i > 0; i--)
            //    {
            //        mAdapter.RemoveData(i);
            //    }
            //    //ChatList.DeleteRange(0, 15);
            //}

        }
        #endregion
        public bool isupdate = true;
        #region 成员列表的增加、删除、设置权限
        /// <summary>
        /// 添加成员到列表中
        /// </summary>
        /// <param name="msg"></param>
        public void AddFans(MessageObject msg)
        {
            LiveMember member = new LiveMember();
            member.userId = Convert.ToInt32(msg.toUserId);
            member.nickName = msg.toUserName;
            member.type = 3;
            member.state = 0;//新加入的好友的禁言状态跟当前账号是没有关系的，默认不禁言状态
            liveMembers.Add(member);
            FansLst.InsertItem(liveMembers.Count);
        }
        /// <summary>
        /// 移除成员
        /// </summary>
        /// <param name="msg"></param>
        public void DelFans(MessageObject msg)
        {
            int index = mFansAdapter.GetIndexByFansId(msg.toUserId);
            if (index > -1)
            {

                //判断是否被创建
                if (FansLst.DataCreated(index))
                {
                    use = FansLst.GetItemControl(index) as USEMange;
                    use.lblName.Text = msg.content;//刷新ui
                }
                else
                {
                    // mFansAdapter.GetDatas(index).GroupName = msg.content;//更新数据源
                }
            }
        }


        /// <summary>
        /// 设置管理员
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="role"></param>
        public void SetAdmin(MessageObject msg, string role)
        {
            int i = mFansAdapter.GetIndexByFansId(msg.toUserId);
            if (i > -1)
            {

                //判断是否被创建
                if (FansLst.DataCreated(i))
                {
                    use = FansLst.GetItemControl(i) as USEMange;
                    if (role.Equals("0"))
                    {
                        use.lblName.Text = "观众";
                        ((LiveMember)use.Tag).type = 3;//刷新ui
                    }
                    else
                    {
                        use.lblName.Text = "管理员";
                        ((LiveMember)use.Tag).type = 2;//刷新ui
                    }
                }
                else
                {
                    if (role.Equals("0"))
                    {
                        mFansAdapter.GetDatas(i).type = 3;//更新数据源
                    }
                    else
                    {
                        mFansAdapter.GetDatas(i).type = 2;//更新数据源
                    }
                }
            }
        }
        /// <summary>
        /// 设置禁言
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="state"></param>
        public void SetTalk(MessageObject msg, string state)
        {
            int i = mFansAdapter.GetIndexByFansId(msg.toUserId);
            if (i > -1)
            {

                //判断是否被创建
                if (FansLst.DataCreated(i))
                {
                    use = FansLst.GetItemControl(i) as USEMange;
                    if (state.Equals("0"))
                    {

                        ((LiveMember)use.Tag).state = 1;//刷新ui
                    }
                    else
                    {

                        ((LiveMember)use.Tag).state = 0;//刷新ui
                    }
                }
                else
                {
                    if (state.Equals("0"))
                    {
                        mFansAdapter.GetDatas(i).state = 1;//更新数据源
                    }
                    else
                    {
                        mFansAdapter.GetDatas(i).state = 0;//更新数据源
                    }
                }
            }
        }
        #endregion
        #region 成员列表和聊天室切换
        public bool flag = true;//记录查询状态
        /// <summary>
        /// 成员列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFansinfo_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            if (IsLoadRoom)
            {
                btnliveinfo.BackColor = Color.White;
                btnliveinfo.ForeColor = Color.Black;
                btnFansinfo.BackColor = Color.FromArgb(10, 209, 5);
                btnFansinfo.ForeColor = Color.White;
            }
            FansLst.Visible = true;
            ChatList.Visible = false;
            txtSend.Visible = false;
            btntext.Visible = false;
            label1.Visible = false;
            lblNext.Visible = false;
            IsLoadRoom = false;
            if (flag)
            {
                isupdate = true;
                flag = false;

                // ShowLodingDialog(FansLst);
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(600);
                    GetRoomLst(LiveRoomInfo.roomId);
                });

            }



            isLoading = false;

        }

        #region 获取成员列表
        /// <summary>
        /// 获取直播列表
        /// </summary>
        /// <param name="Rooid"></param>
        public void GetRoomLst(string Rooid)
        {
            //http get请求获得数据
            if (isupdate)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/memberList")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", Rooid)
                 .AddParams("pageIndex", pageIndex.ToString())
                .AddParams("pageSize", "10")
                .Build()
                .Execute((success, result) =>
                {
                    //loding.stop();
                    if (success)
                    {
                        if (pageIndex == 0)
                        {
                            liveMembers.Clear();
                            FansLst.ClearList();
                        }

                        string list = UIUtils.DecodeString(result, "data");
                        List<LiveMember> liveMemberLst = JsonConvert.DeserializeObject<List<LiveMember>>(list);

                        if (UIUtils.IsNull(liveMemberLst))
                        {
                            isLoading = false;
                            mFansAdapter.BindDatas(null);
                            FansLst.ClearList();
                            return;
                        }

                        for (int i = 0; i < liveMemberLst.Count - 1; i++)
                        {
                            for (int j = 0; j < liveMemberLst.Count - 1 - i; j++)
                            {
                                if (liveMemberLst[j].type > liveMemberLst[j + 1].type)
                                {
                                    var temp = liveMemberLst[j];
                                    liveMemberLst[j] = liveMemberLst[j + 1];
                                    liveMemberLst[j + 1] = temp;
                                }
                            }
                        }

                        liveMembers.AddRange(liveMemberLst);
                        FansLst.SuspendLayout();
                        mFansAdapter.BindDatas(liveMembers);
                        FansLst.SetAdapter(mFansAdapter);
                        FansLst.ShowRangeStart(pageIndex * 10, 0, true);
                        FansLst.ResumeLayout();
                        //if (!IsLoadRoom)// && FansLst.IsHandleCreated)//无用
                        //{

                        //}

                        if (liveMemberLst.Count < 10)
                        {
                            isLoading = false;
                            isupdate = false;
                            flag = true;
                        }
                        else
                        {
                            isLoading = true;
                            isupdate = true;
                        }

                    }
                });
            }
        }
        #endregion

        private void LoadNextPageMenber()
        {
            if (isLoading)
            {  //http get请求获得数据
                ShowLodingDialog(FansLst);
                pageIndex = pageIndex + 1;
                isLoading = false;
                GetRoomLst(LiveRoomInfo.roomId);
            }
        }

        private int pageIndex = 0;


        /// <summary>
        /// 聊天室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnliveinfo_Click(object sender, EventArgs e)
        {
            if (!IsLoadRoom)
            {
                btnFansinfo.BackColor = Color.White;
                btnFansinfo.ForeColor = Color.Black;
                btnliveinfo.BackColor = Color.FromArgb(26, 181, 26);
                btnliveinfo.ForeColor = Color.White;
            }
            if (loding != null)
            {
                loding.stop();
            }


            FansLst.Visible = false;
            ChatList.Visible = true;
            txtSend.Visible = true;
            btntext.Visible = true;
            label1.Visible = true;
            lblNext.Visible = true;
            IsLoadRoom = true;
        }
        #endregion
        #region 鼠标事件
        public void Use_MouseLeave(object sender, EventArgs e)
        {
            USEMange usemange = (USEMange)sender;
            // use.BackColor = Color.Transparent;
            if (!usemange.IsSelected)
            {
                usemange.BackColor = Color.Transparent;

            }
        }
        /// <summary>
        /// 鼠标悬停事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void USEMange_MouseEnter(object sender, EventArgs e)
        {
            USEMange usemange = (USEMange)sender;

            if (!usemange.IsSelected)
            {
                if (use != null)
                {
                    use.BackColor = Color.Transparent;
                }
                usemange.BackColor = ColorTranslator.FromHtml("#D8D8D9");//悬浮颜色
                use = usemange;
            }
        }
        #endregion
        #region 右键事件
        /// <summary>
        /// 鼠标右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void USEGrouops_MouseDown(object sender, MouseEventArgs e)
        {
            USEMange uSEMange = (USEMange)sender;

            if (BeforeItem != null)
            {
                BeforeItem.IsSelected = false;
            }
            if (e.Button == MouseButtons.Right)
            {

                uSEMange.ContextMenuStrip = menuDel;


                uSEMange.IsSelected = true;
                SelectItems = uSEMange;

                BeforeItem = uSEMange;



                //1.群主,管理员不能被禁言
                //2.管理员不能对自己指定管理员
                //3.管理员可以被取消
                //4.取消禁言
                //群主被取消之后就是普通成员
                if (Role == 1)//当前是群主
                {

                    if (((LiveMember)SelectItems.Tag).type == 1)
                    {
                        uSEMange.ContextMenuStrip = null;

                    }

                    else
                    {
                        MenuItemexite.Visible = true;
                        MenuItemSetAdmin.Visible = true;
                        MenuItemUnTalk.Visible = true;
                        if (((LiveMember)SelectItems.Tag).type == 2)
                        {
                            MenuItemSetAdmin.Text = "取消管理员";
                        }

                        else
                        {
                            MenuItemSetAdmin.Text = "指定管理员";
                        }
                        if (((LiveMember)SelectItems.Tag).state == 0)
                        {
                            MenuItemUnTalk.Text = "禁言";
                        }
                        else
                        {
                            MenuItemUnTalk.Text = "取消禁言";
                        }
                    }

                }
                else if (Role == 2)
                {
                    if (((LiveMember)SelectItems.Tag).type == 1)
                    {
                        uSEMange.ContextMenuStrip = null;
                    }
                    else if (((LiveMember)SelectItems.Tag).type == 2)
                    {
                        MenuItemSetAdmin.Visible = false;
                        MenuItemUnTalk.Visible = false;
                        MenuItemexite.Visible = false;
                    }
                    else
                    {
                        MenuItemSetAdmin.Visible = false;
                        MenuItemUnTalk.Visible = true;
                        MenuItemexite.Visible = true;

                        if (((LiveMember)SelectItems.Tag).state == 0)
                        {
                            MenuItemUnTalk.Text = "禁言";
                        }
                        else
                        {
                            MenuItemUnTalk.Text = "取消禁言";
                        }
                    }

                }
                else
                {
                    uSEMange.ContextMenuStrip = null;
                }

            }
            if (e.Button == MouseButtons.Left)
            {


            }

        }
        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemUnTalk_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 踢人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemexite_Click(object sender, EventArgs e)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/kick")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", LiveRoomInfo.roomId)
                 .AddParams("userId", ((LiveMember)SelectItems.Tag).userId.ToString())
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {
                        for (int i = 0; i < liveMembers.Count; i++)
                        {
                            if (liveMembers[i].userId == ((LiveMember)SelectItems.Tag).userId)
                            {
                                FansLst.RemoveItem(i);

                                //   member.Remove(member[i]);
                                liveMembers.Remove(liveMembers[i]);
                                break;
                            }
                        }
                    }
                });
        }
        /// <summary>
        /// 设置取消管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSetAdmin_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            string type = "0";
            string menultemtext = toolStripMenuItem.Text;
            //刷新当前的角色
            if (toolStripMenuItem.Text == "指定管理员")
            {
                toolStripMenuItem.Text = "取消管理员";
                ((LiveMember)SelectItems.Tag).type = 2;
                type = "2";
            }
            else if (toolStripMenuItem.Text == "取消管理员")
            {
                toolStripMenuItem.Text = "指定管理员";
                ((LiveMember)SelectItems.Tag).type = 3;
                type = "3";
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/setmanage")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", LiveRoomInfo.roomId)
                 .AddParams("userId", ((LiveMember)SelectItems.Tag).userId.ToString())
                 .AddParams("type", type)
                .Build()
                .Execute((success, result) =>
                {
                    if (success)
                    {

                    }
                });
        }
        #endregion


        private void MenuItemChat_Click(object sender, EventArgs e)
        {
            CheckBarrage = false;
            btntext.Text = "发送";
            txtSend.Text = "";
            if (TalkState == 0)
            {
                txtSend.Enabled = true;
                btntext.Enabled = true;
            }
            else
            {
                txtSend.Enabled = false;
                btntext.Enabled = false;
            }

        }

        private void MenuItemB_Click(object sender, EventArgs e)
        {
            CheckBarrage = true;
            btntext.Text = "弹幕";
            textboxHasText = false;
            txtSend.Text = "开启大喇叭，1钻石/条";
            txtSend.ForeColor = Color.LightGray;
            textBox1.Focus();
            txtSend.Enabled = true;
            btntext.Enabled = true;
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            CmsChat.Show(btntext, 0, btntext.Height);
        }
        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemTalkTime_Click(object sender, EventArgs e)
        {
            int state = 0;//1为禁言0为取消
            ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
            string tag = menuitem.Tag.ToString();
            double SettalkTime = 0;//设置禁言时间
            int daysends = 24 * 60 * 60;
            switch (tag)
            {
                case "1":
                    SettalkTime = 0;//不禁言
                    state = 0;
                    break;
                case "2":
                    SettalkTime = daysends / 48;//禁言30分钟
                    state = 1;
                    break;
                case "3":
                    SettalkTime = daysends / 24;//禁言1小时
                    state = 1;
                    break;
                case "4":
                    SettalkTime = daysends;//禁言1天
                    state = 1;
                    break;
                case "5":
                    SettalkTime = daysends * 3;//禁言3天
                    state = 1;
                    break;

            }

            //禁言结束的时间
            long talkTime = Convert.ToInt64(TimeUtils.CurrentTimeDouble() + SettalkTime);
            //   ShowLodingDialog(palMember);//显示等待符

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/shutup")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("roomId", LiveRoomInfo.roomId)
               .AddParams("userId", ((LiveMember)SelectItems.Tag).userId.ToString())
               .AddParams("state", state.ToString())
               .AddParams("talkTime", talkTime.ToString())
               .Build()
               .Execute((success, result) =>
               {
                   if (success)
                   {

                   }
               });



        }

        private void txtSend_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                txtSend.Text = "";

            txtSend.ForeColor = Color.Black;
        }

        private void txtSend_Leave(object sender, EventArgs e)
        {
            if (txtSend.Text == "" && btntext.Text == "弹幕")
            {
                txtSend.Text = "开启大喇叭，1钻石/条";
                txtSend.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textboxHasText = false;
        }
    }
}

