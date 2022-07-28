using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Properties;
using System.Drawing.Drawing2D;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class RegisterPanelEx : Panel
    {
        public RegisterPanelEx()
        {
            InitializeComponent();
        } /// <summary>
          /// 字段和属性 ， panel的颜色
          /// </summary>
        private Color _panelColor;
        public Color PanelColor
        {
            get { return _panelColor; }
            set { this._panelColor = value; }
        }

        /// <summary>
        /// 字段和属性，border的颜色
        /// </summary>
        private Color _borderColor;
        public Color BorderColor
        {
            get { return _borderColor; }
            set { this._borderColor = value; }
        }

        /// <summary>
        /// 阴影区域大小
        /// </summary>
        private int shadowSize = 5;

        //将预备的小图标转化

        static Image shadowDownRight = new Bitmap(Resources.tshadowdownright);
        static Image shadowDown = new Bitmap(Resources.tshadowdown);

        static Image shadowLeft = new Bitmap(Resources.tshadowleft);
        static Image shadowLeftDown = new Bitmap(Resources.tshadowdownleft);

        static Image shadowLeftTop = new Bitmap(Resources.tshadowtopleft);

        /// <summary>
        /// 重绘panel
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Get the graphics object. We need something to draw with
            Graphics g = e.Graphics;

            //下边画笔
            TextureBrush shadowDownBrush = new TextureBrush(shadowDown, WrapMode.Tile);

            //左边画笔
            TextureBrush shadowLeftBrush = new TextureBrush(shadowLeft, WrapMode.Tile);

            //给画笔定位
            shadowDownBrush.TranslateTransform(0, Height - shadowSize);

            shadowLeftBrush.TranslateTransform(0, 0);

            //每个阴影区域非配一个矩形区域
            Rectangle shadowDownRectangle = new Rectangle(
                shadowSize,                                                     //X
                Height - shadowSize,                                         //Y
                Width - shadowSize * 2,                                     //width(stretches)
                shadowSize                                                    //height
                );

            Rectangle shadowRightRectangle = new Rectangle(
              Width - shadowSize,                                           //X
              shadowSize,                                                     //Y
              shadowSize,                                                    //width
              Height - shadowSize * 2                                       //height(stretches)
              );

            Rectangle shadowTopRectangle = new Rectangle(
              shadowSize,                                                    //X
              0,                                                                     //Y
              Width - shadowSize * 2,                                       //width
              shadowSize                                                     //height(stretches)
              );

            Rectangle shadowLeftRectangle = new Rectangle(
              0,                                                                    //X
              shadowSize,                                                    //Y
              shadowSize,                                                    //width
              Height - shadowSize * 2                                       //height(stretches)
              );

            //在底部画出阴影
            g.FillRectangle(shadowDownBrush, shadowDownRectangle);
            //在左边画出阴影
            g.FillRectangle(shadowLeftBrush, shadowLeftRectangle);

            //四个角落处的阴影
            g.DrawImage(shadowDownRight, new Rectangle(Width - shadowSize, Height - shadowSize, shadowSize, shadowSize));
            g.DrawImage(shadowLeftDown, new Rectangle(0, Height - shadowSize, shadowSize, shadowSize));
            g.DrawImage(shadowLeftTop, new Rectangle(0, 0, shadowSize, shadowSize));


            Rectangle fullRectangle = new Rectangle(
                1,
                1,
                Width - (shadowSize + 2),
                Height - (shadowSize + 2)
                );

            if (PanelColor != null)
            {
                SolidBrush bgBrush = new SolidBrush(_panelColor);
                g.FillRectangle(bgBrush, fullRectangle);
            }

            //给panel添加边框颜色
            if (_borderColor != null)
            {
                Pen borderPen = new Pen(BorderColor);
                g.DrawRectangle(borderPen, fullRectangle);
            }

            //释放画笔资源
            shadowDownBrush.Dispose();
            shadowLeftBrush.Dispose();

            shadowDownBrush = null;
            shadowLeftBrush = null;
        }

        //Correct resizing
        protected override void OnResize(EventArgs e)
        {
            base.Invalidate();
            base.OnResize(e);
        }
    }
}
