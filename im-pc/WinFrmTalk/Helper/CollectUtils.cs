using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.GroupDomain;
using WinFrmTalk.Model;

namespace WinFrmTalk.Helper
{
    public class CollectUtils
    {
        private static string collmsgId = null;

        #region http保存消息

        /// <summary>
        /// 单条保存
        /// </summary>
        /// <param name="msg"></param>  
        internal static void CollectMessage(MessageObject msg, bool saveEmoji = false, string folderId = "")
        {
            if (msg == null || UIUtils.IsNull(msg.messageId))
            {
                LogUtils.Log("保存数据为空");
                return;
            }

            if (msg.messageId.Equals(collmsgId))
            {
                Console.WriteLine("快速点击保存");
                return;
            }

            if (!msg.isCollect())
            {
                HttpUtils.Instance.ShowTip("文字/图片/语音/视频/文件 消息才能被保存");
                return;
            }

            string saveType = ToSaveType(msg);

            // 修改禅道8282bug,存表情和保存参数emoji有细微的差别，emoji是msg，保存是msgid
            string emoji = saveEmoji ? toSaveEmojiParams(msg) : toCollectParams(msg);
            collmsgId = msg.messageId;


            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/add") //保存
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("emoji", emoji)
                .AddParams("type", saveType)
                .AddParams("folderId", folderId)
                .NoErrorTip()
                 .Build().AddErrorListener((code, err) =>
                 {
                     if (code == 0)
                     {
                         HttpUtils.Instance.ShowTip("不能重复保存消息");
                     }
                     else
                     {
                         //code == 105002 端到端加密消息
                         HttpUtils.Instance.ShowTip(err);
                     }
                     collmsgId = null;
                 })
                .Execute((sccess, room) =>
                {
                    collmsgId = null;
                    if (sccess)
                    {
                        if (saveEmoji)
                        {
                            HttpUtils.Instance.ShowTip("存表情成功");
                        }
                        else
                        {
                            HttpUtils.Instance.ShowTip("保存成功");
                            // 更新保存页
                            Messenger.Default.Send("1", MessageActions.UPDATE_COLLECT_LIST);
                        }
                    }
                });
        }

        public static string ToSaveType(MessageObject msg)
        {
            /// <param name="type">类型1图片，2视频，3文件，4音乐，5其他</param>
            switch (msg.type)
            {
                case kWCMessageType.File:
                    return "3";
                case kWCMessageType.Image:
                    return "1";
                case kWCMessageType.Video:
                    return "2";
                default:
                    return "5";
            }
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="msglst"></param>
        internal static void CollectMessage(List<MessageObject> msgList)
        {
            if (msgList == null || UIUtils.IsNull(msgList))
            {
                LogUtils.Log("保存数据为空");
                return;
            }

            for (int index = msgList.Count - 1; index > -1; index--)
            {
                MessageObject msg = msgList[index];

                if (!(msg.type == kWCMessageType.Video || msg.type == kWCMessageType.Text || msg.type == kWCMessageType.Image || msg.type == kWCMessageType.File || msg.type == kWCMessageType.Voice))
                {
                    msgList.Remove(msg);
                    continue;
                }

                if (msg.isReadDel == 1)
                {
                    msgList.Remove(msg);
                    continue;
                }
            }

            if (UIUtils.IsNull(msgList))
            {
                HttpUtils.Instance.ShowTip("选中消息中 文字/图片/语音/视频/文件 消息才能被保存");
                return;
            }

            //保存
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/add")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("emoji", toCollectParams(msgList))
                .Build()
                .Execute((sccess, room) =>
                {
                    if (sccess)
                    {
                        HttpUtils.Instance.ShowTip("全部保存成功");
                        Messenger.Default.Send("1", MessageActions.UPDATE_COLLECT_LIST);
                    }
                });
        }


        // 多条保存字符串拼接
        private static string toCollectParams(List<MessageObject> msgs)
        {
            JArray jSONArray = new JArray();
            foreach (var datas in msgs)
            {
                JObject data = new JObject();
                if (!(datas.type == kWCMessageType.Video || datas.type == kWCMessageType.Text || datas.type == kWCMessageType.Image || datas.type == kWCMessageType.File || datas.type == kWCMessageType.Voice))
                {
                    continue;
                }

                if (datas.type == kWCMessageType.Gif)
                {
                    data.Add("url", datas.content);
                }
                else
                {
                    data.Add("msgId", datas.messageId);
                }
                data.Add("msg", datas.content);
                data.Add("type", GetType(datas.type));

                if (datas.isGroup == 1)
                {
                    data.Add("roomJid", datas.toUserId);
                }

                jSONArray.Add(data);
            }
            return jSONArray.ToString();
        }


        // 单条保存字符串拼接
        private static string toCollectParams(MessageObject datas)
        {

            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("msgId", datas.messageId);
            data.Add("msg", datas.content);
            data.Add("type", GetType(datas.type));

            if (datas.type == kWCMessageType.ResouresSocial)
            {
                jSONArray.Add(datas.objectId);
                return jSONArray.ToString();
            }
            if (datas.type == kWCMessageType.ResouresActive)
            {
                return datas.objectId;
            }
            else if (datas.type == kWCMessageType.ResouresNotify)
            {
                data["msg"] = datas.content;
                data["title"] = datas.fileName;
                data["shareURL"] = datas.objectId;
                data.Add("collectType", "5");
            }
            else if (datas.type == kWCMessageType.ResouresResoures)
            {
                return datas.objectId;
            }

            if (datas.isGroup == 1)
            {
                data.Add("roomJid", datas.toUserId);
            }
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        // 存表情字符串拼接
        private static string toSaveEmojiParams(MessageObject datas)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("url", datas.content);
            data.Add("msg", datas.content);
            data.Add("type", 6);
            // 增加roomJid会导致存表情到保存中去
            //if (datas.isGroup == 1)
            //{
            //    data.Add("roomJid", datas.toUserId);
            //}
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        // 存链接字符串拼接
        private static string toSaveLinkParams(string url)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("type", "5");
            data.Add("msg", url);
            data.Add("collectContent", url);
            data.Add("collectType", "-1");
            jSONArray.Add(data);
            return jSONArray.ToString();
        }


        // 将消息类型转换为保存类型
        private static string GetType(kWCMessageType type)
        {
            int value = 0;
            switch (type)
            {
                case kWCMessageType.Image:
                    value = 1;
                    break;
                case kWCMessageType.Video:
                    value = 2;
                    break;
                case kWCMessageType.File:
                    value = 3;
                    break;
                case kWCMessageType.Voice:
                    value = 4;
                    break;
                default:
                    value = 5;
                    break;
            }
            return value.ToString();
        }
        // 将保存类型转换为消息类型
        public static kWCMessageType GetMsgTypeBySaveType(String saveType)
        {

            switch (saveType)
            {
                case "1":
                    return kWCMessageType.Image;
                case "2":
                    return kWCMessageType.Video;
                case "3":
                    return kWCMessageType.File;
                case "4":
                    return kWCMessageType.Voice;
                case "5":
                    return kWCMessageType.Text;
                case "6":
                    return kWCMessageType.Gif;
                default:
                    return kWCMessageType.SDKLink;
            }

        }

        #endregion


        #region http保存表情
        /// <summary>
        /// 保存表情
        /// </summary>
        /// <param name="msg"></param>
        internal static void CollectExpression(MessageObject msg)
        {
            if (msg == null || UIUtils.IsNull(msg.messageId))
            {
                LogUtils.Log("保存表情为空");
                return;
            }

            CollectMessage(msg, true);
        }
        #endregion


        #region http保存链接
        /// <summary>
        /// 保存链接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="roomJid"></param>
        internal static void CollectLink(string url, string roomJid)
        {

            MessageObject message = new MessageObject();
            message.type = kWCMessageType.SDKLink;
            message.content = url;

            if (!UIUtils.IsNull(roomJid))
            {
                message.isGroup = 1;
                message.toUserId = roomJid;
            }
            message.messageId = Guid.NewGuid().ToString("N");

            CollectMessage(message);
        }

        #endregion


        #region 浏览器保存一个链接
        /// <summary>
        /// 保存链接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="roomJid"></param>
        internal static void CollectLink(string url)
        {
            string text = toSaveLinkParams(url);

            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "user/emoji/add") //保存
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("emoji", text)
                .NoErrorTip()
                 .Build().AddErrorListener((code, err) =>
                 {
                     if (code == 0)
                     {
                         HttpUtils.Instance.ShowTip("不能重复保存消息");
                     }
                     else
                     {
                         //code == 105002 端到端加密消息
                         HttpUtils.Instance.ShowTip(err);
                     }
                 })
                .Execute((sccess, room) =>
                {
                    if (sccess)
                    {
                        HttpUtils.Instance.ShowTip("保存成功");
                        // 更新保存页
                        Messenger.Default.Send("1", MessageActions.UPDATE_COLLECT_LIST);
                    }
                });
        }

        #endregion

        /// <summary>
        /// 单条服务器删除
        /// </summary>
        /// <param name="msg"></param>
        internal static void DelServerMessages(MessageObject msg, bool isLastMsg)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "tigase/deleteMsg"). //删除群组
                AddParams("access_token", Applicate.Access_Token).
                AddParams("type", msg.isGroup == 0 ? "1" : "2").    //1 单聊  2 群聊
                AddParams("delete", "1").   //1： 删除属于自己的消息记录 2：撤回 删除整条消息记录
                AddParams("messageId", msg.messageId).
                AddParams("roomJid", msg.toUserId).
                Build().ExecuteJson<object>((sccess, obj) =>   //返回值说明： text：加密后的内容
                {
                    //删除成功
                    if (sccess)
                    {
                        int result = msg.DeleteData();
                        HttpUtils.Instance.ShowTip("删除成功");
                        //通知最近聊天列表更新
                        if (isLastMsg)
                        {

                            // 更新最后一条消息内容
                            MessageObject local = msg.GetLastMessage();
                            var friend = msg.GetFriend();

                            string content = string.Empty;
                            double timesend = TimeUtils.CurrentTimeDouble();
                            if (!UIUtils.IsNull(local.messageId))
                            {
                                timesend = local.timeSend;
                                content = friend.ToLastContentTip(local.type, local.content, local.fromUserId, local.fromUserName, local.toUserName);
                                if (friend.IsGroup == 1)
                                {
                                    content = local.fromUserName + ":" + content;
                                }
                            }

                            friend.UpdateLastContent(content, timesend);
                            Messenger.Default.Send(friend, token: MessageActions.UPDATE_FRIEND_LAST_CONTENT);
                        }
                    }
                });
        }

        /// <summary>
        /// 多选服务器删除
        /// </summary>
        /// <param name="list_msgs"></param>
        internal static void DelServerMessages(List<MessageObject> list_msgs, bool isLastMsg)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "tigase/deleteMsg"). //删除群组
                AddParams("access_token", Applicate.Access_Token).
                AddParams("type", list_msgs[0].isGroup == 0 ? "1" : "2").    //1 单聊  2 群聊
                AddParams("delete", "1").   //1： 删除属于自己的消息记录 2：撤回 删除整条消息记录
                AddParams("messageId", UIUtils.AppendMessageIds(list_msgs)).
                AddParams("roomJid", list_msgs[0].toUserId).
                Build().ExecuteJson<object>((sccess, obj) =>   //返回值说明： text：加密后的内容
                {
                    //删除成功
                    if (sccess)
                    {
                        // 从数据库中移除
                        foreach (var item in list_msgs)
                        {
                            item.DeleteData();
                        }

                        //通知最近聊天列表更新
                        if (isLastMsg)
                        {
                            // 更新最后一条消息内容
                            MessageObject local = list_msgs[list_msgs.Count - 1].GetLastMessage();
                            var friend = list_msgs[list_msgs.Count - 1].GetFriend();

                            string content = string.Empty;
                            double timesend = TimeUtils.CurrentTimeDouble();
                            if (!UIUtils.IsNull(local.messageId))
                            {
                                timesend = local.timeSend;
                                content = friend.ToLastContentTip(local.type, local.content, local.fromUserId, local.fromUserName, local.toUserName);
                                if (friend.IsGroup == 1)
                                {
                                    content = local.fromUserName + ":" + content;
                                }
                            }

                            friend.UpdateLastContent(content, timesend);
                            Messenger.Default.Send(friend, token: MessageActions.UPDATE_FRIEND_LAST_CONTENT);
                        }

                        HttpUtils.Instance.ShowTip("全部删除成功");
                    }
                });
        }



        public static bool EnableForward(Friend friend)
        {
            if (friend == null || UIUtils.IsNull(friend.UserId))
            {
                HttpUtils.Instance.ShowTip("数据错误");
                return true;
            }

            if (friend.IsSecretGroup == 1)
            {
                if (UIUtils.IsNull(friend.ChatKeyGroup))
                {
                    // 没有密钥
                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                    return true;
                }

                if (friend.IsLostKeyGroup == 1)
                {
                    // 没有密钥
                    HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                    return true;
                }
            }

            if (friend.IsGroup == 1)
            {
                int role = new RoomMember() { roomId = friend.RoomId, userId = Applicate.MyAccount.userId }.GetRoleByUserId();

                if (role == 4)
                {
                    HttpUtils.Instance.ShowTip("隐身人不能发送消息");
                    return true;
                }

                if (role == 3)
                {
                    //是否全体禁言
                    string all = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, "0");
                    //管理员和群主除外
                    if (!"0".Equals(all))
                    {
                        // 全体禁言
                        HttpUtils.Instance.ShowTip("不能发送讲课到全体禁言群");
                        return true;
                    }

                    string single = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK" + Applicate.MyAccount.userId, "0");
                    //是否单个禁言
                    if (!"0".Equals(single))
                    {
                        HttpUtils.Instance.ShowTip("您已被禁止在此群发言");
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 指示是否可以转发
        /// </summary>
        /// <param name="friend"></param>
        /// <returns>返回值为0则可以转发，<0则不允许转发
        /// <para>-1=friend null;-2=没有群密钥;-3=隐身人;-4=禁言</para>
        /// </returns>
        public static int EnableForward_NotTip(Friend friend)
        {
            if (friend == null || UIUtils.IsNull(friend.UserId))
            {
                //HttpUtils.Instance.ShowTip("数据错误");
                return -1;
            }

            if (friend.IsSecretGroup == 1)
            {
                if (UIUtils.IsNull(friend.ChatKeyGroup))
                {
                    // 没有密钥
                    //HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                    return -2;
                }

                if (friend.IsLostKeyGroup == 1)
                {
                    // 没有密钥
                    //HttpUtils.Instance.ShowTip("不能转发消息到密钥丢失群");
                    return -2;
                }
            }

            if (friend.IsGroup == 1)
            {
                int role = new RoomMember() { roomId = friend.RoomId, userId = Applicate.MyAccount.userId }.GetRoleByUserId();

                if (role == 4)
                {
                    //HttpUtils.Instance.ShowTip("隐身人不能发送消息");
                    return -3;
                }

                if (role == 3)
                {
                    //是否全体禁言
                    string all = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, "0");
                    //管理员和群主除外
                    if (!"0".Equals(all))
                    {
                        // 全体禁言
                        //HttpUtils.Instance.ShowTip("不能发送讲课到全体禁言群");
                        return -4;
                    }

                    string single = LocalDataUtils.GetStringData(friend.UserId + "BANNED_TALK" + Applicate.MyAccount.userId, "0");
                    //是否单个禁言
                    if (!"0".Equals(single))
                    {
                        //HttpUtils.Instance.ShowTip("您已被禁止在此群发言");
                        return -4;
                    }
                }
            }

            return 0;
        }



        #region

        /// <summary>
        /// 刷新移动至菜单
        /// </summary>
        public static void RefreshMoveSubMenu(ToolStripMenuItem baseItem, List<HttpFolderData> folderList)
        {
            baseItem.DropDownItems.Clear();

            if (!UIUtils.IsNull(folderList))
            {
                foreach (var item in folderList)
                {
                    var sub = CreateSubMenuItem(item);
                    if (sub != null)
                    {
                        baseItem.DropDownItems.Add(sub);

                        if (item.SubCount > 0)
                        {
                            foreach (var item1 in item.groupUserAlbumList)
                            {
                                var sub1 = CreateSubMenuItem(item1);
                                if (sub1 != null)
                                {
                                    sub.DropDownItems.Add(sub1);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static ToolStripMenuItem CreateSubMenuItem(HttpFolderData data)
        {
            // 资源可以往空文件夹中移动
            if (UIUtils.IsNull(data.folderId))
            {
                return null;
            }

            ToolStripMenuItem mnuPrintPageSet = new ToolStripMenuItem(data.folderName);
            mnuPrintPageSet.Name = data.folderId;
            mnuPrintPageSet.Text = UIUtils.LimitTextLength(data.folderName, 20, true);
            mnuPrintPageSet.Click += menuItem_MoveAs_Click;
            return mnuPrintPageSet;
        }


        // 移动至
        private static void menuItem_MoveAs_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            collect11?.Invoke(item.Name);
        }



        /// <summary>
        ///       
        /// </summary>
        /// <param name="type">类型1图片，2视频，3文件，4音乐，5其他</param>

        private static Action<string> collect11;
        public static void HttpCollectionList(string type, ToolStripMenuItem skinContext, Action<string> name)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/collectionFile/v2")
                .AddParams("type", type)
                .AddParams("fileType", "0")
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "1000")
                 .Build().ExecuteJson<List<HttpFolderData>>((sccess, dataList) =>
                 {
                     collect11 = name;
                     if (sccess && dataList != null)
                     {
                         RefreshMoveSubMenu(skinContext, dataList);

                     }
                 });
        }






        #endregion


    }
}

