using Newtonsoft.Json;
using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Dictionarys;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmHistoryMsg : FrmBase
    {
        // 单次查询多少条记录
        private int ROW_CHECK = 50;
        private static int emoji_count = 0;
        private List<Control> views = new List<Control>();
        public LodingUtils loding;
        private TurnHistoryAdapter mAdapter;

        public void ShowLodingDialog(Control con)
        {
            loding = new LodingUtils();
            loding.parent = con;
            loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
            loding.start();
        }
        /// <summary>
        /// 标题文字（好友名称）
        /// </summary>
        public string TitleText
        {
            get { return lblTitlt.Text; }
            set
            {
                lblTitlt.Text = value;
                lblTitlt.Visible = true;
            }
        }

        public bool FromLocal { get; set; }
        public string content { get; set; }
        public static List<MessageObject> msgs = new List<MessageObject>();
        public List<MessageObject> messages = new List<MessageObject>();
        /// <summary>
        /// 好友对象
        /// </summary>
        public static Friend friendData { get; set; }

        public FrmHistoryMsg()
        {
            FromLocal = false;
            InitializeComponent();
            lblTitlt.Visible = false;
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标



            mAdapter = new TurnHistoryAdapter();
            useSearch.tips = LanguageXmlUtils.GetValue("search", "搜索");


            useSearch.SearchEvent += search;
        }

        private void FrmHistoryMsg_Load(object sender, EventArgs e)
        {
            useSearch.Focus();
        }

        private void FrmHistoryMsg_MouseDown(object sender, MouseEventArgs e)
        {
            historyTablePanel.Focus();
        }

        private void FrmHistoryMsg_Shown(object sender, EventArgs e)
        {
            ShowLodingDialog(historyTablePanel);//等待符
            //searchTextBox.lblSearch.Font = new Font(Program.ApplicationFontCollection.Families.Last(), 8f);//设置文字图标
            //searchTextBox.lblSearch.Text = "";     //Unicode转中文后的转动图标
            //searchTextBox.lblSearch.ForeColor = Color.Gray;

            historyTablePanel.Focus();

            #region 加载历史记录

            if (FromLocal)//加载本地
            {
                msgs = LoadObjectLocalMsg();
                foreach (var msg in msgs)
                {
                    HistoryItem item = new HistoryItem();
                    item.messageData = msg;
                    item.txtTime = msg.timeSend.StampToDatetime().ToString(@"yyyy/MM/dd HH:mm");
                    views.Add(item);
                }
            }
            else
            {
                //消息解析
                getmessage();

            }
            LoadRoomList();
            //  historyTablePanel.AddViewsToPanel(views);
            #endregion
        }

        public void LoadRoomList()
        {
            mAdapter.SetMaengForm(this);
            mAdapter.BindDatas(msgs);
            historyTablePanel.SetAdapter(mAdapter);
            loding.stop();//关闭等待符
        }

        #region 初次加载本地聊天记录
        private List<MessageObject> LoadObjectLocalMsg()
        {
            //获取固定数量的聊天消息
            List<MessageObject> msgList = new MessageObject()
            {
                FromId = friendData.UserId,
                ToId = Applicate.MyAccount.userId
            }.GetPageList(1, ROW_CHECK);
            //重新排序
            msgList.Sort((x, y) =>
            {
                if (x.timeSend < y.timeSend)
                    return -1;
                else if (x.timeSend > y.timeSend)
                    return 1;
                else
                    return 0;
            });
            return msgList;
        }
        #endregion


        /// <summary>
        /// 根据传入的content进行解析并放入面板中
        /// </summary>
        private void getmessage()
        {
            if (content != null)
            {
                msgs = new List<MessageObject>();
                var newslst = JsonConvert.DeserializeObject<List<string>>(content);
                foreach (var item in newslst)//获取到消息列表
                {
                    var mem = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());


                    string content = UIUtils.DecodeString(mem, "content");
                    MessageObject msg = new MessageObject();
                    msg.fromUserName = UIUtils.DecodeString(mem, "fromUserName");
                    msg.fromUserId = UIUtils.DecodeString(mem, "fromUserId");
                    msg.timeSend = UIUtils.DecodeDouble(mem, "timeSend");
                    msg.content = UIUtils.DecodeString(mem, "content");
                    msg.toUserId = UIUtils.DecodeString(mem, "toUserId");
                    msg.messageId = UIUtils.DecodeString(mem, "messageId");
                    msg.toUserName = UIUtils.DecodeString(mem, "toUserName");
                    if (mem.ContainsKey("timeLen"))
                    {
                        msg.timeLen = UIUtils.DecodeInt(mem, "timeLen");
                    }
                    if (mem.ContainsKey("fileName"))
                    {
                        msg.fileName = UIUtils.DecodeString(mem, "fileName");
                    }
                    if (mem.ContainsKey("fileSize"))
                    {
                        msg.fileSize = UIUtils.DecodeLong(mem, "fileSize");
                    }
                    if (mem.ContainsKey("location_x"))
                    {
                        msg.location_x = UIUtils.DecodeDouble(mem, "location_x");
                    }
                    if (mem.ContainsKey("location_y"))
                    {
                        msg.location_y = UIUtils.DecodeDouble(mem, "location_y");
                    }
                    if (mem.ContainsKey("objectId"))
                    {
                        msg.objectId = UIUtils.DecodeString(mem, "objectId");
                    }
                    msg.type = UIUtils.Trantomesstype(mem, "type");//消息类型转换
                    msgs.Add(msg);
                }

            }
            else
            {
                msgs = messages;
            }

        }

        #region 提取超链接与emaijo表情
        public static void Calc_PanelWidth(Control control, string userid)
        {
            if (!(control is RichTextBoxEx richContent))
                return;

            // 临时建立一个容器装入内容
            RichTextBoxEx canv_Rich = control as RichTextBoxEx;
            // 先取全部Text的值
            canv_Rich.Text = richContent.Text;
            // 把code转为emoji

            canv_Rich.Rtf = GetLink(canv_Rich.Text, userid);

            // 用来设置字体的，一定不能少，不然会变成默认的宋体了
            canv_Rich.Font = new Font(Applicate.SetFont, 10);
            richContent.Rtf = canv_Rich.Rtf;

        }

        public static string GetLink(string msgText, string userid)
        {
            RichTextBoxEx richTextBox = new RichTextBoxEx();
            richTextBox.Text = msgText;
            richTextBox.Font = new Font(Applicate.SetFont, 10);
            //正则表达式
            MatchCollection msg = Regex.Matches(msgText, @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", RegexOptions.IgnoreCase | RegexOptions.Singleline);//得到表情的个数
            foreach (Match match in msg)
            {
                int str_index = richTextBox.Text.IndexOf(match.Value);
                richTextBox.SelectionStart = str_index;

                richTextBox.SelectionLength = match.Value.Length;
                richTextBox.SelectedText = "";
                richTextBox.InsertLink(match.Value);

            }
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
                //  bool isMin = userid == Applicate.MyAccount.userId;
                richTextBox.Rtf = richTextBox.Rtf.Replace(newStr[i], EnjoyCodeColor.GetEmojiRtfByCode(newStr[i], Color.White));
            }

            string result = richTextBox.Rtf;
            string text = richTextBox.Text;
            richTextBox.Dispose();
            return result;
        }
        #endregion
        //视频播放
        public static void Vido_clike(object sender, MouseEventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                FrmVideoFlash frm = FrmVideoFlash.CreateInstrance();
                MessageObject msges = new MessageObject();
                msges = (MessageObject)picture.Tag;
                frm.VidoShowList(msges);
                frm.Show();
            }
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="toFilePath"></param>
        /// <param name="fileUrl"></param>
        public static void DownFile(string toFilePath, string fileUrl)
        {
            HttpDownloader.DownloadFile(fileUrl, toFilePath, (path) =>
            {
                if (!string.IsNullOrEmpty(path))
                {
                    // 下载成功
                    LogUtils.Log("下载成功！" + path);
                    //打开此文件
                    System.Diagnostics.Process.Start(path);
                }
            });
        }

        #region 图片查看器
        /// <summary>
        /// 打开图片查看器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MouseClie(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取当前的图片
                PictureBox picture = (PictureBox)sender;

                //获取Tag值
                string messageid = (string)picture.Tag;
                //清除


                List<MessageObject> listmessage = new List<MessageObject>();
                listmessage = msgs;
                //索引
                int index = 0;
                for (int i = 0; i < msgs.Count; i++)
                {
                    if (listmessage[i].messageId.Equals(messageid))
                    {
                        index = i;
                        break;

                    }
                }


                FrmLookImage frmLookImage = Applicate.GetWindow<FrmLookImage>();
                if (frmLookImage == null)
                {
                    frmLookImage = new FrmLookImage();
                }
                else
                {
                    frmLookImage.Activate();
                }

                frmLookImage.ShowImageList(listmessage, index);
            }

        }
        #endregion

        public int FontWidth(Font font, Control control, string str)
        {
            //此处为什么会报错？？？难道因为执行此方法在后，创建控件在先？？

            Graphics g = this.CreateGraphics();
            SizeF siF = g.MeasureString(str, font); return (int)siF.Width;


        }

        private string lastSearchText = "";

        #region 查询消息记录

        public void search(string currText)
        {
            List<MessageObject> result = new List<MessageObject>();

            if (string.IsNullOrEmpty(currText) && string.IsNullOrEmpty(lastSearchText))
            {
                LogUtils.Log("SearchTextChanged null");
                return;
            }

            if (string.Equals(lastSearchText, currText))
            {
                LogUtils.Log("SearchTextChanged Equals");
                return;
            }

            // 清空了搜索框
            if (string.IsNullOrEmpty(currText) && !string.IsNullOrEmpty(lastSearchText))
            {
                lastSearchText = currText;
                // 恢复原列表
                LoadRoomList();
                return;
            }

            lastSearchText = currText;
            if (!string.IsNullOrEmpty(currText))
            {
                // 加载搜索数据

                for (int i = 0; i < msgs.Count; i++)
                {
                    string a = msgs[i].content;
                    if (msgs[i].content.Contains(useSearch.txt_Search.Text.Trim()) || msgs[i].content.Contains(useSearch.txt_Search.Text.Trim().ToUpper()) || msgs[i].content.Contains(useSearch.txt_Search.Text.Trim().ToLower()))
                    {
                        result.Add(msgs[i]);
                    }

                }
                mAdapter.SetMaengForm(this);
                mAdapter.BindDatas(result);
                historyTablePanel.SetAdapter(mAdapter);
                loding.stop();//关闭等待符
                //  loding.stop();
            }
        }



        private void txtSearch_click(object sender, EventArgs e)
        {


        }
        #endregion


        public const int minHeight = 50;
        public static int BubbleWidth, BubbleHeight;

        private void useSearch_Load(object sender, EventArgs e)
        {

        }

        public void RichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBoxEx richText = (RichTextBoxEx)sender;
            richText.Height = e.NewRectangle.Height + 10;
        }
    }
}