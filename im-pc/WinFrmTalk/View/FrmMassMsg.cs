using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Dictionarys;
using WinFrmTalk.Live;
using WinFrmTalk.Model;
using WinFrmTalk.socket;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    // 群发消息
    public partial class FrmMassMsg : FrmBase
    {
        #region private member
        private int emoji_num = 0;          //当前文本框有多少个emoji表情
        public MsgTabAdapter msgTabAdapter = new MsgTabAdapter();   //适配器
        private BatchSendFriendAdapter adrAdapter = null;
        private List<string> emoji_codes = new List<string>();      //记录文本框中的emojiCode
        private Dictionary<string, Friend> addressees = null;       //收信人
        private Dictionary<string, string> SrcImages { get; set; }  //截图，key: file path， value: image rtf

        private List<string> fileCollect_imageRtf = new List<string>();


        private List<string> fileCollect = new List<string>();      //拖拽的文件
        //private static Microsoft.Office.Interop.PowerPoint.Presentation PpointFile;
        //private static Microsoft.Office.Interop.PowerPoint.ApplicationClass myWordApp = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
        #endregion

        #region 拖入控件边界时发生（liuhuan/2019/4/22）
        /// <summary>
        /// 拖入控件边界时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSend_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    //e.Effect = DragDropEffects.Copy;
            //    e.Effect = DragDropEffects.Move;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}
            //如果拖拽的文件是pptx的空文件，会出现生成的图片为空（为解决）
            e.Effect = DragDropEffects.Move;
            String[] supportedFormats = e.Data.GetFormats(true);
            if (supportedFormats != null)
            {
                List<string> sfList = new List<string>(supportedFormats);
                if (sfList.Contains(DataFormats.FileDrop.ToString()))
                {
                    txtSend.EnableAutoDragDrop = false;
                }
                else
                {
                    txtSend.EnableAutoDragDrop = true;

                }
            }
        }
        #endregion

        #region  在完成拖放操作时完成（liuhuan/2019/4/22）
        /// <summary>
        /// 在完成拖放操作时完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSend_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //if (files.Length > 0)
            //    fileCollect.Add(files[0]);
            //foreach (string file in files)
            //{
            //    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //    StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            //    sr.Close();
            //}
            String[] supportedFormats = e.Data.GetFormats(true);
            if (supportedFormats != null)
            {
                List<string> sfList = new List<string>(supportedFormats);
                if (sfList.Contains(DataFormats.FileDrop.ToString()))
                {
                    string[] fileList = (string[])((System.Array)e.Data.GetData(DataFormats.FileDrop));
                    foreach (string fileName in fileList)
                    {
                        FileInfo fileInfo = new FileInfo(fileName);

                        if (Directory.Exists(fileName))//如果是文件夹，不允许生成图片
                        {
                            HttpUtils.Instance.ShowTip("暂不支持文件夹发送");
                            continue;
                        }
                        if (fileInfo.Length == 0 || fileInfo == null)//文件为空的情况
                        {
                            HttpUtils.Instance.ShowTip("文件为空,不允许发送请重新选择");
                            continue;
                        }
                        if (fileName.Contains(".pptx") || fileName.Contains(".ppt"))
                        {

                            //PpointFile = myWordApp.Presentations.Open(fileName, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
                            //PpointFile = myWordApp.Presentations.Open(fileName, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
                            //int pages = PpointFile.Slides.Count;
                            //PpointFile.Close();
                            //if (pages == 0)
                            //{
                            //    HttpUtils.Instance.ShowTip("不允许发送空白ppt");
                            //    continue;
                            //}
                        }
                        if (!fileCollect.Contains(fileName))
                        {
                            fileCollect.Add(fileName);
                            int pic_size = 48;
                            Bitmap bm = WindowsThumbnailProvider.GetThumbnail(fileName, pic_size, pic_size, ThumbnailOptions.None);

                            Clipboard.Clear();
                            Clipboard.SetDataObject(bm, false, 3, 200);//将图片放在剪贴板中
                            if (txtSend.CanPaste(DataFormats.GetFormat(DataFormats.Bitmap)))
                                txtSend.Paste();//粘贴数据

                            //记录添加到文本框的缩略图
                            string img_rtf = EQControlManager.ImageToRtf(bm);
                            fileCollect_imageRtf.Add(img_rtf);
                        }


                    }
                }
            }
            txtSend.EnableAutoDragDrop = true;
        }
        #endregion

        #region liuhuan2019/08/03获取图片的字符串
        /// <summary>
        /// 获取richtextbox所有的图片的纯rtf代码(不包括高度宽度像素等信息)
        /// </summary>
        /// <param name="_ImageList">返回图片rtf字符串列表</param>
        private void ReadImg(ref List<string> _ImageList)
        {
            _ImageList.Clear();
            string _RtfText = txtSend.Rtf;
            while (true)
            {
                int _Index = _RtfText.IndexOf("pichgoal");
                if (_Index == -1) break;
                _RtfText = _RtfText.Remove(0, _Index + 8);
                _Index = _RtfText.IndexOf("\r\n");
                _RtfText = _RtfText.Remove(0, _Index);
                _Index = _RtfText.IndexOf("}");
                _ImageList.Add(_RtfText.Substring(0, _Index).Replace("\r\n", ""));
                _RtfText = _RtfText.Remove(0, _Index);
            }
        }
        #endregion

        #region  发送拖拽后的文件（liuhuan/2019/4/22）
        /// <summary>
        /// 拖拽后点击发送文件
        /// </summary>
        private void DroupFeileSend()
        {
            //if (_ImageList.Count == 0)
            //{
            //    fileCollect.Clear();
            //}
            try
            {
                foreach (string local_path in fileCollect)
                {
                    if (File.Exists(local_path))
                    {
                        bool isVideo = FileUtils.JudgeIsVideoFile(local_path);
                        //如果为视频文件
                        if (isVideo)
                        {
                            //先生成气泡
                            int fileSize = Convert.ToInt32(new FileInfo(local_path).Length);
                            MessageObject vi_msg = ShiKuManager.SendVideoMessage(new Friend(), local_path, local_path, fileSize, false, false);
                            //    SendMsgAndAddBubble(vi_msg, (msg, addressee, ui_msgid, isFirst) =>
                            //    {
                            //        msg.isLoading = 1;
                            //        bool isRefresh = isFirst;

                            //        //获取气泡
                            //        EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                            //        if (talk_panel != null)
                            //        {
                            //            UploadEngine.Instance.From(local_path).
                            //            //上传中

                            //            //上传完成
                            //            UploadFile((success, url) =>
                            //            {
                            //                UploadVideo(talk_panel, msg, url, success, isRefresh);
                            //            });
                            //        }
                            //    });

                            bool isFirstRefreshUI = true;
                            vi_msg.isMassMsg = true;
                            //添加气泡到列表
                            JudgeMsgIsAddToPanel(vi_msg);

                            UploadEngine.Instance.From(local_path).
                                   UploadFile((success, url) =>
                                   {

                                       var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                                       {
                                           //得到一个新的对象
                                           MessageObject chatMessage = GetChatMessage(vi_msg, fd);

                                           chatMessage.isLoading = 1;
                                           bool isRefresh = isFirstRefreshUI;
                                           //获取气泡
                                           EQBaseControl talk_panel = GetTalkPanelByMsg(vi_msg.messageId);
                                           if (talk_panel != null)
                                           {
                                               UploadVideo(talk_panel, chatMessage, url, success, isRefresh);
                                           }

                                           isFirstRefreshUI = false;
                                       });
                                       frmProgressBar.ShowDialog();
                                   });
                        }
                        else
                            UploadFileOrImage(local_path, Convert.ToInt32(new FileInfo(local_path).Length));
                    }
                    else
                        HttpUtils.Instance.ShowTip("路径不存在：" + local_path);
                }
            }
            catch (Exception ex) { LogHelper.log.Error("----------发送拖拽后的文件出错：方法（DroupFeileSend）\n" + ex.Message); }
            //txtSend.Clear();
            fileCollect.Clear();
        }
        #endregion

        #region 实例化和加载，绑定收信人
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmMassMsg_title", this.Text);
            btnSend.Text = LanguageXmlUtils.GetValue("btn_send", btnSend.Text);
        }

        /// <summary>
        /// 打开群发消息窗体
        /// </summary>
        /// <param name="addressees">收信人（复数）</param>
        public FrmMassMsg(Dictionary<string, Friend> addressees)
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            this.addressees = addressees;
            #region msg列表的适配器
            msgTabAdapter = new MsgTabAdapter
            {
                xListView = this.xListView
            };
            msgTabAdapter.direction = false;        //倒序排列
            Friend myUser = new Friend()
            {
                UserId = Applicate.MyAccount.userId,
                NickName = Applicate.MyAccount.nickname,
                IsGroup = 0
            };
            msgTabAdapter.choose_target = myUser;
            //BubbleBgDictionary.RemoveAllBg();       //移除所有缓存的背景图
            //msgTabAdapter.BindData(msgList);        //绑定数据源
            xListView.SetAdapter(msgTabAdapter);    //绑定适配器
            #endregion
        }

        private void FrmMassMsg_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            try
            {
                #region 收信人列表的适配器
                adrAdapter = new BatchSendFriendAdapter();
                if (addressees != null || addressees.Count > 0)
                    BindData_Addressees(addressees);
                #endregion

                //允许拖拽(liuhuan)
                txtSend.AllowDrop = true;
                txtSend.DragDrop += TxtSend_DragDrop;
                txtSend.DragEnter += TxtSend_DragEnter;

                #region 录音回调
                userSoundRecording.nr.PathCallback = (localPath, timespan) =>
                {
                    //修改焦点
                    txtSend.Focus();
                    int timeLen = (int)timespan.TotalSeconds;
                    int fileSize = Convert.ToInt32(new FileInfo(localPath).Length);
                    //先生成气泡
                    MessageObject vo_msg = ShiKuManager.SendVoiceMessage(new Friend(), "", localPath, fileSize, timeLen, false, false);

                    //SendMsgAndAddBubble(vo_msg, (msg, addressee, ui_msgid, isFirst) =>
                    //{
                    //    bool isRefresh = isFirst;
                    //    //上传音频文件
                    //    UploadEngine.Instance.From(localPath).
                    //        UploadFile((success, url) =>
                    //        {
                    //            if (success)
                    //            {
                    //                msg.content = url;
                    //                msg.UpdateMessageContent();
                    //                ShiKuManager.mSocketCore.SendMessage(msg);

                    //                if (isRefresh)
                    //                {
                    //                    //获取控件并转化文件
                    //                    EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                    //                    var result = talk_panel.Controls.Find("crl_content", true);
                    //                    if (result.Length > 0 && result[0] is Panel panel_voice && talk_panel is EQVoiceControl voice_crl)
                    //                    {
                    //                        voice_crl.DownloadAndChangeVoice(panel_voice);
                    //                    }
                    //                }
                    //            }
                    //        });
                    //});

                    bool isFirstRefreshUI = true;
                    vo_msg.isMassMsg = true;
                    //添加气泡到列表
                    JudgeMsgIsAddToPanel(vo_msg);

                    UploadEngine.Instance.From(localPath).
                           UploadFile((success, url) =>
                           {

                               var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                               {
                                   //得到一个新的对象
                                   MessageObject chatMessage = GetChatMessage(vo_msg, fd);

                                   chatMessage.isLoading = 1;
                                   bool isRefresh = isFirstRefreshUI;

                                   chatMessage.content = url;
                                   chatMessage.UpdateMessageContent();
                                   ShiKuManager.mSocketCore.SendMessage(chatMessage);

                                   if (isRefresh)
                                   {
                                       //获取控件并转化文件
                                       EQBaseControl talk_panel = GetTalkPanelByMsg(vo_msg.messageId);
                                       var result = talk_panel.Controls.Find("crl_content", true);
                                       if (result.Length > 0 && result[0] is Panel panel_voice && talk_panel is EQVoiceControl voice_crl)
                                       {
                                           voice_crl.DownloadAndChangeVoice(panel_voice);
                                       }
                                   }

                                   isFirstRefreshUI = false;
                               });
                               frmProgressBar.ShowDialog();
                           });

                };
                #endregion
            }
            catch (Exception ex) { LogHelper.log.Error("----加载控件出错，方法（FrmMassMsg_Load）: \r\n" + ex.Message); }
            finally { this.ResumeLayout(); }

        }

        private void BindData_Addressees(Dictionary<string, Friend> addressess)
        {
            string content = "你将发消息给" + addressess.Count() + "位好友";
            lblAdrNum.Text = LanguageXmlUtils.GetValue("frmMassMsg_tips", content).Replace("%s", addressess.Count().ToString());

            //Action<string> remove_item = (userId) =>
            //{
            //    if(this.addressees.Count() < 2)
            //    {
            //        this.Close();
            //    }

            //    //获取收信人控件
            //    var result = Addressees_Panel.Controls.Find("adr_" + userId, false);
            //    if (result.Count() < 0)
            //        return;

            //    for (int i = 0; i < result.Count(); i++)
            //    {
            //        if (result[i] is AddresseeItem)
            //        {
            //            this.Addressees_Panel.Controls.Remove(result[i]);
            //            this.addressees.Remove(userId);
            //            lblAdrNum.Text = "你将发消息给" + this.addressees.Count() + "位好友";
            //            return;
            //        }
            //    }
            //};

            //foreach (Friend fd_item in addressess.Values)
            //{
            //    AddresseeItem adr_item = new AddresseeItem(remove_item);
            //    adr_item.Name = "adr_" + fd_item.UserId;
            //    adr_item.UserId = fd_item.UserId;
            //    string name = string.IsNullOrWhiteSpace(fd_item.RemarkName) ? fd_item.NickName : fd_item.RemarkName;
            //    adr_item.SetAddresseeName(name);
            //    //Addressees_Panel.Controls.Add(adr_item);
            //}

            List<Friend> friends = addressees.Values.ToList();
            adrAdapter.BindDatas(friends);
            xlvAddressees.SetAdapter(adrAdapter);
        }

        /// <summary>
        /// 发送消息并添加气泡（更新UI）
        /// </summary>
        /// <param name="plmp_Msg">polymorphism message</param>
        /// <param name="sendAction">
        /// <para>string: ui_msgid, MessageObject: xmpp_msg, Friend: toUser</para>
        /// 不同消息类型的发送方法
        /// </param>
        private void SendMsgAndAddBubble(MessageObject plmp_Msg, Action<MessageObject, Friend, string, bool> sendAction)
        {
            bool isFirstRefreshUI = true;
            plmp_Msg.isMassMsg = true;
            //添加气泡到列表
            JudgeMsgIsAddToPanel(plmp_Msg);

            var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
            {
                //如果为群组，自己为隐身人或者被禁言
                //

                string ui_msgid = plmp_Msg.messageId;
                //得到一个新的对象
                MessageObject chatMessage = GetChatMessage(plmp_Msg, fd);
                //发送消息
                sendAction(chatMessage, fd, ui_msgid, isFirstRefreshUI);
                isFirstRefreshUI = false;
            });
            frmProgressBar.ShowDialog();
        }
        /// <summary>
        /// 发送消息并添加气泡（不更新UI）
        /// </summary>
        /// <param name="plmp_Msg"></param>
        /// <param name="sendAction"></param>
        private void SendMsgAndAddBubble(MessageObject plmp_Msg, Action<MessageObject, Friend> sendAction)
        {
            plmp_Msg.isMassMsg = true;
            //添加气泡到列表
            JudgeMsgIsAddToPanel(plmp_Msg);
            Invoke(new Action(() =>
            {
                var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                {
                    //如果为群组，自己为隐身人或者被禁言
                    //

                    //得到一个新的对象
                    MessageObject chatMessage = GetChatMessage(plmp_Msg, fd);
                    //发送消息
                    sendAction(chatMessage, fd);
                });
                frmProgressBar.ShowDialog();
                //frmSchedule.ShowDialog(this);
                //frmSchedule.Dispose();
            }));
        }

        private MessageObject GetChatMessage(MessageObject msg, Friend fd)
        {
            MessageObject chatMessage = msg.CopyMessage();
            chatMessage.ToId = fd.UserId;
            chatMessage.toUserId = fd.UserId;    //接收者
            chatMessage.toUserName = fd.NickName;
            chatMessage.messageId = Guid.NewGuid().ToString("N");  //生成Guid
            if (fd.IsGroup == 1)
            {
                chatMessage.isGroup = 1;

                // 获取我的群名片
                string nickName = new RoomMember() { roomId = fd.RoomId, userId = chatMessage.FromId }.GetNickName();
                if (!UIUtils.IsNull(nickName))
                {
                    chatMessage.fromUserName = nickName;
                }
            }
            chatMessage.InsertData();

            return chatMessage;
        }
        #endregion

        #region 发送消息

        #region 发送按钮发送
        private void BtnSend_Click(object sender, EventArgs e)
        {
            //选择对象不能为空
            if (addressees == null || addressees.Count < 1)
                return;
            if (txtSend.Text == null)
            { return; }

            if (fileCollect != null && fileCollect.Count > 0)
            {
                DroupFeileSend();
            }

            try
            {
                //保存变量，异步执行会导致变量出错
                string strSend = txtSend.Text;
                string rtfSend = txtSend.Rtf;
                int eji_num = emoji_num;
                List<string> eji_codes = emoji_codes;
                int at_count = atCount;
                List<Friend> atFriends = list_atFriends;
                if (this.SrcImages == null)
                {
                    this.SrcImages = new Dictionary<string, string>();
                }
                Dictionary<string, string> SrcImages = this.SrcImages.Copy();
                List<string> fileCollect_imageRtf = new List<string>();

                if (this.fileCollect_imageRtf != null)
                {
                    fileCollect_imageRtf = this.fileCollect_imageRtf.Copy();
                }

                Thread sendThread = new Thread(() =>
                {
                    //输入不能为空
                    if (string.IsNullOrEmpty(strSend) && eji_num < 1)
                    {
                        //不存在图片
                        if (!EQControlManager.JudgeRtfHaveImg(rtfSend))
                            return;
                    }

                    //emoji表情转为code
                    if (eji_codes != null && eji_codes.Count > 0)
                        rtfSend = ShowMsgPanel.EmojiPngToCode(rtfSend, eji_codes);
                    //用于rtf的转化
                    using (RichTextBox richTextBox = new RichTextBox())
                    {
                        richTextBox.Rtf = rtfSend;

                        #region 解析图片并单独发送
                        try
                        {
                            //用正则表达式，获取图片rtf
                            //MatchCollection matchs = Regex.Matches(richTextBox.Rtf, @"{\\object[^}]+}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            //foreach (Match item in matchs)
                            //{
                            //    richTextBox.Rtf = richTextBox.Rtf.Replace(item.Value, "");
                            //}

                            //List<Image> list_images = new List<Image>();

                            //先移除所有文件缩略图图片，避免错误发送
                            foreach (string value in fileCollect_imageRtf)
                            {
                                richTextBox.Rtf = richTextBox.Rtf.Replace(value, "");
                            }

                            //通过粘贴剪切图片等正常途径添加的图片
                            foreach (string filePath in SrcImages.Keys)
                            {
                                string old_rtf = richTextBox.Rtf;
                                string img_rtf = SrcImages[filePath].Replace("{\\*\\picprop{\\sp{\\sn wzDescription}{\\sv Image}}{\\sp{\\sn posv}{\\sv 1}}\r\n}\\pngblip", "\\wmetafile8");
                                //var result = old_rtf.Split(new string[] { img_rtf }, StringSplitOptions.None);
                                int pic_num = old_rtf.Split(new string[] { img_rtf }, StringSplitOptions.None).Length - 1;
                                richTextBox.Rtf = richTextBox.Rtf.Replace(img_rtf, "");
                                //如果图片已经从文本框删除
                                if (old_rtf.Equals(richTextBox.Rtf))
                                    continue;



                                //保存图片到本地
                                //string filePath = EQControlManager.RtfToImageSave(item.Value);

                                //可能发送多张相同的图片
                                for (int index = 0; index < pic_num; index++)
                                {
                                    //发送图片
                                    if (!string.IsNullOrEmpty(filePath))
                                    {
                                        MessageObject img_msg = ShiKuManager.SendImageMessage(new Friend(), "", filePath, Convert.ToInt32(new FileInfo(filePath).Length), false, false);
                                        ////进入循环发送
                                        //SendMsgAndAddBubble(img_msg, (msg, addressee, ui_msgid, isFirst) =>
                                        //{
                                        //    bool isRefresh = isFirst;
                                        //    //上传完成
                                        //    UploadEngine.Instance.From(filePath).
                                        //        UploadFile((success, url_path) =>
                                        //        {
                                        //            MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(ui_msgid);    //能获取到代表已添加到气泡列表中
                                        //            if (t_msg != null && isRefresh)
                                        //            {
                                        //                //修改气泡的图片和样式
                                        //                EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                                        //                UploadImage(talk_panel, msg, url_path, success);
                                        //            }
                                        //            //如果聊天列表没有该消息，则不更新UI只发送
                                        //            else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                        //            {
                                        //                msg.content = url_path;
                                        //                msg.UpdateData();

                                        //                ShiKuManager.mSocketCore.SendMessage(msg);
                                        //            }
                                        //        });
                                        //});
                                        bool isFirstRefreshUI = true;
                                        img_msg.isMassMsg = true;
                                        //添加气泡到列表
                                        JudgeMsgIsAddToPanel(img_msg);

                                        UploadEngine.Instance.From(filePath).
                                               UploadFile((success, url) =>
                                               {

                                                   var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                                                   {
                                                       //得到一个新的对象
                                                       MessageObject chatMessage = GetChatMessage(img_msg, fd);

                                                       chatMessage.isLoading = 1;
                                                       bool isRefresh = isFirstRefreshUI;

                                                       MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(img_msg.messageId);    //能获取到代表已添加到气泡列表中
                                                       if (t_msg != null && isRefresh)
                                                       {
                                                           //修改气泡的图片和样式
                                                           EQBaseControl talk_panel = GetTalkPanelByMsg(img_msg.messageId);
                                                           UploadImage(talk_panel, chatMessage, url, success);
                                                       }
                                                       //如果聊天列表没有该消息，则不更新UI只发送
                                                       else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                                       {
                                                           chatMessage.content = url;
                                                           chatMessage.UpdateData();
                                                           ShiKuManager.mSocketCore.SendMessage(chatMessage);     //指定发送的UserId
                                                                                                                  //ShiKuManager.mSocketCore.SendMessage(msg);
                                                       }

                                                       isFirstRefreshUI = false;
                                                   });
                                                   frmProgressBar.ShowDialog();
                                               });
                                    }
                                }
                            }
                            //通过其他渠道在文本框添加的图片（如输入法的表情）
                            if (EQControlManager.JudgeRtfHaveImg(richTextBox.Rtf))
                            {
                                //用正则表达式，获取图片rtf
                                MatchCollection matchs = Regex.Matches(richTextBox.Rtf, @"{\\pict[^}]+}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                                foreach (Match item in matchs)
                                {
                                    string item_rtf = item.Value;
                                    Image img = EQControlManager.RtfToImageSave(item_rtf);
                                    string filePath = Applicate.LocalConfigData.ImageFolderPath + Guid.NewGuid().ToString("N") + ".png";
                                    img.Save(filePath);

                                    //添加气泡到列表
                                    MessageObject msg_item = ShiKuManager.SendImageMessage(new Friend(), "", filePath, Convert.ToInt32(new FileInfo(filePath).Length), false, false);

                                    bool isFirstRefreshUI = true;
                                    msg_item.isMassMsg = true;
                                    //添加气泡到列表
                                    JudgeMsgIsAddToPanel(msg_item);

                                    //SendMsgAndAddBubble(msg_item, (msg, addressee, ui_msgid, isFirst) =>
                                    //{
                                    //    bool isRefresh = isFirst;
                                    //    //上传完成
                                    //    UploadEngine.Instance.From(filePath).
                                    //        UploadFile((success, url_path) =>
                                    //        {
                                    //            MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(ui_msgid);
                                    //            if (t_msg != null && isRefresh)
                                    //            {
                                    //                //修改气泡的图片和样式
                                    //                EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                                    //                UploadImage(talk_panel, msg, url_path, success);
                                    //            }
                                    //            //如果聊天列表没有该消息，则不更新UI只发送
                                    //            else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                    //            {
                                    //                msg.content = url_path;
                                    //                msg.UpdateData();

                                    //                ShiKuManager.mSocketCore.SendMessage(msg);
                                    //            }
                                    //        });
                                    //});

                                    UploadEngine.Instance.From(filePath).
                                           UploadFile((success, url) =>
                                           {
                                               var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                                               {
                                                   //得到一个新的对象
                                                   MessageObject chatMessage = GetChatMessage(msg_item, fd);

                                                   chatMessage.isLoading = 1;
                                                   bool isRefresh = isFirstRefreshUI;

                                                   MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(msg_item.messageId);    //能获取到代表已添加到气泡列表中
                                                   if (t_msg != null && isRefresh)
                                                   {
                                                       //修改气泡的图片和样式
                                                       EQBaseControl talk_panel = GetTalkPanelByMsg(msg_item.messageId);
                                                       UploadImage(talk_panel, chatMessage, url, success);
                                                   }
                                                   //如果聊天列表没有该消息，则不更新UI只发送
                                                   else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                                   {
                                                       chatMessage.content = url;
                                                       chatMessage.UpdateData();
                                                       ShiKuManager.mSocketCore.SendMessage(chatMessage);     //指定发送的UserId
                                                                                                              //ShiKuManager.mSocketCore.SendMessage(msg);
                                                   }

                                                   isFirstRefreshUI = false;
                                               });
                                               frmProgressBar.ShowDialog();
                                           });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.log.Error("----解析图片出错，方法（btnSend_Click） : " + ex.Message);
                        }
                        #endregion

                        //发送文本消息
                        try
                        {
                            if (!string.IsNullOrEmpty(strSend) && !string.IsNullOrWhiteSpace(richTextBox.Text))
                            {
                                //如果是长文本消息
                                if (richTextBox.Text.Length > 3000)
                                    SendTxtFile_LongTextMsg(richTextBox.Text.TrimEnd());
                                else
                                {
                                    // 修改搜狗输入法回车后直接发出文字的问题#7303
                                    var textarray = richTextBox.Text.ToArray();
                                    if (textarray.Length > 0)
                                    {
                                        char cc = textarray[textarray.Length - 1];
                                        if (10 != cc && sender == null)
                                        {
                                            return;
                                        }
                                    }

                                    MessageObject txt_msg = null;
                                    // 修改禅道7938
                                    //if (at_count > 0 && !UIUtils.IsNull(atFriends))
                                    //{
                                    //    atFriends = atFriends.FindIndex(f => f.UserId.Equals("allRoomMember")) > -1 ? new List<Friend>() : atFriends;
                                    //    txt_msg = ShiKuManager.SendAtMessage(null, atFriends, richTextBox.Text, false);
                                    //}
                                    //else
                                    txt_msg = ShiKuManager.SendTextMessage(new Friend(), richTextBox.Text.TrimEnd(), false, false);
                                    SendMsgAndAddBubble(txt_msg, (msg, addressee) =>
                                    {
                                        ShiKuManager.mSocketCore.SendMessage(msg);     //指定发送的UserId
                                    });
                                }
                            }


                            //清空发送框
                            txtSend.Focus();
                            txtSend.Clear();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.log.Error("----发送文本消息出错，方法（btnSend_Click） : " + ex.Message);
                        }
                    }

                });
                if (this.IsHandleCreated)
                {
                    sendThread.SetApartmentState(ApartmentState.STA);
                    sendThread.Start();
                }
            }
            catch (Exception ex) { LogHelper.log.Error("----发送消息出错，方法（btnSend_Click） : " + ex.Message, ex); }

            emoji_num = 0;
            atCount = 0;
            list_atFriends = new List<Friend>();
            this.fileCollect_imageRtf = new List<string>();
        }
        #endregion

        #region 长文本转文件消息发送
        private void SendTxtFile_LongTextMsg(string txt_msg)
        {
            //保存的本地路径   //文件命名规则：2019-06-25 时间戳
            string local_path = Applicate.LocalConfigData.FileFolderPath +
                string.Format(@"文件({0}).txt", DateTime.Now.ToString("yyyy-MM-dd") + " " + TimeUtils.CurrentIntTime());
            FileStream fs = new FileStream(local_path, FileMode.OpenOrCreate);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine(txt_msg);
            wr.Close();

            //上传并发送文件
            int file_size = Convert.ToInt32(new FileInfo(local_path).Length);
            UploadFileOrImage(local_path, file_size);
        }
        #endregion

        #endregion


        #region Send File

        #region 上传文件
        private void UploadFileOrImage(string fileLocation, int fileSize)
        {
            try
            {
                if (fileSize > 314572800)
                {
                    HttpUtils.Instance.ShowTip("文件大小不能大于300M");
                    return;
                }
                if (JudgeIsImage(fileLocation))
                {
                    MessageObject msg = ShiKuManager.SendImageMessage(new Friend(), "", fileLocation, fileSize, false, false);
                    //SendMsgAndAddBubble(msg, (msg_flie, addressee, ui_msgid, isFirst) =>
                    //{
                    //    bool isRefresh = isFirst;
                    //    UploadEngine.Instance.From(fileLocation).
                    //    //上传完成
                    //    UploadFile((success, url) =>
                    //    {
                    //        MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(ui_msgid);    //能获取到代表已添加到气泡列表中
                    //        if (t_msg != null && isRefresh)
                    //        {
                    //            //修改气泡的图片和样式
                    //            EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                    //            UploadImage(talk_panel, msg, url, success);
                    //        }
                    //        //如果聊天列表没有该消息，则不更新UI只发送
                    //        else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                    //        {
                    //            msg.content = url;
                    //            msg.UpdateData();
                    //            ShiKuManager.mSocketCore.SendMessage(msg_flie);     //指定发送的UserId
                    //                                                                //ShiKuManager.mSocketCore.SendMessage(msg);
                    //        }
                    //    });

                    //});
                    bool isFirstRefreshUI = true;
                    msg.isMassMsg = true;
                    //添加气泡到列表
                    JudgeMsgIsAddToPanel(msg);

                    UploadEngine.Instance.From(fileLocation).
                           UploadFile((success, url) =>
                           {

                               var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                               {
                                   //得到一个新的对象
                                   MessageObject chatMessage = GetChatMessage(msg, fd);

                                   chatMessage.isLoading = 1;
                                   bool isRefresh = isFirstRefreshUI;

                                   MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(msg.messageId);    //能获取到代表已添加到气泡列表中
                                   if (t_msg != null && isRefresh)
                                   {
                                       //修改气泡的图片和样式
                                       EQBaseControl talk_panel = GetTalkPanelByMsg(msg.messageId);
                                       UploadImage(talk_panel, chatMessage, url, success);
                                   }
                                   //如果聊天列表没有该消息，则不更新UI只发送
                                   else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                   {
                                       chatMessage.content = url;
                                       chatMessage.UpdateData();
                                       ShiKuManager.mSocketCore.SendMessage(chatMessage);     //指定发送的UserId
                                                                                              //ShiKuManager.mSocketCore.SendMessage(msg);
                                   }

                                   isFirstRefreshUI = false;
                               });
                               frmProgressBar.ShowDialog();
                           });
                }
                else
                {
                    MessageObject msg = ShiKuManager.SendFileMessage(new Friend(), "", fileLocation, fileSize, false, false);

                    bool isFirstRefreshUI = true;
                    msg.isMassMsg = true;
                    //添加气泡
                    JudgeMsgIsAddToPanel(msg);

                    bool isRefresh = true;
                    //获取气泡
                    EQBaseControl talk_panel = GetTalkPanelByMsg(msg.messageId);

                    if (talk_panel == null)
                        return;

                    if (talk_panel is EQFileControl fileControl)
                    {
                        UploadEngine.Instance.From(fileLocation).
                        //上传中
                        UpProgress((progress) =>
                        {
                            if (isRefresh)
                            {
                                fileControl.isDownloading = true;
                                //获取到文件的panel
                                if (talk_panel.Controls.Find("image_panel", true).Length > 0 && talk_panel.Controls.Find("image_panel", true)[0] is Panel image_panel)
                                    if (image_panel.Controls.Find("crl_content", true).Length > 0 && image_panel.Controls.Find("crl_content", true)[0] is FilePanelLeft filePanel)
                                    {
                                        filePanel.lab_lineLime.BringToFront();
                                        int pro_width = Convert.ToInt32(filePanel.lab_lineSilver.Width * ((decimal)progress / 100));
                                        if (pro_width > filePanel.lab_lineLime.Width)
                                            filePanel.lab_lineLime.Width = pro_width;
                                        if ((progress / 100) == 1)
                                            filePanel.lab_lineLime.Width = 0;
                                    }
                            }
                        }).
                        UpSpeed((speed) =>
                        {
                            if (isRefresh)
                            {
                                //获取到文件的panel
                                if (talk_panel.Controls.Find("image_panel", true).Length > 0 && talk_panel.Controls.Find("image_panel", true)[0] is Panel image_panel)
                                    if (image_panel.Controls.Find("crl_content", true).Length > 0 && image_panel.Controls.Find("crl_content", true)[0] is FilePanelLeft filePanel)
                                    {
                                        filePanel.lblSpeed.Visible = true;
                                        filePanel.lblSpeed.BringToFront();
                                        filePanel.lblSpeed.Text = speed + @"/s";
                                    }
                            }
                        }).
                        //上传完成
                        UploadFile((success, url) =>
                        {
                            fileControl.isDownloading = false;
                            //获取到文件的panel
                            if (talk_panel.Controls.Find("image_panel", true).Length > 0 && talk_panel.Controls.Find("image_panel", true)[0] is Panel image_panel)
                                if (image_panel.Controls.Find("crl_content", true).Length > 0 && image_panel.Controls.Find("crl_content", true)[0] is FilePanelLeft filePanel)
                                    //关闭下载速度
                                    filePanel.lblSpeed.Visible = false;

                            msg.content = url;
                            msg.UpdateData();
                            if (success)
                            {
                                string localPath = Applicate.LocalConfigData.FileFolderPath + FileUtils.GetFileName(msg.fileName);
                                if (File.Exists(localPath))//如果对应文件存在 先删除文件(再下载文件)
                                {
                                    try
                                    {
                                        var r = new Random(Guid.NewGuid().GetHashCode());//产生不重复的随机数
                                        string filename = FileUtils.GetFileName(msg.fileName);
                                        string suffix = FileUtils.GetFileExtension(msg.fileName);//取出后缀
                                        string filename1 = filename.Replace(suffix, "") + "(" + r.Next(0, 1000) + ")" + suffix;//合成名称
                                        msg.fileName = Applicate.LocalConfigData.FileFolderPath + filename1;//重新赋值
                                        msg.UpdateFilename();
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }

                                var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                                {
                                    //如果为群组，自己为隐身人或者被禁言
                                    //

                                    string ui_msgid = msg.messageId;
                                    //得到一个新的对象
                                    MessageObject chatMessage = GetChatMessage(msg, fd);
                                    //发送消息
                                    ShiKuManager.mSocketCore.SendMessage(chatMessage);     //指定发送的UserId

                                    //sendAction(chatMessage, fd, ui_msgid, isFirstRefreshUI);
                                    isFirstRefreshUI = false;

                                    isRefresh = isFirstRefreshUI;
                                });
                                frmProgressBar.ShowDialog();

                                //SendMsgAndAddBubble(msg, (msg_flie, addressee, ui_msgid, isFirst) =>
                                //{

                                //if (msg.messageId != msg_flie.messageId)
                                //{

                                //}
                                //});
                                //ShiKuManager.mSocketCore.SendMessage(msg);
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("----上传文件出错，方法（UploadFileOrImage） : " + ex.Message, ex);
            }
        }
        #endregion

        #region 上传图片
        private void UploadImage(EQBaseControl talk_panel, MessageObject msg, string url, bool success)
        {
            #region 更新msg
            //上传失败
            if (string.IsNullOrEmpty(url) || !success)
            {
                msg.isSend = -1;
                msg.content = "error";
                msg.UpdateData();
            }
            else
            {
                msg.content = url;
                msg.UpdateData();
                ShiKuManager.mSocketCore.SendMessage(msg);
            }
            #endregion

            #region 更新UI
            //msg = msgTabAdapter.TargetMsgData.GetMsg(msg.messageId);
            //if (msg == null)
            //    return;
            //修改气泡的图片和样式
            talk_panel.messageObject.content = msg.content;
            if (talk_panel is EQImageControl imageCrl)
            {
                if (imageCrl.Controls.Find("crl_content", true).Length > 0 && imageCrl.Controls.Find("crl_content", true)[0] is PictureBox pic_image)
                {
                    //上传失败
                    if (string.IsNullOrEmpty(url) || !success)
                    {
                        //关闭等待符
                        if (pic_image.Controls.Find("loding", true).Length > 0 && pic_image.Controls.Find("loding", true)[0] is USELoding loding)
                        {
                            loding.Dispose();
                            Helpers.ClearMemory();
                        }
                        //var result = imageCrl.Controls.Find("lab_msg", false);
                        //if (result.Length > 0 && result[0] is Label lab_msg)
                        //    EQControlManager.DrawIsSend(msg, lab_msg);
                    }
                    else
                    {
                        imageCrl.LoadImage(pic_image);
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 上传视频
        private void UploadVideo(EQBaseControl talk_panel, MessageObject msg, string url, bool success, bool refresh_ui)
        {
            #region 更新msg
            //上传失败
            if (string.IsNullOrEmpty(url) || !success)
            {
                msg.isSend = -1;
                msg.content = "error";
                msg.UpdateData();
            }
            else
            {
                msg.content = url;
                msg.UpdateData();
                ShiKuManager.mSocketCore.SendMessage(msg);
            }
            #endregion

            #region 更新ui
            if (msg != null && refresh_ui)
            {
                //if (string.IsNullOrWhiteSpace(talk_panel.messageObject.content))
                talk_panel.messageObject.content = msg.content;
                //修改气泡的图片和样式
                if (talk_panel is EQVideoControl videoCrl)
                {
                    var video_result = videoCrl.Controls.Find("crl_content", true);
                    if (video_result.Length > 0 && video_result[0] is PictureBox pic_content)
                    {
                        //上传失败
                        if (string.IsNullOrEmpty(url) || !success)
                        {
                            var loding_result = pic_content.Controls.Find("loding", true);
                            //关闭等待符
                            if (loding_result.Length > 0 && loding_result[0] is USELoding loding)
                            {
                                loding.Dispose();
                                Helpers.ClearMemory();
                            }
                            //var result = videoCrl.Controls.Find("lab_msg", false);
                            //if (result.Length > 0 && result[0] is Label lab_msg)
                            //    EQControlManager.DrawIsSend(msg, lab_msg);
                        }
                        else
                        {
                            videoCrl.LoadVideo(pic_content);
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 判断是否为图片
        private bool JudgeIsImage(string fileName)
        {
            try
            {

                if (!File.Exists(fileName))
                {
                    return false;
                }

                string extension = FileUtils.GetFileExtension(fileName);

                if (UIUtils.IsNull(extension))
                {
                    return false;
                }

                if (string.Equals(".jpg", extension.ToLower()))
                {
                    return true;
                }

                if (string.Equals(".jpeg", extension.ToLower()))
                {
                    return true;
                }

                if (string.Equals(".gif", extension.ToLower()))
                {
                    return true;
                }

                if (string.Equals(".png", extension.ToLower()))
                {
                    return true;
                }

                if (string.Equals(".bmp", extension.ToLower()))
                {
                    return true;
                }
                if (string.Equals(".jpeg", extension.ToLower()))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("----JudgeIsImage : " + ex.Message, ex);
            }
            return false;
        }
        #endregion
        #endregion


        #region 文本框事件
        #region 发送消息文本框，文本变更事件
        private bool isChangingEmoji = false;   //是否正在转换emoji表情
        private int txtChangedState = 1;    //0为正在选择@成员，不再弹出好友选择器
        private int atCount = 0;    //@的人数
        private List<Friend> list_atFriends = new List<Friend>();
        private void TxtSend_TextChanged(object sender, EventArgs e)
        {
            #region 修改emojiCode转图片
            //正在转化emoji表情
            if (!isChangingEmoji)
            {
                if (string.IsNullOrEmpty(txtSend.Text) || txtSend.Text.IndexOf("[") < 0)
                    return;

                Console.WriteLine("TextChanged_Emoji");
                //匹配符合规则的表情code
                //MatchCollection matchs = Regex.Matches(txtSend.Text, @"\[[a-z_-]*\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                //if (matchs.Count > 0)
                //{
                isChangingEmoji = true;
                txtSend.SuspendLayout();
                try
                {
                    bool isParallel = false;
                    string[] rtfs = txtSend.Rtf.Split(']');
                    Parallel.For(0, rtfs.Length, (index, loopState) =>
                    //Parallel.ForEach(rtfs.OfType<string>(), rtf =>
                    {
                        if (string.IsNullOrEmpty(rtfs[index]) || rtfs[index].IndexOf("[") < 0)
                            loopState.Break();
                        //匹配符合规则的表情code
                        MatchCollection matchs = Regex.Matches(rtfs[index] + "]", @"\[[a-z_-]*\]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        if (matchs.Count > 0)
                        {
                            string emoji_rtf = EmojiCodeDictionary.GetEmojiRtfByCode(matchs[0].Value);
                            if (!string.IsNullOrEmpty(emoji_rtf))
                            {
                                isParallel = true;
                                emoji_codes.Add(matchs[0].Value);
                                rtfs[index] = (rtfs[index] + "]").Replace(matchs[0].Value, emoji_rtf);
                            }

                        }
                    });

                    // 修改禅道#6891 还是会有问题
                    if (isParallel)
                    {
                        string new_rtf = string.Empty;
                        for (int i = 0; i < rtfs.Length; i++)
                        {
                            new_rtf += rtfs[i];
                        }
                        txtSend.Rtf = new_rtf;//rtf赋值
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.log.Error("----转化emoji出错，方法（txtSend_TextChanged） : " + ex.Message, ex);
                }
                txtSend.ResumeLayout();
                isChangingEmoji = false;
            }
            #endregion
        }
        #endregion

        #region 监控按键
        private void TxtSend_KeyUp(object sender, KeyEventArgs e)
        {
            //当Ctrl+V按太快，会导致e.Control == false
            if (e.KeyCode == Keys.V)
            {
                try
                {
                    if (e.Control)
                        LogHelper.log.Debug("KeyUp start => Ctrl+V");
                    //Console.WriteLine("KeyUp complate => Ctrl+V");
                    else
                        LogHelper.log.Debug("KeyUp start => V");
                    //Console.WriteLine("KeyUp complate => V");
                    if (!string.IsNullOrEmpty(paste_path))
                    {
                        //IDataObject IData = Clipboard.GetDataObject();
                        //if (IData.GetDataPresent(DataFormats.Bitmap))
                        //using (Image paste_image = Image.FromFile(paste_path))
                        //{
                        if (!BitmapUtils.IsNull(paste_image))
                        {
                            //Console.WriteLine("width: " + paste_image.Width);
                            //Console.WriteLine("height: " + paste_image.Height);
                            //恢复到初始
                            Clipboard.Clear();
                            Clipboard.SetDataObject(paste_image, true, 3, 200);//将图片放在剪贴板中
                            paste_path = string.Empty;
                        }
                        //}
                    }
                }
                catch (Exception ex) { LogHelper.log.Error("-----------粘贴图片到文本框时出错，txtSend_KeyUp：", ex); }
            }
            if (e.KeyData == Keys.Return)
            {
                BtnSend_Click(null, null);

                var textarray = txtSend.Text.ToArray();
                if (textarray.Length > 0 && 10 == textarray[textarray.Length - 1])
                {
                    txtSend.Clear();
                }

            }
        }

        private static string paste_path = "";      //用于短暂保存粘贴板的图片
        private static Image paste_image = null;      //用于短暂保存粘贴板的图片
        private void TxtSend_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyData == Keys.Enter)
            //    btnSend_Click(null, null);
            //Ctrl+V
            if (e.Control && e.KeyCode == Keys.V)
            {
                try
                {
                    //stopwatch.Restart();
                    //检查是否黏贴文件
                    if (Clipboard.GetFileDropList().Count > 0)
                    {
                        var strCollection = Clipboard.GetFileDropList();
                        foreach (string item in strCollection)
                            fileCollect.Add(item);
                    }

                    IDataObject IData = Clipboard.GetDataObject();
                    if (IData.GetDataPresent(DataFormats.Bitmap))
                    {
                        //保存路径
                        string filePath = Applicate.LocalConfigData.ImageFolderPath + Guid.NewGuid().ToString("N") + ".png";
                        //获取黏贴板的图片
                        Image image = (Bitmap)IData.GetData(DataFormats.Bitmap);
                        paste_image = image;
                        paste_path = filePath;
                        int new_width = image.Width, new_height = image.Height;
                        EQControlManager.ModifyWidthAndHeight(ref new_width, ref new_height, 150, 150);
                        Image new_image = new Bitmap(image, new_width, new_height);

                        Clipboard.Clear();
                        Clipboard.SetDataObject(new_image, true, 3, 200);//将图片放在剪贴板中

                        //Task.Factory.StartNew(() =>
                        //{
                        image.MySave(filePath, ImageFormat.Png);
                        //获取截图的图片的RTF
                        using (RichTextBox richTextBox = new RichTextBox())
                        {
                            richTextBox.Paste();
                            string txt_rtf = richTextBox.Rtf;
                            string image_rtf = EQControlManager.subRtf(txt_rtf);
                            SrcImages.Add(filePath, image_rtf);
                            //Console.WriteLine("SrcImage_Count: " + SrcImages.Count);
                            //Console.WriteLine("filePath:" + filePath);
                        }
                        //});
                    }
                    if (IData.GetDataPresent(DataFormats.Rtf))
                    {
                        using (RichTextBox richTextBox = new RichTextBox())
                        {
                            richTextBox.Paste();
                            foreach (string emoji_code in EmojiCodeDictionary.GetEmojiDataNotMine().Keys)
                            {
                                string emoji_rtf = EmojiCodeDictionary.GetEmojiRtfByCode(emoji_code);
                                if (richTextBox.Rtf.IndexOf(emoji_rtf) >= 0)
                                {
                                    //不存在才添加
                                    if (emoji_codes.FindIndex(code => code.Equals("[" + emoji_code + "]")) < 0)
                                    {
                                        emoji_num++;
                                        emoji_codes.Add("[" + emoji_code + "]");
                                    }
                                }
                            }
                        }
                    }
                    //stopwatch.Stop();
                    //Console.WriteLine("输出时间：" + stopwatch.ElapsedMilliseconds + "ms");
                    LogHelper.log.Debug("KeyDown complate => Ctrl+V");
                    //Console.WriteLine("KeyDown complate => Ctrl+V");
                }
                catch (Exception ex) { LogHelper.log.Error("-----------粘贴数据到文本框时出错，txtSend_KeyDown：", ex); }
            }
        }
        #endregion
        #endregion

        #region emoji表情的处理
        private void AddEmojiToTxtSend(string emoji_code)
        {
            int selectionIndex = txtSend.SelectionStart;    //记录鼠标的当前光标

            txtSend.SelectedText += emoji_code;

            emoji_num++;
            Helpers.ClearMemory();

            txtSend.SelectionStart = selectionIndex + 1;    //修改光标的位置
        }

        #endregion

        #region 工具栏

        #region 选择表情
        private FrmExpressionTab frmExpressionTab;      //表情列表窗口
        private void LblExpression_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //获取鼠标点击表情时的坐标
            Point ms = Control.MousePosition;
            frmExpressionTab = FrmExpressionTab.GetExpressionTab();
            //修改列表索引
            frmExpressionTab.tabExpression.SelectedIndex = 0;
            //设置弹出窗起始坐标
            int location_x = ms.X - e.X - 8;
            int location_y = ms.Y - frmExpressionTab.Height - e.Y - 5;
            frmExpressionTab.Location = new Point(location_x, location_y);
            //控件显示在最上层
            frmExpressionTab.TopMost = true;
            frmExpressionTab.Show();

            //回调
            frmExpressionTab.expressionAction = (type, code) =>
            {
                switch (type)
                {
                    //选择了emoji表情
                    case ExpressionType.Emoji:
                        AddEmojiToTxtSend(code);
                        break;
                    case ExpressionType.Gif:
                        MessageObject gif_msg = ShiKuManager.SendGifMessage(new Friend(), code, false, false);
                        SendMsgAndAddBubble(gif_msg, (msg, friend) =>
                        {
                            //Messenger.Default.Send(gif_msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);   //添加消息气泡通知
                            ShiKuManager.mSocketCore.SendMessage(msg);
                        });
                        break;
                    case ExpressionType.Image:
                        //此处code为url
                        ImageLoader.Instance.Load(code).Into((bit, path) =>
                        {
                            int fileSize = Convert.ToInt32(new FileInfo(path).Length / 1024);
                            MessageObject img_msg = ShiKuManager.SendImageMessage(new Friend(), code, path, fileSize, false);
                            SendMsgAndAddBubble(img_msg, (msg, friend) =>
                            {
                                //Messenger.Default.Send(img_msg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);   //添加消息气泡通知
                                ShiKuManager.mSocketCore.SendMessage(msg);
                            });
                        });
                        break;
                }
            };
        }
        #endregion

        #region 选择文件并发送
        private void LblSendFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择文件夹",
                Filter = "所有文件 (*.*)|*.*" +
                "|图像 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png" +
                "|视频 (*.avi;*.mp4;*.rmvb;*.flv)|*.avi;*.mp4;*.rmvb;*.flv"
            };

            //完成选择图片的操作
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in dialog.FileNames)
                {
                    FileStream fsRead = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    Clipboard.SetDataObject(fsRead, true, 3, 500);

                    bool isVideo = FileUtils.JudgeIsVideoFile(file);
                    //如果为视频文件
                    if (isVideo)
                    {
                        //先生成气泡
                        int fileSize = Convert.ToInt32(new FileInfo(file).Length);
                        MessageObject vi_msg = ShiKuManager.SendVideoMessage(new Friend(), file, file, fileSize, false, false);

                        bool isFirstRefreshUI = true;
                        vi_msg.isMassMsg = true;

                        //添加气泡到列表
                        JudgeMsgIsAddToPanel(vi_msg);

                        UploadEngine.Instance.From(file).
                        //上传中

                        //上传完成
                        UploadFile((success, url) =>
                        {
                            //SendMsgAndAddBubble(vi_msg, (msg, addressee, ui_msgid, isFirst) =>
                            //{
                            //    bool isRefresh = isFirst;
                            //    msg.isLoading = 1;

                            //    //获取气泡
                            //    EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                            //    if (talk_panel != null)
                            //    {

                            //        UploadVideo(talk_panel, msg, url, success, isRefresh);

                            //    }
                            //});

                            var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                            {
                                //得到一个新的对象
                                MessageObject chatMessage = GetChatMessage(vi_msg, fd);

                                chatMessage.isLoading = 1;
                                bool isRefresh = isFirstRefreshUI;

                                //获取气泡
                                EQBaseControl talk_panel = GetTalkPanelByMsg(vi_msg.messageId);
                                if (talk_panel != null)
                                {

                                    UploadVideo(talk_panel, chatMessage, url, success, isRefresh);

                                }

                                isFirstRefreshUI = false;
                            });
                            frmProgressBar.ShowDialog();
                        });

                    }
                    else
                        UploadFileOrImage(file, Convert.ToInt32(new FileInfo(file).Length));   //上传图片
                }
                dialog.Dispose();
            }
        }
        #endregion

        #region 截图
        private void LblScreen_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CaptureImageTool capture = new CaptureImageTool();

                // capture.SelectCursor = CursorManager.ArrowNew;
                //  capture.DrawCursor = CursorManager.CrossNew;

                if (capture.ShowDialog() == DialogResult.OK)
                {
                    bool txt_readOnly = txtSend.ReadOnly;
                    txtSend.ReadOnly = false;
                    int new_width = capture.Image.Width, new_height = capture.Image.Height;
                    EQControlManager.ModifyWidthAndHeight(ref new_width, ref new_height, 150, 150);
                    Image new_image = new Bitmap(capture.Image, new_width, new_height);

                    Clipboard.Clear();
                    Clipboard.SetImage(new_image);
                    //将图片粘贴到鼠标焦点位置(选中的字符都会被图片覆盖)
                    txtSend.Paste();
                    txtSend.ReadOnly = txt_readOnly;
                    if (SrcImages == null)
                    {
                        SrcImages = new Dictionary<string, string>();
                    }
                    //获取截图的图片的RTF
                    using (RichTextBox richTextBox = new RichTextBox())
                    {
                        richTextBox.Paste();
                        string txt_rtf = richTextBox.Rtf;
                        string image_rtf = EQControlManager.subRtf(txt_rtf);
                        SrcImages.Add(capture.FilePath, image_rtf);
                    }

                    //恢复到初始
                    Clipboard.Clear();
                    Clipboard.SetImage(capture.Image);
                    capture.Image.Dispose();
                }

                if (!Visible)
                {
                    Show();
                }
            }
        }
        #endregion

        #region 选择并发送定位
        private void LblLocation_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;


            Console.WriteLine("" + ShiKuManager.GetXmppState());
            if (ShiKuManager.GetXmppState() != SocketConnectionState.Authenticated)
            {
                HttpUtils.Instance.ShowTip("网络异常，不能定位");
                return;
            }

            FrmSedLocation frmSedLocation = FrmSedLocation.CreateInstrance();
            frmSedLocation.initCefSharp((loc_msg) =>
            {
                SendMsgAndAddBubble(loc_msg, (msg, addressee) =>
                {
                    ShiKuManager.mSocketCore.SendMessage(msg);
                });
            });
            frmSedLocation.Show();
        }
        #endregion

        #region 录音
        private void LblSoundRecord_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //正在录音
            if (userSoundRecording.SoundState)
                return;
            //开启录音功能
            if (userSoundRecording.IsCanSoundRecord())
            {
                ShowSoundRecord();
            }
            else
            {
                userSoundRecording.SendToBack();
                HttpUtils.Instance.ShowTip("未发现录音设备");
            }
        }

        private void ShowSoundRecord()
        {
            userSoundRecording.Visible = true;
            userSoundRecording.BringToFront();
        }
        #endregion

        #region 拍照
        private void LblCamera_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            FrmTakePhoto takephoto = FrmTakePhoto.GetInstance();
            if (takephoto.iscontentpoto())
            {
                takephoto.Show();
                //点击发送的回调
                takephoto.takeimage = (image, localPath) =>
                {
                    if (string.IsNullOrEmpty(localPath) || !File.Exists(localPath))
                        return;
                    //添加气泡到列表
                    MessageObject img_msg = ShiKuManager.SendImageMessage(new Friend(), "", localPath, Convert.ToInt32(new FileInfo(localPath).Length), false, false);

                    bool isFirstRefreshUI = true;
                    img_msg.isMassMsg = true;
                    //添加气泡到列表
                    JudgeMsgIsAddToPanel(img_msg);

                    //SendMsgAndAddBubble(img_msg, (msg, addressee, ui_msgid, isFirst) =>
                    //{
                    //    bool isRefresh = isFirst;
                    //    UploadEngine.Instance.From(localPath).
                    //    //上传完成
                    //    UploadFile((success, url_path) =>
                    //    {
                    //        MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(ui_msgid);    //能获取到代表已添加到气泡列表中
                    //        if (t_msg != null && isRefresh)
                    //        {
                    //            //修改气泡的图片和样式
                    //            EQBaseControl talk_panel = GetTalkPanelByMsg(ui_msgid);
                    //            UploadImage(talk_panel, msg, url_path, success);
                    //        }
                    //        //如果聊天列表没有该消息，则不更新UI只发送
                    //        else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                    //        {
                    //            msg.content = url_path;
                    //            msg.UpdateData();

                    //            ShiKuManager.mSocketCore.SendMessage(msg);
                    //        }
                    //    });
                    //});

                    UploadEngine.Instance.From(localPath).
                           UploadFile((success, url) =>
                           {

                               var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                               {
                                   //得到一个新的对象
                                   MessageObject chatMessage = GetChatMessage(img_msg, fd);

                                   chatMessage.isLoading = 1;
                                   bool isRefresh = isFirstRefreshUI;

                                   MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(img_msg.messageId);    //能获取到代表已添加到气泡列表中
                                   if (t_msg != null && isRefresh)
                                   {
                                       //修改气泡的图片和样式
                                       EQBaseControl talk_panel = GetTalkPanelByMsg(img_msg.messageId);
                                       UploadImage(talk_panel, chatMessage, url, success);
                                   }
                                   //如果聊天列表没有该消息，则不更新UI只发送
                                   else if ((t_msg == null && success) || (t_msg != null && !isRefresh))
                                   {
                                       chatMessage.content = url;
                                       chatMessage.UpdateData();
                                       ShiKuManager.mSocketCore.SendMessage(chatMessage);     //指定发送的UserId
                                                                                              //ShiKuManager.mSocketCore.SendMessage(msg);
                                   }

                                   isFirstRefreshUI = false;
                               });
                               frmProgressBar.ShowDialog();
                           });
                };
            }
            else
            {
                HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip("未发现拍照设备或设备占用");
                //MessageBox.Show("未发现拍照设备", "警告");
                return;
            }
        }
        #endregion

        #region 录像
        private void LblPhotography_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (Applicate.IsOpenRecordView())
            {
                return;
            }

            //是否正在录像
            if (FrmRecordVideo.isRecord)
            {
                HttpUtils.Instance.ShowTip("当前已经打开录像功能");
                return;
            }
            if (UIUtils.IsNull(AudioPushBase.GetAudioDeviceName()))
            {
                HttpUtils.Instance.ShowTip("缺少音频设备");
                return;
            }
            if (UIUtils.IsNull(VideoPushBase.GetVideoDeviceName()))
            {
                HttpUtils.Instance.ShowTip("缺少视频设备");
                return;
            }
            FrmRecordVideo.isRecord = true;

            FrmRecordVideo frmRecordVideo = new FrmRecordVideo(new Friend());
            try
            {
                frmRecordVideo.videoInfo = (localPath, ChatFd) =>
                {
                    //文件不存在
                    if (!File.Exists(localPath))
                        return;

                    // 禅道9064
                    HttpUtils.Instance.PopView(frmRecordVideo);

                    int fileSize = Convert.ToInt32(new FileInfo(localPath).Length);
                    //先生成气泡
                    MessageObject vi_msg = ShiKuManager.SendVideoMessage(new Friend(), localPath, localPath, fileSize, false, false);

                    bool isFirstRefreshUI = true;
                    vi_msg.isMassMsg = true;

                    JudgeMsgIsAddToPanel(vi_msg);

                    UploadEngine.Instance.From(localPath).
                    //上传完成
                    UploadFile((success, url) =>
                    {
                        var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
                        {
                            //得到一个新的对象
                            MessageObject chatMessage = GetChatMessage(vi_msg, fd);

                            chatMessage.isLoading = 1;
                            bool isRefresh = isFirstRefreshUI;
                            //获取气泡
                            EQBaseControl talk_panel = GetTalkPanelByMsg(vi_msg.messageId);
                            if (talk_panel != null)
                            {
                                UploadVideo(talk_panel, chatMessage, url, success, isRefresh);
                            }

                            isFirstRefreshUI = false;
                        });
                        frmProgressBar.ShowDialog();

                    });
                };
                frmRecordVideo.Show();
            }
            catch (Exception ex)
            {
                if (!frmRecordVideo.IsDisposed)
                {
                    frmRecordVideo.Close();
                    frmRecordVideo.Dispose();
                    frmRecordVideo = null;
                }
                LogUtils.Error(ex.Message);
            }

            #region 弃用
            //FrmTakeVideo frmTakeVideo = FrmTakeVideo.GetInstance();
            //if (frmTakeVideo.iscontentpoto())
            //{
            //    frmTakeVideo.Show();
            //    frmTakeVideo.videoInfo = (localPath) =>
            //    {
            //        //文件不存在
            //        if (!File.Exists(localPath))
            //            return;

            //        // 禅道9064
            //        HttpUtils.Instance.PopView(frmTakeVideo);

            //        //先生成气泡
            //        int fileSize = Convert.ToInt32(new FileInfo(localPath).Length);
            //        MessageObject vi_msg = ShiKuManager.SendVideoMessage(new Friend(), localPath, localPath, fileSize, false, false);

            //        bool isFirstRefreshUI = true;
            //        vi_msg.isMassMsg = true;
            //        //添加气泡到列表
            //        JudgeMsgIsAddToPanel(vi_msg);

            //        UploadEngine.Instance.From(localPath).
            //               UploadFile((success, url) =>
            //               {
            //                   if (success)
            //                   {
            //                       var frmProgressBar = new FrmProgressBar(addressees, (fd) =>
            //                       {
            //                           //得到一个新的对象
            //                           MessageObject chatMessage = GetChatMessage(vi_msg, fd);

            //                           chatMessage.isLoading = 1;
            //                           bool isRefresh = isFirstRefreshUI;
            //                           //获取气泡
            //                           EQBaseControl talk_panel = GetTalkPanelByMsg(vi_msg.messageId);
            //                           if (talk_panel != null)
            //                           {
            //                               UploadVideo(talk_panel, chatMessage, url, success, isRefresh);
            //                           }

            //                           isFirstRefreshUI = false;
            //                       });
            //                       frmProgressBar.ShowDialog();
            //                   }
            //               });
            //    };
            //}
            //else
            //    HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip("未发现拍照设备或设备占用");
            #endregion
        }
        #endregion

        #endregion

        #region 添加气泡到消息列表
        #region 判断是否添加气泡到列表
        private void JudgeMsgIsAddToPanel(MessageObject msg)
        {
            #region 过滤消息
            if (msg == null || string.IsNullOrEmpty(msg.messageId))
                return;
            //不生成气泡的消息类型
            if (!msg.IsVisibleMsg() && msg.type != kWCMessageType.RoomIsVerify)
                return;
            //已存在该气泡控件
            if (xListView.panel1.Controls["talk_panel_" + msg.messageId] != null)
                return;
            //content为空的消息不显示
            if (string.IsNullOrEmpty(msg.content))
            {
                switch (msg.type)
                {
                    case kWCMessageType.Text:
                        msg.content = " ";
                        break;
                    case kWCMessageType.Image:
                        break;
                    case kWCMessageType.File:
                        break;
                    case kWCMessageType.Video:
                        break;
                    case kWCMessageType.Voice:
                        break;
                    default:
                        return;
                }
            }

            //如果数据已经加载了300条，继续滚动会超过最大值
            if (msgTabAdapter.msgList.Count > 300)
            {
                HttpUtils.Instance.ShowTip("当前群发消息超过单次最大发送数量：300条");
                return;
            }

            //获取滚动条的位置
            int progress = xListView.Progress;
            //是否在底部
            //if (progress == 100 || xListView.Height >= xListView.panel1.Height)
            //    isInsert = true;
            bool isInsert = JudgeIsInsert(msg);
            if (this.IsHandleCreated)
                Invoke(new Action(() =>
                {
                    try
                    {
                        //添加消息气泡
                        msgTabAdapter.TargetMsgData.AddMsgData(msg);
                        int index = msgTabAdapter.msgList.FindIndex(m => m.messageId == msg.messageId);
                        //msgTabAdapter.msgList.Insert(end, msg);
                        xListView.InsertItem(index, isInsert);

                        //如果是自己发送的消息，或者当前滚动到了底部，则调用滚动到底部的方法
                        if (msg.fromUserId == Applicate.MyAccount.userId || progress == 100)
                        {
                            int end = msgTabAdapter.msgList.Count - 1;
                            //bool isFillCrl = Applicate.GetWindow<FrmMain>().WindowState != FormWindowState.Minimized;
                            xListView.ShowRangeEnd(end, 0, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.log.Error("----添加气泡出错，方法（JudgeMsgIsAddToPanel） : " + ex.Message, ex);
                    }
                }));
        }
        #endregion

        private bool JudgeIsInsert(MessageObject msg)
        {
            if (xListView.Height >= xListView.panel1.Height)
                return true;

            //1.判断消息是否是对方发送的
            //2.判断滚动条的位置决定是否在底部
            //3.位置不在底部返回false，默认为true
            int progress = xListView.Progress;      //获取滚动条的位置
            if (!msg.IsMySend())
            {
                if (progress != 100 && Math.Abs(xListView.panel1.Location.Y) != xListView.panel1.Height - xListView.Height)
                    return false;
            }
            return true;
        }
        #endregion
        #endregion

        #region 按回执更新送达消息状态
        private void DrawIsSend(MessageObject msg)
        {
            MessageObject t_msg = msgTabAdapter.TargetMsgData.GetMsg(msg.messageId);
            //不属于自己的消息回执
            if (t_msg == null)
                return;
            t_msg.isSend = msg.isSend;
            // 修改禅道9394
            t_msg.signature = msg.signature;
            if (t_msg == null || string.IsNullOrEmpty(t_msg.messageId))
                return;

            if (t_msg.fromUserId != Applicate.MyAccount.userId)
                return;

            //获得需要更新的控件
            EQBaseControl talk_panel = GetTalkPanelByMsg(t_msg.messageId);

            //是否存在该气泡消息和送达标识
            if (talk_panel == null || talk_panel.Controls["lab_msg"] == null)
                return;

            //修改气泡的发送状态
            Action action = new Action(() =>
            {
                if (talk_panel.Controls["lab_msg"] != null)
                    EQControlManager.DrawIsSend(t_msg, (Label)talk_panel.Controls["lab_msg"]);
            });
            if (this.IsHandleCreated)
                Invoke(action);
        }
        #endregion


        private EQBaseControl GetTalkPanelByMsg(string msgId)
        {
            string name = "panel_" + msgId;
            Control panel = xListView.panel1.Controls[name];
            if (panel == null)
                return null;

            var result = panel.Controls.Find("talk_panel_" + msgId, true);
            if (result.Length > 0 && result[0] is EQBaseControl talk_panel)
                return talk_panel;

            return null;
        }

        private void FrmMassMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            //清除数据
            msgTabAdapter.TargetMsgData.RemoveAllData();
            ChatTargetDictionary.RemoveItem(Applicate.MyAccount.userId);

            //取消录音
            if (userSoundRecording.SoundState)
                userSoundRecording.StopSound();
        }
    }
}
