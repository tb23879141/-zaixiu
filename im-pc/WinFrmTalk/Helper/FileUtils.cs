using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebPWrapper;
using WinFrmTalk;
using WinFrmTalk.Properties;

public class FileUtils
{
    public object UnsafeNativeMethods { get; private set; }

    internal static string GetFileName(string url)
    {

        // 062f59e23d794343b24bfd63494f082b
        if (UIUtils.IsNull(url))
        {
            return "" + TimeUtils.CurrentTimeMillis();
        }

        try
        {
            int start = url.LastIndexOf("/");
            if (start == -1)
            {
                start = url.LastIndexOf("\\");
            }

            string name = url.Substring(start + 1);

            if (name.Contains("?") || name.Contains("="))
            {
                var ext = GetFileExtension(url);
                return Math.Abs(url.GetHashCode()).ToString() + ext;
            }

            return name;
        }
        catch (Exception)
        {
            LogUtils.Log("文件格式错误");
            return url.GetHashCode().ToString();
        }
    }

    internal static bool IsRecycled(Bitmap image)
    {
        if (image == null || image.PixelFormat == PixelFormat.DontCare || image.PixelFormat == PixelFormat.Undefined)
        {
            return true;
        }

        return false;
    }

    internal static Bitmap FileToBitmap(string filePath)
    {
        if (UIUtils.IsNull(filePath))
        {
            return null;
        }

        if (!File.Exists(filePath))
        {
            return null;
        }

        MemoryStream stream = null;
        try
        {
            // 打开文件
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            // 读取文件的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();

            // 增加支持显示webp格式图片 2019-12-24 15:22:00
            string extension = GetFileExtension(filePath);

            if (".webp".Equals(extension))
            {
                using (WebP webp = new WebP())
                    return webp.Decode(bytes);
            }
            else
            {
                if (bytes != null && bytes.Length > 13)
                {
                    var str = Encoding.UTF8.GetString(bytes, 8, 4);
                    if ("WEBP".Equals(str))
                    {
                        using (WebP webp = new WebP())
                            return webp.Decode(bytes);
                    }
                }
            }

            // 把 byte[] 转换成 Stream
            stream = new MemoryStream(bytes);
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);

            return new Bitmap(stream);
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
            }
        }
    }


    internal static string ReplaceSuffix(string fileName, string suffix)
    {
        string suf = Path.GetExtension(fileName);
        if (suf.Length == 0)
            return "error." + suffix;
        return fileName.Replace(suf, suffix);
    }


    public static string GetFileExtension(string filePath)
    {
        try
        {
            return Path.GetExtension(filePath);
        }
        catch (Exception)
        {

            return "";
        }

    }

    internal static void DeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch (Exception)
        {
        }
    }

    internal static int GetFileTypeByNanme(string url)
    {
        //获取文件的截取名字
        string suffix = Path.GetExtension(url);
        if (suffix == null || suffix == "")
        {
            return 9;
        }
        int type = 9;
        if (suffix == ".png" || suffix == ".jpg" || suffix == ".gif")
        {
            type = 1;
        }
        else if (suffix == ".mp3")
        {
            type = 2;
        }
        else if (suffix == ".mp4" || suffix == ".avi" || suffix == ".MP4")
        {
            type = 3;
        }
        else if (suffix == ".xls" || suffix == ".xlsx")
        {
            type = 5;
        }
        else if (suffix == ".doc" || suffix == ".docx")
        {
            type = 6;
        }
        else if (suffix == ".ppt" || suffix == ".pptx")
        {
            type = 4;
        }
        else if (suffix == ".pdf")
        {
            type = 10;
        }
        else if (suffix == ".apk")
        {
            type = 11;
        }
        else if (suffix == ".txt")
        {
            type = 8;
        }
        else if (suffix == ".rar" || suffix == ".zip")
        {
            type = 7;
        }
        else if (suffix == ".wav")
        {
            type = 55;
        }
        else if (suffix == ".amr")
        {
            type = 56;
        }

        else
        {
            type = 9;
        }

        return type;
    }


    /// <summary>
    /// 缩略图
    /// </summary>
    /// <param name="url"></param>
    /// <param name="incoImage"></param>
    public static Bitmap TypeFileToImage(string url)
    {
        int type = FileUtils.GetFileTypeByNanme(url);

        //图片
        if (type == 1)
        {
            return WindowsThumbnailProvider.GetThumbnail(url, 48, 48, ThumbnailOptions.None);
        }
        else if (type == 2)
        {
            //music
            return Resources.ic_muc_flie_type_y;

        }
        else if (type == 3)
        {
            //视频
            return Resources.ic_muc_flie_type_v;

        }
        else if (type == 4)
        {
            //ppt
            return Resources.ic_muc_flie_type_p;

        }
        else if (type == 5)
        {
            //xlse
            return Resources.ic_muc_flie_type_x;

        }
        else if (type == 6)
        {
            //world
            return Resources.ic_muc_flie_type_w;

        }
        else if (type == 7)
        {
            //zrp
            return Resources.ic_muc_flie_type_z;

        }
        else if (type == 8)
        {
            //txt
            return Resources.ic_muc_flie_type_t;

        }
        else if (type == 9)
        {
            //??
            return Resources.ic_muc_flie_type_what;
        }
        else if (type == 10)
        {
            //pdf
            return Resources.ic_muc_flie_type_f;

        }
        else if (type == 11)
        {

            return Resources.ic_muc_flie_type_a;

        }
        else if (type == 12)//红包
        {
            return Resources.ic_historyredpacket;

        }
        else if (type == 13)//转账
        {
            return Resources.ic_historytransfer;

        }
        else if (type == 56 || type == 55)
        {
            return Resources.ic_flie_type_voice;
        }

        return Resources.ic_muc_flie_type_what;
    }

    internal static void GetVideoThubImage(string oriVideoPath, string thubImagePath, Action<string> result)
    {
        ////避免因为cmd导致界面卡死
        Task.Factory.StartNew(() =>
        {
            //生成缩略图
            string ffmpegPath = Applicate.AppCurrentDirectory + @"ffmpeg.exe";
            int frameIndex = 1;     //第几帧

            //GetMovWidthAndHeight(oriVideoPath, out width, out height);
            string command = string.Format("\"{0}\" -i \"{1}\" -ss {2} -vframes 1 -r 1 -ac 1 -ab 2 -s {3}*{4} -f image2 \"{5}\"", ffmpegPath, oriVideoPath, frameIndex, 200, 200, thubImagePath);
            Cmd(command);

            HttpUtils.Instance.Invoke(result, oriVideoPath);
        });
    }


    /// <summary>
    /// 获取视频的帧宽度和帧高度
    /// </summary>
    /// <param name="videoFilePath">mov文件的路径</param>
    /// <returns>null表示获取宽度或高度失败</returns>
    public static void GetMovWidthAndHeight(string ffmpegPath, string videoFilePath, out int? width, out int? height)
    {
        try
        {
            //执行命令获取该文件的一些信息 
            string output;
            string error;
            ExecuteCommand("\"" + ffmpegPath + "\"" + " -i " + "\"" + videoFilePath + "\"", out output, out error);
            if (string.IsNullOrEmpty(error))
            {
                width = null;
                height = null;
            }
            //通过正则表达式获取信息里面的宽度信息
            Regex regex = new Regex("(\\d{2,4})x(\\d{2,4})", RegexOptions.Compiled);
            Match m = regex.Match(error);
            if (m.Success)
            {
                width = int.Parse(m.Groups[1].Value);
                height = int.Parse(m.Groups[2].Value);

                // 视频缩略图压缩
                if (width > 500 || height > 500)
                {
                    width = Convert.ToInt32(width * 0.5f);
                    height = Convert.ToInt32(height * 0.5f);
                }

                // 视频可能被旋转
                Regex rote = new Regex(@"rotation of (\S+)", RegexOptions.Compiled);
                Match m1 = rote.Match(error);
                if (m1.Success)
                {
                    var rotation = float.Parse(m1.Groups[1].Value);
                    if (rotation == 90 || rotation == -90)
                    {
                        width = height + width;
                        height = width - height;
                        width = width - height;
                    }
                }

            }
            else
            {
                width = null;
                height = null;
            }
        }
        catch (Exception)
        {
            width = null;
            height = null;
        }
    }


    /// <summary>
    /// 执行一条command命令
    /// </summary>
    /// <param name="command">需要执行的Command</param>
    /// <param name="output">输出</param>
    /// <param name="error">错误</param>
    public static void ExecuteCommand(string command, out string output, out string error)
    {
        try
        {
            //创建一个进程
            Process pc = new Process();
            pc.StartInfo.FileName = command;
            pc.StartInfo.UseShellExecute = false;
            pc.StartInfo.RedirectStandardOutput = true;
            pc.StartInfo.RedirectStandardError = true;
            pc.StartInfo.CreateNoWindow = true;

            //启动进程
            pc.Start();
            //准备读出输出流和错误流
            string outputData = string.Empty;
            string errorData = string.Empty;
            pc.BeginOutputReadLine();
            pc.BeginErrorReadLine();

            pc.OutputDataReceived += (ss, ee) =>
            {
                outputData += ee.Data;
            };
            pc.ErrorDataReceived += (ss, ee) =>
            {
                errorData += ee.Data;
            };

            //等待退出
            pc.WaitForExit();
            //关闭进程
            pc.Close();
            //返回流结果
            output = outputData;
            error = errorData;
        }
        catch (Exception)
        {
            output = null;
            error = null;
        }
    }

    /// <summary>
    /// 执行Cmd命令
    /// </summary>
    public static bool Cmd(string c)
    {
        try
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            process.StandardInput.WriteLine(c);
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("exit");
            StreamReader reader = process.StandardOutput;//截取输出流           
            process.WaitForExit(3000);
            process.Close();

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 判断文件是否为视频格式
    /// </summary>
    /// <param name="fileName">文件名或者路径</param>
    /// <returns></returns>
    public static bool JudgeIsVideoFile(string fileName)
    {
        string[] videoType = new string[] { ".mp4", ".avi", ".flv", ".rmvb" };
        string fileType = Path.GetExtension(fileName);
        return videoType.Contains(fileType);
    }


    public static bool JudgeIsImageFile(string fileName)
    {
        try
        {
            string extension = FileUtils.GetFileExtension(fileName);

            if (UIUtils.IsNull(extension))
            {
                return false;
            }

            if (string.Equals(".jpg", extension.ToLower()))
            {
                return true;
            }

            if (string.Equals(".jpeg", extension.ToLower()))
            {
                return true;
            }

            if (string.Equals(".gif", extension.ToLower()))
            {
                return true;
            }

            if (string.Equals(".png", extension.ToLower()))
            {
                return true;
            }

            if (string.Equals(".bmp", extension.ToLower()))
            {
                return true;
            }
            if (string.Equals(".jpeg", extension.ToLower()))
            {
                return true;
            }
            if (string.Equals(".webp", extension.ToLower()))
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            LogHelper.log.Error("----JudgeIsImage : " + ex.Message, ex);
        }
        return false;
    }



    /// <summary>
    /// 判断文件是否为音频格式
    /// </summary>
    /// <param name="fileName">文件名或者路径</param>
    /// <returns></returns>
    public static bool JudgeIsMusicFile(string fileName)
    {
        string[] videoType = new string[] { ".mp3" };
        string fileType = Path.GetExtension(fileName);
        return videoType.Contains(fileType);
    }

    /// <summary>
    /// 获取一个文件夹下所有的文件大小
    /// 建议放在子线程执行
    /// </summary>
    /// <param name="path"></param>
    /// <returns>文件大小</returns>
    public static long GetDirectorySize(string path)
    {
        long size = 0;
        if (Directory.Exists(path))
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] dirs = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();
            foreach (var item in dirs)
            {
                size += GetDirectorySize(item.FullName);
            }

            foreach (var item in files)
            {
                size += item.Length;
            }
        }

        // 如果需要格式化文件大小  UIutils.FromatFileSize

        return size;
    }


    /// <summary>
    /// 清除缓存
    /// 删除某个文件夹下所有的文件，而不删除文件夹
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <returns></returns>
    public static void ClearAppCacheFile(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            DirectoryInfo[] dirs = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();
            foreach (var item in dirs)
            {
                ClearAppCacheFile(item.FullName);
            }

            foreach (var item in files)
            {
                try
                {
                    item.Delete();
                }
                catch (Exception)
                {
                    Console.WriteLine("删除文件失败：" + item.FullName);
                }
            }
        }
    }

    internal static bool IsGif(string path)
    {
        //获取文件的截取名字
        string suffix = Path.GetExtension(path);
        return suffix == ".gif";
    }
}
