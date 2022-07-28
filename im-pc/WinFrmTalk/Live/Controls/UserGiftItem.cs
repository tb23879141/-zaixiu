using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserGiftItem : UserControl
    {
        public UserGiftItem()
        {
            InitializeComponent();
        }
        private Gift _gift;
        /// <summary>
        /// 设置礼物参数
        /// </summary>
        public Gift GiftData
        {
            get { return _gift; }
            set
            {
                _gift = value;
                lab_money.Text = _gift.price.ToString();
                ImageLoader.Instance.DisplayImage(_gift.photo, pic_gift);

            }
        }
        /// <summary>
        //、父窗体点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parent_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

    }
}
