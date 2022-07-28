using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.View
{
    public partial class SLC_ItemList : FrmSuspension
    {
        //private List<Control> crls = null;
        private static string menuList = "";
        private static readonly object looker = new object();       //确保线程的同步，同一时间不能同时访问
        private static SLC_ItemList sLc_ItemList;
        private SLC_ItemList()
        {
            InitializeComponent();
            this.IsClose = false;
            this.IsVisible = true;
            this.Radius = 0;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static SLC_ItemList GetSLC_ItemList(string menuList)
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (sLc_ItemList == null)
            {
                lock (looker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (sLc_ItemList == null)
                    {
                        sLc_ItemList = new SLC_ItemList();
                    }
                }
            }
            SLC_ItemList.menuList = menuList;
            return sLc_ItemList;
        }

        public void RefreshItems()
        {
            flpSLC.Controls.Clear();
            int max_width = 0;
            int total_height = 0;
            //List<Control> crls = new List<Control>();
            JArray jArray = JsonConvert.DeserializeObject<JArray>(menuList);
            foreach (JToken item in jArray)
            {
                //创建菜单项
                Label lbl_item = new Label();
                lbl_item.AutoSize = false;
                lbl_item.BackColor = Color.White;
                lbl_item.Cursor = Cursors.Hand;
                lbl_item.ForeColor = Color.FromArgb(136, 136, 136);
                lbl_item.Font = new Font("微软雅黑", 9F);
                lbl_item.Location = Point.Empty;
                lbl_item.Height = 35;
                lbl_item.Text = UIUtils.DecodeString(item, "name").Trim();
                lbl_item.TextAlign = ContentAlignment.MiddleCenter;
                lbl_item.Width = (int)EQControlManager.GetStringTheSize(lbl_item.Text, lbl_item.Font).Width + 40;
                lbl_item.Margin = new Padding(1, 1, 1, 1);
                lbl_item.MouseClick += (s, ev) =>
                {
                    if (ev.Button != MouseButtons.Left)
                        return;

                    //可能为单条图文等特殊操作
                    string menuId = UIUtils.DecodeString(item, "menuId");
                    if (!string.IsNullOrEmpty(menuId))
                    {
                        HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + menuId).Build(false).Execute(null);

                    }
                    else
                    {
                        FrmBrowser frmBrowser = new FrmBrowser();
                        frmBrowser.OpenUrl(UIUtils.DecodeString(item, "url"), UIUtils.DecodeString(item, "userId"));
                        //Console.WriteLine(UIUtils.DecodeString(item, "url"));
                    }
                    this.Hide();
                };
                //lbl_item.MouseLeave += (s, ev) =>
                //{
                //    ((Control)s).BackColor = Color.White;
                //};
                //lbl_item.MouseEnter += (s, ev) =>
                //{
                //    ((Control)s).BackColor = Color.FromArgb(226, 226, 226);
                //};
                flpSLC.Controls.Add(lbl_item);
                max_width = max_width >= lbl_item.Width ? max_width : lbl_item.Width;
                total_height += lbl_item.Height;
                //lbl_item.Dock = DockStyle.Top;
            }
            this.Size = new Size(max_width, total_height + jArray.Count() * 3);
            //flpSLC.Controls.AddRange(crls.ToArray());
        }

        private void SLC_ItemList_Activated(object sender, EventArgs e)
        {
            RefreshItems();
        }

    }
}
