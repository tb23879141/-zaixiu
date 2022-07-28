using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Helper;

namespace WinFrmTalk.View
{
    public partial class FrmFeedback : FrmBase
    {
        private LodingUtils loding;//等待符控件全局
        string types = "0";//默认为其他类型问题
        List<string> images = new List<string>();
        List<Panel> panels = new List<Panel>();
        public FrmFeedback()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="bVk"> virtual-key code</param>
        /// <param name="bScan">hardware scan code</param>
        /// <param name="dwFlags"> flags specifying various function options</param>
        /// <param name="dwExtraInfo"> additional data associated with keystroke</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        private void btnsure_Click(object sender, EventArgs e)
        {
            string imgOurl = "";

            for (int i = 0; i < images.Count; i++)
            {
                if (i != 0)
                    imgOurl += ",";

                imgOurl += images[i];
            }
            string content = textContent.Text.Replace("请输入您要反馈的问题（5-200字以内）！", "");
            if (UIUtils.IsNull(content))
            {
                ShowTip("请填写意见");
                return;
            }
            if (GetTextBoxLength(content) > 200)
            {
                ShowTip("输入内容限制为200字以内!");
                return;
            }
            ShowLodingDialog();

            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "addFeedback/v1")
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("content", content)
            .AddParams("types", types)
            .AddParams("imgOurl", imgOurl)
            .Build().Execute((suss, data) =>
            {
                loding.stop();
                if (suss)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            });
        }

        /// <summary>
        /// 检查文本长度
        /// </summary>
        /// <param name="textboxTextStr"></param>
        /// <returns></returns>
        public static int GetTextBoxLength(string textboxTextStr)
        {
            int nLength = 0;
            for (int i = 0; i < textboxTextStr.Length; i++)
            {
                if (textboxTextStr[i] >= 0x3000 && textboxTextStr[i] <= 0x9FFF)
                    nLength += 2;
                else
                    nLength++;
            }
            return nLength;
        }

        /// <summary>
        /// 使用等待符
        /// </summary>
        private void ShowLodingDialog()
        {
            loding = new LodingUtils();
            loding.parent = this;
            loding.Title = "加载中";
            loding.start();
        }

        private void image_Click(object sender, EventArgs e)
        {
            //利用tab按键textContent让焦点
            keybd_event((byte)Keys.Tab, 0, 0, 0);
            keybd_event((byte)Keys.Tab, 0, 2, 0);

            UpLoadImage();
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="control"></param>
        private void UpLoadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = true,//该值确定是否可以选择多个文件
                Title = "请选择文件夹",
                Filter = "图像 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            //完成选择图片的操作
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in dialog.FileNames)
                {
                    UploadEngine.Instance.From(file).UploadFile((success, url) =>
                    {
                        var map = DwonImage(url);
                        panels[images.Count].BackgroundImage = map;
                        panels[images.Count].BackgroundImageLayout = ImageLayout.Stretch;
                        panels[images.Count].Tag = url;

                        panels[images.Count].Click -= new EventHandler(image_Click);
                        panels[images.Count].Click += new EventHandler(FrmFeedback_MouseClick);

                        AddDeleteImg(panels[images.Count]);

                        //图片显示完成后才添加图片
                        images.Add(url);

                    });
                }
                dialog.Dispose();
            }
        }

        private void FrmFeedback_MouseClick(object sender, EventArgs e)
        {
            FrmLookImage frmLookImage = Applicate.GetWindow<FrmLookImage>();
            if (frmLookImage == null)
            {
                frmLookImage = new FrmLookImage();
            }
            else
            {
                frmLookImage.WindowState = FormWindowState.Normal;
                frmLookImage.Activate();
            }

            frmLookImage.ShowImage(((Panel)sender).Tag.ToString());
        }

        private Bitmap DwonImage(string url)
        {
            try
            {
                WebRequest imgRequest = WebRequest.Create(url);
                Image dwonImage = System.Drawing.Image.FromStream(imgRequest.GetResponse().GetResponseStream());
                Bitmap map = new Bitmap(dwonImage);
                return map;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加删除图标
        /// </summary>
        /// <param name="controls"></param>
        private void AddDeleteImg(Control controls)
        {
            PictureBox box = new PictureBox();
            box.BackColor = Color.Transparent;
            box.Cursor = Cursors.Hand;
            box.Image = Properties.Resources.delete;
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Location = new Point(controls.Width - box.Width, controls.Height - box.Height);
            box.Tag = controls;
            box.Click += new EventHandler(this.DeleteImage);
            controls.Controls.Add(box);
        }

        /// <summary>
        /// 删除当前图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteImage(object sender, EventArgs e)
        {
            var panel = (Panel)((PictureBox)sender).Tag;
            var imgUrl = panel.Tag.ToString();

            //执行删除操作
            panel.Tag = null;//先获取值再清空标记
            images.Remove(imgUrl);//去除储存的图片
            panel.Controls.Clear();
            panel.Click += new EventHandler(image_Click);
            panel.Click -= new EventHandler(FrmFeedback_MouseClick);
            panel.BackgroundImage = Properties.Resources.add_photo;

            //执行图片前移操作
            for (int i = 0; i < panels.Count - 1; i++)
            {
                //当前图片为空
                if (panels[i].Tag == null)
                {
                    //图片上移
                    panels[i].BackgroundImage = panels[i + 1].BackgroundImage;
                    //保存当前图片值
                    panels[i].Tag = panels[i + 1].Tag;
                    if (panels[i].Tag != null)
                    {
                        AddDeleteImg(panels[i]);
                        panels[i].Click -= new EventHandler(image_Click);
                        panels[i].Click += new EventHandler(FrmFeedback_MouseClick);
                    }

                    //删除下张图片
                    panels[i + 1].Tag = null;
                    panels[i + 1].BackgroundImage = Properties.Resources.add_photo;//回复为默认图片
                    panels[i + 1].Click += new EventHandler(image_Click);
                    panels[i + 1].Click -= new EventHandler(FrmFeedback_MouseClick);
                    panels[i + 1].Controls.Clear();
                }
            }
        }

        #region 反馈类型选择：1.功能异常 2.页面优化 3.新增模块 4.其他问题
        private void type1_Click(object sender, EventArgs e)
        {
            AddSelectImg(FeedBackType.Exception);
        }

        private void type2_Click(object sender, EventArgs e)
        {
            AddSelectImg(FeedBackType.optimize);
        }

        private void type3_Click(object sender, EventArgs e)
        {
            AddSelectImg(FeedBackType.Add);
        }

        private void type4_Click(object sender, EventArgs e)
        {
            AddSelectImg(FeedBackType.Other);
        }


        private void AddSelectImg(FeedBackType type)
        {
            //利用tab按键textContent让焦点
            keybd_event((byte)Keys.Tab, 0, 0, 0);
            keybd_event((byte)Keys.Tab, 0, 2, 0);
            type1.BackgroundImage = Properties.Resources.o_unselected;
            type2.BackgroundImage = Properties.Resources.o_unselected;
            type3.BackgroundImage = Properties.Resources.o_unselected;
            type4.BackgroundImage = Properties.Resources.o_unselected;
            switch (type)
            {
                case FeedBackType.Exception:
                    type1.BackgroundImage = Properties.Resources.o_select;
                    types = "1";
                    break;
                case FeedBackType.optimize:
                    type2.BackgroundImage = Properties.Resources.o_select;
                    types = "2";
                    break;
                case FeedBackType.Add:
                    type3.BackgroundImage = Properties.Resources.o_select;
                    types = "3";
                    break;
                case FeedBackType.Other:
                    type4.BackgroundImage = Properties.Resources.o_select;
                    types = "0";
                    break;
                default:
                    break;
            }
        }
        #endregion


        private bool textContentText = false;
        private void textContent_Enter(object sender, EventArgs e)
        {
            if (textContentText == false)
                textContent.Text = "";

            textContent.ForeColor = Color.Black;
        }

        private void textContent_Leave(object sender, EventArgs e)
        {
            if (textContent.Text == "")
            {
                textContent.Text = "请输入您要反馈的问题（5-200字以内）！";
                textContent.ForeColor = Color.FromArgb(102, 102, 102);
                textContentText = false;
            }
            else
                textContentText = true;
        }

        private void FrmFeedback_Load(object sender, EventArgs e)
        {
            panels.Add(image1);
            panels.Add(image2);
            panels.Add(image3);
            panels.Add(image4);
        }
    }

    /// <summary>
    /// 反馈问题类型
    /// </summary>
    enum FeedBackType
    {
        Other,
        Exception,
        optimize,
        Add
    }
}