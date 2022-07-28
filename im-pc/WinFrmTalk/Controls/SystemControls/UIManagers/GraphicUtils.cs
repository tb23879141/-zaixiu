using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Controls.SystemControls
{
    public class GraphicUtils
    {
        public static GraphicsPath CreateRoundRectanglePath(int radius, Rectangle rectangle)
        {
            var r = new BorderRadius(radius);
            return CreateRoundRectanglePath(r, rectangle);
        }

        public static GraphicsPath CreateRoundRectanglePath(BorderRadius radius, Rectangle rectangle)
        {
            GraphicsPath result = new GraphicsPath();

            if (radius.TopLeft > 0)
            {
                result.AddArc(rectangle.X, rectangle.Y, radius.TopLeft, radius.TopLeft, 180, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X, rectangle.Y), new System.Drawing.Point(rectangle.X, rectangle.Y));
            }
            if (radius.TopRight > 0)
            {
                result.AddArc(rectangle.X + rectangle.Width - radius.TopRight, rectangle.Y, radius.TopRight, radius.TopRight, 270, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y), new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y));
            }
            if (radius.BottomRight > 0)
            {
                result.AddArc(rectangle.X + rectangle.Width - radius.BottomRight, rectangle.Y + rectangle.Height - radius.BottomRight, radius.BottomRight, radius.BottomRight, 0, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
            }
            if (radius.BottomLeft > 0)
            {
                result.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius.BottomLeft, radius.BottomLeft, radius.BottomLeft, 90, 90);
            }
            else
            {
                result.AddLine(new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height), new System.Drawing.Point(rectangle.X, rectangle.Y + rectangle.Height));
            }

            result.CloseFigure();
            return result;
        }



        public static GraphicsPath CreateRectanglePath(BorderWidth radius, Rectangle rectangle)
        {
            GraphicsPath result = new GraphicsPath();

            if (radius.LeftWidth > 0)
            {
                result.AddLine(rectangle.X, rectangle.Y, rectangle.X, rectangle.Height);
            }

            if (radius.TopWidth > 0)
            {
                result.AddLine(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Y);
            }

            if (radius.RightWidth > 0)
            {
                result.AddLine(rectangle.Width, rectangle.Y, rectangle.Width, rectangle.Height);
            }

            if (radius.BottomWidth > 0)
            {
                result.AddLine(rectangle.X, rectangle.Height, rectangle.Width, rectangle.Height);
            }

            return result;
        }

        internal static void Dispose(Brush brush)
        {
            if (brush != null)
            {
                brush.Dispose();
            }
        }

        internal static void Dispose(Pen pen)
        {
            if (pen != null)
            {
                pen.Dispose();
            }
        }
    }
}
