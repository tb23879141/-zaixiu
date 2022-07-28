using System;
using System.IO;
using System.Threading.Tasks;
using WinFrmTalk;

public static class HttpDownloader
{
    internal static void DownloadFile(string url, string path, Action<string> action)
    {
        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path))
        {
            action(null);
        }

        Task.Factory.StartNew(() =>
        {
            try
            {
                //如果对应文件存在 先删除文件(再下载文件)
                FileUtils.DeleteFile(path);

                HttpItem httpitem = new HttpItem()
                {
                    URL = url,
                    ResultType = ResultType.Byte
                };
                var result = new HTTP().GetHtml(httpitem);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)//服务器返回正常才处理字节
                {
                    if (!File.Exists(path))
                    {
                        //创建一个文件流
                        FileStream fs = new FileStream(path, FileMode.Create);
                        if (result.ResultByte != null)
                        {
                            //将byte数组写入文件中
                            fs.Write(result.ResultByte, 0, result.ResultByte.Length);
                            //所有流类型都要关闭流，否则会出现内存泄露问题
                            fs.Close();
                            fs.Dispose();
                            HttpUtils.Instance.Invoke(action, path);

                        }
                        else
                        {   //所有流类型都要关闭流，否则会出现内存泄露问题
                            fs.Close();
                            FileUtils.DeleteFile(path);
                            HttpUtils.Instance.Invoke(action, "");
                        }
                    }
                    else
                    {
                        HttpUtils.Instance.Invoke(action, path);
                    }
                }
                else
                {
                    HttpUtils.Instance.Invoke(action, path);
                }
            }
            catch (Exception)
            {
                HttpUtils.Instance.Invoke(action, "");
            }
        });
    }
}
