using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WinFrmTalk.Model;
using Newtonsoft.Json;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserLiveGift : UserControl
    {
        //FrmSuspension
        /// <summary>
        /// 礼物列表
        /// </summary>
        public List<Gift> gifts;
       
        public LiveCardBean liveinfo;

        //public LiveCardBean liveinfo
        //{
        //    get { return _liveCardBean; }
        //    set { _liveCardBean = value; }
        //}
        
        public UserLiveGift()
        {
            InitializeComponent();
          
       }
        public void GetGiftLst()
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
                        gifts = giftlst;
                        AddGiftToTab();

                    }
                });
        }

        private void AddGiftToTab()
        {
            //EQControlManager.ClearTabel(flpEmoji);
            if (PalGiftList.Controls.Count > 0)
                return;

            //获取礼物的表情列表

            //循环添加emoji表情
            for (int i = 0; i < gifts.Count; i++)
            {
                UserGiftItem userGiftItem = new UserGiftItem();
                userGiftItem.GiftData = gifts[i];
                userGiftItem.Click += UserGiftItem_Click;
                PalGiftList.Controls.Add(userGiftItem);
            }

        }

        private void UserGiftItem_Click(object sender, EventArgs e)
        {
            UserGiftItem userGiftItem = (UserGiftItem)sender;
            LiveUtils.SendGiftLst(userGiftItem.GiftData, liveinfo.roomId, liveinfo.userId);
        }

        private void PicEmoji_MouseDown(object sender, MouseEventArgs e)
        {

        }
      

        private void PalGiftList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserLiveGift_Load(object sender, EventArgs e)
        {
            GetGiftLst();
        }
    }
}
