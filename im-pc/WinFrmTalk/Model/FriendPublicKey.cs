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
    /// 好友公钥表
    /// 2019-4-23 17:33:50
    /// </summary>
    public class FriendPublicKey
    {
        /// <summary>
        /// 主键自增长
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int keyId { get; set; }

        /// <summary>
        /// 好友id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string userId { get; set; }

        /// <summary>
        /// 当前登录id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string ownerId { get; set; }

        /// <summary>
        /// 好友公钥
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string publicKey { get; set; }

        /// <summary>
        /// 公钥创建时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public long createTime { get; set; }


        public FriendPublicKey()
        {
            ownerId = Applicate.MyAccount.userId;
        }
    }
}
