using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Properties;
using WinFrmTalk.View;

namespace WinFrmTalk
{
    /// <summary>
    /// 注册页面
    /// </summary>
    public partial class FrmRegister : FrmBase
    {
        private int countdown = 60;
        private bool State = true;
        private bool openImageCode = false;
        private string inImgCode = "";
        public FrmRegister()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标

            //使用用户名注册
            if (Applicate.URLDATA.data.regeditPhoneOrName == 1)
            {
                //lblPhoneNumber.Text = "用 户 名：";
                lblContry.Visible = false;
                txtTel.Size = txtPassword.Size;
                //txtTel.Location = new Point(100, 155);
            }

            if (Applicate.URLDATA.data.registerInviteCode == 1)
            {
                //lblImgCode.Text = "邀 请 码：";
                picImgCode.Visible = false;
                txtImgCode.Size = txtPassword.Size;
                //lblVerificationCode.Visible = false;
                txtCode.Visible = false;
                txtCode.Text = "不为空";
                btnSendCode.Visible = false;
            }

            if (Applicate.URLDATA.data.isOpenSMSCode == 0)
            {
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                txtImgCode.Visible = false;
                picImgCode.Visible = false;
                lollipopFlatButton1.Visible = false;
                txtCode.Visible = false;
                btnSendCode.Visible = false;
                panelLineSms.Visible = false;
                panelLinePwd.Visible = false;
                pictureBox2.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y);
                txtPassword.Location = new Point(txtImgCode.Location.X, txtImgCode.Location.Y);
            }

            btnRegister.locked = true;
        }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            //this.Text = LanguageXmlUtils.GetValue("register", this.Text);
            //lblPhoneNumber.Text = LanguageXmlUtils.GetValue("phone_number", lblPhoneNumber.Text, true);
            //lblPwd.Text = LanguageXmlUtils.GetValue("password", lblPwd.Text, true);
            //lblImgCode.Text = LanguageXmlUtils.GetValue("image_code", lblImgCode.Text, true);
            //lblVerificationCode.Text = LanguageXmlUtils.GetValue("verification_code", lblVerificationCode.Text, true);
            //btnSendCode.Text = LanguageXmlUtils.GetValue("send", btnSendCode.Text);
            //lblnocode.Text = LanguageXmlUtils.GetValue("no_code", lblnocode.Text);
            //btnRegister.Text = LanguageXmlUtils.GetValue("next_procedure", btnRegister.Text);
        }

        /// <summary>
        /// 初始化注册界面数据
        /// </summary>
        public void InitData(string phone, string pwd, string areaCode, string inviteCode)
        {
            //this.Tel = phone;
            //this.Password = pwd;
            //this.AreaCode = areaCode;
            //this.InviteCode = inviteCode;

            txtTel.Text = phone;
            txtTel.ForeColor = Color.Black;
            textTelText = true;

            txtPassword.Text = pwd;
            txtPassword.PasswordChar = '●';
            txtPassword.ForeColor = Color.Black;
            txtPasswordText = true;

            txtImgCode.Text = inviteCode;
            if (txtImgCode.Text == "")
            {
                txtImgCode.Text = "请输入正确答案";
                txtImgCode.ForeColor = Color.FromArgb(214, 214, 214);
                txtImgCodeText = false;
            }
            else
                txtImgCodeText = true;

            if (!UIUtils.IsNull(areaCode))
            {
                lblContry.Text = "+" + areaCode;
            }
        }

        /// <summary>
        /// 判断账号是否是数字
        /// </summary>
        private void TxtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Applicate.URLDATA.data.regeditPhoneOrName == 0)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }

            if (Applicate.URLDATA.data.regeditPhoneOrName == 1)
            {
                int chfrom = Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fa5）转换成int（chfrom～chend）
                int chend = Convert.ToInt32("9fa5", 16);
                if (e.KeyChar >= (Char)chfrom && e.KeyChar <= (Char)chend)
                {
                    e.Handled = true;
                }
                if (e.KeyChar >= (Char)65281 & (int)e.KeyChar <= (Char)65374)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 倒计时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrCode_Tick(object sender, EventArgs e)
        {
            if (countdown != 0)
            {
                btnSendCode.Enabled = false;
                btnSendCode.BackColor = Color.White;
                btnSendCode.Text = countdown + "s";
                countdown--;
                if (countdown == 30)
                {
                    //lblnocode.Visible = true;
                }
            }
            else
            {
                btnSendCode.Enabled = true;
                btnSendCode.Text = "获取验证码";
                btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                countdown = 60;
                tmrCode.Stop();
            }
        }

        /// <summary>
        /// 选择区号点击
        /// </summary>
        private void LblContry_Click(object sender, EventArgs e)
        {
            FrmControl frmControl = new FrmControl();
            frmControl.loadData();
            frmControl.prefix = (prefix) =>
            {
                lblContry.Text = prefix.ToString();
                lblContry.Text = "+" + prefix.ToString();
            };
        }

        /// <summary>
        /// 注册界面关闭事件
        /// </summary>
        private void FrmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (State)
            {
                Messenger.Default.Send("regist_back", MessageActions.SHOW_LOGINFORM);
                this.Dispose();
            }
        }


        #region 发送短信验证码
        private bool isEnableSCode;
        private void BtnSendCode_Click(object sender, EventArgs e)
        {
            string phone = txtTel.Text.Trim().Replace("请输入手机号", "");
            string imgCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");
            string areaCode = lblContry.Text.Remove(0, 1).Trim();


            if (string.IsNullOrEmpty(phone))
            {
                ShowTip("手机号码不能为空");
                return;
            }

            if (string.IsNullOrEmpty(imgCode))
            {
                ShowTip("图片验证码不能为空");
                return;
            }

            if (isEnableSCode)
            {
                return;
            }

            isEnableSCode = true;
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
                .AddParams("isRegister", "1")
                .AddParams("version", "1")
                .AddErrorListener((code, msg) =>
                {
                    ShowTip(msg);
                    btnSendCode.Enabled = true;
                    //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                    btnSendCode.Text = "获取验证码";
                    countdown = 60;
                    tmrCode.Stop();

                    txtImgCode.Text = "";
                    isEnableSCode = false;
                    RefreshCodeImage();
                })
                .Build().Execute((s, msg) =>
                {
                    if (s)
                    {
                        inImgCode = imgCode;
                        txtCode.Focus();
                        string rcode = UIUtils.DecodeString(msg, "code");
                        LogUtils.Log("服务端验证码:" + rcode);
                        HttpUtils.Instance.ShowTip("验证码已发送，请注意查收");
                    }
                    else
                    {
                        btnSendCode.Enabled = true;
                        //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
                        btnSendCode.Text = "获取验证码";
                        countdown = 60;
                        tmrCode.Stop();
                    }
                    isEnableSCode = false;
                });
        }

        #endregion

        #region 刷新图形码
        /// <summary>
        /// 刷新图形码
        /// </summary>
        private void PicImgCode_Click(object sender, EventArgs e)
        {

            //string phone = txtTel.Text.Replace("请输入手机号", "");

            //if (UIUtils.IsNull(phone))
            //{
            //    ShowTip("账号不能为空");
            //    return;
            //}

            RefreshCodeImage();

            //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
            //btnSendCode.Text = "发送验证码";

            countdown = 60;
            tmrCode.Stop();
        }


        private void RefreshCodeImage()
        {
            string phone = txtTel.Text.Replace("请输入手机号", "");

            if (UIUtils.IsNull(phone) || phone.Length < 11)
            {
                panelLinePhone.BackColor = Color.Red;
                ShowTip("请输入正确的手机号码");
                //txtImgCode.Text = "请输入正确答案";
                //txtImgCode.ForeColor = Color.FromArgb(214, 214, 214);
                //txtImgCodeText = false;
                this.txtTel.Focus();
                return;
            }

            // 激活显示发送按钮
            btnSendCode.Enabled = true;

            string code = lblContry.Text.ToString().Remove(0, 1);

            // 获取验证码url
            string url = HttpUtils.Instance.Get()
                .Url(Applicate.URLDATA.data.apiUrl + "getImgCode/v1")
                .AddParams("telephone", code + phone)
                .Build(true).BuildUrl();

            // 显示验证码
            ImageLoader.Instance.DisplayImage(url, picImgCode, false);

            openImageCode = true;
        }


        #endregion

        #region 注册账号
        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            panelLineUser.BackColor = Color.LightGray;
            panelLineImg.BackColor = Color.LightGray;
            panelLinePhone.BackColor = Color.LightGray;
            panelLineSms.BackColor = Color.LightGray;
            panelLinePwd.BackColor = Color.LightGray;
            panelLinePwdChk.BackColor = Color.LightGray;
            if (requesting)
            {
                return;
            }
            string nickname = npTxtName.Text.Trim().Replace("用户名", "");
            string phone = txtTel.Text.Trim().Replace("请输入手机号", "");
            string pwd = txtPassword.Text.Trim().Replace("请输入密码", "");
            string imgCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");
            string rcode = txtCode.Text.Trim().Replace("验证码", "");

            //if (UIUtils.IsNull(imgCode))
            //{
            //    panelLineImg.BackColor = Color.Red;
            //    ShowTip("请输入正确答案");
            //    return;
            //}



            if (UIUtils.IsNull(nickname))
            {
                panelLineUser.BackColor = Color.Red;
                ShowTip("用户名不能为空");
                npTxtName.Focus();
                return;
            }

            if (phone.Length < 11)
            {
                panelLinePhone.BackColor = Color.Red;
                ShowTip("请输入正确的手机号码");
                return;
            }

            if (UIUtils.IsNull(imgCode))
            {
                panelLineImg.BackColor = Color.Red;
                ShowTip("请填写正确的图形码答案");
                txtImgCode.Focus();
                return;
            }

            if (UIUtils.IsNull(rcode))
            {
                panelLineSms.BackColor = Color.Red;
                ShowTip("请填写正确的验证码");
                txtCode.Focus();
                return;
            }
            //if (txtImgCode.Visible && txtCode.Visible)
            //{
            //    if (string.IsNullOrEmpty(imgCode) && string.IsNullOrEmpty(rcode))
            //    {
            //        ShowTip("信息不能为空");
            //        return;
            //    }
            //}


            if (Applicate.URLDATA.data.isOpenSMSCode == 1)
            {
                if (UIUtils.IsNull(txtCode.Text))
                {
                    ShowTip("验证码不能为空");
                    return;
                }

                if (UIUtils.IsNull(inImgCode))
                {
                    ShowTip("验证码不正确");
                    return;
                }

                if (!string.Equals(imgCode, inImgCode))
                {
                    ShowTip("图形码不正确");
                    return;
                }

                // 新版本不在本地校验短信码
                //if (!Code.Equals(RequestCode))
                //{
                //    ShowTip("验证码不正确");
                //    return;
                //}
            }

            if (UIUtils.IsNull(phone) || UIUtils.IsNull(pwd))
            {
                ShowTip("账号或密码不能为空");
                return;
            }

            if (pwd.Length < 6)
            {
                ShowTip("密码长度应大于6位");
                return;
            }

            if (pwd.Length > 18)
            {
                ShowTip("密码长度应小于18位");
                return;
            }


            if (txtPassword.Text != txtPasswordChk.Text)
            {
                ShowTip("请填写相同的密码");
                return;
            }


            requesting = true;

            // 是否跳过验证码
            bool skipverify = !txtCode.Visible;

            RequesVerifyPhone(phone, pwd, skipverify);

            // 去注册
            //RequestHttpRegist(phone, pwd, npTxtName.Text.Trim(), rbWomen.Checked ? "1" : "0", "", "", "", "", rcode);

            requesting = false;
        }


        /// <summary>
        /// 收不到验证码直接登录
        /// </summary>
        private void Lblnocode_Click(object sender, EventArgs e)
        {
            string phone = txtTel.Text.Trim().Replace("请输入手机号", "");
            string pwd = txtPassword.Text.Trim().Replace("请输入密码", "");
            if (UIUtils.IsNull(phone) || UIUtils.IsNull(pwd))
            {
                ShowTip("账号或密码不能为空");
                return;
            }

            if (pwd.Length < 6)
            {
                ShowTip("密码长度应大于6位");
                return;
            }

            if (pwd.Length > 18)
            {
                ShowTip("密码长度应小于18位");
                return;
            }

            // 验证手机号
            RequesVerifyPhone(phone, pwd, true);
        }

        private bool requesting = false;

        /// <summary>
        /// 请求验证手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <param name="skipverify"></param>
        private void RequesVerifyPhone(string phone, string pwd, bool skipverify)
        {
            string areaCode = lblContry.Text.Remove(0, 1).Trim();
            string inviteCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");
            string rcode = txtCode.Text.Trim().Replace("请输入验证码", "");

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "verify/telephone")
                  .AddParams("areaCode", areaCode)
                  .AddParams("telephone", phone)
                  .Build()
                  .AddErrorListener((code, msg) =>
                  {
                      ShowTip(msg);
                      requesting = false;
                  }).
                  Execute((susse, data) =>
                  {

                      if (susse)
                      {
                          if (data["resultCode"].ToString() == "1")
                          {
                              //FrmRegisterInfo frm = new FrmRegisterInfo();
                              //frm.InitData(phone, pwd, areaCode, rcode, inviteCode);

                              //this.Dispose();
                              //State = false;//防止登录界面闪烁打开
                              //frm.Location = this.Location;
                              //frm.ShowDialog();

                              // 去注册
                              RequestHttpRegist(phone, pwd, npTxtName.Text.Trim(), rbWomen.Checked ? "1" : "0", "", "", "", "", rcode);
                          }
                          else
                          {
                              ShowTip(phone + "已被注册");
                          }
                          LogUtils.Log(data.ToString());
                      }
                      else
                      {
                          // this.btnRegister.Enabled = true;
                          this.btnRegister.Text = "注 册";
                          ShowTip(txtTel.Text.Trim().Replace("请输入手机号", "").Replace(" ", "").Replace("：", "") + "已注册");
                      }

                      requesting = false;
                  });
        }
        #region 请求注册账号
        private void RequestHttpRegist(string phone, string password, string nickname, string sex, string birthday, string countryID, string provinceID, string cityID, string randCode)
        {
            //ShowLodingDialog(this);

            Dictionary<string, string> pairs = new Dictionary<string, string>();


            var dhKeyPair = ECDH.CretaeDHKeyPair();
            string dhPublicKey = dhKeyPair.ToPublicString();
            string dhPrivateKey = dhKeyPair.ToPrivateString();
            string encryptDhPriKey = SecureChatUtil.AesEncryptDHPrivateKey(password, dhPrivateKey);


            var rsaKeyPair = RSA.CreateRsaKey();
            string rsaPublicKey = rsaKeyPair.ToPublicString();
            string rsaPrivateKey = rsaKeyPair.ToPrivateString();
            string encryptRsaPriKey = SecureChatUtil.AesEncryptRSAPrivateKey(password, rsaPrivateKey);


            pairs.Add("dhPublicKey", dhPublicKey);
            pairs.Add("dhPrivateKey", encryptDhPriKey);
            pairs.Add("rsaPublicKey", rsaPublicKey);
            pairs.Add("rsaPrivateKey", encryptRsaPriKey);

            pairs.Add("userType", "1");
            pairs.Add("telephone", phone);
            pairs.Add("password", MD5.MD5Hex(password));

            if (UIUtils.IsNull(randCode))
            {
                // 跳过验证传入0
                pairs.Add("isSmsRegister", "0");
            }
            else
            {
                pairs.Add("isSmsRegister", "1");
                pairs.Add("smsCode", randCode);
            }

            if (Applicate.URLDATA.data.registerInviteCode == 1)
            {
                pairs.Add("inviteCode", "");
            }

            pairs.Add("areaCode", "86");

            pairs.Add("nickname", nickname);
            pairs.Add("sex", sex);
            pairs.Add("birthday", birthday);
            pairs.Add("xmppVersion", "1");

            pairs.Add("countryId", countryID);
            pairs.Add("provinceId", provinceID);
            pairs.Add("cityId", cityID);
            //pairs.Add("areaId", String.valueOf(mTempData.getAreaId()));

            // 附加信息
            //pairs.Add("apiVersion", DeviceInfoUtil.getVersionCode(mContext) + "");
            //pairs.Add("model", DeviceInfoUtil.getModel());
            //pairs.Add("osVersion", DeviceInfoUtil.getOsVersion());
            pairs.Add("serial", UIUtils.Getpcid());

            // 地址信息
            //double latitude = MyApplication.getInstance().getBdLocationHelper().getLatitude();
            //double longitude = MyApplication.getInstance().getBdLocationHelper().getLongitude();
            //String location = MyApplication.getInstance().getBdLocationHelper().getAddress();
            //pairs.Add("latitude", String.valueOf(latitude));
            //pairs.Add("longitude", String.valueOf(longitude));
            //pairs.Add("location", location);


            string salt = TimeUtils.CurrentTimeMillis().ToString();
            byte[] code = MD5.Encrypt(Applicate.API_KEY);

            // 组合验参
            string mac = MAC.EncodeBase64((Applicate.API_KEY + Parameter.JoinValues(pairs) + salt), code);
            pairs.Add("mac", mac);
            string content = JsonConvert.SerializeObject(pairs);
            string data1 = AES.EncryptBase64(content, code);

            //注册 
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/register/v1")
                .AddParams("data", data1)
                .AddParams("salt", salt)
                .AddParams("deviceId", "pc")
                .AddErrorListener((errcode, msg) =>
                {
                    //loding.stop();
                    ShowTip(msg);
                    //reigesting = false;

                }).Build().Execute((susse, resultdata) =>
                {
                    //loding.stop();
                    if (susse)
                    {
                        content = UIUtils.DecodeString(resultdata, "data");
                        string deData = AES.NewString(AES.DecryptBase64(content, code));
                        var result = JsonConvert.DeserializeObject<DataOfUserDetial>(deData);
                        result.Telephone = phone;
                        result.password = password;
                        //result.areaCode = this.areaCode;

                        Applicate.MyAccount = result;
                        //赋值全局变量
                        if (!UIUtils.IsNull(""))
                        {
                            UploadEngine.Instance.From("").UploadAvatar(result.userId,
                                (s) =>
                                {
                                    LogUtils.Log(s.ToString());
                                    Messenger.Default.Send("regist_success", MessageActions.SHOW_LOGINFORM);
                                    State = false;
                                    this.Dispose();
                                });
                        }
                        else
                        {
                            Messenger.Default.Send("regist_success", MessageActions.SHOW_LOGINFORM);
                            State = false;
                            this.Dispose();
                        }
                    }
                    else
                    {
                        Messenger.Default.Send("regist_err", MessageActions.SHOW_LOGINFORM);
                        State = false;
                        this.Dispose();
                    }
                    //reigesting = false;

                });
        }

        #endregion

        #endregion



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = Application.OpenForms["FrmPrivacy"];
            if (frm == null)
            {
                FrmPrivacy frmPrivacy = new FrmPrivacy();
                frmPrivacy.html = Applicate.URLDATA.data.privacy.agreement;
                frmPrivacy.Show();
            }
            else
            {
                frm.Activate();
            }

        }

        #region textbox 操作
        private bool textTelText = false;
        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (textTelText == false)
                txtTel.Text = "";

            txtTel.ForeColor = Color.Black;
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text == "")
            {
                txtTel.Text = "请输入手机号";
                txtTel.ForeColor = Color.FromArgb(214, 214, 214);
                textTelText = false;
            }
            else
            {
                textTelText = true;
                pictureBox7_Click(null, null);
            }
        }



        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "请输入密码";
                txtPassword.ForeColor = Color.FromArgb(214, 214, 214);
                txtPassword.PasswordChar = default(char);
                txtPasswordText = false;
            }
            else
                txtPasswordText = true;

        }

        private bool txtImgCodeText = false;
        private void txtImgCode_Enter(object sender, EventArgs e)
        {
            if (txtImgCodeText == false)
                txtImgCode.Text = "";

            txtImgCode.ForeColor = Color.Black;

            //RefreshCodeImage();
        }

        private void txtImgCode_Leave(object sender, EventArgs e)
        {
            if (txtImgCode.Text == "")
            {
                txtImgCode.Text = "请输入正确答案";
                txtImgCode.ForeColor = Color.FromArgb(214, 214, 214);
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
                txtCode.ForeColor = Color.FromArgb(214, 214, 214);
                txtCodeText = false;
            }
            else
                txtCodeText = true;
        }
        #endregion

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            //RefreshCodeImage();

            showTipBottom = 77;
            showTipWidth = 135;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            RefreshCodeImage();

            //btnSendCode.BackColor = ColorTranslator.FromHtml("#1AAD19");
            btnSendCode.Text = "发送验证码";

            countdown = 60;
            tmrCode.Stop();
        }



        private bool textTxtName = false;
        private void npTxtName_Enter(object sender, EventArgs e)
        {
            if (textTxtName == false)
                npTxtName.Text = "";

            npTxtName.ForeColor = Color.Black;
        }

        private void npTxtName_Leave(object sender, EventArgs e)
        {
            if (npTxtName.Text == "")
            {
                npTxtName.Text = "用户名";
                npTxtName.ForeColor = Color.FromArgb(214, 214, 214);
                textTxtName = false;
            }
            else
                textTxtName = true;
        }

        private void npTxtName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        private void txtPasswordChk_Leave(object sender, EventArgs e)
        {
            if (npTxtName.Text == "")
            {
                txtPasswordChk.Text = "确认密码";
                txtPasswordChk.ForeColor = Color.FromArgb(214, 214, 214);
                textTxtPwdChk = false;
            }
            else
                textTxtPwdChk = true;
        }

        private void txtPasswordChk_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private bool textTxtPwdChk = false;
        private void txtPasswordChk_Enter(object sender, EventArgs e)
        {

            if (textTxtPwdChk == false)
            {
                textTxtPwdChk = true;
                txtPasswordChk.Text = "";
            }

            txtPasswordChk.PasswordChar = showConfirmText ? '\0' : '●';
            txtPasswordChk.ForeColor = Color.Black;
        }

        private bool txtPasswordText = false;
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordText == false)
            {
                txtPasswordText = true;
                txtPassword.Text = "";
            }

            txtPassword.PasswordChar = showPwdText ? '\0' : '●';
            txtPassword.ForeColor = Color.Black;
        }


        public bool showPwdText = false;
        public bool showConfirmText = false;
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            showPwdText = !showPwdText;
            pictureBox8.Image = showPwdText ? Resources.pwdShowIcon : Resources.loginpwdsee;

            if (txtPasswordText)
            {
                txtPassword.PasswordChar = showPwdText ? '\0' : '●';
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            showConfirmText = !showConfirmText;
            pictureBox9.Image = showConfirmText ? Resources.pwdShowIcon : Resources.loginpwdsee;

            if (txtPasswordText)
            {
                txtPasswordChk.PasswordChar = showConfirmText ? '\0' : '●';
            }
        }


        private void CheckedBtnEnabel(object sender, EventArgs e)
        {
            var ok = InputMustText();

            if (ok)
            {
                requesting = false;
                btnRegister.locked = false;
                btnRegister.Image = Resources.ic_login_btn0;
                btnRegister.ForeColor = Color.White;
            }
            else
            {
                btnRegister.locked = true;
                btnRegister.ForeColor = Color.White;
                btnRegister.Image = Resources.ic_login_btn2;
                requesting = true;
            }
        }

        private bool InputMustText()
        {
            string nickname = npTxtName.Text.Trim().Replace("用户名", "");
            string phone = txtTel.Text.Trim().Replace("请输入手机号", "");
            string pwd = txtPassword.Text.Trim().Replace("请输入密码", "");
            string imgCode = txtImgCode.Text.Trim().Replace("请输入正确答案", "");
            string rcode = txtCode.Text.Trim().Replace("验证码", "");
            string confirm = txtPasswordChk.Text.Trim().Replace("确认密码", "");

            if (UIUtils.IsNull(nickname))
            {
                return false;
            }

            if (UIUtils.IsNull(phone))
            {
                return false;
            }

            if (UIUtils.IsNull(imgCode))
            {
                return false;
            }

            if (UIUtils.IsNull(rcode))
            {
                return false;
            }

            if (UIUtils.IsNull(confirm))
            {
                return false;
            }

            if (UIUtils.IsNull(pwd))
            {
                return false;
            }

            return true;
        }
    }
}
