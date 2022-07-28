using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using WinFrmTalk.Properties;

public class BitmapUtils
{
    public static bool IsNull(Image image)
    {

        if (image == null || image.PixelFormat == PixelFormat.DontCare || image.PixelFormat == PixelFormat.Undefined)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    internal static Bitmap GetRoundImage(Bitmap image, int size)
    {
        return GetRoundImage(image, size, size);
    }

    internal static Bitmap GetRoundImage(Bitmap image, int width, int height)
    {
        return ChangeSize(GetRoundImage(image), width, height);
    }




    public static Bitmap CutEllipse(Image image, int width, int height)
    {
        int new_size = Math.Min(image.Width, image.Height);

        int centx = (image.Width - new_size) / 2;
        int centy = (image.Height - new_size) / 2;

        Bitmap bm = new Bitmap(new_size + 2, new_size + 2);

        using (Graphics g = Graphics.FromImage(bm))
        {
            //if (gary)
            //{
            //    using (Brush brush = new SolidBrush(Color.Gray))
            //    {
            //        g.FillEllipse(brush, 0, 0, bm.Width - 2, bm.Height - 2);
            //    }
            //}

            GraphicsPath gpath = new GraphicsPath();

            gpath.AddEllipse(0, 0, new_size, new_size);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            g.SetClip(gpath);

            var descRect = new Rectangle(0, 0, new_size, new_size);
            var srcRect = new Rectangle(centx, centy, new_size, new_size);
            g.DrawImage(image, descRect, srcRect, GraphicsUnit.Pixel);
        }
        return bm;
    }

    internal static Bitmap GetRoundImage(Bitmap image)
    {
        return CutEllipse(image, image.Width, image.Height);

        //123123123123
        //Bitmap bm = new Bitmap(image.Width + 1, image.Height + 1);
        //Graphics g = Graphics.FromImage(bm);

        //GraphicsPath gpath = new GraphicsPath();
        //gpath.AddEllipse(0, 0, image.Width, image.Height);

        //g.SmoothingMode = SmoothingMode.AntiAlias;
        ////g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        ////g.CompositingQuality = CompositingQuality.HighQuality;

        //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //g.CompositingQuality = CompositingQuality.HighQuality;

        //g.SetClip(gpath);

        //g.DrawImage(image, new Rectangle(0, 0, image.Width + 5, image.Height + 5), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
        //g.Dispose();

        //return bm;
    }

    internal static Bitmap AppendGroupAvatar(Bitmap image, int role)
    {

        Bitmap frontImage = GetRoundImage(image);

        if (role > 2 || role == 0)
        {
            return frontImage;
        }

        Bitmap background = role == 1 ? Resources.ic_roommem_border1 : Resources.ic_roommem_border2;
        int iwidth = background.Width > frontImage.Width ? background.Width : frontImage.Width;
        int iheight = background.Height > frontImage.Height ? background.Height : frontImage.Height;
        //按最大值修改气泡长宽
        ModifyWidthAndHeight(ref iwidth, ref iheight, 200, 200);
        background = ChangeSize(background, iwidth, iheight);
        //frontImage = ModifyBitmapSize(frontImage, 140, 160);
        Bitmap mixImage2 = new Bitmap(iwidth, iheight);
        Graphics g = Graphics.FromImage(mixImage2);
        g.DrawImage(frontImage, new Rectangle(3, 3, iwidth - 6, iheight - 6));
        g.DrawImage(background, new Rectangle(0, 0, iwidth, iheight));
        return mixImage2;
    }




    #region 修改图片的尺寸
    /// <summary>
    /// 修改图片的尺寸
    /// </summary>
    /// <param name="old_bitmap"></param>
    /// <param name="new_width"></param>
    /// <param name="new_height"></param>
    /// <returns></returns>
    internal static Bitmap ChangeSize(Bitmap old_bitmap, int new_width, int new_height)
    {
        Bitmap new_bitmap = new Bitmap(new_width, new_height);
        Graphics g = Graphics.FromImage(new_bitmap);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(old_bitmap, new Rectangle(0, 0, new_width, new_height), new Rectangle(0, 0, old_bitmap.Width, old_bitmap.Height), GraphicsUnit.Pixel);
        g.Dispose();
        old_bitmap.Dispose();

        //// 处理灰色
        //if (isGary)
        //{
        //    Color gary = Color.Gainsboro;
        //    for (int i = 0; i < new_bitmap.Width; i++)
        //    {
        //        for (int j = 0; j < new_bitmap.Height; j++)
        //        {
        //            Color color = new_bitmap.GetPixel(i, j);
        //            if (color.A == 0)
        //            {
        //                new_bitmap.SetPixel(i, j, gary);
        //            }
        //        }
        //    }
        //}
        return new_bitmap;
    }
    #endregion

    #region 修改图片的尺寸
    /// <summary>
    /// 修改图片的尺寸
    /// </summary>
    /// <param name="old_bitmap"></param>
    /// <param name="new_width"></param>
    /// <param name="new_height"></param>
    /// <returns></returns>
    internal static Bitmap ChangeSize(Bitmap old_bitmap, int new_width, int new_height, float rotate)
    {
        Bitmap new_bitmap = new Bitmap(new_width, new_height);
        Graphics graphics = Graphics.FromImage(new_bitmap);
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //旋转角度和平移
        Matrix mtxRotate = graphics.Transform;
        mtxRotate.RotateAt(rotate, new PointF(new_width >> 1, new_height >> 1));
        graphics.Transform = mtxRotate;

        graphics.DrawImage(old_bitmap, new Rectangle(0, 0, new_width, new_height), new Rectangle(0, 0, old_bitmap.Width, old_bitmap.Height), GraphicsUnit.Pixel);
        graphics.Dispose();

        return new_bitmap;
    }
    #endregion

    #region 按最大值修改长宽进行自适应
    /// <summary>
    /// 按最大值修改长宽进行自适应
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="maxWidth"></param>
    /// <param name="maxHeight"></param>
    internal static void ModifyWidthAndHeight(ref int width, ref int height, int maxWidth, int maxHeight)
    {
        //暂时只考虑长宽最大值相同的情况
        if (maxWidth != maxHeight)
        {
            return;
        }
        //都没有超过最大值
        if (width <= maxWidth && height <= maxHeight)
        {
            return;
        }
        //只有宽度超过了最大值
        else if (width > maxWidth && height <= maxHeight)
        {
            height = Convert.ToInt32((decimal)maxWidth / (decimal)width * (decimal)height);
            width = maxWidth;
        }
        //只有高度超过了最大值
        else if (width <= maxWidth && height > maxHeight)
        {
            width = Convert.ToInt32((decimal)maxHeight / (decimal)height * (decimal)width);
            height = maxHeight;
        }
        //都超过了最大值
        else if (width > maxWidth && height > maxHeight)
        {
            if (width >= height)
            {
                height = Convert.ToInt32((decimal)maxWidth / (decimal)width * (decimal)height);
                width = maxWidth;
            }
            else
            {
                width = Convert.ToInt32((decimal)maxHeight / (decimal)height * (decimal)width);
                height = maxHeight;
            }
        }
    }
    #endregion


    #region 拼合红点图到 图片上
    public static Bitmap CombineRedPointToImg(Image foreImage, Image backImage)
    {

        Bitmap bitmap = new Bitmap(45, 45);
        Graphics g = Graphics.FromImage(bitmap);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.DrawImage(backImage, new Rectangle(0, 8, 35, 35), 0, 0, backImage.Width, backImage.Height, GraphicsUnit.Pixel);
        g.DrawImage(foreImage, new Rectangle(23, 0, foreImage.Width, foreImage.Height), 0, 0, foreImage.Width, foreImage.Height, GraphicsUnit.Pixel);

        return bitmap;
    }
    #endregion


    /// <summary>
    /// 无损压缩图片
    /// </summary>
    /// <param name="sFile">原图片地址</param>
    /// <param name="dFile">压缩后保存图片地址</param>
    /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
    /// <param name="size">压缩后图片的最大大小</param>
    /// <param name="sfsc">是否是第一次调用</param>
    /// <returns></returns>
    public static bool CompressImage(string sFile, string dFile, int flag = 90, int size = 20, bool sfsc = true)
    {
        Image iSource = Image.FromFile(sFile);
        ImageFormat tFormat = iSource.RawFormat;
        int dHeight = iSource.Height / 2;
        int dWidth = iSource.Width / 2;

        int sW = 0, sH = 0;
        //按比例缩放
        Size tem_size = new Size(iSource.Width, iSource.Height);
        if (tem_size.Width > dHeight || tem_size.Width > dWidth)
        {
            if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
            {
                sW = dWidth;
                sH = (dWidth * tem_size.Height) / tem_size.Width;
            }
            else
            {
                sH = dHeight;
                sW = (tem_size.Width * dHeight) / tem_size.Height;
            }
        }
        else
        {
            sW = tem_size.Width;
            sH = tem_size.Height;
        }

        Bitmap ob = new Bitmap(dWidth, dHeight);
        Graphics g = Graphics.FromImage(ob);

        g.Clear(Color.WhiteSmoke);
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

        g.Dispose();
        iSource.Dispose();
        //以下代码为保存图片时，设置压缩质量
        EncoderParameters ep = new EncoderParameters();
        long[] qy = new long[1];
        qy[0] = flag;//设置压缩的比例1-100
        EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
        ep.Param[0] = eParam;

        try
        {
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICIinfo = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICIinfo = arrayICI[x];
                    break;
                }
            }
            if (jpegICIinfo != null)
            {
                File.Delete(dFile);
                ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                FileInfo fi = new FileInfo(dFile);
                if (fi.Length > 1024 * size)
                {
                    flag = flag - 10;
                    CompressImage(sFile, dFile, flag, size, false);
                }
            }
            else
            {
                ob.Save(dFile, tFormat);
            }
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            iSource.Dispose();
            ob.Dispose();
        }
    }



    public static bool CompressAvatarProcess(string sFile, string dFile, int flag = 90, int size = 20, bool sfsc = true)
    {
        Image iSource = Image.FromFile(sFile);
        ImageFormat tFormat = iSource.RawFormat;
        int dHeight = Convert.ToInt32(iSource.Height * 0.68);
        int dWidth = Convert.ToInt32(iSource.Width * 0.68);

        int newSize = dWidth;
        if (newSize > dHeight)
        {
            newSize = dHeight;
        }

        Bitmap ob = new Bitmap(newSize, newSize);
        Graphics g = Graphics.FromImage(ob);

        g.Clear(Color.WhiteSmoke);
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        int centx = (iSource.Width - newSize) / 2;
        int centy = (iSource.Height - newSize) / 2;

        g.DrawImage(iSource, new Rectangle(0, 0, newSize, newSize), new Rectangle(centx, centy, newSize, newSize), GraphicsUnit.Pixel);

        g.Dispose();

        iSource.Dispose();
        //以下代码为保存图片时，设置压缩质量
        EncoderParameters ep = new EncoderParameters();
        long[] qy = new long[1];
        qy[0] = flag;//设置压缩的比例1-100
        EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
        ep.Param[0] = eParam;

        try
        {
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICIinfo = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICIinfo = arrayICI[x];
                    break;
                }
            }

            if (jpegICIinfo != null)
            {
                File.Delete(dFile);
                ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                FileInfo fi = new FileInfo(dFile);
                if (fi.Length > 1024 * size)
                {
                    flag = flag - 10;
                    CompressImage(sFile, dFile, flag, size, false);
                }
            }
            else
            {
                ob.Save(dFile, tFormat);
            }
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            iSource.Dispose();
            ob.Dispose();
        }
    }



    public static Bitmap GetRoundImage(Image image, bool round, bool sky)
    {
        return GetRoundImage(image, 67, 67, round, sky);
    }
    public static Bitmap GetRoundImage(Image image, int width, int height, bool round, bool sky)
    {
        int new_size = Math.Max(width + width, height + height);


        int new_width = Math.Max(width, height);
        int new_height = Math.Max(width, height);

        Bitmap bm = new Bitmap(new_size + 2, new_size + 2);

        float scale = (float)image.Width / image.Height;
        if (scale > 0.92 && scale < 1.12)
        {
            scale = 1;
        }


        if (scale == 1)
        {
            new_width = new_size;
            new_height = new_size;
        }
        else if (scale < 1)
        {
            // 长图 以长做基数
            new_height = new_size;
            new_width = Convert.ToInt32((float)new_size / image.Height * image.Width);
        }
        else
        {
            // 宽图 以宽做基数
            new_width = new_size;
            new_height = Convert.ToInt32((float)new_size / image.Width * image.Height);
        }



        using (Graphics g = Graphics.FromImage(bm))
        {
            GraphicsPath gpath = new GraphicsPath();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            if (round)
            {
                // 切圆
                gpath.AddEllipse(0, 0, new_size, new_size);
                g.SetClip(gpath);
            }

            var descRect = new Rectangle(0, 0, new_size, new_size);

            if (sky)
            {
                // 绘制星空底色
                var bg = Resources.ic_head_bg_sky;
                var srcRect1 = new Rectangle(0, 0, bg.Width, bg.Height);
                g.DrawImage(bg, descRect, srcRect1, GraphicsUnit.Pixel);
            }

            if (scale != 1)
            {
                int cenx = (new_size - new_width) / 2;
                int ceny = (new_size - new_height) / 2;
                descRect = new Rectangle(cenx, ceny, new_width - 1, new_height - 1);
            }
            // 绘制图像
            var srcRect = new Rectangle(0, 0, image.Width, image.Height);
            g.DrawImage(image, descRect, srcRect, GraphicsUnit.Pixel);

            g.ResetClip();
            // 绘制边框
            var broder = Resources.ic_roommem_border3;
            var broRect = new Rectangle(0, 0, broder.Width, broder.Height);
            var descRect1 = new Rectangle(0, 0, new_size + 2, new_size + 2);
            g.DrawImage(broder, descRect1, broRect, GraphicsUnit.Pixel);
        }
        return bm;
    }


    // 居中缩放
    private RectangleF CropCenterRect(Image image, float width, float height)
    {
        float img_width = image.Width;
        float img_height = image.Height;

        float new_width = 0;
        float new_height = 0;

        //获取合适的比例进行裁剪
        new_width = img_width;
        new_height = img_width / width * height;

        if (new_height > img_height)
        {
            new_width = img_height / new_height * new_width;
            new_height = img_height;
        }

        return new RectangleF((image.Width - new_width) / 2, (image.Height - new_height) / 2, new_width, new_height);
    }

    /// <summary>
    /// 生成文字图像
    /// </summary>
    /// <param name="image"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static Bitmap CreateRoundText(string text, int width, int height)
    {
        // 限制一下文字长度
        text = LimitTextLength(text, 2);

        Bitmap bm = new Bitmap(width, height);

        using (Graphics g = Graphics.FromImage(bm))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            // 画圆
            using (Brush brush = new SolidBrush(Color.FromArgb(13, 205, 101)))
            {
                var descRect = new Rectangle(1, 1, width - 3, height - 3);
                g.FillEllipse(brush, descRect);

                // 普通人
                var broder = Resources.ic_roommem_border3;
                var broRect = new Rectangle(0, 0, broder.Width, broder.Height);
                var descRect1 = new Rectangle(1, 1, width - 2, height - 2);
                // 绘制边框
                g.DrawImage(broder, descRect1, broRect, GraphicsUnit.Pixel);
            }

            //写字
            using (Brush brushText = new SolidBrush(Color.White))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                var descRect = new Rectangle(0, 1, width, height);
                g.DrawString(text, new Font("微软雅黑", width/3f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), brushText, descRect, format);
            }

            g.Dispose();
        }

        return bm;
    }

    public static string LimitTextLength(string text, int limit)
    {

        if (text.Length <= 2)
        {
            return text;
        }
        else
        {
            return text.Substring(text.Length - 2, 2);
        }

        //定义编码器，GB2312中文占2个长度，英文占1个长度 
        Encoding code = System.Text.Encoding.GetEncoding("GB2312");

        int count = 1;
        string result = string.Empty;

        while (count <= text.Length)
        {
            result = text.Substring(text.Length - count, count);

            if (code.GetByteCount(result) < limit)
            {
                // 没有超过就往后面去加
                count++;
            }
            else
            {
                break;
            }
        }

        return result;
    }
}