using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Helper;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk
{
    /// <summary>
    /// 设置窗体
    /// <para>lxq-3.12</para>
    /// </summary>
    public partial class FrmSet : FrmBase
    {
        private List<string> FriendFromLst = new List<string>();
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmSet_title", this.Text);
            tpAccountSet.Text = LanguageXmlUtils.GetValue("account_set", tpAccountSet.Text);
            tpGeneralSet.Text = LanguageXmlUtils.GetValue("general_set", tpGeneralSet.Text);
            tpPrivacySet.Text = LanguageXmlUtils.GetValue("privacy_set", tpPrivacySet.Text);
            tpChangePwd.Text = LanguageXmlUtils.GetValue("change_pwd", tpChangePwd.Text);
            c.Text = LanguageXmlUtils.GetValue("about_us", c.Text);
            btnEdit.Text = LanguageXmlUtils.GetValue("edit_info", btnEdit.Text);
            btnCancel.Text = LanguageXmlUtils.GetValue("logout", btnCancel.Text);
            btninputAllfriendxls.Text = LanguageXmlUtils.GetValue("export_fd_history_xls", btninputAllfriendxls.Text);
            btninputAllroomxls.Text = LanguageXmlUtils.GetValue("export_gp_history_xls", btninputAllroomxls.Text);
            btninputAllfriendtxt.Text = LanguageXmlUtils.GetValue("export_fd_history_txt", btninputAllfriendtxt.Text);
            btninputAllroomtxt.Text = LanguageXmlUtils.GetValue("export_gp_history_txt", btninputAllroomtxt.Text);
            btnmuchSend.Text = LanguageXmlUtils.GetValue("mass_msg", btnmuchSend.Text);
            btnDeleteCache.Text = LanguageXmlUtils.GetValue("clear_cache", btnDeleteCache.Text);
            btnDeleteChat.Text = LanguageXmlUtils.GetValue("clear_history", btnDeleteChat.Text);
            lblFdValidation.Text = LanguageXmlUtils.GetValue("fd_validation", lblFdValidation.Text);
            lblKnowTyping.Text = LanguageXmlUtils.GetValue("let_know_typing", lblKnowTyping.Text);
            lblDevicesLogin.Text = LanguageXmlUtils.GetValue("can_devices_login", lblDevicesLogin.Text);
            lblAddMePhone.Text = LanguageXmlUtils.GetValue("can_search_me_by_phone", lblAddMePhone.Text);
            lblAddMeName.Text = LanguageXmlUtils.GetValue("can_search_me_by_name", lblAddMeName.Text);
            lblRoamingTime.Text = LanguageXmlUtils.GetValue("roaming_time", lblRoamingTime.Text);
            lblAddWay.Text = LanguageXmlUtils.GetValue("allow_to_add_my_way", lblAddWay.Text);
            lblServicePattern.Text = LanguageXmlUtils.GetValue("service_pattern", lblServicePattern.Text);
            lblMsgPopup.Text = LanguageXmlUtils.GetValue("new_msg_popup", lblMsgPopup.Text);
            lblMsgStatus.Text = LanguageXmlUtils.GetValue("show_msg_status", lblMsgStatus.Text);
            lblOldPwd.Text = LanguageXmlUtils.GetValue("old_pwd", lblOldPwd.Text, true);
            lblNewPwd.Text = LanguageXmlUtils.GetValue("new_pwd", lblNewPwd.Text, true);
            lblVerifyPwd.Text = LanguageXmlUtils.GetValue("verify_pwd", lblVerifyPwd.Text, true);
            btnRevise.Text = LanguageXmlUtils.GetValue("btn_change_pwd", btnRevise.Text);
            btnUpdate.Text = LanguageXmlUtils.GetValue("btn_check_update", btnUpdate.Text);
            tsmHour.Text = LanguageXmlUtils.GetValue("one_hour", tsmHour.Text);
            tsmDay.Text = LanguageXmlUtils.GetValue("one_day", tsmDay.Text);
            tsmWeek.Text = LanguageXmlUtils.GetValue("one_week", tsmWeek.Text);
            tsmMonth.Text = LanguageXmlUtils.GetValue("one_month", tsmMonth.Text);
            tsmSeason.Text = LanguageXmlUtils.GetValue("one_season", tsmSeason.Text);
            tsmYear.Text = LanguageXmlUtils.GetValue("one_year", tsmYear.Text);
            tsmForever.Text = LanguageXmlUtils.GetValue("permanent", tsmForever.Text);
            tsmsynchronize.Text = LanguageXmlUtils.GetValue("out-sync", tsmsynchronize.Text);
        }

        public FrmSet()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            //lblCompanyName.Text = Applicate.URLDATA.data.companyName;
            lblCopyright.Text = Applicate.URLDATA.data.copyright;
            HttpUtils.Instance.InitHttp(this);
            lblEdition.Text = Applicate.APP_VERSION;
            if (!Applicate.IsInputChatList)
            {
                btninputAllfriendtxt.Visible = false;
                btninputAllfriendxls.Visible = false;
                btninputAllroomtxt.Visible = false;
                btninputAllroomxls.Visible = false;
                btnDeleteCache.Visible = true;
                btnDeleteChat.Visible = true;
                btnDeleteChat.Location = new System.Drawing.Point(184, 215);
                btnDeleteCache.Location = new System.Drawing.Point(184, 142);
            }


            this.Load += FrmSet_Load1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSet_Load1(object sender, EventArgs e)
        {
            // 读取缓存文件大小
            ReadCacheFile();
        }



        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();
            // 设置文字是居中的
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            //画出选项卡文字
            e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text, System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.Black), e.Bounds, sf);
        }

        private bool state = false;//窗体是否加载成功
        private void FrmSet_Load(object sender, EventArgs e)
        {


            chkshowtips.Checked = Applicate.ShowMsgTipWindowd == true ? true : false;
            //设置DrawMode 为 OwnerDrawFixed 可以再可视化编辑里设置
            this.tabSet.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //控制选项卡大小
            this.tabSet.ItemSize = new Size(30, 80);
            //设置Alignment 为 Left/Right 可以再可视化编辑里设置
            this.tabSet.Alignment = System.Windows.Forms.TabAlignment.Left;
            //将tabcontrol的drawitem 重写 交给自己写的DrawItem方法
            this.tabSet.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);

            ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, false, (bitmap) =>
            {
                Bitmap size = BitmapUtils.ChangeSize(bitmap, picHead.Width, picHead.Height);
                picHead.BackgroundImage = BitmapUtils.GetRoundImage(size);
            });

            //隐私设置获取、好友验证、消息加密、正在输入
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("userId", Applicate.MyAccount.userId).
                Build().Execute((suss, data) =>
                {
                    if (suss)
                    {
                        Applicate.MyAccount.settings.friendsVerify = UIUtils.DecodeInt(data, "friendsVerify");//好友验证
                        chkPrivacy.Checked = Applicate.MyAccount.settings.friendsVerify == 1;

                        Applicate.MyAccount.sendInput = UIUtils.DecodeInt(data, "isTyping") == 1;//正在输入
                        chkSendInput.Checked = Applicate.MyAccount.sendInput;
                        MultiDeviceManager.Instance.IsEnable = UIUtils.DecodeString(data, "multipleDevices") == "1";
                        chkMultipleDevices.Checked = MultiDeviceManager.Instance.IsEnable;
                        OverdueDate(UIUtils.DecodeString(data, "chatSyncTimeLen"), false);
                        AddToway(UIUtils.DecodeString(data, "friendFromList"));
                        chkAllowtoPhone.Checked = UIUtils.DecodeInt(data, "phoneSearch") == 1;
                        chkAllowtoNickname.Checked = UIUtils.DecodeInt(data, "nameSearch") == 1;

                        chkAllowtoCustomer.Checked = UIUtils.DecodeInt(data, "openService") == 1;
                        Applicate.ServiceMode = UIUtils.DecodeInt(data, "openService") == 1;

                        Applicate.MyAccount.isShowMsgState = UIUtils.DecodeInt(data, "isShowMsgState") == 1;
                        chkNewsState.Checked = Applicate.MyAccount.isShowMsgState;
                        state = true;
                    }
                    else
                    {
                        ShowTip("设置获取出现异常");
                    }
                });

            #region 刷新头像
            Messenger.Default.Register<string>(this, MessageActions.UPDATE_HEAD, (userid) =>
            {

                if (Applicate.MyAccount.userId.Equals(userid))
                {
                    picHead.isDrawRound = true;
                    ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, picHead);
                }

            });
            #endregion
        }

        private void FrmSet_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //划横线
            Pen pen = new Pen(Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197))))), 1);
            Point point1 = new Point(82, 0);
            Point point2 = new Point(82, 467);
            graphics.DrawLine(pen, point1, point2);
        }


        private bool isUpdatePwd;
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevise_Click(object sender, EventArgs e)
        {

            string oldPassword = txtOldPwd.Text.Trim();
            string newPassword = txtNewPwd.Text.Trim();

            if (isUpdatePwd)
            {
                return;
            }

            if (UIUtils.IsNull(oldPassword))
            {
                ShowTip("旧密码不能为空");
                return;
            }

            if (UIUtils.IsNull(newPassword) || UIUtils.IsNull(txtConfirmPwd.Text))
            {
                ShowTip("密码不能为空");
                return;
            }

            if (!newPassword.Equals(txtConfirmPwd.Text.Trim()))
            {
                ShowTip("两次密码不一致");
                return;
            }

            if (newPassword.Length < 5)
            {
                ShowTip("密码长度过短");
                return;
            }

            isUpdatePwd = true;
            if (!UIUtils.IsNull(Applicate.MyAccount.rsaPrivateKey) && Applicate.ENABLE_ASY_ENCRYPT)
            {
                RequestCheckCode(oldPassword, newPassword);
            }
            else
            {
                RequestChangePwd(oldPassword, newPassword);
            }

        }
        private void RequestCheckCode(string oldpwd, string newpwd)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/getRandomStr")
                .AddParams("access_token", Applicate.Access_Token)
                .Build().Execute((sccess, data) =>
                {
                    if (sccess)
                    {
                        string content = UIUtils.DecodeString(data, "userRandomStr");
                        string authCode = RSA.DecryptFromBase64Pk1(content, Applicate.MyAccount.rsaPrivateKey);
                        RequestChangePwd(oldpwd, newpwd, authCode);
                    }
                    else
                    {

                    }
                    isUpdatePwd = false;
                });
        }

        private void RequestChangePwd(string oldpwd, string newpwd, string authCode = null)
        {
            string RequestUrl = string.Empty;

            Dictionary<string, string> pairs = new Dictionary<string, string>();

            pairs.Add("access_token", Applicate.Access_Token);
            pairs.Add("telephone", Applicate.MyAccount.Telephone);
            pairs.Add("areaCode", Applicate.MyAccount.areaCode);
            pairs.Add("oldPassword", SecureChatUtil.CiphertextPwd(oldpwd));
            pairs.Add("newPassword", SecureChatUtil.CiphertextPwd(newpwd));

            // 兼容老版本账号
            if (UIUtils.IsNull(authCode))
            {
                RequestUrl = Applicate.URLDATA.data.apiUrl + "user/password/update";
            }
            else
            {
                // 取出本地保存的私钥，使用新密码加密私钥，上传服务器
                string newDHPrivateKey = SecureChatUtil.AesEncryptDHPrivateKey(newpwd, Applicate.MyAccount.dhPrivateKey);
                string newRSAPrivateKey = SecureChatUtil.AesEncryptRSAPrivateKey(newpwd, Applicate.MyAccount.rsaPrivateKey);
                string signature = SkSSLUtils.SignatureUpdateKeys(newpwd, authCode);

                pairs.Add("dhPrivateKey", newDHPrivateKey);
                pairs.Add("rsaPrivateKey", newRSAPrivateKey);
                pairs.Add("mac", signature);

                RequestUrl = Applicate.URLDATA.data.apiUrl + "user/password/update/v1";
            }

            HttpUtils.Instance.Get().Url(RequestUrl)
                .AddParams(pairs)
                .Build().Execute((sccess, data) =>
                {
                    if (sccess)
                    {
                        ShowTip("密码修改成功,请重新登录,程序正在重启");
                        //登录记住密码清空
                        Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        cfa.AppSettings.Settings["passWord"].Value = String.Empty;
                        cfa.Save();

                        btnCancel_Click(null, null);
                    }
                    else
                    {
                        ShowTip("密码修改失败");
                    }
                    isUpdatePwd = false;
                });
        }


        /// <summary>
        /// 打开编辑资料窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {




            var tmpset = Applicate.GetWindow<FrmRegisterInfo>();
            if (tmpset == null)
            {
                var query = new FrmRegisterInfo();
                query.Location = new Point(this.Location.X + (this.Width - query.Width) / 2, this.Location.Y + (this.Height - query.Height) / 2);//居中


                query.LoadShow();
                query.Text = LanguageXmlUtils.GetValue("edit_info", "编辑资料");
            }
            else
            {
                tmpset.Activate();
            }

        }

        /// <summary>
        /// 清除聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteChat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(LanguageXmlUtils.GetValue("sure_to_clear", "确认清除聊天记录？"),
                LanguageXmlUtils.GetValue("tips", "提示"), MessageBoxButtons.OKCancel))
            {

                var frmSchedule = new FrmSchedule();
                frmSchedule.ClearAllMsgRecord();
                frmSchedule.Compte = () =>
                {
                    HttpUtils.Instance.PopView(frmSchedule);
                    ShowTip("删除聊天记录成功");
                };

            }
        }

        /// <summary>
        /// 隐私设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPrivacy_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("friendsVerify", chkPrivacy.Checked ? "1" : "0")
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            ShowTip("修改好友验证设置成功");
                        }
                        else
                        {
                            ShowTip("设置好友验证出现异常");
                        }
                    });
            }
        }


        /// <summary>
        /// 显示正在输入设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSendInput_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {

                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("isTyping", chkSendInput.Checked ? "1" : "0")
                    .Build().Execute((suus, data) =>
                    {
                        if (suus)
                        {
                            Applicate.MyAccount.sendInput = chkSendInput.Checked;
                            ShowTip("修改显示正在输入设置成功");
                        }
                        else
                        {
                            ShowTip("设置显示正在输入出现异常");
                        }
                    });
            }
        }
        /// <summary>
        /// 多点登录设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMultipleDevices_CheckedChanged(object sender, EventArgs e)
        {
            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("multipleDevices", chkMultipleDevices.Checked ? "1" : "0")
                    .Build().Execute((suus, data) =>
                    {
                        if (suus)
                        {
                            MessageBox.Show("多设备登录设置成功,重启程序方能生效", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MultiDeviceManager.Instance.IsEnable = chkMultipleDevices.Checked;
                        }
                        else
                        {
                            ShowTip("设置多设备登录出现异常");
                        }
                    });
            }
        }


        /// <summary>
        /// 读取缓存文件大小
        /// </summary>
        private void ReadCacheFile()
        {
            string str = Applicate.AppCurrentPerson + "Downloads\\ShikuIM";

            Task.Factory.StartNew(() =>
            {
                long size = FileUtils.GetDirectorySize(str);
                string text = UIUtils.FromatFileSize(size);

                this.Invoke(new Action(() =>
                {
                    btnDeleteCache.Text = LanguageXmlUtils.GetValue("clear_cache", "清空缓存") + text;
                }));

            });
        }



        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCache_Click(object sender, EventArgs e)
        {
            btnDeleteCache.Enabled = false;
            Task.Factory.StartNew(() =>
            {
                string path = Applicate.AppCurrentPerson + "Downloads\\ShikuIM";
                FileUtils.ClearAppCacheFile(path);

                this.Invoke(new Action(() =>
                {
                    btnDeleteCache.Enabled = true;
                    ShowTip("清除成功");
                    btnDeleteCache.Text = LanguageXmlUtils.GetValue("clear_cache", "清空缓存") + "(0B)";
                }));

            });

            //LocalDataUtils.SetBoolData("clearcache", true);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ShowTip("正在退出登录...");
            ShiKuManager.ApplicationExit();
            LocalDataUtils.SetStringData(Applicate.QUIT_TIME, TimeUtils.CurrentIntTime().ToString());

            // 关闭任务栏图标
            Messenger.Default.Send("1030102", MessageActions.CLOSE_NOTIFY_INCO);

            //此处调用退出接口

            Application.ExitThread();
            Application.Exit();
            //Application.Restart();
            Process.GetCurrentProcess().Kill();

        }

        private void lblOverdueDate_Click(object sender, EventArgs e)
        {
            cmsOverdueDate.Show(lblOverdueDate, 0, lblOverdueDate.Height);
        }
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Applicate.APP_VERSION.Replace(".", "") != Applicate.URLDATA.data.pcVersion && !string.IsNullOrEmpty(Applicate.URLDATA.data.pcZipUrl))
            {
                if (MessageBox.Show("有新的版本是否需要进行更新", "系统更新", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    File.Delete("Download.config");
                    FileStream fsWrite = new FileStream("Download.config", FileMode.OpenOrCreate);
                    byte[] buffer = Encoding.Default.GetBytes(Applicate.URLDATA.data.pcZipUrl);
                    fsWrite.Write(buffer, 0, buffer.Length);
                    fsWrite.Close();
                    string path = Applicate.AppCurrentDirectory;
                    Process process = new Process();
                    process.StartInfo.FileName = "update.exe";
                    process.StartInfo.WorkingDirectory = path; //要掉用得exe路径例如:"C:\windows";               
                    process.StartInfo.CreateNoWindow = true;
                    if (File.Exists(process.StartInfo.FileName))
                    {
                        process.Start();
                        Application.ExitThread();
                        Application.Exit();
                    }
                    Application.Exit();
                }
            }
            else
            {

                HttpUtils.Instance.ShowTip("暂无更新");

                //if (string.IsNullOrEmpty(Applicate.URLDATA.data.pcAppUrl))
                //{
                //    HttpUtils.Instance.ShowPromptBox("请检查服务器下载地址");
                //}
                //else
                //{
                //    HttpUtils.Instance.ShowPromptBox("暂无更新");
                //}

            }




        }

        private void FrmSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }

        /// <summary>
        /// 过期时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void HttpSubDate(string date)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                .AddParams("access_token", Applicate.Access_Token)
               .AddParams("userId", Applicate.MyAccount.userId)
                .AddParams("chatSyncTimeLen", date)

                .Build().Execute((sucess, data) =>
                {
                    if (sucess)
                    {
                        OverdueDate(date, true);
                        LogUtils.Log("修改成功");
                    }
                });
        }


        /// <summary>
        /// 设置消息过期内容
        /// </summary>
        /// <param name="date"></param>
        private void OverdueDate(string date, bool a)
        {

            string save = date;
            switch (date)
            {
                case "-1":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", "永久");
                    save = "0";
                    break;
                case "0":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("permanent", "永久");
                    break;
                case "-2":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("out-sync", "不同步");
                    break;
                case "0.04":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_hour", "1小时");
                    break;
                case "1.0":
                case "1":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_day", "1天");
                    break;
                case "7.0":
                case "7":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_week", "1周");
                    break;
                case "30.0":
                case "30":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_week", "1月"); ;
                    break;
                case "90.0":
                case "90":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_season", "1季");
                    break;
                case "365.0":
                case "365":
                    lblOverdueDate.Text = LanguageXmlUtils.GetValue("one_year", "1年");
                    break;
                default:
                    LogUtils.Log("修改失败");
                    save = "0";
                    break;
            }
            //if (a)
            //{
            //    LocalDataUtils.SetStringData(mFriend.userId + "chatRecordTimeOut" + Applicate.MyAccount.userId, save);
            //}

        }
        /// <summary>
        /// 永久
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmForever_Click(object sender, EventArgs e)
        {
            HttpSubDate("-1");
        }
        /// <summary>
        /// 不同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmsynchronize_Click(object sender, EventArgs e)
        {
            HttpSubDate("-2");
        }
        /// <summary>
        /// 1小时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmHour_Click(object sender, EventArgs e)
        {
            HttpSubDate("0.04");
        }
        /// <summary>
        /// 一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDay_Click(object sender, EventArgs e)
        {
            HttpSubDate("1.0");
        }
        /// <summary>
        /// 一周
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmWeek_Click(object sender, EventArgs e)
        {
            HttpSubDate("7.0");
        }
        /// <summary>
        /// 一月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmMonth_Click(object sender, EventArgs e)
        {
            HttpSubDate("30.0");
        }
        /// <summary>
        /// 一季
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSeason_Click(object sender, EventArgs e)
        {
            HttpSubDate("90.0");
        }
        /// <summary>
        /// 一年
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmYear_Click(object sender, EventArgs e)
        {
            HttpSubDate("365.0");
        }
        /// <summary>
        /// 添加方式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allowtoway_Click(object sender, EventArgs e)
        {

            FrmAddstate frmAddstate = new FrmAddstate();
            frmAddstate.FriendFromLst = FriendFromLst;
            frmAddstate.ShowDialog();
            if (frmAddstate.DialogResult == DialogResult.OK)
            {
                FriendFromLst = frmAddstate.FriendFromLst;
                RequestUpdateAddType();
            }
        }

        /// <summary>
        /// 设置添加方式
        /// </summary>
        /// <param name="date"></param>
        private void AddToway(string date)
        {

            if (date == null || date == "")
            {
                lblallowtoway.Text = "";
                return;
            }
            int length = (date.Length + 1) / 2;
            string[] value = new string[length];
            if (date.Contains(','))
            {

                value = date.Split(',');
            }
            else
            {
                value[0] = date;
            }
            string towaytext = string.Empty;
            FriendFromLst = new List<string>();
            for (int i = 0; i < value.Length; i++)
            {
                string save = date;
                if (value[i] == "0")
                {
                    continue;
                }
                FriendFromLst.Add(value[i]);
                //switch (value[i])
                //{
                //    case "0":
                //        towaytext += "系统添加好友" + ",";
                //        save = "0";
                //        break;
                //    case "1":
                //        towaytext += "二维码" + ",";
                //        save = "0";
                //        break;
                //    case "2":
                //        towaytext += "名片" + ",";
                //        break;
                //    case "3":
                //        towaytext += "群组" + ",";
                //        break;
                //    case "4":
                //        towaytext += "手机号搜索" + ",";
                //        break;
                //    case "5":
                //        towaytext += "昵称搜索" + ",";
                //        break;
                //    default:
                //        LogUtils.Log("修改失败");
                //        save = "0";
                //        break;
                //}
            }
            lblallowtoway.Text = value.Length + "种";
        }



        /// <summary>
        /// 允许手机号搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAllowtoPhone_Click(object sender, EventArgs e)
        {
            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("phoneSearch", chkAllowtoPhone.Checked ? "1" : "0")
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            ShowTip("修改手机号搜索设置成功");
                        }
                        else
                        {
                            ShowTip("设置手机号搜索设置出现异常");
                        }
                    });
            }

        }
        /// <summary>
        /// 昵称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAllowtoNickname_Click(object sender, EventArgs e)
        {
            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("nameSearch", chkAllowtoNickname.Checked ? "1" : "0")
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            ShowTip("修改昵称搜索设置成功");
                        }
                        else
                        {
                            ShowTip("设置昵称搜索设置出现异常");
                        }
                    });
            }
        }
        /// <summary>
        /// 导出所有好友聊天记录的xls格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninputAllfriendxls_Click(object sender, EventArgs e)
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }
            else
            {
                return;
            }
            if (!btninputAllfriendxls.Enabled)
            { return; }
            btninputAllfriendxls.Enabled = false;
            //我将业务放在线程里处理,若不让在线程里,this.btnConfirm.Enabled = false;不会有禁止效果,因为本次主线程没有完成。
            Task task = new Task(() =>
            {
                savetoExcel(getfriendorroomLst(0), personImgPath);
                btninputAllfriendxls.Enabled = true;
            }
            );
            task.Start();
        }

        /// <summary>
        /// 获取所有好友聊天记录
        /// </summary>
        /// <returns></returns>
        private List<MessageObject> friendlistchat(string toUserid)
        {
            List<MessageObject> messages = new MessageObject()
            {
                FromId = Applicate.MyAccount.userId,
                ToId = toUserid
            }.LoadRecordMsg();
            return messages;
        }
        /// <summary>
        /// 获取群组的所有聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninputAllroomxls_Click(object sender, EventArgs e)
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }
            else
            {
                return;
            }
            if (!btninputAllroomxls.Enabled)
            { return; }
            btninputAllroomxls.Enabled = false;
            //我将业务放在线程里处理,若不让在线程里,this.btnConfirm.Enabled = false;不会有禁止效果,因为本次主线程没有完成。
            Task task = new Task(() =>
            {
                savetoExcel(getfriendorroomLst(1), personImgPath);
                btninputAllroomxls.Enabled = true;
            }
            );
            task.Start();

        }
        /// <summary>
        /// 获得数据库的好友或者群组列表
        /// </summary>
        /// <param name="flag">0表示好友，1表示群组</param>
        private List<Friend> getfriendorroomLst(int flag)
        {
            Friend friend = new Friend { UserId = Applicate.MyAccount.userId };
            List<Friend> friendlst = new List<Friend>();
            if (flag == 0)
            {
                return friendlst = friend.GetFriendsList();//好友列表
            }
            else
            {
                return friendlst = friend.GetGroupsList();//群组列表
            }
        }
        /// <summary>
        /// 保存为excel
        /// </summary>
        /// <param name="friendlst">好友或群组列表</param>

        private void savetoExcel(List<Friend> friendlst, string personImgPath)
        {

            List<MessageObject> Alllist = new List<MessageObject>();
            for (int i = 0; i < friendlst.Count; i++)
            {
                Alllist = new List<MessageObject>();
                Alllist = friendlistchat(friendlst[i].UserId);
                string filepath = string.Empty;
                string user = string.Empty;
                if (friendlst[i].UserId.Length > 4)
                {
                    user = (friendlst[i].UserId).Substring(friendlst[i].UserId.Length - 4, 4);
                }
                else
                {
                    user = friendlst[i].UserId;
                }
                if (friendlst[i].IsGroup == 0)
                {
                    filepath = personImgPath + "\\" + friendlst[i].NickName + "与" + Applicate.MyAccount.nickname + "的聊天记录" + user + ".xlsx"; //文件路径(好友)
                }
                else
                {
                    filepath = personImgPath + "\\" + friendlst[i].NickName + "的聊天记录" + user + ".xlsx"; //文件路径（群组）
                }
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("发送者");//列

                dt.Columns.Add("内容");
                dt.Columns.Add("时间");
                dt.Columns.Add("类型");

                for (int j = 0; j < Alllist.Count; j++)
                {
                    DataRow dr2 = dt.NewRow();//行
                    dr2[0] = Alllist[j].fromUserName;
                    if (Alllist[j].content == null)
                    {
                        Alllist[j].content = "";
                    }
                    dr2[1] = Alllist[j].content;
                    dr2[2] = TimeUtils.FromatTime(Convert.ToInt64(Alllist[j].timeSend), "yyyy / MM / dd HH: mm:ss");
                    dr2[3] = UIUtils.NewstypeTostring(Alllist[j].type);
                    dt.Rows.Add(dr2);
                }
                InputFileUtils.DataTableToExcel(filepath, dt, false);//保存exele,
            }
            HttpUtils.Instance.ShowTip("聊天记录导出成功");
        }
        /// <summary>
        /// 全部好友导出txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninputAllfriendtxt_Click(object sender, EventArgs e)
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;

            }

            else
            {
                return;
            }
            if (!btninputAllfriendtxt.Enabled)
            { return; }
            btninputAllfriendtxt.Enabled = false;
            //我将业务放在线程里处理,若不让在线程里,this.btnConfirm.Enabled = false;不会有禁止效果,因为本次主线程没有完成。
            Task task = new Task(() =>
            {
                SaveTotxt(getfriendorroomLst(0), personImgPath);
                btninputAllfriendtxt.Enabled = true;
            }
            );
            task.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendlst">群组列表或好友列表</param>
        private void SaveTotxt(List<Friend> friendlst, string personImgPath)
        {
            List<MessageObject> Alllist = new List<MessageObject>();
            for (int i = 0; i < friendlst.Count; i++)
            {
                Alllist = new List<MessageObject>();
                Alllist = friendlistchat(friendlst[i].UserId);
                string filepath = string.Empty;
                string user = string.Empty;
                if (friendlst[i].UserId.Length > 4)
                {
                    user = (friendlst[i].UserId).Substring(friendlst[i].UserId.Length - 4, 4);
                }
                else
                {
                    user = friendlst[i].UserId;
                }
                if (friendlst[i].IsGroup == 0)
                {
                    filepath = personImgPath + "\\" + friendlst[i].NickName + "与" + Applicate.MyAccount.nickname + "的聊天记录" + user + ".txt"; //文件路径(好友)
                }
                else
                {
                    filepath = personImgPath + "\\" + friendlst[i].NickName + "的聊天记录" + user + ".txt"; //文件路径（群组）
                }
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                InputFileUtils.SaveTxtFile(Alllist, filepath);//保存文件
            }
            HttpUtils.Instance.ShowTip("聊天记录导出成功");
        }
        /// <summary>
        /// 群聊txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninputAllroomtxt_Click(object sender, EventArgs e)
        {
            string personImgPath = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                personImgPath = dialog.SelectedPath;
            }

            else
            {
                return;
            }
            if (!btninputAllroomtxt.Enabled)
            { return; }
            btninputAllroomtxt.Enabled = false;
            //我将业务放在线程里处理,若不让在线程里,this.btnConfirm.Enabled = false;不会有禁止效果,因为本次主线程没有完成。
            Task task = new Task(() =>
            {
                SaveTotxt(getfriendorroomLst(1), personImgPath);
                btninputAllroomtxt.Enabled = true;
            }
            );
            task.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSortSelect frmSortSelect = new FrmSortSelect();
            frmSortSelect.Show();
        }
        /// <summary>
        /// 开启或者关闭客服模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAllowtoCustomer_Click(object sender, EventArgs e)
        {
            if (state)
            {
                SetCustomer();
            }
        }
        /// <summary>
        /// 设置客服模式（如果失败就保持原来的设置）
        /// </summary>
        private void SetCustomer()
        {
            string openSerivice = chkAllowtoCustomer.Checked ? "1" : "0";
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/findEmployee")
              .AddParams("access_token", Applicate.Access_Token)
              .AddParams("companyId", "5cd2fdfd0c03d03c19a109c7")
              .AddParams("departmentId", "5cd2fdfd0c03d03c19a109c9")
                .AddParams("openService", openSerivice)
                  .AddParams("userId", Applicate.MyAccount.userId)
               .Build().Execute((suss, data) =>
               {
                   if (suss)
                   {
                       HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "org/employee/updateEmployee")
               .AddParams("access_token", Applicate.Access_Token)
               .AddParams("companyId", "5cd2fdfd0c03d03c19a109c7")
                 .AddParams("isPause", openSerivice)
               .AddParams("departmentId", "5cd2fdfd0c03d03c19a109c9")
               .AddParams("userId", Applicate.MyAccount.userId)
                .Build().Execute((sucess, result) =>
                {
                    if (sucess)
                    {
                        HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                   .AddParams("access_token", Applicate.Access_Token)
                   .AddParams("openService", chkAllowtoCustomer.Checked ? "1" : "0")
                   .Build().Execute((s, dt) =>
                   {
                       if (s)
                       {
                           if (chkAllowtoCustomer.Checked)
                           {
                               Applicate.ServiceMode = true;
                               ShowTip("客户模式开启");
                           }
                           else
                           {
                               Applicate.ServiceMode = false;
                               ShowTip("客户模式关闭");
                           }
                           string value = chkAllowtoCustomer.Checked ? "1" : "0";
                           Messenger.Default.Send(value, MessageActions.XMPP_UPDATE_CUSTOMERSERVICE);// 更新UI消息
                       }
                       else
                       {
                           ShowTip("设置客户模式失败");
                           if (openSerivice == "0")
                           {
                               chkAllowtoCustomer.Checked = true;
                           }
                           else
                           {
                               chkAllowtoCustomer.Checked = false;
                           }
                       }
                   });
                    }
                    else
                    {
                        if (openSerivice == "0")
                        {
                            chkAllowtoCustomer.Checked = true;
                        }
                        else
                        {
                            chkAllowtoCustomer.Checked = false;
                        }
                    }
                });
                   }
                   else
                   {
                       if (openSerivice == "0")
                       {
                           chkAllowtoCustomer.Checked = true;
                       }
                       else
                       {
                           chkAllowtoCustomer.Checked = false;
                       }
                   }
               });
        }

        /// <summary>
        /// 更新允许添加我的方式到服务器
        /// </summary>
        private void RequestUpdateAddType()
        {
            string value = string.Empty;
            for (int i = 0; i < FriendFromLst.Count; i++)
            {
                if (i != (FriendFromLst.Count - 1))
                    value += FriendFromLst[i] + ",";
                else
                {
                    value += FriendFromLst[i];
                }
            }

            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("FriendFromList", value)
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            lblallowtoway.Text = FriendFromLst.Count + "种";
                        }
                        else
                        {
                            ShowTip("设置好友验证出现异常");
                        }
                    });
            }
        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }

        }
        /// <summary>
        /// 群发消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmuchSend_Click(object sender, EventArgs e)
        {
            FrmMassMsg frmMassMsg = null;
            var frmFriendSelect = new FrmSortSelect();
            frmFriendSelect.LoadFriendsData(true, true, true, true, true);
            frmFriendSelect.Show();
            frmFriendSelect.AddConfrmListener((UserFriends) =>
            {

                HttpUtils.Instance.PopView(frmFriendSelect);

                Invoke(new Action(() =>
                {
                    //调用群发消息聊天窗
                    frmMassMsg = new FrmMassMsg(UserFriends);
                    frmMassMsg.Show();

                }));

            });

            //Dictionary<string, Friend> UserFriends = new Dictionary<string, Friend>();
            //Friend friend = new Friend();
            //friend.UserId = "10055";
            //friend.NickName = "10055";
            //UserFriends.Add("10055", friend);
        }

        private void chkshowtips_Click(object sender, EventArgs e)
        {
            Applicate.ShowMsgTipWindowd = chkshowtips.Checked;
        }

        private void chkNewsState_Click(object sender, EventArgs e)
        {
            if (state)
            {
                HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "user/settings/update")
                    .AddParams("access_token", Applicate.Access_Token)
                    .AddParams("isShowMsgState", chkNewsState.Checked ? "1" : "0")
                    .Build().Execute((suss, data) =>
                    {
                        if (suss)
                        {
                            Applicate.MyAccount.isShowMsgState = chkNewsState.Checked;
                            ShowTip("修改消息状态设置成功");
                        }
                        else
                        {
                            ShowTip("设置消息状态出现异常");
                        }
                    });
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Language.ImportDataByXML();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            FrmFeedback Feedback = new FrmFeedback();
            Feedback.ShowDialog();
            if (Feedback.DialogResult == DialogResult.OK)
            {
                ShowTip("反馈意见提交成功！");
            }
        }

        private void btnAgreement_Click(object sender, EventArgs e)
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
        private void btnPrivacy_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FrmPrivacy"];
            if (frm == null)
            {
                FrmPrivacy frmPrivacy = new FrmPrivacy();
                frmPrivacy.html = Applicate.URLDATA.data.privacy.privacy;
                frmPrivacy.Show();
            }
            else
            {
                frm.Activate();
            }
        }
    }
}

