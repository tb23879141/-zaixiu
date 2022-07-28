using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Dictionarys;
using WinFrmTalk.Helper;
using WinFrmTalk.Helper.MVVM;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View;
using WinFrmTalk.View.list;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class GroupCollection : UserControl
    {
        private Friend _Room = new Friend();
        public Friend GroupInfo
        {
            get { return _Room; }
            set { _Room = value; }
        }

        #region 全局变量
        private List<Collections> collectionShowlst = new List<Collections>();// 全部集合
        private List<Collections> collectionlst = new List<Collections>();// 全部集合
        private GroupCollectionAdapter mAdapter;//保存适配
        //MyColleagueAdapter myColleagueAdapter;//我的讲课适配
        public List<MessageObject> ListMessage = new List<MessageObject>();//选中讲课消息集合

        private List<MessageObject> message = new List<MessageObject>();

        // 我的讲课选中项
        private UserCollectionItem mSelectCourse;

        // 我的保存选中项
        private UserCollectionItem CollectionItem;

        private bool isLoadCourseData; // 是否加载过数据了
        public const int minHeight = 50;//最小高度
        public static int BubbleWidth, BubbleHeight;//气泡宽度，气泡高度

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnWhole.Text = LanguageXmlUtils.GetValue("all_collection", btnWhole.Text);
            btnText.Text = LanguageXmlUtils.GetValue("text_collection", btnText.Text);
            btnImg.Text = LanguageXmlUtils.GetValue("image_collection", btnImg.Text);
            btnVideo.Text = LanguageXmlUtils.GetValue("video_collection", btnVideo.Text);
            btnLecture.Text = LanguageXmlUtils.GetValue("my_courseware", btnLecture.Text);
            tsmEdit.Text = LanguageXmlUtils.GetValue("edit_courseware_name", tsmEdit.Text);
            tsmSendLecture.Text = LanguageXmlUtils.GetValue("send_courseware", tsmSendLecture.Text);
            tsmDelete.Text = LanguageXmlUtils.GetValue("delete_courseware", tsmDelete.Text);
            tsmForward.Text = LanguageXmlUtils.GetValue("forward", tsmForward.Text);
            tsmDel.Text = LanguageXmlUtils.GetValue("delete", tsmDel.Text);
        }

        #endregion
        public GroupCollection()
        {
            InitializeComponent();
            LoadLanguageText();
            mAdapter = new GroupCollectionAdapter();//适配绑定（保存）
            //myColleagueAdapter = new MyColleagueAdapter();//适配绑定（我的讲课）
            //myColleagueAdapter.SetMaengForm(this);
            // 更新保存页
            Messenger.Default.Register<string>(this, MessageActions.UPDATE_COLLECT_LIST, (str) =>
            {
                refretime = 0;
            });

            // 更新我的讲课
            Messenger.Default.Register<string>(this, MessageActions.UPDATE_COURSE_LIST, (str) =>
            {
                isLoadCourseData = false;
                if (LanguageXmlUtils.GetValue("my_lecture", "我的课件").Equals(lblTitle.Text))
                {
                    btnLecture_Click(this.btnLecture, null);
                }
            });

            //SearchCollect.tips = "保存文字";
            SearchCollect.tips = LanguageXmlUtils.GetValue("search", "搜索");
            SearchCollect.SearchEvent += SearchMeesageContent;

            //收到了一个批量删除通知
            Messenger.Default.Register<bool>(this, EQFrmInteraction.BatchDeleteCollect, (delStatus) =>
            {
                bool result = HttpUtils.Instance.ShowPromptBox("确认全部删除");
                if (result)
                {
                    foreach (var item in List_Msgs)
                    {
                        HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/delete")
                       .AddParams("access_token", Applicate.Access_Token)
                       .AddParams("emojiId", item.emojiId)
                       .Build().Execute((su, da) =>
                       {
                           //if (su)
                           //{
                           //    int index = mAdapter.GetMessageIdByIndex(CollectionItem.Collections.emojiId);

                           //    WholeData();
                           //    HttpUtils.Instance.ShowTip("删除成功");
                           //}
                       });
                    }
                    WholeData();
                    cc.ClearList();
                    HttpUtils.Instance.ShowTip("删除成功");
                }


            });


            //收到了一个全选通知
            Messenger.Default.Register<bool>(this, EQFrmInteraction.BatchSelectCollect, (chkStatus) =>
            {
                if (chkStatus)
                {
                    foreach (Control item in cc.panel1.Controls)
                        if (item is UserCollectionItem ucItem)
                            foreach (Control chkitem in ucItem.panel.Controls)
                                if (chkitem is CheckBoxEx checkBox)
                                {
                                    checkBox.Checked = true;
                                }

                    this.List_Msgs = collectionShowlst;
                }
                else
                {

                    int i = 0;
                    foreach (Control item in cc.panel1.Controls)
                        if (item is UserCollectionItem ucItem)
                            foreach (Control chkitem in ucItem.panel.Controls)
                                if (chkitem is CheckBoxEx checkBox)
                                {
                                    checkBox.Checked = false;

                                    i++;
                                }

                    this.List_Msgs = new List<Collections>();
                }

                multiSelectPanel.List_Msgs = this.List_Msgs;
            });


            // 图片文件簿双击
            Messenger.Default.Register<string>(this, MessageActions.uimsg_imgfolder_doubleclick, (str) =>
            {
                cc.Visible = false;
                string msgID = str;
                panelImgFolder.Visible = true;
                flowLayoutPanelImgList.Visible = true;
                flowLayoutPanelImgList.Controls.Clear();
                Collections collection = collectionShowlst.Find(x => x.msgId.Equals(msgID));
                labelImgFolderTitle.Text = "< ";
                if (collection != null & collection.Filename != null) labelImgFolderTitle.Text += collection.Filename ?? "";
                if (collection.groupShareList != null)
                    foreach (var item in collection.groupShareList)
                    {
                        UserImgItem UserImgItem = new UserImgItem();
                        ImageLoader.Instance.Load(item.url).NoCache().Into(UserImgItem.lab_icon, UserImgItem.panel_file);
                        //UserImgItem.panel_file.BackgroundImage = UserImgItem.lab_icon.BackgroundImage;
                        UserImgItem.lab_fileName.Text = TimeUtils.FromatTime(item.time, "yyyy-MM-dd");
                        //UserImgItem.lab_fileName.BackColor = Color.Transparent;
                        //UserImgItem.pictureBox_view.BackColor = Color.Transparent;
                        //UserImgItem.lab_fileName.Visible = true;
                        //UserImgItem.pictureBox_view.Visible = true;           
                        flowLayoutPanelImgList.Controls.Add(UserImgItem);
                    }

            });
        }

        public LodingUtils loding;//等待符

        /// <summary>
        /// 显示等待符
        /// </summary>
        /// <param name="control">等待符显示的父控件</param>
        public void ShowLodingDialog(Control control)
        {
            if (loding == null)
            {
                loding = new LodingUtils();
                loding.parent = control;
                loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
                loding.start();
            }
        }



        /// <summary>
        /// 停止等待符
        /// </summary>
        public void HideLodingDialog()
        {
            if (loding != null)
            {
                loding.stop();
                loding = null;
            }
        }
        public Friend group;
        #region 加载全部数据
        public int refretime = 0;
        public void RefreData()
        {
            if (TimeUtils.CurrentIntTime() - refretime > 60)
            {
                refretime = TimeUtils.CurrentIntTime();
                //WholeData();
                //btnVideo_Click(btnVideo, null);

            }
            //getGroupShare();
        }
        //获取群分享资源 1群文件 2群视频
        private void getGroupShare(int filetype = 0)
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getGroupShare";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            List<MyGroupContent> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupContent>>(data["data"].ToString());
                            collectionlst = new List<Collections>() { };

                            //保存类型 1相册 2视频 3文件  4声音 5文本 6gif 7SDKLink ;
                            //群资源类型 1群文件 2群视频
                            foreach (var item in myGroupContentList)
                            {
                                Collections collectItem = new Collections() { };
                                collectItem.msgId = item.shareId;
                                collectItem.Filename = item.url;
                                collectItem.url = item.url;
                                collectItem.msg = item.title;

                                //collectItem.msg = item.text;
                                //collectItem.createTime = item.time;
                                //collectItem.fileSize =0;
                                switch (item.type)
                                {
                                    case 1: collectItem.collectType = 3; collectItem.type = collectItem.collectType.ToString(); break;
                                    case 2: collectItem.collectType = 2; collectItem.type = collectItem.collectType.ToString(); break;
                                }
                                collectionlst.Add(collectItem);
                            }

                            List<Collections> tmpcollectionList = new List<Collections>();
                            for (int i = 0; i < collectionlst.Count; i++)
                            {
                                if (collectionlst[i].type == filetype.ToString())
                                {
                                    tmpcollectionList.Add(collectionlst[i]);
                                }
                            }
                            collectionShowlst = tmpcollectionList;
                            mAdapter.BindDatas(tmpcollectionList);
                            cc.SetAdapter(mAdapter);

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }

        //获取群分享资源 公告
        private void getGroupNotice()
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "room/notice/list";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            List<MyGroupNotice> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupNotice>>(data["data"].ToString());
                            collectionlst = new List<Collections>() { };

                            //保存类型 1相册 2视频 3文件  4声音 5文本 6gif 7SDKLink ;
                            //群资源类型 1群文件 2群视频
                            foreach (var item in myGroupContentList)
                            {
                                Collections collectItem = new Collections() { };
                                collectItem.msgId = item.id;
                                //collectItem.url = item.ur;
                                collectItem.msg = item.title;
                                collectItem.collectContent = item.text;
                                collectItem.nickname = item.nickname;
                                collectItem.createTime = item.time;
                                collectItem.collectType = 11; collectItem.type = collectItem.collectType.ToString();
                                //collectItem.msg = item.text;
                                //collectItem.createTime = item.time;
                                //collectItem.fileSize =0;
                                //switch (item.type)
                                //{
                                //    case 1: collectItem.collectType = 3; collectItem.type = collectItem.collectType.ToString(); break;
                                //    case 2: collectItem.collectType = 2; collectItem.type = collectItem.collectType.ToString(); break;
                                //}
                                collectionlst.Add(collectItem);
                            }

                            //List<Collections> textcollection = new List<Collections>();

                            //for (int i = 0; i < collectionlst.Count; i++)
                            //{
                            //    if (collectionlst[i].type == "5" || collectionlst[i].type == "6" || collectionlst[i].type == "7")
                            //    {
                            //        textcollection.Add(collectionlst[i]);
                            //    }
                            //}
                            collectionShowlst = collectionlst;
                            mAdapter.BindDatas(collectionlst);
                            cc.SetAdapter(mAdapter);

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }

        //获取群分享资源 活动
        private void getGroupActivity()
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getActivityList";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            List<MyGroupActivity> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupActivity>>(data["data"].ToString());
                            collectionlst = new List<Collections>() { };

                            //保存类型 1相册 2视频 3文件  4声音 5文本 6gif 7SDKLink ;
                            //群资源类型 1群文件 2群视频
                            foreach (var item in myGroupContentList)
                            {
                                Collections collectItem = new Collections() { };
                                collectItem.msgId = item.id;
                                collectItem.url = item.webUrl;
                                collectItem.msg = item.title;
                                collectItem.collectContent = item.title;
                                collectItem.collectType = 13; collectItem.type = collectItem.collectType.ToString();

                                collectItem.act_address = item.address;
                                collectItem.act_charge = item.charge;
                                collectItem.act_cover = item.cover;
                                collectItem.act_endTime = item.endTime;
                                collectItem.act_forward = item.forward;
                                collectItem.act_isJoin = item.isJoin;
                                collectItem.act_isMemberDownload = item.isMemberDownload;
                                collectItem.act_isPublic = item.isPublic;
                                collectItem.act_isWatchDownload = item.isWatchDownload;
                                collectItem.act_notice = item.notice;
                                collectItem.act_payee = item.payee;
                                collectItem.act_publishTime = item.publishTime;
                                collectItem.act_rule = item.rule;
                                collectItem.act_signUpBegin = item.signUpBegin;
                                collectItem.act_signUpEnd = item.signUpEnd;
                                collectItem.act_time = item.time;
                                collectItem.act_title = item.title;
                                collectItem.act_type = item.type;
                                collectItem.act_userSize = item.userSize;
                                ;
                                //collectItem.msg = item.text;
                                //collectItem.createTime = item.time;
                                //collectItem.fileSize =0;
                                //switch (item.type)
                                //{
                                //    case 1: collectItem.collectType = 3; collectItem.type = collectItem.collectType.ToString(); break;
                                //    case 2: collectItem.collectType = 2; collectItem.type = collectItem.collectType.ToString(); break;
                                //}
                                collectionlst.Add(collectItem);
                            }

                            //List<Collections> textcollection = new List<Collections>();

                            //for (int i = 0; i < collectionlst.Count; i++)
                            //{
                            //    if (collectionlst[i].type == "5" || collectionlst[i].type == "6" || collectionlst[i].type == "7")
                            //    {
                            //        textcollection.Add(collectionlst[i]);
                            //    }
                            //}
                            collectionShowlst = collectionlst;
                            mAdapter.BindDatas(collectionlst);
                            cc.SetAdapter(mAdapter);

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }
        //获取相册文件夹
        private void getGroupFolder()
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getGroupAlbum";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            List<MyGroupFolder> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupFolder>>(data["data"].ToString());
                            collectionlst = new List<Collections>() { };

                            //保存类型 1相册 2视频 3文件  4声音 5文本 6gif 7SDKLink ;
                            //群资源类型 1群文件 2群视频
                            foreach (var item in myGroupContentList)
                            {
                                Collections collectItem = new Collections() { };
                                collectItem.msgId = item.folderId;
                                collectItem.Filename = item.folderName;
                                collectItem.collectType = 20; collectItem.type = collectItem.collectType.ToString();
                                if (item.groupShareList != null && item.groupShareList.Count > 0)
                                    collectItem.url = item.groupShareList[0].resource.tUrl;

                                collectItem.groupShareList = item.groupShareList;
                                //collectItem.msg = item.title;

                                //collectItem.msg = item.text;
                                //collectItem.createTime = item.time;
                                //collectItem.fileSize =0;
                                //switch (item.type)
                                //{
                                //    case 1: collectItem.collectType = 3; collectItem.type = collectItem.collectType.ToString(); break;
                                //    case 2: collectItem.collectType = 2; collectItem.type = collectItem.collectType.ToString(); break;
                                //}
                                collectionlst.Add(collectItem);
                            }
                            collectionShowlst = collectionlst;
                            mAdapter.BindDatas(collectionlst);
                            cc.SetAdapter(mAdapter);
                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }

        private void getGroupUserSize()
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "room/get";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            labelGroupInfo.Text = "(总群员：" + data["userSize"] + "人)";
                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }
        //获取相册列表
        private void getGroupImg()
        {
            string RequestUrl = string.Empty;
            //Dictionary<string, string> pairs = new Dictionary<string, string>();
            //pairs.Add("dhPublicKey", dhPublicKey);

            RequestUrl = Applicate.URLDATA.data.apiUrl + "community/getGroupShare";


            HttpUtils.Instance.InitHttp(this);

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("salt", TimeUtils.CurrentTimeMillis().ToString())
                  .AddParams("roomId", group.RoomId)
                    .AddParams("type", "1")//资源类型 1群文件 2群视频
                    .AddParams("pageIndex", "0")
                     .AddParams("pageSize", "99999")
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        try
                        {
                            List<MyGroupContent> myGroupContentList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyGroupContent>>(data["data"].ToString());
                            collectionlst = new List<Collections>() { };

                            //保存类型 1相册 2视频 3文件  4声音 5文本 6gif 7SDKLink ;
                            //群资源类型 1群文件 2群视频
                            foreach (var item in myGroupContentList)
                            {
                                Collections collectItem = new Collections() { };
                                collectItem.msgId = item.shareId;
                                collectItem.Filename = item.url;
                                collectItem.url = item.url;
                                collectItem.msg = item.title;

                                //collectItem.msg = item.text;
                                //collectItem.createTime = item.time;
                                //collectItem.fileSize =0;
                                switch (item.type)
                                {
                                    case 1: collectItem.collectType = 3; collectItem.type = collectItem.collectType.ToString(); break;
                                    case 2: collectItem.collectType = 2; collectItem.type = collectItem.collectType.ToString(); break;
                                }
                                collectionlst.Add(collectItem);
                            }

                        }
                        catch (Exception ex)
                        {
                            string tmpErr = ex.ToString();
                        }
                    }
                });
        }

        public void DisplayGroup()
        {


            lblTitle.Text = group.NickName;
            int length = lblTitle.Text.Length;
            if (length > 58)
            {
                lblTitle.Text = lblTitle.Text.Substring(0, 59) + "...";
            }
            pictureBoxGQ.Visible = false;
            if (group.UserType == 2) pictureBoxGQ.Visible = true;

            this.GroupInfo = group;
            //labelGroupInfo.Text = "(总群员："+ group.nu+ "人)";
            btnLecture_Click(null, null);
            getGroupUserSize();

        }

        /// <summary>
        /// 全部保存数据
        /// </summary>
        private void WholeData()
        {
            lblTitle.Text = btnWhole.Text.Trim();
            tvClassTip.Visible = false;
            ShowLodingDialog(cc);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/collection/list")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("userId", Applicate.MyAccount.userId)
               .Build().AddErrorListener((code, ss) =>
               {
                   loding.stop();
                   //cc.SetAdapter(mAdapter);
                   HttpUtils.Instance.ShowTip(ss);

               }).ExecuteJson<List<Collections>>((suss, data) =>
               {
                   if (loding != null)
                   {
                       loding.stop();
                   }

                   if (UIUtils.IsNull(data))
                   {

                       //cc.SetAdapter(mAdapter);
                       HttpUtils.Instance.ShowTip("暂无保存");
                       return;
                   }
                   foreach (var item in data)
                   {
                       if (item.type == "1")
                       {
                           string[] strarr = item.msg.Split(',');

                           foreach (var image in strarr)
                           {

                               var msg = new MessageObject() { content = image, fileName = item.Filename, fileSize = Convert.ToInt64(item.fileLength), type = kWCMessageType.Image };
                               message.Add(msg);

                           }
                       }
                   }

                   collectionlst = data;

                   //mAdapter.SetMaengForm(this);
                   //mAdapter.BindDatas(collectionlst);
                   //cc.SetAdapter(mAdapter);
               });
        }
        #endregion



        public void OnClickCollectionItem(UserCollectionItem item, MouseEventArgs eve)
        {
            if (eve.Button == MouseButtons.Left)
            {

                openItem(item);
            }
            else
            {
                CollectionItem = item;
            }


        }

        private void openItem(UserCollectionItem item)
        {
            var data = item.Collections;
            switch (data.type)
            {
                case "1":
                    // 图片和文字
                    OpenFile(data);
                    break;
                case "2":
                    // 视频
                    OpenVideo(data);
                    break;
                case "3":
                    // 文件
                    OpenFile(data);
                    break;
                case "4":
                    // 语音
                    OpenVoice(data);
                    break;
                case "5":
                    // 链接
                    if (UIUtils.IsHttpUrl(data.msg))
                    {
                        OpenLink(data);
                    }
                    else
                    {
                        OpenTextLook(data);
                    }
                    break;
                default:
                    break;
            }
        }

        private List<Collections> _msgs;
        /// <summary>
        /// 多选的集合
        /// </summary>
        public List<Collections> List_Msgs
        {
            get { return _msgs; }
            set { _msgs = value; }
        }
        #region 保存类型
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhole_Click(object sender, EventArgs e)
        {
            initBtnIcon();
            btnWhole.Image = Resources.groupActivity;
            new SaveMusicMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);
            cc.ClearList();
            //lblTitle.Text = "";
            //lblTitle.Text = ((Control)sender).Text.Trim();
            mAdapter.SetMaengForm(this);
            //mAdapter.BindDatas(collectionlst);全部
            List<Collections> musiccollection = new List<Collections>();

            for (int i = 0; i < collectionlst.Count; i++)
            {
                if (collectionlst[i].type == "3") //4
                {
                    musiccollection.Add(collectionlst[i]);
                }
            }
            collectionShowlst = musiccollection;
            mAdapter.BindDatas(musiccollection);
            cc.SetAdapter(mAdapter);

            tvClassTip.Visible = false;
            setChechkBoxClick();
            getGroupActivity();
        }
        private void setChechkBoxClick()
        {
            this.List_Msgs = new List<Collections>();
            int i = 0;
            foreach (Control item in cc.panel1.Controls)
                if (item is UserCollectionItem ucItem)
                    foreach (Control chkitem in ucItem.panel.Controls)
                        if (chkitem is CheckBoxEx checkBox)
                        {
                            checkBox.Visible = false;
                            checkBox.Tag = i;
                            checkBox.CheckedChanged += (sender, e) =>
                            {
                                bool cheked = ((CheckBoxEx)sender).Checked;
                                if (cheked)
                                    this.List_Msgs.Add(collectionShowlst[int.Parse(((CheckBoxEx)sender).Tag.ToString())]);
                                else
                                    this.List_Msgs.Remove(collectionShowlst[int.Parse(((CheckBoxEx)sender).Tag.ToString())]);
                                multiSelectPanel.List_Msgs = this.List_Msgs;
                            };
                            i++;
                        }



        }
        /// <summary>
        /// 文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnText_Click(object sender, EventArgs e)
        {
            //RefreData();
            getGroupShare(3);
            initBtnIcon();
            btnText.Image = Resources.groupFile;
            new SaveFileMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);
            ShowLodingDialog(cc);
            cc.ClearList();
            //lblTitle.Text = "";
            //lblTitle.Text = ((Control)sender).Text.Trim();
            mAdapter.SetMaengForm(this);

            //List<Collections> textcollection = new List<Collections>();

            //for (int i = 0; i < collectionlst.Count; i++)
            //{
            //    if (collectionlst[i].type == "3")
            //    {
            //        textcollection.Add(collectionlst[i]);
            //    }
            //}
            //collectionShowlst = textcollection;
            //mAdapter.BindDatas(textcollection);
            //cc.SetAdapter(mAdapter);
            loding.stop();

            tvClassTip.Visible = false;
            setChechkBoxClick();
        }
        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImg_Click(object sender, EventArgs e)
        {
            initBtnIcon();
            btnImg.Image = Resources.groupImg;
            new SaveImgFolderMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);
            //new SaveImgFileMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);
            ShowLodingDialog(cc);
            cc.ClearList();
            //lblTitle.Text = "";
            //lblTitle.Text = ((Control)sender).Text.Trim();
            tvClassTip.Visible = false;
            mAdapter.SetMaengForm(this);
            List<Collections> imagecollection = new List<Collections>();

            for (int i = 0; i < collectionlst.Count; i++)
            {
                if (collectionlst[i].type == "1")
                {
                    imagecollection.Add(collectionlst[i]);
                }
            }
            collectionShowlst = imagecollection;
            mAdapter.BindDatas(imagecollection);
            cc.SetAdapter(mAdapter);
            loding.stop();
            setChechkBoxClick();
            getGroupFolder();
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVideo_Click(object sender, EventArgs e)
        {
            //RefreData();
            getGroupShare(2);
            initBtnIcon();
            btnVideo.Image = Resources.groupVideo;
            new SaveVedioMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);
            tvClassTip.Visible = false;
            ShowLodingDialog(cc);
            cc.ClearList();
            //lblTitle.Text = "";
            //lblTitle.Text = ((Control)sender).Text.Trim();

            mAdapter.SetMaengForm(this);
            //List<Collections> vidiocollection = new List<Collections>();
            //for (int i = 0; i < collectionlst.Count; i++)
            //{
            //    if (collectionlst[i].type == "2")
            //    {
            //        vidiocollection.Add(collectionlst[i]);
            //    }
            //}
            //collectionShowlst = vidiocollection;
            //mAdapter.BindDatas(vidiocollection);
            //cc.SetAdapter(mAdapter);


            if (loding != null)
            {
                loding.stop();
            }
            setChechkBoxClick();

        }
        #endregion

        #region 转发保存
        private void tsmForward_Click(object sender, EventArgs e)
        {
            var frm = Applicate.GetWindow<FrmFriendSelect>();

            if (frm == null)
            {
                frm = new FrmFriendSelect();
            }
            else
            {
                frm.Activate();
                return;
            }

            frm.max_number = 15;
            frm.LoadFriendsData(1);
            frm.AddConfrmListener((dis) =>
            {
                HttpUtils.Instance.PopView(frm);
                foreach (var friend in dis)
                {
                    ForwardCollection(friend.Value, CollectionItem);
                }
            });
        }

        // 转发保存
        private void ForwardCollection(Friend friend, UserCollectionItem collection)
        {
            if (CollectUtils.EnableForward(friend))
            {
                return;
            }

            MessageObject messageObjects = new MessageObject();
            //msgObj.type = CollectUtils.GetMsgTypeBySaveType(collectItem.type);
            messageObjects.timeSend = TimeUtils.CurrentTimeDouble();
            messageObjects.messageId = Guid.NewGuid().ToString("N");//生成Guid
            messageObjects.FromId = Applicate.MyAccount.userId;
            messageObjects.ToId = friend.UserId;
            messageObjects.toUserId = friend.UserId;//接收者
            messageObjects.toUserName = friend.NickName;
            messageObjects.fromUserId = Applicate.MyAccount.userId;
            messageObjects.fromUserName = Applicate.MyAccount.nickname;
            //msgObj.content = collectItem.msg;
            //msgObj.fileName = collectItem.Filename;
            Collections collections = collection.Collections;

            switch (collections.type)
            {
                //图片
                case "1":

                    string[] conString = collections.msg.Split(',');
                    foreach (var msg in conString)
                    {
                        messageObjects = new MessageObject() { content = msg, type = kWCMessageType.Image };
                        messageObjects.timeSend = TimeUtils.CurrentTimeDouble();
                        messageObjects.messageId = Guid.NewGuid().ToString("N");//生成Guid
                        messageObjects.FromId = Applicate.MyAccount.userId;
                        messageObjects.ToId = friend.UserId;
                        messageObjects.toUserId = friend.UserId;//接收者
                        messageObjects.toUserName = friend.NickName;
                        messageObjects.fromUserId = Applicate.MyAccount.userId;
                        messageObjects.fromUserName = Applicate.MyAccount.nickname;
                        //messageObjects.content = msg;
                        //messageObjects.type = kWCMessageType.Image;
                        ShiKuManager.SendForwardMessage(friend, messageObjects);

                        Messenger.Default.Send(messageObjects, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

                        HttpUtils.Instance.ShowTip("转发成功");
                    }


                    if (!string.IsNullOrEmpty(collections.collectContent))
                    {
                        messageObjects = new MessageObject() { content = collections.collectContent, type = kWCMessageType.Image };
                        ShiKuManager.SendForwardMessage(friend, messageObjects);

                        Messenger.Default.Send(messageObjects, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

                        HttpUtils.Instance.ShowTip("转发成功");
                    }

                    return;
                //视频
                case "2":
                    messageObjects = new MessageObject() { content = collections.url, fileName = FileUtils.GetFileName(collections.url), type = kWCMessageType.Video, fileSize = collections.fileSize };

                    break;
                //文件
                case "3":
                    messageObjects = new MessageObject() { content = collections.url, fileName = FileUtils.GetFileName(collections.Filename), type = kWCMessageType.File, fileSize = collections.fileSize };
                    break;

                //文本表情
                case "5":
                    messageObjects = new MessageObject() { content = CollectionItem.Tag.ToString(), type = kWCMessageType.Text };
                    break;

                case "4":    //语音
                    messageObjects = new MessageObject() { content = collections.url, fileName = collections.Filename, type = kWCMessageType.Voice, fileSize = collections.fileSize, timeLen = Convert.ToInt32(collections.fileLength) };
                    break;
                case "6":       //表情
                case "7":         //SDK分享链接
                    break;
            }


            if (messageObjects != null)
            {
                messageObjects.timeSend = TimeUtils.CurrentTimeDouble();
                messageObjects.messageId = Guid.NewGuid().ToString("N");//生成Guid
                messageObjects.FromId = Applicate.MyAccount.userId;
                messageObjects.ToId = friend.UserId;
                messageObjects.toUserId = friend.UserId;//接收者
                messageObjects.toUserName = friend.NickName;
                messageObjects.fromUserId = Applicate.MyAccount.userId;
                messageObjects.fromUserName = Applicate.MyAccount.nickname;

                ShiKuManager.SendForwardMessage(friend, messageObjects);

                Messenger.Default.Send(messageObjects, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

                HttpUtils.Instance.ShowTip("转发成功");
            }

        }

        #endregion

        #region 删除保存
        private void tsmDel_Click(object sender, EventArgs e)
        {

            bool result = HttpUtils.Instance.ShowPromptBox("确认删除");
            if (result && CollectionItem != null)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/delete")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("emojiId", CollectionItem.Collections.emojiId)
                    .Build().Execute((su, da) =>
                    {
                        if (su)
                        {
                            int index = mAdapter.GetMessageIdByIndex(CollectionItem.Collections.emojiId);

                            WholeData();//刷新数据

                            if (index > -1)
                            {
                                //myTabLayoutPanel1.RemoveItem(index);
                                //mAdapter.RemoveData(index);
                                cc.RemoveItem(index);
                                //HttpUtils.Instance.ShowTip("删除成功");
                            }
                            HttpUtils.Instance.ShowTip("删除成功");

                            //if (!btnWhole.Text.Trim().Equals(lblTitle.Text))
                            //{
                            //for (int i = collectionlst.Count - 1; i > -1; i--)
                            //{
                            //    if (collectionlst[i].emojiId == CollectionItem.Name)
                            //    {
                            //        collectionlst.RemoveAt(i);
                            //        break;
                            //    }
                            //}
                            //}
                        }
                    });
            }
        }

        #endregion
        private void initBtnIcon()
        {
            flowLayoutPanelImgList.Visible = false;
            panelImgFolder.Visible = false;
            cc.Visible = true;
            btnLecture.Image = Resources.groupNotice0;
            btnWhole.Image = Resources.groupActivity0;
            btnText.Image = Resources.groupFile0;
            btnVideo.Image = Resources.groupVideo0;
            btnImg.Image = Resources.groupImg0;
        }
        #region 点击我的讲课
        private void btnLecture_Click(object sender, EventArgs e)
        {
            initBtnIcon();
            btnLecture.Image = Resources.groupNotice;
            new SaveOtherMenuStripVisibleVoice().SettingMenuStripVisible(ref cmsCollection, false, false);

            //lblTitle.Text = ((Control)sender).Text.Trim();


            //// 加载过数据就不在去加载了
            //if (isLoadCourseData)
            //{
            //    //tvClassTip.Visible = myColleagueAdapter.GetItemCount() == 0;
            //    cc.SetAdapter(myColleagueAdapter);
            //    return;
            //}

            //ShowLodingDialog(cc);
            //HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/list")
            //    .AddParams("access_token", Applicate.Access_Token)
            //    .AddParams("userId", Applicate.MyAccount.userId)
            //    .Build().ExecuteList<ColleaguesList>((suss, data) =>
            //    {
            //        HideLodingDialog();
            //        if (suss)
            //        {
            //            isLoadCourseData = true;
            //            //tvClassTip.Visible = UIUtils.IsNull(data.data);
            //            myColleagueAdapter.BindDatas(data.data);
            //            cc.SetAdapter(myColleagueAdapter);
            //        }
            //    });


            ShowLodingDialog(cc);
            cc.ClearList();
            //lblTitle.Text = "";
            //lblTitle.Text = ((Control)sender).Text.Trim();
            mAdapter.SetMaengForm(this);

            List<Collections> textcollection = new List<Collections>();

            for (int i = 0; i < collectionlst.Count; i++)
            {
                if (collectionlst[i].type == "5" || collectionlst[i].type == "6" || collectionlst[i].type == "7")
                {
                    textcollection.Add(collectionlst[i]);
                }
            }
            collectionShowlst = textcollection;
            mAdapter.BindDatas(textcollection);
            cc.SetAdapter(mAdapter);
            loding.stop();

            tvClassTip.Visible = false;
            setChechkBoxClick();

            getGroupNotice();
        }

        #endregion


        #region 点击我的讲课详情
        // 点击我的讲课详情
        internal void OnClickCourseItem(UserCollectionItem item, MouseEventArgs eve)
        {
            if (eve.Button == MouseButtons.Right)
            {
                mSelectCourse = item;
                if (mSelectCourse != null)
                {
                    mSelectCourse.ContextMenuStrip = null;
                }

                mSelectCourse = item;
                mSelectCourse.ContextMenuStrip = cmsLecture;
                return;
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/get")
                      .AddParams("courseId", item.Name)
                      .AddParams("access_token", Applicate.Access_Token)
                      .Build().ExecuteJson<List<CourseMessage>>((state, jsonArray) =>
                      {
                          if (state)
                          {
                              ListMessage = new List<MessageObject>();

                              foreach (var arrItme in jsonArray)
                              {
                                  MessageObject msg = arrItme.ToMessageObject();

                                  //解析出错
                                  if (msg == null)
                                  {
                                      continue;
                                  }

                                  if (msg.isEncrypt > 0)
                                  {
                                      SkSSLUtils.DecryptRecordMessage(msg, msg.ChatJid.Length > 18);
                                  }

                                  if (msg.isEncrypt != 3)
                                  {
                                      ListMessage.Add(msg);
                                  }
                              }



                              if (eve.Button == MouseButtons.Left)
                              {
                                  if (mSelectCourse != null)
                                  {
                                      mSelectCourse.ContextMenuStrip = null;
                                  }

                                  mSelectCourse = item;

                                  FrmHistoryMsg frmHistoryMsg = new FrmHistoryMsg()
                                  {
                                      messages = ListMessage,
                                      FromLocal = false
                                  };
                                  frmHistoryMsg.Text = btnLecture.Text.Trim();
                                  frmHistoryMsg.Show();
                              }
                          }
                      });
        }

        #endregion

        #region 修改我的讲课名称

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            //UserFileLeft panel_file = new UserFileLeft();
            //foreach (Control ctrl in mSelectCourse.Controls)
            //{
            //    if (ctrl.Name == "panel_file")
            //    {
            //        panel_file = (UserFileLeft)ctrl;
            //    }
            //}

            string courName = mSelectCourse.Tag.ToString();
            frm.NameEdit = courName;// panel_file.lab_fileName.Text.Remove(0, 5);
            frm.ColleagueName((courseName) =>
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("courseId", mSelectCourse.Name)
                    .AddParams("courseName", courseName)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            frm.Close();
                            HttpUtils.Instance.ShowTip("修改成功");
                            mSelectCourse.RefreshCourseName(courseName);
                            mSelectCourse.Tag = courseName;
                        }
                    });

            });

            string title = LanguageXmlUtils.GetValue("title_modify_courseware", "修改课件");
            string name = LanguageXmlUtils.GetValue("name_courseware_name", "课件名称：", true);
            frm.ShowThis(title, name);
        }

        #endregion

        #region 发送讲课
        private void tsmSendLecture_Click(object sender, EventArgs e)
        {
            FrmFriendSelect frm = new FrmFriendSelect();
            frm.max_number = 1;
            frm.LoadFriendsData(1);
            frm.AddConfrmListener((data) =>
            {
                if (data == null || data.Count == 0)
                {
                    HttpUtils.Instance.ShowTip("数据错误");
                    return;
                }

                Friend friend = null;
                foreach (var item in data.Values)
                {
                    friend = item;
                }

                if (friend == null || UIUtils.IsNull(ListMessage))
                {
                    HttpUtils.Instance.ShowTip("数据错误");
                    return;
                }
                else
                {
                    if (friend.IsGroup == 1)
                    {
                        if (friend.IsSecretGroup == 1)
                        {
                            if (UIUtils.IsNull(friend.ChatKeyGroup))
                            {
                                // 没有密钥
                                HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                return;
                            }

                            if (friend.IsLostKeyGroup == 1)
                            {
                                // 没有密钥
                                HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                                return;
                            }
                        }

                        RoomMember roomMember = new RoomMember { roomId = friend.RoomId, userId = Applicate.MyAccount.userId };

                        roomMember = roomMember.GetRoomMember();
                        if (roomMember.role == 4)
                        {
                            HttpUtils.Instance.ShowTip("隐身人不能发送课件");
                            return;
                        }

                        if (roomMember.role == 3)
                        {
                            if (friend.AllowSpeakCourse != 1)
                            {
                                HttpUtils.Instance.ShowTip("已开启普通成员不能发送课件");
                                return;
                            }

                            //是否全体禁言
                            string all = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, "0");
                            //管理员和群主除外
                            if (!"0".Equals(all))
                            {
                                // 全体禁言
                                HttpUtils.Instance.ShowTip("不能发送讲课到全体禁言群");
                                return;
                            }

                            string single = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK" + Applicate.MyAccount.userId, "0");
                            //是否单个禁言
                            if (!"0".Equals(single))
                            {
                                HttpUtils.Instance.ShowTip("您已被禁止在此群发言");
                                return;
                            }
                        }

                    }
                }

                Task.Factory.StartNew(() =>
                {
                    SendCourseMessage(friend, ListMessage, 0);
                });
            });
        }

        private void SendCourseMessage(Friend friend, List<MessageObject> listMessage, int index)
        {
            Thread.Sleep(500);

            MessageObject mess = ShiKuManager.SendForwardMessage(friend, ListMessage[index]);
            Messenger.Default.Send(mess, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);

            if ((++index) < listMessage.Count)
            {
                SendCourseMessage(friend, listMessage, index);
            }
            else
            {
                HttpUtils.Instance.ShowTip("课件发送成功");
            }
        }
        #endregion


        #region 保存搜索

        // 搜索逻辑代码
        private void SearchMeesageContent(string inputStr)
        {


            HideLodingDialog();

            if (string.IsNullOrEmpty(inputStr))
            {
                lblTitle.Text = btnWhole.Text.Trim();
                // 还原数据
                RevertData();
            }
            else
            {
                lblTitle.Text = LanguageXmlUtils.GetValue("search_result", "搜索结果");
                List<Collections> searchResult = SearchNickName(inputStr);
                if (UIUtils.IsNull(searchResult))
                {
                    mAdapter.BindDatas(new List<Collections>());
                    cc.ClearList();
                }
                else
                {
                    mAdapter.BindDatas(searchResult);
                    cc.SetAdapter(mAdapter);
                }
            }
        }
        /// <summary>
        /// 还原数据
        /// </summary>
        private void RevertData()
        {
            cc.ClearList();
            mAdapter.BindDatas(collectionlst);
            cc.SetAdapter(mAdapter);
        }


        private List<Collections> SearchNickName(string text)
        {
            List<Collections> data = new List<Collections>();
            foreach (var item in collectionlst)
            {
                // 只搜索文字
                if ("5".Equals(item.type) && UIUtils.Contains(item.msg, text))
                {
                    data.Add(item);
                }
            }

            return data;
        }

        private void tvClassTip_Click(object sender, EventArgs e)
        {

            FrmLookImage look = new FrmLookImage();
            // look.ShowImageList(msgs, 0);
            string url = "https://www.shiku.co/lecture_guide_pc.jpg";
            look.pictureBox1_SetImage(url, false);

        }
        #endregion

        #region 右键删除我的讲课

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/course/delete")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("courseId", mSelectCourse.Name)
                .Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        HttpUtils.Instance.ShowTip("删除成功");

                        //int index = myColleagueAdapter.GetIndexByName(mSelectCourse.Name);
                        //if (index > -1)
                        //{
                        //    cc.RemoveItem(index);
                        //    myColleagueAdapter.RemoveData(index);
                        //}
                    }
                });
        }

        #endregion

        // 查看保存中的图文
        public void OnClickCollectionImage(Collections data, int index)
        {
            bool findImag = false;
            string[] strarr = data.msg.Split(',');

            foreach (var image in strarr)
            {
                //var msg = new MessageObject() { content = image, fileName = data.Filename, fileSize = Convert.ToInt64(data.fileLength), type = kWCMessageType.Image };
                //message.Add(msg);
                foreach (var item in message)
                {
                    if (item.content.Contains(image))
                    {
                        findImag = true;
                    }
                    if (!findImag)
                    {
                        index++;
                    }
                }
            }


            FrmLookImage frm = new FrmLookImage();
            frm.ShowImageList(message, index, true);
            frm.Show();
        }

        // 查看保存中的图视频
        private void OpenVideo(Collections data, bool noVolumn = false)
        {
            FrmVideoFlash frm = FrmVideoFlash.CreateInstrance();
            var msg = new MessageObject() { content = data.url, fileName = FileUtils.GetFileName(data.url), fileSize = data.fileSize, type = kWCMessageType.Video };
            frm.VidoShowList(msg);
            frm.isCollect = true;
            frm.noVolumn = noVolumn;
            frm.Show();
        }

        // 查看保存中的录音
        private void OpenVoice(Collections data)
        {
            var main = Applicate.GetWindow<FrmMain>();
            var frm = Applicate.GetWindow<FrmvoiceTest>();

            bool isNull = false;
            if (frm == null)
            {
                isNull = true;
                frm = new FrmvoiceTest();
            }

            var msg = new MessageObject() { content = data.url, fileSize = data.fileSize, timeLen = Convert.ToInt32(data.fileLength) };
            if (frm.GetDevicde())
            {
                HttpUtils.Instance.ShowTip("未发现音频播放设备");
                return;
            }

            frm.SetAutoClose();
            frm.SetData(msg);
            frm.Size = new Size(cc.Width, 72);
            frm.Location = new Point(main.Location.X + 326, main.Location.Y + 65);
            if (isNull)
            {
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        // 查看保存中的链接
        private void OpenLink(Collections data)
        {

            string url = REUtils.MatchStrUrl(data.msg);
            if (UIUtils.IsNull(url))
            {
                OpenTextLook(data);
                return;
            }


            var msg = new MessageObject() { content = url };

            var frmSeeText = Applicate.GetWindow<FrmBrowser>();
            if (frmSeeText == null)
            {
                frmSeeText = new FrmBrowser();
                frmSeeText.BrowserShow(msg, true);
            }
            else
            {
                frmSeeText.Activate();
                frmSeeText.WindowState = FormWindowState.Normal;
                frmSeeText.BrowserShow(msg, true);
            }
        }

        // 查看文本
        private void OpenTextLook(Collections data)
        {
            var msg = new MessageObject() { content = data.msg };

            var frmSeeText = Applicate.GetWindow<FrmSeeText>();
            if (frmSeeText == null)
            {
                frmSeeText = new FrmSeeText();
                frmSeeText.Longtext = data.msg;
                frmSeeText.IsForward = false;
                frmSeeText.iscollect = false;
                frmSeeText.Show();
            }
            else
            {
                frmSeeText.Activate();
                frmSeeText.WindowState = FormWindowState.Normal;
                frmSeeText.IsForward = false;
                frmSeeText.iscollect = false;
                frmSeeText.Longtext = data.msg;
            }
        }



        public bool isOpenFileing = false;
        // 查看保存中的图文件
        private void OpenFile(Collections data)
        {

            if (isOpenFileing)
            {
                Applicate.GetWindow<FrmMain>().ShowTip("正在打开文件中…");
                return;
            }

            isOpenFileing = true;
            string url = data.url;
            string downUrl = data.msg;
            if (string.IsNullOrEmpty(downUrl))
            {
                Applicate.GetWindow<FrmMain>().ShowTip("文件不存在！");
                return;
            }
            string sname = FileUtils.GetFileName(url);

            //文件的本地路径
            string localPath = Applicate.LocalConfigData.FileFolderPath + sname;

            //本地已存在该文件，并且不是下载中   这样会有一个bug,就是服务器的文件和实际下载的文件不一样
            if (File.Exists(localPath))
            {
                //打开文件
                //System.Diagnostics.Process.Start(localPath);
                StartExplorer(localPath);
            }
            else
            {
                //开始下载
                DownloadEngine.Instance.DownUrl(downUrl)
                .SavePath(localPath)
                .Down((path) =>
                {
                    if (string.IsNullOrEmpty(path))
                        return;
                    //打开文件
                    StartExplorer(path);
                });
            }
        }


        private void tsmOpen_Click(object sender, EventArgs e)
        {
            openItem(CollectionItem);
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            MenuItem_Copy_Click();
        }
        #region 复制
        private void MenuItem_Copy_Click()
        {


            var data = CollectionItem.Collections;
            switch (data.type)
            {
                case "1"://kWCMessageType.Image
                    //清空剪切板，防止里面之前有内容
                    Clipboard.Clear();
                    //给剪切板设置图片对象

                    if (FileUtils.IsGif(data.Filename))
                    {
                        string imgfileName = FileUtils.GetFileName(data.Filename);
                        string imgfilePath = Applicate.LocalConfigData.ImageFolderPath + imgfileName;
                        if (File.Exists(imgfilePath))
                        {
                            StringCollection strcoll = new StringCollection
                            {
                                imgfilePath
                            };
                            Clipboard.SetFileDropList(strcoll);
                        }
                    }
                    else
                    {
                        //Image image = picBox.BackgroundImage;
                        ////string msgId = picBox.Tag != null ? picBox.Tag.ToString() : "";
                        ////if (!string.IsNullOrEmpty(msgId))
                        ////{
                        ////    MessageObject image_msg = msgTabAdapter.TargetMsgData.GetMsg(msgId);
                        //if (BitmapUtils.IsNull(image))
                        //{
                        //    //string filePath = Applicate.LocalConfigData.ImageFolderPath + msgId + ".png";
                        //    string fileName = FileUtils.GetFileName(msg.content);
                        //    string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;

                        //    if (File.Exists(filePath))
                        //    {
                        //        image = Image.FromFile(filePath);
                        //    }
                        //}
                        //}
                        //Bitmap bitmap = new Bitmap(image);
                        //Clipboard.SetImage(image);
                        string imgfilePath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(data.Filename);
                        if (!File.Exists(imgfilePath))
                        {
                            DownloadEngine.Instance.DownUrl(data.Filename).Down((path) =>
                            {
                                StringCollection strcoll = new StringCollection();
                                strcoll.Add(path);
                                Clipboard.SetFileDropList(strcoll);
                            });
                        }
                        else
                        {
                            StringCollection strcoll = new StringCollection();
                            strcoll.Add(imgfilePath);
                            Clipboard.SetFileDropList(strcoll);
                        }
                    }
                    break;
                case "5":// kWCMessageType.Text
                    //清空剪切板，防止里面之前有内容
                    Clipboard.Clear();
                    //给剪切板设置图片对象

                    //string content = "";
                    //if (string.IsNullOrEmpty(data.msg))
                    //    content = data.msg.ToString().Trim();
                    //else
                    //{
                    //    bool isOneself = false;
                    //    string selected_rtf = data.msg;
                    //    selected_rtf = selected_rtf.Replace("{\\*\\picprop}", "");
                    //    foreach (string item in EmojiCodeDictionary.GetEmojiDataIsMine().Keys)
                    //    {
                    //        string emoji_code = "[" + item + "]";
                    //        selected_rtf = selected_rtf.Replace(EmojiCodeDictionary.GetEmojiRtfByCode(item, isOneself), emoji_code);
                    //    }
                    //    using (RichTextBox ri = new RichTextBox())
                    //    {
                    //        ri.Rtf = selected_rtf;
                    //        content = ri.Text;
                    //    }
                    //}
                    Clipboard.SetText(data.msg.ToString().Trim());

                    break;
                case "0"://kWCMessageType.Reply
                    //清空剪切板，防止里面之前有内容
                    Clipboard.Clear();
                    //给剪切板设置图片对象
                    //RichTextBox richTextBox = crl_content as RichTextBox;
                    //string content = richTextBox.Tag.ToString();
                    //Clipboard.SetText(msg.content);
                    break;
                case "3"://kWCMessageType.File
                    //string localPath = Applicate.LocalConfigData.FileFolderPath + FileUtils.GetFileName(data.Filename);
                    //if (!File.Exists(localPath))
                    //    DownloadFile(msg, localPath, true);
                    //else
                    //{
                    //    StringCollection strcoll = new StringCollection
                    //    {
                    //        localPath
                    //    };
                    //    Clipboard.SetFileDropList(strcoll);
                    //}
                    string filePath = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(data.Filename);
                    if (!File.Exists(filePath))
                    {
                        DownloadEngine.Instance.DownUrl(data.Filename).Down((path) =>
                        {
                            StringCollection strcoll = new StringCollection();
                            strcoll.Add(path);
                            Clipboard.SetFileDropList(strcoll);
                        });
                    }
                    else
                    {
                        StringCollection strcoll = new StringCollection();
                        strcoll.Add(filePath);
                        Clipboard.SetFileDropList(strcoll);
                    }
                    break;
                case "2"://kWCMessageType.Video
                    string videoPath = data.Filename;// Applicate.LocalConfigData.VideoFolderPath + FileUtils.GetFileName(msg.content);
                    if (!File.Exists(videoPath))
                    {
                        DownloadEngine.Instance.DownUrl(videoPath).Down((path) =>
                        {
                            StringCollection strcoll = new StringCollection();
                            strcoll.Add(path);
                            Clipboard.SetFileDropList(strcoll);
                        });
                    }
                    else
                    {
                        StringCollection strcoll = new StringCollection();
                        strcoll.Add(videoPath);
                        Clipboard.SetFileDropList(strcoll);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
        private void tsmPlayer_Click(object sender, EventArgs e)
        {
            OpenVideo(CollectionItem.Collections, true);
        }

        private void tsmMulti_Click(object sender, EventArgs e)
        {
            cc.SuspendLayout();
            try
            {
                int i = 0;
                foreach (Control item in cc.panel1.Controls)
                    if (item is UserCollectionItem ucItem)
                        foreach (Control chkitem in ucItem.panel.Controls)
                            if (chkitem is CheckBoxEx checkBox)
                            {
                                checkBox.Visible = true;
                                checkBox.BringToFront();
                                i++;
                            }




            }
            catch (Exception ex) { LogUtils.Error(ex.Message); }
            cc.ResumeLayout();
            ////清空之前被多选的集合
            List_Msgs.Clear();
            //multiSelectPanel.FdTalking = ChooseTarget;
            //展示多选
            ////IsShowPanelMultiSelect(true);
            SetDialogBoxSize(DialogBox.MultiSelect);
        }

        private void StartExplorer(string path)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2500);
                isOpenFileing = false;

            });

            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                psi.Arguments = "/e,/select," + path;
                System.Diagnostics.Process.Start(psi);


            }
            catch (Exception)
            {
                HttpUtils.Instance.ShowTip("不能打开此类型文件");
            }
        }

        #region 关闭多选面板
        private void LblClose_Click(object sender, EventArgs e)
        {
            //msgTabAdapter.TargetMsgData.isMultiSelect = false;
            foreach (Control item in cc.panel1.Controls)
                if (item is UserCollectionItem ucItem)
                    foreach (Control chkitem in ucItem.panel.Controls)
                        if (chkitem is CheckBoxEx checkBox)
                            checkBox.Visible = false;



            panMultiSelect.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 通知界面刷新
            // Messenger.Default.Send(true, MessageActions.ShowGroupInfo);
        }
        #endregion

        /// <summary>
        /// 设置对话框的尺寸（包括XList的高度变化）
        /// </summary>
        /// <param name="to_dialogBox">转变后的状态</param>
        public void SetDialogBoxSize(DialogBox to_dialogBox)
        {
            panMultiSelect.Visible = true;
            panMultiSelect.Dock = DockStyle.Bottom;
            panMultiSelect.BringToFront();
        }

        private void labelImgFolderTitle_Click(object sender, EventArgs e)
        {
            panelImgFolder.Visible = false;
            flowLayoutPanelImgList.Visible = false;
            cc.Visible = true;
        }

        // 双击相册簿
        public void OnDoubleClickCollectionImage(Collections data, int index)
        {

        }

    }
}