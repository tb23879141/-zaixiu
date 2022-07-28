using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

//如果好用，请收藏地址，帮忙分享。
public class MyGroupFolder_Resource
{
    /// <summary>
    /// 
    /// </summary>
    public long length { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string oUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long size { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string tUrl { get; set; }
}

public class GroupShareListItem
{
    /// <summary>
    /// 
    /// </summary>
    public string folderId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string forward { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string forwardId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> forwardInfoList { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isMemberDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isPublic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isWatchDownload { get; set; }
    /// <summary>
    /// 测试账号1
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MyGroupFolder_Resource resource { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string shareId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long time { get; set; }
    /// <summary>
    /// 测试
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string url { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userId { get; set; }
}

public class MyGroupFolder
{
    /// <summary>
    /// 
    /// </summary>
    public string folderId { get; set; }
/// <summary>
/// 信息发布
/// </summary>
public string folderName { get; set; }
/// <summary>
/// 
/// </summary>
public List<GroupShareListItem> groupShareList { get; set; }
/// <summary>
/// 
/// </summary>
public string roomId { get; set; }
/// <summary>
/// 
/// </summary>
public long updateTime { get; set; }
/// <summary>
/// 
/// </summary>
public long userId { get; set; }
}

 