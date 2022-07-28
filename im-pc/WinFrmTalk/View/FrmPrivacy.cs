using CefSharp;
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
    public partial class FrmPrivacy : FrmBase
    {
        public string html;
        public FrmPrivacy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPrivacy_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            WebBrowser w = new WebBrowser();
            w.IsWebBrowserContextMenuEnabled = false;
            w.WebBrowserShortcutsEnabled = false;
            w.AllowWebBrowserDrop = false;
            w.Parent = this;
            w.Dock = DockStyle.Fill;
            w.DocumentText = html;
        }
       
    }
}
