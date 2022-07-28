using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace WinFrmTalk.Model
{

    /// <summary>
    /// 浏览器配置类
    /// 作用：
    /// 1.给浏览器可以访问系统音视频的权限
    /// </summary>
    public class SelfPermission
    {

        // 是否请求过
        private bool isRequest = false;
        private readonly object lock_request = new object();

        // 单例模式 
        private SelfPermission()
        {
        }

        private static SelfPermission _instance;
        public static SelfPermission Instance => _instance ?? (_instance = new SelfPermission());

        public void RequestOpenVideoPermission()
        {

            lock (lock_request)
            {
                Init();
            }
        }


        //加载视频的方法
        private void Init()
        {
            if (isRequest)
            {
                return;
            }

            //默认为true
            isRequest = true;
            var setting = new CefSettings();
            //端口号
            setting.RemoteDebuggingPort = 8080;
            //语言
            setting.Locale = "zh-CN";
            setting.AcceptLanguageList = "zh-CN";
            //开启音视频
            setting.CefCommandLineArgs.Add("enable-media-stream", "enable-media-stream");
            //setting.CefCommandLineArgs.Add("enable-speech-input", "enable-speech-input");
            //验证书
            setting.IgnoreCertificateErrors = true;
            //日志
            setting.LogSeverity = CefSharp.LogSeverity.Verbose;
            if (!Cef.Initialize(setting))
            {
                if (Environment.GetCommandLineArgs().Contains("--type=renderer"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
