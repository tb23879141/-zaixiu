using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;
using WinFrmTalk.View;

namespace WinFrmTalk
{
    public partial class FrmForgetPwd : FrmBase
    {
        // 总计秒数
        private int countdown = 60;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            //this.Text = LanguageXmlUtils.GetValue("forget_pwd", this.Text);
            //lbliconAccount.Text = LanguageXmlUtils.GetValue("user_account", lbliconAccount.Text, true);
            //lbliconPassword.Text = LanguageXmlUtils.GetValue("new_pwd", lbliconPassword.Text, true);
            //lblVerifyPwd.Text = LanguageXmlUtils.GetValue("verify_pwd", lblVerifyPwd.Text, true);
            //lblImgCode.Text = LanguageXmlUtils.GetValue("image_code", lblImgCode.Text, true);
            //lblCode.Text = LanguageXmlUtils.GetValue("verification_code", lblCode.Text, true);
            //btnModifyPwd.Text = LanguageXmlUtils.GetValue("btn_modify_pwd", btnModifyPwd.Text);
            //btnSendCode.Text = LanguageXmlUtils.GetValue("send", btnSendCode.Text);
        }

        public FrmForgetPwd()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            //this.Text = "忘记密码";
        }
        public string loginTelephone = "";
        private void FrmForgetPwd_Load(object sender, EventArgs e)
        {
            showTipBottom = 77;
            showTipWidth = 135;
            txtTelephone.Text = ConfigurationManager.AppSettings["userId"];
            if (loginTelephone.Length > 0) txtTelephone.Text = loginTelephone;
            if (txtTelephone.Text.Length > 0) { textTelText = true; RefreshCodeImage(); }
        }

        private void FrmForgetPwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Messenger.Default.Send("regist_back", MessageActions.SHOW_LOGINFORM);
            this.Dispose();
        }


        /// <summary>
        /// 刷新图形码
        /// </summary>
        private void PicImgCode_Click(object sender, EventArgs e)
        {
            RefreshCodeImage();
        }
        private void RefreshCodeImage()
        {
            string phone = txtTelephone.Text.Replace("请输入手机号", ""); ;

            if (UIUtils.IsNull(phone) || phone.Length < 11)
            {
                panelLinePhone.BackColor = Color.Red;
                ShowTip("请输入正确的手机号码");
                //ShowTip("账号不能为空");
                //txtImgCode.Text = "请输入正确答案";
                //txtImgCode.ForeColor = Color.FromArgb(153, 153, 153);
                //txtImgCodeText = false;
                this.txtTelephone.Focus();
                return;
            }

            string code = lblContry.Text.ToString().Remove(0, 1);

            // 获取验证码url
            string url = HttpUtils.Instance.Get()
                .Url(Applicate.URLDATA.data.apiUrl + "getImgCode/v1")
                .AddParams("telephone", code + phone)
                .Build(true).BuildUrl();

            // 显示验证码
            ImageLoader.Instance.DisplayImage(url, picImgCode, false);

            // 激活显示发送按钮
            btnSendCode.Enabled = true;
            //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
            btnSendCode.Text = "获取验证码";

            countdown = 60;
            tmrCode.Stop();

        }

        #region 发送短信验证码
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendCode_Click(object sender, EventArgs e)
        {


            panelLineCode.BackColor = Color.LightGray;
            panelLinePhone.BackColor = Color.LightGray;
            panelLineSms.BackColor = Color.LightGray;
            panelLinePwd.BackColor = Color.LightGray;
            panelLinePwdChk.BackColor = Color.LightGray;

            panelLineCode.BackColor = Color.LightGray;
            panelLinePhone.BackColor = Color.LightGray;
            panelLineSms.BackColor = Color.LightGray;
            panelLinePwd.BackColor = Color.LightGray;
            panelLinePwdChk.BackColor = Color.LightGray;

            string phone = txtTelephone.Text.Trim().Replace("请输入手机号", ""); ;
            string pwd = txtNewPwd.Text.Trim().Replace("请输入新密码", "");
            string areaCode = lblContry.Text.ToString().Remove(0, 1);
            string rcode = txtCode.Text.Trim().Replace("请输入验证码", ""); ;
            string imgCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");


            if (UIUtils.IsNull(imgCode))
            {
                panelLineCode.BackColor = Color.Red;
                ShowTip("请输入正确答案");
                txtImgCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(phone) || phone.Length < 11)
            {
                panelLinePhone.BackColor = Color.Red;
                ShowTip("请输入正确的手机号码");
                return;
            }


            //if (string.IsNullOrEmpty(rcode))
            //{
            //    panelLineSms.BackColor = Color.Red;
            //    ShowTip("验证码不能为空");
            //    return;
            //}




            if (string.IsNullOrEmpty(pwd))
            {
                panelLinePwd.BackColor = Color.Red;
                ShowTip("新密码不能为空");
                return;
            }



            if (!string.Equals(txtNewPwd.Text.Replace("请输入新密码", ""), txtConfirmPwd.Text.Replace("请确认密码", "")))
            {
                panelLinePwdChk.BackColor = Color.Red;
                ShowTip("新密码和确认密码不一致");
                return;
            }

            // 请求发送短信验证码
            RequestSendRandCode(phone, areaCode, imgCode);
        }

        /// <summary>
        /// 请求服务器发送短信验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="areaCode"></param>
        /// <param name="imgCode"></param>
        public void RequestSendRandCode(string phone, string areaCode, string imgCode)
        {
            // 请求服务器发送验证码
            tmrCode.Start();
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "basic/randcode/sendSms")
                .AddParams("language", "zh")
                .AddParams("areaCode", areaCode)
                .AddParams("telephone", phone)
                .AddParams("imgCode", imgCode)
                .AddParams("isRegister", "0")
                .AddParams("version", "1")
                .AddErrorListener((code, msg) =>
                {
                    ShowTip(msg);
                    btnSendCode.Enabled = true;
                    RefreshCodeImage();
                    //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                    btnSendCode.Text = "获取验证码";
                    txtImgCode.Text = "请输入正确答案";
                    txtImgCode.ForeColor = Color.FromArgb(153, 153, 153);
                    txtImgCodeText = false;
                    countdown = 60;
                    tmrCode.Stop();
                })
                .Build().Execute((s, msg) =>
                {
                    if (s)
                    {
                        txtCode.Focus();
                        string rcode = UIUtils.DecodeString(msg, "code");
                        LogUtils.Log("服务端验证码:" + rcode);
                    }
                    else
                    {
                        btnSendCode.Enabled = true;
                        //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                        btnSendCode.Text = "获取验证码";
                        countdown = 60;
                        tmrCode.Stop();
                    }
                });
        }

        #endregion

        #region 重置密码
        private void BtnModifyPwd_Click(object sender, EventArgs e)
        {

            panelLineCode.BackColor = Color.LightGray;
            panelLinePhone.BackColor = Color.LightGray;
            panelLineSms.BackColor = Color.LightGray;
            panelLinePwd.BackColor = Color.LightGray;
            panelLinePwdChk.BackColor = Color.LightGray;

            string phone = txtTelephone.Text.Trim().Replace("请输入手机号", ""); ;
            string pwd = txtNewPwd.Text.Trim().Replace("请输入新密码", "");
            string areaCode = lblContry.Text.ToString().Remove(0, 1);
            string rcode = txtCode.Text.Trim().Replace("请输入验证码", ""); ;
            string imgCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");



            if (string.IsNullOrEmpty(phone) || phone.Length < 11)
            {
                panelLinePhone.BackColor = Color.Red;
                ShowTip("请输入正确的手机号码");
                return;
            }

            if (UIUtils.IsNull(imgCode))
            {
                panelLineCode.BackColor = Color.Red;
                ShowTip("请输入正确答案");
                txtImgCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(rcode))
            {
                panelLineSms.BackColor = Color.Red;
                ShowTip("验证码不能为空");
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                panelLinePwd.BackColor = Color.Red;
                ShowTip("新密码不能为空");
                return;
            }



            //if (rcode.Length != 6)
            //{
            //    ShowTip("验证码长度不正确");
            //    return;
            //}

            if (!string.Equals(txtNewPwd.Text.Replace("请输入新密码", ""), txtConfirmPwd.Text.Replace("请确认密码", "")))
            {
                panelLinePwdChk.BackColor = Color.Red;
                ShowTip("新密码和确认密码不一致");
                return;
            }

            //if (txtNewPwd.Text.Replace("请输入新密码", "").Length < 5)
            //{
            //    ShowTip("新密码长度过短");
            //    return;
            //}

            if (Applicate.ENABLE_ASY_ENCRYPT)
            {
                // 兼容老账号的dh加密
                CheckSupportSecureChat();
            }
            else
            {
                RequestResetPassword(phone, pwd, areaCode, rcode, false);
            }
        }



        /// <summary>
        /// 请求重置密码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="areaCode"></param>
        /// <param name="pwd"></param>
        /// <param name="rcode"></param>
        private void RequestResetPassword(string phone, string password, string areaCode, string rcode, bool isSupportSecureChat = false)
        {
            string RequestUrl = string.Empty;
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            if (isSupportSecureChat)
            {
                RequestUrl = Applicate.URLDATA.data.apiUrl + "user/password/reset/v1";

                var dhKeyPair = ECDH.CretaeDHKeyPair();
                string dhPublicKey = dhKeyPair.ToPublicString();
                string dhPrivateKey = dhKeyPair.ToPrivateString();
                string encryptDhPriKey = SecureChatUtil.AesEncryptDHPrivateKey(password, dhPrivateKey);

                var rsaKeyPair = RSA.CreateRsaKey();
                string rsaPublicKey = rsaKeyPair.ToPublicString();
                string rsaPrivateKey = rsaKeyPair.ToPrivateString();
                string encryptRsaPriKey = SecureChatUtil.AesEncryptRSAPrivateKey(password, rsaPrivateKey);

                string signature = SkSSLUtils.SignatureUpdateKeys(password, phone);

                pairs.Add("dhPublicKey", dhPublicKey);
                pairs.Add("dhPrivateKey", encryptDhPriKey);
                pairs.Add("rsaPublicKey", rsaPublicKey);
                pairs.Add("rsaPrivateKey", encryptRsaPriKey);
                pairs.Add("mac", signature);
            }
            else
            {
                RequestUrl = Applicate.URLDATA.data.apiUrl + "user/password/reset";
            }

            pairs.Add("telephone", phone);
            pairs.Add("randcode", rcode);
            pairs.Add("areaCode", areaCode);
            pairs.Add("newPassword", SecureChatUtil.CiphertextPwd(password));

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams(pairs)
                .AddErrorListener((ecode, msg) =>
                {
                    ShowTip(msg);
                })
                .Build()
                .Execute((suss, ResultData) =>
                {
                    if (suss)
                    {
                        // 保存账号信息
                        SaveAccountInfo();

                        // 保存此账号刚刚忘记了密码，需要重新去下载群组
                        LocalDataUtils.SetIntData("just_forgetpwd" + phone, 1);
                        Messenger.Default.Send("reset_success", MessageActions.SHOW_LOGINFORM);
                        this.Dispose();
                    }
                });
        }

        #endregion

        #region 记住账号
        /// <summary>
        /// 保存账号信息
        /// </summary>
        private void SaveAccountInfo()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["areaCodeIndex"].Value = lblContry.Text.ToString(); // 账号（默认记住）
            cfa.AppSettings.Settings["userId"].Value = txtTelephone.Text.Replace("请输入手机号", ""); ; // 账号（默认记住）
            cfa.AppSettings.Settings["passWord"].Value = string.Empty;
            cfa.AppSettings.Settings["rememberPwd"].Value = "False"; // 自动赋值
            cfa.Save();
        }

        #endregion


        private void tmrCode_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                btnSendCode.Enabled = false;
                btnSendCode.BackColor = Color.White;
                btnSendCode.Text = countdown + "s";
                countdown--;
            }
            else
            {
                btnSendCode.Enabled = true;
                btnSendCode.Text = "获取验证码";
                //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                countdown = 60;
                tmrCode.Stop();
            }
        }

        private void lblContry_Click(object sender, EventArgs e)
        {
            FrmControl frmControl = new FrmControl();
            frmControl.loadData();
            frmControl.prefix = (prefix) =>
            {
                lblContry.Text = prefix.ToString();
                lblContry.Text = "+" + prefix.ToString();
            };
        }

        private void CheckSupportSecureChat()
        {
            string phone = txtTelephone.Text.Trim().Replace("请输入手机号", ""); ;
            string pwd = txtNewPwd.Text.Trim().Replace("请输入新密码", "");
            string areaCode = lblContry.Text.ToString().Remove(0, 1);
            string rcode = txtCode.Text.Trim().Replace("请输入验证码", ""); ;


            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "authkeys/isSupportSecureChat")
                .AddParams("areaCode", areaCode)
                .AddParams("telephone", phone)
                .Build(true).Execute((suss, ResultData) =>
                {
                    if (suss)
                    {
                        int isSupport = UIUtils.DecodeInt(ResultData, "isSupportSecureChat");

                        if (1 == isSupport)
                        {
                            if (HttpUtils.Instance.ShowPromptBox("忘记密码将重置端到端加密密钥对，服务器上已加密的单聊聊天记录将无法解密!"))
                            {
                                RequestResetPassword(phone, pwd, areaCode, rcode, true);
                            }
                        }
                        else
                        {
                            RequestResetPassword(phone, pwd, areaCode, rcode, false);
                        }
                    }
                });
        }


        private bool textTelText = false;
        private void txtTelephone_Enter(object sender, EventArgs e)
        {

            if (textTelText == false)
                txtTelephone.Text = "";

            txtTelephone.ForeColor = Color.Black;
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "请输入手机号";
                txtTelephone.ForeColor = Color.FromArgb(153, 153, 153);
                textTelText = false;
            }
            else
            {
                textTelText = true; PicImgCode_Click(null, null);
            }

        }


        private void txtConfirmPwd_Leave(object sender, EventArgs e)
        {

            if (txtConfirmPwd.Text == "")
            {
                txtConfirmPwd.Text = "请确认密码";
                txtConfirmPwd.ForeColor = Color.FromArgb(153, 153, 153);
                txtConfirmPwd.PasswordChar = default(char);
                txtConfirmPwdText = false;
            }
            else
                txtConfirmPwdText = true;
        }

        private bool txtImgCodeText = false;
        private void txtImgCode_Enter(object sender, EventArgs e)
        {
            if (txtImgCodeText == false)
                txtImgCode.Text = "";

            txtImgCode.ForeColor = Color.Black;
            if (string.IsNullOrEmpty(txtImgCode.Text.Trim().Replace("请输入正确答案", "")))
            {
                //RefreshCodeImage();
            }
        }

        private void txtImgCode_Leave(object sender, EventArgs e)
        {
            if (txtImgCode.Text == "")
            {
                txtImgCode.Text = "请输入正确答案";
                txtImgCode.ForeColor = Color.FromArgb(153, 153, 153);
                txtImgCodeText = false;
            }
            else
                txtImgCodeText = true;

        }

        private bool txtCodeText = false;
        private void txtCode_Enter(object sender, EventArgs e)
        {
            if (txtCodeText == false)
                txtCode.Text = "";

            txtCode.ForeColor = Color.Black;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                txtCode.Text = "请输入验证码";
                txtCode.ForeColor = Color.FromArgb(153, 153, 153);
                txtCodeText = false;
            }
            else
                txtCodeText = true;
        }


        public bool showPwdText = false;
        public bool showConfirmText = false;

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            showPwdText = !showPwdText;
            pictureBox7.Image = showPwdText ? Resources.pwdShowIcon : Resources.loginpwdsee;

            if (txtNewPwdText)
            {
                txtNewPwd.PasswordChar = showPwdText ? '\0' : '●';
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            showConfirmText = !showConfirmText;
            pictureBox8.Image = showConfirmText ? Resources.pwdShowIcon : Resources.loginpwdsee;

            if (txtConfirmPwdText)
            {
                txtConfirmPwd.PasswordChar = showConfirmText ? '\0' : '●';
            }
        }




        private bool txtNewPwdText = false;
        private void txtNewPwd_Enter(object sender, EventArgs e)
        {
            if (txtNewPwdText == false)
            {
                txtNewPwdText = true;
                txtNewPwd.Text = "";
            }

            txtNewPwd.PasswordChar = showPwdText ? '\0' : '●';
            txtNewPwd.ForeColor = Color.Black;
        }

        private bool txtConfirmPwdText = false;
        private void txtConfirmPwd_Enter(object sender, EventArgs e)
        {

            if (txtConfirmPwdText == false)
            {
                txtConfirmPwdText = true;
                txtConfirmPwd.Text = "";
            }

            txtConfirmPwd.PasswordChar = showConfirmText ? '\0' : '●';
            txtConfirmPwd.ForeColor = Color.Black;
        }

        private void txtNewPwd_Leave(object sender, EventArgs e)
        {

            if (txtNewPwd.Text == "")
            {
                txtNewPwd.Text = "请输入新密码";
                txtNewPwd.ForeColor = Color.FromArgb(153, 153, 153);
                txtNewPwd.PasswordChar = default(char);
                txtNewPwdText = false;
            }
            else
                txtNewPwdText = true;
        }


    }
}
