using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Dictionarys;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmHistoryChat : FrmBase
    {
        #region 全局变量
        //选中的label控件
        public Label is_check;
        public static Friend friends;
        //所有消息
        public static List<MessageObject> listData;

        private bool isOpenForm = false;
        private static int emoji_count = 0;
        public int type;
        private RichTextBoxEx richText = new RichTextBoxEx();
        private ImageViewxVideo pictureBoxVideo;
        private PictureBox pictureBoxImage = new PictureBox();
        private FilePanelLeft panel_file = new FilePanelLeft();
        private Panel pnlReplay = new Panel();
        private ChatItem chatFile = new ChatItem();
        private HistotyChatAdapter mAdapter;
        private bool isScrollBar;
        private int page = 1;
        #endregion
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblAll.Text = LanguageXmlUtils.GetValue("history_all", lblAll.Text);
            lblFile.Text = LanguageXmlUtils.GetValue("history_file", lblFile.Text);
            lblImage.Text = LanguageXmlUtils.GetValue("history_image", lblImage.Text);
            lblVideo.Text = LanguageXmlUtils.GetValue("history_video", lblVideo.Text);
        }

        private void FrmHistoryChat_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            this.Text = LanguageXmlUtils.GetValue("frmHistoryChat_title", "历史记录");
        }


        #region 窗体加载
        public FrmHistoryChat()
        {

            InitializeComponent();
            LoadLanguageText();

            mAdapter = new HistotyChatAdapter();

            xlvMsgs.FooterRefresh += OnFooterRefresh;



            lblAll.ForeColor = ColorTranslator.FromHtml("#1AAD19");
            lblAll.Font = new Font(Applicate.SetFont, 12);
            is_check = lblAll;

            if (!Applicate.IsInputChatList)
            {
                lblNext.Visible = false;
            }
            SearchMessage.tips = LanguageXmlUtils.GetValue("search_history_msgs", "搜索聊天记录");
            SearchMessage.SearchEvent += HistorySearch;
            //SearchMessage.ChangeUnselectColor(Color.FromArgb(230, 229, 229));
        }


        //向下滚动
        private void OnFooterRefresh()
        {
            if (isScrollBar)
            {
                page++;
                List<MessageObject> messages = new MessageObject()
                {
                    FromId = friends.UserId,

                }.GetPageListHistory(page);
                if (messages.Count <= 0)
                {
                    return;
                }

                if (listData.Count() > 400)
                {
                    xlvMsgs.DeleteRange(0, 300);
                    for (int i = 300; i > 0; i--)
                    {
                        mAdapter.RemoveData(i);
                    }
                }


                int index = listData.Count;
                listData.AddRange(messages);
                mAdapter.FrmHistoryChat = this;
                mAdapter.BindFriendData(listData);
                xlvMsgs.InsertRange(index);
            }
        }

        #endregion

        #region 数据验证
        /// <summary>
        /// 头像
        /// </summary>
        /// <param name="url"></param>
        /// <param name="incoImage"></param>
        public static void TypeFileToImage(string url, PictureBox incoImage)
        {
            int type = 0;
            if (url == "12" || url == "13")
            {
                type = Convert.ToInt32(url);
            }
            else
            {
                type = FileUtils.GetFileTypeByNanme(url);
            }
            //获取当前文件选择的头像

            //图片
            if (type == 1)
            {
                ImageLoader.Instance.Load(url).NoCache().Into(incoImage);

            }
            else if (type == 2)
            {

                //music
                incoImage.Image = Resources.ic_muc_flie_type_y;

            }
            else if (type == 3)
            {
                //视频
                incoImage.Image = Resources.ic_muc_flie_type_v;

            }
            else if (type == 4)
            {
                //ppt
                incoImage.Image = Resources.ic_muc_flie_type_p;

            }
            else if (type == 5)
            {
                //xlse
                incoImage.Image = Resources.ic_muc_flie_type_x;

            }
            else if (type == 6)
            {
                //world
                incoImage.Image = Resources.ic_muc_flie_type_w;

            }
            else if (type == 7)
            {
                //zrp
                incoImage.Image = Resources.ic_muc_flie_type_z;

            }
            else if (type == 8)
            {
                //txt
                incoImage.Image = Resources.ic_muc_flie_type_t;

            }
            else if (type == 9)
            {
                //??
                incoImage.Image = Resources.ic_muc_flie_type_what;

            }
            else if (type == 10)
            {
                //pdf
                incoImage.Image = Resources.ic_muc_flie_type_f;

            }
            else if (type == 11)
            {

                incoImage.Image = Resources.ic_muc_flie_type_a;

            }
            else if (type == 12)//红包
            {
                incoImage.Image = Resources.ic_historyredpacket;

            }
            else if (type == 13)//转账
            {
                incoImage.Image = Resources.ic_historytransfer;

            }
            else if (type == 56 || type == 55)
            {
                incoImage.Image = Resources.ic_flie_type_voice;
            }
        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="toFilePath"></param>
        /// <param name="fileUrl"></param>
        public static void DownFile(string toFilePath, string fileUrl, bool isOpen = false)
        {
            HttpDownloader.DownloadFile(fileUrl, toFilePath, (path) =>
            {
                if (!string.IsNullOrEmpty(path))
                {
                    // 下载成功
                    LogUtils.Log("下载成功！" + path);
                    if (!isOpen)
                    {
                        //打开此文件
                        System.Diagnostics.Process.Start(path);
                    }
                }
            });
        }
        #endregion

        #region  控件点击事件
        private void lblAll_Click(object sender, EventArgs e)
        {
            //清楚原有数据
            xlvMsgs.ClearList();
            var views = new List<Control>();
            lblAll.Text = LanguageXmlUtils.GetValue("history_all", "全部");

            #region 字体颜色
            Label label = (Label)sender;
            if (is_check != null && is_check != label)
            {
                //点击当前
                Font f = new Font(Applicate.SetFont, 12);
                label.ForeColor = ColorTranslator.FromHtml("#1AAD19");
                label.Font = f;
                //点击其它按钮
                Font f2 = new Font(Applicate.SetFont, 12);
                is_check.ForeColor = Color.Black;
                is_check.Font = f2;
                is_check = label;
            }
            #endregion
            #region 全部
            if ((Label)sender == lblAll)
            {
                LodingUtils loding = new LodingUtils();
                loding.parent = xlvMsgs;
                loding.size = xlvMsgs.Size;
                loding.start();
                xlvMsgs.Visible = true;
                flpTable.Visible = false;
                //判断是否在加载
                mAdapter.isclickFileButton = false;
                mAdapter.FrmHistoryChat = this;
                mAdapter.BindFriendData(listData);
                xlvMsgs.SetAdapter(mAdapter);
                //重新查询
                HistorySearch(SearchMessage.txt_Search.Text);
                loding.stop();
            }
            #endregion
            #region 文件
            if ((Label)sender == lblFile)
            {
                xlvMsgs.Visible = true;
                flpTable.Visible = false;
                List<MessageObject> listFileData = ShowMsgFileList(friends.UserId);
                foreach (var item in listFileData)
                {
                    FileInfonmation(item);
                    mAdapter.isclickFileButton = true;
                    mAdapter.FrmHistoryChat = this;
                    mAdapter.BindFriendData(listFileData);
                    xlvMsgs.SetAdapter(mAdapter);
                }
            }
            #endregion
            #region 图片
            if ((Label)sender == lblImage)
            {
                type = 3;
                //清除
                ImageIngomation();
            }
            #endregion
            #region 视频
            if ((Label)sender == lblVideo)
            {
                type = 4;
                VdioShow();
            }
            #endregion
        }
        #endregion

        #region 加载分类数据
        //视频
        private void VdioShow()
        {
            //清除
            flpTable.Controls.Clear();
            foreach (var item in listData)
            {
                if (item.type == kWCMessageType.Video)
                {
                    xlvMsgs.Visible = false;
                    flpTable.Visible = true;

                    pictureBoxVideo = new ImageViewxVideo();
                    pictureBoxVideo.Tag = item;
                    pictureBoxVideo.Location = new Point(52, 117);
                    pictureBoxVideo.Size = new Size(95, 95);

                    ThubImageLoader.Instance.LoadImage(item.content, pictureBoxVideo);

                    //绑定当前索引
                    pictureBoxVideo.Tag = item;
                    pictureBoxVideo.MouseClick += new MouseEventHandler(Vido_clike);
                    flpTable.Controls.Add(pictureBoxVideo);
                    BindMouseDown(pictureBoxVideo, item);
                    this.Controls.Add(flpTable);
                }
            }
        }
        //图片
        private void ImageIngomation()
        {
            flpTable.Controls.Clear();
            foreach (var item in listData)
            {
                if (item.type == kWCMessageType.Image)
                {
                    xlvMsgs.Visible = false;
                    flpTable.Visible = true;
                    pictureBoxImage = new PictureBox();
                    pictureBoxImage.Location = new Point(52, 117);
                    pictureBoxImage.Size = new Size(95, 95);
                    ImageLoader.Instance.Load(item.content).NoCache().Into((bitmap, path) =>
                    {
                        bitmap = EQControlManager.ClipImage(bitmap, pictureBoxImage.Width, pictureBoxImage.Height);
                        pictureBoxImage.BackgroundImageLayout = ImageLayout.Zoom;
                        pictureBoxImage.BackgroundImage = bitmap;
                    });
                    //pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxImage.Dock = DockStyle.None;
                    //绑定当前索引
                    pictureBoxImage.Name = item.messageId;
                    pictureBoxImage.Tag = item;
                    pictureBoxImage.MouseClick += new MouseEventHandler(MouseClie);
                    flpTable.Controls.Add(pictureBoxImage);
                    BindMouseDown(pictureBoxImage, item);
                    this.Controls.Add(flpTable);
                }
            }
        }
        //文件
        public ChatItem FileInfonmation(MessageObject message)
        {
            //实例化控件
            chatFile = new ChatItem();
            //string fileName = FileUtils.GetFileName(item.fileName);
            //chatFile.fileName = UIUtils.LimitTextLength(fileName, 20, true);
            //Label lblMsg = new Label();
            //lblMsg.AutoSize = false;
            //lblMsg.Size = new Size(150, 17);
            //lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            //lblMsg.Text = UIUtils.FromatFileSize(item.fileSize);
            //lblMsg.Location = new Point(chatFile.lblName.Location.X, chatFile.lblName.Location.Y + chatFile.lblName.Height + 5);
            //chatFile.Controls.Add(lblMsg);
            //lblMsg.BringToFront();
            //string Name = item.content != null ? item.content : item.fileName;
            //TypeFileToImage(Name, chatFile.pboxHead);
            //chatFile.MouseClick += (sende, e1) =>
            //{
            //    if (e1.Button == MouseButtons.Left)
            //    {
            //        string url = "";
            //        string filePaht = "";
            //        url = item.content;
            //        filePaht = FileUtils.GetFileName(item.content);
            //        string LoacPath = Applicate.LocalConfigData.RoomFileFolderPath + fileName;
            //        //下载
            //        DownFile(LoacPath, url);
            //    }
            //};
            //chatFile.Time = TimeUtils.ChatLastTime(item.timeSend);
            //chatFile.Tag = item;
            //BindMouseDown(chatFile, item);

            UserFileLeft panel_file = new UserFileLeft();
            panel_file.Cursor = Cursors.Hand;
            string fileNames = FileUtils.GetFileName(message.fileName);
            panel_file.lab_fileName.Text = fileNames;
            panel_file.lab_fileSize.Text = UIUtils.FromatFileSize(message.fileSize) + " " + message.fromUserName;
            //panel_file.Location = new Point(70, 12);
            panel_file.Location = new Point(chatFile.lblName.Location.X, chatFile.lblName.Location.Y);
            panel_file.BringToFront();
            panel_file.Tag = message;
            FrmHistoryChat.TypeFileToImage(message.content, panel_file.lab_icon);
            chatFile.lblName.Visible = false;

            foreach (Control itemControl in panel_file.Controls)
            {
                itemControl.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        string path = "";
                        string fileName = "";
                        path = message.content;
                        fileName = FileUtils.GetFileName(message.content);
                        string filePath = Applicate.LocalConfigData.RoomFileFolderPath + fileName;
                        //下载
                        FrmHistoryChat.DownFile(filePath, path);
                    }
                };
                if (itemControl.Controls.Count > 0)
                    foreach (Control itemcl in itemControl.Controls)
                        itemcl.MouseClick += (sender, e) =>
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                string path = "";
                                string fileName = "";
                                path = message.content;
                                fileName = FileUtils.GetFileName(message.content);
                                string filePath = Applicate.LocalConfigData.RoomFileFolderPath + fileName;
                                //下载
                                FrmHistoryChat.DownFile(filePath, path);
                            }
                        };
            }
            chatFile.Controls.Add(panel_file);
            chatFile.Size = new Size(xlvMsgs.Width - 20 - 33, 97);
            BindMouseDown(panel_file, message);
            return chatFile;
        }
        #endregion

        #region  数据加载
        // 显示数据
        public void ShowFriendMsg(Friend friend)
        {
            if (!isOpenForm)
            {
                this.Show();
                friends = friend;
                //if (friend.GetRemarkName().Length>15)
                //{
                //    lblNickName.Text = friend.GetRemarkName().Substring(0, 15) + "...";
                //}
                lblNickName.Text = friend.GetRemarkName();
                LodingUtils loding = new LodingUtils();
                loding.parent = xlvMsgs;
                loding.size = xlvMsgs.Size;
                loding.start();
                var views = new List<Control>();
                listData = ShowMsgList(friend.UserId);
                if (listData.Count >= 30)
                {
                    isScrollBar = true;
                }
                BindData(listData);
                loding.stop();
            }
            else
            {
                return;
            }
        }
        //数据绑定
        private void BindData(List<MessageObject> list)
        {
            mAdapter.FrmHistoryChat = this;
            mAdapter.BindFriendData(list);
            xlvMsgs.SetAdapter(mAdapter);
        }

        //显示讲课数据
        public void ShowMessageList(List<MessageObject> datas, string title)
        {
            //昵称
            LodingUtils loding = new LodingUtils();
            loding.parent = xlvMsgs;
            loding.size = xlvMsgs.Size;
            loding.start();
            listData = datas;

            lblNickName.Text = title;
            lblAll.Visible = false;
            lblFile.Visible = false;
            lblImage.Visible = false;
            lblVideo.Visible = false;
            this.Show();
            BindData(datas);
            loding.stop();
        }
        /// <summary>
        /// 文本高宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RichTextBox_Height(object sender, ContentsResizedEventArgs e)
        {
            RichTextBoxEx richText = (RichTextBoxEx)sender;
            richText.Height = e.NewRectangle.Height + 10;
        }
        #endregion

        #region 绑定右键菜单
        // 绑定右键菜单
        public void BindMouseDown(Control item, MessageObject message)
        {
            var copyitem = new MenuItem(LanguageXmlUtils.GetValue("copy", "复制"), (sen, eve) =>
            {
                CopyData(message);
                HttpUtils.Instance.ShowTip("复制成功");
            });
            var sendcard = new MenuItem(LanguageXmlUtils.GetValue("forward", "转发"), (sen, eve) =>
            {
                ForwardMessage(message);
            });
            var colleitem = new MenuItem(LanguageXmlUtils.GetValue("collect", "收藏"), (sen, eve) =>
            {

                CollectUtils.CollectMessage(message);
            });
            var cm = new ContextMenu();
            cm.MenuItems.Add(copyitem);
            cm.MenuItems.Add(sendcard);
            cm.MenuItems.Add(colleitem);
            item.ContextMenu = cm;//设置右键菜单
            item.MouseDown += ClickSelectItem;//设置事件
        }
        //复制数据
        private void CopyData(MessageObject message)
        {
            if (message.type == kWCMessageType.Text || message.type == kWCMessageType.Reply)
            {
                Clipboard.Clear();
                string selected = richText.SelectedText;
                if (selected.Length == 0)
                {
                    Clipboard.SetText(message.content);
                    return;
                }
                //给剪切板设置对象
                Clipboard.SetText(message.content);
            }
            if (message.type == kWCMessageType.Image)
            {
                Clipboard.Clear();
                //给剪切板设置图片对象
                Clipboard.SetImage(pictureBoxImage.Image);
            }
            if (message.type == kWCMessageType.File || message.type == kWCMessageType.Video)
            {
                string fileNames = FileUtils.GetFileName(message.fileName);
                string path = "";
                path = Applicate.LocalConfigData.RoomFileFolderPath + fileNames;
                if (!File.Exists(message.content))
                {
                    DownFile(path, message.content, true);
                }
                else
                {
                    path = message.content;
                }
                Clipboard.Clear();
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                files.Add(path);
                Clipboard.SetFileDropList(files);
            }
        }
        #endregion

        #region 转发消息
        private void ForwardMessage(MessageObject message)
        {
            FrmFriendSelect frm = new FrmFriendSelect();
            frm.LoadFriendsData(1);
            frm.AddConfrmListener((dis) =>
            {
                HttpUtils.Instance.PopView(frm);

                foreach (var friend in dis)
                {
                    if (CollectUtils.EnableForward(friend.Value))
                    {
                        continue;
                    }

                    // 调用 xmpp 转发消息
                    MessageObject msg = ShiKuManager.SendForwardMessage(friend.Value, message);

                    //如果转发对象包括当前聊天对象，给UI添加消息气泡
                    if (Applicate.IsChatFriend(friend.Value.UserId))
                    {
                        //添加消息气泡通知
                        Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                    }
                }
            });
        }

        #endregion


        #region 选中对应项
        private void ClickSelectItem(object sender, EventArgs e)
        {
            Control item = sender as Control;
            MessageObject message = item.Tag as MessageObject;
            //给全局变量赋值
            if (message.type == kWCMessageType.Image)
            {
                //给全局变量赋值
                pictureBoxImage = sender as PictureBox;

            }
            else if (message.type == kWCMessageType.Text)
            {
                richText = sender as RichTextBoxEx;
            }
            else if (message.type == kWCMessageType.Video)
            {
                pictureBoxVideo = sender as ImageViewxVideo;

            }
            else if (message.type == kWCMessageType.File)
            {
                panel_file = sender as FilePanelLeft;
                chatFile = sender as ChatItem;
            }
            else if (message.type == kWCMessageType.Reply)
            {
                richText = sender as RichTextBoxEx;
            }
        }
        #endregion

        #region 图片点击事件
        /// <summary>
        /// 打开图片查看器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseClie(object sender, MouseEventArgs e)
        {
            //获取当前的图片
            PictureBox picture = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                FrmLookImage frm = new FrmLookImage();
                //获取Tag值
                string messageid = (string)picture.Name;
                //清除
                List<MessageObject> listmessage = ShowMsgImageList(friends.UserId);
                //索引
                int index = 0;
                for (int i = 0; i < listmessage.Count; i++)
                {
                    if (listmessage[i].messageId.Equals(messageid))
                    {
                        index = i;
                        break;

                    }
                    frm.fielSize = listmessage[i].fileSize.ToString();
                }
                frm.ShowImageList(listmessage, index);
            }

        }
        //视频播放
        public static void Vido_clike(object sender, MouseEventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                FrmVideoFlash frm = FrmVideoFlash.CreateInstrance();
                frm.VidoShowList((MessageObject)picture.Tag);
                frm.Show();
            }
        }
        #endregion

        #region 数据库查询
        //加载所有
        public static List<MessageObject> ShowMsgList(string toUserid)
        {
            //分页加载数据
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetPageListHistory(1, 30);
            return messages;
        }
        //文件
        public static List<MessageObject> ShowMsgFileList(string toUserid)
        {
            //分页加载数据
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetFileList(1, 30);
            return messages;

        }
        //图片
        public static List<MessageObject> ShowMsgImageList(string toUserid)
        {
            //分页加载数据
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetVideoImageList(1, 30);
            return messages;

        }
        //历史记录
        public static List<MessageObject> ShowMsgHistoryList(string toUserid, string content)
        {
            //分页加载数据
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetPageHotrysList(1, content, 1, 30);
            return messages;

        }
        #endregion

        #region 提取超链接与emaijo表情
        public static void Calc_PanelWidth(Control control)
        {
            if (!(control is RichTextBoxEx richContent))
                return;

            //临时建立一个容器装入内容
            RichTextBoxEx canv_Rich = control as RichTextBoxEx;
            //先取全部Text的值
            canv_Rich.Text = richContent.Text;
            //把code转为emoji
            canv_Rich.Rtf = GetLink(canv_Rich.Text);
            canv_Rich.Font = new Font(Applicate.SetFont, 10);//用来设置字体的，一定不能少，不然会变成默认的宋体了
            richContent.Rtf = canv_Rich.Rtf;
        }
        public static string GetLink(string msgText)
        {
            RichTextBoxEx richTextBox = new RichTextBoxEx();
            richTextBox.Text = msgText;
            MatchCollection msg = Regex.Matches(msgText, @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match match in msg)
            {
                int str_index = richTextBox.Text.IndexOf(match.Value);
                richTextBox.SelectionStart = str_index;
                richTextBox.SelectionLength = match.Value.Length;
                richTextBox.SelectedText = "";
                richTextBox.InsertLink(match.Value);
            }

            //正则表达式

            //emajio表情
            msg = Regex.Matches(richTextBox.Text, @"\[[a-z_-]*\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            emoji_count = msg.Count;
            int index = 0;
            string[] newStr = new string[msg.Count];
            foreach (Match item in msg)
            {
                newStr[index] = item.Groups[0].Value;
                index++;
            }
            //循环替换code为表情图片
            for (int i = 0; i < newStr.Length; i++)
            {
                //bool isMin = friends.userId == Applicate.MyAccount.userId;
                richTextBox.Rtf = richTextBox.Rtf.Replace(newStr[i], EnjoyCodeColor.GetEmojiRtfByCode(newStr[i], Color.White));
                //  richTextBox.Rtf = richTextBox.Rtf.Replace(newStr[i], EmojiCodeDictionary.GetEmojiRtfByCode(newStr[i]));
            }
            string result = richTextBox.Rtf;
            richTextBox.Dispose();
            return result;
        }
        #endregion

        #region 查询消息记录

        public void HistorySearch(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                xlvMsgs.ClearList();
                LodingUtils loding = new LodingUtils();
                loding.parent = xlvMsgs;
                loding.size = xlvMsgs.Size;
                loding.start();
                List<MessageObject> newListData = new List<MessageObject>();

                if (lblAll.Visible)
                {
                    newListData = ShowMsgHistoryList(friends.UserId, content);
                }
                else
                {
                    foreach (var item in listData)
                    {
                        if (item.content.Contains(content))
                        {
                            newListData.Add(item);
                        }
                    }
                }

                mAdapter.isclickFileButton = false;
                BindData(newListData);
                loding.stop();

                lblAll.Text = LanguageXmlUtils.GetValue("search", "搜索");
                SelectedType(lblAll);
                is_check = lblAll;
            }
            else
            {
                mAdapter.isclickFileButton = false;
                BindData(listData);

                lblAll.Text = LanguageXmlUtils.GetValue("history_all", "全部");
                SelectedType(lblAll);
                is_check = lblAll;
            }
        }
        #endregion
        public void SelectedType(Label label)
        {
            if (is_check != null)
            {
                is_check.ForeColor = Color.Black;
            }

            //点击当前
            label.ForeColor = ColorTranslator.FromHtml("#1AAD19");
        }

        #region 导出excel 文件和 txt 文件
        /// <summary>
        /// 获取文件路径
        /// </summary>
        /// <returns></returns>

        public string GetImagePath()
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "请选择文件路径");

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }

            return personImgPath;
        }

        /// <summary>
        /// 获取与该好友的所有聊天记录（不分页)
        /// </summary>
        /// <param name="toUserid"></param>
        /// <returns></returns>
        public static List<MessageObject> ShowAllMsgList(string toUserid)
        {
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.LoadRecordMsg();
            return messages;
        }

        #endregion


        private void lblNickName_TextChanged(object sender, EventArgs e)
        {
            EQControlManager.StrAddEllipsis(lblNickName, lblNickName.Font, this.Width - 40);
        }

        private void lblNext_Click(object sender, EventArgs e)
        {
            CmsChat.Show(lblNext, 0, lblNext.Height);
        }
        /// <summary>
        /// 导出excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemInputEls_Click(object sender, EventArgs e)
        {
            if (!this.MenuItemInputEls.Enabled)
            { return; }
            MenuItemInputEls.Enabled = false;
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "请选择文件路径");

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }

            else
            {
                return;
            }

            var frmSchedule = new FrmSchedule();
            frmSchedule.FormClosed += FrmSchedule_FormClosed;
            frmSchedule.Exportmessage(personImgPath, friends);
            frmSchedule.Compte = () =>
            {


                MenuItemInputEls.Enabled = true;
                HttpUtils.Instance.PopView(frmSchedule);
                ShowTip("导出成功");
            };
        }
        /// <summary>
        ///  导出txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuIteminputTxt_Click(object sender, EventArgs e)
        {
            if (!this.MenuIteminputTxt.Enabled)
            { return; }
            this.MenuIteminputTxt.Enabled = false;
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "请选择文件路径");

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }

            else
            {
                return;
            }
            var frmSchedule = new FrmSchedule();
            frmSchedule.FormClosed += FrmSchedule_FormClosed;
            frmSchedule.ExportTxtmessage(personImgPath, friends);
            frmSchedule.Compte = () =>
            {
                MenuIteminputTxt.Enabled = true;
                HttpUtils.Instance.PopView(frmSchedule);
                ShowTip("导出成功");
            };
        }

        private void FrmSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!MenuIteminputTxt.Enabled)
            {
                MenuIteminputTxt.Enabled = true;
            }
            if (!MenuItemInputEls.Enabled)
            {
                MenuItemInputEls.Enabled = true;
            }

        }

        private void lblNext_MouseEnter(object sender, EventArgs e)
        {
            lblNext.BackColor = ColorTranslator.FromHtml("#E5E5E5");
        }

        private void lblNext_MouseLeave(object sender, EventArgs e)
        {
            lblNext.BackColor = Color.Transparent;
        }
    }
}

