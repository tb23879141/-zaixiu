using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFrmTalk.Model;

namespace WinFrmTalk
{
    /// <summary>
    /// 好友标签表
    /// 2019-4-23 17:33:50
    /// </summary>
    public class FriendLabel
    {

        /// <summary>
        /// 标签id
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, Length = 128)]
        public string groupId { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string groupName { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string userId { get; set; }

        /// <summary>
        /// 标签好友集
        /// </summary>

        [SugarColumn(IsNullable = true)]
        [JsonIgnore]
        public string userIdList { get; set; }

        public FriendLabel()
        {

        }

        // josn 解析
        public FriendLabel(Dictionary<string, object> jsonData)
        {
            this.groupId = UIUtils.DecodeString(jsonData, "groupId");
            this.userId = UIUtils.DecodeString(jsonData, "userId");
            this.groupName = UIUtils.DecodeString(jsonData, "groupName");
            this.userIdList = UIUtils.DecodeString(jsonData, "userIdList");
        }

        // 获取标签下好友数量
        public int GetFriendCount()
        {
            if (userIdList == null || userIdList.Length < 2)
            {
                return 0;
            }

            JArray array = JArray.Parse(userIdList);
            return array.Count;
        }

        // 获取标签下好友列表
        public List<Friend> GetFriendList()
        {
            if (userIdList == null || userIdList.Length < 2)
            {
                return null;
            }

            JArray array = JArray.Parse(userIdList);

            List<Friend> friendlst = new List<Friend>();
            for (int i = 0; i < array.Count; i++)
            {
                string userid = array[i].ToString();
                Friend friend = new Friend() { UserId = userid }.GetByUserId();
                friendlst.Add(friend);
            }

            return friendlst;
        }


    }
}
