using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Live
{
    public class RoomLive
    {
        public void GetRoom_Live(string roomId)
        {
            if (UIUtils.IsNull(AudioPushBase.GetAudioDeviceName()) || UIUtils.IsNull(VideoPushBase.GetVideoDeviceName()))
            {
                HttpUtils.Instance.ShowTip("缺少音视频设备");
                return;
            }
                
            //获取自己的直播间
            //HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/getLiveRoom")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("roomId", roomId)
                .Build()
                .Execute((success, result) =>
                {
                    if (!success)
                        return;

                    if (result.Count > 2)
                    {
                        string data = JsonConvert.SerializeObject(result);
                        LiveCardBean liveCard = JsonConvert.DeserializeObject<LiveCardBean>(data);
                        if (string.IsNullOrEmpty(liveCard.liveRoomId))
                        {
                            liveCard.liveRoomId = roomId;
                        }
                        if (liveCard.userId.Equals(Applicate.MyAccount.userId))
                        {
                            if (liveCard.numbers >= 1)
                            {
                                liveCard.numbers--;
                            }
                            if (Applicate.isliveopen)
                            {
                                HttpUtils.Instance.ShowTip("该直播间已打开");
                                return;
                            }

                            //打开直播间
                            try
                            {
                                FrmLive frmLive = new FrmLive();
                                frmLive.LiveStart(liveCard.url, liveCard, 2);
                                frmLive.Show();
                            }
                            catch (Exception ex) { LogHelper.log.Error("----------------打开直播间失败:", ex); }
                            liveCard.isOpen = true;
                            Applicate.isliveopen = true;
                        }
                        //已经有人开始在群内直播了
                        else
                        {
                            if (liveCard.isOpen)
                            {
                                HttpUtils.Instance.ShowTip("该直播间已打开");
                                return;
                            }
                            if (TimeUtils.CurrentIntTime() - Applicate.ColseLiveTime < 2)
                            {
                                HttpUtils.Instance.ShowTip("请稍候");
                                return;
                            }
                            try
                            {
                                //观看别人的直播，并且自己为管理员或群主，显示关闭直播间的按钮
                                int myRole = new RoomMember() { roomId = roomId, userId = Applicate.MyAccount.userId }.GetRoleByUserId();
                                int liverRole = new RoomMember() { roomId = roomId, userId = liveCard.userId }.GetRoleByUserId();
                                //管理员不能结束管理员权限以上的直播
                                bool isShowClose = (myRole == 1 || myRole == 2) && liverRole > 2;

                                FrmLive frmLive = new FrmLive();
                                frmLive.usertitle.isShowCloseLive = isShowClose;
                                frmLive.LiveStart(liveCard.url, liveCard, 3);
                                Console.WriteLine("click");
                                frmLive.Show();
                            }
                            catch (Exception ex) { LogHelper.log.Error("----------------打开直播间失败:", ex); }
                        }
                    }
                    //返回结果为空，没有人直播，自己也没有直播间
                    else
                    {
                        CreatLiveRoom(roomId);
                    }
                });
        }

        private void CreatLiveRoom(string roomJid)
        {
            //创建一个房间

            //直播间的名字
            FrmBuildLive frmBuildLive = new FrmBuildLive();
            var parent = Applicate.GetWindow<FrmMain>();
            frmBuildLive.Location = new Point(parent.Location.X + (parent.Width - frmBuildLive.Width) / 2, parent.Location.Y + (parent.Height - frmBuildLive.Height) / 2);//居中
            frmBuildLive.ShowDialog();

            if (frmBuildLive.DialogResult == DialogResult.OK)
            {
                string jid = ShiKuManager.mSocketCore.CreateGroup(frmBuildLive.live_name, frmBuildLive.live_notice);
                //创建直播间
                //http get请求获得数据
                //HttpUtils.Instance.InitHttp(this);
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/create")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("userId", Applicate.MyAccount.userId)
                    .AddParams("nickName", Applicate.MyAccount.nickname)
                    .AddParams("jid", jid)
                    .AddParams("name", frmBuildLive.live_name)
                    .AddParams("notice", frmBuildLive.live_notice)
                    .AddParams("liveRoomId", roomJid)
                    .Build()
                    .Execute((success, result) =>
                    {
                        if (success && result != null && result.Count > 0)
                        {
                            string data = JsonConvert.SerializeObject(result);
                            LiveCardBean liveCard = JsonConvert.DeserializeObject<LiveCardBean>(data);

                            //打开直播间
                            try
                            {
                                FrmLive frmLive = new FrmLive();
                                frmLive.LiveStart(liveCard.url, liveCard, 2);
                                frmLive.Show();
                            }
                            catch (Exception ex) { LogHelper.log.Error("----------------群内直播间创建失败:", ex); }
                            liveCard.isOpen = true;
                        }
                    });
            }
        }
    }
}
