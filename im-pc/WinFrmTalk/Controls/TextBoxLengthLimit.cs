using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    public partial class TextBoxLengthLimit : UserControl
    {
        /// <summary>
        /// 重写Text的属性，文本框的内容
        /// </summary>
        public override string Text { get => txtContent.Text; set => txtContent.Text = value; }

        public TextBoxLengthLimit()
        {
            InitializeComponent();
        }

        private void TxtContent_TextChanged(object sender, EventArgs e)
        {
            lblNumber.Text = txtContent.Text.Length + "//" + txtContent.MaxLength;
        }
    }
}
