using System;
using System.Collections.Generic;
using WinFrmTalk.Model;

namespace WinFrmTalk.Helper
{
    // 消息漫游类
    internal class DownMsgRecord
    {

        private const int PAGER_SIZE = 20;

        private const string MSG_ROMING_PAGE_SIZE = "60";

        private IShowMsgPanel mPanel;

        public DownMsgRecord(IShowMsgPanel panel)
        {
            mPanel = panel;
        }


        public void LoadMsgDatas(Friend friend, int index, double fristTime, bool isMsgLaod = false)
        {
            List<MessageObject> message = null;

            // 这里是搜索
            if (friend.IsSendRecipt == 10)
            {
                message = new MessageObject() { FromId = friend.UserId }.SearchMessageRecord(friend.LastMsgTime);

                if (!UIUtils.IsNull(message))
                {
                    //var msg = new MessageObject();
                    //msg.type = kWCMessageType.labMoreMsg;
                    //message.Insert(0, msg);

                    // 翻转数组
                    //   message.Reverse();

                    if (mPanel != null)
                    { // 加载本地数据
                        mPanel.OnDownRecord(message);
                    }

                    return;
                }
            }

            // 加载本地数据
            if (friend.IsGroup == 1)
            {
                friend = friend.GetByUserId();
                if (index == 1 && fristTime == 0 && friend.IsClearMsg == 1)
                {
                    var msg = new MessageObject();
                    msg.type = kWCMessageType.labMoreMsg;
                    message = new List<MessageObject>();
                    message.Add(msg);
                    mPanel.OnDownRecord(message);
                    Console.WriteLine("LoadMsgDatas");
                    return;
                }


                int count = PAGER_SIZE;
                if (index == 1 && friend.MsgNum != 0)
                {
                    // 第一次点击进来,追踪数量
                    count = Math.Max(friend.MsgNum, count);
                }
                // 加载本地数据 - 群聊
                message = LoadLocalGroupMsg(friend, fristTime, index, count);

                // 刚刚清空过聊天记录，有收到到新消息 修改禅道#9778
                if (friend.IsClearMsg == 2)
                {
                    if (UIUtils.IsNull(message))
                    {
                        message = new List<MessageObject>();
                    }

                    var msg = new MessageObject();
                    msg.type = kWCMessageType.labMoreMsg;
                    message.Add(msg);
                    //var kk = friend.UpdateClearMessageState(0);
                }
            }
            else
            {
                // 加载本地数据 - 单聊
                friend = friend.GetByUserId();
                if (friend.DownloadRoamStartTime != 0)
                {
                    double start = (friend.DownloadRoamStartTime / 1000) + 1;
                    message = new MessageObject() { FromId = friend.UserId }.QueryMessageRecordAfter(index, start, PAGER_SIZE);
                    if (!UIUtils.IsNull(message))
                    {
                        message.Add(new MessageObject() { type = kWCMessageType.labMoreMsg });
                    }
                }
                else
                {
                    if (fristTime == 0)
                    {
                        message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(index, PAGER_SIZE);
                    }
                    else
                    {
                        // 加载本地数据
                        message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(fristTime, PAGER_SIZE);
                    }
                }
            }


            if (UIUtils.IsNull(message) || isMsgLaod)
            {
                // 触发漫游
                DownRecord(friend, fristTime, index, PAGER_SIZE);

                return;
            }

            if (message.Count < PAGER_SIZE)
            {
                // 显示加载更多 的气泡
                //message.Add();
            }

            // 翻转数组
            message.Reverse();

            if (mPanel != null)
            { // 加载本地数据
                DecryptMessage(message, friend);
                mPanel.OnDownRecord(message);
            }
        }

        private void DownRecord(Friend friend, double fristTime, int index, int count)
        {
            if (friend.IsGroup == 1)
            {
                DownGroupRecord(friend, fristTime, index, count);
            }
            else
            {
                DownSingleRecord(friend, fristTime, index);
            }
        }


        #region 单聊
        public void DownSingleRecord(Friend friend, double fristTime, int index)
        {
            if (friend.DownloadRoamEndTime <= friend.DownloadRoamStartTime)
            {
                mPanel.OnDownRecord(null);
                return;
            }

            string starttime = ToFromAtTime(Math.Floor(friend.DownloadRoamStartTime));
            string endtime = ToFromAtTime(Math.Ceiling(friend.DownloadRoamEndTime));

            if (mPanel != null)
            { // 加载本地数据
                mPanel.OnShowLoading();
            }

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "tigase/shiku_msgs") //获取单聊漫游
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("receiver", friend.UserId)
                .AddParams("startTime", starttime)    // 2010-01-01 00:00:00  服务端返回的数据为倒序返回
                .AddParams("endTime", endtime)
                .AddParams("pageSize", MSG_ROMING_PAGE_SIZE)
                .Build().ExecuteList<MessageRecordList>((success, result) =>
                {
                    if (success && !UIUtils.IsNull(result.data))
                    {
                        string key = ECDH.ComputeSharedSecret(Applicate.MyAccount.dhPrivateKey, friend.DhPublicKey);

                        double min = friend.DownloadRoamEndTime / 1000;
                        foreach (var item in result.data)
                        {
                            MessageObject message = item.ToMessageObject();

                            if (message == null)
                            {
                                continue;
                            }

                            if (message.timeSend < min)
                            {
                                min = message.timeSend;
                            }

                            if (!message.IsVisibleMsg())
                            {
                                continue;
                            }

                            if (message.deleteTime > 0 && message.deleteTime < TimeUtils.CurrentTimeDouble())
                            {
                                continue;
                            }

                            //解密
                            DecryptRecordMessage(message, key);

                            message.InsertData();
                        }

                        if (result.data.Count < 60)
                        {
                            friend.UpdateDownTime(0, 0);
                        }
                        else
                        {
                            friend.UpdateDownTime(Convert.ToDouble(starttime), Convert.ToDouble(min * 1000));
                        }
                    }
                    else
                    {
                        // 不再去漫游
                        friend.UpdateDownTime(0, 0);
                    }

                    if (mPanel != null)
                    {
                        if (fristTime == 0)
                        {
                            // 加载本地数据
                            List<MessageObject> message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(index, PAGER_SIZE);
                            // 翻转数组
                            if (!UIUtils.IsNull(message))
                            {
                                message.Reverse();
                            }

                            DecryptMessage(message, friend);
                            mPanel.OnDownRecord(message);
                        }
                        else
                        {
                            // 加载本地数据
                            List<MessageObject> message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(fristTime, PAGER_SIZE);
                            // 翻转数组
                            if (!UIUtils.IsNull(message))
                            {
                                message.Reverse();
                            }

                            DecryptMessage(message, friend);
                            mPanel.OnDownRecord(message);
                        }
                    }
                });
        }

        private string ToFromAtTime(double data)
        {
            string strdata = Convert.ToDecimal(data).ToString();

            if (strdata.Length > 13)
            {
                return strdata.Substring(0, 13);
            }

            return strdata;
        }
        #endregion

        #region 群聊
        private void DownGroupRecord(Friend friend, double fristTime, int index, int showcount)
        {
            string starttime = "1262275200000";
            string endtime;
            MessageObject localfrist = new MessageObject() { isGroup = 1, FromId = friend.UserId }.GetFristMessage();
            if (localfrist != null)
            {
                endtime = Math.Ceiling(localfrist.timeSend * 1000).ToString();
            }
            else
            {
                endtime = TimeUtils.CurrentTimeMillis().ToString();
                MsgRoamTask delTask = new MsgRoamTask() { userId = friend.UserId, ownerId = Applicate.MyAccount.userId };
                delTask.DeleteTaskAll();
            }


            // 这里要根据群聊任务机制去加载漫游
            MsgRoamTask task = new MsgRoamTask() { userId = friend.UserId, ownerId = Applicate.MyAccount.userId }.QueryLastTask();
            if (task != null)
            {
                starttime = Math.Floor(task.startTime * 1000).ToString();
                endtime = Math.Ceiling(task.endTime * 1000).ToString();
            }

            //int requestIndex = 0;// LocalDataUtils.GetIntData(friend.userId + starttime, 0);
            //if (requestIndex == -1)
            //{
            //    mPanel.OnDownRecord(null);
            //    return;
            //}

            mPanel.OnShowLoading();
            //http get请求获得数据
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "tigase/shiku_muc_msgs") //获取群漫游
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("roomId", friend.UserId)
            .AddParams("startTime", starttime)    // 2010-01-01 00:00:00  服务端返回的数据为倒序返回
            .AddParams("endTime", endtime)
            .AddParams("pageSize", MSG_ROMING_PAGE_SIZE)
            //.AddParams("pageIndex", requestIndex.ToString())
            .Build().ExecuteList<MessageRecordList>((success, result) =>
            {
                if (success)
                {

                    friend.UpdateClearMessageState(0);

                    // 算出群组对称密钥G
                    string key = SecureChatUtil.DecryptChatkey(friend.UserId, friend.ChatKeyGroup, Applicate.API_KEY);

                    double stime = 0;

                    foreach (var item in result.data)
                    {
                        MessageObject message = item.ToMessageObject(1);

                        if (message == null)
                        {
                            continue;
                        }

                        if (!message.IsVisibleMsg())
                        {
                            continue;
                        }

                        if (message.deleteTime > 0 && message.deleteTime < TimeUtils.CurrentTimeDouble())
                        {
                            continue;
                        }

                        //消息解密
                        DecryptRecordMessage(message, key);

                        stime = message.timeSend;
                        message.InsertData();
                    }

                    if (task != null)
                    {
                        task.DeleteTaskAll();
                        new MessageObject() { isGroup = 1, FromId = friend.UserId }.DeleteMessageLow(stime);

                        //if (MSG_ROMING_PAGE_SIZE.Equals(result.data.Count.ToString()))
                        //{
                        //    // 正常返回了指定条数的msg， 说明漫游任务还没有结束 
                        //    double lasttime = result.data[result.data.Count - 1].timeSend;
                        //    task.UpdateTaskEndTime(lasttime);
                        //}
                        //else
                        //{
                        //    task.DeleteTask();
                        //}
                    }
                }

                if (mPanel != null)
                { // 加载本地数据
                    List<MessageObject> message = LoadLocalGroupMsg(friend, fristTime, index, showcount);
                    // 翻转数组
                    if (!UIUtils.IsNull(message))
                    {
                        message.Reverse();
                        DecryptMessage(message, friend);
                    }

                    mPanel.OnDownRecord(message);
                }
            });
        }


        private List<MessageObject> LoadLocalGroupMsg(Friend friend, double fristTime, int index, int count)
        {

            double endtime = 0;

            if (fristTime == 0) // 第一次加载， 本地没有数据
            {
                // 群聊漫游分两种情况, 本地为空的情况， 直接拉全部的漫游
                MessageObject local = new MessageObject() { isGroup = 1, FromId = friend.UserId }.GetLastMessage();
                if (UIUtils.IsNull(local.messageId))
                {
                    return null;
                }
                else
                {
                    endtime = local.timeSend + 1;
                }
            }
            else
            {
                // 取最上面一条消息的timesend
                endtime = fristTime;
            }


            MsgRoamTask task = new MsgRoamTask() { userId = friend.UserId, ownerId = Applicate.MyAccount.userId }.QueryLastTask();
            if (task != null)
            {
                double starttime = task.endTime;
                List<MessageObject> message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(starttime, endtime, count);

                if (!UIUtils.IsNull(message))
                {
                    message.Add(new MessageObject() { type = kWCMessageType.labMoreMsg });
                }

                return message;
            }
            else
            {
                List<MessageObject> message = new MessageObject() { FromId = friend.UserId }.LoadRecordMsg(endtime, count);
                if (!UIUtils.IsNull(message))
                {
                    if (message[message.Count - 1].type != kWCMessageType.kWCMessageTypeNone)
                    {
                        message.Add(new MessageObject() { type = kWCMessageType.labMoreMsg });
                    }
                }
                return message;
            }
        }

        #endregion



        /// <summary>
        ///  漫游消息解密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        private void DecryptRecordMessage(MessageObject message, string key)
        {
            if (message.isEncrypt == 1)
            {
                SkSSLUtils.DecryptMessage_3DES(message);
            }
            else if (message.isEncrypt == 2)
            {
                SkSSLUtils.DecryptMessage_AES(message);
            }
            else if (message.isEncrypt == 3)
            {
                SkSSLUtils.DecryptMessage_DH1(message, key);
            }
        }


        // 消息解密
        private void DecryptMessage(List<MessageObject> messages, Friend friend)
        {
            if (UIUtils.IsNull(messages))
            {
                return;
            }

            bool isGroup = friend.IsGroup == 1;
            var f = friend.GetByUserId();
            string key = string.Empty;
            if (isGroup)
            {
                key = SkSSLUtils.GetGroupChatkey(friend.UserId, friend.ChatKeyGroup);
            }
            else
            {
                key = SkSSLUtils.GetSingleChatkey(friend.DhPublicKey);
            }

            foreach (var msg in messages)
            {
                DecryptRecordMessage(msg, key);
            }
        }
    }

    internal interface IShowMsgPanel
    {
        void OnShowLoading();
        void OnDownRecord(List<MessageObject> data);

    }

}


