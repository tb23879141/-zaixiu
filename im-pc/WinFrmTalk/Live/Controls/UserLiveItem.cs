using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserLiveItem : UserControl
    {
        public UserLiveItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置昵称
        /// </summary>
        public string NickName { get { return lblName.Text; } set { lblName.Text = value; } }

      
    }
}
