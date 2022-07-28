using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class RecentTextBoxEx : RichTextBox
    {
        private const string ATME_TEXT = "[有人@我]";
        private const string ATALL_TEXT = "[@全体成员]";

        public RecentTextBoxEx()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.None;
        }
        private const int WM_SETFOCUS = 0x7;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        public override Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        /// <summary>
        /// 屏蔽控件所有鼠标消息的发送
        /// </summary>
        /// <param name="m">消息</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private int atme;
        public int AtMe
        {
            get
            {
                return atme;
            }
            set
            {
                atme = value;
                Invalidate();
            }
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {
            //Console.WriteLine("OnPaint" + this.Text);
            this.Width = 155;
            if (this.Enabled && !string.IsNullOrEmpty(this.Text))
            {
                int offsetx = 0;
                if (AtMe == 1)
                {
                    using (Brush brush = new SolidBrush(System.Drawing.Color.Red))
                    {
                        e.Graphics.DrawString(ATME_TEXT, this.Font, brush, base.ClientRectangle);
                    }

                    SizeF size = e.Graphics.MeasureString(ATME_TEXT, this.Font);
                    offsetx = (int)size.Width;
                }
                else if (AtMe == 2)
                {
                    using (Brush brush = new SolidBrush(System.Drawing.Color.Red))
                    {
                        e.Graphics.DrawString(ATALL_TEXT, this.Font, brush, base.ClientRectangle);
                    }

                    SizeF size = e.Graphics.MeasureString(ATALL_TEXT, this.Font);
                    offsetx = (int)size.Width;
                }


                Color nearestColor = e.Graphics.GetNearestColor(base.Enabled ? this.ForeColor : SystemColors.Control);
                System.Drawing.Rectangle rectangle = e.ClipRectangle;

                rectangle.Location = new Point(e.ClipRectangle.Location.X + offsetx, e.ClipRectangle.Location.Y);
                using (Brush brush = new SolidBrush(nearestColor))
                {
                    e.Graphics.DrawString(Text, this.Font, brush, rectangle);
                }
            }
        }




        public string GroupAtModifyColor(string richTextBox)
        {
            //用正则表达式，获取@的key
            MatchCollection matchs = Regex.Matches(richTextBox, @"@[^\s]+\s", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            string str = "";
            foreach (Match match in matchs)
            {
                //修改字符串颜色
                str += "" + match.Value;

            }

            return str;
        }
    }
}
