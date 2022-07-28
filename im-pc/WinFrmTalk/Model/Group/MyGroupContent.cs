using System.Collections.Generic;

public class MyGroupResource
{

    /// <summary>
    /// 测试
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// 测试
    /// </summary>
    public string title { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string url { get; set; }

    /// <summary>
    /// 测试
    /// </summary>
    public string subTitle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string imageUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string appIcon { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string appName { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }

}


public class SolitaireData
{

    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// 接龙格式
    /// </summary>
    public string example { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string jid { get; set; }
    /// <summary>
    /// 接龙说明：222
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<SolitaireMember> solitaireBodies { get; set; }
}


public class SolitaireMember
{
    /// <summary>
    /// 
    /// </summary>
    public string body { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string userId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string userName { get; set; }
}