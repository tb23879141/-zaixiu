using CefSharp;
using CefSharp.Web;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.View
{
    public partial class FrmChromeBrowser : FrmBase
    {
        public string url;
        public HtmlString html;
        public FrmChromeBrowser()
        {
            InitializeComponent();
        }
        public void LoadingChromeBrowser()
        {
            ChromiumWebBrowser chromeBrowser;
            if (html !=null)
            {
                    chromeBrowser = new ChromiumWebBrowser(html);
            }
            else
            {
                 chromeBrowser = new ChromiumWebBrowser(url);
            }
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.FrameLoadEnd += webbrowser_FrameLoadEnd;
            LivePanel.Controls.Add(chromeBrowser);
        }
        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            browser.SetZoomLevel(0.5);

        }
        private void FrmChromeBrowser_Load(object sender, EventArgs e)
        {
            InitializeChromium();
            LoadingChromeBrowser();
        }
        //初始化浏览器并启动
        public void InitializeChromium()
        {
            try
            {
                CefSettings settings = new CefSettings();
                // 设置是否使用GPU
                settings.CefCommandLineArgs.Add("disable-gpu", "1");
                // 设置是否使用代理服务
                settings.CefCommandLineArgs.Add("no-proxy-server", "1");
                // 设置是否启动js交互，假如需要原生与js方法互调，则需要设置为true
                CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                // 初始化cef
                Cef.Initialize(settings, true, browserProcessHandler: null);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void FrmChromeBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放
            this.Dispose();
        }
    }
    internal class MenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }
        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }
        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }
        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
