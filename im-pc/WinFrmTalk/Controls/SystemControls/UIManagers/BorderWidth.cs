using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmTalk.Controls.SystemControls
{
    public struct BorderWidth
    {
        public int TopWidth { get; set; }
        public int RightWidth { get; set; }
        public int LeftWidth { get; set; }
        public int BottomWidth { get; set; }

        public BorderWidth(int all)
        {
            TopWidth = RightWidth = LeftWidth = BottomWidth = 1;
        }

        public BorderWidth(int left, int top, int right, int bottom)
        {
            LeftWidth = left;
            TopWidth = top;
            RightWidth = right;
            BottomWidth = bottom;
        }
    }
}