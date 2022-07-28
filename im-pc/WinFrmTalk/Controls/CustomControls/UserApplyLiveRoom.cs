using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.View;
using System.IO;
using System.Net;
using WinFrmTalk.Controls.SystemControls;
using System.Threading;
using System.CodeDom;
using System.Text.RegularExpressions;
using WinFrmTalk.Model;
using SqlSugar;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserApplyLiveRoom : UserControl
    {
        #region 全局变量

        public  LiveApplyModel liveApplyModel = new LiveApplyModel();

        Snackbar TipView;
        #endregion

        #region 定义提示框
        public UserApplyLiveRoom()
        {
            InitializeComponent();

            labelBandCard.Text = Applicate.URLDATA.data.bandCard;

            TipView = new WinFrmTalk.Controls.SystemControls.Snackbar();
            TipView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            TipView.Location = new System.Drawing.Point(213, 393);
            TipView.Name = "tipView";
            TipView.Size = new System.Drawing.Size(75, 23);
            TipView.TabIndex = 0;
            TipView.Text = "tipView";
            TipView.Visible = false;
            Controls.Add(TipView);
        }
        public void ShowTip(string err)
        {
            int count = (int)(Snackbar.MIN_WIDTH / 16.1);
            int hegiht = (err.Length / count + 1) * 11 + 14;
            TipView.Size = new System.Drawing.Size(Snackbar.MIN_WIDTH, hegiht);

            int x = (int)((this.Size.Width - Snackbar.MIN_WIDTH) * 0.5f);
            int y = this.Size.Height - this.TipView.Size.Height - Snackbar.MARGIN_BOTTOM;
            TipView.Location = new System.Drawing.Point(x, y);
            TipView.BringToFront();

            TipView.SetText(err);

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(Snackbar.DisplayTime);

                HttpUtils.Instance.Invoke(new Action(() =>
                {
                    this.TipView.HideText();

                }));
            });

        }

        #endregion

        #region 加载历史数据
        public void LoadData(LiveApplyModel liveModel)
        {
            this.liveApplyModel = liveModel;
            switch (liveModel.status) //-1未申请 0刚申请  1通过  2驳回
            {
                case "-1":

                    liveApplyModel.type = "1";
                    this.panel3.Location = new System.Drawing.Point(16, 30);
                    labelPersonal.ForeColor = Color.FromArgb(34, 24, 219);
                    labelBusiness.ForeColor = Color.Black;
                    panelPersonalStep1.Visible = true;
                    panelBusinessStep1.Visible = false;
                    panelStep2.Visible = false;
                    panelStep3.Visible = false;

                    textContent.Text = "请简单描述您开播的分享的目的与内容...";
                    textContent.ForeColor = Color.FromArgb(154, 154, 154);
                    textContentText = false;

                    Initialize();
                    RemoveImg();
                    ClearText(panelPersonalStep1);

                    break;
                case "0":
                    labelStep1.Parent = panelBr;
                    labelStep1.Location = new Point(86, 6);
                    labelStep1.ForeColor = Color.FromArgb(102, 102, 102);
                    labelStep2.Parent = panelBr;
                    labelStep2.Location = new Point(386, 6);
                    labelStep2.ForeColor = Color.FromArgb(102, 102, 102);
                    labelStep3.Parent = imgStep;
                    labelStep3.Location = new Point(57, 6);
                    labelStep3.ForeColor = Color.White;
                    imgStep.Location = new Point(600, 0);
                    panelPersonalStep1.Visible = false;
                    panelStep2.Visible = false;
                    panelStep3.Visible = true;
                    break;
                case "2":
                    panelLiveApplyFail.Visible = true;
                    LoadImage(liveModel);
                    switch (liveModel.type)
                    {
                        case "1":
                            //初始化界面
                            this.panel3.Location = new System.Drawing.Point(16, 30);
                            labelPersonal.ForeColor = Color.FromArgb(34, 24, 219);
                            labelBusiness.ForeColor = Color.Black;
                            panelPersonalStep1.Visible = true;
                            panelBusinessStep1.Visible = false;
                            panelStep2.Visible = false;
                            panelStep3.Visible = false;
                            Initialize();
                            ClearText(panelPersonalStep1);
                            //填入个人申请信息
                            txtNickname.Text = liveModel.name;
                            textID.Text = liveModel.idCardLincence;
                            textPhone.Text = liveModel.phoneEmail;
                            textBoxBankCard.Text = liveModel.bandCard;
                            textContent.Text = liveModel.content;
                            textContent.ForeColor = Color.Black;
                            textContentText = true;
                            break;
                        case "2":
                            //初始化界面
                            this.panel3.Location = new Point(248, 30);
                            labelBusiness.ForeColor = Color.FromArgb(34, 24, 219);
                            labelPersonal.ForeColor = Color.Black;
                            panelBusinessStep1.Visible = true;
                            panelPersonalStep1.Visible = false;
                            panelStep2.Visible = false;
                            panelStep3.Visible = false;
                            Initialize();
                            ClearText(panelBusinessStep1);
                            //填入企业申请信息
                            txtBusinessName.Text = liveModel.name;
                            txtBusinessId.Text = liveModel.idCardLincence;
                            txtBusinessEmail.Text = liveModel.phoneEmail;
                            txtBusinessBank.Text = liveModel.bandCard;
                            txtBankName.Text = liveModel.openName;
                            txtSubBranch.Text = liveModel.openBank;
                            txtBankAddress.Text = liveModel.bankLoc;
                            txtBusinessContent.Text = liveModel.content;
                            txtBusinessContent.ForeColor = Color.Black;
                            txtBusinessContentText = true;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 加载申请记录图片
        /// </summary>
        /// <param name="liveModel"></param>
        private void LoadImage(LiveApplyModel liveModel) {
            //身份证正面图
            imgIDFront.BackgroundImage = DwonImage(liveModel.upCardUrl);
            imgIDFront.BackgroundImageLayout = ImageLayout.Stretch;
            labelIDFront.ForeColor = Color.Black;
            //身份证反面图
            imgIDReverse.BackgroundImage = DwonImage(liveModel.downCardUrl);
            imgIDReverse.BackgroundImageLayout = ImageLayout.Stretch;
            labelIDReverse.ForeColor = Color.Black;
            //打款记录图或公司营业执照
            imgBill.BackgroundImage = DwonImage(liveModel.screenLicence);
            imgBill.BackgroundImageLayout = ImageLayout.Stretch;
            labelBill.ForeColor = Color.Black;
            //粉丝数量截图
            imgFansCount.BackgroundImage = DwonImage(liveModel.screenfans);
            imgFansCount.BackgroundImageLayout = ImageLayout.Stretch;
            labelFansCount.ForeColor = Color.Black;
        }


        /// <summary>
        /// 获取打款金额
        /// </summary>
        public void GetAmount()
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "liveRoom/getApplicationAmount")
                .Build().Execute((susse, data) =>
                {
                    if (susse)
                    {
                        liveApplyModel.money = labelAmount.Text = UIUtils.DecodeString(data, "data");
                    }
                });
        }

        /// <summary>
        /// 打开直播协议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelAgreement_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FrmPrivacy"];
            if (frm == null)
            {
                FrmPrivacy frmPrivacy = new FrmPrivacy();
                frmPrivacy.html = Applicate.URLDATA.data.privacy.liveAgreement;
                frmPrivacy.Show();
            }
            else
            {
                frm.Activate();
            }
        }
        #endregion

        #region 个人申请
        private void labelPersonal_Click(object sender, EventArgs e)
        {
            if (liveApplyModel.type == "2" && liveApplyModel.status == "-1")
            {
                liveApplyModel.type = "1";
                this.panel3.Location = new System.Drawing.Point(16, 30);
                labelPersonal.ForeColor = Color.FromArgb(34, 24, 219);
                labelBusiness.ForeColor = Color.Black;
                panelPersonalStep1.Visible = true;
                panelBusinessStep1.Visible = false;
                panelStep2.Visible = false;
                panelStep3.Visible = false;

                textContent.Text = "请简单描述您开播的分享的目的与内容...";
                textContent.ForeColor = Color.FromArgb(154, 154, 154);
                textContentText = false;

                Initialize();
                RemoveImg();
                ClearText(panelPersonalStep1);
            }
        }

        private void BtnPersonalNext_Click(object sender, EventArgs e)
        {
            liveApplyModel.name = txtNickname.Text;
            liveApplyModel.idCardLincence = textID.Text;
            liveApplyModel.phoneEmail = textPhone.Text;
            liveApplyModel.bandCard = textBoxBankCard.Text;
            liveApplyModel.content = textContent.Text.Replace("请简单描述您开播的分享的目的与内容...", "");
            if (string.IsNullOrEmpty(liveApplyModel.name))
            {
                ShowTip("请填写本人姓名!");
                txtNickname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.idCardLincence))
            {
                ShowTip("请填写本人身份证号!");
                textID.Focus();
                return;
            }
            if ((!Regex.IsMatch(liveApplyModel.idCardLincence, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                ShowTip("请输入正确的身份证号!");
                textID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.phoneEmail))
            {
                ShowTip("请填写本人手机号!");
                textPhone.Focus();
                return;
            }
            if ((!Regex.IsMatch(liveApplyModel.phoneEmail, @"^[1]+[3,5]+\d{9}", RegexOptions.IgnoreCase)))
            {
                ShowTip("请输入正确的手机号!");
                textPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.bandCard))
            {
                ShowTip("请填写银行卡号!");
                textBoxBankCard.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.content))
            {
                ShowTip("请填开播内容!");
                textBoxBankCard.Focus();
                return;
            }

            labelStep1.Parent = panelBr;
            labelStep1.Location = new Point(86, 6);
            labelStep1.ForeColor = Color.FromArgb(102, 102, 102);
            labelStep2.Parent = imgStep;
            labelStep2.Location = new Point(74, 6);
            labelStep2.ForeColor = Color.White;
            imgStep.Location = new Point(300, 0);
            panelPersonalStep1.Visible = false;
            panelStep2.Visible = true;
            labelBill.Text = "打款记录图";
        }
        #endregion

        #region 企业申请
        private void labelBusiness_Click(object sender, EventArgs e)
        {
            if (liveApplyModel.type == "1" && liveApplyModel.status == "-1")
            {
                liveApplyModel.type = "2";
                this.panel3.Location = new Point(248, 30);
                labelBusiness.ForeColor = Color.FromArgb(34, 24, 219);
                labelPersonal.ForeColor = Color.Black;
                panelBusinessStep1.Visible = true;
                panelPersonalStep1.Visible = false;
                panelStep2.Visible = false;
                panelStep3.Visible = false;
                txtBusinessContent.Text = "请简单描述您开播的分享的目的与内容...";
                txtBusinessContent.ForeColor = Color.FromArgb(154, 154, 154);
                txtBusinessContentText = false;
                Initialize();
                RemoveImg();
                ClearText(panelBusinessStep1);
            }
        }

        private void BtnBusinessNext_Click(object sender, EventArgs e)
        {
            liveApplyModel.name = txtBusinessName.Text;
            liveApplyModel.idCardLincence = txtBusinessId.Text;
            liveApplyModel.phoneEmail = txtBusinessEmail.Text;
            liveApplyModel.bandCard = txtBusinessBank.Text;
            liveApplyModel.openName = txtBankName.Text;
            liveApplyModel.openBank = txtSubBranch.Text;
            liveApplyModel.bankLoc = txtBankAddress.Text;
            liveApplyModel.content = txtBusinessContent.Text.Replace("请简单描述您开播的分享的目的与内容...", "");

            if (string.IsNullOrEmpty(liveApplyModel.name))
            {
                ShowTip("请填写企业名称!");
                txtBusinessName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.idCardLincence))
            {
                ShowTip("请填写营业执照号!");
                txtBusinessId.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.phoneEmail))
            {
                ShowTip("请填写企业邮箱!");
                txtBusinessEmail.Focus();
                return;
            }
            if ((!Regex.IsMatch(liveApplyModel.phoneEmail, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase)))
            {
                ShowTip("请输入正确的企业邮箱!");
                txtBusinessEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.bandCard))
            {
                ShowTip("请填写企业银行账号!");
                txtBusinessBank.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.openName))
            {
                ShowTip("请填写银行开户名!");
                txtBankName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.openBank))
            {
                ShowTip("请填写开户银行支行名称!");
                txtSubBranch.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.bankLoc))
            {
                ShowTip("请填写开户银行所在地!");
                txtBankAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.content))
            {
                ShowTip("请填开播内容!");
                textBoxBankCard.Focus();
                return;
            }
            labelStep1.Parent = panelBr;
            labelStep1.Location = new Point(86, 6);
            labelStep1.ForeColor = Color.FromArgb(102, 102, 102);
            labelStep2.Parent = imgStep;
            labelStep2.Location = new Point(74, 6);
            labelStep2.ForeColor = Color.White;
            imgStep.Location = new Point(300, 0);
            panelBusinessStep1.Visible = false;
            panelStep2.Visible = true;
            labelBill.Text = "营业执照图";
        }
        #endregion

        /// <summary>
        /// 申请信息提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(liveApplyModel.upCardUrl))
            {
                ShowTip("请上传身份证正面图!");
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.downCardUrl))
            {
                ShowTip("请上传身份证正面图!");
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.screenLicence))
            {
                ShowTip("请上传" + labelBill.Text + "!");
                return;
            }
            if (string.IsNullOrEmpty(liveApplyModel.screenfans))
            {
                ShowTip("请上传粉丝数量截图!");
                return;
            }
            if (liveApplyModel.status=="2")//申请被驳回就更新申请信息
            {
                UpdateLivePermission();
            }
            else
            {
                ApplyLivePermission();
            }
        }

        /// <summary>
        /// 申请直播权限
        /// </summary>
        private void ApplyLivePermission()
        {
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/applyLivePermission")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("type", liveApplyModel.type)
                .AddParams("name", liveApplyModel.name)
                .AddParams("idCardLincence", liveApplyModel.idCardLincence)
                .AddParams("bandCard", liveApplyModel.bandCard)
                .AddParams("upCardUrl", liveApplyModel.upCardUrl)
                .AddParams("downCardUrl", liveApplyModel.downCardUrl)
                .AddParams("content", liveApplyModel.content)
                .AddParams("phoneEmail", liveApplyModel.phoneEmail)
                .AddParams("screenLicence", liveApplyModel.screenLicence)
                .AddParams("screenFans", liveApplyModel.screenfans)
                .AddParams("money", liveApplyModel.money)
                .AddParams("openName", liveApplyModel.openName)
                .AddParams("openBank", liveApplyModel.openBank)
                .AddParams("bankLoc", liveApplyModel.bankLoc)
                .AddParams("roomType", liveApplyModel.roomType)
                .NoErrorTip()
                 .Build().AddErrorListener((code, err) =>
                 {
                     ShowTip(err);
                 })
                .Execute((sccess, room) =>
                {
                    if (sccess)
                    {
                        labelStep2.Parent = panelBr;
                        labelStep2.Location = new Point(386, 6);
                        labelStep2.ForeColor = Color.FromArgb(102, 102, 102);
                        labelStep3.Parent = imgStep;
                        labelStep3.Location = new Point(57, 6);
                        labelStep3.ForeColor = Color.White;
                        imgStep.Location = new Point(600, 0);
                        panelPersonalStep1.Visible = false;
                        panelStep2.Visible = false;
                        panelStep3.Visible = true;
                        //liveApplyModel.Status = 1;//记录完成申请填写
                    }
                });
        }

        /// <summary>
        /// 更新申请信息
        /// </summary>
        private void UpdateLivePermission()
        {
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "/liveRoom/updateLivePermission")
                 .AddParams("access_token", Applicate.Access_Token)
                 .AddParams("id", liveApplyModel.id)
                 .AddParams("name", liveApplyModel.name)
                 .AddParams("idCardLincence", liveApplyModel.idCardLincence)
                 .AddParams("bandCard", liveApplyModel.bandCard)
                 .AddParams("upCardUrl", liveApplyModel.upCardUrl)
                 .AddParams("downCardUrl", liveApplyModel.downCardUrl)
                 .AddParams("content", liveApplyModel.content)
                 .AddParams("phoneEmail", liveApplyModel.phoneEmail)
                 .AddParams("screenLicence", liveApplyModel.screenLicence)
                 .AddParams("screenFans", liveApplyModel.screenfans)
                 .AddParams("openName", liveApplyModel.openName)
                 .AddParams("openBank", liveApplyModel.openBank)
                 .AddParams("bankLoc", liveApplyModel.bankLoc)
                 //.AddParams("type", liveApplyModel.type)
                 //.AddParams("roomType", liveApplyModel.roomType)
                 .NoErrorTip()
                  .Build().AddErrorListener((code, err) =>
                  {
                      ShowTip(err);
                  })
                 .Execute((sccess, room) =>
                 {
                     if (sccess)
                     {
                         labelStep2.Parent = panelBr;
                         labelStep2.Location = new Point(386, 6);
                         labelStep2.ForeColor = Color.FromArgb(102, 102, 102);
                         labelStep3.Parent = imgStep;
                         labelStep3.Location = new Point(57, 6);
                         labelStep3.ForeColor = Color.White;
                         imgStep.Location = new Point(600, 0);
                         panelPersonalStep1.Visible = false;
                         panelStep2.Visible = false;
                         panelStep3.Visible = true;
                        //liveApplyModel.Status = 1;//记录完成申请填写
                    }
                 });

        }

        #region 初始化界面
        //初始化图片选择框
        private void RemoveImg() 
        {
            imgIDFront.BackgroundImage = WinFrmTalk.Properties.Resources.photo_bg;
            labelIDFront.ForeColor = Color.FromArgb(153, 153, 153);
            imgIDReverse.BackgroundImage = WinFrmTalk.Properties.Resources.photo_bg;
            labelIDReverse.ForeColor = Color.FromArgb(153, 153, 153);
            imgBill.BackgroundImage = WinFrmTalk.Properties.Resources.photo_bg;
            labelBill.ForeColor = Color.FromArgb(153, 153, 153);
            imgFansCount.BackgroundImage = WinFrmTalk.Properties.Resources.photo_bg;
            labelFansCount.ForeColor = Color.FromArgb(153, 153, 153);
            liveApplyModel.upCardUrl = "";
            liveApplyModel.downCardUrl = "";
            liveApplyModel.screenLicence = "";
            liveApplyModel.screenfans = "";
        }

        /// <summary>
        /// 初始化控件位置
        /// </summary>
        private void Initialize()
        {
            imgStep.Location = new Point(0, 0);
            labelStep1.Parent = imgStep;
            labelStep1.ForeColor = Color.White;
            labelStep1.Location = new Point(74, 6);
            labelStep2.Parent = panelBr;
            labelStep2.ForeColor = Color.FromArgb(102, 102, 102);
            labelStep2.Location = new Point(386, 6);
            labelStep3.Parent = panelBr;
            labelStep3.ForeColor = Color.FromArgb(102, 102, 102);
            labelStep3.Location = new Point(657, 6);

        }
        private void ClearText(Control ctrlTop)
        {
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                if (ctrlTop.Text == "请简单描述您开播的分享的目的与内容...")
                    return;
                ctrlTop.Text = "";
            }
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用
                }
            }
        }

        #endregion

        #region 选择图片上传
        private void imgIDFront_Click(object sender, EventArgs e)
        {
            UpLoadImage(this.imgIDFront);
            labelIDFront.ForeColor = Color.Black;
        }

        private void imgIDReverse_Click(object sender, EventArgs e)
        {
            UpLoadImage(this.imgIDReverse);
            labelIDReverse.ForeColor = Color.Black;
        }

        private void imgBill_Click(object sender, EventArgs e)
        {
            UpLoadImage(this.imgBill);
            labelBill.ForeColor = Color.Black;
        }

        private void imgFansCount_Click(object sender, EventArgs e)
        {
            UpLoadImage(this.imgFansCount);
            labelFansCount.ForeColor = Color.Black;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="control"></param>
        private void UpLoadImage(Control control)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,//该值确定是否可以选择多个文件
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
                        if (control.Name == "imgIDFront")
                            liveApplyModel.upCardUrl = url;
                        if (control.Name == "imgIDReverse")
                            liveApplyModel.downCardUrl = url;
                        if (control.Name == "imgBill")
                            liveApplyModel.screenLicence = url;
                        if (control.Name == "imgFansCount")
                            liveApplyModel.screenfans = url;
                        var map = DwonImage(url);
                        control.BackgroundImage = map;
                        control.BackgroundImageLayout = ImageLayout.Stretch;
                    });
                }
                dialog.Dispose();
            }
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
        #endregion

        #region txtbox文本操作
        private bool txtBusinessContentText = false;
        private void txtBusinessContent_Enter(object sender, EventArgs e)
        {
            if (txtBusinessContentText == false)
                txtBusinessContent.Text = "";

            txtBusinessContent.ForeColor = Color.Black;
        }

        private void txtBusinessContent_Leave(object sender, EventArgs e)
        {
            if (txtBusinessContent.Text == "")
            {
                txtBusinessContent.Text = "请简单描述您开播的分享的目的与内容...";
                txtBusinessContent.ForeColor = Color.FromArgb(154, 154, 154);
                txtBusinessContentText = false;
            }
            else
                txtBusinessContentText = true;
        }

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
                textContent.Text = "请简单描述您开播的分享的目的与内容...";
                textContent.ForeColor = Color.FromArgb(154, 154, 154);
                textContentText = false;
            }
            else
                textContentText = true;

        }
        #endregion

        #region 操作优化
        private void txtBusinessName_Enter(object sender, EventArgs e)
        {
            panelBusinessName.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBusinessName_Leave(object sender, EventArgs e)
        {
            panelBusinessName.BackgroundImage = Properties.Resources.d1;
        }

        private void txtBusinessId_Enter(object sender, EventArgs e)
        {
            panelBusinessId.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBusinessId_Leave(object sender, EventArgs e)
        {
            panelBusinessId.BackgroundImage = Properties.Resources.d1;
        }

        private void txtBusinessEmail_Enter(object sender, EventArgs e)
        {
            panelBusinessEmail.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBusinessEmail_Leave(object sender, EventArgs e)
        {
            panelBusinessEmail.BackgroundImage = Properties.Resources.d1;
        }

        private void txtBusinessBank_Enter(object sender, EventArgs e)
        {
            panelBusinessBank.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBusinessBank_Leave(object sender, EventArgs e)
        {
            panelBusinessBank.BackgroundImage = Properties.Resources.d1;
        }

        private void txtBankName_Enter(object sender, EventArgs e)
        {
            panelBankName.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBankName_Leave(object sender, EventArgs e)
        {
            panelBankName.BackgroundImage = Properties.Resources.d1;
        }

        private void txtSubBranch_Enter(object sender, EventArgs e)
        {
            panelSubBranch.BackgroundImage = Properties.Resources.d2;
        }

        private void txtSubBranch_Leave(object sender, EventArgs e)
        {
            panelSubBranch.BackgroundImage = Properties.Resources.d1;
        }

        private void txtBankAddress_Enter(object sender, EventArgs e)
        {
            panelBankAddress.BackgroundImage = Properties.Resources.d2;
        }

        private void txtBankAddress_Leave(object sender, EventArgs e)
        {
            panelBankAddress.BackgroundImage = Properties.Resources.d1;
        }

        private void txtNickname_Enter(object sender, EventArgs e)
        {
            panelName.BackgroundImage = Properties.Resources.d2;
        }

        private void txtNickname_Leave(object sender, EventArgs e)
        {
            panelName.BackgroundImage = Properties.Resources.d1;
        }

        private void textID_Enter(object sender, EventArgs e)
        {
            panelID.BackgroundImage = Properties.Resources.d2;
        }

        private void textID_Leave(object sender, EventArgs e)
        {
            panelID.BackgroundImage = Properties.Resources.d1;
        }

        private void textPhone_Enter(object sender, EventArgs e)
        {
            panelPhone.BackgroundImage = Properties.Resources.d2;
        }

        private void textPhone_Leave(object sender, EventArgs e)
        {
            panelPhone.BackgroundImage = Properties.Resources.d1;
        }

        private void textBoxBankCard_Enter(object sender, EventArgs e)
        {
            panelBankCard.BackgroundImage = Properties.Resources.d2;
        }

        private void textBoxBankCard_Leave(object sender, EventArgs e)
        {
            panelBankCard.BackgroundImage = Properties.Resources.d1;
        }
        #endregion

        private void Resubmit_Click(object sender, EventArgs e)
        {
            panelLiveApplyFail.Visible = false;
        }
    }
}
