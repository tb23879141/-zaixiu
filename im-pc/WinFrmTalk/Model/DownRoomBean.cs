using System;
using System.Collections.Generic;

namespace WinFrmTalk.Model
{
    internal class DownRoomBean
    {
        public DownRoomBean()
        {
            data = new List<DownRoom>();
        }

        public List<DownRoom> data { get; set; }

        public List<Friend> ToRoomFriends()
        {
            if (UIUtils.IsNull(data))
            {
                return null;
            }

            List<Friend> rooms = new List<Friend>();

            foreach (DownRoom room in data)
            {
                Friend friend = new Friend();
                friend.UserId = room.jid;
                friend.ShowRead = room.showRead;
                friend.AllowUploadFile = room.allowUploadFile;//允许普通群成员上传文件
                friend.AllowSpeakCourse = room.allowSpeakCourse;//允许普通群成员发起讲课
                friend.AllowConference = room.allowSpeakCourse;
                friend.AllowConference = room.allowConference;//允许普通群成员召开会议
                friend.AllowInviteFriend = room.allowInviteFriend;//允许普通群成员邀请好友
                friend.ShowMember = room.showMember;
                friend.AllowSendCard = room.allowSendCard;//允许普通群成员私聊
                //  开启了全体禁言，本地朋友表丢失此字段 room.talkTime > 0
                friend.CreateTime = (int)room.createTime;
                friend.NickName = room.name;
                friend.RoomId = room.id;
                friend.Status = 2;
                friend.IsGroup = 1;
                friend.Description = room.desc;
                friend.IsNeedVerify = room.isNeedVerify;
                friend.IsSecretGroup = room.isSecretGroup;
                friend.IsEncrypt = room.encryptType;
                //  0普通群；2官方群；3商城群；4临时群；5个人粉丝群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
                friend.GroupType = room.type;
                if (room.member != null)
                {
                    friend.Nodisturb = room.member.offlineNoPushMsg;
                    friend.TopTime = room.member.openTopChatTime;
                    friend.Role = room.member.role.ToString();

                    if (room.isSecretGroup == 1 && Applicate.ENABLE_ASY_ENCRYPT)
                    {
                        // 解析chatkey
                        string enchatkey = room.member.chatKeyGroup;
                        if (!UIUtils.IsNull(enchatkey))
                        {
                            string key = RSA.DecryptFromBase64Pk1(enchatkey, Applicate.MyAccount.rsaPrivateKey);
                            if (!UIUtils.IsNull(key))
                            {
                                // 加密成 chatkeygroup
                                string chatKey = SecureChatUtil.EncryptChatKey(room.jid, key, Applicate.API_KEY);
                                friend.ChatKeyGroup = chatKey;
                            }
                            else
                            {
                                friend.ChatKeyGroup = "";
                            }
                        }
                    }

                }

                if (friend.IsSecretGroup == 1 && !Applicate.ENABLE_ASY_ENCRYPT)
                {
                    continue;
                }

                rooms.Add(friend);
            }

            return rooms;
        }
    }

    public class Member
    {
        /// <summary>
        /// 
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long modifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int offlineNoPushMsg { get; set; }

        public int openTopChatTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int role { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sub { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long talkTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }


        public string chatKeyGroup { get; set; }

    }


    public class DownRoom
    {
        /// <summary>
        /// 
        /// </summary>
        public int allowConference { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int allowHostUpdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int allowInviteFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int allowSendCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int allowSpeakCourse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int allowUploadFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int areaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string call { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double chatRecordTimeOut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int countryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double createTime { get; set; }
        public long endTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isAttritionNotice { get; set; }


        public int isSecretGroup { get; set; }

        public int encryptType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int isNeedVerify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double latitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double longitude { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public int maxUserSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Member member { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int modifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int provinceId { get; set; }
        /// <summary>
        /// 是否可以围观
        /// </summary>
        public int isLook { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int showMember { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int showRead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long talkTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string videoMeetingNo { get; set; }

        /// <summary>
        /// 指向的官群ID
        /// </summary>
        public string officialGroupId { get; set; }

        public long watchTime { get; set; }

        public int movingState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 0==内部群 1==外部群
        /// </summary>
        public int inside { get; set; }


        public Friend ToRoom(bool mem = true)
        {
            Friend friend = new Friend();
            friend.UserId = this.jid;
            friend.ShowRead = this.showRead;
            friend.AllowUploadFile = this.allowUploadFile;//允许普通群成员上传文件
            friend.AllowSpeakCourse = this.allowSpeakCourse;//允许普通群成员发起讲课
            friend.AllowConference = this.allowSpeakCourse;
            friend.AllowConference = this.allowConference;//允许普通群成员召开会议
            friend.AllowInviteFriend = this.allowInviteFriend;//允许普通群成员邀请好友
            friend.ShowMember = this.showMember;
            friend.AllowSendCard = this.allowSendCard;//允许普通群成员私聊

            // this.talkTime > 0 开启了全体禁言，本地朋友表丢失此字段
            friend.CreateTime = (int)this.createTime;
            friend.NickName = this.name;
            friend.RoomId = id;
            friend.Status = 2;
            friend.IsGroup = 1;
            friend.Description = this.desc;
            friend.IsNeedVerify = this.isNeedVerify;
            //  0普通群；2官方群；3商城群；4临时群；5个人粉丝群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
            friend.GroupType = this.type;
            friend.deleteTime = this.endTime;
            friend.movingState = this.movingState;
            friend.OfficialGroupId = this.officialGroupId;
            friend.inside = this.inside;

            friend.Role = this.member == null ? "-1" : "0";
            if (mem)
            {
                if (member != null)
                {
                    if (member != null && !UIUtils.IsNull(member.chatKeyGroup))
                    {
                        string key = RSA.DecryptFromBase64Pk1(member.chatKeyGroup, Applicate.MyAccount.rsaPrivateKey);
                        // 加密成 chatkeygroup
                        if (!UIUtils.IsNull(key))
                        {
                            string chatKey = SecureChatUtil.EncryptChatKey(friend.UserId, key, Applicate.API_KEY);
                            friend.ChatKeyGroup = chatKey;
                            friend.IsEncrypt = 3;
                        }
                    }

                    friend.Nodisturb = member.offlineNoPushMsg;
                    friend.TopTime = member.openTopChatTime;

                    friend.Role = Convert.ToString(this.member.role);
                }
            }
            return friend;

        }

        internal RoomMember ToMeMember(string roomId)
        {
            if (member == null || string.IsNullOrEmpty(member.userId))
            {
                return null;
            }

            RoomMember roomMembers = new RoomMember();
            roomMembers.roomId = roomId;
            roomMembers.userId = member.userId;
            roomMembers.nickName = member.nickname;
            roomMembers.role = member.role;
            roomMembers.createTime = Convert.ToInt32(member.createTime);
            return roomMembers;
        }
    }



}
