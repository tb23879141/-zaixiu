﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using WinFrmTalk.Model.dao;

namespace WinFrmTalk.Model
{

    #region 朋友
    /// <summary>
    /// 接口返回的朋友
    /// </summary>
    public class JsonFriends : JsonBase
    {

        #region 构造函数
        public JsonFriends()
        {
            Data = new List<Friend>();
        }
        #endregion

        public List<Friend> Data { get; set; }

    }
    #endregion

    #region Friend
    /// <summary>
    /// Friend数据结构
    /// </summary>
    public class Friend
    {

        public const string ID_NEW_FRIEND = "10001";// 新朋友消息 ID
        public const string ID_BAN_LIST = "9999";// 黑名单列表
        public const string ID_PUBLIC_LIST = "9998";// 公众号列表
        public const string ID_SK_PAY = "1100";// 支付公众号，
        public const string ID_BLOG_MESSAGE = "10002";// 商务圈消息ID
        public const string ID_INTERVIEW_MESSAGE = "10004";// 面试中心ID（用于职位、初试、面试的推送）
        public const string ID_SYSTEM_NOTIFICATION = "10005";// 系统号，用于各种控制消息通知，
        public const string ID_SYSTEM = "10000";// 系统号，用于各种控制消息通知，


        // 好友状态
        public const int STATUS_BLACKLIST = -1;// 黑名单
        public const int STATUS_UNKNOW = 0;// 陌生人(不可能出现在好友表，只可能在新朋友消息表)
        public const int STATUS_ATTENTION = 1;// 关注
        public const int STATUS_FRIEND = 2;// 好友
        public const int STATUS_SYSTEM = 8;// 显示系统号
        // 需要验证的
        public const int STATUS_10 = 10; //显示  等待验证
        public const int STATUS_11 = 11; //您好
        public const int STATUS_12 = 12; //已通过验证
        public const int STATUS_13 = 13; //验证被通过了
        public const int STATUS_14 = 14; //别人回话
        public const int STATUS_15 = 15; //回话
        public const int STATUS_16 = 16; //已删除了XXX
        public const int STATUS_17 = 17; //XXX删除了我
        public const int STATUS_18 = 18; //已拉黑了XXX
        public const int STATUS_19 = 19; //XXX拉黑了我
        public const int STATUS_20 = 20; //默认值什么都不显示
        // 不需要验证的
        public const int STATUS_21 = 21;//XXX 添加你为好友
        public const int STATUS_22 = 22;//你添加好友 XXX
        public const int STATUS_24 = 24;//XXX 已经取消了黑名单
        public const int STATUS_23 = 23;//对方把我加入了黑名单
        public const int STATUS_25 = 25;//通过手机联系人添加
        public const int STATUS_26 = 26;//被后台删除的好友，仅用于新的朋友页面显示，


        #region Public Member

        /// <summary>
        /// 朋友id，如果是房间就是roomJid
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, Length = 128)]
        public string UserId { get; set; }

        /// <summary>
        ///通讯号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string AccountId { get; set; }


        /// <summary>
        /// 好友创建时间戳
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int CreateTime { get; set; }


        /// <summary>
        /// 与该好友的状态 
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int Status { get; set; }

        /// <summary>
        /// 用户类型 @see FriendType
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int UserType { get; set; }

        /// <summary>
        /// 好友昵称/名称
        /// <para>当对象为群时，该字段为群名称</para>
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string NickName { get; set; }

        /// <summary>
        /// 消息免打扰
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int Nodisturb { get; set; }

        /// <summary>
        /// 好友区号，例如86是中国
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 区id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int AreaId { get; set; }

        /// <summary>
        /// 城市id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int CityId { get; set; }

        /// <summary>
        /// 个人说明，个性签名
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }

        /// <summary>
        /// 省份id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int ProvinceId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int Sex { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Telephone { get; set; }

        /// <summary>
        /// 备注名
        /// <para>如果时单聊则为备注名，如果是群聊则为群名片</para>
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string RemarkName { get; set; }

        /// <summary>
        /// 备注名
        /// <para>如果时单聊则为备注名，如果是群聊则为群名片</para>
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string RemarkPhone { get; set; }

        /// <summary>
        /// 是否群组
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsGroup { get; set; }

        /// <summary>
        /// 最后一条聊天内容（用于处理是否在最近聊天列表中内容）
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Content { get; set; }


        /// <summary>
        /// 最后一条消息的类型
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int LastMsgType { get; set; }


        /// <summary>
        /// 最后一次聊天时间戳
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public double LastMsgTime { get; set; }

        /// <summary>
        /// 未读消息数量
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int MsgNum { get; set; }

        /// <summary>
        /// 房间的id
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string RoomId { get; set; }

        /// <summary>
        /// 最近输入( 未发送的草稿)
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string LastInput { get; set; }

        /// <summary>
        /// 好友身份身份  1=游客（?用于后台浏览数据）；2=公众号 ；3=机器账号，由系统?自动?生成；4=客服账号;5=管理员；6=超级管理员；7=财务； 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        [JsonIgnore]
        public string Role { get; set; }

        /// <summary>
        ///  群组?里里?面是否有@我的消息 
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsAtMe { get; set; }

        /// <summary>
        /// 是否显示已读
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int ShowRead { get; set; }

        /// <summary>
        /// 是否显示群成员
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int ShowMember { get; set; }

        /// <summary>
        /// 允许普通群成员私聊
        /// 1 允许  0 不允许 2019年7月31日16:21:01
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AllowSendCard { get; set; }

        /// <summary>
        /// 允许普通群成员邀请好友
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AllowInviteFriend { get; set; }

        /// <summary>
        /// 允许普通群成员上传文件
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AllowUploadFile { get; set; }

        /// <summary>
        /// 允许普通群成员召开会议
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AllowConference { get; set; }


        /// <summary>
        /// 允许普通群成员发起讲课
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AllowSpeakCourse { get; set; }
        [SugarColumn(IsNullable = true)]
        public int AllowOpenLive { get; set; }

        /// <summary>
        /// 此群组是否开始阅后即焚
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsOpenReadDel { get; set; }


        /// <summary>
        /// 我的某一个设备是否在线（多点登录使用，标识我的某一个设备是否在线）
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsOnLine { get; set; }

        /// <summary>
        /// 是否要转发给此用户（多点登录使用，是否要转发消息给此用户（当前账号的其他设备））
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsSendRecipt { get; set; }

        /// <summary>
        /// 置顶时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int TopTime { get; set; }

        /// <summary>
        /// 是否开启群主验证
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsNeedVerify { get; set; }

        /// <summary>
        /// 出生如期
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long Birthday { get; set; }

        /// <summary>
        /// 漫游的开始时间
        /// </summary>
        public double DownloadRoamStartTime { get; set; }

        /// <summary>
        /// 漫游的结束时间
        /// </summary>
        public double DownloadRoamEndTime { get; set; }

        /// <summary>
        /// 上次漫游离线消息的结束时间
        /// </summary>
        public double OfflineEndTime { get; set; }

        /// <summary>
        /// 群组是否已经解散  
        /// IsDismiss == 1 已被解散
        /// IsDismiss == 2 已被锁定
        /// </summary>
        public int IsDismiss { get; set; }

        /// <summary>
        /// 是否刚刚清除聊天记录
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsClearMsg { get; set; }
        /// <summary>
        /// dh公钥
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string DhPublicKey { get; set; }

        /// <summary>
        /// rsa公钥
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string RsaPublicKey { get; set; }

        /// <summary>
        /// 私密群组通信Key
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string ChatKeyGroup { get; set; }

        /// <summary>
        /// 标记我已丢失当前私密群组的chatKey
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsLostKeyGroup { get; set; }

        /// <summary>
        /// 是否启用端到端加密
        /// 0 不加密 1 old 3des 2 aes 3 dh
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsEncrypt { get; set; }


        /// <summary>
        /// 标记当前是否端到端群组
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int IsSecretGroup { get; set; }

        ///// <summary>
        ///// 当前称呼首字母
        ///// </summary>
        [SugarColumn(IsNullable = true)]
        public int fristAscII { get; set; }

        #endregion

        #region Consturtor


        #region 非持久化字段


        /// <summary>
        /// 群分类参考type字段 0普通群；2官方群；3商城群；4临时群；5个人粉丝群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
        /// </summary>
        [JsonIgnore]
        public int GroupType { get; set; }


        /// <summary>
        /// 官群ID
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        public string OfficialGroupId { get; set; }

        /// <summary>
        /// 是否可以围观
        /// -1 不可围观
        /// 1 可以围观
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        public int isLook { get; set; }

        /// <summary>
        /// 临时群组
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        public long deleteTime { get; set; }

        /// <summary>
        ///移动状态(0 没有状态 1 群移动 2群中群)
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        public int movingState { get; set; }

        /// <summary>
        /// 0==内部群 1==外部群
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int inside { get; set; }
        #endregion


        public Friend()
        {

        }

        #endregion


        /// <summary>
        /// 获取好友备注名，如果没有备注则显示昵称
        /// </summary>
        /// <returns></returns>
        internal string GetRemarkName()
        {
            if (string.IsNullOrEmpty(RemarkName))
            {
                return NickName;
            }

            return RemarkName;
        }

        /// <summary>
        /// 获取通讯号
        /// </summary>
        /// <returns></returns>
        public string GetFriendInfoId()
        {
            if (!string.IsNullOrEmpty(AccountId))
            {
                return AccountId;
            }
            else
            {
                return UserId;
            }
        }

        #region 创建数据库表
        /// <summary>
        /// 创建数据库表
        /// </summary>
        public bool CreateFriendTable()
        {
            return FriendDao.Instance.CreateTable();
        }
        #endregion


        internal int GetFristASCIICode()
        {
            if (UserType == FriendType.NEWFRIEND_TYPE)
            {
                if (UserId.Equals(ID_NEW_FRIEND))
                {
                    return 10;
                }
                else if (UserId.Equals(ID_BAN_LIST))
                {
                    return 11;
                }
                else
                {
                    return 12;
                }
            }
            else if (UserType == FriendType.DEVICE_TYPE)
            {
                return 20;
            }
            else if (UserType == FriendType.PUBLICIZE_TYPE)
            {
                // 公众号 35 - 60
                return PinYinUtils.GetFristASCIICode(GetRemarkName()) - 30;
            }
            else
            {
                // 普通人 65 - 90
                return PinYinUtils.GetFristASCIICode(GetRemarkName());
            }
        }


        public void UpdateFristAscII(int fristAscii)
        {

            if (CreateFriendTable())
            {
                try
                {
                    var result = DBSetting.SQLiteDBContext.Updateable<Friend>()
                        .UpdateColumns(it => new Friend() { fristAscII = fristAscii })
                        .Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }

        }

        internal string GetColumnTitle()
        {
            if (UserType == FriendType.NEWFRIEND_TYPE)
            {
                if (UserId.Equals(ID_NEW_FRIEND))
                {
                    return "新的朋友";
                }
                else if (UserId.Equals(ID_BAN_LIST))
                {
                    return "黑名单";
                }
                else
                {
                    return "公众号";
                }

            }
            else if (UserType == FriendType.DEVICE_TYPE)
            {
                return "我的设备";
            }
            else if (UserType == FriendType.PUBLICIZE_TYPE)
            {
                return "公众号";
            }
            else
            {
                if (fristAscII >= 65 && fristAscII <= 90)
                {
                    byte code = Convert.ToByte(fristAscII);
                    return Encoding.ASCII.GetString(new byte[] { code });
                }
                else
                {
                    return "#";
                }
            }
        }

        #region 分页获取好友
        /// <summary>
        /// 分页获取好友（按名字排序）
        /// </summary>
        /// <param name="pageIndex">0和1都是第一页</param>
        /// <param name="pageSize">一页多少条数据</param>
        /// <returns></returns>
        public List<Friend> GetByPage(int pageIndex = 0, int pageSize = 30)
        {
            if (CreateFriendTable())
            {
                List<Friend> Lists = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.IsGroup == this.IsGroup).
                    OrderBy(it => it.NickName).ToPageList(pageIndex, pageSize);
                return Lists ?? new List<Friend>();
            }
            return new List<Friend>();
        }
        #endregion


        #region 获取公众号列表
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetByOfficialAccountLst()
        {
            if (CreateFriendTable())
            {
                List<Friend> Lists = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.UserType == FriendType.PUBLICIZE_TYPE).
                    OrderBy(it => it.fristAscII).ToList();//.ToPageList(pageIndex, pageSize);
                return Lists ?? new List<Friend>();
            }
            return new List<Friend>();
        }
        #endregion

        #region 插入到数据库
        /// <summary>
        /// 插入到数据库
        /// </summary>
        public bool InsertAuto()
        {
            if (CreateFriendTable())
            {
                var friend = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);
                int result = 0;
                if (friend == null)
                {
                    result = DBSetting.SQLiteDBContext.Insertable(this).ExecuteCommand();
                }
                else
                {
                    result = DBSetting.SQLiteDBContext.Updateable(this).ExecuteCommand();//更新
                }
                return result > 0 ? true : false;
            }
            return false;
        }
        #endregion

        #region 判断是否存在朋友，没有就插入
        /// <summary>
        /// 插入到数据库
        /// </summary>
        public bool InsertRange(List<Friend> friends)
        {
            if (CreateFriendTable())
            {
                int result = 0;
                try
                {
                    if (!UIUtils.IsNull(friends))
                    {
                        result = DBSetting.SQLiteDBContext.Insertable(friends).ExecuteCommand();
                    }
                }
                catch (Exception)
                {
                    foreach (var item in friends)
                    {
                        item.InsertData();
                    }

                }

                return result > 0;
            }
            return false;

        }

        public bool InsertData()
        {
            if (CreateFriendTable())
            {
                int result = 0;
                if (!UIUtils.IsNull(this.UserId))
                {
                    try
                    {
                        result = DBSetting.SQLiteDBContext.Insertable(this).ExecuteCommand();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                return result > 0;
            }
            return false;
        }

        public bool InsertNonFriend()
        {
            if (CreateFriendTable())
            {
                var friend = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);
                int result = 0;
                if (friend == null)
                {
                    result = DBSetting.SQLiteDBContext.Insertable(this).ExecuteCommand();
                }
                return result > 0;
            }
            return false;
        }

        internal void UpdateChatKeyGroup(string chatKeyGroup)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.ChatKeyGroup = chatKeyGroup;
                    var result = DBSetting.SQLiteDBContext.Updateable<Friend>()
                        .UpdateColumns(it => new Friend() { ChatKeyGroup = chatKeyGroup })
                        .Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
        }


        #endregion



        #region 更新到数据库
        /// <summary>
        /// 更新到数据库
        /// </summary>
        public int Update()
        {
            if (CreateFriendTable())
            {
                try
                {
                    //DBSetting.SQLiteDBContext.Updateable(this).ExecuteCommand();     //默认主键为筛选条件
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().Where(f => f.UserId == UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }


        //更新密钥丢失状态
        internal int UpdateLostKeyGroup()
        {
            if (CreateFriendTable())
            {
                int result = DBSetting.SQLiteDBContext.Updateable<Friend>().UpdateColumns(it => new Friend()
                {
                    IsLostKeyGroup = this.IsLostKeyGroup
                }).Where(it => it.UserId == this.UserId).ExecuteCommand();

                return result;
            }
            return 0;

        }
        #endregion

        #region 更新好友关系
        /// <summary>
        /// 更新好友关系
        /// </summary>
        /// <param name="UserId">好友Id</param>
        /// <param name="state">状态
        /// <para>好友状态-2黑名单(对方拉黑我方) -1://黑名单(我方拉黑对方)；0：陌生人；1:单方关注；2:互为好友</para>
        /// </param>
        public void UpdateFriendState(string UserId, int state)
        {
            try
            {
                this.UserId = UserId;
                UpdateFriendState(state);
            }
            catch (Exception ex)
            {
                ConsoleLog.Output(ex.Message);
            }
        }
        #endregion

        #region 更新好友关系

        public int GetFriendState(string UserId)
        {
            if (CreateFriendTable())
            {
                var friend = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);

                if (friend != null)
                {
                    return friend.Status;
                }
            }

            return 0;
        }
        #endregion

        #region 更新好友关系
        /// <summary>
        /// 更新好友关系
        /// <para>好友状态-2黑名单(对方拉黑我方) -1://黑名单(我方拉黑对方)；0：陌生人；1:单方关注；2:互为好友</para>
        /// </summary>
        /// <param name="UserId">好友Id</param>
        /// <param name="state">状态
        /// </param>
        public int UpdateFriendState(int state)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.Status = state;
                    //"Update Friend set status = " + state + " where userId=" + UserId;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>()
                        .UpdateColumns(it => new Friend() { Status = state }).
                        Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新好友关系
        /// <summary>
        /// 和一个用户成为好友
        /// </summary>
        public int BecomeFriend(kWCMessageType type)
        {
            if (CreateFriendTable())
            {
                this.LastMsgType = (int)type;
                this.Status = Friend.STATUS_FRIEND;

                if (UserType == 2)
                {
                    Content = "已关注公众号";
                }
                else
                {
                    Content = "你们已经成为好友，快来聊天吧";
                }
                //this.Content = "你们已经成为好友，快来聊天吧";
                this.fristAscII = GetFristASCIICode();
                this.LastMsgTime = TimeUtils.CurrentIntTime();
                this.MsgNum = 1;


                var friend = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);

                if (friend != null)
                {
                    DBSetting.SQLiteDBContext.Updateable<Friend>()
                    .UpdateColumns(it => new Friend()
                    {
                        fristAscII = this.fristAscII,
                        Status = this.Status,
                        Content = this.Content,
                        LastMsgTime = this.LastMsgTime,
                        MsgNum = this.MsgNum,
                        LastMsgType = this.LastMsgType
                    }).
                    Where(it => it.UserId == this.UserId).ExecuteCommand();

                    return 1;
                }
                else
                {
                    InsertAuto();
                }
            }
            return 0;
        }
        #endregion

        internal int UpdateClearMessageState(int isClear)
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().UpdateColumns(it => new Friend()
                    {
                        IsClearMsg = isClear,
                    }).Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }


        internal int UpdateDownTime(double startTime, double endTime)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.DownloadRoamStartTime = startTime;
                    this.DownloadRoamEndTime = endTime;

                    return DBSetting.SQLiteDBContext.Updateable<Friend>().UpdateColumns(it => new Friend()
                    {
                        DownloadRoamStartTime = startTime,
                        DownloadRoamEndTime = endTime,
                    }).Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;

        }

        #region 更新好友最后一条聊天内容
        /// <summary>
        /// 更新好友最后一条聊天内容
        /// </summary>
        /// <param name="UserId">好友Id</param>
        /// <param name="content">最后的聊天内容
        /// </param>
        public int UpdateFriendLastContent(string con, int type, double time)
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().UpdateColumns(it => new Friend()
                    {
                        Content = con,
                        LastMsgTime = time,
                        LastMsgType = type

                    }).Where(it => it.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        /// <summary>
        ///  下载最后一条消息提示
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ToLastContentTip(DataItem item)
        {
            kWCMessageType type = (kWCMessageType)item.type;

            switch (type)
            {
                case kWCMessageType.Withdraw:
                    if (Applicate.MyAccount.Equals(item.from))
                    {
                        return "你撤回了一条消息";
                    }
                    else
                    {
                        return item.fromUserName + "撤回了一条消息";
                    }
                case kWCMessageType.TYPE_83:
                    if (Applicate.MyAccount.Equals(item.from))
                    {
                        return "你领取了" + item.toUserName + "的红包";
                    }
                    else
                    {
                        return item.fromUserName + "领取了你的红包";
                    }
                case kWCMessageType.RoomIsVerify:
                    if ("1".Equals(item.content))
                    {
                        return item.fromUserName + "开启了进群验证";
                    }
                    else if ("0".Equals(item.content))
                    {
                        return item.fromUserName + "关闭了进群验证";
                    }
                    else
                    {
                        return item.content;
                    }
                case kWCMessageType.TYPE_TRANSFER_RECEIVE:
                    if (Applicate.MyAccount.Equals(item.from))
                    {
                        return "我已领取对方转账";
                    }
                    else
                    {
                        return "转账已被对方领取";
                    }
                case kWCMessageType.RoomNotice:

                    return item.fromUserName + "发布了新公告";
                case kWCMessageType.RoomAdmin:

                    if (item.content == "0")//取消管理员
                    {
                        return item.fromUserName + "取消管理员" + item.toUserName;
                    }
                    else if (item.content == "1")//设置管理员8
                    {
                        return item.fromUserName + "设置:" + item.toUserName + "为管理员";
                    }
                    else
                    {
                        return item.content;
                    }
                case kWCMessageType.RoomInvite:

                    if (item.from.Equals(item.to) || item.from.Equals(item.to))
                    {
                        return item.fromUserName + "进入群组";
                    }
                    else
                    {
                        return item.fromUserName + "邀请成员:" + item.toUserName;
                    }
                case kWCMessageType.RoomAllBanned://群组全员禁言 

                    return item.timeSend == 0 ? "已关闭全体禁言" : "已开启全体禁言";
                case kWCMessageType.RoomIsPublic:
                    return item.content == "0" ? item.fromUserName + "将本群设为公开群组" : item.fromUserName + "将本群设为私密群组";

                case kWCMessageType.RoomFileUpload://上传了群文件(删除，上传，下载这三个在这里获取不到文件名称)
                    return item.fromUserName + "上传了群文件";

                case kWCMessageType.RoomFileDelete://删除群文件
                    return item.fromUserName + "删除了群文件:";

                case kWCMessageType.RoomFileDownload://下载群文件
                    return item.fromUserName + "下载了群文件:";
                default:
                    return ToLastContentTip(type, item.content);
            }

        }


        public string ToLastContentTip(kWCMessageType type, string con, string from, string fromUserName, string toUserName)
        {
            switch (type)
            {
                case kWCMessageType.RoomIsVerify:
                    if ("1".Equals(con))
                    {
                        return from + "开启了进群验证";
                    }
                    else if ("0".Equals(con))
                    {
                        return from + "关闭了进群验证";
                    }
                    else
                    {
                        return con;
                    }
                case kWCMessageType.Withdraw:
                    if (Applicate.MyAccount.userId.Equals(from))
                    {
                        return "你撤回了一条消息";
                    }
                    else
                    {
                        return fromUserName + "撤回了一条消息";
                    }
                case kWCMessageType.TYPE_83:
                    if (Applicate.MyAccount.userId.Equals(from))
                    {
                        return "你领取了" + toUserName + "的红包";
                    }
                    else
                    {
                        return fromUserName + "领取了你的红包";
                    }
                case kWCMessageType.TYPE_TRANSFER_RECEIVE:
                    if (Applicate.MyAccount.userId.Equals(from))
                    {
                        return "我已领取对方转账";
                    }
                    else
                    {
                        return "转账已被对方领取";
                    }
                case kWCMessageType.RoomNotice:

                    if (!UIUtils.IsNull(con))
                    {
                        con = con.Replace("\r\n", "");
                        con = con.Replace("\n", "");
                    }

                    return UIUtils.QuotationName(fromUserName) + "发布了新公告" + UIUtils.QuotationName(con);
                case kWCMessageType.RoomAdmin:

                    if (con == "0")//取消管理员
                    {
                        return fromUserName + "取消管理员" + toUserName;
                    }
                    else if (con == "1")//设置管理员8
                    {
                        return fromUserName + "设置:" + toUserName + "为管理员";
                    }
                    else
                    {

                        return con;
                    }
                case kWCMessageType.RoomAllBanned://群组全员禁言 

                    return con == "0" ? "已关闭全体禁言" : "已开启全体禁言";

                default:
                    return ToLastContentTip(type, con);
            }
        }

        internal List<MessageObject> GetFailMessageList()
        {
            var list = new MessageObject() { FromId = UserId, ToId = Applicate.MyAccount.userId }.GetFailMessageList();
            return list;
        }

        public string ToLastContentTip(kWCMessageType type, string con)
        {

            if (!UIUtils.IsNull(con))
            {
                con = con.Replace("\r\n", "");
                con = con.Replace("\n", "");
            }

            switch (type)
            {
                case kWCMessageType.Image:
                    return LanguageXmlUtils.GetValue("Image", "图片").AddBrackets();
                case kWCMessageType.Voice:
                    return LanguageXmlUtils.GetValue("Voice", "语音").AddBrackets();
                case kWCMessageType.Location:
                    return LanguageXmlUtils.GetValue("Location", "位置").AddBrackets();
                case kWCMessageType.Gif:
                    return LanguageXmlUtils.GetValue("Gif", "动画").AddBrackets();
                case kWCMessageType.Video:
                    return LanguageXmlUtils.GetValue("Video", "视频").AddBrackets();
                case kWCMessageType.Audio:
                    return LanguageXmlUtils.GetValue("Audio", "视频").AddBrackets();
                case kWCMessageType.Card:
                    return LanguageXmlUtils.GetValue("Card", "名片").AddBrackets();
                case kWCMessageType.File:
                    return LanguageXmlUtils.GetValue("File", "文件").AddBrackets();
                case kWCMessageType.RedPacket:
                    return LanguageXmlUtils.GetValue("RedPacket", "红包").AddBrackets();
                case kWCMessageType.TRANSFER:
                    return LanguageXmlUtils.GetValue("TRANSFER", "转账").AddBrackets();
                case kWCMessageType.ImageTextSingle:
                    return LanguageXmlUtils.GetValue("ImageTextSingle", "单条图文").AddBrackets();
                case kWCMessageType.ImageTextMany:
                    return LanguageXmlUtils.GetValue("ImageTextMany", "多条图文").AddBrackets();
                case kWCMessageType.Link:
                case kWCMessageType.SDKLink:
                    return LanguageXmlUtils.GetValue("Link", "链接").AddBrackets();
                case kWCMessageType.PokeMessage:
                    return LanguageXmlUtils.GetValue("PokeMessage", "戳一戳").AddBrackets();
                case kWCMessageType.History:
                    return LanguageXmlUtils.GetValue("History", "聊天记录").AddBrackets();
                case kWCMessageType.AudioChatEnd:
                    return LanguageXmlUtils.GetValue("AudioChatEnd", "语音通话结束").AddBrackets();
                case kWCMessageType.VideoChatEnd:
                    return LanguageXmlUtils.GetValue("VideoChatEnd", "视频通话结束").AddBrackets();
                case kWCMessageType.VideoChatCancel:
                    return LanguageXmlUtils.GetValue("VideoChatCancel", "取消了视频通话").AddBrackets();
                case kWCMessageType.AudioChatCancel:
                    return LanguageXmlUtils.GetValue("AudioChatCancel", "取消了语音通话").AddBrackets();
                case kWCMessageType.RedBack:
                    return LanguageXmlUtils.GetValue("RedBack", "红包已过期,余额已退回零钱").AddBrackets();
                case kWCMessageType.TYPE_SECURE_REFRESH_KEY:
                    return "欢迎使用本软件";
                case kWCMessageType.TYPE_SECURE_LOST_KEY:
                    return LanguageXmlUtils.GetValue("TYPE_SECURE_LOST_KEY", "请求群组通讯密钥").AddBrackets();
                case kWCMessageType.TYPE_SECURE_SEND_KEY:
                    return LanguageXmlUtils.GetValue("TYPE_SECURE_SEND_KEY", "发送群组通讯密钥").AddBrackets();
                case kWCMessageType.ProductPush:
                    return LanguageXmlUtils.GetValue("ProductPush", "商品链接").AddBrackets();
                case kWCMessageType.ResouresNotify:
                    return LanguageXmlUtils.GetValue("ProductPush", "公告").AddBrackets();
                case kWCMessageType.ResouresResoures:
                    return LanguageXmlUtils.GetValue("ProductPush", "资源").AddBrackets();
                case kWCMessageType.ResouresActive:
                    return LanguageXmlUtils.GetValue("ProductPush", "活动").AddBrackets();
                case kWCMessageType.ResouresSocial:
                    return LanguageXmlUtils.GetValue("ProductPush", "秀吧").AddBrackets();
                case kWCMessageType.Solitaire:
                    return LanguageXmlUtils.GetValue("ProductPush", "接龙").AddBrackets();
                case kWCMessageType.GroupInviateLink:
                    return LanguageXmlUtils.GetValue("ProductPush", "邀请链接").AddBrackets();
                default:
                    return con;
            }
        }

        #region 更新到数据库
        /// <summary>
        /// 更新到数据库
        /// </summary>
        public int UpdateDetial()
        {
            if (CreateFriendTable())
            {
                try
                {
                    //DBSetting.SQLiteDBContext.Updateable(this).ExecuteCommand();     //默认主键为筛选条件
                    return DBSetting.SQLiteDBContext.Updateable(this).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 获取首字母


        #endregion


        #region 根据status批量删除
        /// <summary>
        /// 根据status批量删除
        /// </summary>
        public int DeleteByStatus()
        {
            if (CreateFriendTable())
            {
                try
                {
                    //var result = (
                    //    from friend in DBSetting.AccountDbContext.Friends
                    //    where friend.status == this.status
                    //    select friend);
                    //if (result != null)
                    //{
                    //    DBSetting.AccountDbContext.Friends.RemoveRange(result);
                    //    DBSetting.AccountDbContext.SaveChanges();
                    //}
                    return DBSetting.SQLiteDBContext.Deleteable<Friend>().Where(f => f.Status == this.Status).ExecuteCommand();
                }
                catch (Exception e)
                {
                    ConsoleLog.Output(e.Message);
                }
            }
            return 0;
        }
        #endregion


        #region 根据userId批量删除
        /// <summary>
        /// 根据userId批量删除
        /// </summary>
        public int DeleteByUserId()
        {
            if (CreateFriendTable())
            {
                try
                {
                    //var result = (
                    //    from friend in DBSetting.AccountDbContext.Friends
                    //    where friend.status == this.status
                    //    select friend);
                    //if (result != null)
                    //{
                    //    DBSetting.AccountDbContext.Friends.RemoveRange(result);
                    //    DBSetting.AccountDbContext.SaveChanges();
                    //}
                    return DBSetting.SQLiteDBContext.Deleteable<Friend>().Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception e)
                {
                    ConsoleLog.Output(e.Message);
                }
            }
            return 0;
        }

        internal RoomMember ToRoomMember(string roomId)
        {
            RoomMember member = new RoomMember()
            {
                roomId = roomId,
                userId = UserId,
                nickName = NickName,
                role = 3,
                talkTime = 0,
                sub = 1,
                offlineNoPushMsg = 0
            };
            return member;
        }

        /// <summary>
        /// 修改@我的消息状态， 2 == @全体成员 1 == @我
        /// </summary>
        /// <param name="atme"></param>
        internal void UpdateAtMeState(int atme)
        {
            this.IsAtMe = atme;
            if (CreateFriendTable())
            {
                try
                {
                    DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { IsAtMe = atme }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }

        }
        #endregion

        #region 根据status批量删除
        /// <summary>
        /// 根据status批量删除
        /// <paramref name="status">状态值</paramref>
        /// </summary>
        public int DeleteByStatus(int status)
        {
            if (CreateFriendTable())
            {
                try
                {
                    //var result = (
                    //    from friend in DBSetting.AccountDbContext.Friends
                    //    where friend.status == status
                    //    select friend).ToList();
                    //if (result != null)
                    //{
                    //    DBSetting.AccountDbContext.Friends.RemoveRange(result);
                    //    DBSetting.AccountDbContext.SaveChanges();
                    //}
                    return DBSetting.SQLiteDBContext.Deleteable<Friend>().Where(f => f.Status == status).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }


        #endregion

        #region 序列化
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }


        #endregion


        /// <summary>
        /// 更新某个朋友的消息置顶
        /// </summary>
        /// <param name="time"></param>
        internal void UpdateTopTime(int time)
        {

            if (CreateFriendTable())
            {
                try
                {
                    DBSetting.SQLiteDBContext.Updateable<Friend>().
                       UpdateColumns(f => new Friend() { TopTime = time }).
                       Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
        }



        /// <summary>
        /// 更新消息免打扰
        /// </summary>
        /// <param name="time"></param>
        internal void UpdateNodisturb()
        {
            if (CreateFriendTable())
            {
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                      UpdateColumns(f => new Friend() { Nodisturb = Nodisturb }).
                      Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }

        /// <summary>
        /// 更新阅后即焚
        /// </summary>
        /// <param name="time"></param>
        internal void UpdateReadDel()
        {
            if (CreateFriendTable())
            {
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                      UpdateColumns(f => new Friend() { IsOpenReadDel = IsOpenReadDel }).
                      Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }

        /// <summary>
        /// 更新消息加密传输方式
        /// </summary>
        /// <param name="encrypt"></param>
        internal void UpdateEncrypt(int encrypt)
        {
            if (CreateFriendTable())
            {
                this.IsEncrypt = encrypt;
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                      UpdateColumns(f => new Friend() { IsEncrypt = encrypt }).
                      Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }
        /// <summary>
        /// 是否是加密群组
        /// </summary>
        /// <param name="encrypt"></param>
        internal void UpdateSecretGroup(int secretGroup)
        {
            if (CreateFriendTable())
            {
                this.IsSecretGroup = secretGroup;
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                      UpdateColumns(f => new Friend() { IsSecretGroup = secretGroup }).
                      Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }


        #region 反序列化
        public Friend ToModel(string strJson)
        {
            Friend msgObj = JsonConvert.DeserializeObject<Friend>(strJson);
            return msgObj;
        }
        #endregion

        #region 根据status获得列表
        /// <summary>
        /// 根据status获得列表
        /// </summary>
        public List<Friend> GetListByStatus()
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.Status == this.Status && f.IsGroup == this.IsGroup).ToList();
            }
            return new List<Friend>();
        }
        #endregion

        #region 根据userId从本地数据库获得对象
        /// <summary>
        /// 根据userId获得本地数据库对象
        /// </summary>
        /// <returns></returns>
        public Friend GetByUserId()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);


                return result == null ? this : result;
            }
            return this;
        }
        #endregion

        #region 根据roomId从本地数据库获得对象
        /// <summary>
        /// 根据userId获得本地数据库对象
        /// </summary>
        /// <returns></returns>
        public Friend GetFriendByRoomId(string roomId)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.RoomId == roomId);
                return result;

            }
            return this;
        }
        #endregion

        #region 根据userId从本地数据库获得对象
        /// <summary>
        /// 根据userId获得本地数据库对象
        /// </summary>
        /// <returns></returns>
        public Friend GetFdByUserId()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);

                if (IsGroup == 1)
                {
                    return result;
                }

                return result == null ? this : result;
            }
            return this;
        }
        #endregion

        #region 是否存在数据库中
        /// <summary>
        /// 是否存在数据库中
        /// </summary>
        /// <param name="userId">需要查询的UserId</param>
        /// <returns>表示是否存在</returns>
        public bool ExistsLocal(string userId)
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.UserId == userId).Any();
            }
            return false;
        }
        #endregion

        #region 是否存在我方黑名单中
        /// <summary>
        /// 是否存在我方黑名单中
        /// </summary>
        /// <param name="userId">需要查询的UserId</param>
        /// <returns>是否存在值</returns>
        public bool ExistsBlackList(string userId)
        {
            if (CreateFriendTable())
            {
                //int count = DBSetting.dbContext.Friends.Count(f => f.userId == userId && f.status == -1);
                return DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.UserId == userId && f.Status == -1).Any();
            }
            return false;
        }
        #endregion

        #region 与该好友是否为好友
        /// <summary>
        /// 与该好友是否为好友
        /// </summary>
        /// <param name="userId">需要查询的UserId</param>
        /// <returns>是否存在</returns>
        public bool ExistsFriend()
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.UserId == UserId && f.Status == 2).Any();
            }
            return false;
        }
        #endregion



        #region 根据UserName获取(支持模糊查询)
        public List<Friend> GetByUserName(string str_like)
        {
            if (CreateFriendTable())
            {
                //模糊查询
                List<IConditionalModel> conModels = new List<IConditionalModel>();
                //conModels.Add(new ConditionalModel() { FieldName = "Name", ConditionalType = ConditionalType.Equal, FieldValue = "s" });
                conModels.Add(new ConditionalModel() { FieldName = "isGroup", ConditionalType = ConditionalType.Equal, FieldValue = this.IsGroup.ToString() });
                conModels.Add(new ConditionalModel() { FieldName = "Name", ConditionalType = ConditionalType.Like, FieldValue = str_like });
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(conModels).OrderBy(it => it.NickName).ToList();
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取最近聊天列表
        /// <summary>
        /// 获取最近聊天列表
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetRecentList()
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.Content != null)
                    .Where(f => f.Content != string.Empty)
                    .Where(f => f.GroupType != 2)
                    .Where(f => f.Status == 2)
                    .Where(f => f.IsDismiss != 1)
                    .OrderBy(f => f.TopTime, OrderByType.Desc)
                    .OrderBy(it => it.LastMsgTime, OrderByType.Desc)
                    .ToPageList(0, 100);
            }
            return new List<Friend>();
        }

        public List<Friend> GetRecordSortList()
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.Status == 2 && f.IsDismiss != 1 && f.UserType <= FriendType.USER_TYPE_NEW)
                    .OrderBy(f => f.TopTime, OrderByType.Desc)
                    .OrderBy(it => it.LastMsgTime, OrderByType.Desc)
                    .ToList();
            }
            return new List<Friend>();
        }

        /// <summary>
        /// 获取最近群聊列表
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetRecentGroupList()
        {
            if (CreateFriendTable())
            {
                return DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.Content != null && f.Status == 2)
                    .Where(f => f.IsGroup == 1).ToList();
            }
            return new List<Friend>();
        }

        #endregion

        #region 获取好友列表
        /// <summary>
        /// 获取好友列表
        /// <para>status == 2</para>
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetFriendsList()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.Status == 2 && f.IsGroup == this.IsGroup)
                    .OrderBy(f => f.UserType, OrderByType.Desc)
                    .ToList();

                if (result != null && result.Count > 7)
                {
                    result.Sort(6, result.Count - 6, new FriendComparable());
                }
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion


        #region 获取好友列表
        /// <summary>
        /// 获取好友列表
        /// <para>status == 2</para>
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetFriendsByFriendAdapter()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.Status == 2 && f.IsGroup == 0)
                    .Where(f => f.UserType != 2)
                    .OrderBy(f => f.fristAscII, OrderByType.Asc)
                    .ToList();

                //if (result != null && result.Count > 7)
                //{
                //    result.Sort(6, result.Count - 6, new FriendComparable());
                //}
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取好友列表
        /// <summary>
        /// 获取好友列表
        /// <para>status == 2</para>
        /// </summary>
        /// <returns></returns>
        public List<Friend> SearchFriendsByName(string name, int isGroup = 0)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.NickName.Contains(name) || f.RemarkName.Contains(name))
                    .Where(f => f.Status == 2 && f.IsGroup == this.IsGroup)
                    .ToList();

                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取群组列表
        /// <summary>
        /// 获取群组列表
        /// <para>status == 2</para>
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetGroupsList()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                       .Where(f => f.Status == 2 && f.IsGroup == 1 && f.IsDismiss != 1)
                       .ToList();

                if (result != null && result.Count > 0)
                {
                    result.Sort(new FriendComparable());
                }
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取好友或者群组集合
        /// <summary>
        /// 获取好友或者群组集合
        /// </summary>
        /// <param name="isGroup">0为好友，1为群组</param>
        /// <para name="Sort">是否需要通过好友最后一次发送消息事件排序，0否，1是</para>
        /// <returns></returns>
        public List<Friend> GetFriendsByIsGroup(int Sort = 0)
        {
            if (CreateFriendTable())
            {
                if (Sort == 0)
                {
                    var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                        .Where(f => f.Status == 2 && f.IsGroup == IsGroup)
                        .Where(f => !f.UserId.Equals(Friend.ID_SYSTEM))
                        .Where(f => f.UserType <= FriendType.USER_TYPE_NEW)
                        .ToList();

                    return result == null ? new List<Friend>() : result;
                }

                if (Sort == 1)
                {
                    var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                        .Where(f => f.Status == 2 && f.IsGroup == IsGroup)
                        .Where(f => f.UserType <= FriendType.USER_TYPE_NEW)
                        .Where(f => !f.UserId.Equals(Friend.ID_SYSTEM))
                        .OrderBy(f => f.TopTime, OrderByType.Desc)
                        .OrderBy(it => it.LastMsgTime, OrderByType.Desc).ToList();
                    return result == null ? new List<Friend>() : result;
                }
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取好友和群组集合
        /// <summary>
        /// 获取好友和群组集合
        /// <para>好友状态为2</para>
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetAllFriends()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.Status == 2 && f.UserType <= FriendType.USER_TYPE_NEW).ToList();
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取黑名单列表
        /// <summary>
        /// 获取黑名单列表
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetBlacksList()
        {
            //List<Friend> result = (
            //from friend in DBSetting.dbContext.Friends
            //where friend.status == -1
            //select friend
            //).ToList();

            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.Status == -1 && f.IsGroup == this.IsGroup).ToList();
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 检查用户是否在获取黑名单列表
        /// <summary>
        /// 检查用户是否在黑名单列表
        /// </summary>
        /// <returns></returns>
        public int IsBlackUser(string userid)
        {
            //var result = (
            //    from fri in DBSetting.dbContext.Friends
            //    where fri.status == -1 && fri.userId == userid
            //    select fri
            //).FirstOrDefault()
            UpdateAccountId(Applicate.MyAccount.userId);
            UpdateAccountId(userid);

            if (CreateFriendTable())
            {
                //用户存在于好友列表且在黑名单则为1
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.Status == -1 && f.UserId == userid); return result == null ? 0 : result.Count();
            }
            return 0;

        }
        #endregion

        #region 获取黑名单好友
        /// <summary>
        /// 获取黑名单好友
        /// </summary>
        /// <returns></returns>
        public Friend GetBlackUser(string userid)
        {
            //var result = (
            //    from fri in DBSetting.dbContext.Friends
            //    where fri.status == -1 && fri.userId == userid
            //    select fri
            //).FirstOrDefault();

            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.Status == -1 && f.UserId == UserId);
                return result == null ? new Friend() : result;
            }
            return new Friend();
        }
        #endregion

        #region 获取所有用户列表
        /// <summary>
        /// 获取所有用户列表，如果结果为空返回新的实体类
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetAllList()
        {

            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().ToList();
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }


        public List<Friend> QueryFriendAndRoom()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.UserType != FriendType.NEWFRIEND_TYPE)
                    .OrderBy(f => f.TopTime, OrderByType.Desc)
                    .OrderBy(it => it.Content, OrderByType.Desc)
                    .ToList();
                return result;
            }

            return null;
        }

        public bool IsNormalUser()
        {
            return UserType == FriendType.USER_TYPE || UserType == FriendType.USER_TYPE_NEW;
        }

        internal void UpdateCreateTime(double timeSend)
        {
            if (CreateFriendTable())
            {
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                      UpdateColumns(f => new Friend() { CreateTime = Convert.ToInt32(timeSend - 1) }).
                      Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }

        #endregion

        #region 获取所有好友列表
        /// <summary>
        /// 获取所有用户列表，如果结果为空返回新的实体类
        /// </summary>
        /// <returns></returns>
        public List<Friend> GetAllListByGroup(int isgroup)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.IsGroup == isgroup).ToList();
                return result == null ? new List<Friend>() : result;
            }
            return new List<Friend>();
        }
        #endregion

        #region 获取所有好友列表
        /// <summary>
        /// 获取所有用户列表，如果结果为空返回新的实体类
        /// </summary>
        /// <returns></returns>
        public int GetTopFriendCount(int top)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.TopTime > top).ToList();
                return result == null ? 0 : result.Count;
            }

            return 0;
        }
        #endregion

        #region 获取最近消息列表时间排序
        /// <summary>
        /// 获取所有用户列表，如果结果为空返回新的实体类
        /// </summary>
        /// <returns></returns>
        public int GetLastTimeFriendCount(double time)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                    .Where(f => f.LastMsgTime > time || f.TopTime > 0)
                      .Where(f => f.Content != null && f.Status == 2)
                    .ToList();
                return result == null ? -1 : result.Count;
            }

            return -1;
        }
        #endregion

        #region 更新备注
        /// <summary>
        /// 更新好友备注
        /// <para>必须先对userId和remarkName赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="remarkName">新备注名</param>
        /// <returns>受影响行数</returns>
        public int UpdateRemarkName()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend()
                        {
                            RemarkName = this.RemarkName
                        }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion


        #region 更新备注手机号
        /// <summary>
        /// 更新好友备注
        /// <para>必须先对userId和remarkName赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="remarkName">新备注名</param>
        /// <returns>受影响行数</returns>
        public int UpdateRemarkPhone(string phone)
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend()
                        {
                            RemarkPhone = phone
                        }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 1;
        }
        #endregion

        #region 更新描述
        /// <summary>
        /// 更新好友备注
        /// <para>必须先对userId和remarkName赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="remarkName">新备注名</param>
        /// <returns>受影响行数</returns>
        public int UpdateDescription(string desc)
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend()
                        {
                            Description = desc
                        }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 1;
        }
        #endregion

        #region 修改群昵称
        /// <summary>
        /// 修改群昵称
        /// <para>必须先对userId和nickName赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="nickName">新昵称</param>
        /// <returns>受影响行数</returns>
        public int UpdateNickName()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { NickName = this.NickName }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新群邀请验证 

        /// <summary>
        /// 更新群邀请验证
        /// <para>必须先对userId和isNeedVerify赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="isNeedVerify">验证</param>
        /// <returns>受影响行数</returns>
        public int UpdateNeedVerify()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { IsNeedVerify = this.IsNeedVerify }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新清除聊天记录 

        /// <summary>
        /// 更新群邀请验证
        /// <para>必须先对userId和isNeedVerify赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="isNeedVerify">验证</param>
        /// <returns>受影响行数</returns>
        public int UpdateClearMsg()
        {
            if (CreateFriendTable())
            {
                try
                {
                    if (IsGroup == 1)
                    {
                        return DBSetting.SQLiteDBContext.Updateable<Friend>().
                                UpdateColumns(f => new Friend()
                                {
                                    MsgNum = 0,
                                    Content = null,
                                    IsClearMsg = 1,
                                }).
                                Where(f => f.UserId == this.UserId).
                                ExecuteCommand();
                    }
                    else
                    {
                        return DBSetting.SQLiteDBContext.Updateable<Friend>().
                                  UpdateColumns(f => new Friend()
                                  {
                                      MsgNum = 0,
                                      Content = null,
                                      DownloadRoamStartTime = 0,
                                      DownloadRoamEndTime = 0,
                                  }).
                                  Where(f => f.UserId == this.UserId).
                                  ExecuteCommand();
                    }
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新群已读人数

        /// <summary>
        /// 更新群已读人数
        /// <para>必须先对userId和showRead赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="showRead">群已读</param>
        /// <returns>受影响行数</returns>
        public int UpdateShowRead()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { ShowRead = this.ShowRead }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion


        #region 更新群类型

        /// <summary>
        /// 更新群类型
        /// <summary>
        public int UpdateGroupType()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { GroupType = this.GroupType }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新群成员显示

        /// <summary>
        /// 更新群成员显示
        /// <para>必须先对userId和showManber赋值</para>
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="showMember">群成员显示</param>
        /// <returns>受影响行数</returns>
        public int UpdateShowMember(int show)
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { ShowMember = show }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更新群私聊
        public int UpdateAllowSendCard(int allow)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.AllowSendCard = allow;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { AllowSendCard = allow }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        internal void UpdateAccountId(string accountid)
        {
            if (CreateFriendTable())
            {
                DBSetting.SQLiteDBContext.Updateable<Friend>().
                     UpdateColumns(f => new Friend() { AccountId = accountid }).
                     Where(f => f.UserId == this.UserId).ExecuteCommand();
            }
        }


        #region 更新群主开启了普通成员邀请功能
        public int UpdateAllowInviteFriend(int invite)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.AllowInviteFriend = invite;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { AllowInviteFriend = invite }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 普通成员上传群共享
        public int UpdateAllowUploadFile(int invite)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.AllowUploadFile = invite;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { AllowUploadFile = invite }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更改群会议
        public int UpdateAllowConference(int invite)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.AllowConference = invite;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { AllowConference = invite }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 更改群课件
        public int UpdateAllowSpeakCourse(int invite)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.AllowSpeakCourse = invite;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { AllowSpeakCourse = invite }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion


        public int UpdateClearContent()
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.Content = null;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { Content = null }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }

        public int UpdateLastContent(string str, double timeSend)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.Content = str;
                    this.LastMsgTime = timeSend;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { Content = str, LastMsgTime = timeSend }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }


        public int UpdateLastContent(string str, double timeSend, int unredcount)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.Content = str;
                    this.LastMsgTime = timeSend;
                    this.MsgNum = unredcount;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { Content = str, LastMsgTime = timeSend, MsgNum = unredcount }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }

        // 更新未读数量
        public int UpdateRedNum(int num)
        {
            if (CreateFriendTable())
            {
                try
                {
                    this.MsgNum = num;
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend() { MsgNum = num }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }

        public int GetNuRedNum()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Single(f => f.UserId == this.UserId);
                return result == null ? 0 : result.MsgNum;
            }

            return 0;
        }


        public List<Friend> SearchFriendByName(string text)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>()
                            .Where(f => f.NickName.Contains(text) || f.RemarkName.Contains(text))
                            .Where(f => f.Status == 2 && f.UserType <= FriendType.USER_TYPE_NEW)
                            .ToList();
                return result;
            }

            return null;
        }


        public int UpdateDhPublicKey(string publickey)
        {
            if (UIUtils.IsNull(publickey))
            {
                return 0;
            }

            if (CreateFriendTable())
            {
                this.DhPublicKey = publickey;
                return DBSetting.SQLiteDBContext.Updateable<Friend>().
                    UpdateColumns(f => new Friend() { DhPublicKey = publickey }).
                    Where(f => f.UserId == this.UserId).ExecuteCommand();
            }

            return 0;
        }


        public int UpdateRsaPublicKey(string publickey)
        {
            if (CreateFriendTable())
            {
                this.RsaPublicKey = publickey;
                return DBSetting.SQLiteDBContext.Updateable<Friend>().
                    UpdateColumns(f => new Friend() { RsaPublicKey = publickey }).
                    Where(f => f.UserId == this.UserId).ExecuteCommand();
            }

            return 0;
        }

        #region 好友总数
        /// <summary>
        /// 好友总数
        /// </summary>
        /// <returns></returns>
        internal int FriendsCount()
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.IsGroup == 0);
                return result == null ? 0 : result.Count();
            }
            return 0;
        }
        #endregion


        /// <summary>
        /// 数据下载接口 数据转成friend
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public List<Friend> AttentionToFriends(Dictionary<string, object> jsonText)
        {
            List<Friend> listFriend = new List<Friend>();
            JArray friendArray = JArray.Parse(UIUtils.DecodeString(jsonText, "data"));
            foreach (var item in friendArray)
            {
                Friend friend = new Friend()
                {
                    UserId = item["toUserId"].ToString(),
                    LastMsgTime = Convert.ToInt32(item["lastMsgTime"]),
                    MsgNum = Convert.ToInt32(item["msgNum"]),
                    Status = Convert.ToInt32(item["status"]),
                    NickName = UIUtils.DecodeString(item, "toNickname"),
                    CreateTime = Convert.ToInt32(item["createTime"]),
                    RemarkName = item["remarkName"] == null ? "" : item["remarkName"].ToString(),
                    Sex = Convert.ToInt32(item["sex"]),
                    IsOpenReadDel = UIUtils.DecodeInt(item, "isOpenSnapchat"),
                    TopTime = UIUtils.DecodeInt(item, "openTopChatTime"),
                    Nodisturb = UIUtils.DecodeInt(item, "offlineNoPushMsg"),
                };


                friend.RsaPublicKey = UIUtils.DecodeString(item, "rsaMsgPublicKey");
                friend.DhPublicKey = UIUtils.DecodeString(item, "dhMsgPublicKey");
                friend.IsEncrypt = UIUtils.DecodeInt(item, "encryptType");

                friend.TopTime = UIUtils.DecodeInt(item, "openTopChatTime");
                if (friend.TopTime == 1)
                {
                    friend.TopTime = TimeUtils.CurrentIntTime();
                }

                // 公众号 #8134
                if (UIUtils.DecodeInt(item, "toUserType") == 2)
                {
                    friend.UserType = FriendType.PUBLICIZE_TYPE;
                }

                if (ID_SYSTEM.Equals(friend.UserId))
                {
                    friend.UserType = FriendType.PUBLICIZE_TYPE;
                }

                // 我被对方拉黑 isBeenBlack == 1
                if (1 == Convert.ToInt32(item["isBeenBlack"]))
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

                listFriend.Add(friend);

            }

            return listFriend;
        }

        /// <summary>
        /// 群组信息接口数据 转成 friend 
        /// </summary>
        /// <param name="result"></param>
        public void TransToMember(Dictionary<string, object> keyValues)
        {
            //是否显示群已读
            ShowRead = UIUtils.DecodeInt(keyValues, "showRead");
            // 显示群成员
            ShowMember = UIUtils.DecodeInt(keyValues, "showMember");
            // 允许普通群成员私聊
            AllowSendCard = UIUtils.DecodeInt(keyValues, "allowSendCard");
            //允许普通群成员邀请好友
            AllowInviteFriend = UIUtils.DecodeInt(keyValues, "allowInviteFriend");
            //允许普通群成员上传文件
            AllowUploadFile = UIUtils.DecodeInt(keyValues, "allowUploadFile");
            //允许普通群成员召开会议
            AllowConference = UIUtils.DecodeInt(keyValues, "allowConference");
            //允许普通群成员发起讲课
            AllowSpeakCourse = UIUtils.DecodeInt(keyValues, "allowSpeakCourse");
            //是否开启群主验证
            IsNeedVerify = UIUtils.DecodeInt(keyValues, "isNeedVerify");
            // 是否私密群组
            IsSecretGroup = UIUtils.DecodeInt(keyValues, "isSecretGroup");


            // 更新自己在群里面的数据
            string roomByme = UIUtils.DecodeString(keyValues, "member");
            if (!UIUtils.IsNull(roomByme))
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(roomByme);
                RoomMember user = new RoomMember
                {
                    roomId = this.RoomId
                };
                user.UpdateRoomUser(data);

                string enchatkey = UIUtils.DecodeString(data, "chatKeyGroup");
                if (!UIUtils.IsNull(enchatkey))
                {
                    string key = RSA.DecryptFromBase64Pk1(enchatkey, Applicate.MyAccount.rsaPrivateKey);
                    if (!UIUtils.IsNull(key))
                    {
                        // 加密成 chatkeygroup
                        string chatKey = SecureChatUtil.EncryptChatKey(UserId, key, Applicate.API_KEY);
                        ChatKeyGroup = chatKey;
                        IsEncrypt = 3;
                        IsLostKeyGroup = 0;
                    }
                    else
                    {
                        // 密钥丢失
                        ChatKeyGroup = "";
                        IsLostKeyGroup = 1;
                    }
                }

                this.Role = UIUtils.DecodeString(data, "role");
            }
            else
            {
                this.Role = "-1";
            }

            UpdateRoomSetting();

            // 获取禁言状态
            long talkTime = UIUtils.DecodeLong(keyValues, "talkTime");
            talkTime = talkTime > 0 ? 1 : 0;
            LocalDataUtils.SetStringData(UserId + "BANNED_TALK_ALL" + Applicate.MyAccount.userId, talkTime.ToString());

            // 设置群聊消息过期时间
            string outtime = UIUtils.DecodeString(keyValues, "chatRecordTimeOut");
            LocalDataUtils.SetStringData(UserId + "chatRecordTimeOut" + Applicate.MyAccount.userId, outtime);

            //"allowHostUpdate": 1,  // 是否允许群主修改群属性
            //"chatRecordTimeOut":      消息保存天数
            //"createTime": 1554106810, 创建时间
            //"isAttritionNotice": 1,群组减员通知
            //"isLook": 1, // 是否公开群组
            //"modifyTime": 1554116921, // 最后一次发言时间
            //"talkTime": 0, // 禁言时间

            //"videoMeetingNo": "355228" // 群会议地址
            //"call": "305228",// 群会议地址

            //"areaId": 440307,
            //"category": 0,
            //"cityId": 440300,
            //"countryId": 1,
            //"provinceId": 440000,
            //"latitude": 22.608988,
            //"longitude": 114.066209,

            //"s": 1,// 群组状态 -1 锁定 1 正常

            //"name": "飞飞",
            //"desc": "1",
            //"subject": "",

            //"userSize": 6,
            //"maxUserSize": 1000,

            //"nickname": "2007",
            //"userId": 10009572,

            //"id": "5ca1c9b90c03d0640281ad58",
            //"jid": "d0495fea6ce34adea87a0fe8764bdd24",




            // 更新管理员和群主在群里界面的数据
            string admins = UIUtils.DecodeString(keyValues, "members");
            if (!UIUtils.IsNull(admins))
            {
                var mems = JsonConvert.DeserializeObject<List<object>>(admins);
                foreach (var item in mems)
                {
                    var mem = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ObjToString());
                    RoomMember member = new RoomMember
                    {
                        roomId = this.RoomId
                    };
                    member.UpdateRoomUser(mem);
                }
            }

            //"notice": {
            //"id": "5ca495d60c03d02d76821ad1",
            //"nickname": "2007",
            //"roomId": "5ca1c9b90c03d0640281ad58",
            //"text": "11111",
            //"time": 1554290134,
            //"userId": 10009572
            //},

            string notice = UIUtils.DecodeString(keyValues, "notice");
            if (!UIUtils.IsNull(notice))
            {
                var noticeData = JsonConvert.DeserializeObject<Dictionary<string, object>>(notice);
                int time = UIUtils.DecodeInt(noticeData, "time");
                if (TimeUtils.CurrentTime() - time < 60 * 60 * 24 * 15)
                {
                    LocalDataUtils.SetBoolData(UserId + "show_notice", true);
                }
            }

            //"member": {
            //"active": 1554106810,
            //"call": "305228",
            //"createTime": 1554106810,
            //"modifyTime": 0,
            //"nickname": "2007",
            //"offlineNoPushMsg": 0,
            //"role": 1,
            //"sub": 1,
            //"talkTime": 0,
            //"userId": 10009572,
            //"videoMeetingNo": "355228"
            //},

            //"members": [
            //{
            //"active": 1554106810,
            //"call": "305228",
            //"createTime": 1554106810,
            //"modifyTime": 0,
            //"nickname": "2007",
            //"offlineNoPushMsg": 0,
            //"role": 1,
            //"sub": 1,
            //"talkTime": 0,
            //"userId": 10009572,
            //"videoMeetingNo": "355228"
            //}
            //],

            //"notice": {
            //"id": "5ca495d60c03d02d76821ad1",
            //"nickname": "2007",
            //"roomId": "5ca1c9b90c03d0640281ad58",
            //"text": "11111",
            //"time": 1554290134,
            //"userId": 10009572
            //},
        }

        public int UpdateRoomInfo()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend()
                        {
                            ShowRead = this.ShowRead,
                            ShowMember = this.ShowMember,
                            AllowSendCard = this.AllowSendCard,
                            AllowInviteFriend = this.AllowInviteFriend,
                            AllowUploadFile = this.AllowUploadFile,
                            AllowConference = this.AllowConference,
                            AllowSpeakCourse = this.AllowSpeakCourse,
                            IsNeedVerify = this.IsNeedVerify,
                            ChatKeyGroup = this.ChatKeyGroup,
                            IsEncrypt = this.IsEncrypt
                        }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }


        #region 更改群设置
        private int UpdateRoomSetting()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Updateable<Friend>().
                        UpdateColumns(f => new Friend()
                        {
                            ShowRead = this.ShowRead,
                            ShowMember = this.ShowMember,
                            AllowSendCard = this.AllowSendCard,
                            AllowInviteFriend = this.AllowInviteFriend,
                            AllowUploadFile = this.AllowUploadFile,
                            AllowConference = this.AllowConference,
                            AllowSpeakCourse = this.AllowSpeakCourse,
                            IsNeedVerify = this.IsNeedVerify,
                            TopTime = this.TopTime,
                            ChatKeyGroup = this.ChatKeyGroup,
                            IsLostKeyGroup = this.IsLostKeyGroup,
                            IsOpenReadDel = this.IsOpenReadDel,
                            Nodisturb = this.Nodisturb
                        }).
                        Where(f => f.UserId == this.UserId).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 判断本地是否存在好友

        public bool IsExistFriend(bool isGroup)
        {
            if (CreateFriendTable())
            {
                try
                {
                    if (isGroup)
                    {
                        var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.IsGroup == 1).ToList();
                        return !UIUtils.IsNull(result);
                    }
                    else
                    {
                        var result = DBSetting.SQLiteDBContext.Queryable<Friend>().Where(f => f.IsGroup != 1).ToList();
                        return !UIUtils.IsNull(result);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public int RemoveAllFriend()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Deleteable<Friend>().Where(f => f.IsGroup != 1).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }

        public int RemoveAllGroup()
        {
            if (CreateFriendTable())
            {
                try
                {
                    return DBSetting.SQLiteDBContext.Deleteable<Friend>().Where(f => f.IsGroup == 1).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    ConsoleLog.Output(ex.Message);
                }
            }
            return 0;
        }
        #endregion

        #region 修改状态为已解散
        /// <summary>
        /// 更新群组状态
        /// 1解散  2锁定 0正常
        /// </summary>
        public int UpdateDismiss(int type)
        {
            if (CreateFriendTable())
            {
                var result = DBSetting.SQLiteDBContext.Updateable<Friend>().UpdateColumns(f => new Friend { IsDismiss = type }).
                    Where(f => f.UserId == this.UserId).ExecuteCommand();
                return result;
            }

            return 0;
        }

        // 是否是用户
        internal bool IsDevice()
        {
            return UserType == FriendType.DEVICE_TYPE;
        }
        #endregion
    }
    #endregion


    public class FriendType
    {
        // 用户好友
        public const int USER_TYPE = 0;
        // 用户好友
        public const int USER_TYPE_NEW = 1;
        // 公众号 
        public const int PUBLICIZE_TYPE = 2;
        // 我的设备
        public const int DEVICE_TYPE = 3;
        // 黑名单和新的朋友
        public const int NEWFRIEND_TYPE = 4;
    }
}
