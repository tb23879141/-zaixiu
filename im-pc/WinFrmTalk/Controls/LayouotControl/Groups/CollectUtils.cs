using Newtonsoft.Json.Linq;
using System;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{

    /// <summary>
    /// 新的群组资源收藏
    /// 外层的type 1图片，2视频，3文件，4音乐，5其他
    /// 收藏的collectType  收藏type; -1:消息无关的收藏,0:消息收藏 ,1：秀友圈收藏,2：秀吧收藏,3：资源信息收藏,4：活动收藏,5：公告收藏
    /// </summary>
    internal class GroupCollectUtils
    {
        internal static string GetNotifyParams(MyGroupNotice itemData)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("title", itemData.title);
            data.Add("msgId", itemData.id);
            data.Add("msg", itemData.text);
            data.Add("collectType", "5");
            data.Add("type", "5");
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        internal static string GetActiveParams(MyGroupActivity itemData)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("title", itemData.title);
            data.Add("msgId", itemData.id);
            data.Add("collectType", "4");
            data.Add("type", "5");
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        internal static string GetFileParams(string url, float size)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("msg", url);
            data.Add("url", url);
            data.Add("folad", FileUtils.GetFileName(url));
            data.Add("type", "3");
            data.Add("fileSize", Convert.ToString(size));
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        internal static string GetVideoParams(string url, long size)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("msg", url);
            data.Add("url", url);
            data.Add("folad", FileUtils.GetFileName(url));
            data.Add("fileName", FileUtils.GetFileName(url));
            data.Add("type", "2");
            data.Add("fileSize", Convert.ToString(size));
            jSONArray.Add(data);
            return jSONArray.ToString();
        }

        internal static string GetImageParams(string url)
        {
            JArray jSONArray = new JArray();
            JObject data = new JObject();
            data.Add("msg", url);
            data.Add("url", url);
            data.Add("folad", FileUtils.GetFileName(url));
            data.Add("type", "1");
            jSONArray.Add(data);
            return jSONArray.ToString();
        }
    }
}
