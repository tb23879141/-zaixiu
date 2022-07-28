using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
using Newtonsoft.Json;

namespace WinFrmTalk.Live.Controls
{
    public partial class UserPresentlst : UserControl
    {
        public List<Gift> gifts;//礼物列表
        public List<UserGiftItem> userGiftItems;
        public LiveCardBean liveinfo;

        public UserPresentlst()
        {
            InitializeComponent();
        }
        #region 传值获取参数
        public void setdata(LiveCardBean liveinfos)
        {
            liveinfo = liveinfos;
            GetGiftLst();
        }

        public Gift GetGift(string id)
        {

            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts[i].giftId.Equals(id))
                {
                    return gifts[i];
                }
            }
            return null;
        }

        #endregion
        #region 从接口获取礼物列表
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
        #endregion
        #region 将数据显示在界面上
        private void AddGiftToTab()
        {
            //EQControlManager.ClearTabel(flpEmoji);
            if (PalGiftList.Controls.Count > 0)
                return;

            //获取礼物的表情列表
            userGiftItems = new List<UserGiftItem>();

            PalGiftList.Width = (gifts.Count * 76);

            //循环添加emoji表情
            for (int i = 0; i < gifts.Count; i++)
            {
                UserGiftItem userGiftItem = new UserGiftItem();
                userGiftItem.Location = new Point((userGiftItem.Size.Width + 10) * i, 10);
                userGiftItem.Margin = new Padding(0, 10, 10, 0);
                userGiftItem.GiftData = gifts[i];
                userGiftItems.Add(userGiftItem);
                userGiftItem.Click += PalGiftList_Click;
                PalGiftList.Controls.Add(userGiftItem);
            }
            if (gifts.Count < 11)
            {
                btnleft.Enabled = false;
                btnRight.Enabled = false;
            }
            else
            {
                btnleft.Enabled = true;
                btnRight.Enabled = true;
            }
        }
        #endregion
        #region 发送礼物事件
        private void PalGiftList_Click(object sender, EventArgs e)
        {
            if(liveinfo.userId == Applicate.MyAccount.userId)//主播自己不能发送礼物
            {
                return;
            }
            UserGiftItem userGiftItem = (UserGiftItem)sender;
            LiveUtils.SendGiftLst(userGiftItem.GiftData, liveinfo.roomId, liveinfo.userId);
        }
        #endregion
        #region 礼物列表左右移动
        /// <summary>
        /// 
        /// 
        /// 
        ///左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnleft_Click(object sender, EventArgs e)
        {
            if (PalGiftList.Location.X <= 49)
            {
                PalGiftList.Location = new Point(PalGiftList.Location.X + 660, 0);
            }

        }
        /// <summary>
        /// 右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (PalGiftList.Location.X > -1070)
            {
                PalGiftList.Location = new Point(PalGiftList.Location.X - 660, 0);
            }
        }
        #endregion

    }



}
