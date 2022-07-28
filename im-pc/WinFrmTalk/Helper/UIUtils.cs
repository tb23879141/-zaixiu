
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using WinFrmTalk;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

public class UIUtils
{

    /// <summary>
    /// 返回当前毫秒时间错
    /// </summary>
    /// <returns></returns>
    public static long CurrentTimeMillis()
    {
        var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long times = Convert.ToInt64((ts.TotalSeconds + TimeUtils.SyncTimeDiff()) * 1000);
        return times;
    }

    public static double CurrentTimeDouble()
    {
        var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return ts.TotalSeconds + TimeUtils.SyncTimeDiff();
    }
    public static long CurrentTimeLong()
    {
        var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds + TimeUtils.SyncTimeDiff());

    }
    public static bool IsNull(string str)
    {
        if (str == null || str.Length == 0)
        {
            return true;
        }

        return false;

    }

    public static bool IsNull<T>(List<T> str)
    {

        if (str == null || str.Count == 0)
        {
            return true;
        }

        return false;

    }


    public static bool IsNull(Dictionary<string, string> data)
    {

        if (data == null || data.Count == 0)
        {
            return true;
        }
        return false;
    }

    internal static string LimitTextLength(string value, int max, bool Ellipsis)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }
        if (Ellipsis)
        {
            return value.Length > max ? value.Substring(0, max) + "..." : value;
        }
        return value.Length > max ? value.Substring(0, max) : value;
    }


    internal static string MaxTextLine(string value, int max)
    {
        string[] sArray = Regex.Split(value, "\n", RegexOptions.IgnoreCase);
        if (sArray != null && sArray.Length > max)
        {
            string res = "";
            for (int i = 0; i < max; i++)
            {
                res = res + sArray[i];
            }

            return res;
        }

        return value;
    }


    internal static string DecodeString(JToken pairs, string key)
    {
        try
        {
            return pairs[key].ToString();
        }
        catch (Exception)
        {
            //Console.WriteLine("DecodeString 解析失败" + key);
            return "";
        }
    }

    //internal static string DecodeString(Dictionary<string, object> pairs, string key)
    //{
    //    try
    //    {
    //        if (pairs != null && pairs.ContainsKey(key))
    //        {
    //            return pairs[key].ToString();
    //        }
    //        else
    //        {
    //            return "";
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        //Console.WriteLine("DecodeString 解析失败" + key);
    //        return "";
    //    }
    //}

    internal static long DecodeLong(JToken pairs, string key)
    {
        try
        {
            long val = pairs.Value<long>(key);
            return val;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    internal static int DecodeInt(JToken pairs, string key)
    {

        try
        {
            int val = pairs.Value<int>(key);
            return val;
        }
        catch (Exception)
        {
            return 0;
        }
    }


    //internal static double DecodeDouble(JToken pairs, string key)
    //{
    //    if (pairs.Contains(key))
    //    {
    //        return Convert.ToDouble(pairs[key]);
    //    }

    //    return 0;
    //}

    internal static string DecodeString(Dictionary<string, object> pairs, string key)
    {
        if (pairs.ContainsKey(key))
        {
            var dat = pairs[key];
            if (dat != null && !"null".Equals(dat.ToString()))
            {
                //return pairs[key].ToString();
                return dat.ToString();
            }
            else
            {
                return "";
            }

        }

        return "";
    }

    internal static int DecodeInt(Dictionary<string, object> pairs, string key)
    {
        try
        {
            if (pairs.ContainsKey(key))
            {
                return Convert.ToInt32(pairs[key].ToString());
            }

        }
        catch (Exception)
        {
            return 0;
        }
        return 0;
    }

    internal static void DisposeGdi(SolidBrush fillBrush)
    {
        if (fillBrush != null)
        {
            fillBrush.Dispose();
            fillBrush = null;
        }
    }

    internal static void DisposeGdi(Pen framePen)
    {
        if (framePen != null)
        {
            framePen.Dispose();
            framePen = null;
        }
    }

    internal static double DecodeDouble(Dictionary<string, object> pairs, string key)
    {
        try
        {
            if (pairs.ContainsKey(key))
            {
                return Convert.ToDouble(pairs[key].ToString());
            }

        }
        catch (Exception)
        {
            return 0;
        }

        return 0;
    }
    internal static long DecodeLong(Dictionary<string, object> pairs, string key)
    {
        try
        {
            if (pairs.ContainsKey(key))
            {
                return Convert.ToInt64(pairs[key].ToString());
            }
        }
        catch (Exception)
        {
            return 0;
        }

        return 0;
    }

    internal static string QuotationName(string name)
    {
        if (UIUtils.IsNull(name))
        {
            return "";
        }

        if (name.Length > 6)
        {
            return "“" + name.Substring(0, 6) + "…”";
        }

        return "“" + name + "”";
    }

    internal static double DoubleParse(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return 0;
        }

        return Convert.ToDouble(value);
    }
    /// <summary>
    /// 图片修剪
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dest"></param>
    /// <returns></returns>
    public static Image ImageScale(Bitmap src)
    {
        Bitmap dest = Resources.on_line;
        if (src == null || dest == null)
        {
            return null;
        }

        double srcScale;
        double destScale;
        srcScale = (double)src.Width / src.Height;
        destScale = (double)dest.Width / dest.Height;
        //计算长宽比
        using (Graphics g = Graphics.FromImage(dest))
        {
            g.Clear(Color.Blue);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            if (srcScale - destScale >= 0 && srcScale - destScale <= 0.001)
            {
                //长宽比相同
                g.DrawImage(src, new Rectangle(0, 0, dest.Width, dest.Height),
                    new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
            }
            else if (srcScale < destScale)
            {
                //源长宽比小于目标长宽比，源的高度大于目标的高度
                double newHeight;
                newHeight = (double)dest.Height * src.Width / dest.Width;
                g.DrawImage(src, new Rectangle(0, 0, dest.Width, dest.Height),
                    new Rectangle(0, (int)((src.Height - newHeight) / 2), src.Width, (int)newHeight),
                    GraphicsUnit.Pixel);
            }
            else
            {
                //源长宽比大于目标长宽比，源的宽度大于目标的宽度
                double newWidth;
                newWidth = (double)dest.Width * src.Height / dest.Height;
                g.DrawImage(src, new Rectangle(0, 0, dest.Width, dest.Height),
                    new Rectangle((int)((src.Width - newWidth) / 2), 0, (int)newWidth, src.Height),
                    GraphicsUnit.Pixel);
            }
            return dest;
        }
    }

    internal static kWCMessageType Trantomesstype(Dictionary<string, object> pairs, string key)
    {
        kWCMessageType kWCMessage = kWCMessageType.Text;
        string type = "";
        if (pairs.ContainsKey(key))
        {
            type = pairs[key].ToString();
            switch (type)
            {
                case "1":
                    kWCMessage = kWCMessageType.Text;
                    break;
                case "2":
                    kWCMessage = kWCMessageType.Image;
                    break;
                case "3":
                    kWCMessage = kWCMessageType.Voice;
                    break;
                case "4":
                    kWCMessage = kWCMessageType.Location;
                    break;
                case "85":
                    kWCMessage = kWCMessageType.History;
                    break;
                case "9":
                    kWCMessage = kWCMessageType.File;
                    break;
                case "6":
                    kWCMessage = kWCMessageType.Video;
                    break;


            }

            return kWCMessage;
        }
        return 0;

    }

    internal static string NewstypeTostring(kWCMessageType type)
    {
        string typevalue = string.Empty;
        switch (type)
        {
            case kWCMessageType.Text:
                typevalue = "文本";
                break;
            case kWCMessageType.Image:
                typevalue = "图像";
                break;
            case kWCMessageType.Voice:
                typevalue = "语音";
                break;
            case kWCMessageType.Location:
                typevalue = "位置";
                break;
            case kWCMessageType.History:
                typevalue = "聊天记录";
                break;
            case kWCMessageType.File:
                typevalue = "文件";
                break;
            case kWCMessageType.Video:
                typevalue = "录音";
                break;
            case kWCMessageType.Gif:
                typevalue = "动态图";
                break;
        }
        return typevalue;
    }

    /// <summary>
    /// 文件大小格式化，
    /// </summary>
    /// <param name="size"> b单位的文件大小 </param>
    /// <returns></returns>

    public static string FromatFileSize(long size)
    {
        if (size == 0)
        {
            return "未知大小";
        }

        if (size < 1024)
        {
            return size + "B";
        }
        else if (size < 1024 * 1024)
        {
            float kbsize = size / 1024f;
            return kbsize.ToString("f2") + "KB";
        }
        else if (size < 1024L * 1024 * 1024)
        {
            float mbsize = size / 1024f / 1024f;
            return mbsize.ToString("f2") + "MB";
        }
        else if (size < 1024L * 1024 * 1024 * 1024)
        {
            float gbsize = size / 1024f / 1024f / 1024f;
            return gbsize.ToString("f2") + "GB";
        }
        else
        {
            return "size: error";
        }

    }

    private static string save_url = "";
    /// <summary>
    /// 服务器读取
    /// </summary>
    /// <returns></returns>
    public static string GetServer()
    {
        if (!string.IsNullOrEmpty(save_url))
        {
            return save_url;
        }

        string appconfig = ConfigurationManager.AppSettings["local_app_config_url"];
        if (!string.IsNullOrEmpty(appconfig))
        {
            return appconfig;
        }
        else
        {
            return Applicate.APP_CONFIG;
        }
    }
    /// <summary>
    /// 服务器写入
    /// </summary>
    /// <param name="value"></param>
    public static void SetServer(string value)
    {
        save_url = value;
        Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        cfa.AppSettings.Settings["local_app_config_url"].Value = value;
        cfa.Save();
    }

    /// <summary>
    /// 拼接ids
    /// </summary>
    /// <param name="friends"></param>
    /// <returns> "1215123,李四,王五" </returns>
    public static string AppendFrindIds(List<Friend> friends)
    {
        if (IsNull(friends))
        {
            return "";
        }

        StringBuilder builder = new StringBuilder();
        foreach (var item in friends)
        {
            builder.Append(item.UserId);
            builder.Append(",");
        }

        if (builder.Length > 1)
        {
            builder.Remove(builder.Length - 1, 1);
        }

        return builder.ToString();
    }

    /// <summary>
    /// 拼接用户名 
    /// </summary>
    /// <param name="friends"></param>
    /// <returns> "张三,李四,王五" </returns>
    public static string AppendFrindNames(List<Friend> friends)
    {
        if (IsNull(friends))
        {
            return "";
        }

        StringBuilder builder = new StringBuilder();
        foreach (var item in friends)
        {
            builder.Append(item.NickName);
            builder.Append(",");
        }

        if (builder.Length > 1)
        {
            builder.Remove(builder.Length - 1, 1);
        }

        return builder.ToString();
    }

    /// <summary>
    /// 拼接消息ID
    /// </summary>
    /// <param name="messages"></param>
    /// <returns> "messageId1,messageId2,messageId3" </returns>
    public static string AppendMessageIds(List<MessageObject> messages)
    {
        if (IsNull(messages))
        {
            return "";
        }

        StringBuilder builder = new StringBuilder();
        foreach (var item in messages)
        {
            builder.Append(item.messageId);
            builder.Append(",");
        }

        if (builder.Length > 1)
        {
            builder.Remove(builder.Length - 1, 1);
        }

        return builder.ToString();
    }


    internal static string Getpcid()
    {
        string code = null;
        SelectQuery query = new SelectQuery("select * from Win32_ComputerSystemProduct");
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
        {
            foreach (var item in searcher.Get())
            {
                using (item) code = item["UUID"].ToString();
            }
        }
        return code;


    }


    public static string GetDotNetVersion()
    {
        string oldname = "0";

        try
        {
            using (RegistryKey ndpKey =
            RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
            OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string newname = (string)versionKey.GetValue("Version", "");
                        if (string.Compare(newname, oldname) > 0)
                        {
                            oldname = newname;
                        }
                        if (newname != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            newname = (string)subKey.GetValue("Version", "");
                            if (string.Compare(newname, oldname) > 0)
                            {
                                oldname = newname;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            return oldname = "1.0";
        }

        return oldname;
    }

    /// <summary>
    /// 判断.Net Framework的Version是否符合需要
    /// (.Net Framework 版本在2.0及以上)
    /// </summary>
    /// <param name="version">需要的版本 version = 4.5</param>
    /// <returns></returns>
    public static bool GetDotNetVersion(string version)
    {
        string oldname = GetDotNetVersion();
        return string.Compare(oldname, version) > 0 ? true : false;
    }

    //private const string Windows2000 = "5.0";
    //private const string WindowsXP = "5.1";
    //private const string Windows2003 = "5.2";
    //private const string Windows2008 = "6.0";
    //private const string Windows7 = "6.1";
    //private const string Windows8OrWindows81 = "6.2";
    //private const string Windows10 = "10.0";
    private static string system = string.Empty;
    public static bool GetOSystem_IsWin7()
    {
        if (string.IsNullOrEmpty(system))
        {
            system = System.Environment.OSVersion.Version.Major + "." + System.Environment.OSVersion.Version.Minor;
        }
        return system == "6.1";
    }

    internal static bool Contains(string text, string str)
    {
        if (!IsNull(text))
        {
            return text.Contains(str);
        }

        return false;
    }

    internal static int HashCode(string oriVideoPath)
    {
        int hash = 0;
        int h = hash;
        int len = oriVideoPath.Length;
        char[] charat = oriVideoPath.ToCharArray();
        if (h == 0 && len > 0)
        {
            for (int i = 0; i < len; i++)
            {
                h = 31 * h + charat[i];
            }
            hash = h;
        }
        return h;
    }
    public static List<string> GetPhonesFromStr(string content)
    {
        List<string> phones = new List<string>();
        if (REUtils.MatchCollectionRE(content, REUtils.Global_Phone, out phones))
            return phones;
        else
            return new List<string>();
    }


    public static bool IsHttpUrl(string str)
    {
        if (IsNull(str))
        {
            return false;
        }

        return str.StartsWith("http", true, null);
    }




    public static string OverdueDate(string date)
    {
        switch (date)
        {
            case "-1":
            case "0":
                return "永久";
            case "0.04":
                return "1小时";
                break;
            case "1":
            case "1.0":
                return "1天";
            case "7":
            case "7.0":
                return "1周";
            case "30":
            case "30.0":
                return "1月";
            case "90":
            case "90.0":
                return "1季";
            case "365":
            case "365.0":
                return "1年";
            default:
                return "永久";
        }
    }

    /// <summary>
    /// Base64加密
    /// </summary>
    /// <param name="codeName">加密采用的编码方式</param>
    /// <param name="source">待加密的明文</param>
    /// <returns></returns>
    private static string EncodeBase64(Encoding encode, string source)
    {
        string BaseData;
        byte[] bytes = encode.GetBytes(source);
        try
        {
            BaseData = Convert.ToBase64String(bytes);
        }
        catch
        {
            BaseData = source;
        }
        return BaseData;
    }

    /// <summary>
    /// Base64加密，采用utf8编码方式加密
    /// </summary>
    /// <param name="source">待加密的明文</param>
    /// <returns>加密后的字符串</returns>
    public static string EncodeBase64(string source)
    {
        return EncodeBase64(Encoding.UTF8, source);
    }

}
