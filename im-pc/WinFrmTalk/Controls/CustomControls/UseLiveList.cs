using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RichTextBoxLinks;
using WinFrmTalk.Dictionarys;
using WinFrmTalk.Live;
using WinFrmTalk.Model;
using WinFrmTalk.View;
using WinFrmTalk.View.list;

namespace WinFrmTalk.Controls.CustomControls
{
    enum PageTuningType
    {
        PageUp = 0,
        PageDown = 1
    }


    // 直播间列表
    public partial class UseLiveList : UserControl
    {
        /// <summary>
        /// 主窗口对象
        /// </summary>
        public FrmMain MainForm { get; set; }

        public List<LiveCardBean> liveList = new List<LiveCardBean>();
        public UseLiveList()
        {
            InitializeComponent();

        }

        public void LoadData()
        {
            liveList.Clear();
            flpLiveList.Controls.Clear();
            //http get请求获得数据
            //HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/list")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("pageIndex", pageIndex.ToString())
                .AddParams("pageSize", "99")
                .AddParams("status", "1")
                .Build()
                .Execute((success, result) =>
                {
                    if (success && result != null && result.Count > 0)
                    {
                        try
                        {
                            string data = UIUtils.DecodeString(result, "data");
                            List<LiveCardBean> liveCards = JsonConvert.DeserializeObject<List<LiveCardBean>>(data);

                            foreach (var item in liveCards)
                            {
                                //已存在的直播间不重复添加
                                if (liveList.FindIndex(l => l.userId == item.userId) > -1)
                                    continue;
                                ////不添加自己的直播间
                                //if (item.userId == Applicate.MyAccount.userId)
                                //    continue;

                                LiveCardItem liveCardItem = new LiveCardItem();
                                liveCardItem.BindDataToUI(item);
                                liveCardItem.useLiveList = this;
                                flpLiveList.Controls.Add(liveCardItem);
                                liveList.Add(item);
                            }
                        }
                        catch (Exception) { }
                    }
                });
        }

        static int pageIndex = 0;
        private void PageTruning(PageTuningType type)
        {
            if (type == PageTuningType.PageUp && pageIndex > 0)
                pageIndex--;
            else if (type == PageTuningType.PageDown)
                pageIndex++;
            LoadData();
        }

        private void LblLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                PageTruning(PageTuningType.PageUp);
        }

        private void LblRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                PageTruning(PageTuningType.PageDown);
        }

        public void CreatLiveRoom(FrmBuildLive frmBuildLive, LiveApplyModel liveModel)
        {
            //创建一个房间
            string jid = ShiKuManager.mSocketCore.CreateGroup(frmBuildLive.live_name, frmBuildLive.live_notice);

            //创建直播间
            //http get请求获得数据
            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/create")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("nickName", Applicate.MyAccount.nickname)
                .AddParams("jid", jid)
                .AddParams("roomType", liveModel.roomType)
                .AddParams("name", frmBuildLive.live_name)
                .AddParams("notice", frmBuildLive.live_notice)
                .Build()
                .Execute((success, result) =>
                {
                    if (success && result != null && result.Count > 0)
                    {
                        //string data = UIUtils.DecodeString(result, "data");
                        string data = JsonConvert.SerializeObject(result);
                        LiveCardBean liveCard = JsonConvert.DeserializeObject<LiveCardBean>(data);

                        //LiveCardItem liveCardItem = new LiveCardItem();
                        //liveCardItem.BindDataToUI(liveCard);
                        //flpLiveList.Controls.Add(liveCardItem);

                        //打开直播间
                        try
                        {
                            FrmLive frmLive = new FrmLive();
                            frmLive.useLiveList = this;
                            frmLive.LiveStart(liveCard.url, liveCard, 0);
                            frmLive.Show();
                            //FrmLiveTest frmLiveTest = new FrmLiveTest();
                            //frmLiveTest.LiveStart(LiveCardBean.url, LiveCardBean);
                            //frmLiveTest.Show();
                        }
                        catch (Exception ex) { LogHelper.log.Error("----------------打开直播间失败:", ex); }
                        liveCard.isOpen = true;

                        //刷新直播列表
                        LoadData();
                    }
                });
        }

        #region 判断设备接入
        /// <summary>
        /// 视频设备
        /// </summary>
        /// <returns></returns>
        private string GetVideoDeviceName()
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    string device_name = device["Caption"].ToString();
                    return device_name;
                }
                catch { continue; }
            }
            return "";
        }
        /// <summary>
        /// 音频设备
        /// </summary>
        /// <returns></returns>
        private string GetAudioDeviceName()
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity  WHERE (PNPClass = 'AudioEndpoint')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    if (device.ToString().IndexOf("{0.0.1.00000000}") > 0)
                    {
                        //Console.WriteLine("PNPClass: " + device["PNPClass"] + "  Caption: " + device["Caption"]);
                        string device_name = device["Caption"].ToString();
                        return device_name;
                    }
                }
                catch { continue; }
            }
            return "";
        }
        #endregion

        private void BtnStartLive_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UIUtils.IsNull(AudioPushBase.GetAudioDeviceName()) || UIUtils.IsNull(VideoPushBase.GetVideoDeviceName()))
                {
                    HttpUtils.Instance.ShowTip("缺少音视频设备");
                    return;
                }

                //获取自己的直播间
                HttpUtils.Instance.InitHttp(this);
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/getLiveRoom")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("userId", Applicate.MyAccount.userId)
                    .Build()
                    .Execute((success, result) =>
                    {
                        if (success && result != null && result.Count > 0)
                        {
                            OpenLiveRoom(result);
                        }
                    });
            }
        }

        public Dictionary<string, FrmLive> frmLivePairs = new Dictionary<string, FrmLive>();
        /// <summary>
        /// 打开直播间
        /// </summary>
        /// <param name="liveCard"></param>
        private void OpenLiveRoom(Dictionary<string, object> result)
        {
            FrmBuildLive frmBuildLive = new FrmBuildLive();
            frmBuildLive.lblTitle.Text = "修改直播间";
            frmBuildLive.btnStartLive_Text = "确认修改";
            var parent = Applicate.GetWindow<FrmMain>();
            frmBuildLive.Location = new Point(parent.Location.X + (parent.Width - frmBuildLive.Width) / 2, parent.Location.Y + (parent.Height - frmBuildLive.Height) / 2);//居中

            string data = JsonConvert.SerializeObject(result);
            LiveCardBean liveCard = JsonConvert.DeserializeObject<LiveCardBean>(data);
            if (!string.IsNullOrEmpty(liveCard.name))
                frmBuildLive.txtName_Text = liveCard.name;
            if (!string.IsNullOrEmpty(liveCard.notice))
                frmBuildLive.txtNotice_Text = liveCard.notice;
            frmBuildLive.roomType = int.Parse(string.IsNullOrEmpty(liveCard.roomType) ? "1" : liveCard.roomType);
            Form form = Application.OpenForms["FrmBuildLive"];
            if (form == null || form.IsDisposed)
            {
                frmBuildLive.ShowDialog();
            }
            else
            {
                form.Activate();
            }

            if (frmBuildLive.DialogResult == DialogResult.OK)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/getLivePermissionByUser")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("roomType", frmBuildLive.live_type.ToString())
               .Build()
               .ExecuteJson<LiveApplyModel>((resultStatus, liveModel) =>
               {
                   if (resultStatus)
                   {
                       if (liveModel.status == "1")
                       {
                           if (result.Count > 2)
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
                                   if (!frmLivePairs.ContainsKey(liveCard.url))
                                   {
                                       FrmLive frmLive = new FrmLive();
                                       //如果没修改就点确定
                                       if (frmBuildLive.txtName_Text.Equals(liveCard.name) && frmBuildLive.txtNotice_Text.Equals(liveCard.notice))
                                       {
                                           frmLive.useLiveList = this;
                                           frmLive.LiveStart(liveCard.url, liveCard, 0);
                                           frmLive.Show();
                                       }
                                       else
                                       {
                                           //强制结束直播
                                           var builder = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/update")
                                           .AddParams("access_token", Applicate.Access_Token)
                                           .AddParams("roomId", liveCard.roomId)
                                           .AddParams("name", frmBuildLive.live_name)
                                           .AddParams("notice", frmBuildLive.live_notice)
                                           .AddParams("roomType", frmBuildLive.live_type.ToString());
                                           if (!string.IsNullOrEmpty(liveCard.liveRoomId))
                                           {
                                               builder.AddParams("liveRoomId", liveCard.liveRoomId);
                                           }
                                           builder.Build()
                                               .Execute((success, resultJson) =>
                                               {
                                                   if (success && result.Count > 0)
                                                   {
                                                       liveCard.name = frmBuildLive.txtName_Text;
                                                       liveCard.notice = frmBuildLive.txtNotice_Text;
                                                       frmLive.useLiveList = this;
                                                       frmLive.LiveStart(liveCard.url, liveCard, 0);
                                                       frmLive.Show();
                                                   }
                                               });
                                       }
                                       frmLivePairs.Add(liveCard.url, frmLive);
                                   }
                                   else
                                   {
                                       frmLivePairs[liveCard.url].Activate();
                                   }
                                   //刷新直播列表
                                   LoadData();
                               }
                               catch (Exception ex) { LogHelper.log.Error("----------------打开直播间失败:", ex); }
                               liveCard.isOpen = true;
                               Applicate.isliveopen = true;
                           }
                           else
                           {
                               CreatLiveRoom(frmBuildLive, liveModel);
                           }

                       }
                       else
                       {
                         
                       }
                   }
               });
            }
        }
    }
}
