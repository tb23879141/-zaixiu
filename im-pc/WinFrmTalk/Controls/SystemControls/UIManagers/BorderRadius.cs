using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmTalk.Controls.SystemControls
{
    public struct BorderRadius
    {
        public int TopLeft { get; set; }
        public int TopRight { get; set; }
        public int BottomLeft { get; set; }
        public int BottomRight { get; set; }

        public BorderRadius(int all)
        {
            this.TopLeft = this.TopRight = this.BottomLeft = this.BottomRight = all;
        }
    }
}
