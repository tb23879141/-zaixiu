using CefSharp;
using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FrmBrowser : FrmBase
    {
        #region 全局变量
        private ChromiumWebBrowser webView;
        private bool isMessobject;
        private MessageObject messageList;
        public static string Url;
        //默认浏览器
        public readonly string Default = "http://www.google.com/";
        private static readonly bool DebuggingSub = Debugger.IsAttached;
        //验证窗体被动打开事件
        public static bool isInitSet;
        //经纬度
        public double Longitude;
        private double Latitude;
        private string Locadpath;
        private bool isMapLocation;
        public string Userid { get; private set; }
        private string openUrl;//已经打开的网址

        #endregion

        #region 窗体加载
        public FrmBrowser()
        {
            InitializeComponent();

        }
        private void FrmBrowser_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
        }

        #endregion

        #region 浏览器配置
        /// <summary>
        /// 浏览器配置
        /// </summary>
        private void BrowsserSetting(bool isExpand = false)
        {
            //开启授权
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            Control.CheckForIllegalCrossThreadCalls = false;
            webView = new CefSharp.WinForms.ChromiumWebBrowser(Url);

            if (isExpand)
            {
                pboxZhuang.Location = pboxcollect.Location;
                pboxcollect.Visible = false;
                this.Width = 1300;
                this.Height = SystemInformation.PrimaryMonitorSize.Width;
            }

            panel1.Controls.Add(webView);
            //窗体完毕
            webView.FrameLoadEnd += (hhh, kkk) =>
            {
                timer.Stop();
            };
            //窗体加载
            webView.LoadingStateChanged += (hhh, kkk) =>
            {
                timer.Start();
            };
            Font font = new Font(Applicate.SetFont, 20.5f);
            webView.Dock = DockStyle.Fill;
            webView.Font = font;
            webView.LifeSpanHandler = new OpenPageSelf();
            panel1.Controls.Add(webView);
            //选择事件
            webView.AddressChanged += ((hhh, kkk) =>
            {
                //当前页面的Url
                Url = webView.Address;
                LogUtils.Log(webView.Address);
                timer.Start();
            });
            this.Show();
        }
        #endregion



        #region 打开链接
        /// <summary>
        /// 打开链接
        /// </summary>
        /// <param name="url"></param>
        public void BrowserShow(MessageObject message, bool isCollect = false)
        {
            isMessobject = true;
            messageList = message;
            if (message.type == kWCMessageType.Location)
            {
                isMapLocation = true;
                pboxcollect.Visible = false;
                //Url = "https://www.shiku.co/BaiDuMap.html?Longitude=" + message.location_y + "&Latitude=" + message.location_x + "";


                ShowMap(message.location_y, message.location_x);
                return;
            }
            else
            {
                isMapLocation = false;
                Url = message.content;
            }

            // 如果是收藏界面打开的窗体就隐藏收藏按钮
            if (isCollect)
            {
                pboxZhuang.Location = pboxcollect.Location;
                pboxcollect.Visible = false;
            }

            BrowsserSetting();
        }

        /// <summary>
        /// 打开链接
        /// </summary>
        /// <param name="url"></param>
        public void OpenUrl(string url, string userid, bool isExpand = false)
        {
            isMessobject = false;
            Url = url;
            openUrl = url;
            Userid = userid;
            BrowsserSetting(isExpand);
        }

        #endregion

        #region 地图
        public void initCefSharp()
        {
            //开启授权
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            string path = Applicate.AppCurrentDirectory + "BaiDuMap.html";
            webView = new ChromiumWebBrowser(path);
            Locadpath = path;
            Url = path;
            webView.Dock = DockStyle.Fill;
            panel1.Controls.Add(webView);
        }

        public void ShowMap(double longitude, double latitude)
        {
            initCefSharp();
            Longitude = longitude;
            Latitude = latitude;
            this.Show();
        }
        #endregion



        #region 同窗体新链接
        /// <summary>
        /// 在自己窗口打开链接
        /// </summary>
        internal class OpenPageSelf : ILifeSpanHandler
        {
            public bool DoClose(IWebBrowser browserControl, IBrowser browser)
            {
                return false;
            }

            public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
            {

            }

            public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
            {

            }

            public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
    string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
    IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
            {
                newBrowser = null;
                var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
                chromiumWebBrowser.Load(targetUrl);
                return true; //Return true to cancel the popup creation copyright by codebye.com.
            }
        }
        #endregion

        #region 图标功能
        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBrows.Value < progressBrows.Maximum)
            {
                progressBrows.Value++;
            }
            else
            {
                progressBrows.Value = 0;
                timer.Stop();
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxrefresh_Click(object sender, EventArgs e)
        {
            webView.Load(Url);
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxBack_Click_1(object sender, EventArgs e)
        {
            webView.Back();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxCopy_Click(object sender, EventArgs e)
        {
            //获取当前的链接
            //清空剪切板，防止里面之前有内容
            Clipboard.Clear();
            //给剪切板设置图片对象
            Clipboard.SetText(Url);
            HttpUtils.Instance.ShowTip("复制成功");
        }

        /// <summary>
        /// 默认系统浏览器打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxOpen_Click(object sender, EventArgs e)
        {
            //系统默认浏览器
            System.Diagnostics.Process.Start(Url);
        }

        /// <summary>
        /// 转发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxZhuang_Click(object sender, EventArgs e)
        {
            //打开好友选择器
            var frm = Applicate.GetWindow<FrmFriendSelect>();
            if (frm == null)
            {
                frm = new FrmFriendSelect();
                frm.Mark = "FrmBrowser";
            }
            else
            {
                frm.Activate();
                if (string.Equals(frm.Mark, "FrmBrowser"))
                {
                    return;
                }
            }

            frm.Mark = "FrmBrowser";
            frm.LoadFriendsData();
            frm.AddConfrmListener((UserData) =>
            {
                foreach (var item in UserData)
                {
                    if (isMessobject)
                    {
                        MessageObject msg = messageList.CopyMessage();
                        if (!isMapLocation)
                        {

                            msg.content = Url;
                            messageList = msg;
                        }
                        //调用xmpp
                        MessageObject messImgs = ShiKuManager.SendForwardMessage(item.Value, messageList);
                        Messenger.Default.Send(messImgs, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                        return;
                    }
                    MessageObject messImg = ShiKuManager.SendTextMessage(item.Value, Url);
                    Messenger.Default.Send(messImg, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                }
            });
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboxcollect_Click(object sender, EventArgs e)
        {
            if (!isMessobject)
            {
                CollectUtils.CollectLink(Url);
                return;
            }

            // 链接消息类型特殊处理一下
            if (messageList != null && messageList.type == kWCMessageType.Link)
            {
                CollectUtils.CollectLink(Url);
                return;
            }

            // 普通消息的收藏
            CollectUtils.CollectMessage(messageList);
        }
        #endregion

        #region 图标提示
        private void pboxCopy_MouseEnter(object sender, EventArgs e)
        {
            string str = LanguageXmlUtils.GetValue("browser_copy_url", "复制链接地址");
            toolTip1.SetToolTip(pboxCopy, str);
        }

        private void pboxrefresh_MouseEnter(object sender, EventArgs e)
        {
            string str = LanguageXmlUtils.GetValue("browser_refresh", "刷新");
            toolTip1.SetToolTip(pboxrefresh, str);
        }

        private void pboxOpen_MouseEnter(object sender, EventArgs e)
        {
            string str = LanguageXmlUtils.GetValue("browser_open_by_default", "用默认浏览器打开");
            toolTip1.SetToolTip(pboxOpen, str);
        }

        private void pboxZhuang_MouseEnter(object sender, EventArgs e)
        {
            string str = LanguageXmlUtils.GetValue("browser_forward", "转发");
            toolTip1.SetToolTip(pboxZhuang, str);
        }

        private void pboxcollect_MouseEnter(object sender, EventArgs e)
        {
            string str = LanguageXmlUtils.GetValue("browser_collect", "收藏");
            toolTip1.SetToolTip(pboxcollect, str);
        }
        #endregion

        #region 窗体关闭
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放
            this.Dispose();
        }
        #endregion
    }
}
