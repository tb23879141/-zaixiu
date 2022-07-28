
//如果好用，请收藏地址，帮忙分享。
using System.Collections.Generic;

public class MyGroupActivity_ContentsItem
{
    /// <summary>
    /// 
    /// </summary>
    public string content { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long type { get; set; }
    public string oFileName { get; set; }
}

public class GroupActivity_Member
{
    /// <summary>
    /// 
    /// </summary>
    public string aid { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double money { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string nickName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string phone { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public long time { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string userId { get; set; }
}

public class MyGroupActivity
{
    /// <summary>
    /// 地址
    /// </summary>
    public string address { get; set; }

    public string contactPhone { get; set; }
    /// <summary>
    /// 是否收费
    /// </summary>
    public int charge { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string cover { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long endTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string forward { get; set; }
    /// <summary>
    /// 
    /// </summary>


    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isJoin { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int isMemberDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int isPublic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int isWatchDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long money { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string notice { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long payee { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long publishTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string activityGroupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string rule { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long signUpBegin { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long signUpEnd { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long time { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string webUrl { get; set; }
    public List<MyGroupActivity_ContentsItem> contents { get; set; }

}
