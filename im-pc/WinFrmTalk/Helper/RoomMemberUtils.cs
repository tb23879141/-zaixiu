using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFrmTalk.Model;

namespace WinFrmTalk.Helper
{
    public class RoomMemberUtils
    {
        private Dictionary<string, string> _users;
        /// <summary>
        /// 记录调用过key-value表的user
        /// </summary>
        private Dictionary<string, string> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new Dictionary<string, string>();
                    return _users;
                }
                return _users;
            }
            set { _users = value; }
        }

        public string GetSenderNameByMsg(MessageObject msg, string roomId)
        {
            string userId = msg.fromUserId;
            if (string.IsNullOrEmpty(userId))
                return msg.fromUserName;

            if (Users.Keys.Contains(userId))
            {
                return Users[userId];
            }
            else
            {
                string senderName = GetRoomUserName(msg, roomId);
                Users.Add(userId, senderName);
                return senderName;
            }
        }

        /// <summary>
        /// 获取群成员的名称（群主备注 > 群昵称 > 用户昵称）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        private string GetRoomUserName(MessageObject msg, string roomId)
        {
            var rm = new RoomMember()
            {
                userId = msg.fromUserId,
                roomId = roomId
            }.GetRoomMember();

            if(rm == null || string.IsNullOrEmpty(rm.userId))
            {
                return msg.fromUserName;
            }

            if (!string.IsNullOrEmpty(rm.remarkName))
            {
                return rm.remarkName;
            }
            if (!string.IsNullOrEmpty(rm.cardName))
            {
                return rm.cardName;
            }

            //获取昵称或者好友备注
            //string userName = "";
            //if (Applicate.FdNames.ContainsKey(msg.fromUserId))
            //    userName = Applicate.FdNames[msg.fromUserId];
            //userName = string.IsNullOrEmpty(userName) ? rm.nickName : userName;
            //return userName;

            return rm.nickName;
        }

        /// <summary>
        /// 修改群昵称调用
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="roomId"></param>
        internal void UpdateRoomMemberName_Member(string name, string userId, string roomId)
        {
            string senderName = "";

            var rm = new RoomMember()
            {
                userId = userId,
                roomId = roomId
            }.GetRoomMember();

            if (rm == null || string.IsNullOrEmpty(rm.userId))
            {
                senderName = name;
            }
            else if (!string.IsNullOrEmpty(rm.remarkName))
            {
                senderName = rm.remarkName;
            }
            else
            {
                senderName = name;
            }

            //string userId = msg.fromUserId;
            //string senderName = GetRoomUserName(msg, roomId);
            if (Users.Keys.Contains(userId))
            {
                Users[userId] = senderName;
            }
            else
            {
                Users.Add(userId, senderName);
            }
        }

        /// <summary>
        /// 修改群主备注调用
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="roomId"></param>
        internal void UpdateRoomMemberName_Remark(string userId, string name)
        {
            if (Users.Keys.Contains(userId))
            {
                Users[userId] = name;
            }
            else
            {
                Users.Add(userId, name);
            }
        }
    }
}
