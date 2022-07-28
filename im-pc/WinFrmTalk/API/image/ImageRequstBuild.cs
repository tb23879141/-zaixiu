using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.API.image;

public class ImageRequstBuild
{
    private ImageLoadConfig mConfig;
    private string mLoadUrl;
    private PictureBox mImageView;
    private Panel mPanelView;
    private bool isBackground;
    private bool isRefresh;


    public ImageRequstBuild(ImageLoadConfig con)
    {
        ImageLoadConfig config = con.Copy();
        this.mConfig = config;
    }

    internal void LoadUrl(string url)
    {
        mLoadUrl = url;
    }

    public ImageRequstBuild Refresh()
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


        if (mConfig.noReadCache)
        {
            // 直接从网络加载
            string fileName = FileUtils.GetFileName(mLoadUrl);
            if (mConfig.isThum)
            {
                fileName = GetThumFileName(fileName);
            }
            string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;
            // 最后从网络加载 保存到本地 => 保存到内存 
            ImageDownloader.Instance.DownloadImage(mLoadUrl, filePath, (down) =>
            {
                if (!string.IsNullOrEmpty(down))
                {
                    Bitmap image = FileUtils.FileToBitmap(down);
                    if (image == null)
                    {
                        ToView(image, down);
                    }
                    else
                    {
                        LogUtils.Log("下载失败：" + filePath);
                        ToView(null, null);
                    }
                }
                else
                {
                    LogUtils.Log("下载失败：" + filePath);
                    ToView(null, null);
                }
            });
        }


        if (IsFIlePath(mLoadUrl)) // 一个本地路径文件，直接从本地获取
        {
            Bitmap bitmap = FileUtils.FileToBitmap(mLoadUrl);
            if (bitmap != null)
            {
                ToView(bitmap, mLoadUrl);
            }
            else
            {
                ToView(null, null);
            }
        }
        else
        {
            // 绘制加载中
            if (mConfig.bitLoading != null && mImageView != null)
            {
                SetImage(mConfig.bitLoading);
            }


            // 从内存加载
            Bitmap bitmap = ImageCacheManager.Instance.GetCacheImage(mLoadUrl);
            if (!BitmapUtils.IsNull(bitmap))
            {
                string path = Applicate.LocalConfigData.ImageFolderPath + FileUtils.GetFileName(mLoadUrl);
                ToView(bitmap, path);
                return;
            }

            // 从本地加载
            string fileName = FileUtils.GetFileName(mLoadUrl);
            if (mConfig.isThum)
            {
                fileName = GetThumFileName(fileName);
            }
            string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;

            if (File.Exists(filePath))
            {
                bitmap = FileUtils.FileToBitmap(filePath);
                if (!BitmapUtils.IsNull(bitmap))
                {
                    if (mConfig.isAvatar)
                    {
                        if (mImageView != null)
                        {
                            bitmap = BitmapUtils.GetRoundImage(bitmap, mImageView.Width, mImageView.Width, mConfig.isAvatar, isGray);
                        }
                        else
                        {
                            bitmap = BitmapUtils.GetRoundImage(bitmap, mConfig.isAvatar, isGray);
                        }
                    }

                    ToView(bitmap, filePath);

                    // 保存到内存
                    if (mConfig.isAvatar)
                    {
                        ImageCacheManager.Instance.PutImageCache(mLoadUrl, bitmap);
                    }
                    return;
                }
            }


            // 最后从网络加载 保存到本地 => 保存到内存 
            ImageDownloader.Instance.DownloadImage(mLoadUrl, filePath, (down) =>
            {
                bitmap = FileUtils.FileToBitmap(down);

                if (!BitmapUtils.IsNull(bitmap))
                {
                    if (mConfig.isAvatar)
                    {
                        if (mImageView != null)
                        {
                            bitmap = BitmapUtils.GetRoundImage(bitmap, mImageView.Width, mImageView.Width, mConfig.isAvatar, isGray);
                        }
                        else
                        {
                            bitmap = BitmapUtils.GetRoundImage(bitmap, mConfig.isAvatar, isGray);
                        }
                    }

                    ToView(bitmap, down);

                    // 保存到内存
                    if (mConfig.isAvatar)
                    {
                        ImageCacheManager.Instance.PutImageCache(mLoadUrl, bitmap);
                    }
                }
                else
                {
                    if (mConfig.isAvatar && !UIUtils.IsNull(drawText))
                    {
                        if (mImageView != null)
                        {
                            bitmap = BitmapUtils.CreateRoundText(drawText, mImageView.Width + mImageView.Width, mImageView.Height + mImageView.Height);
                        }
                        else
                        {
                            bitmap = BitmapUtils.CreateRoundText(drawText, 128, 128);
                        }
                        LogUtils.Log("下载失败：" + filePath);
                        ToView(bitmap, null);
                        return;
                    }

                    if (mConfig.isAvatar)
                    {
                        ImageCacheManager.Instance.PutImageCache(mLoadUrl, mConfig.bitErr);
                        LogUtils.Log("下载失败：" + filePath);
                        ToView(mConfig.bitErr, null);
                        return;
                    }

                    LogUtils.Log("下载失败：" + filePath);
                    ToView(null, null);
                }

            });
        }
    }

    private string GetThumFileName(string fileName)
    {

        string pa = "t\\" + fileName;

        return pa;
    }

    internal void Into(PictureBox view, Panel panel = null)
    {
        mImageView = view;
        mPanelView = panel;
        Execute();
    }

    internal void Into(Action<Bitmap, string> action)
    {
        mConfig.onResponse = action;
        Execute();
    }

    // save path
    internal void Save(Action<string> action)
    {


        if (UIUtils.IsNull(mLoadUrl))
        {
            action.Invoke("");
        }



        if (IsFIlePath(mLoadUrl)) // 一个本地路径文件，直接从本地获取
        {
            action.Invoke(mLoadUrl);
            return;
        }
        else
        {

            // 从本地加载
            string fileName = FileUtils.GetFileName(mLoadUrl);
            string filePath = Applicate.LocalConfigData.ImageFolderPath + fileName;

            if (File.Exists(filePath))
            {
                action.Invoke(filePath);
                return;
            }


            // 最后从网络加载 保存到本地 => 保存到内存 
            ImageDownloader.Instance.DownloadImage(mLoadUrl, filePath, (down) =>
            {
                if (!string.IsNullOrEmpty(down))
                {
                    action.Invoke(down);

                }
                else
                {
                    action.Invoke("");
                }

            });
        }

    }

    internal ImageRequstBuild Error(Bitmap bitmap)
    {
        mConfig.bitErr = bitmap;
        return this;
    }

    private string drawText;
    internal ImageRequstBuild Error(string text)
    {
        this.drawText = text;
        return this;
    }


    internal ImageRequstBuild Avatar()
    {
        mConfig.isAvatar = true;
        return this;
    }

    internal ImageRequstBuild Tag(string mark)
    {
        mConfig.tag = mark;
        return this;
    }

    internal ImageRequstBuild Error(Action<string> errAction)
    {
        mConfig.onError = errAction;
        return this;
    }

    internal ImageRequstBuild Loading(Bitmap bitmap)
    {
        mConfig.bitLoading = bitmap;
        return this;
    }

    internal ImageRequstBuild NoCache()
    {
        return this;
    }

    private bool isGray;
    internal ImageRequstBuild Gray()
    {
        isGray = true;
        return this;
    }

    internal ImageRequstBuild IsThum()
    {
        mConfig.isThum = true;
        return this;
    }

    internal ImageRequstBuild NoReadCache()
    {
        mConfig.noReadCache = true;
        return this;
    }

    internal ImageRequstBuild CompteListener(Action<Bitmap> action)
    {
        mConfig.OnCompte = action;
        return this;
    }

    internal ImageRequstBuild Background()
    {
        isBackground = true;
        return this;
    }

    private bool IsFIlePath(string url)
    {
        return File.Exists(url);
    }

    private bool CropCenter = false;
    internal ImageRequstBuild Center()
    {
        CropCenter = true;
        return this;
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
            if (isBackground)
            {
                //HttpUtils.Instance.Invoke(new Action(()=> {
                //    mImageView.BackgroundImage = bitmap;
                //}));
                // mImageView.BackgroundImage = bitmap;
                if (!UIUtils.IsNull(path) && bitmap.RawFormat.Equals(ImageFormat.Gif))
                {
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    Image img = Image.FromStream(fs);
                    Bitmap image = new Bitmap(img);
                    if (image != bitmap)
                    {
                        mImageView.BackgroundImage = bitmap;
                        if (mPanelView != null) mPanelView.BackgroundImage = bitmap;
                    }
                    else
                    {
                        mImageView.BackgroundImage = img;
                        if (mPanelView != null) mPanelView.BackgroundImage = img;
                    }
                }
                else
                {
                    mImageView.BackgroundImageLayout = ImageLayout.Zoom;
                    mImageView.BackgroundImage = bitmap;
                    if (mPanelView != null) mPanelView.BackgroundImage = bitmap;
                }

            }
            else
            {
                //HttpUtils.Instance.Invoke(new Action(() => {
                //    mImageView.Image = bitmap;
                //}));
                if (!UIUtils.IsNull(path) && bitmap.RawFormat.Equals(ImageFormat.Gif))
                {
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    Image img = Image.FromStream(fs);
                    mImageView.Image = img;
                    if (mPanelView != null) mPanelView.BackgroundImage = img;
                }
                else
                {
                    if (CropCenter)
                    {
                        mImageView.Image = CropCenterRect(bitmap, mImageView.Width, mImageView.Height);
                    }
                    else
                    {
                        if (mConfig.isAvatar)
                        {
                            mImageView.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        mImageView.Image = bitmap;
                    }
                    if (mPanelView != null) mPanelView.BackgroundImage = bitmap;
                }

                //mImageView.Image = bitmap;
            }
        }

    }

    // 居中缩放
    private Image CropCenterRect(Image image, float width, float height)
    {
        //得到图片斜率
        float image_scale = (float)image.Width / image.Height;
        //得到容器斜率
        float dest_scale = width / height;

        float img_width = image.Width;
        float img_height = image.Height;

        if (img_width > 3000 || img_height > 3000)
        {
            img_width = img_width * 0.45f;
            img_height = img_height * 0.45f;
        }


        float new_width = img_width;
        float new_height = img_height;

        if (Math.Abs(image_scale - dest_scale) < 0.01)
        {
            // 斜率相同，直接缩放就行
            new_width = img_width;
            new_height = img_height;
        }
        else
        {
            // 新的矩形框
            new_width = img_height / height * width;
            new_height = img_height;
            if (new_width > img_width || new_height > img_height)
            {
                // 以宽度计算
                new_height = img_width / width * height;
                new_width = img_width;
            }
        }

        Bitmap bm = new Bitmap((int)new_width, (int)new_height);
        using (Graphics g = Graphics.FromImage(bm))
        {
            var srcRect = new RectangleF((img_width - new_width) / 2, (img_height - new_height) / 2, new_width, new_height);
            var descRect = new Rectangle(0, 0, bm.Width, bm.Height);
            g.DrawImage(image, descRect, srcRect, GraphicsUnit.Pixel);
        }
        return bm;
    }


    private void OnCompte(Bitmap bitmap)
    {
        bitmap.Tag = mConfig.tag;
        mConfig.OnCompte?.Invoke(bitmap);

    }
}