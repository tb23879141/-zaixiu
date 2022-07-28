using Newtonsoft.Json;
using System.Collections.Generic;
using WinFrmTalk.Controls.LayouotControl.Items;

namespace WinFrmTalk.Model
{
    /// <summary>
    /// liuhuan 2019/4/1
    /// </summary>
    public class GroupNotices
    {
        //id
        public string Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// roomid
        /// </summary>
        public string Roomid { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string text { get; set; }
        /// <summary>
        ///userid
        /// </summary>
        public string Userid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Time { get; set; }

    }



    public class GroupResource
    {
        /// <summary>
        /// 
        /// </summary>
        public long length { get; set; }

        /// <summary>
        /// 4.30课件.pdf
        /// </summary>
        public string oFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string oUrl { get; set; }

        public string tUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size { get; set; }
    }



    public class GroupFilesx
    {
        /// <summary>
        /// 
        /// </summary>
        public string shareId { get; set; }
        public string nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GroupResource resource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long time { get; set; }

        /// <summary>
        /// 打工皇帝都很喜欢喜欢吃
        /// </summary>
        public string title { get; set; }

        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int isMemberDownload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isPublic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isWatchDownload { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public string emojiId { get; set; }

        /// <summary>
        /// 5 == 公告    4==活动   0==消息
        /// </summary>
        public int collectType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long createTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        public string fileName { get; set; }
        public string collectSource { get; set; }
        public string collectContent { get; set; }
        public string shareURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float fileSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                return UIUtils.IsNull(fileName) ? msg : fileName;
            }
        }

        internal string toJsonString(ResourcexType resType)
        {
            switch (resType)
            {
                case ResourcexType.notify:
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("title", title);
                    dict.Add("text", msg);
                    dict.Add("shareURL", shareURL);
                    return JsonConvert.SerializeObject(dict);
                case ResourcexType.active:
                case ResourcexType.social:
                case ResourcexType.res:
                    return this.collectContent;
                default:
                    return this.msg;
            }
        }


        internal kWCMessageType toMessageType(ResourcexType resType)
        {
            switch (resType)
            {
                case ResourcexType.notify:
                    return kWCMessageType.ResouresNotify;
                case ResourcexType.active:
                    return kWCMessageType.ResouresActive;
                case ResourcexType.social:
                    return kWCMessageType.ResouresSocial;
                case ResourcexType.res:
                    return kWCMessageType.ResouresResoures;
                default:
                    return kWCMessageType.Text;
            }
        }
    }


    public class Collections
    {
        public List<GroupShareListItem> groupShareList { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long createTime { get; set; }
        /// <summary>
        /// 收集类型
        /// </summary>
        public int collectType { get; set; }
        /// <summary>
        /// jid
        /// </summary>
        public string emojiId { get; set; }
        /// <summary>
        /// 文件长度
        /// </summary>
        public string fileLength { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long fileSize { get; set; }
        /// <summary>
        /// msg
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// messageid
        /// </summary>
        public string msgId { get; set; }
        /// <summary>
        /// roomjid
        /// </summary>
        public string roomJid { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// userid
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public string url { set; get; }
        public string collectContent { set; get; }
        public string Filename { set; get; }
        public string nickname { set; get; }
        public string act_address { set; get; }
        public long act_charge { set; get; }
        public string act_cover { set; get; }
        public long act_endTime { set; get; }
    }


    public class ColleaguesList
    {
        public ColleaguesList()
        {
            data = new List<MyColleagues>();
        }

        public List<MyColleagues> data { get; set; }
    }

    public class MyColleagues
    {
        /// <summary>
        /// 消息id
        /// </summary>
        public object messageIds { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string courseName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 课程id
        /// </summary>
        public string courseId { get; set; }

    }



    public class CollectionSave
    {
        public string collectContent { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string emojiId { get; set; }

        /// <summary>
        /// 5 == 公告    4==活动   0==消息
        /// </summary>
        public int collectType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long createTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float fileSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public long time { get; set; }

        /// <summary>
        /// 咕咕咕
        /// </summary>
        public string fileName { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public string msgId { get; set; }





        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string shareURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string collectSource { get; set; }



        internal string toJsonString(ResourcexType resType)
        {
            switch (resType)
            {
                case ResourcexType.notify:
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("title", title);
                    dict.Add("text", msg);
                    dict.Add("shareURL", shareURL);
                    return JsonConvert.SerializeObject(dict);
                case ResourcexType.active:
                case ResourcexType.social:
                case ResourcexType.res:
                    return this.collectContent;
                default:
                    return this.msg;
            }
            return "";
        }



        internal kWCMessageType toMessageType(ResourcexType resType)
        {
            switch (resType)
            {
                case ResourcexType.notify:
                    return kWCMessageType.ResouresNotify;
                case ResourcexType.active:
                    return kWCMessageType.ResouresActive;
                case ResourcexType.social:
                    return kWCMessageType.ResouresSocial;
                case ResourcexType.res:
                    return kWCMessageType.ResouresResoures;
                default:
                    return kWCMessageType.Text;
            }
        }
    }

    public class PictureFloderRoot
    {
        public List<PictureFloder> pictureList;
    }

    public class PictureFloder
    {

        /// <summary>
        /// 
        /// </summary>
        public string folderId { get; set; }

        /// <summary>
        /// 好。好防城港
        /// </summary>
        public string folderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<CollectionSave> groupShareList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int newAddNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int updateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int isMemberDownload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isPublic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int isWatchDownload { get; set; }
    }

    public class GroupTyteData
    {
        /// <summary>
        /// 
        /// </summary>
        public string englishName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 生活
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SubclassListItem> subclassList { get; set; }
    }

    public class SubclassListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }

        /// <summary>
        /// 休闲
        /// </summary>
        public string cname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string englishName { get; set; }

        /// <summary>
        /// 生活-休闲
        /// </summary>
        public string fullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string parentId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string parentName { get; set; }

    }

    public class Gift
    {
        /// <summary>
        /// 
        /// </summary>
        public string giftId { get; set; }
        /// <summary>
        /// 鲜花
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string photo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }
    public class Redpackges
    {
        /// <summary>
        ///红包的数量
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 提示语
        /// </summary>
        public string greetings { get; set; }
        /// <summary>
        /// 红包id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string money { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string outTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string over { get; set; }
        /// <summary>
        /// 已经领取的个数
        /// </summary>
        public string receiveCount { get; set; }
        /// <summary>
        /// roomjid
        /// </summary>
        public string roomJid { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string sendTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        public string toUserId { get; set; }
        /// <summary>
        /// 红包类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 领取人的userid集合
        /// </summary>
        public List<string> userIds
        {
            get; set;
        }
        /// <summary>
        /// 发红包人的昵称
        /// </summary>
        public string userName { get; set; }

    }
    /// <summary>
    /// 红包领取人的信息
    /// </summary>
    public class Receivers
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string money { get; set; }
        /// <summary>
        /// 红包id
        /// </summary>
        public string redId { get; set; }
        /// <summary>
        /// 发送者名称
        /// </summary>
        public string sendName { get; set; }
        /// <summary>
        /// 领取时间
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 领取人userid
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// 领取人名称
        /// </summary>
        public string userName { get; set; }
        public string reply { get; set; }
    }

    public class TransferInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double money { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int outTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int receiptTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int toUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 美团外卖
        /// </summary>
        public string userName { get; set; }
    }
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int currentTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Gift> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int resultCode { get; set; }
    }
    public class LiveMember
    {
        /// <summary>
        /// 
        /// </summary>
        public int createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int online { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roomId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
    }

    public class LiveMemberTime
    {
        /// <summary>
        /// 
        /// </summary>
        public int currentTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LiveMember> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int resultCode { get; set; }
    }


    public class HaveReceived
    {
        public string id { get; set; }
        public string transferid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double money { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Time { get; set; }
        public int createTime { get; set; }
        public int receiptTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sendId { get; set; }
        /// <summary>
        /// 美团外卖
        /// </summary>
        public string sendName { get; set; }
        public string userName { get; set; }
    }

    public class HaveReceivedRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public int currentTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HaveReceived data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int resultCode { get; set; }
        /// <summary>
        /// 该转账已完成或退款
        /// </summary>
        public string resultMsg { get; set; }
    }
}