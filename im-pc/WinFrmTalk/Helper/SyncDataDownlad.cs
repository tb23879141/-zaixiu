using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;

namespace WinFrmTalk
{
    /// <summary>
    /// 登录后群组&好友数据下载
    /// </summary>
    public class SyncDataDownlad
    {

        private int friendDownCompe; // 下载好友
        private int roomDownCompe; // 下载群组
        private int lableDownCompe; // 下载标签

        private bool isDownCompt;
        private Action<bool> mComptListener;

        /// <summary>
        /// 设置下载监听
        /// </summary>
        /// <param name="comptListener">数据下载完成的回调</param>
        public void StartDown(Action<bool> comptListener, string phone)
        {
            mComptListener = comptListener;

            DownFriend();

            int downroom = LocalDataUtils.GetIntData("just_forgetpwd" + phone);

            if (!new Friend().IsExistFriend(true) || downroom == 1)
            {
                // 本地没有群组
                DownRoom();
            }
            else
            {
                roomDownCompe = 1;
                Compt();
            }

            DownLable();
        }

        /// <summary>
        /// 下载好友列表
        /// </summary>
        public void DownFriend()
        {
            LogUtils.Log("down friends ing........");

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friends/attention/list")
                  .AddParams("access_token", Applicate.Access_Token)
                  .AddParams("pageIndex", "0")
                  .AddParams("pageSize", "1000")
                  .AddParams("userId", Applicate.MyAccount.userId)
                  .Build().ExecuteList<AttentionDownList>((sccess, list) =>
                  {
                      if (sccess)
                      {
                          Task.Factory.StartNew(() =>
                          {
                              lock (lock_insert)
                              {
                                  UpdateFriendData(list);
                              }
                              Compt();
                          });
                      }
                      else
                      {
                          friendDownCompe = -1;
                          LogUtils.Log("DownFriend  Error");
                          Compt();
                      }
                  });
        }


        /// <summary>
        ///下载群列表
        /// </summary>
        public void DownRoom()
        {
            LogUtils.Log("down room ing........");

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/list/his")
                  .AddParams("access_token", Applicate.Access_Token)
                  .AddParams("pageIndex", "0")
                  .AddParams("pageSize", "1000")
                  .AddParams("type", "0")
                   .AddParams("userId", Applicate.MyAccount.userId)
                   .NoErrorTip()
                  .Build().ExecuteList<DownRoomBean>((sccess, list) =>
                  {
                      if (sccess)
                      {
                          Task.Factory.StartNew(() =>
                          {
                              lock (lock_insert)
                              {
                                  UpdateRoomData(list);
                              }
                          });
                      }
                      else
                      {
                          roomDownCompe = -1;
                          LogUtils.Log("Down room  Error");
                          Compt();
                      }
                  });
        }


        /// <summary>
        /// 下载好友标签
        /// </summary>
        public void DownLable()
        {
            FriendLabelDao.Instance.UpdateLableByHttp(() =>
            {

                LogUtils.Log("down lables compte........");
                lableDownCompe = 1;
                Compt();

            });
        }


        /// <summary>
        /// 获取我的所有好友
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Friend> FindAllFriend()
        {
            List<Friend> data = new Friend().GetAllListByGroup(0);
            Dictionary<string, Friend> list = new Dictionary<string, Friend>();
            for (int i = 0; i < data.Count; i++)
            {
                var friend = data[i];
                list.Add(friend.UserId, friend);
            }
            return list;
        }

        /// <summary>
        /// 获取我的所有群组
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Friend> FindAllGroup()
        {
            List<Friend> data = new Friend().GetAllListByGroup(1);
            Dictionary<string, Friend> list = new Dictionary<string, Friend>();
            for (int i = 0; i < data.Count; i++)
            {
                var friend = data[i];
                list.Add(friend.UserId, friend);
            }
            return list;
        }

        /// <summary>
        /// 创建默认的好友
        /// </summary>
        private void CreateDeviceFriend()
        {
            Friend friend = new Friend();
            friend.UserId = Friend.ID_NEW_FRIEND;
            friend.NickName = "新的好友";
            friend.UserType = FriendType.NEWFRIEND_TYPE;
            friend.Status = 2;
            friend.fristAscII = friend.GetFristASCIICode();
            friend.InsertNonFriend();

            friend = new Friend();
            friend.UserId = "9999";
            friend.NickName = "黑名单";
            friend.Status = 2;
            friend.UserType = FriendType.NEWFRIEND_TYPE;
            friend.fristAscII = friend.GetFristASCIICode();
            friend.InsertNonFriend();

            friend = new Friend();
            friend.UserId = "android";
            friend.NickName = "我的Android";
            friend.Status = 2;
            friend.UserType = FriendType.DEVICE_TYPE;
            friend.fristAscII = friend.GetFristASCIICode();
            friend.InsertNonFriend();

            friend = new Friend();
            friend.UserId = "ios";
            friend.NickName = "我的iPhone";
            friend.Status = 2;
            friend.UserType = FriendType.DEVICE_TYPE;
            friend.fristAscII = friend.GetFristASCIICode();
            friend.InsertNonFriend();

            //friend = new Friend();
            //friend.UserId = "web";
            //friend.NickName = "我的Web网页";
            //friend.Status = 2;
            //friend.UserType = FriendType.DEVICE_TYPE;
            //friend.fristAscII = friend.GetFristASCIICode();
            //friend.InsertNonFriend();

            //friend = new Friend();
            //friend.UserId = "mac";
            //friend.NickName = "我的Mac电脑";
            //friend.Status = 2;
            //friend.UserType = FriendType.DEVICE_TYPE;
            //friend.fristAscII = friend.GetFristASCIICode();
            //friend.InsertNonFriend();


            friend = new Friend();
            friend.UserId = Friend.ID_PUBLIC_LIST;
            friend.NickName = "公众号";
            friend.Status = 2;
            friend.UserType = FriendType.NEWFRIEND_TYPE;
            friend.fristAscII = friend.GetFristASCIICode();
            friend.InsertNonFriend();
        }

        /// <summary>
        /// 保存当前登录账号在某个群里面的身份
        /// </summary>
        /// <param name="member"></param>
        /// <param name="roomJid"></param>
        /// <param name="roomId"></param>
        private void SaveRoomMember(Model.Member member, string roomId)
        {
            if (member == null || string.IsNullOrEmpty(member.userId))
            {
                return;
            }

            RoomMember roomMembers = new RoomMember();
            roomMembers.roomId = roomId;
            roomMembers.userId = member.userId;
            roomMembers.nickName = member.nickname;
            roomMembers.role = member.role;
            roomMembers.createTime = Convert.ToInt32(member.createTime);
            roomMembers.InsertOrUpdate();
        }

        /// <summary>
        /// 调用了的下载对象进度
        /// </summary>
        private void Compt()
        {
            ///进度改变时
            if (friendDownCompe == 0 || roomDownCompe == 0 || lableDownCompe == 0)
            {
                LogUtils.Log("正在下载中.....");
            }
            else
            {
                if (!isDownCompt)
                {
                    isDownCompt = true;
                    //通知登录界面改变
                    //Console.WriteLine("下载成功。" + friendDownCompe + " ------ " + friendDownCompe);
                    //mComptListener?.Invoke(true);
                    HttpUtils.Instance.Invoke(mComptListener, true);
                }
            }
        }

        private static readonly object lock_insert = new object();

        private void UpdateFriendData(AttentionDownList list)
        {
            LogUtils.Log("down friends tolist........" + list.data.Count);

            List<Friend> friends = list.AttentionToFriends();

            // 遍历服务器所有的好友
            //List<Friend> friends = new Friend().AttentionToFriends(list);

            Friend temp = new Friend();
            // 是否存在好友
            if (temp.IsExistFriend(false))
            {
                // 删除全部旧的好友
                temp.RemoveAllFriend();
            }


            LocalDataUtils.SetStringData(Applicate.QUIT_TIME, Applicate.DEF_START_TIME.ToString());

            LogUtils.Log("down friends start insert........" + friends.Count);
            // 批量插入
            if (temp.InsertRange(friends))
            {
                Console.WriteLine("批量插入数据成功" + friends.Count);
            }

            // 生成设备号
            CreateDeviceFriend();

            friendDownCompe = 1;
            LogUtils.Log("down friends compte........");
        }

        private void UpdateRoomData(DownRoomBean list)
        {
            LogUtils.Log("down room UpdateRoomData........" + list.data.Count);

            // 遍历服务器所有的群组
            List<Friend> friends = list.ToRoomFriends();
            if (friends != null)
            {
                LogUtils.Log("down room start insert........" + friends.Count);
            }

            InsertRoomMember(friends);


            Friend temp = new Friend();
            // 是否存在群组
            if (temp.IsExistFriend(true))
            {
                // 删除全部旧的群组
                temp.RemoveAllGroup();
            }

            // 批量插入
            if (temp.InsertRange(friends))
            {
                if (friends != null)
                {
                    Console.WriteLine("批量插入数据成功" + friends.Count);
                }
            }

            LogUtils.Log("down room start member........");

            List<RoomMember> members = new List<RoomMember>();
            // 存入我的身份
            foreach (DownRoom room in list.data)
            {
                RoomMember mem = room.ToMeMember(room.id);

                if (mem != null)
                {
                    mem.DeleteByUserId();
                    members.Add(mem);
                }
            }

            LogUtils.Log("down room start insert........");

            // 批量插入
            new RoomMember().InsertRange(members);

            roomDownCompe = 1;
            Compt();
            LogUtils.Log("down room compte........");
        }

        public void InsertRoomMember(List<Friend> friends)
        {
            //if (null == friends) return;
            //foreach (var friend in friends)
            //{
            //    //将数据保存
            //    HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/get") //获取群详情
            //        .AddParams("access_token", Applicate.Access_Token)
            //        .AddParams("roomId", friend.RoomId)
            //        .AddParams("pageSize", "5")
            //         .Build().Execute((sccess, room) =>
            //         {
            //             if (sccess)
            //             {
            //                 if (room.ContainsKey("members"))
            //                 {
            //                     var members = JsonConvert.DeserializeObject<List<object>>(room["members"].ToString());
            //                     foreach (var item in members)
            //                     {
            //                         var member = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());
            //                         RoomMember roomMember = new RoomMember();
            //                         roomMember.role = UIUtils.DecodeInt(member, "role");
            //                         roomMember.userId = UIUtils.DecodeString(member, "userId");
            //                         roomMember.createTime = UIUtils.DecodeInt(member, "createTime");
            //                         roomMember.modifyTime = UIUtils.DecodeInt(member, "modifyTime");
            //                         roomMember.nickName = UIUtils.DecodeString(member, "nickname");
            //                         roomMember.offlineNoPushMsg = UIUtils.DecodeInt(member, "offlineNoPushMsg");
            //                         roomMember.sub = UIUtils.DecodeInt(member, "sub");
            //                         roomMember.talkTime = UIUtils.DecodeLong(member, "talkTime");
            //                         roomMember.remarkName = UIUtils.DecodeString(member, "remarkName");
            //                         roomMember.cardName = UIUtils.DecodeString(member, "cardName");
            //                         roomMember.roomId = friend.RoomId;
            //                         roomMember.InsertOrUpdate();

            //                     }
            //                 }
            //             }
            //         });

            //}
        }
    }
}
