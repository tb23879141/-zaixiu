﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    public partial class UseSendChatKey : UserControl
    {
        private Action<MessageObject> onevent;
        private MessageObject message;

        public UseSendChatKey()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (message != null)
            {
                onevent?.Invoke(message);
            }
        }

        internal void BindData(MessageObject messageObject)
        {
            message = messageObject;
            //修改名片头像
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            ImageLoader.Instance.DisplayAvatar(messageObject.fromUserId, pictureBox1);

            if (message.isDownload == 1)
            {
                ChangeSendState(1);
            }
        }

        public void ChangeSendState(int isDown)
        {
            if (isDown == 1)
            {
                label2.ForeColor = Color.FromArgb(157, 157, 157);
            }
            else
            {
                label2.ForeColor = Color.FromArgb(157, 157, 157);
            }

        }

        internal void BindEvent(Action<MessageObject> onSendChatKey)
        {
            this.onevent = onSendChatKey;
        }
    }
}
