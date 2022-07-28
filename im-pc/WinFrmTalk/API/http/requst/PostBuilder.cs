using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WinFrmTalk.Helper.http.requst
{
    class PostBuilder
    {
        private Dictionary<string, string> hashMap;
        protected bool noTip;
        protected Action<int, string> mErrListener;

        protected string RequstParam { get; set; }

        protected string RequstUrl { get; set; }
        /// <summary>
        /// 请求url
        /// </summary>
        public PostBuilder Url(string url)
        {
            RequstUrl = url;
            return this;
        }

        /// <summary>
        /// 请求参数 依次拼接
        /// </summary>
        public PostBuilder AddParams(string key, string value)
        {
            if (hashMap == null)
            {
                hashMap = new Dictionary<string, string>();
            }

            hashMap.Add(key, value);

            return this;
        }

        /// <summary>
        /// 请求参数
        /// </summary>
        public PostBuilder AddParams(Dictionary<string, string> pari)
        {
            if (pari == null)
            {
                return this;
            }

            if (hashMap == null)
            {
                hashMap = pari;
            }
            else
            {
                foreach (var item in pari)
                {

                    if (hashMap.ContainsKey(item.Key))
                    {
                        hashMap[item.Key] = item.Value;
                    }
                    else
                    {
                        hashMap.Add(item.Key, item.Value);
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// 编译
        /// </summary>
        /// <param name="beforeLogin">是否登陆前接口,用于接口加密</param>
        /// <returns></returns>
        public PostCall Build(bool beforeLogin = false)
        {
            // 接口加密系统
            HttpEncrypt(beforeLogin);

            string rParams = AppendParams();
            PostCall call = new PostCall(RequstUrl, rParams);
            call.AddErrorListener(mErrListener);
            call.NoErrorTip(noTip);
            return call;
        }


        public PostBuilder NoErrorTip()
        {
            noTip = true;
            return this;
        }

        public PostBuilder AddErrorListener(Action<int, string> callback)
        {
            mErrListener = callback;
            return this;
        }

        /// <summary>
        /// 参数拼接
        /// </summary>
        private string AppendParams()
        {
            StringBuilder sb = new StringBuilder();
            if (!UIUtils.IsNull(hashMap))
            {
                foreach (KeyValuePair<string, string> kvp in hashMap)
                {
                    if (kvp.Value.ToLower().Contains(".png") || kvp.Value.ToLower().Contains(".jpg") || kvp.Value.ToLower().Contains(".jpeg"))
                    {
                        sb.Append(kvp.Key).Append("=").Append(kvp.Value).Append("&");
                    }
                    else
                    {
                        string value = HttpUtility.UrlEncode(kvp.Value, Encoding.UTF8);
                        sb.Append(kvp.Key).Append("=").Append(value).Append("&");
                    }
                }
                sb = sb.Remove(sb.Length - 1, 1); // 去掉后面的&
            }

            string url = sb.ToString();

            return url;
        }

        /// <summary>
        /// 接口加密系统
        /// </summary>
        private void HttpEncrypt(bool beforeLogin)
        {
            if (hashMap != null && hashMap.ContainsKey("secret"))
            {
                if (!UIUtils.IsNull(Applicate.Access_Token))
                {
                    hashMap.Add("access_token", Applicate.Access_Token);
                }
                return;
            }


            if (beforeLogin)
            {
                BeforeLoginParam();
                return;
            }


            string userId = null;
            if (UIUtils.IsNull(Applicate.Access_Token))
            {
                BeforeLoginParam();
                return;
            }

            if (Applicate.MyAccount == null || UIUtils.IsNull(Applicate.MyAccount.userId))
            {
                BeforeLoginParam();
                return;
            }
            else
            {
                userId = Applicate.MyAccount.userId;
            }


            if (UIUtils.IsNull(Applicate.HTTP_KEY))
            {
                BeforeLoginParam();
                return;
            }


            if (hashMap == null)
            {
                hashMap = new Dictionary<string, string>();
            }

            string salt = TimeUtils.CurrentTimeMillis().ToString();
            if (hashMap.ContainsKey("salt"))
            {
                salt = hashMap["salt"];
                hashMap.Remove("salt");
            }

            hashMap.Remove("access_token");
            string macContent = Applicate.API_KEY + userId + Applicate.Access_Token + Parameter.JoinValues(hashMap) + salt;
            string mac = MAC.EncodeBase64(macContent, Convert.FromBase64String(Applicate.HTTP_KEY));
            hashMap.Add("access_token", Applicate.Access_Token);
            hashMap.Add("salt", salt);
            hashMap.Add("secret", mac);
        }

        /// <summary>
        /// 登陆前验参
        /// </summary>
        private void BeforeLoginParam()
        {

            string salt = TimeUtils.CurrentTimeMillis().ToString();
            if (hashMap != null && hashMap.ContainsKey("salt"))
            {
                salt = hashMap["salt"];
                hashMap.Remove("salt");
            }

            string secret = string.Empty;

            string macContent = Applicate.API_KEY + Parameter.JoinValues(hashMap) + salt;
            byte[] key = MD5.Encrypt(Applicate.API_KEY);

            string mac = MAC.EncodeBase64(macContent, key);

            if (hashMap == null)
            {
                hashMap = new Dictionary<string, string>();
            }
            hashMap.Add("salt", salt);
            hashMap.Add("secret", mac);
        }
    }

}
