using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFrmTalk.Model;

namespace WinFrmTalk.Live.Controls
{
   public  class LiveUtils
    {
        /// <summary>
        /// 发送礼物
        /// </summary>
        public static void SendGiftLst( Gift gift, string Rooid, string Touserid)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/give")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("roomId", Rooid)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("toUserId", Touserid)
                .AddParams("giftId", gift.giftId)
                .AddParams("count", "1")
                .AddParams("price", gift.price.ToString())
                .Build()
                .AddErrorListener((code,err)=> {
                    HttpUtils.Instance.ShowTip(err);
                })
                .Execute(null);
        }
        /// <summary>
        /// 获取礼物列表
        /// </summary>
        public static void GetGiftLst()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/giftlist")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("pageIndex", "0")
                .AddParams("pageSize", "50")
                .Build()
                .Execute((success, result) =>
                {
                    if (success && result != null && result.Count > 0)
                    {
                        string list = UIUtils.DecodeString(result, "data");
                        List<Gift> giftlst = JsonConvert.DeserializeObject<List<Gift>>(list);

                    }
                });
        }
        /// <summary>
        /// 获取直播列表
        /// </summary>
        /// <param name="gift"></param>
        /// <param name="Rooid"></param>
        /// <param name="Touserid"></param>
       

    }
}
