using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.Controls;
using WinFrmTalk.Properties;

/// <summary>
/// 视频缩略图加载器
/// </summary>
public class ThubImageLoader
{
    // 单例模式 
    private ThubImageLoader()
    {
    }

    private static ThubImageLoader _instance;
    public static ThubImageLoader Instance => _instance ?? (_instance = new ThubImageLoader());

    public void Load(string videoUrl, PictureBox picture, Action<bool, int, int> action = null)
    {
        if (picture == null || string.IsNullOrEmpty(videoUrl))
        {
            return;
        }

        // 判断视频是否存在
        string thubImagePath = Applicate.LocalConfigData.TempFilepath + FileUtils.ReplaceSuffix(FileUtils.GetFileName(videoUrl), ".jpg");      //保存的缩略图路径

        // 判断视频缩略图是否存在
        if (File.Exists(thubImagePath))
        {
            Bitmap bit = ToImageByView(thubImagePath, picture);
            if (!BitmapUtils.IsNull(bit))
                action?.Invoke(true, bit.Width, bit.Height);
            return;
        }


        string defPath = Applicate.AppCurrentDirectory + "Resources\\ic_black_rect.png";
        ToImageByView(defPath, picture);

        ////避免因为cmd导致界面卡死
        Task.Factory.StartNew(() =>
        {
            //生成缩略图
            string ffmpegPath = Applicate.AppCurrentDirectory + @"ffmpeg.exe";
            int? width, height;

            FileUtils.GetMovWidthAndHeight(ffmpegPath, videoUrl, out width, out height);

            if (width == null || width == 0)
            {
                // 出错了， 说明视频地址不正确
            }
            else
            {
                string size = width + "x" + height;

                string cmd = GenerateVideo2ImageCmd(ffmpegPath, videoUrl, size, thubImagePath);
                bool success = FileUtils.Cmd(cmd);

                HttpUtils.Instance.Invoke(new Action(() =>
                {
                    ToImageByView(thubImagePath, picture);
                    action?.Invoke(true, width.Value, height.Value);
                }));
            }


            Console.WriteLine("获取成功" + thubImagePath);
        });

    }

    /// <summary>
    /// 这个方法只加载略缩图 不在拼合播放图标，请使用imageviewxvideo 控件
    /// </summary>
    /// <param name="videoUrl"></param>
    /// <param name="picture"></param>
    /// <param name="action"></param>
    public void LoadImage(string videoUrl, ImageViewxVideo picture)
    {
        if (picture == null || string.IsNullOrEmpty(videoUrl))
        {
            return;
        }

        // 判断视频是否存在
        string thubImagePath = Applicate.LocalConfigData.TempFilepath + FileUtils.ReplaceSuffix(FileUtils.GetFileName(videoUrl), ".jpg");

        // 判断视频缩略图是否存在
        if (File.Exists(thubImagePath))
        {
            Bitmap image = FileUtils.FileToBitmap(thubImagePath);
            picture.Image = image;
            return;
        }

        picture.Loding();

        ////避免因为cmd导致界面卡死
        Task.Factory.StartNew(() =>
        {
            //生成缩略图
            string ffmpegPath = Applicate.AppCurrentDirectory + @"ffmpeg.exe";
            int? width, height;

            FileUtils.GetMovWidthAndHeight(ffmpegPath, videoUrl, out width, out height);
            if (width == null || width == 0)
            {
                // 出错了， 说明视频地址不正确
                HttpUtils.Instance.Invoke(new Action(() =>
                {
                    picture.Error();
                }));
            }
            else
            {
                string size = width + "x" + height;
                string cmd = GenerateVideo2ImageCmd(ffmpegPath, videoUrl, size, thubImagePath);
                bool success = FileUtils.Cmd(cmd);
                HttpUtils.Instance.Invoke(new Action(() =>
                {
                    if (success)
                    {
                        Bitmap image = FileUtils.FileToBitmap(thubImagePath);
                        if (BitmapUtils.IsNull(image))
                        {
                            picture.Error();
                        }
                        else
                        {
                            picture.Image = image;
                        }

                  
                    }
                    else
                    {
                        picture.Error();
                    }
                }));
            }
        });

    }


    private Bitmap ToImageByView(string thubImagePath, PictureBox picture)
    {
        Bitmap bitmap = null;// ImageCacheManager.Instance.GetCacheImage(thubImagePath);
        if (bitmap != null)
        {
            picture.BackgroundImage = bitmap;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.Cursor = Cursors.Hand;
        }
        else
        {
            bitmap = EQControlManager.getMixImage(0.80F, Resources.jc_play_normal, thubImagePath);
            picture.BackgroundImage = bitmap;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.Cursor = Cursors.Hand;
            // ImageCacheManager.Instance.PutImageCache(thubImagePath, bitmap);
        }
        return bitmap;
    }


    public string GenerateVideo2ImageCmd(string ffmpegPath, string videoUrl, string size, string outImagePaht)
    {
        //string cmd = ffmpegPath + " -i " + videoUrl + " -y -f mjpeg -ss 3 -t 0.001 -s " + size + " " + thubImagePath;
        // 有些路劲获取不了：http://47.91.232.3:8089/u/7332/10017332/201910/c03d35f0ff694cbb8acdc82e6bbb74a8.mp4
        //string cmd = ffmpegPath + " -i " + videoUrl + " -y -f mjpeg -ss 3 -t 0.02 -s " + size + " " + thubImagePath;
        string cmd = ffmpegPath + " -i " + videoUrl + " -y -f image2 -ss 1 -t 0.02 -s " + size + " " + outImagePaht;
        return cmd;
    }
}
