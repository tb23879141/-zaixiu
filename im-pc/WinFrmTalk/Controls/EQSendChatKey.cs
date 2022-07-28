using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls
{
    public class EQSendChatKey : EQBaseControl
    {
        UseSendChatKey sendchatkey;

        public EQSendChatKey(string strJson) : base(strJson)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }


        public EQSendChatKey(MessageObject messageObject) : base(messageObject)
        {
            isShowRedPoint = true;
            isRemindMessage = false;
        }

        public override void Calc_PanelWidth(Control control)
        {
            BubbleWidth = control.Width;
            BubbleHeight = control.Height;
        }

        public override Control ContentControl()
        {
            sendchatkey = new UseSendChatKey();
            Calc_PanelWidth(sendchatkey);
            sendchatkey.BindData(messageObject);
            sendchatkey.BindEvent(OnSendChatKey);
            return sendchatkey;
        }


        private void OnSendChatKey(MessageObject message)
        {
            if (string.Equals(message.fromUserId, message.myUserId))
            {
                HttpUtils.Instance.ShowTip("等待他人发送密钥");
                return;
            }

            message = message.GetMessageObject();
            message.isRead = 1;

            DisposeRedPoint();

            if (message.isDownload == 1)
            {
                sendchatkey.ChangeSendState(1);
                var main = HttpUtils.Instance.FindFrm(typeof(FrmMain));
                main.ShowTip("不能重复发送密钥");
                return;
            }


            message.UpdateIsRead(message.messageId);

            var friend = message.GetFriend();

            if (friend.IsLostKeyGroup == 1)
            {
                HttpUtils.Instance.ShowTip("密钥丢失状态不能发送密钥给其他成员");
                return;
            }

            // 请求服务器获取群成员的rsa公钥
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/getMemberRsaPublicKey")
                .AddParams("roomId", friend.RoomId)
                .AddParams("userId", message.fromUserId)
                .Build().Execute((state, data) =>
                {
                    if (state)
                    {
                        string publickey = UIUtils.DecodeString(data, "rsaPublicKey");

                        if (RSA.VerifyFromBase64(message.objectId, publickey, message.content))
                        {
                            string chatkey = SecureChatUtil.DecryptChatkey(friend.UserId, friend.ChatKeyGroup, Applicate.API_KEY);

                            ShiKuManager.SendRequestChatKeyMessage(message, chatkey, publickey, true);
                            ShiKuManager.SendRequestChatKeyMessage(message, chatkey, publickey, false);

                            sendchatkey.ChangeSendState(0);
                        }
                    }
                    else
                    {
                        HttpUtils.Instance.ShowTip("密钥发送失败");
                    }
                });


        }

        /// <summary>
        /// 红点消失
        /// </summary>
        /// <param name="msg"></param>
        public void DisposeRedPoint()
        {
            //更新UI
            var crl_msg = sendchatkey.Parent.Controls["lab_redPoint"];
            if (crl_msg != null && crl_msg is Label lab_redPoint && lab_redPoint.Image != null)
            {
                //去除红点
                DrawIsReceive(lab_redPoint, 1);
            }
        }
    }
}
