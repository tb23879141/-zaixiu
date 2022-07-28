using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Model
{
    public class emoji
    {
        /// <summary>
        /// 数据库预留（自增长主键id修改数据类型int）
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// emoji图片名
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 254)]
        public string filename { get; set; }


        /// <summary>
        /// emoji图片英文名称
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 254)]
        public string english { get; set; }

        /// <summary>
        /// emoji图片中文名称
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 254)]
        public string chinese { get; set; }

        [SugarColumn(IsNullable = true, Length = 254)]
        public string big5 { get; set; }

        [SugarColumn(IsNullable = true)]
        public int sort { get; set; }


        #region 创建表
        /// <summary>
        /// 创建表
        /// </summary>
        public bool CreatEmojiTable()
        {
            using (var db = DBSetting.ConstantDBContext)
            {
                //创建数据库表
                try
                {
                    if (!db.Queryable<sqlite_master>().Where(s => s.Name == "emoji" && s.Type == "table").Any())
                    {
                        db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(emoji));
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        public emoji GetEmojiByName()
        {
            if (CreatEmojiTable())
            {
                using (var db = DBSetting.ConstantDBContext)
                {
                    var result = db.Queryable<emoji>().Single(e => e.english == english);
                    return result == null ? this : result;
                }
            }
            return this;
        }
    }
}
