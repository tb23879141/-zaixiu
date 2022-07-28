using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class TurnHistoryAdapter : IBaseAdapter
    {
        public List<MessageObject> mDatas;
        public FrmHistoryMsg frmHistory;
        public override int GetItemCount()
        {
            return mDatas.Count;
        }
        public void SetMaengForm(FrmHistoryMsg historyMsg)
        {
            this.frmHistory = historyMsg;
        }

        public override Control OnCreateControl(int index)
        {
            HistoryItem chat = new HistoryItem();
            chat.Width = frmHistory.historyTablePanel.ItemGroupWidth;
            chat.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            chat.messageData = mDatas[index];
            chat.Tag = mDatas[index].content;

            chat.BackColor = Color.White;
            ImageLoader.Instance.DisplayAvatar(mDatas[index].fromUserId, chat.pic_head);



            #region 文件
            if (mDatas[index].type == kWCMessageType.File)//文件
            {
                chat = new HistoryItem();
                Size s = chat.Size;
                chat.Size = new Size(s.Width, 130);
                chat.BackColor = Color.White;
                chat.messageData = mDatas[index];
                var panel_file = new FilePanelLeft();
                panel_file.Cursor = Cursors.Hand;
                panel_file.lab_lineLime.Width = 0;
                string fileNames = FileUtils.GetFileName(mDatas[index].fileName);
                panel_file.FileName = fileNames;
                int fileSize = (int)mDatas[index].fileSize;
                panel_file.lab_fileSize.Text = Convert.ToInt32(fileSize / 1024) + "KB";
                panel_file.Location = new Point(55, 50);
                panel_file.Size = new Size(225, 76);
                panel_file.BringToFront();
                //  系统默认打开文件
                foreach (Control itemControl in panel_file.Controls)
                {
                    itemControl.Click += (sender, e) =>
                    {
                        string path = "";
                        string fileName = "";
                        path = frmHistory.content;
                        fileName = FileUtils.GetFileName(frmHistory.content);
                        string filePath = Applicate.LocalConfigData.RoomFileFolderPath + fileName;
                        //下载
                        FrmHistoryMsg.DownFile(filePath, path);
                    };
                    if (itemControl.Controls.Count > 0)
                        foreach (Control itemcl in itemControl.Controls)
                            itemcl.Click += (sender, e) =>
                            {
                                string path = "";
                                string fileName = "";
                                path = mDatas[index].content;
                                fileName = FileUtils.GetFileName(mDatas[index].content);
                                string filePath = Applicate.LocalConfigData.RoomFileFolderPath + fileName;
                                //下载
                                FrmHistoryMsg.DownFile(filePath, path);
                            };
                }
                ImageLoader.Instance.DisplayAvatar(mDatas[index].fromUserId, chat.pic_head);
                chat.Controls.Add(panel_file);
                return chat;
                // views.Add(chat);
            }
            #endregion

            #region 视频
            if (mDatas[index].type == kWCMessageType.Video)
            {
                Size s = chat.Size;
                chat.Size = new Size(s.Width, 175);


                ImageViewxVideo pictureBox = new ImageViewxVideo();
                pictureBox.Location = new Point(55, 50);
                pictureBox.Size = new Size(130, 130);
                //绑定当前的索引
                pictureBox.Tag = mDatas[index];

                ThubImageLoader.Instance.LoadImage(mDatas[index].content, pictureBox);

                pictureBox.MouseClick += new MouseEventHandler(FrmHistoryMsg.Vido_clike);
                chat.Controls.Add(pictureBox);
                return chat;
            }
            #endregion
            #region 图片
            if (mDatas[index].type == kWCMessageType.Image)
            {
                // 实例化控件
                frmHistory.content = "";
                Size s = chat.Size;
                //  chat.Size = new Size(s.Width, 175);
                PictureBox pictureBox = new PictureBox();

                pictureBox.Location = new Point(55, 50);
                pictureBox.Size = new Size(130, 110);

                ImageLoader.Instance.Load(mDatas[index].content).NoCache().Into(pictureBox);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Dock = DockStyle.None;
                //  绑定当前的索引
                pictureBox.Tag = mDatas[index].messageId;
                pictureBox.MouseClick += new MouseEventHandler(FrmHistoryMsg.MouseClie);
                chat.Controls.Add(pictureBox);
                return chat;

            }
            #endregion
            //语音
            if (mDatas[index].type == kWCMessageType.Voice)
            {
                //Label lblText = new Label();
                //lblText.Font = new Font(Applicate.SetFont, 10);
                //lblText.AutoSize = false;
                //lblText.Size = new Size(150, 40);
                //lblText.Location = new Point(55, 50);
                //lblText.Text = "[" + LanguageXmlUtils.GetValue("Voice", "语音消息") + "]";
                //chat.Controls.Add(lblText);
                // views.Add(chat);

                chat.Size = new Size(chat.Size.Width, 100);
                UserFileLeft panel_voice = new UserFileLeft();

                panel_voice.Cursor = Cursors.Hand;
                panel_voice.lab_fileName.Text = LanguageXmlUtils.GetValue("Voice", "语音");
                panel_voice.lab_fileSize.Text = "00:" + mDatas[index].timeLen.ToString().PadLeft(2, '0');
                panel_voice.Location = new Point(55, 50);
                FrmHistoryChat.TypeFileToImage(mDatas[index].content, panel_voice.lab_icon);

                panel_voice.Click += (sen, eve) =>
                {
                    FrmvoiceTest frm = Applicate.GetWindow<FrmvoiceTest>();
                    if (frm == null)
                    {
                        frm = new FrmvoiceTest();
                    }
                    else
                    {
                        frm.Activate();
                        return;
                    }

                    if (frm.GetDevicde())
                    {
                        HttpUtils.Instance.ShowTip("未发现音频播放设备");
                        return;
                    }
                    frm.userVoiceplayer1.VidoShowList(new MessageObject() { content = mDatas[index].content, fileSize = mDatas[index].fileSize, timeLen = Convert.ToInt32(mDatas[index].timeLen) });
                    //Point point = FrmHistoryChat.flpTable.PointToScreen(FrmHistoryChat.flpTable.Location);
                    //frm.Location = new Point(point.X - FrmHistoryChat.flpTable.Location.X, point.Y - 20);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.BringToFront();

                    frm.Show();
                };
                chat.Tag = panel_voice.lab_fileName.Text;

                chat.Controls.Add(panel_voice);
                return chat;

            }
            #region 消息记录
            if (mDatas[index].type == kWCMessageType.History)
            {
                Label lblText = new Label();
                lblText.Cursor = Cursors.Hand;
                lblText.Font = new Font(Applicate.SetFont, 10);
                lblText.AutoSize = false;
                lblText.Size = new Size(150, 40);
                lblText.Location = new Point(55, 50);
                lblText.Text = "[" + LanguageXmlUtils.GetValue("History", "[聊天记录]") + "]";

                //  views.Add(chat);
                lblText.Click += (sender, e) =>
                {
                    FrmHistoryMsg frmHistory = new FrmHistoryMsg();
                    frmHistory.content = mDatas[index].content;
                    frmHistory.FromLocal = false;
                    frmHistory.Show();
                    frmHistory.TitleText = string.Format("“{0}”和“{1}”的聊天记录",
                        EQControlManager.StrAddEllipsis(mDatas[index].toUserName, lblText.Font, 150),
                        EQControlManager.StrAddEllipsis(mDatas[index].fromUserName, lblText.Font, 150));
                };
                chat.Controls.Add(lblText);
                return chat;
            }
            #endregion
            #region 消息内容
            if (mDatas[index].type == kWCMessageType.Text)
            {
                // frmHistory. ShowLodingDialog(this);



                RichTextBoxEx richText = new RichTextBoxEx();
                richText.SelectionFont = new Font(Applicate.SetFont, 10);
                richText.Font = new Font(Applicate.SetFont, 10);
                richText.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                richText.Size = new Size(420, 30);
                // richText.BackColor = Color.WhiteSmoke;
                richText.Location = new Point(55, 40);
                richText.BorderStyle = BorderStyle.None;
                richText.ScrollBars = RichTextBoxScrollBars.None;
                richText.ReadOnly = true;
                richText.BackColor = Color.White;
                // 防止换行
                richText.Multiline = true;
                richText.BringToFront();
                richText.Text = mDatas[index].content;

                int textwindth = frmHistory.FontWidth(richText.Font, richText, richText.Text);
                richText.ContentsResized += frmHistory.RichTextBox_ContentsResized;
                if (richText.Width <= textwindth)
                {
                    richText.Click += (sender, e) =>
                    {
                        // 打开文字查看器
                        FrmSeeText frmSeeText = new FrmSeeText();
                        frmSeeText.Getmsg = mDatas[index];
                        frmSeeText.Longtext = mDatas[index].content;
                        frmSeeText.Show();
                    };
                }
                else
                {
                    richText.Text = mDatas[index].content;
                }
                // // 超链接
                richText.DetectUrls = true;
                //文字提取凭
                FrmHistoryMsg.Calc_PanelWidth(richText, mDatas[index].toUserId);//这行代码会导致字体变成默认的宋体

                // frmHistory. loding.stop();

                EQShowInfoPanelAlpha eQShowInfo = new EQShowInfoPanelAlpha();//透明遮罩 

                eQShowInfo.Size = richText.Size;
                eQShowInfo.Location = richText.Location;
                eQShowInfo.BringToFront();
                chat.Controls.Add(eQShowInfo);
                chat.Controls.Add(richText);
                //  richText.TextChanged += RichText_TextChanged;

                // views.Add(chat);
                // 点击超链接
                richText.LinkClicked += (sender, e) =>
                {
                    //  打开浏览器窗口
                    FrmBrowser frm = new FrmBrowser();
                    frm.BrowserShow(mDatas[index]);
                };
                return chat;
            }
            //位置
            if (mDatas[index].type == kWCMessageType.Location)
            {
                // content = "";

                //chat = new HistoryItem();
                Size s = chat.Size;
                chat.Size = new Size(s.Width, 135);

                // chat.lblDatime.Location = new Point(499, 17);
                //实例化控件
                Panel pnlLoction = new Panel();
                pnlLoction.Cursor = Cursors.Hand;
                pnlLoction.Location = new Point(55, 50);
                pnlLoction.Size = new Size(200, 88);
                pnlLoction.Tag = mDatas[index].messageId;
                //地图
                PictureBox pic_image = new PictureBox();
                pic_image.Size = new Size(196, 70);
                pic_image.Location = new Point(1, 1);
                pic_image.SizeMode = PictureBoxSizeMode.StretchImage;
                pic_image.Dock = DockStyle.Top;
                ImageLoader.Instance.Load(mDatas[index].content).NoCache().Into(pic_image);
                pnlLoction.Controls.Add(pic_image);
                //增加布局
                Label lab_name = new Label();
                lab_name.BackColor = Color.White;
                lab_name.Text = mDatas[index].objectId;
                lab_name.TextAlign = ContentAlignment.MiddleCenter;
                lab_name.AutoSize = false;
                lab_name.Size = new Size(200, 12);
                lab_name.Location = new Point(4, 73);
                pnlLoction.Controls.Add(lab_name);
                chat.Controls.Add(pnlLoction);
                pic_image.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        FrmBrowser frm = new FrmBrowser();
                        frm.BrowserShow(mDatas[index]);
                    }
                };
                return chat;
            }
            return chat;
        }

        #endregion
        public override int OnMeasureHeight(int index)
        {
            EQControlManager.CalculateWidthAndHeight_Text(mDatas[index], false, 420);

            if (mDatas[index].type == kWCMessageType.Text)//不含richtextbox
            {

                return mDatas[index].BubbleHeight + 60;
            }
            else if (mDatas[index].type == kWCMessageType.History)
            {
                return 90;
            }
            else if (mDatas[index].type == kWCMessageType.File)
            {
                //return mDatas[index].BubbleHeight + 90;//含有richtextbox会得到BubbleHeight的准确值
                return 97 + 55; //97为文件消息控件的固定高度
            }
            else if (mDatas[index].type == kWCMessageType.Image)
            {
                return mDatas[index].BubbleHeight + 135;//含有richtextbox会得到BubbleHeight的准确值
            }
            else if (mDatas[index].type == kWCMessageType.Video)
            {
                return 130 + 55;    //130为视频消息固定高度
            }
            else
            {
                return mDatas[index].BubbleHeight + 125;//含有richtextbox会得到BubbleHeight的准确值
            }


            //有richtextbox的项返回mDatas[index].BubbleHeight +10，但是如果没有richtextbox时候返回有误
        }

        public override void RemoveData(int index)
        {
            mDatas.RemoveAt(index);
        }
        public void BindDatas(List<MessageObject> data)
        {
            mDatas = data;
        }

    }
}

