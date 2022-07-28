using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Helper;

namespace WinFrmTalk.View
{
    /// <summary>
    /// 表情窗口
    /// 2020-6-20 11:06:10
    /// lx
    /// </summary>
    public partial class FrmEmojiTab : FrmBase
    {
        //双缓冲
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        public List<EmojiGif> mGifData;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            tlblEmoji.Text = LanguageXmlUtils.GetValue("exps_default", tlblEmoji.Text);
            tlblGif.Text = LanguageXmlUtils.GetValue("exps_gif", tlblGif.Text);
            tlblCustom.Text = LanguageXmlUtils.GetValue("exps_custom", tlblCustom.Text);
            tsmiDeleted.Text = LanguageXmlUtils.GetValue("delete", tsmiDeleted.Text);
            btnInit.Text = LanguageXmlUtils.GetValue("initialize_emoji", btnInit.Text);
        }

        public FrmEmojiTab()
        {
            this.ControlBox = false;
            this.Stacked = false;

            InitializeComponent();
            LoadLanguageText();
            this.Deactivate += FrmEmojiTab_Deactivate;

            // 创建面板 三个面板
            InitLayoutControl();

            SwitchTabDefault();
        }

        // 自动关闭
        public bool isDeactivate;

        private void FrmEmojiTab_Deactivate(object sender, EventArgs e)
        {
            if (isDeactivate)
            {
                this.Hide();
            }
            isDeactivate = true;
        }


        public void SwitchTabDefault()
        {
            // 默认选中第一个
            Tab_MouseClick(tlblEmoji, null);
        }

        private void InitLayoutControl()
        {
            // 添加emoji表情到面板
            InitEmojiControl();

            // 添加Gif到面板
            InitGifControl();

            // 添加自定义表情
            InitCustomizeControl();
        }

        // 控件鼠标滚动事件
        private void Item_MouseWheel(object sender, MouseEventArgs e)
        {
            int movey = 0;
            if (e.Delta >= 0)
            {
                movey = gifPanel.Location.Y + 71;
            }
            else
            {
                movey = gifPanel.Location.Y - 71;
            }

            if (movey > 0)
            {
                movey = 0;
            }
            else if (movey < (3 * 71) - gifPanel.Height + 1)
            {
                movey = (3 * 71) - gifPanel.Height + 1;
            }

            gifPanel.Location = new Point(0, movey);
            MoveScrollbar(movey);
        }

        private void Item_MouseWheel_CustomizePanel(object sender, MouseEventArgs e)
        {
            int movey = 0;
            if (e.Delta >= 0)
            {
                movey = customizePanel.Location.Y + 71;
            }
            else
            {
                movey = customizePanel.Location.Y - 71;
            }

            if (movey > 0)
            {
                movey = 0;
            }
            else if (movey < (3 * 71) - customizePanel.Height + 1)
            {
                movey = (3 * 71) - customizePanel.Height + 1;
            }

            customizePanel.Location = new Point(0, movey);
            MoveScrollbar(movey);
        }


        // 移动滚动条 到某一个位置
        private void MoveScrollbar(int location_y)
        {
            // 总高度
            int height = currentPanel.Height - layoutPanel.Height;
            if (height <= 0)
                return;
            LogUtils.Log("MoveScrollbar:" + location_y + " , " + height);

            // 当前偏移 / 总高 = 进度
            int pro = Convert.ToInt32(Math.Abs(location_y) / (float)height * 100);
            pro = Math.Min(pro, 100);

            vScrollBar.SetProgress(pro);
        }

        private int last_progress;
        // 进度条滚动事件
        private void ScrollChangeListener()
        {
            //   Console.WriteLine("" + vScrollBar.Value);

            if (vScrollBar.Value == last_progress)
            {
                return;
            }

            if (layoutPanel.Height > currentPanel.Height)
            {
                return;
            }

            last_progress = vScrollBar.Value;

            float max = currentPanel.Height - layoutPanel.Height;


            int moveyindex = Convert.ToInt32(last_progress / -100f * max / 71);

            int movey = Convert.ToInt32(moveyindex * 71);

            // 移动panel
            currentPanel.Location = new Point(0, movey);
        }


        // 初始化emoji表情
        private void InitEmojiControl()
        {
            emojiPanel = new Panel();
            layoutPanel.Controls.Add(emojiPanel);

            //获取所有emoji表情路径
            string[] emojiPaths = Directory.GetFiles(Applicate.LocalConfigData.EmojiFolderPath, "*.png");
            //循环添加emoji表情

            int width = 0, height = 0;
            foreach (string emojiPath in emojiPaths)
            {
                Bitmap emoji = new Bitmap(emojiPath);

                string name = FileUtils.GetFileName(emojiPath);// emojiPath.Substring(emojiPath.LastIndexOf("\\") + 1);

                var picEmoji = new ImageViewxEmoji();
                picEmoji.Name = string.Format("[{0}]", name.Remove(name.LastIndexOf(".")));
                picEmoji.TabIndex = 0;
                picEmoji.TabStop = false;
                picEmoji.Image = emoji;
                picEmoji.Padding = new Padding(5);
                picEmoji.Location = new System.Drawing.Point(width, height);
                picEmoji.Size = new System.Drawing.Size(36, 36);

                picEmoji.MouseClick += PicEmoji_MouseClick;
                //picEmoji.MouseEnter += PicEmoji_MouseEnter;
                //picEmoji.MouseLeave += PicEmoji_MouseLeave;
                emojiPanel.Controls.Add(picEmoji);

                width += 36;
                if (width > this.Width - 36)
                {
                    width = 0;
                    height += 36;
                }
            }

            emojiPanel.Size = new Size(layoutPanel.Width, height + 36);
            //  Console.WriteLine("em及   ：" + (height + 36));
        }

        private static FrmEmojiTab frmExpressionTab;
        private static readonly object looker = new object();

        internal static FrmEmojiTab GetExpressionTab()
        {
            if (frmExpressionTab == null)
            {
                lock (looker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (frmExpressionTab == null)
                    {
                        frmExpressionTab = new FrmEmojiTab();
                    }
                }
            }

            if (frmExpressionTab.IsDisposed)
            {
                lock (looker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (frmExpressionTab.IsDisposed)
                    {
                        frmExpressionTab = new FrmEmojiTab();
                    }
                }
            }



            return frmExpressionTab;
        }



        // 初始化GIF表情
        private void InitGifControl()
        {
            gifPanel = new Panel();
            gifPanel.BackColor = Color.FromArgb(243, 243, 243);
            layoutPanel.Controls.Add(gifPanel);


            // 按照手机版排序
            mGifData = new List<EmojiGif>();
            mGifData.Add(new EmojiGif() { name = "onety_one.gif", text = "Hi" });
            mGifData.Add(new EmojiGif() { name = "onety_two.gif", text = "No No No" });
            mGifData.Add(new EmojiGif() { name = "onety_three.gif", text = "OK" });
            mGifData.Add(new EmojiGif() { name = "onety_four.gif", text = "抱抱" });
            mGifData.Add(new EmojiGif() { name = "onety_five.gif", text = "比心" });

            mGifData.Add(new EmojiGif() { name = "onety_six.gif", text = "大哭" });
            mGifData.Add(new EmojiGif() { name = "onety_seven.gif", text = "干杯" });
            mGifData.Add(new EmojiGif() { name = "onety_eight.gif", text = "干饭" });
            mGifData.Add(new EmojiGif() { name = "onety_nine.gif", text = "欢迎" });
            mGifData.Add(new EmojiGif() { name = "ontty_ten.gif", text = "节日快乐" });

            mGifData.Add(new EmojiGif() { name = "twoty_one.gif", text = "亲亲" });
            mGifData.Add(new EmojiGif() { name = "twoty_two.gif", text = "庆祝" });
            mGifData.Add(new EmojiGif() { name = "twoty_three.gif", text = "生日快乐" });
            mGifData.Add(new EmojiGif() { name = "twoty_four.gif", text = "送花" });
            mGifData.Add(new EmojiGif() { name = "twoty_five.gif", text = "晚安" });

            mGifData.Add(new EmojiGif() { name = "twoty_six.gif", text = "早安" });
            mGifData.Add(new EmojiGif() { name = "twoty_seven.png", text = "恭喜发财" });
            mGifData.Add(new EmojiGif() { name = "twoty_eight.png", text = "想你" });
            mGifData.Add(new EmojiGif() { name = "twoty_nine.png", text = "摸摸头" });
            mGifData.Add(new EmojiGif() { name = "twoty_ten.png", text = "瑟瑟发抖" });

            mGifData.Add(new EmojiGif() { name = "third_one.png", text = "吃瓜" });
            mGifData.Add(new EmojiGif() { name = "third_two.png", text = "好运连连" });
            mGifData.Add(new EmojiGif() { name = "third_three.png", text = "出来聊天" });
            mGifData.Add(new EmojiGif() { name = "third_four.png", text = "等待回复" });
            mGifData.Add(new EmojiGif() { name = "third_five.png", text = "溜了" });

            mGifData.Add(new EmojiGif() { name = "third_six.png", text = "拜托" });
            mGifData.Add(new EmojiGif() { name = "third_seven.png", text = "对不起" });
            mGifData.Add(new EmojiGif() { name = "third_eight.png", text = "诸事顺利" });
            mGifData.Add(new EmojiGif() { name = "third_nine.png", text = "尴尬" });
            mGifData.Add(new EmojiGif() { name = "third_ten.png", text = "欢迎" });

            mGifData.Add(new EmojiGif() { name = "fourty_one.png", text = "生气" });
            mGifData.Add(new EmojiGif() { name = "fourty_two.png", text = "你好" });


            //获取所有gif表情路径
            //string[] paths = Directory.GetFiles(, "*.*");
            AddControlToPanel(mGifData, gifPanel, ExpressionType.Gif);

            // 默认隐藏
            gifPanel.Visible = false;
        }

        // 初始化自定义表情
        private void InitCustomizeControl()
        {
            customizePanel = new Panel();
            customizePanel.BackColor = Color.FromArgb(243, 243, 243);
            layoutPanel.Controls.Add(customizePanel);

            //// 加入骰子和剪刀石头布
            //string[] paths = new string[3];
            //paths[0] = @"Res/Dice/dice_1.png";
            //paths[1] = @"Res/Jsb/jsb.png";
            //paths[2] = @"Res/CYC/cyc_r.png";

            //AddControlToPanel(paths, customizePanel, ExpressionType.Image);

            customizePanel.Visible = false;

            RequestUserCollect();
        }


        private void AddControlToPanel(List<EmojiGif> paths, Panel panel, ExpressionType type)
        {
            // 最少6列
            int col = 6, index = 0;
            // 最少3行
            int row = Math.Max((paths.Count / 6) + 1, 3);

            // string path = string.Empty;
            string name = string.Empty;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    index = i * 6 + j;
                    name = index < paths.Count ? paths[index].name : string.Empty;


                    var view = CreateImageEmoji(j * 71 + 1, i * 71 + 1);

                    if (!UIUtils.IsNull(name))
                    {
                        view.Image = new Bitmap(string.Concat(Applicate.LocalConfigData.GifFolderPath, name));
                        view.Name = name;
                        view.EmojiType = ExpressionType.Gif;
                        toolTip1.SetToolTip(view, paths[index].text);
                    }
                    else
                    {
                        view.Name = "";
                        view.EmojiType = ExpressionType.None;
                    }

                    //if (type == ExpressionType.Image)
                    //{
                    //    view.MouseWheel += Item_MouseWheel_CustomizePanel;
                    //}
                    panel.Controls.Add(view);
                }
            }

            panel.Size = new Size(col * 71 + 1, row * 71 + 1);
        }


        private ImageViewxEmoji CreateImageEmoji(int x, int y)
        {
            var view = new ImageViewxEmoji();
            view.Padding = new Padding(8);
            view.Size = new Size(70, 70);
            view.Location = new Point(x, y);
            view.BackColor = Color.White;
            // 添加滚轮事件
            view.MouseWheel += Item_MouseWheel;
            view.MouseClick += View_MouseClick;
            return view;
        }

        private ImageViewxEmoji FindCreateEmoji(int x, int y, int index)
        {
            if (customizePanel.Controls.Count > index)
            {
                var view = customizePanel.Controls[index] as ImageViewxEmoji;
                view.MouseWheel += Item_MouseWheel_CustomizePanel;
                return view;
            }
            else
            {
                var view = CreateImageEmoji(x, y);
                customizePanel.Controls.Add(view);
                customizePanel.Size = new Size(6 * 71 + 1, y + 71);
                view.MouseWheel += Item_MouseWheel_CustomizePanel;
                return view;
            }
        }

        /// <summary>
        /// 请求用户收藏表情
        /// </summary>
        public void RequestUserCollect()
        {
            string userid = Applicate.MyAccount.userId;
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/list")
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("userId", userid)
            .AddParams("pageIndex", "0")
            .AddParams("pageSize", "100")
            .NoErrorTip()
            .Build()
            .ExecuteJson<List<EmojiCollect>>((success, collects) =>
            {
                if (success && !UIUtils.IsNull(collects))
                {
                    int width = 1, height = 1;
                    // 最少6列
                    int col = 6, index = 0;
                    // 最少3行
                    int row = Math.Max((collects.Count / 6) + 1, 3);

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            index = i * 6 + j;

                            var view = CreateImageEmoji(j * 71 + 1, i * 71 + 1);

                            if (index < collects.Count)
                            {
                                view.Collect = collects[i];
                                view.Name = view.CollectEmojiId;
                                view.EmojiType = ExpressionType.Image;
                                view.ContextMenuStrip = cmsCustomizeMenu;

                                ImageLoader.Instance.Load(collects[i].url).Into((bitmp, path) =>
                                {
                                    if (!BitmapUtils.IsNull(bitmp) && path != null)
                                    {
                                        view.Image = bitmp;
                                    }
                                });
                            }

                            view.MouseWheel += Item_MouseWheel_CustomizePanel;
                            customizePanel.Controls.Add(view);
                        }
                    }

                    customizePanel.Size = new Size(col * 71 + 1, row * 71 + 1);
                    customizePanel.MouseWheel += Item_MouseWheel_CustomizePanel;
                    ////将room解析

                    //for (int i = 0; i < collects.Count; i++)
                    //{
                    //    var view = FindCreateEmoji(width, height, i + 3);
                    //    view.Collect = collects[i];
                    //    view.Name = view.CollectEmojiId;
                    //    view.EmojiType = ExpressionType.Image;
                    //    view.ContextMenuStrip = cmsCustomizeMenu;
                    //    ImageLoader.Instance.Load(collects[i].url).Into((bitmp, path) =>
                    //    {
                    //        if (!BitmapUtils.IsNull(bitmp) && path != null)
                    //        {
                    //            view.Image = bitmp;
                    //        }
                    //    });

                    //    width += 71;
                    //    if (width > customizePanel.Width - 71)
                    //    {
                    //        width = 1;
                    //        height += 71;
                    //    }
                    //}

                }
            });
        }

        private Control selected = null;
        private Panel currentPanel = null;

        private Panel emojiPanel = null; // 
        private Panel gifPanel = null;
        private Panel customizePanel = null;

        #region 选中与移出事件

        private void Tab_MouseEnter(object sender, EventArgs e)
        {
            if (selected != sender)
            {
                var tab = sender as Label;
                // 鼠标进入颜色
                tab.BackColor = Color.FromArgb(225, 225, 225);
            }
        }

        private void Tab_MouseLeave(object sender, EventArgs e)
        {
            if (selected != sender)
            {
                var tab = sender as Label;
                // 鼠标移除颜色
                tab.BackColor = Color.FromArgb(243, 243, 243);
            }
        }

        private void Tab_MouseClick(object sender, MouseEventArgs e)
        {
            if (selected != sender)
            {
                if (selected != null)
                {
                    // 回复默认色
                    selected.BackColor = Color.FromArgb(243, 243, 243);
                }

                var tab = sender as Label;
                // 鼠标选中色
                tab.BackColor = Color.White;
                OnSwitchTabLayout(tab.Tag.ToString());
                selected = tab;
            }
        }

        #endregion

        /// <summary>
        /// 切换表情面板
        /// </summary>
        /// <param name="v"></param>
        private void OnSwitchTabLayout(string v)
        {
            //   Console.WriteLine("OnSwitchTabLayout" + v);

            if (currentPanel != null)
            {
                currentPanel.Visible = false;
            }

            switch (v)
            {
                case "1":
                    // 表情
                    currentPanel = emojiPanel;
                    vScrollBar.Visible = false;
                    break;
                case "2":
                    // gif
                    currentPanel = gifPanel;
                    vScrollBar.Visible = true;
                    break;
                case "3":
                    // 表情
                    currentPanel = customizePanel;
                    vScrollBar.Visible = customizePanel.Controls.Count > 19 ? true : false;
                    break;
                default:
                    break;
            }

            currentPanel.Visible = true;
            currentPanel.BringToFront();
        }

        //回调：添加emoji表情到文本框
        public Action<ExpressionType, string> expressionAction;

        // emoji表情点击
        private void PicEmoji_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var item = sender as Control;
                // 回调界面  emoji表情
                expressionAction?.Invoke(ExpressionType.Emoji, item.Name);
                this.Hide();
            }
        }

        private ImageViewxEmoji select_picCustomize;
        // 图片表情点击事件
        private void View_MouseClick(object sender, MouseEventArgs e)
        {
            var item = sender as ImageViewxEmoji;

            if (e.Button == MouseButtons.Left)
            {
                if (item.EmojiType != ExpressionType.None)
                {
                    if (item.EmojiType == ExpressionType.Image)
                    {
                        //error
                        string url = UIUtils.IsNull(item.Collect.content) ? item.Collect.url : item.Collect.content;
                        expressionAction?.Invoke(item.EmojiType, url);

                    }
                    else
                    {
                        expressionAction?.Invoke(item.EmojiType, item.Name);
                    }

                    this.Hide();
                }
            }
            else
            {
                if (item.EmojiType == ExpressionType.Image)
                {
                    select_picCustomize = item;
                }
                else
                {
                    select_picCustomize = null;
                }
            }
        }

        // 删除表情
        private void menuItem_deleted_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            select_picCustomize = (ImageViewxEmoji)(toolStripMenuItem.Owner as CCWin.SkinControl.SkinContextMenuStrip).SourceControl;
            if (select_picCustomize != null)
            {
                ExpressionUlUtils.RemoveExpression(select_picCustomize.CollectEmojiId);

                frmExpressionTab = null;
                customizePanel.Controls.Clear();
                this.Hide();
                //select_picCustomize.ClearImage();
                //select_picCustomize.ContextMenuStrip = null;
                //select_picCustomize.Image = null;
                //select_picCustomize = null;

            }
        }

        private void BtnInit_MouseClick(object sender, MouseEventArgs e)
        {
            //FrmInitEmoji frm = new FrmInitEmoji();
            //frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2,
            //    this.Location.Y + (this.Height - frm.Height) / 2);
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.ShowDialog();
        }
    }


}

public class EmojiGif
{
    public string name;
    public string text;
}


public class EmojiCollect
{
    public string emojiId;
    public string content;
    public string msg;
    public string url;
}



