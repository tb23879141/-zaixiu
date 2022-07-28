using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class UploadEngine
{
    private Dictionary<string,int> cList;

    private UploadEngine()
    {
        cList = new Dictionary<string, int>();
    }

    private static UploadEngine _instance;
    public static UploadEngine Instance => _instance ?? (_instance = new UploadEngine());


    public UploadFileBuild From(string filePath)
    {
        var build = new UploadFileBuild(filePath);

        return build;

    }

    public bool isCancel(string path) {

        if (!cList.ContainsKey(path))
        {
            return false;
        }

        //cList[path] == -1;
        return false;
    }


    public void Push(string path) {
        
        if (!cList.ContainsKey(path))
        {
            cList.Add(path,0);
        }
    }


    public void Cancel(string path) {

        if (cList.ContainsKey(path))
        {
            cList[path] = -1;
        }

    }

    internal void Pop(string path)
    {
        //if (cList.ContainsKey(path))
        //{
        //    cList.Remove(path);
        //}
    }
}
