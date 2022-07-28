using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk
{
    /// <summary>
    /// 注册信息填写页
    /// </summary>
    public partial class FrmRegisterInfo : FrmBase
    {
        // 头像地址
        private string avatarPath;

        //等待符
        private LodingUtils loding;

        // 手机号码/用户名
        private string phone;

        // 密码
        private string password;

        // 邀请码
        private string inviteCode;

        // 短信验证码
        private string randCode;

        // 区号
        private string areaCode;

        public Friend Registerfriend;

        private bool State = true;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblNickname.Text = LanguageXmlUtils.GetValue("nickname", lblNickname.Text, true);
            lblSex.Text = LanguageXmlUtils.GetValue("sex", lblSex.Text, true);
            lblBirthday.Text = LanguageXmlUtils.GetValue("date_of_birth", lblBirthday.Text, true);
            lblLivePlace.Text = LanguageXmlUtils.GetValue("live_place", lblLivePlace.Text, true);
            lblAccountIM.Text = LanguageXmlUtils.GetValue("account_IM", lblAccountIM.Text, true);
            btnSubmit.Text = LanguageXmlUtils.GetValue("btn_submit", btnSubmit.Text);
            //int loc_x = lblNickname.Location.X - 14;
            //lblNickname.Location = new Point(loc_x, lblNickname.Location.Y);
            //lblSex.Location = new Point(loc_x, lblSex.Location.Y);
            //lblBirthday.Location = new Point(loc_x, lblBirthday.Location.Y);
            //lblLivePlace.Location = new Point(loc_x, lblLivePlace.Location.Y);
            //lblAccountIM.Location = new Point(loc_x, lblAccountIM.Location.Y);
        }

        public FrmRegisterInfo()
        {
            InitializeComponent();

            LoadLanguageText();
            //是否开启位置服务
            if (Applicate.URLDATA.data.isOpenPositionService == 1)
            {
                lblAccountIM.Location = lblLivePlace.Location;
                txtAccount.Location = txtRegion.Location;
                lblLivePlace.Visible = false;
                txtRegion.Visible = false;
            }
            //加载icon图标
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);
            this.FormClosing += new FormClosingEventHandler(this.FrmRegisterInfo_FormClosing);


            //账号注册默认值
            //txtSex.Text = "男";
            //cmbSex.SelectedIndex = 0;
            txtRegion.Text = "广东省深圳市";
            txtRegion.Tag = "440000|440300";

            this.dtpBirthday.DatePicker.Value = DateTime.Now;
        }


        private void LoadCityMenu()
        {

            Task.Factory.StartNew(() =>
            {
                ////加载省市级菜单
                Areas areas = new Areas();
                areas.parent_id = 1;
                areas.type = 2;
                List<Areas> listAreas = areas.GetChildrenList();
                foreach (Areas a in listAreas)
                {
                    ToolStripMenuItem tool = new ToolStripMenuItem();
                    tool.Tag = a.id;
                    tool.Text = a.name;

                    //加载子级菜单
                    Areas areas2 = new Areas();
                    areas2.parent_id = a.id;
                    areas2.type = 3;
                    List<Areas> listAreeas2 = areas2.GetChildrenList();
                    foreach (Areas a2 in listAreeas2)
                    {
                        ToolStripMenuItem tool2 = new ToolStripMenuItem();
                        tool2.Tag = a2.id;
                        tool2.Text = a2.name;
                        tool2.Click += Tool2_Click;
                        tool.DropDownItems.Add(tool2);
                    }

                    BeginInvoke(new Action(() =>
                    {

                        cmsRegion.Items.Add(tool);
                    }));

                }
            });


        }

        // 设置界面修改信息需要重新请求数据
        public void LoadShow()
        {
            this.Show();
            lblAccountIM.Visible = true;
            txtAccount.Visible = true;
            panelAccount.Visible = true;
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/get")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        Friend friend = JsonConvert.DeserializeObject<Friend>(JsonConvert.SerializeObject(data));
                        Registerfriend = friend;
                        ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, picHead, false); //加载头像
                        string Region = String.Empty;
                        txtNickname.Text = friend.NickName;
                        //txtSex.Text = friend.Sex == 1 ? "男" : "女";
                        //cmbSex.SelectedIndex = friend.Sex == 1 ? 0 : 1;

                        if (friend.Birthday != 0)
                        {
                            dtpBirthday.DatePicker.Value = Helpers.StampToDatetime(friend.Birthday);
                        }

                        Areas EditAreas = new Areas();
                        EditAreas.id = friend.CityId;
                        EditAreas = EditAreas.GetModel();
                        Region = EditAreas.name;
                        EditAreas.id = EditAreas.parent_id;
                        EditAreas = EditAreas.GetModel();
                        txtRegion.Text = EditAreas.name + Region;
                        txtRegion.Tag = friend.ProvinceId + "|" + friend.CityId;
                        if (!string.IsNullOrEmpty(UIUtils.DecodeString(data, "account")))
                        {
                            txtAccount.Enabled = false;
                        }

                        txtAccount.Text = UIUtils.DecodeString(data, "account"); //通讯号
                    }
                });
        }

        // 注册界面传递过来的数据
        public void InitData(string phone, string pwd, string areaCode, string rcode, string inviteCode)
        {
            // 手机号码/用户名
            this.phone = phone;
            // 密码
            this.password = pwd;
            // 邀请码
            this.inviteCode = inviteCode;
            // 短信验证码
            this.randCode = rcode;
            // 区号
            this.areaCode = areaCode;
        }

        /// <summary>
        /// 打开选择头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>      
        private void PicHead_Click(object sender, EventArgs e)
        {
            OpenImage();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        public void OpenImage()
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "所有图像文件|*.bmp;*.pcx;*.png;*.jpg;*.gif;*.jpeg";
            fileDialog.Title = "打开图像文件";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectUrl = fileDialog.FileNames[0];

                string outUrl = selectUrl;

                FileInfo firstFileInfo = new FileInfo(selectUrl);
                if (firstFileInfo.Length > 20 * 1024)
                {
                    outUrl = UploadAvatarProcess(selectUrl);
                }

                // 加载选择的头像
                ImageLoader.Instance.Load(outUrl).Background().Avatar().Into(picHead);
                this.avatarPath = outUrl;
            }
        }

        private string UploadAvatarProcess(string path)
        {
            string extension = FileUtils.GetFileExtension(path);

            string filename = Guid.NewGuid().ToString("N") + extension;

            string outpath = Applicate.LocalConfigData.ImageFolderPath + filename;

            BitmapUtils.CompressAvatarProcess(path, outpath, 80, 50);

            return outpath;
        }


        #region 性别输入框的处理
        /// <summary>
        /// 弹出性别选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSex_Click(object sender, EventArgs e)
        {
            cmsSex.Show((TextBox)sender, new Point(0, ((TextBox)sender).Size.Height));
        }

        /// <summary>
        /// 性别禁止输入处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// 赋值个文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Man_Click(object sender, EventArgs e)
        {
            //txtSex.Text = "男";
            //txtSex.Select(txtSex.Text.Length, 0);
        }

        /// <summary>
        /// 赋值文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Woman_Click(object sender, EventArgs e)
        {
            //txtSex.Text = "女";
            //txtSex.Select(txtSex.Text.Length, 0);
        }

        #endregion

        #region 位置信息的处理

        /// <summary>
        /// 打开菜单位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRegion_Click(object sender, EventArgs e)
        {
            cmsRegion.Show(this, 0, 0);
        }

        /// <summary>        /// 禁止输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        /// <summary>
        /// 点击市级菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool2_Click(object sender, EventArgs e)
        {
            ToolStripItem tool = ((ToolStripMenuItem)sender).OwnerItem;
            txtRegion.Tag = tool.Tag.ToString() + "|" + ((ToolStripMenuItem)sender).Tag.ToString();
            txtRegion.Text = tool.Text + ((ToolStripMenuItem)sender).Text;
            txtRegion.Select(txtRegion.Text.Length, 0);
            LogUtils.Log(txtRegion.Tag.ToString());
        }
        #endregion

        // 显示加载框
        private void ShowLodingDialog(Control control)
        {
            loding = new LodingUtils();
            loding.parent = control;
            loding.Title = "加载中";
            loding.start();
        }

        //性别初始值为男(1)
        private string Sex = "1";
        /// <summary>
        /// 注册与修改好友资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string Nickname = txtNickname.Text.TrimStart().Trim();
            //string Sex = txtSex.Text.Trim() == "男" ? "1" : "0";

            if (checkMale.Checked)
            {

            }
            string Birthday = Helpers.DatetimeToStamp(dtpBirthday.DatePicker.Value).ToString();
            string Region = txtRegion.Tag.ToString();

            if (UIUtils.IsNull(Nickname))
            {
                ShowTip("昵称不能为空");
                return;
            }

            if (UIUtils.IsNull(Sex))
            {
                ShowTip("性别不能为空");
                return;
            }

            if (UIUtils.IsNull(Birthday))
            {
                ShowTip("生日不能为空");
                return;
            }

            if (UIUtils.IsNull(Region))
            {
                ShowTip("居住地不能为空");
                return;
            }

            if (UIUtils.IsNull(avatarPath) && Registerfriend == null)
            {
                ShowTip("头像不能为空");
                return;
            }

            string CountryID = "1";//国家ID
            string ProvinceID = Region.Split('|')[0];
            string cityID = Region.Split('|')[1];

            if (Registerfriend == null)
            {
                if (reigesting)
                {
                    return;
                }

                reigesting = true;
                // 去注册
                RequestHttpRegist(Nickname, Sex, Birthday, CountryID, ProvinceID, cityID);
            }
            else
            {
                // 去修改资料
                RequestUpdateInfo(Nickname, Sex, Birthday, CountryID, ProvinceID, cityID);
            }
        }

        private bool reigesting = false;

        #region 修改用户资料
        private void RequestUpdateInfo(string nickname, string sex, string birthday, string countryID, string provinceID, string cityID)
        {
            ShowLodingDialog(this);

            BaseRequstBuilder builder = HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/update");
            builder.AddParams("access_token", Applicate.Access_Token);
            builder.AddParams("userType", "1");
            builder.AddParams("nickname", nickname);
            builder.AddParams("sex", sex);
            builder.AddParams("birthday", birthday);
            builder.AddParams("countryId", countryID);
            builder.AddParams("provinceId", provinceID);
            builder.AddParams("cityId", cityID);
            if (txtAccount.Enabled && txtAccount.Visible)
            {
                builder.AddParams("account", txtAccount.Text);
            }
            builder.Build().Execute((suss, data) =>
            {
                if (suss)
                {
                    if (!UIUtils.IsNull(this.avatarPath))
                    {
                        LogUtils.Log(data["userId"].ToString());
                        UploadEngine.Instance.From(avatarPath).UploadAvatar(data["userId"].ToString(),
                            (s) =>
                            {
                                if (s)
                                {

                                    ImageLoader.Instance.RefreshAvatar(Applicate.MyAccount.userId);
                                    loding.stop();
                                    Applicate.GetWindow<FrmSet>().ShowTip("修改成功");


                                    HttpUtils.Instance.PopView(this);
                                    Messenger.Default.Send(Applicate.MyAccount.userId, MessageActions.UPDATE_HEAD);//发送刷新头像通知
                                    LogUtils.Log(data.ToString());

                                    this.Close();


                                    //string headUrl = ImageLoader.Instance.GetHeadUrl(Applicate.MyAccount.userId);
                                    //string FileName = FileUtils.GetFileName(headUrl);
                                    //string filePath = Applicate.LocalConfigData.ImageFolderPath + FileName;
                                    //HttpDownloader.DownloadFile(headUrl, filePath, (path) =>
                                    //{
                                    //    if (!string.IsNullOrEmpty(path) || File.Exists(path))
                                    //    {

                                    //        picHead.isDrawRound = true;
                                    //        string a = path;
                                    //        picHead.BackgroundImage = Image.FromFile(path);
                                    //        picHead.BackgroundImageLayout = ImageLayout.Stretch;
                                    //        loding.stop();
                                    //        Applicate.GetWindow<FrmSet>().ShowTip("修改成功");
                                    //        Messenger.Default.Send(Applicate.MyAccount.userId, MessageActions.UPDATE_HEAD);//发送刷新头像通知
                                    //        LogUtils.Log(data.ToString());

                                    //        this.Close();

                                    //    }

                                    //});
                                }

                            });

                    }
                    else
                    {
                        //修改nickName
                        Applicate.MyAccount.nickname = Convert.ToString(data["nickname"]);

                        this.Close();
                        Applicate.GetWindow<FrmSet>().ShowTip("修改成功");
                        LogUtils.Log(data.ToString());
                    }
                }
                else
                {
                    this.Close();
                    Applicate.GetWindow<FrmSet>().ShowTip("修改失败");
                }

            });
        }

        #endregion

        #region 请求注册账号
        private void RequestHttpRegist(string nickname, string sex, string birthday, string countryID, string provinceID, string cityID)
        {
            ShowLodingDialog(this);

            Dictionary<string, string> pairs = new Dictionary<string, string>();


            var dhKeyPair = ECDH.CretaeDHKeyPair();
            string dhPublicKey = dhKeyPair.ToPublicString();
            string dhPrivateKey = dhKeyPair.ToPrivateString();
            string encryptDhPriKey = SecureChatUtil.AesEncryptDHPrivateKey(this.password, dhPrivateKey);


            var rsaKeyPair = RSA.CreateRsaKey();
            string rsaPublicKey = rsaKeyPair.ToPublicString();
            string rsaPrivateKey = rsaKeyPair.ToPrivateString();
            string encryptRsaPriKey = SecureChatUtil.AesEncryptRSAPrivateKey(this.password, rsaPrivateKey);


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
                pairs.Add("inviteCode", inviteCode);
            }

            pairs.Add("areaCode", areaCode);

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
                    loding.stop();
                    ShowTip(msg);
                    reigesting = false;

                }).Build().Execute((susse, resultdata) =>
                {
                    loding.stop();
                    if (susse)
                    {
                        content = UIUtils.DecodeString(resultdata, "data");
                        string deData = AES.NewString(AES.DecryptBase64(content, code));
                        var result = JsonConvert.DeserializeObject<DataOfUserDetial>(deData);
                        result.Telephone = this.phone;
                        result.password = this.password;
                        result.areaCode = this.areaCode;

                        Applicate.MyAccount = result;
                        //赋值全局变量
                        if (!UIUtils.IsNull(this.avatarPath))
                        {
                            UploadEngine.Instance.From(avatarPath).UploadAvatar(result.userId,
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
                    reigesting = false;

                });
        }

        #endregion

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '\r') || (e.KeyChar == '\b'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void FrmRegisterInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Registerfriend == null && State)
            {
                FrmRegister frm = new FrmRegister();
                frm.InitData(phone, password, areaCode, inviteCode);
                frm.Show();
            }
        }

        private void txtNickname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNickname.Text.Length <= 0)
            { //空格不能在第一位
                if ((int)e.KeyChar == 32)
                {
                    e.Handled = true;
                }
            }
        }

        private void FrmRegisterInfo_Load(object sender, EventArgs e)
        {
            LoadCityMenu();
        }

        private void checkMale_Click(object sender, EventArgs e)
        {
            checkMale.Checked = true;
            checkfemale.Checked = false;
            if (checkMale.Checked)
            {
                Sex = "1";
            }
        }

        private void checkfemale_Click(object sender, EventArgs e)
        {
            checkfemale.Checked = true;
            checkMale.Checked = false;
            if (checkfemale.Checked)
            {
                Sex = "0";
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #region 操作优化
        private void txtNickname_Enter(object sender, EventArgs e)
        {
            panelName.BackgroundImage = Properties.Resources.d2;
        }

        private void txtNickname_Leave(object sender, EventArgs e)
        {
            panelName.BackgroundImage = Properties.Resources.d1;
        }

        private void txtRegion_Enter(object sender, EventArgs e)
        {
            panelRegion.BackgroundImage = Properties.Resources.d2;
        }

        private void txtRegion_Leave(object sender, EventArgs e)
        {
            panelRegion.BackgroundImage = Properties.Resources.d1;
        }

        private void dtpBirthday_Enter(object sender, EventArgs e)
        {
            paneldateExt1.BackgroundImage = Properties.Resources.d2;
        }

        private void dtpBirthday_Leave(object sender, EventArgs e)
        {
            paneldateExt1.BackgroundImage = Properties.Resources.d1;
        }

        private void txtAccount_Enter(object sender, EventArgs e)
        {
            panelAccount.BackgroundImage = Properties.Resources.d2;
        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
            panelAccount.BackgroundImage = Properties.Resources.d1;
        }
        #endregion

        private void dtpBirthday_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
