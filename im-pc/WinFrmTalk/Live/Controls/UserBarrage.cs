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

namespace WinFrmTalk.Live.Controls
{
   
    public partial class UserBarrage : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        public List<BarrageItem> barrageItemlst = new List<BarrageItem>();


        public UserBarrage()
        {
            InitializeComponent();
        }
        public  void SendBarrage(string Roomid, string Userid, string Text)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/barrage")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("roomId", Roomid)
               .AddParams("userId", Userid)
                .AddParams("text", Text)
               .Build()
               .Execute((success, result) =>
               {
                   if (success && result != null)
                   {

                       generateItem(Text);
                   }
               });
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
            item.verticalPos = r.Next(this.Height);
            int textwidth = FontWidth(item.textView.Font, item.textView, tx);
            item.textView.Location = new Point(10, item.verticalPos);
            this.Controls.Add(item.textView);

           
            barrageItemlst.Add(item);
        
        }
        private int FontWidth(Font font, Control control, string str)
        {
            Graphics g = control.CreateGraphics();
            SizeF siF = g.MeasureString(str, font); return (int)siF.Width;
        }
      public  bool isspoot = true;
        private void UserBarrage_Load(object sender, EventArgs e)
        {
            // 开始滚动
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
            if(barrageItemlst==null)
            {
                barrageItemlst = new List<BarrageItem>();
            }
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
