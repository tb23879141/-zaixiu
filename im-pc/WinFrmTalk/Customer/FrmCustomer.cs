using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Customer
{
    public partial class FrmCustomer : FrmBase
    {
        public FrmCustomer()
        {
            InitializeComponent();

            ////调用的方法（测试）
            //Leavingmsg leavingmsg = new Leavingmsg()
            //{
            //    MsgNumber = "487954",
            //    SenderName = "临时客户5476",
            //    SenderPhone = "13876543210",
            //    SenderEmail = "188758@qq.com",
            //    Channel = "测试网页",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now,
            //    Content = "111111111"
            //};
            //FrmCustomer frmCustomer = new FrmCustomer();
            //frmCustomer.BindData(leavingmsg);
            //frmCustomer.Show();
        }

        public void BindData(Leavingmsg leavingmsg)
        {
            this.Text = "留言编号" + leavingmsg.MsgNumber;
            lblSenderName.Text += leavingmsg.SenderName;
            lblSenderPhone.Text += leavingmsg.SenderPhone;
            lblSenderEmail.Text += leavingmsg.SenderEmail;
            lblChannel.Text += leavingmsg.Channel;
            lblCreateTime.Text += leavingmsg.CreateTime.ToString("yyyy-MM-dd hh:mm:ss");
            lblUpdateTime.Text += leavingmsg.UpdateTime.ToString("yyyy-MM-dd hh:mm:ss");
            lblContent.Text += leavingmsg.Content;
            lblSenderName.Text += leavingmsg.SenderName;

            //客服回复板块
            CustomerReplyItem item = new CustomerReplyItem();
            item.BindData("Admin", DateTime.Now, "15d4s6a847686846868");
            pnlReply.Controls.Add(item);
        }
    }
}
