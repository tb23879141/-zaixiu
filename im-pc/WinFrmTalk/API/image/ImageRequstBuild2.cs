using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.API.image;

public class ImageRequstBuild2
{
    private ImageLoadConfig mConfig;
    private string mLoadUrl;
    private PictureBox mImageView;
    private bool isRefresh;


    public ImageRequstBuild2(ImageLoadConfig con)
    {
        ImageLoadConfig config = con.Copy();
        this.mConfig = config;
    }

    internal void LoadUrl(string url)
    {
        mLoadUrl = url;
    }

    public ImageRequstBuild2 Refresh()
    {
        isRefresh = true;
        return this;
    }


    internal void Execute()
    {

        if (string.IsNullOrEmpty(mLoadUrl))
        {
            LogUtils.Log("下载地址为空");
            ToView(null, null);
            return;
        }


        if (isRefresh)
        {
            ImageCacheManager.Instance.ClearImageCache(mLoadUrl);
        }


        if (!mConfig.noReadCache)
        {
            // 从内存加载
            Bitmap bitmap = ImageCacheManager.Instance.GetCacheImage(mLoadUrl);
            if (bitmap != null)
            {

                string path = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(mLoadUrl);
                ToView(bitmap, path);

                return;
            }

            // 从本地加载
            string fileName = FileUtils.GetFileName(mLoadUrl);
            string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;
            bitmap = FileUtils.FileToBitmap(filePath);
            if (bitmap != null)
            {
                // 保存到内存
                if (mConfig.isAvatar)
                {
                    ImageCacheManager.Instance.PutImageCache(mLoadUrl, bitmap);
                }

                ToView(bitmap, filePath);

                return;
            }
        }


        if (IsFIlePath(mLoadUrl)) // 一个本地路径文件，直接从本地获取
        {
            Bitmap bitmap = FileUtils.FileToBitmap(mLoadUrl);
            if (bitmap != null)
            {
                // 保存到内存
                if (mConfig.isAvatar)
                {
                    ImageCacheManager.Instance.PutImageCache(mLoadUrl, bitmap);
                }

                ToView(bitmap, mLoadUrl);
            }
            else
            {
                ToView(null, null);
            }

        }
        else
        {

            if (mConfig.bitLoading != null && mImageView != null)
            {
                SetImage(mConfig.bitLoading);
            }

            // 从本地加载
            string fileName = FileUtils.GetFileName(mLoadUrl);
            string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;
            // 最后从网络加载 保存到本地 => 保存到内存 
            ImageDownloader.Instance.DownloadImage(mLoadUrl, filePath, (down) =>
            {
                if (!string.IsNullOrEmpty(down))
                {
                    //Console.WriteLine("从网络中取到的图片");

                    Bitmap image = FileUtils.FileToBitmap(down);

                    ToView(image, down);

                    // 保存到内存
                    if (mConfig.isAvatar)
                    {
                        ImageCacheManager.Instance.PutImageCache(mLoadUrl, image);
                    }
                }
                else
                {
                    if (mConfig.isAvatar)
                    {
                        ImageCacheManager.Instance.PutImageCache(mLoadUrl, mConfig.bitErr);
                    }

                    LogUtils.Log("下载失败：" + filePath);
                    ToView(null, null);
                }

            });
        }
    }



    internal void Into(PictureBox view)
    {
        mImageView = view;
        Execute();
    }

    internal void Into(Action<Bitmap, string> action)
    {
        mConfig.onResponse = action;
        Execute();
    }

    internal ImageRequstBuild2 Error(Bitmap bitmap)
    {
        mConfig.bitErr = bitmap;
        return this;
    }


    internal ImageRequstBuild2 Tag(string mark)
    {
        mConfig.tag = mark;
        return this;
    }

    internal ImageRequstBuild2 Error(Action<string> errAction)
    {
        mConfig.onError = errAction;
        return this;
    }

    internal ImageRequstBuild2 Loading(Bitmap bitmap)
    {
        mConfig.bitLoading = bitmap;
        return this;
    }

    internal ImageRequstBuild2 NoCache()
    {
        //mConfig.isCache = false;
        return this;
    }

    internal ImageRequstBuild2 NoReadCache()
    {
        mConfig.noReadCache = true;
        return this;
    }

    internal ImageRequstBuild2 CompteListener(Action<Bitmap> action)
    {
        mConfig.OnCompte = action;
        return this;
    }



    private bool IsFIlePath(string url)
    {
        return File.Exists(url);
    }

    private void ToView(Bitmap bitmap, string path)
    {
        if (BitmapUtils.IsNull(bitmap))
        {


            // 下载出错情况
            SetImage(mConfig.bitErr);

            mConfig.onError?.Invoke("下载出错");
        }
        else
        {
            // 下载成功
            SetImage(bitmap, path);

            mConfig.onResponse?.Invoke(bitmap, path);
        }


    }


    public void SetImage(Bitmap bitmap, string path = "")
    {

        if (bitmap == null)
        {
            return;
        }

        OnCompte(bitmap);

        if (mImageView != null)
        {
            if (!UIUtils.IsNull(path) && bitmap.RawFormat.Equals(ImageFormat.Gif))
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Image img = Image.FromStream(fs);
                mImageView.Image = img;
            }
            else
            {
                mImageView.Image = bitmap;
            }
        }
    }


    private void OnCompte(Bitmap bitmap)
    {
        bitmap.Tag = mConfig.tag;
        mConfig.OnCompte?.Invoke(bitmap);

    }
}