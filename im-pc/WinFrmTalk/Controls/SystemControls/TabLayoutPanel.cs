using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 布局面板
    /// </summary>
    public class TabLayoutPanel : Control
    {
        public delegate void ItmeFocusChangedHandler(object sender, bool focus);

        private int indicateLeft;

        public FocusControl LastControl { private set; get; }

        /// <summary>
        /// 控件分割间距
        /// -1 == 平均分布
        /// </summary>
        public int ItemMaginLeft { get; set; } = -1;

        /// <summary>
        /// 是否绘制分割线
        /// </summary>
        public int DelimitLineHeight { get; set; } = 25;

        /// <summary>
        /// 回调界面
        /// </summary>
        public event MouseEventHandler ItemSelected;

        public event ItmeFocusChangedHandler ItemFocusChanged;

        public TabLayoutPanel()
        {
            this.ControlAdded += TabLayoutPanel_ControlAdded;
        }


        private void TabLayoutPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (ItemMaginLeft == -1 && this.Controls.Count > 0)
            {
                int rect_width = this.Width - (this.Controls.Count * this.Controls[0].Width);

                int marginLeft = rect_width / (this.Controls.Count + 1);

                indicateLeft = marginLeft >> 1;

                int marginTop = (this.Height - this.Controls[0].Height) / 2;

                var location = new System.Drawing.Point(marginLeft, marginTop);

                foreach (Control item in this.Controls)
                {
                    item.Location = location;
                    location.X += (item.Width + marginLeft);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DelimitLineHeight > 0 && this.Controls.Count > 0)
            {
                Graphics graphics = e.Graphics;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


                using (var pen = new Pen(Color.FromArgb(220, 220, 220), 0.3f))
                {
                    int y = (this.Height - DelimitLineHeight - 1) >> 1;
                    for (int i = 1; i < this.Controls.Count; i++)
                    {
                        var item = this.Controls[i];

                        graphics.DrawLine(pen, item.Location.X - indicateLeft, y, item.Location.X - indicateLeft, y + DelimitLineHeight);
                    }
                }
            }
        }


        public void AppendControl(Control item, bool focus = false)
        {
            item.MouseClick += Item_MouseClick;

            if (ItemMaginLeft > 0)
            {
                indicateLeft = ItemMaginLeft >> 1;
                int marginLeft = ItemMaginLeft;

                foreach (Control view in this.Controls)
                {
                    marginLeft += (view.Width + ItemMaginLeft);
                }

                int marginTop = (this.Height - item.Height) / 2;
                var location = new System.Drawing.Point(marginLeft, marginTop);
                item.Location = location;

            }


            var control = item as FocusControl;
            control.FocusChanged(focus);

            if (focus)
            {
                LastControl = control;
            }

            ItemFocusChanged?.Invoke(item, focus);

            this.Controls.Add(item);

            this.Invalidate();
        }


        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            if (LastControl != sender)
            {
                var current = sender as FocusControl;

                if (LastControl != null)
                {
                    LastControl.FocusChanged(false);
                    ItemFocusChanged?.Invoke(LastControl, false);
                }

                current.FocusChanged(true);
                ItemFocusChanged?.Invoke(sender, true);
                LastControl = current;

                this.Invoke(new Action(() =>
                {
                    ItemSelected?.Invoke(sender, e);
                }));
            }
        }
    }

    public interface FocusControl
    {
        void FocusChanged(bool focus);
    }

}
