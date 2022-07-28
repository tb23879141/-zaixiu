using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Base;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public partial class FrmBarrage : Form
    {
      
        public FrmBarrage()
        {
            InitializeComponent();
           
        }
       
        public List<BarrageItem> barrageItemlst = new List<BarrageItem>();//弹幕列表
        public bool isspoot = true;
        public bool IsShow = false;
        int i = 0;
        public void generateItem(string barrageText)
        {
            BarrageItem item = new BarrageItem();
            //把我们的每行弹幕的行数顺序跟弹幕进行一个随机
            String tx = barrageText;
            //随机弹幕大小
            item.textView = new System.Windows.Forms.Label();
            item.textView.Size = new Size(750, 25);
            item.textView.AutoSize = false;
            item.textView.AutoEllipsis = true;
            item.textView.Text = tx;
            item.textView.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            item.textView.BackColor = Color.Transparent;

            Random random = new Random();
            item.textView.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //弹幕在y轴上出现的位置
            var r = new Random(Guid.NewGuid().GetHashCode());
            int count = 4;
            if (i > count) i = 0;
            int height = 5 + 25 * i;i++;
            item.verticalPos = r.Next(10,this.Height-25);
            //int textwidth = 300;// (int)EQControlManager.GetStringTheSize(tx, item.textView.Font).Width;
            int TextStart = item.textView.PreferredSize.Width;
            if (TextStart> item.textView.Width)
            {
                TextStart = item.textView.Width;
            }
            //int textwidth = FontWidth(item.textView.Font, item.textView, tx);
            item.textView.Location = new Point(-TextStart, height);
            this.barrageItemlst.Add(item);
            this.Controls.Add(item.textView);
        }
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;

            }
        }

        private void FrmBarrage_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                // 运动代码
                while (isspoot)
                {
                    Thread.Sleep(16);
                    if (!this.IsDisposed)
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                LoopLable();
                            }));
                        }
                        catch (Exception)
                        {

                        }

                    }

                }
            });
        }
        private void LoopLable()
        {
            if (barrageItemlst == null)
            {
                barrageItemlst = new List<BarrageItem>();
            }
            if (barrageItemlst.Count > 0)
            {
                for (int i = barrageItemlst.Count - 1; i >= 0; i--)
                {
                    Point p1 = barrageItemlst[i].textView.Location;
                    p1.X += 2;
                    barrageItemlst[i].textView.Location = p1;
                    if (p1.X >= this.Width)
                    {
                        this.Controls.Remove(barrageItemlst[i].textView);
                        barrageItemlst[i].textView.Dispose();
                        barrageItemlst.RemoveAt(i);
                    }

                }

            }
        }

        private void FrmBarrage_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsShow = false;
        }
    }
}
