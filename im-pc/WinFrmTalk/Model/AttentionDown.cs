using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrmTalk.Model
{

    public class AttentionDownList
    {
        public List<AttentionDown> data { get; set; }

        public List<Friend> AttentionToFriends()
        {
            if (UIUtils.IsNull(data))
            {
                return null;
            }

            List<Friend> friends = new List<Friend>();

            foreach (var item in data)
            {
                friends.Add(item.ToFriend());
            }

            return friends;
        }
    }

    public class AttentionDown
    {
        /// <summary>
        /// 
        /// </summary>
        //public long chatRecordTimeOut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dhMsgPublicKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int encryptType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fromAddType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isBeenBlack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isOpenSnapchat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lastTalkTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int modifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int msgNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int offlineNoPushMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int openTopChatTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rsaMsgPublicKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 客服公众号
        /// </summary>
        public string toNickname { get; set; }

        /// <summary>
        /// 客服公众号
        /// </summary>
        public string remarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string toUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int toUserType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }


        internal Friend ToFriend()
        {
            Friend friend = new Friend()
            {
                UserId = toUserId,
                MsgNum = msgNum,
                Status = status,
                NickName = toNickname,
                CreateTime = createTime,
                RemarkName = remarkName,
                IsOpenReadDel = isOpenSnapchat,
                TopTime = openTopChatTime,
                Nodisturb = offlineNoPushMsg,
                RsaPublicKey = rsaMsgPublicKey,
                DhPublicKey = dhMsgPublicKey,
                IsEncrypt = encryptType,
            };


            if (friend.TopTime == 1)
            {
                friend.TopTime = TimeUtils.CurrentIntTime();
            }

            // 公众号 #8134
            if (toUserType == 2)
            {
                friend.UserType = FriendType.PUBLICIZE_TYPE;
            }

            if (Friend.ID_SYSTEM.Equals(friend.UserId))
            {
                friend.UserType = FriendType.PUBLICIZE_TYPE;
            }

            // 我被对方拉黑 isBeenBlack == 1
            if (1 == isBeenBlack)
            {
                // 修改禅道 #8125
                friend.Status = Friend.STATUS_19;
            }

            // 禅道#8706
            if (Friend.ID_SYSTEM.Equals(friend.UserId))
            {
                friend.Content = "欢迎使用本软件";
                friend.LastMsgTime = TimeUtils.CurrentIntTime();
            }

            if ("10005".Equals(friend.UserId))
            {
                friend.UserType = FriendType.NEWFRIEND_TYPE;
            }

            friend.fristAscII = friend.GetFristASCIICode();

            return friend;
        }
    }
}
