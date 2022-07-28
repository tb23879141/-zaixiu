using SqlSugar;
using System;

namespace WinFrmTalk.Model.dao
{
    internal class FriendDao
    {

        #region 单例模式

        private static readonly FriendDao instance = new FriendDao();
        private bool TableExists;

        /// <summary>
        /// 显式的静态构造函数用来告诉C#编译器在其内容实例化之前不要标记其类型
        /// </summary>
        static FriendDao() { }

        private FriendDao() { }

        public static FriendDao Instance
        {
            get
            {
                return instance;
            }
        }

        internal bool CreateTable()
        {
            if (TableExists)
            {
                return true;
            }

            try
            {
                var result = DBSetting.SQLiteDBContext.Queryable<sqlite_master>().Where(s => SqlFunc.Equals(s.Name, "Friend") && SqlFunc.Equals(s.Type, "table"));

                //不存在表
                if (result == null || result.Count() == 0)
                {
                    //创建数据库表
                    DBSetting.SQLiteDBContext.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(Friend));
                }

                TableExists = true;
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Log(ex.Message);
                TableExists = false;
                return false;
            }
        }

        internal Friend GetFriendByRoomId(string roomId)
        {
            return new Friend().GetFriendByRoomId(roomId);
        }

        #endregion
    }
}
