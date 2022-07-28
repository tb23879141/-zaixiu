using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.LayouotControl
{

    public delegate void EventSendMessageHandler(MessageObject message);


    public partial class ChatSendLayout : UserControl
    {
        public event EventSendMessageHandler OnSendMessage;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            btnSend.Text = LanguageXmlUtils.GetValue("btn_send", btnSend.Text);
        }

        public ChatSendLayout()
        {
            InitializeComponent();
            LoadLanguageText();
        }

        private void LblExpression_MouseClick(object sender, MouseEventArgs e)
        {
            //获取鼠标点击表情时的坐标
            Point ms = Control.MousePosition;
            var frmExpressionTab = FrmExpressionTab.GetExpressionTab();
            //修改列表索引
            frmExpressionTab.tabExpression.SelectedIndex = 0;
            //设置弹出窗起始坐标
            int location_x = ms.X - e.X - 8;
            int location_y = ms.Y - frmExpressionTab.Height - e.Y - 5;
            frmExpressionTab.Location = new Point(location_x, location_y);
            //传递对象给新窗口
            //frmExpressionTab.SetFriendTarget();
            //控件显示在最上层
            frmExpressionTab.TopMost = true;
            frmExpressionTab.Show();

            //回调
            frmExpressionTab.expressionAction = (type, code) =>
            {
                switch (type)
                {
                    //选择了emoji表情
                    case ExpressionType.Emoji:
                     
                        break;
                    case ExpressionType.Gif:
                      
                        break;
                    case ExpressionType.Image:
                        //此处code为url
                        break;
                }
            };
        }


        private MessageObject CreateEmojiMessage(string code) {
            var message = new MessageObject();
            return message;
        }



        private void lblSendFile_Click(object sender, EventArgs e)
        {

        }

        private void lblScreen_Click(object sender, EventArgs e)
        {

        }

        private void lblLocation_Click(object sender, EventArgs e)
        {

        }

        private void lblSoundRecord_Click(object sender, EventArgs e)
        {

        }

        private void lblCamera_Click(object sender, EventArgs e)
        {

        }

        private void lblPhotography_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var message = new MessageObject();
            message.content = "111";
            OnSendMessage(message);
        }
    }
}
