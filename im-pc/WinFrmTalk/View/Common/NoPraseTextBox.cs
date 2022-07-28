using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.View.Common
{
    public partial class NoPraseTextBox : TextBox
    {

        private const int WM_GETTEXT = 0x000d;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CONTEXTMENU = 0x007B;
        private const int WM_RBUTTONDOWN = 0x0204;

        public NoPraseTextBox()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_RBUTTONDOWN)
                return;//WM_RBUTTONDOWN是为了不让出现鼠标菜单
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
