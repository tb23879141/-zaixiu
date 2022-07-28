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
        #region ȫ�ֱ���
        //ѡ�е�label�ؼ�
        public Label is_check;
        public static Friend friends;
        //������Ϣ
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
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//����iconͼ��
            this.Text = LanguageXmlUtils.GetValue("frmHistoryChat_title", "��ʷ��¼");
        }


        #region �������
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
            SearchMessage.tips = LanguageXmlUtils.GetValue("search_history_msgs", "���������¼");
            SearchMessage.SearchEvent += HistorySearch;
            //SearchMessage.ChangeUnselectColor(Color.FromArgb(230, 229, 229));
        }


        //���¹���
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

        #region ������֤
        /// <summary>
        /// ͷ��
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
            //��ȡ��ǰ�ļ�ѡ���ͷ��

            //ͼƬ
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
                //��Ƶ
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
            else if (type == 12)//���
            {
                incoImage.Image = Resources.ic_historyredpacket;

            }
            else if (type == 13)//ת��
            {
                incoImage.Image = Resources.ic_historytransfer;

            }
            else if (type == 56 || type == 55)
            {
                incoImage.Image = Resources.ic_flie_type_voice;
            }
        }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <param name="toFilePath"></param>
        /// <param name="fileUrl"></param>
        public static void DownFile(string toFilePath, string fileUrl, bool isOpen = false)
        {
            HttpDownloader.DownloadFile(fileUrl, toFilePath, (path) =>
            {
                if (!string.IsNullOrEmpty(path))
                {
                    // ���سɹ�
                    LogUtils.Log("���سɹ���" + path);
                    if (!isOpen)
                    {
                        //�򿪴��ļ�
                        System.Diagnostics.Process.Start(path);
                    }
                }
            });
        }
        #endregion

        #region  �ؼ�����¼�
        private void lblAll_Click(object sender, EventArgs e)
        {
            //���ԭ������
            xlvMsgs.ClearList();
            var views = new List<Control>();
            lblAll.Text = LanguageXmlUtils.GetValue("history_all", "ȫ��");

            #region ������ɫ
            Label label = (Label)sender;
            if (is_check != null && is_check != label)
            {
                //�����ǰ
                Font f = new Font(Applicate.SetFont, 12);
                label.ForeColor = ColorTranslator.FromHtml("#1AAD19");
                label.Font = f;
                //���������ť
                Font f2 = new Font(Applicate.SetFont, 12);
                is_check.ForeColor = Color.Black;
                is_check.Font = f2;
                is_check = label;
            }
            #endregion
            #region ȫ��
            if ((Label)sender == lblAll)
            {
                LodingUtils loding = new LodingUtils();
                loding.parent = xlvMsgs;
                loding.size = xlvMsgs.Size;
                loding.start();
                xlvMsgs.Visible = true;
                flpTable.Visible = false;
                //�ж��Ƿ��ڼ���
                mAdapter.isclickFileButton = false;
                mAdapter.FrmHistoryChat = this;
                mAdapter.BindFriendData(listData);
                xlvMsgs.SetAdapter(mAdapter);
                //���²�ѯ
                HistorySearch(SearchMessage.txt_Search.Text);
                loding.stop();
            }
            #endregion
            #region �ļ�
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
            #region ͼƬ
            if ((Label)sender == lblImage)
            {
                type = 3;
                //���
                ImageIngomation();
            }
            #endregion
            #region ��Ƶ
            if ((Label)sender == lblVideo)
            {
                type = 4;
                VdioShow();
            }
            #endregion
        }
        #endregion

        #region ���ط�������
        //��Ƶ
        private void VdioShow()
        {
            //���
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

                    //�󶨵�ǰ����
                    pictureBoxVideo.Tag = item;
                    pictureBoxVideo.MouseClick += new MouseEventHandler(Vido_clike);
                    flpTable.Controls.Add(pictureBoxVideo);
                    BindMouseDown(pictureBoxVideo, item);
                    this.Controls.Add(flpTable);
                }
            }
        }
        //ͼƬ
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
                    //�󶨵�ǰ����
                    pictureBoxImage.Name = item.messageId;
                    pictureBoxImage.Tag = item;
                    pictureBoxImage.MouseClick += new MouseEventHandler(MouseClie);
                    flpTable.Controls.Add(pictureBoxImage);
                    BindMouseDown(pictureBoxImage, item);
                    this.Controls.Add(flpTable);
                }
            }
        }
        //�ļ�
        public ChatItem FileInfonmation(MessageObject message)
        {
            //ʵ�����ؼ�
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
            //        //����
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
                        //����
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
                                //����
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

        #region  ���ݼ���
        // ��ʾ����
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
        //���ݰ�
        private void BindData(List<MessageObject> list)
        {
            mAdapter.FrmHistoryChat = this;
            mAdapter.BindFriendData(list);
            xlvMsgs.SetAdapter(mAdapter);
        }

        //��ʾ��������
        public void ShowMessageList(List<MessageObject> datas, string title)
        {
            //�ǳ�
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
        /// �ı��߿�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RichTextBox_Height(object sender, ContentsResizedEventArgs e)
        {
            RichTextBoxEx richText = (RichTextBoxEx)sender;
            richText.Height = e.NewRectangle.Height + 10;
        }
        #endregion

        #region ���Ҽ��˵�
        // ���Ҽ��˵�
        public void BindMouseDown(Control item, MessageObject message)
        {
            var copyitem = new MenuItem(LanguageXmlUtils.GetValue("copy", "����"), (sen, eve) =>
            {
                CopyData(message);
                HttpUtils.Instance.ShowTip("���Ƴɹ�");
            });
            var sendcard = new MenuItem(LanguageXmlUtils.GetValue("forward", "ת��"), (sen, eve) =>
            {
                ForwardMessage(message);
            });
            var colleitem = new MenuItem(LanguageXmlUtils.GetValue("collect", "�ղ�"), (sen, eve) =>
            {

                CollectUtils.CollectMessage(message);
            });
            var cm = new ContextMenu();
            cm.MenuItems.Add(copyitem);
            cm.MenuItems.Add(sendcard);
            cm.MenuItems.Add(colleitem);
            item.ContextMenu = cm;//�����Ҽ��˵�
            item.MouseDown += ClickSelectItem;//�����¼�
        }
        //��������
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
                //�����а����ö���
                Clipboard.SetText(message.content);
            }
            if (message.type == kWCMessageType.Image)
            {
                Clipboard.Clear();
                //�����а�����ͼƬ����
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

        #region ת����Ϣ
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

                    // ���� xmpp ת����Ϣ
                    MessageObject msg = ShiKuManager.SendForwardMessage(friend.Value, message);

                    //���ת�����������ǰ������󣬸�UI�����Ϣ����
                    if (Applicate.IsChatFriend(friend.Value.UserId))
                    {
                        //�����Ϣ����֪ͨ
                        Messenger.Default.Send(msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                    }
                }
            });
        }

        #endregion


        #region ѡ�ж�Ӧ��
        private void ClickSelectItem(object sender, EventArgs e)
        {
            Control item = sender as Control;
            MessageObject message = item.Tag as MessageObject;
            //��ȫ�ֱ�����ֵ
            if (message.type == kWCMessageType.Image)
            {
                //��ȫ�ֱ�����ֵ
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

        #region ͼƬ����¼�
        /// <summary>
        /// ��ͼƬ�鿴��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseClie(object sender, MouseEventArgs e)
        {
            //��ȡ��ǰ��ͼƬ
            PictureBox picture = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                FrmLookImage frm = new FrmLookImage();
                //��ȡTagֵ
                string messageid = (string)picture.Name;
                //���
                List<MessageObject> listmessage = ShowMsgImageList(friends.UserId);
                //����
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
        //��Ƶ����
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

        #region ���ݿ��ѯ
        //��������
        public static List<MessageObject> ShowMsgList(string toUserid)
        {
            //��ҳ��������
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetPageListHistory(1, 30);
            return messages;
        }
        //�ļ�
        public static List<MessageObject> ShowMsgFileList(string toUserid)
        {
            //��ҳ��������
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetFileList(1, 30);
            return messages;

        }
        //ͼƬ
        public static List<MessageObject> ShowMsgImageList(string toUserid)
        {
            //��ҳ��������
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetVideoImageList(1, 30);
            return messages;

        }
        //��ʷ��¼
        public static List<MessageObject> ShowMsgHistoryList(string toUserid, string content)
        {
            //��ҳ��������
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.GetPageHotrysList(1, content, 1, 30);
            return messages;

        }
        #endregion

        #region ��ȡ��������emaijo����
        public static void Calc_PanelWidth(Control control)
        {
            if (!(control is RichTextBoxEx richContent))
                return;

            //��ʱ����һ������װ������
            RichTextBoxEx canv_Rich = control as RichTextBoxEx;
            //��ȡȫ��Text��ֵ
            canv_Rich.Text = richContent.Text;
            //��codeתΪemoji
            canv_Rich.Rtf = GetLink(canv_Rich.Text);
            canv_Rich.Font = new Font(Applicate.SetFont, 10);//������������ģ�һ�������٣���Ȼ����Ĭ�ϵ�������
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

            //������ʽ

            //emajio����
            msg = Regex.Matches(richTextBox.Text, @"\[[a-z_-]*\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            emoji_count = msg.Count;
            int index = 0;
            string[] newStr = new string[msg.Count];
            foreach (Match item in msg)
            {
                newStr[index] = item.Groups[0].Value;
                index++;
            }
            //ѭ���滻codeΪ����ͼƬ
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

        #region ��ѯ��Ϣ��¼

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

                lblAll.Text = LanguageXmlUtils.GetValue("search", "����");
                SelectedType(lblAll);
                is_check = lblAll;
            }
            else
            {
                mAdapter.isclickFileButton = false;
                BindData(listData);

                lblAll.Text = LanguageXmlUtils.GetValue("history_all", "ȫ��");
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

            //�����ǰ
            label.ForeColor = ColorTranslator.FromHtml("#1AAD19");
        }

        #region ����excel �ļ��� txt �ļ�
        /// <summary>
        /// ��ȡ�ļ�·��
        /// </summary>
        /// <returns></returns>

        public string GetImagePath()
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "��ѡ���ļ�·��");

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }

            return personImgPath;
        }

        /// <summary>
        /// ��ȡ��ú��ѵ����������¼������ҳ)
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
        /// ����excel�ļ�
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
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "��ѡ���ļ�·��");

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
                ShowTip("�����ɹ�");
            };
        }
        /// <summary>
        ///  ����txt�ļ�
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
            dialog.Description = LanguageXmlUtils.GetValue("choose_file_path", "��ѡ���ļ�·��");

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
                ShowTip("�����ɹ�");
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

