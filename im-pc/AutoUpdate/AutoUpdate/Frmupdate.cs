using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace AutoUpdate
{
    public partial class Frmupdate : Form
    {
        [DllImport("zipfile.dll")]
        public static extern int MyZip_ExtractFileAll(string zipfile, string pathname);
        public Frmupdate()
        {
            InitializeComponent();
        }

        private void Download()
        {
            string savePaht = Application.StartupPath + "\\tnshow_Setup.zip";//下载到哪个路径
            //读取下载地址
            FileStream fsRead = new FileStream("Download.config", FileMode.OpenOrCreate);
            int fsLen = (int)fsRead.Length;
            byte[] heByte = new byte[fsLen];
            int r = fsRead.Read(heByte, 0, heByte.Length);
            string myStr = System.Text.Encoding.UTF8.GetString(heByte);
            fsRead.Close();
            if (string.IsNullOrEmpty(myStr))
            {
                // myStr = Applicate.URLDATA.data.pcAppUrl;
            }

            //开始下载
            DownloadEngine.Instance.DownUrl(myStr).SetMainControl(this)
              .DownProgress((pro) =>
              {
                  progressBar1.Value = pro;
                  label1.Text = pro + "%";
              }).SavePath(savePaht).Down(
                  (path) =>
                  {
                      if (path.Equals(savePaht))
                      {
                          label2.Text = "下载成功，正在解压";
                          Thread t = new Thread(() =>
                          {
                              string err = String.Empty;

                                  //FastZip fastZip = new FastZip();
                                  //fastZip.ExtractZip(savePaht, Application.StartupPath, "");
                                  app_UpdateFinish(savePaht);
                                  //将下载下来的文件进行替换
                                  //  string exepath=  ZipToFile(savePaht, Application.StartupPath, out err);//解压
                                  //      if (!string.IsNullOrEmpty(err))
                                  //    {
                                  //        MessageBox.Show("解压出错,原因：" + err);
                                  //    }

                                  //    this.Invoke(new Action(() => { label2.Text = "解压成功，启动中。。。"; }));

                                  //    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                  //    process.StartInfo.FileName = "WinFrmTalk.exe";
                                  //    process.StartInfo.WorkingDirectory = exepath;//要掉用得exe路径例如:"C:\windows";               
                                  //    process.StartInfo.CreateNoWindow = true;
                                  //    process.Start();
                                  //    this.Invoke(new Action(() =>
                                  //    {
                                  //        this.Close();
                                  //        File.Delete(savePaht);

                                  //    }));
                              });
                          t.Start();
                      }

                  });

        }

        /// <summary>
        /// 下载完成后
        /// </summary>
        /// <param name="path">解压后的路径</param>
        void app_UpdateFinish(string path)
        {
            //解压下载后的文件
            if (File.Exists(path))
            {
                //后改的 先解压滤波zip植入ini然后再重新压缩
                string dirEcgPath = Application.StartupPath + "\\" + "autoupload";
                if (!Directory.Exists(dirEcgPath))
                {
                    Directory.CreateDirectory(dirEcgPath);
                }
                //开始解压压缩包
                //MyZip_ExtractFileAll(path, dirEcgPath);
                FastZip fastZip = new FastZip();
                fastZip.ExtractZip(path, dirEcgPath, "");



                try
                {
                    //复制新文件替换旧文件
                    dirEcgPath += "\\" + "Debug";
                    DirectoryInfo TheFolder = new DirectoryInfo(dirEcgPath);
                    //如果文件被占用就不复制
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        if (!IsFileInUse(Application.StartupPath + "\\" + NextFile.Name))
                            File.Copy(NextFile.FullName, Application.StartupPath + "\\" + NextFile.Name, true);
                        else
                        {

                        }
                    }
                    Directory.Delete(dirEcgPath, true);
                    File.Delete(path);
                    //覆盖完成 重新启动程序
                    path = Application.StartupPath;
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "WinFrmTalk.exe";
                    process.StartInfo.WorkingDirectory = path;//要掉用得exe路径例如:"C:\windows";               
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    Application.Exit();
                }
                catch (Exception e)
                {
                    MessageBox.Show("请关闭系统在执行更新操作!");
                    WriteLog(e);
                    Console.WriteLine(e.Message);
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteLog(Exception ex)
        {
            //如果日志文件为空，则默认在Debug目录下新建YYYY-mm-dd_Log.log文件
            string LogAddress = Environment.CurrentDirectory + '\\'
                 + DateTime.Now.Year.ToString()
                 + DateTime.Now.Month.ToString()
                 + DateTime.Now.Day.ToString() + "_Log.log";
            if (!File.Exists(LogAddress))
            {
                FileStream fs = new FileStream(LogAddress, FileMode.Create, FileAccess.Write);
                //把异常信息输出到文件
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine("当前时间：" + DateTime.Now.ToString());
                sw.WriteLine("异常信息：" + ex.Message);
                sw.WriteLine("异常对象：" + ex.Source);
                sw.WriteLine("调用堆栈：" + ex.StackTrace.Trim());
                sw.WriteLine("触发方法：" + ex.TargetSite);
                sw.WriteLine();

                sw.Close();
                fs.Close();
            }
            else
            {
                //把异常信息输出到文件
                FileStream fs = new FileStream(LogAddress, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("当前时间：" + DateTime.Now.ToString());
                sw.WriteLine("异常信息：" + ex.Message);
                sw.WriteLine("异常对象：" + ex.Source);
                sw.WriteLine("调用堆栈：" + ex.StackTrace.Trim());
                sw.WriteLine("触发方法：" + ex.TargetSite);
                sw.WriteLine();

                sw.Close();
                fs.Close();
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = false;

            IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                inUse = true;
            }
            CloseHandle(vHandle);


            //FileStream fs = null;
            //try
            //{
            //    fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            //    inUse = false;
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    if (fs != null)
            //    {
            //        fs.Close();
            //    }
            //}
            return inUse;//true表示正在使用,false没有使用  
        }
        private void Frmupdate_Load(object sender, EventArgs e)
        {
            Download();
        }
    }
}
