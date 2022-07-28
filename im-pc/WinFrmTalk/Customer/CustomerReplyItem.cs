using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Customer
{
    public partial class CustomerReplyItem : UserControl
    {
        public CustomerReplyItem()
        {
            InitializeComponent();
        }

        public void BindData(string name, DateTime time, string content)
        {
            lblName.Text = name;
            lblTime.Text = time.ToString("yyyy-MM-dd hh:mm:ss");
            lblContent.Text = content;
        }
    }
}
