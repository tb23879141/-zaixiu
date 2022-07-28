using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    public class PictureBoxEx : PictureBox
    {
        public PictureBoxEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Size = new Size(200, 150);
        }
    }
}
