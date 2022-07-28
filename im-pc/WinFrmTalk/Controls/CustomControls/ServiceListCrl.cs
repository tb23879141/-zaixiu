using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class ServiceListCrl : UserControl
    {
        public bool isShowMultiSelect { get; set; } //指示是否显示多选面板
        private bool isShowList { get; set; }   //指示是否已显示快捷栏
        private ShowMsgPanel showMsgPanel { get; set; } //父级控件

        private bool LastFdIsOfficial = false;  //

        public ServiceListCrl()
        {
            InitializeComponent();
        }
        public void SetList(Friend friend, ShowMsgPanel showMsgPanel)
        {
            //this.showMsgPanel = showMsgPanel;
            //if (isShowMultiSelect)
            //{
            //    //关闭快捷栏
            //    this.SendToBack();
            //    this.Visible = false;
            //    //设置消息面板高度
            //    if (isShowList)
            //    {
            //        int diff = showMsgPanel.Bottom_Panel.Height - this.Height;
            //        showMsgPanel.xListView.Height -= diff;
            //    }
            //    //设置底部面板
            //    showMsgPanel.Bottom_Panel.BringToFront();
            //    showMsgPanel.Bottom_Panel.Visible = true;
            //    isShowList = false;
            //}
            //else
            //{
            //    if (Applicate.URLDATA.data.enableMpModule == 1 && friend.UserType == 2)
            //    {
            //        showMsgPanel.lblSLC.Visible = true;
            //        //自动绑定控件数据
            //        BindData(friend);
            //        if(LastFdIsOfficial && this.Visible)
            //        {
            //            //设置底部面板
            //            showMsgPanel.Bottom_Panel.SendToBack();
            //            showMsgPanel.Bottom_Panel.Visible = false;
            //            return;
            //        }
            //        //if (isShowList) //避免重复设置
            //        //    return;
            //        isShowList = true;
            //        LastFdIsOfficial = true;
            //    }
            //    else
            //    {
            //        LastFdIsOfficial = false;
            //        showMsgPanel.lblSLC.Visible = false;
            //        if (!isShowList) //避免重复设置
            //            return;
            //        isShowList = false;
            //    }
            //    SetLayout();
            //}            
        }

        public void BindData(Friend friend, ShowMsgPanel showMsgPanel)
        {
            this.showMsgPanel = showMsgPanel;
            //clear data
            var crls = this.Controls.Find("ServiceItem", false);
            foreach (Control crl in crls)
                this.Controls.Remove(crl);

            string userId = friend.UserId;
            //http get请求获得数据
            HttpUtils.Instance.InitHttp(this);
            //将数据保存
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "public/menu/list") //获取公众号快捷栏
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", friend.UserId)
                .Build()
                .Execute((success, result) =>
                {
                    //需要添加到快捷栏的控件集合
                    //List<Control> list_crl = new List<Control>();

                    string data = UIUtils.DecodeString(result, "data");
                    JArray jo = JsonConvert.DeserializeObject<JArray>(data);
                    //获得快捷栏失败
                    if (!success || jo.Count == 0)
                    {
                        if (isShowList || this.Visible)   //如果当前显示的为快捷栏
                        {
                            //设置消息面板高度
                            int h_diff = showMsgPanel.Bottom_Panel.Height - this.Height;
                            showMsgPanel.xListView.Height -= h_diff;
                        }
                        this.SendToBack();
                        this.Visible = false;
                        //设置底部面板
                        showMsgPanel.Bottom_Panel.BringToFront();
                        showMsgPanel.Bottom_Panel.Visible = true;
                        showMsgPanel.lblSLC.Visible = false;
                        isShowList = false;
                        return;
                    }

                    //计算平均宽度
                    int avg_wdith = (this.Width - lblShow.Width) / jo.Count;
                    int diff = (this.Width - lblShow.Width) % jo.Count;
                    for (int i = 0; i < jo.Count; i++)
                    {
                        //Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>();
                        JToken jt = jo[i];

                        if (!userId.Equals(UIUtils.DecodeString(jt, "userId")))
                            return;

                        //添加快捷栏按钮
                        ServiceItem lblBtn = new ServiceItem();
                        lblBtn.Name = "ServiceItem";
                        lblBtn.AutoSize = false;
                        lblBtn.BackColor = Color.Transparent;
                        lblBtn.Cursor = Cursors.Hand;
                        lblBtn.Text = UIUtils.DecodeString(jt, "name");
                        lblBtn.Location = new Point(i* avg_wdith,0);
                        lblBtn.Height = this.Height;
                        lblBtn.Width = diff > 0 ? avg_wdith + 1 : avg_wdith;
                        lblBtn.TextAlign = ContentAlignment.MiddleCenter;
                        lblBtn.ForeColor = Color.FromArgb(136, 136, 136);
                        lblBtn.Font = new Font("微软雅黑", 10F);
                        lblBtn.BindMenuList(UIUtils.DecodeString(jt, "menuList"));
                        if (diff > 0)
                            diff--;

                        this.Controls.Add(lblBtn);
                    }


                });
        }

        private void SetLayout()
        {
            //showMsgPanel.SuspendLayout();
            if (isShowList)     //显示快捷栏
            {
                //设置快捷栏
                this.BringToFront();
                this.Visible = true;
                //设置消息面板高度
                int diff = showMsgPanel.Bottom_Panel.Height - this.Height;
                showMsgPanel.xListView.Height += diff;
                //设置底部面板
                showMsgPanel.Bottom_Panel.SendToBack();
                showMsgPanel.Bottom_Panel.Visible = false;
            }
            else    //关闭快捷栏
            {
                this.SendToBack();
                this.Visible = false;
                //设置消息面板高度
                int diff = showMsgPanel.Bottom_Panel.Height - this.Height;
                showMsgPanel.xListView.Height -= diff;
                //设置底部面板
                showMsgPanel.Bottom_Panel.BringToFront();
                showMsgPanel.Bottom_Panel.Visible = true;
            }
            //showMsgPanel.ResumeLayout();
        }

        private void LblShow_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            //isShowList = !isShowList;
            //SetLayout();
            showMsgPanel.SetDialogBoxSize(DialogBox.Normal);
        }

        private void ServiceListCrl_SizeChanged(object sender, EventArgs e)
        {
            var crls = this.Controls.Find("ServiceItem", false);
            if (crls.Length < 1)
                return;

            //计算平均宽度
            int avg_wdith = (this.Width - lblShow.Width) / crls.Length;
            int diff = (this.Width - lblShow.Width) % crls.Length;
            int width_diff = 0;
            for (int i = 0; i < crls.Length; i++)
            {
                Control item = crls[i];
                item.Location = new Point(item.Location.X + width_diff * i, item.Location.Y);
                int new_width = diff > 0 ? avg_wdith + 1 : avg_wdith;
                width_diff = new_width - item.Width;
                item.Width = diff > 0 ? avg_wdith + 1 : avg_wdith;
            }
        }
    }
}
