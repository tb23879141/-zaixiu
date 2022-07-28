using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace WinFrmTalk.Controls
{
    public struct BarrageItem
    {
        public Label textView;//文本框
        public int textColor;//文本颜色
        public String text;//文本对象
        public int textSize;//文本的大小
        public int moveSpeed;//移动速度
        public int verticalPos;//垂直方向显示的位置
        public int textMeasuredWidth;//字体显示占据的宽度
    }
    public partial class UserBarrage : UserControl
    {
       

        /// <summary>
        /// 
        /// </summary>
        public List<BarrageItem> barrageItemlst { get; set; }

        public int maxwid { get; set; }
        public int maxheight { get; set; }
     

        public UserBarrage()
        {
            InitializeComponent();
            
        }
        public void generateItem(string barrageText)
        {
            BarrageItem item = new BarrageItem();
            //把我们的每行弹幕的行数顺序跟弹幕进行一个随机
            String tx = barrageText;
            //随机弹幕大小
            item.textView = new System.Windows.Forms.Label();
            item.textView.Text = tx;
            item.textView.Font = new Font("微软雅黑", 10.5F);
            item.textView.BackColor = Color.Transparent;
            item.textView.AutoSize = true;
            Random random = new Random();
            item.textView.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //弹幕在y轴上出现的位置
            var r = new Random(Guid.NewGuid().GetHashCode());
            item.verticalPos = r.Next(maxheight);
            int textwidth = FontWidth(item.textView.Font, item.textView, tx);
            item.textView.Location = new Point(-textwidth - 1, item.verticalPos);
            this.Controls.Add(item.textView);
            barrageItemlst.Add(item);
        }
        private int FontWidth(Font font, Control control, string str)
        {
            Graphics g = control.CreateGraphics();
            SizeF siF = g.MeasureString(str, font); return (int)siF.Width;
        }
        
        private void UserBarrage_Load(object sender, EventArgs e)
        {
            // 开始滚动
            Task.Factory.StartNew(() =>
            {
                // 运动代码
                while (true)
                {
                    Thread.Sleep(16);

                    Invoke(new Action(() =>
                    {
                        LoopLable();
                    }));
                }
            });
        }
        private void LoopLable()
        {
            if (barrageItemlst.Count > 0)
            {
                foreach (var barrageitem in barrageItemlst)
                {
                    Point p1 = barrageitem.textView.Location;
                    p1.X += 1;
                    barrageitem.textView.Location = p1;

                }
            }
        }
    }
}

