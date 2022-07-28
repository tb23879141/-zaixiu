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
    public class OpenVideo
    {
        //默认浏览器
        public readonly string Default = "http://www.google.com/";
        private static readonly bool DebuggingSub = Debugger.IsAttached;
        //验证窗体被动打开事件
        public static bool isInitSet;

        //加载视频的方法
        public static RequestContext RequestContext { get; }
        public static void Init()
        {
            if (isInitSet)
            {
                return;
            }
            //默认为true
            isInitSet = true;
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
