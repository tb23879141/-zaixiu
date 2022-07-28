using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;
using WinFrmTalk.View;
using System.Runtime.InteropServices;
using System.Linq;

namespace WinFrmTalk
{
    public partial class LeftLayoutLive : UserControl
    {
        public LeftLayout leftlayout { get; set; }
        //功能模块
        Dictionary<ImageViewx, Panelmodel> imageViewxPairs = new Dictionary<ImageViewx, Panelmodel>();

        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        List<LiveModel> flabellst = new List<LiveModel>();

        public LeftLayoutLive()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }



        private void LoadLive()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/getFunctionModel")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("clientType", "4")
                   .Build().Execute((suss, data) =>
                   {
                       if (suss)
                       {
                           JArray array = JArray.Parse(UIUtils.DecodeString(data, "data"));
                           foreach (var item in array)
                           {
                               LiveModel liveModel = new LiveModel();
                               liveModel.PcIcon = UIUtils.DecodeString(item, "pcIcon");
                               liveModel.Name = UIUtils.DecodeString(item, "name");
                               liveModel.PcUrl = UIUtils.DecodeString(item, "pcUrl");
                               liveModel.PcStatus = UIUtils.DecodeString(item, "pcStatus");

                               flabellst.Add(liveModel);
                           }
                           AddImageViewX(flabellst);
                       }
                   });
        }

        /// <summary>
        /// 添加功能模块
        /// </summary>
        /// <param name="liveModelList"></param>
        private void AddImageViewX(List<LiveModel> liveModelList)
        {
            for (int i = 0; i < liveModelList.Count; i++)
            {
                Panelmodel panelmodel = new Panelmodel();

                ImageViewx imageViewx = new ImageViewx();//图标
                imageViewx.Size = new Size(36, 36);
                imageViewx.Location = new Point(2, 0);
                imageViewx.SizeMode = PictureBoxSizeMode.StretchImage;
                imageViewx.Name = liveModelList[i].Name;
                imageViewx.Tag = liveModelList[i].PcUrl;
                imageViewx.Cursor = Cursors.Hand;
                imageViewx.Click += new EventHandler(ImageViewx_Click);
                imageViewx.MouseMove += new MouseEventHandler(ImageViewx_mouseMove);
                imageViewx.MouseLeave += new EventHandler(ImageViewx_mouseLeave);

                Label label = new Label();//文字说明
                label.Size = new Size(42, 21);
                label.Font = label1.Font;
                label.Text = liveModelList[i].Name;
                label.Margin = new Padding(0, 0, 0, 0);
                label.Cursor = Cursors.Hand;
                label.Tag = liveModelList[i].PcUrl;
                label.Location = new Point(2, -2);
                label.Click += new EventHandler(label_Click);
                label.MouseMove += new MouseEventHandler(label_mouseMove);
                label.MouseLeave += new EventHandler(label_mouseLeave);

                Panel panel = new Panel();
                panel.Location = new Point(0, imageViewx.Height+2);
                panel.BackColor = Color.Transparent;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                panel.Size = new Size(40, 18);
                panel.Controls.Add(label);


              
                Panel panelItem = new Panel();//外框
                panelItem.Size = new Size(panel.Width, panel.Height + imageViewx.Height + 2);
                panelItem.Margin = new Padding(7, 20, 0, 0);
                panelItem.MouseMove += new MouseEventHandler(panelItem_mouseMove);
                panelItem.MouseLeave += new EventHandler(panelItem_mouseLeave);

                panelItem.Controls.Add(panel);
                panelItem.Controls.Add(imageViewx);

                panelmodel.panelItem = panelItem;
                panelmodel.panel = panel;
                panelmodel.label = label;


                imageViewxPairs.Add(imageViewx, panelmodel);
                imageViewx.Load(Applicate.URLDATA.data.downloadUrl + liveModelList[i].PcIcon);
                //flowLayoutPanelBorder1.Controls.Add(imageViewx);
                flowLayoutPanelBorder1.Controls.Add(panelItem);
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (((Label)sender).Name.Contains("直播"))
            {
                this.leftlayout.SelectIndex = MainTabIndex.LivePage;
                MainForm.SelectIndex = MainTabIndex.LivePage;
                return;
            }
            string BrowserUrl = ((Label)sender).Tag == null ?
               "https://www.baidu.com/" : ((Label)sender).Tag.ToString() + "?access_token=" + Applicate.Access_Token + "&httpKey=" + UIUtils.EncodeBase64(Applicate.HTTP_KEY);
            if (!FrmChromePairs.ContainsKey(BrowserUrl))
            {
                FrmBrowser frmChromeBrowser = new FrmBrowser();
                frmChromeBrowser.layoutLive = this;
                frmChromeBrowser.OpenUrl(BrowserUrl, Applicate.MyAccount.userId, true);
                frmChromeBrowser.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - 1300) / 2, 0);
                frmChromeBrowser.Show();
                FrmChromePairs.Add(BrowserUrl, frmChromeBrowser);
            }
            else
            {
                FrmChromePairs[BrowserUrl].Activate();
            }
        }

        public Dictionary<string, FrmBrowser> FrmChromePairs = new Dictionary<string, FrmBrowser>();
        //绑定功能模块点击事件
        private void ImageViewx_Click(object sender, EventArgs e)
        {
            if (((ImageViewx)sender).Name.Contains("直播"))
            {
                this.leftlayout.SelectIndex = MainTabIndex.LivePage;
                MainForm.SelectIndex = MainTabIndex.LivePage;
                return;
            }
            string BrowserUrl = ((ImageViewx)sender).Tag == null ?
               "https://www.baidu.com/" : ((ImageViewx)sender).Tag.ToString() + "?access_token=" + Applicate.Access_Token + "&httpKey=" + UIUtils.EncodeBase64(Applicate.HTTP_KEY);
            if (!FrmChromePairs.ContainsKey(BrowserUrl))
            {
                FrmBrowser frmChromeBrowser = new FrmBrowser();
                frmChromeBrowser.layoutLive = this;
                frmChromeBrowser.OpenUrl(BrowserUrl, Applicate.MyAccount.userId, true);
                frmChromeBrowser.Location = new Point((SystemInformation.PrimaryMonitorSize.Width - 1300) / 2, 0);
                frmChromeBrowser.Show();
                FrmChromePairs.Add(BrowserUrl, frmChromeBrowser);
            }
            else
            {
                FrmChromePairs[BrowserUrl].Activate();
            }
        }

        private void LeftLayoutLive_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //加载直播功能模块
                LoadLive();
            });
        }

        private void imageViewxLive_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
                if (me.Button != MouseButtons.Left)
                    return;
            this.leftlayout.SelectIndex = MainTabIndex.BannerPage;
            MainForm.SelectIndex = MainTabIndex.BannerPage;
        }

        #region 窗体拖拽
        // 利用Windows 的 API 函数：SendMessage 和 ReleaseCapture   
        const uint WM_SYSCOMMAND = 0x0112;
        const uint SC_MOVE = 0xF010;
        const uint HTCAPTION = 0x0002;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private void flowLayoutPanelBorder1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.MainForm.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        #region 鼠标进入事件
        private void imageViewxLive_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.BackgroundImage == null)
            {
                label1.ForeColor = Color.White;
                panel1.BackgroundImage = Properties.Resources.left_br;
            }
        }

        private void imageViewxLive_MouseLeave(object sender, EventArgs e)
        {
            if (panel1.BackgroundImage != null)
            {
                label1.ForeColor = Color.Black;
                panel1.BackgroundImage = null;
            }
        }
        private void ImageViewx_mouseMove(object sender, MouseEventArgs e)
        {
            if (imageViewxPairs[((ImageViewx)sender)].panel.BackgroundImage == null)
            {
                imageViewxPairs[((ImageViewx)sender)].panel.BackgroundImage = Properties.Resources.left_br;
                imageViewxPairs[((ImageViewx)sender)].label.ForeColor = Color.White;
            }
        }

        private void ImageViewx_mouseLeave(object sender, EventArgs e)
        {
            if (imageViewxPairs[((ImageViewx)sender)].panel.BackgroundImage != null)
            {
                imageViewxPairs[((ImageViewx)sender)].panel.BackgroundImage = null;
                imageViewxPairs[((ImageViewx)sender)].label.ForeColor = Color.Black;
            }
        }

        private void label_mouseLeave(object sender, EventArgs e)
        {
            foreach (var item in imageViewxPairs.Values)
            {
                if (item.label == (Label)sender && item.panel.BackgroundImage != null)
                {
                    item.panel.BackgroundImage = null;
                    item.label.ForeColor = Color.Black;
                }
            }
        }

        private void label_mouseMove(object sender, MouseEventArgs e)
        {
           
            foreach (var item in imageViewxPairs.Values)
            {
                if (item.label == (Label)sender && item.panel.BackgroundImage == null)
                {
                    item.panel.BackgroundImage = Properties.Resources.left_br;
                    item.label.ForeColor = Color.White;
                }
            }
        }
        private void panelItem_mouseLeave(object sender, EventArgs e)
        {
            foreach (var item in imageViewxPairs.Values)
            {
                if (item.panelItem == (Panel)sender && item.panel.BackgroundImage != null)
                {
                    item.panel.BackgroundImage = null;
                    item.label.ForeColor = Color.Black;
                }
            }
        }

        private void panelItem_mouseMove(object sender, MouseEventArgs e)
        {
            foreach (var item in imageViewxPairs.Values)
            {
                if (item.panelItem == (Panel)sender && item.panel.BackgroundImage == null)
                {
                    item.panel.BackgroundImage = Properties.Resources.left_br;
                    item.label.ForeColor = Color.White;
                }
            }
        }

        #endregion

    }
    public class Panelmodel
    {
        public Panel panel { get; set; }
        public Panel panelItem { get; set; }

        public Label label { get; set; }
    }
}
