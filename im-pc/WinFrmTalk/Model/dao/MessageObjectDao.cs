using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Model.dao
{
    public class MessageObjectDao
    {

        private Dictionary<string, bool> mCreateTable;
        private static readonly MessageObjectDao instance = new MessageObjectDao();

        /// <summary>
        /// 显式的静态构造函数用来告诉C#编译器在其内容实例化之前不要标记其类型
        /// </summary>
        static MessageObjectDao() { }

        private MessageObjectDao()
        {
            mCreateTable = new Dictionary<string, bool>();
        }

        public static MessageObjectDao Instance
        {
            get
            {
                return instance;
            }
        }



        #region 创建表
        /// <summary>
        /// 创建表
        /// </summary>
        public bool CreatMessageTable(string tableName)
        {

            if ("msg_Null".Equals(tableName))
            {
                return false;
            }

            if (mCreateTable.ContainsKey(tableName))
            {
                return true;
            }

            var db = DBSetting.SQLiteDBContext;
            db.MappingTables.Add("MessageObject", tableName);

            //创建数据库表
            try
            {
                var result = db.Queryable<sqlite_master>().Where(s => SqlFunc.Equals(s.Name, tableName) && SqlFunc.Equals(s.Type, "table"));
                if (result != null && result.Count() < 1)
                {
                    db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(MessageObject));
                }

                mCreateTable.Add(tableName, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsTableExists(string tableName)
        {
            if ("msg_Null".Equals(tableName))
            {
                return false;
            }

            if (mCreateTable.ContainsKey(tableName))
            {
                return true;
            }

            var db = DBSetting.SQLiteDBContext;
            db.MappingTables.Add("MessageObject", tableName);

            //创建数据库表
            try
            {
                var result = db.Queryable<sqlite_master>().Where(s => SqlFunc.Equals(s.Name, tableName) && SqlFunc.Equals(s.Type, "table"));
                return result != null && result.Count() > 0; ;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion




        #region 搜索消息文字内容
        /// <summary>
        /// 分页获取数据列表（模糊查询）
        /// <para>按时间降序排序</para>
        /// </summary>
        /// <param name="type">获取对应类型的消息(小于零时获取全部)</param>
        /// <param name="PageIndex">第几页（0和1都是第一页）</param>
        /// <param name="PageSize">一页多少行消息（同一功能调用该方法请固定使用一个值）</param>
        /// <param name="content">消息内容</param>
        /// <returns></returns>
        public List<MessageObject> GetTextContentList(string content, string friendUserId)
        {
            string tabName = MessageObject.Prefex + friendUserId;

            if (IsTableExists(tabName))
            {
                var list = DBSetting.SQLiteDBContext.Queryable<MessageObject>().AS(tabName)
                     .Where(m => m.type == kWCMessageType.Text)
                     .Where(m => m.content.Contains(content))
                     .OrderBy(it => it.timeSend, OrderByType.Desc)
                     .ToPageList(1, 20);

                return list;
            }

            return null;
        }
        #endregion

    }



}
