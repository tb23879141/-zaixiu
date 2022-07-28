using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.Groups;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UseGroupInfoChat : UserControl
    {
        private Friend mFriend;


        public string UserId
        {
            get
            {
                if (mFriend == null)
                {
                    return "";
                }

                return mFriend.UserId;
            }
        }


        public UseGroupInfoChat()
        {
            InitializeComponent();

            groupPageMain1.HideNewsControl();
        }


        internal void SwitchGroupType(GroupTabIndex tabIndex, Friend friend)
        {
            this.mFriend = friend;
            groupPageMain1.Visible = tabIndex == GroupTabIndex.main;
            groupPageFunc1.Visible = tabIndex != GroupTabIndex.main;

            if (friend == null)
            {
                return;
            }

            switch (tabIndex)
            {
                case GroupTabIndex.main:
                    if (friend.GroupType == 0)
                    {
                        HttpLoadData2();
                    }
                    else
                    {
                        HttpLoadData1();
                    }

                    break;
                default:
                    groupPageFunc1.BindRoomData(friend);
                    groupPageFunc1.SwitchGroupPage(tabIndex);
                    break;
            }
        }

        /// <summary>
        /// 获取官群
        /// </summary>
        private void HttpLoadData1()
        {

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "officialGroup/getOfficialGroup")
                .AddParams("control", "1")
                .AddParams("roomId", mFriend.RoomId)
                .Build().Execute((sccess, data) =>
                {

                    if (sccess)
                    {
                        // 群信息
                        var roomnews = JsonConvert.DeserializeObject<GroupNewsInfo>(UIUtils.DecodeString(data, "news"));
                        groupPageMain1.SetContentData(roomnews, mFriend);

                    }
                });
        }

        /// <summary>
        /// 获取社群 话题
        /// </summary>
        private void HttpLoadData2()
        {
            //QueryGroupOfSubjects
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "community/QueryGroupOfSubjects")
                .AddParams("roomId", mFriend.RoomId)
                .Build().ExecuteJson<List<GroupTopInfo>>((sccess, data) =>
                {

                    if (sccess)
                    {
                        // 群信息
                        //   var roomnews = JsonConvert.DeserializeObject<GroupNewsInfo>(UIUtils.DecodeString(data, "news"));
                        groupPageMain1.SetContentData(data, mFriend);

                    }
                });
        }


    }
}