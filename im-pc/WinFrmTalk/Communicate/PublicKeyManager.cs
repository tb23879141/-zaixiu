using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFrmTalk.Model;
using WinFrmTalk.Model.dao;

namespace WinFrmTalk.Communicate
{
    class PublicKeyManager
    {

        static Dictionary<string, string> cachekeys = new Dictionary<string, string>();

        // 单例模式
        private PublicKeyManager()
        {

        }

        private static PublicKeyManager _instance;
        public static PublicKeyManager Instance => _instance ?? (_instance = new PublicKeyManager());


        public string GetFriendLastPublicKey(string userId, int isGroup)
        {
            if (cachekeys.ContainsKey(userId))
            {
                return cachekeys[userId];
            }
            else
            {
                var friend = new Friend() { UserId = userId, IsGroup = isGroup }.GetByUserId();

                //if (!friend.IsEnableSecure)
                //{
                //    return string.Empty;
                //}

                if (!UIUtils.IsNull(friend.DhPublicKey))
                {
                    cachekeys.Add(userId, friend.DhPublicKey);
                    return friend.DhPublicKey;
                }

                var publickey = FriendPublicKeyDao.Instance.GetLastPublicKey(Applicate.MyAccount.userId, userId);

                if (publickey != null)
                {
                    cachekeys.Add(userId, publickey.publicKey);
                    return publickey.publicKey;
                }

                return string.Empty;
            }
        }
    }
}
