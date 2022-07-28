﻿using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;
namespace WinFrmTalk.View
{
    public partial class FrmSedLocation : FrmBase
    {
        #region 窗体加载
        public FrmSedLocation()
        {

            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
        }
        public static FrmSedLocation CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmSedLocation();
            }
            if (frm != null)
            {
                frm.Activate();
            }
            return frm;
        }
        #endregion

        #region 全局变量
        private delegate void DelegateString(string msg);
        public static double Longitude;
        public static double Latitude;
        public static string IPAdress = Applicate.URLDATA.data.ipAddress;
        public Friend myfriend;
        public Action<MessageObject> locMsg_action;
        private ChromiumWebBrowser webView;
        public static string Lng;
        public static string Lat;
        public static string Province;
        public static string City;
        public static string District;
        public static string Street;
        public static string StreetNumber;
        private static bool isFristClick;
        private static FrmSedLocation frm = null;
        private bool isOpenLocation;
        #endregion

        #region 获取经纬度
        private static LocationModel.AddressForQueryIPFromBaidu GetAddressFormIP(string ip)
        {

            string ak1 = "kyLQQNk36qlXlNujUz30uWUxA8ConrxR";
            string url = "https://api.map.baidu.com/location/ip?ip=" + ip + "&ak=" + ak1 + "&coor=bd09ll";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                string reponseText = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                string jsonData = reponseText;
                LocationModel.AddressForQueryIPFromBaidu address = JsonConvert.DeserializeObject<LocationModel.AddressForQueryIPFromBaidu>(jsonData);
                //获取经纬度
                Longitude = Convert.ToDouble(address.Content.Point.X);
                Latitude = Convert.ToDouble(address.Content.Point.Y);
                Province = address.Content.Address_Detail.Province;//省份
                City = address.Content.Address_Detail.City;//城市
                if (Convert.ToInt32(address.Status) == 0)
                    return address;
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        #endregion

        #region js传递过来的参数
        public class JSEvent
        {
            private Action<string> mlistener;
            //监听事件
            public void SetSelectListener(Action<string> listener)
            {
                mlistener = listener;
            }
            public void ShowTest(object lng, object lat, object province, object city, object district, object street, object streetNumber)
            {
                isFristClick = false;
                //省份依次排名
                Lng = lng.ToString();
                Lat = lat.ToString();
                Province = province.ToString(); ;
                City = city.ToString(); ;
                District = district.ToString(); ;
                Street = street.ToString(); ;
                StreetNumber = streetNumber.ToString();
                string address = Province + City + District + Street + StreetNumber;
                if (mlistener != null)
                {
                    mlistener(address);
                }
            }
        }
        #endregion

        #region 参数传递
        public void initCefSharp(Friend friend)
        {
            try
            {
                if (!isOpenLocation)
                {
                    //开启授权
                    CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                    GetAddressFormIP(IPAdress);
                    myfriend = friend;
                    string Url = Environment.CurrentDirectory + "\\BaiDuMap.html?Longitude=" + Longitude + "&Latitude=" + Latitude + "";
                    webView = new ChromiumWebBrowser(Url);
                    //注册JS
                    JSEvent sEvent = new JSEvent();
                    sEvent.SetSelectListener((address) =>
                    {
                        ShowTextAddress(address);//文本框显示地址
                    });
                    var bindScriptOption = new CefSharp.BindingOptions();
                    bindScriptOption.CamelCaseJavascriptNames = false;
                    webView.RegisterAsyncJsObject("jsObj", sEvent, bindScriptOption);
                    webView.Dock = DockStyle.Fill;
                    pnlLocation.Controls.Add(webView);
                    this.Show();
                    isOpenLocation = true;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void initCefSharp(Action<MessageObject> locMsg_action)
        {
            try
            {
                if (!isOpenLocation)
                {
                    //开启授权
                    CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                    GetAddressFormIP(IPAdress);
                    this.locMsg_action = locMsg_action;
                    string Url = Environment.CurrentDirectory + "\\BaiDuMap.html?Longitude=" + Longitude + "&Latitude=" + Latitude + "";
                    webView = new ChromiumWebBrowser(Url);
                    webView.Dock = DockStyle.Fill;
                    pnlLocation.Controls.Add(webView);
                    //注册JS
                    JSEvent sEvent = new JSEvent();
                    sEvent.SetSelectListener((address) =>
                    {
                        ShowTextAddress(address);//文本框显示地址
                    });

                    var bindScriptOption = new CefSharp.BindingOptions();
                    bindScriptOption.CamelCaseJavascriptNames = false;
                    webView.RegisterAsyncJsObject("jsObj", sEvent, bindScriptOption);
                    this.Show();
                    isOpenLocation = true;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void FrmSedLocation_Load(object sender, EventArgs e)
        {
            isFristClick = true;
            lblLocation.Text = Province + City;
        }

        private void ShowTextAddress(string address)
        {

            if (Thread.CurrentThread.IsBackground)
            {
                var main = new DelegateString(ShowTextAddress);
                Invoke(main, address);
                return;
            }
            lblLocation.Text = address;
        }
        #endregion

        #region 发送位置
        //发送位置
        private void btnSend_Click(object sender, EventArgs e)
        {
            string address = Province + City + District + Street + StreetNumber;
            if (isFristClick)
            {
                Lng = Longitude.ToString();
                Lat = Latitude.ToString();
            }
            if (locMsg_action != null)
            {
                MessageObject loc_msg = ShiKuManager.SendLocationMessage(new Friend(), Convert.ToDouble(Lng), Convert.ToDouble(Lat), address, false, false);
                locMsg_action.Invoke(loc_msg);
                this.Close();
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    MessageObject message = ShiKuManager.SendLocationMessage(myfriend, Convert.ToDouble(Lng), Convert.ToDouble(Lat), address, false);
                    Messenger.Default.Send(message, token: MessageActions.XMPP_UPDATE_NORMAL_MESSAGE);
                    ShiKuManager.mSocketCore.SendMessage(message);

                });
            }
            this.Close();
        }
        #endregion
    }
}
