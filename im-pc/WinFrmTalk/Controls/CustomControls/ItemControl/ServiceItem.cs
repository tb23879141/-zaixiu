using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.CustomControls
{
    public class ServiceItem : LabelBorder
    {
        public ServiceItem()
        {
            this.Border.IsShowLeft = false;
            this.Border.IsShowTop = true;
            this.Border.IsShowRight = true;
            this.Border.IsShowBottom = false;
        }

        public void BindMenuList(string menuList)
        {
            this.Tag = menuList;

            this.MouseClick += ((sender, e) =>
            {
                if (e.Button != MouseButtons.Left)
                    return;

                //绑定菜单列表
                SLC_ItemList sLC_ItemList = SLC_ItemList.GetSLC_ItemList(this.Tag.ToString());
                sLC_ItemList.TopMost = true;
                sLC_ItemList.Show();
                Point screenPoint = PointToScreen(Point.Empty);
                //设置弹出窗起始坐标
                int location_x = (this.Width- sLC_ItemList.Width) / 2 + screenPoint.X;
                int location_y = screenPoint.Y - sLC_ItemList.Height;
                sLC_ItemList.Location = new Point(location_x, location_y);
            });            
        }
    }
}
