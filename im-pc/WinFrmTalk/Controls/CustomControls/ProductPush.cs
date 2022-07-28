using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using WinFrmTalk.Model;
using RichTextBoxLinks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class ProductPush : UserControl
    {
        public ProductPush()
        {
            InitializeComponent();
        }

        #region 解析商品图文

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        public void SetProductText(string content_json)
        {
            var BubbleWidth = 0;
            var BubbleHeight = 0;
            try
            {
                if (string.IsNullOrEmpty(content_json))
                    return;

                var jSONArray = JsonConvert.DeserializeObject<ProductPushModel>(content_json);

                string url = jSONArray.Shop_url + "?access_token=" + Applicate.Access_Token + "&httpKey=" + UIUtils.EncodeBase64(Applicate.HTTP_KEY);
                //解析json
                this.lblTitle.Text = "¥" + jSONArray.Shop_price;
                //this.labelGoodName.Text = jSONArray.Goods_name;

                ImageLoader.Instance.Load(jSONArray.Original_img).Into((image, path) =>
                {
                    if (!BitmapUtils.IsNull(image))
                    {
                        this.picImg.BackgroundImageLayout = ImageLayout.Zoom;
                        this.picImg.BackgroundImage = EQControlManager.ClipImage(image, image.Width, image.Height);
                    }
                });

                TextBoxlabelGoodName.Text = jSONArray.Goods_name;
                TextBoxlabelGoodName.Font = new Font(Applicate.SetFont, 10F);
                TextBoxlabelGoodName.BackColor = Color.White;
                TextBoxlabelGoodName.ReadOnly = true;
                TextBoxlabelGoodName.ScrollBars = RichTextBoxScrollBars.None;
                TextBoxlabelGoodName.WordWrap = true;

                float max_width = 0;
                //通过自适应高度计算
                TextBoxlabelGoodName.ContentsResized += new ContentsResizedEventHandler((sender, e) =>
                {
                    if (string.IsNullOrEmpty(TextBoxlabelGoodName.Text))
                        return;

                    string str_rtf = TextBoxlabelGoodName.Rtf;
                    //分割每一行
                    string[] str_row = TextBoxlabelGoodName.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in str_row)
                    {
                        int item_width = 0;
                        if (!string.IsNullOrEmpty(item))
                        {
                            //空格的数量
                            int whiteSpaceCount = item.Split(' ').Length - 1;

                            //获取行文字所占的大小
                            SizeF sizeF = EQControlManager.GetStringTheSize(item.Replace(" ", ""), new Font(Applicate.SetFont, 10F));

                            //总宽度（emoji表情符号计算长度欠缺3个像素）
                            item_width = (int)sizeF.Width + whiteSpaceCount * 4;
                        }


                        if (item_width > max_width)
                            max_width = item_width;
                        //到达了最大宽度
                        if (max_width >= this.Width)
                        {
                            max_width = this.Width;
                            break;
                        }
                    }
                    if (max_width < 1)
                        return;
                    //如果文字宽度不足260
                    if (max_width < this.Width)
                        BubbleWidth = (int)max_width + 5;
                    else
                        BubbleWidth = this.Width + 5;
                    //if (msg.BubbleHeight > e.NewRectangle.Height)
                    BubbleHeight = e.NewRectangle.Height;
                    TextBoxlabelGoodName.Size = new Size(BubbleWidth + 2, BubbleHeight);
                    TextBoxlabelGoodName.Rtf = str_rtf;

                });
                int EM_GETLINECOUNT = 0x00BA;//获取总行数的消息号 
                SendMessage(TextBoxlabelGoodName.Handle, EM_GETLINECOUNT, IntPtr.Zero, "");

                this.Size = new Size(this.Width,picImg.Height+ lblTitle.Height+ TextBoxlabelGoodName.Height +3);

                //添加点击事件
                this.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (!string.IsNullOrEmpty(url))
                            System.Diagnostics.Process.Start(url);
                    }
                };
                foreach (Control crl in this.Controls)
                    crl.MouseClick += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            if (!string.IsNullOrEmpty(url))
                                System.Diagnostics.Process.Start(url);
                        }
                    };

            }
            catch (Exception ex)
            {
                LogHelper.log.Error("-------------加载消息记录出错，方法（SetProductText）: \r\n" + ex.Message);
            }
        }
        #endregion

    }
}
