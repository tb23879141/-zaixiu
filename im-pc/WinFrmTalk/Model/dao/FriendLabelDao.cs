using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Model.dao
{
    /// <summary>
    /// 好友标签表数据库访问类
    /// </summary>
    public class FriendLabelDao
    {
        private FriendLabelDao()
        {
        }

        private static FriendLabelDao _instance;
        public static FriendLabelDao Instance => _instance ?? (_instance = new FriendLabelDao());

        #region 创建数据库表
        /// <summary>
        /// 创建数据库表
        /// </summary>
        private bool CreateLabelTable()
        {
            try
            {
                var db = DBSetting.SQLiteDBContext;
                var result = db.Queryable<sqlite_master>().Where(s => s.Name == "FriendLabel" && s.Type == "table");
                if (result != null && result.Count() > 0)     //表存在
                {
                    return true;
                }
                //创建数据库表
                db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(FriendLabel));
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Log(ex.Message);
                return false;
            }
        }
        #endregion

        #region 添加方法集合
        // 批量添加
        public void AddFriendLabels(List<FriendLabel> labels)
        {
            if (UIUtils.IsNull(labels))
            {
                return;
            }

            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Insertable(labels).ExecuteCommand();
            }
        }

        public int AddFriendLabel(FriendLabel label)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Insertable(label).ExecuteCommand();
                return result;
            }
            return 0;
        }


        #endregion

        #region 查询标签方法集合
        /// <summary>
        /// 查询当前登录账号所有的好友标签
        /// </summary>
        public List<FriendLabel> GetAllFriendLabel()
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendLabel>().ToList();
                return result;
            }

            return null;
        }

        /// <summary>
        /// 根据好友ID查询所有包含此好友的标签
        /// </summary>
        public List<FriendLabel> GetFriendLabelByUserId(string freindId)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendLabel>()
                    .Where(f => f.userIdList.Contains(freindId))
                    .ToList();
                return result;
            }
            return null;
        }


        /// <summary>
        /// 根据标签ID查询某条标签
        /// </summary>
        public FriendLabel GetFriendLabelById(string groupId)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendLabel>()
                    .Where(f => f.groupId == groupId)
                    .Single();

                return result;
            }

            return null;
        }


        #endregion

        #region 修改方法集合
        /// <summary>
        /// 修改某个标签下的好友列表
        /// </summary>
        public bool UpdateFriendIdListById(string groupId, string friends)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Updateable<FriendLabel>()
                      .UpdateColumns(it => new FriendLabel() { userIdList = friends })
                      .Where(it => it.groupId == groupId)
                      .ExecuteCommand();

                return result > 0;
            }

            return false;
        }

        /// <summary>
        /// 修改标签名称
        /// </summary>
        public bool UpdateLabelNameById(string groupId, string name)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Updateable<FriendLabel>()
                      .UpdateColumns(it => new FriendLabel() { groupName = name })
                      .Where(it => it.groupId == groupId)
                      .ExecuteCommand();

                return result > 0;
            }

            return false;
        }
        #endregion

        #region 删除所有标签
        /// <summary>
        /// 删除所有标签
        /// </summary>
        public void DeleteAllLabel()
        {
            if (CreateLabelTable())
            {
                DBSetting.SQLiteDBContext.Deleteable<FriendLabel>().ExecuteCommand();
            }
        }

        /// <summary>
        /// 删除所有标签
        /// </summary>
        public void DeleteLabelById(string groupId)
        {
            if (CreateLabelTable())
            {
                DBSetting.SQLiteDBContext.Deleteable<FriendLabel>()
                    .Where(f => f.groupId == groupId)
                    .ExecuteCommand();
            }
        }
        #endregion


        #region 下载好友标签到数据库
        public void UpdateLableByHttp(Action binding)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "friendGroup/list")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((sus, data) =>
                {
                    if (sus)
                    {
                        DeleteAllLabel();

                        JArray arrlist = JArray.Parse(UIUtils.DecodeString(data, "data"));
                        var lableList = new List<FriendLabel>();
                        foreach (var arr in arrlist)
                        {
                            FriendLabel label = new FriendLabel()
                            {
                                groupId = UIUtils.DecodeString(arr, "groupId"),
                                groupName = UIUtils.DecodeString(arr, "groupName"),
                                userId = UIUtils.DecodeString(arr, "userId"),
                                userIdList = UIUtils.DecodeString(arr, "userIdList")
                            };

                            lableList.Add(label);
                        }

                        // 批量插入到数据库
                        AddFriendLabels(lableList);
                    }

                    binding?.Invoke();
                });
        }

        #endregion
    }
}
