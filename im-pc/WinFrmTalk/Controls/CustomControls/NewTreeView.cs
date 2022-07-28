using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Properties;

namespace WinFrmTalk
{
    public class NewTreeView : TreeView
    {
        //双缓冲
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        Color backColor = Color.WhiteSmoke;
        public Color SetBackColor
        {
            get { return backColor; }
            set { backColor = value; }
            
        }
        // 窗体背景颜色
        //Color backColor = Color.WhiteSmoke;

        // 节点字体
        Font foreFont = new Font("微软雅黑", 9F, FontStyle.Regular);

        // 字体颜色
        Brush foreBrush = new SolidBrush(Color.Black);// Color.FromArgb(81, 81, 81));

        // 选中的背景颜色
        Brush recBrush = new SolidBrush(Color.FromArgb(202, 200, 198));

        // 选中的文字颜色
        //Brush recSelectedBrush = new SolidBrush(Color.FromArgb(248, 248, 255));


        Image icon;


        // 图标和文字间距
        private const int incointerval = 17;

        public NewTreeView()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.ItemHeight = 30;//节点行高          
            this.BackColor = backColor;
            this.ShowLines = true;
            this.HotTracking = true;
            this.Indent = 20;//节点X值缩进量
            this.Scrollable = true;
            this.BorderStyle = BorderStyle.None;
            this.Font = foreFont;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // 根节点未展开
            if (!e.Node.IsExpanded)
            {
                icon = Resources.ec;
            }
            else//根节点展开
            {
                icon = Resources.ex;
            }

            // 绘制选中的样式
            if (e.Node.IsSelected)
            {
                // 画出背景颜色
                Rectangle box = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                e.Graphics.FillRectangle(recBrush, box);

                // 重绘图标，一级节点X值默认为23，padding-left为6,17 = 23 - 6
                e.Graphics.DrawImage(icon, e.Node.Bounds.X - incointerval, e.Node.Bounds.Y + 9, 10, 10);
                // 重绘文字
                e.Graphics.DrawString(e.Node.Text, foreFont, foreBrush, e.Node.Bounds.Left, e.Node.Bounds.Top + 6);
            }
            else
            {
                //刷新背景色防止字体图标重绘叠加
                e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

                //重绘图标，一级节点X值默认为23，padding-left为6,17 = 23 - 6
                e.Graphics.DrawImage(icon, e.Node.Bounds.X - incointerval, e.Node.Bounds.Y + 9, 10, 10);

                //重绘字体
                e.Graphics.DrawString(e.Node.Text, foreFont, foreBrush, e.Node.Bounds.Left, e.Node.Bounds.Top + 6);
            }
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            TreeNode tn = this.GetNodeAt(e.Location);
            if (tn == null)
            {
                return;
            }

            this.SelectedNode = tn;

            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            // 点击图标的时候 节点会自己切换， 而点击图标外的其他地方需要我们自己去切换
            Rectangle bounds = new Rectangle(tn.Bounds.X - 23, tn.Bounds.Y + 2, 25, tn.Bounds.Height);
            if (!bounds.Contains(e.Location))
            {
                tn.Toggle();
            }
        }
    }
}
