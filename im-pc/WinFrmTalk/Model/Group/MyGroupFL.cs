using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
//如果好用，请收藏地址，帮忙分享。
public class MyGroupFL_SubclassListItem
{
    /// <summary>
    /// 
    /// </summary>
    public int cid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string cname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string englishName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string fullName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int parentId { get; set; }
}

public class MyGroupFLModel
{
    /// <summary>
    /// 
    /// </summary>
    public string englishName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<MyGroupFL_SubclassListItem> subclassList { get; set; }
}
