using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SkSSLUtils;

namespace WinFrmTalk.Model.dao
{
    class FriendPublicKeyDao
    {
        const string TabName = "FriendPublicKey";

        private FriendPublicKeyDao()
        {
        }
        private static FriendPublicKeyDao _instance;
        public static FriendPublicKeyDao Instance => _instance ?? (_instance = new FriendPublicKeyDao());




        #region 创建数据库表
        /// <summary>
        /// 创建数据库表
        /// </summary>
        private bool CreateLabelTable()
        {
            try
            {
                var db = DBSetting.SQLiteDBContext;
                var result = db.Queryable<sqlite_master>().Where(s => s.Name == TabName && s.Type == "table");
                if (result != null && result.Count() > 0)     //表存在
                {
                    return true;
                }
                //创建数据库表
                db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(FriendPublicKey));
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Log(ex.Message);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 插入一个好友公钥
        /// </summary>
        /// <param name="friendPublicKey"></param>
        /// <returns></returns>
        public bool InsertPublicKey(FriendPublicKey friendPublicKey)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendPublicKey>()
                    .Where(f => f.ownerId.Equals(friendPublicKey.ownerId))
                    .Where(f => f.userId.Equals(friendPublicKey.userId))
                    .Where(f => f.publicKey.Equals(friendPublicKey.publicKey))
                    .Single();

                if (result == null)
                {
                    var line = DBSetting.SQLiteDBContext.Insertable(friendPublicKey).ExecuteCommand();
                    return line == 1;
                }
                else
                {
                    Console.WriteLine("已存在key " + friendPublicKey.publicKey);
                }
            }
            return false;
        }


        /// <summary>
        /// 获取所有好友公钥
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<FriendPublicKey> GetAllPublicKeys(string ownerId, string userId)
        {

            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendPublicKey>()
                    .Where(f => f.ownerId.Equals(ownerId))
                    .Where(f => f.userId.Equals(userId))
                    .ToList();

                return result;
            }

            return null;
        }

        internal FriendPublicKey GetLastPublicKey(string ownerId, string userId)
        {
            if (CreateLabelTable())
            {
                var result = DBSetting.SQLiteDBContext.Queryable<FriendPublicKey>()
                   .Where(f => f.ownerId.Equals(ownerId))
                    .Where(f => f.userId.Equals(userId))
                    .OrderBy(m => m.createTime, OrderByType.Desc).First();

                return result;
            }

            return null;
        }


        internal void RefreshPublicKeyList(List<FriendPublicKey> list)
        {

        }

        public void UpdateLastPublicKey(FriendPublicKey key)
        {

            key.createTime = TimeUtils.CurrentTimeMillis();

            var last = GetLastPublicKey(key.ownerId, key.userId);

            if (last != null && last.Equals(key.publicKey))
            {
                var line = DBSetting.SQLiteDBContext.Updateable<FriendPublicKey>()
                       .UpdateColumns(it => new FriendPublicKey() { createTime = key.createTime })
                       .Where(it => it.keyId == last.keyId)

                       .ExecuteCommand();
            }
            else
            {
                var line = DBSetting.SQLiteDBContext.Insertable(key).ExecuteCommand();
            }
        }

        // 更新所有公钥列表，并返回最后一条公钥
        internal string UpdateAllPublicKey(List<KeyBen> keylist, string userid)
        {
            if (keylist == null || keylist.Count == 0)
            {
                return "";
            }

            if (CreateLabelTable())
            {
                // 全部删除
                //var line = DBSetting.SQLiteDBContext.Deleteable<FriendPublicKey>()
                //    .Where(f => f.ownerId.Equals(Applicate.MyAccount.userId))
                //    .Where(f => f.userId.Equals(userid))
                //    .ExecuteCommand();

                // 重新插入
                long time = keylist[0].time;
                string key = "";
                foreach (var item in keylist)
                {
                    var publiekey = new FriendPublicKey()
                    {
                        ownerId = Applicate.MyAccount.userId,
                        publicKey = item.key,
                        userId = userid,
                        createTime = item.time,
                    };

                    if (time < item.time)
                    {
                        time = item.time;
                        key = item.key;
                    }

                    InsertPublicKey(publiekey);
                }

                return key;
            }

            return "";
        }
    }
}
