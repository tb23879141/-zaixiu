using Newtonsoft.Json;
using PBMessage;
using System;
using System.Collections.Generic;

namespace WinFrmTalk.Model
{

    // 消息记录实体   tigase/shiku_msgs

    internal class MessageRecordList
    {

        public MessageRecordList()
        {
            data = new List<MessageRecordModel>();
        }

        public List<MessageRecordModel> data { get; set; }
    }

    internal class MessageRecordModel
    {

        /// <summary>
        /// 
        /// </summary>
        public object body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int direction { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sender_jid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string receiver_jid { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public long ts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string messageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double timeSend { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public long sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public long receiver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }


        public ChatMessage JsonConvertChat()
        {
            string text = this.message.Replace("&quot;", "\"");
            ChatMessage chat = JsonConvert.DeserializeObject<ChatMessage>(text);
            return chat;
        }

        internal MessageObject ToMessageObject(int isGroup = 0)
        {

            string text = this.message.Replace("&quot;", "\"");
            ChatMessage chat = JsonConvert.DeserializeObject<ChatMessage>(text);

            MessageObject message = ChatToMessageObject(chat);

            if (message != null)
            {
                message.isGroup = isGroup;
                if (isGroup == 1)
                {
                    message.FromId = message.myUserId;
                }

                if (message.type == kWCMessageType.Card && !UIUtils.IsNull(message.other))
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(message.other);

                    if (data.ContainsKey("group"))
                    {
                        message.timeLen = Convert.ToInt32(data["group"]);
                    }

                    try
                    {
                        if (message.timeLen == 1)
                        {
                            message.fileName = data["groupId"].ToString();
                            message.objectId = data["roomJid"].ToString();
                            message.signature = data["roomId"].ToString();
                        }
                        else
                        {
                            message.fileName = data["account"].ToString();
                        }
                    }
                    catch (Exception)
                    {


                    }

                }

                // 接龙
                if (message.type == kWCMessageType.Solitaire)
                {
                    var data = JsonConvert.DeserializeObject<SolitaireData>(message.objectId);
                    if (data != null && data.solitaireBodies != null)
                    {
                        message.timeLen = Math.Min(3, data.solitaireBodies.Count);
                    }
                }

                if (message.type == kWCMessageType.Withdraw)
                {
                    message.content = message.fromUserName + ": 撤回了一条消息";
                    message.type = kWCMessageType.Remind;
                }

                //处理群聊控制消息
                if (message.type >= kWCMessageType.RoomMemberNameChange && message.type <= kWCMessageType.RoomNoticeEdit)
                {
                    ProcessGroupManageMessage(message);
                }

                //处理群聊控制消息
                if (message.type == kWCMessageType.TYPE_83 || message.type == kWCMessageType.TYPE_93 || message.type == kWCMessageType.RedBack || message.type == kWCMessageType.TYPE_TRANSFER_RECEIVE)
                {
                    string seetext = "";
                    if (!Applicate.ENABLE_RED_PACKAGE)
                    {
                        seetext = ",请在手机上查看";
                    }

                    string fromName;
                    string toName;
                    if (message.fromUserId.Equals(message.myUserId))
                    {
                        fromName = "你";
                    }
                    else
                    {
                        fromName = message.fromUserName;
                    }

                    if (message.toUserId.Equals(message.myUserId) || message.fromUserId.Equals(message.toUserId))
                    {
                        if (message.fromUserId.Equals(message.myUserId))
                        {
                            toName = "自己";
                        }
                        else
                        {
                            toName = message.toUserName;
                        }
                    }
                    else
                    {
                        toName = message.toUserName;
                    }
                    if (message.type == kWCMessageType.TYPE_83)
                    {
                        message.content = fromName + "领取了" + toName + "的红包" + seetext;
                    }

                    else if (message.type == kWCMessageType.TYPE_93)
                    {
                        message.content = "暂不支持此类型的消息显示";
                    }
                    else if (message.type == kWCMessageType.RedBack)
                    {
                        message.content = "红包已过期已退回零钱";
                    }


                }
                if (message.type == kWCMessageType.AudioChatCancel)
                {
                    message.content = "拒绝语音通话";
                }
                else if (message.type == kWCMessageType.VideoChatCancel)
                {
                    message.content = "拒绝视频通话";
                }
                else if (message.type == kWCMessageType.AudioChatEnd)
                {
                    message.content = "语音通话结束";
                }
                else if (message.type == kWCMessageType.VideoChatEnd)
                {
                    message.content = "视频通话结束";
                }
                else if (message.type == kWCMessageType.TYPE_TRANSFER_RECEIVE)
                {
                    message.content = "转账已被对方领取";
                }
                else if (message.type == (kWCMessageType)950)
                {
                    // 群活动
                    message.type = kWCMessageType.Typing;
                }
                else if (message.type == (kWCMessageType)956)
                {
                    //群资源
                    message.type = kWCMessageType.Typing;
                }
                else if (message.type == (kWCMessageType)987)
                {

                    message.type = kWCMessageType.Typing;
                }
                else if (message.type == (kWCMessageType)958 || message.type == (kWCMessageType)957)
                {
                    //群公告
                    if (!UIUtils.IsNull(message.other))
                    {
                        HandlerGroupNotify(message);
                    }
                    else
                    {
                        return null;
                    }

                }
                else if (message.type == kWCMessageType.ResouresActive)
                {
                    // 958 不知道

                }
                else if (message.type == kWCMessageType.SDKLink)
                {
                    try
                    {
                        // 958 不知道
                        var data = JsonConvert.DeserializeObject<MyGroupResource>(message.objectId);

                        if (data.type == 1000)
                        {
                            message.content = "[秀吧]";
                            message.type = kWCMessageType.ResouresSocial;
                        }
                        else
                        {
                            message.content = "[资源]";
                            message.type = kWCMessageType.ResouresResoures;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                }
                else if (message.type == kWCMessageType.Text && !UIUtils.IsNull(message.other))
                {
                    HandlerGroupNotify(message);
                }


                message.isSend = 1;
                message.isRead = 1;
                message.isUpload = 1;

            }

            return message;
        }

        public void HandlerGroupNotify(MessageObject message)
        {
            // other 字段不会保存到数据库,导致数据丢失
            var data = JsonConvert.DeserializeObject<MyGroupNotice>(message.other);

            if (UIUtils.IsNull(data.text) && !UIUtils.IsNull(data.title))
            {
                data.text = data.title;
                data.title = "";
            }


            if (UIUtils.IsNull(data.shareURL) && !UIUtils.IsNull(data.picPath))
            {
                data.shareURL = data.picPath[0];
            }

            message.fileName = data.title;
            message.objectId = data.shareURL;
            message.content = data.text;
            message.type = kWCMessageType.ResouresNotify;
        }
        private void ProcessGroupManageMessage(MessageObject msg)
        {
            msg.FromId = msg.objectId;
            msg.ToId = msg.myUserId;

            switch (msg.type)
            {
                case kWCMessageType.RoomMemberNameChange://改群内昵称
                    // 更新最后一条消息内容，通知UI刷新
                    msg.content = UIUtils.QuotationName(msg.toUserName) + "修改昵称为:" + UIUtils.QuotationName(msg.content);
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomNameChange://改群名
                    msg.content = UIUtils.QuotationName(msg.fromUserName) + "修改群名为:" + UIUtils.QuotationName(msg.content);
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomDismiss://解散
                    msg.content = "该群已被群主解散";
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomExit://退群
                    if (msg.fromUserId.Equals(msg.toUserId))
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "退出了群组";
                    }
                    else
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "移除成员:" + UIUtils.QuotationName(msg.toUserName);
                    }

                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomNotice://公告
                    // 更新最后一条消息内容，通知UI刷新
                    msg.content = UIUtils.QuotationName(msg.fromUserName) + "发布新公告: \n" + msg.content;
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomInvite://进群
                    if (msg.fromUserId.Equals(msg.toUserId) || msg.toUserId.Equals(msg.myUserId))
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "进入群组";
                    }
                    else
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "邀请成员:" + UIUtils.QuotationName(msg.toUserName);
                    }
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomReadVisiblity://显示阅读人数
                    if ("1".Equals(msg.content))
                    {
                        msg.content = "群主开启了显示消息已读人数功能";
                    }
                    else
                    {
                        msg.content = "群主关闭了显示消息已读人数功能";
                    }

                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomIsVerify://群验证
                    // 通知聊天记录页刷新
                    if ("0".Equals(msg.content) || "1".Equals(msg.content))
                    {
                        msg.content = "0".Equals(msg.content) ? "群主已关闭进群验证" : "群主已开启进群验证";
                        msg.type = kWCMessageType.Remind;
                    }
                    else
                    {

                    }
                    break;
                case kWCMessageType.RoomUnseenRole://隐身人

                    break;
                case kWCMessageType.RoomAdmin://管理员
                    if (msg.content == "0")//取消管理员
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "取消管理员" + UIUtils.QuotationName(msg.toUserName);
                    }
                    else if (msg.content == "1")//设置管理员8
                    {
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "设置:" + UIUtils.QuotationName(msg.toUserName) + "为管理员";
                    }

                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomIsPublic://公开群
                    msg.content = msg.content == "0" ? "群主将本群修改为公开群组" : " 群主将本群修改为私密群组";
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomInsideVisiblity://显示群内成员
                    msg.content = msg.content == "0" ? "群主关闭了查看群成员功能" : "群主开启了查看群成员功能";
                    // 更新最后一条消息内容，通知UI刷新
                    msg.type = kWCMessageType.Remind;

                    break;
                case kWCMessageType.RoomUserRecommend://是否允许发送名片
                    msg.content = msg.content == "0" ? "群主关闭了群内私聊功能" : "群主开启了群内私聊功能";
                    // 更新最后一条消息内容，通知UI刷新
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomMemberBan://禁言成员

                    double banTime = double.Parse(msg.content);
                    if (banTime > TimeUtils.CurrentTime() + 3)
                    {
                        var date = Helpers.StampToDatetime(banTime);
                        string time = date.Month + "-" + date.Day + " " + date.Hour + ":" + date.Minute;
                        msg.content = UIUtils.QuotationName(msg.fromUserName) + "对" + UIUtils.QuotationName(msg.toUserName) + "设置了禁言,截止:" + time;
                    }
                    else
                    {
                        msg.content = UIUtils.QuotationName(msg.toUserName) + "已被" + UIUtils.QuotationName(msg.fromUserName) + "取消禁言";
                    }

                    msg.type = kWCMessageType.Remind;

                    break;
                case kWCMessageType.RoomAllBanned://群组全员禁言 
                    msg.content = msg.content == "0" ? "已关闭全体禁言" : "已开启全体禁言";
                    // 更新最后一条消息内容，通知UI刷新
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomAllowMemberInvite://是否允许群内普通成员邀请陌生人

                    msg.content = msg.content == "0" ? "群主关闭了普通成员邀请功能" : "群主开启了普通成员邀请功能";
                    // 更新最后一条消息内容，通知UI刷新
                    msg.type = kWCMessageType.Remind;

                    break;
                case kWCMessageType.RoomManagerTransfer://转让群主
                    msg.content = UIUtils.QuotationName(msg.toUserName) + "已成为新群主";
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomAllowUploadFile://是否允许成员上传群文件
                    msg.content = msg.content == "0" ? "群主关闭了普通成员上传群共享" : "群主开启了普通成员上传群共享";
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomAllowConference://是否允许群会议
                    msg.content = msg.content == "0" ? "群主关闭了普通成员发起会议功能" : "群主开启了普通成员发起会议功能";
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomAllowSpeakCourse://是否允许群成员开课
                    msg.content = msg.content == "0" ? "群主关闭了普通成员发送课件功能" : "群主开启了普通成员发送课件功能";
                    // 更新最后一条消息内容，通知UI刷新
                    msg.type = kWCMessageType.Remind;
                    break;
                case kWCMessageType.RoomNewOverDate://群消息过期
                    break;
                case kWCMessageType.RoomNoticeEdit://编辑群公告
                    // 更新最后一条消息内容，通知UI刷新
                    msg.content = UIUtils.QuotationName(msg.fromUserName) + "修改了群公告:" + UIUtils.QuotationName(msg.content);
                    msg.type = kWCMessageType.Remind;
                    break;
                default:
                    return;
            }
        }

        public MessageObject ChatToMessageObject(ChatMessage message)
        {
            MessageObject chat = new MessageObject();
            chat.fromUserId = message.fromUserId;
            chat.fromUserName = message.fromUserName;
            chat.toUserId = message.toUserId;
            chat.toUserName = message.toUserName;
            chat.timeSend = message.timeSend / 1000.0;

            if (message.deleteTime > 1500000000000L)
            {
                chat.deleteTime = message.deleteTime / 1000.0;
            }
            else
            {
                chat.deleteTime = message.deleteTime;
            }

            chat.type = (kWCMessageType)message.type;
            chat.isEncrypt = message.encryptType;
            // 兼容老版本
            if (message.encryptType == 0 && message.isEncrypt)
            {
                chat.isEncrypt = 1;
            }
            chat.isReadDel = message.isReadDel ? 1 : 0;
            chat.content = message.content;
            chat.objectId = message.objectId;
            chat.fileName = message.fileName;
            chat.fileSize = message.fileSize;
            chat.timeLen = Convert.ToInt32(message.fileTime);
            chat.location_x = message.location_x;
            chat.location_y = message.location_y;

            MessageHead head = message.messageHead;
            chat.isGroup = head.chatType - 1;
            chat.FromId = message.fromUserId;
            chat.ToId = head.to;
            chat.messageId = head.messageId;
            chat.other = message.other;
            return chat;
        }
    }

}
