using System.Collections.Generic;

public class MyGroupNotice
{
    /// <summary>
    ///// 
    ///// </summary>
    //public string forward { get; set; }
    ///// <summary>
    ///// 
    ///// </summary>
    //public string forwardId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 允许群成员下载 0允许默认 1不允许
    /// </summary>
    public int isMemberDownload { get; set; }
    /// <summary>
    /// 是否公开显示 0公开默认 1不公开
    /// </summary>
    public int isPublic { get; set; }
    /// <summary>
    /// 允许围观者下载 0允许默认 1不允许
    /// </summary>
    public int isWatchDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int modifyTime { get; set; }
    /// <summary>
    /// 测试账号1
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roomId { get; set; }
    /// <summary>
    /// 见到你都不吃你从哪辛苦
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long time { get; set; }
    /// <summary>
    /// 公告公告123
    /// </summary>
    public string title { get; set; }
    public string shareURL { get; set; }


    public List<string> picPath { get; set; }

    public string url { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int userId { get; set; }
}
