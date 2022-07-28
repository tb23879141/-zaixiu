using System;
using System.IO;
using System.Threading.Tasks;

namespace WinFrmTalk.API.image
{
    public class ImageDownloader
    {
        // 单例模式 
        private ImageDownloader()
        {

        }

        private static ImageDownloader _instance;
        public static ImageDownloader Instance => _instance ?? (_instance = new ImageDownloader());

        private static object _object = new object();

        public void DownloadImage(string url, string path, Action<string> action)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path))
            {
                action(null);
                return;
            }

            lock (_object)
            {
                DownImage(url, path, action);
            }

        }

        private void DownImage(string url, string path, Action<string> action)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    HttpItem httpitem = new HttpItem()
                    {
                        URL = url,
                        ResultType = ResultType.Byte
                    };
                    var result = new HTTP().GetHtml(httpitem);

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)//服务器返回正常才处理字节
                    {
                        //if (!File.Exists(path))
                        //{
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
                            fs.Dispose();
                            HttpUtils.Instance.Invoke(action, "");
                        }
                        //}
                        //else
                        //{
                        //    HttpUtils.Instance.Invoke(action, path);
                        //}
                    }
                    else
                    {
                        HttpUtils.Instance.Invoke(action, "");
                    }
                }
                catch (Exception)
                {
                    HttpUtils.Instance.Invoke(action, "");
                }
            });
        }
    }
}
