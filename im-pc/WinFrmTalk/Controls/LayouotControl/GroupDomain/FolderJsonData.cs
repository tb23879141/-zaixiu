using Newtonsoft.Json;
using System.Collections.Generic;
using WinFrmTalk.Controls.LayouotControl.Groups;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.GroupDomain
{

    public class HttpFolderData
    {
        /// <summary>
        /// 0==公开
        /// </summary>
        public int isPublic { get; set; }

        public string folderId { get; set; }
        public string folderName { get; set; }


        public string roomId { get; set; }
        public string userId { get; set; }

        /// <summary>
        /// 数据类型
        /// 1群文件 2群视频 3群图片 4：公告 5：活动
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public long updateTime { get; set; }


        [JsonIgnore]
        public GroupTabIndex tabIndex { get; set; }

        /// <summary>
        /// 是否子文件夹
        /// </summary>
        [JsonIgnore]
        public bool SubFolder { get; set; }


        /// <summary>
        /// 子文件夹
        /// </summary>
        public List<HttpFolderData> groupAlbumList { get; set; }
        /// <summary>
        /// 子文件夹
        /// </summary>
        public List<HttpFolderData> groupUserAlbumList { get; set; }


        /// <summary>
        /// 公告数据
        /// </summary>
        public List<MyGroupNotice> noticeList { get; set; }

        /// <summary>
        /// 活动数据
        /// </summary>
        public List<MyGroupActivity> activityList { get; set; }

        /// <summary>
        /// 文件数据
        /// </summary>
        public List<GroupFilesx> groupShareList { get; set; }

        [JsonIgnore]
        public int Count
        {
            get
            {
                if (type == 5)
                {
                    return activityList == null ? 0 : activityList.Count;
                }
                else if (type == 4)
                {
                    return noticeList == null ? 0 : noticeList.Count;
                }
                else
                {
                    return groupShareList == null ? 0 : groupShareList.Count;
                }

            }
        }

        [JsonIgnore]
        public int SubCount
        {
            get
            {
                return SubFolderList == null ? 0 : SubFolderList.Count;
            }
        }

        [JsonIgnore]
        public List<HttpFolderData> SubFolderList
        {
            get
            {
                List<HttpFolderData> list = groupUserAlbumList == null ? groupAlbumList : groupUserAlbumList;
                return list;
            }
        }

        /// <summary>
        /// 相册封片图
        /// </summary>
        [JsonIgnore]
        public string PictureCover
        {
            get
            {
                if (!UIUtils.IsNull(groupShareList))
                {
                    return groupShareList[0].url;
                }
                else
                {
                    return "";
                }
            }
        }
    }

}
