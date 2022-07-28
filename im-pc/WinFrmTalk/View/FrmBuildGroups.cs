using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmBuildGroups : FrmBase
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            // lblTitle.Text = LanguageXmlUtils.GetValue("create_group", lblTips.Text);
            lblName.Text = LanguageXmlUtils.GetValue("group_name", lblName.Text, true);
            lblDescrip.Text = LanguageXmlUtils.GetValue("group_descrip", lblDescrip.Text, true);
            rlEncrypt.FunctionName = LanguageXmlUtils.GetValue("private_group", rlEncrypt.FunctionName);
            lblTips.Text = LanguageXmlUtils.GetValue("private_group_tip", lblTips.Text);
            btnInviteFrds.Text = LanguageXmlUtils.GetValue("btn_create_group", btnInviteFrds.Text);
        }

        public FrmBuildGroups()
        {
            InitializeComponent();
            LoadLanguageText();
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            //txtGroupName.ImeMode123 = ImeMode.NoControl;
            //txtGroupDis.ImeMode123 = ImeMode.NoControl;
            this.TitleNeed = false;



            if (Applicate.ENABLE_ASY_ENCRYPT)
            {
                rlEncrypt.checkData.Click += CheckData_Click;
            }
            else
            {
                rlEncrypt.Visible = false;
                lblTips.Visible = false;
                this.btnInviteFrds.Location = new Point(64, 203);
                this.Size = new Size(288, 302);
            }


        }

        private void CheckData_Click(object sender, EventArgs e)
        {
            if (!Applicate.ENABLE_ASY_ENCRYPT)
            {
                rlEncrypt.checkData.Checked = false;
                ShowTip("当前版本不支持创建私密群组");
            }

            if (UIUtils.IsNull(Applicate.MyAccount.rsaPrivateKey) || UIUtils.IsNull(Applicate.MyAccount.dhPrivateKey))
            {
                ShowTip("当前账号不支持创建私密群组");
                rlEncrypt.checkData.Checked = false;
            }
        }


        //需要对输入的参数进行限制
        private void btnInviteFrds_Click(object sender, EventArgs e)
        {
            string name = txtGroupName.Text.TrimStart().Trim();
            string roomdesc = txtGroupDis.Text.TrimStart().Trim();

            if (UIUtils.IsNull(name) || UIUtils.IsNull(roomdesc))
            {
                ShowTip("群组名称和群描述不能为空");
                return;
            }

            bool isEncrypt = rlEncrypt.checkData.Checked;

            // 去选择好友
            Friend friend = new Friend();
            friend.NickName = name;
            friend.Description = roomdesc;

            FrmFriendSelect frmFriendSelect = new FrmFriendSelect();
            frmFriendSelect.max_number = 300;
            frmFriendSelect.StartPosition = FormStartPosition.CenterScreen;

            if (isEncrypt)
            {
                // 需要挑选出合法的朋友-一定要带有rsk加密的朋友才可以
                frmFriendSelect.LoadSSLFriends();
            }
            else
            {
                frmFriendSelect.LoadFriendsData();
            }

            frmFriendSelect.AddConfrmListener((Selectdata) =>
            {
                string jid = ShiKuManager.mSocketCore.CreateGroup(friend.NickName, friend.Description);
                if (!string.IsNullOrEmpty(jid))
                {
                    friend.UserId = jid;
                    friend.GroupType = 4;
                    if (isEncrypt)
                    {
                        // 创建私密端到端群组
                        HttpCreateEncryptRoom(friend, Selectdata);
                    }
                    else
                    {
                        // 创建普通群组
                        HttpCreateNormalRoom(friend, Selectdata);
                    }
                }
            });

            this.Close();
        }

        private string ChatKey { get; set; }
        // http创建加密群组
        private void HttpCreateEncryptRoom(Friend friend, Dictionary<string, Friend> select)
        {
            ChatKey = Guid.NewGuid().ToString("N");
            string publickey = Applicate.MyAccount.rsaPublicKey;
            string chatKeyGroup = RSA.EncryptBase64Pk1(ChatKey, publickey);
            //  string decryptChatKeyGroup = RSA.DecryptFromBase64Pk1(chatKeyGroup, Applicate.MyAccount.rsaPrivateKey);

            JObject json = new JObject
            {
                { Applicate.MyAccount.userId, chatKeyGroup }
            };
            string keysStr = json.ToString();

            //Console.WriteLine("zq", "chatKey--->" + chatKey);
            //Console.WriteLine("zq", "chatKeyGroup--->" + chatKeyGroup);
            //Console.WriteLine("zq", "decryptChatKeyGroup--->" + decryptChatKeyGroup);
            //Console.WriteLine("zq", "keysStr--->" + keysStr);

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/add")//新建群组
            .AddParams("jid", friend.UserId)
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("desc", friend.Description)
            .AddParams("name", friend.NickName)
            .AddParams("isLook", "0")
            .AddParams("showRead", "0")
            .AddParams("cityId", "440300")
            .AddParams("countryId", "1")
            .AddParams("provinceId", "440000")
            .AddParams("areaId", "440307")
            .AddParams("longitude", "114.066307")
            .AddParams("latitude", "22.609084")
            .AddParams("isSecretGroup", "1")
            .AddParams("keys", keysStr)
            .Build().Execute((sccess, data) =>
            {
                if (sccess)
                {
                    string roomId = UIUtils.DecodeString(data, "id");
                    // 保存群组信息
                    friend.ShowRead = 0;
                    friend.IsEncrypt = 3;
                    friend.IsGroup = 1;
                    friend.Status = 2;
                    friend.RoomId = roomId;
                    friend.ChatKeyGroup = SecureChatUtil.EncryptChatKey(friend.UserId, ChatKey, Applicate.API_KEY);
                    friend.InsertAuto();

                    // 邀请入群
                    InviteToGroup(roomId, select, 1);
                    // 保存群成员
                    SaveRoomUsers(roomId, select);

                    //刷新列表
                    Messenger.Default.Send(friend, MessageActions.ROOM_UPDATE_INVITE);
                }
                else
                {
                    MessageBox.Show(data.ToString());
                }
            });
        }


        //建群需要传的参数Roomjid,被邀请成员列表，群组名，群组描述
        private void HttpCreateNormalRoom(Friend friend, Dictionary<string, Friend> select)
        {

            //&=1&isLook=1&showRead=0&=1&=1&=1&=1&=1&name=1111111&type=4&=0&language=zh&=&salt=&secret=kTtWcYcxj7%2BwuJuJ9CP7GQ%3D%3D
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "room/add")//新建群组
            .AddParams("jid", friend.UserId)
            .AddParams("access_token", Applicate.Access_Token)
            .AddParams("desc", friend.Description)
            .AddParams("name", friend.NickName)
            .AddParams("cityId", "440300")
            .AddParams("countryId", "1")
            .AddParams("provinceId", "440000")
            .AddParams("areaId", "440307")
            .AddParams("longitude", "114.066307")
            .AddParams("latitude", "22.609084")
            .AddParams("allowConference", "1")
            .AddParams("isLook", "1")
            .AddParams("allowUploadFile", "1")
            .AddParams("allowSendCard", "1")
            .AddParams("showMember", "1")
            .AddParams("allowInviteFriend", "1")
            .AddParams("allowSpeakCourse", "1")
            .AddParams("type", "4")
            .AddParams("showRead", "0")
            .AddParams("isNeedVerify", "0")
            .Build().Execute((sccess, data) =>
            {
                if (sccess)
                {
                    string roomId = UIUtils.DecodeString(data, "id");
                    friend.InsertNonFriend();

                    InviteToGroup(roomId, select, 0);
                    SaveRoomUsers(roomId, select);
                }
                else
                {
                    MessageBox.Show(data.ToString());
                }
            });
        }



        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBoxSender = (TextBox)sender;

            //回车，换行，空格不在第一行
            if (textBoxSender.Text.Length <= 0)
            { //小数点不能在第一位
                if ((int)e.KeyChar == 10 || (int)e.KeyChar == 13 || (int)e.KeyChar == 32)
                {
                    e.Handled = true;
                }
                else
                {
                    //小数点    
                    e.Handled = false;
                    /* float fOriginalAndInput;
                      float fOriginal;
                      bool bCovOriginalAndInput = false, bCovOriginal = false;
                      bCovOriginal = float.TryParse(textBoxSender.Text, out fOriginal);
                      bCovOriginalAndInput = float.TryParse(textBoxSender.Text + e.KeyChar.ToString(), out fOriginalAndInput);
                      if (bCovOriginalAndInput == false)
                      { //输入小数点时，如果输入框内容加上输入的内容不是浮点数
                          if (bCovOriginal == true)
                          {//输入框内容是浮点数，则此次不输入，限制输入小数点的个数，不做处理
                              //  eKeyPress.Handled = true;
                          }
                          else
                          {
                              e.Handled = false;
                          }
                      }*/
                }
            }



        }


        /// <summary>
        ///  邀请入群
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userids"></param>
        /// <param name="isEncrypt">是否端到端加密群组</param>
        private void InviteToGroup(string roomId, Dictionary<string, Friend> select, int isEncrypt)
        {
            List<Friend> datas = new List<Friend>();
            JArray josnIds = new JArray();
            foreach (var item in select.Keys)
            {
                datas.Add(select[item]);
                josnIds.Add(item);
            }

            string memkeys = string.Empty;
            if (isEncrypt == 1)
            {
                memkeys = GetMembersKey(datas, ChatKey);
            }

            string userids = josnIds.ToString();

            Dictionary<string, string> value = new Dictionary<string, string>();
            value.Add("access_token", Applicate.Access_Token);
            value.Add("roomId", roomId);
            value.Add("text", userids);
            value.Add("isSecretGroup", isEncrypt.ToString());
            if (isEncrypt == 1)
            {
                value.Add("keys", memkeys);
            }

            HttpUtils.Instance.InitHttp(this);
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "room/member/update") //获取群详情
            .AddParams(value)
            .AddErrorListener((code, err) =>
            {
                HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip(err);
            })
            .Build().Execute((state, data) =>
            {
                HttpUtils.Instance.FindFrm(typeof(FrmMain)).ShowTip("创建成功");
            });
        }

        // 获取群成员的 ras 公钥集合json
        private string GetMembersKey(List<Friend> select, string chatKey)
        {
            JObject json = new JObject();
            foreach (var friend in select)
            {
                string rskkey = RSA.EncryptBase64Pk1(chatKey, friend.RsaPublicKey);
                json.Add(friend.UserId, rskkey);
            }

            return json.ToString();
        }


        private void SaveRoomUsers(string _roomId, Dictionary<string, Friend> select)
        {
            List<RoomMember> memberList = new List<RoomMember>();
            foreach (KeyValuePair<string, Friend> a in select)
            {
                RoomMember roomMembers = new RoomMember();
                roomMembers.roomId = _roomId;
                roomMembers.userId = a.Key;
                roomMembers.nickName = a.Value.NickName;
                roomMembers.role = 3;
                roomMembers.talkTime = 0;
                roomMembers.sub = 1;
                roomMembers.offlineNoPushMsg = 0;
                roomMembers.remarkName = a.Value.NickName;

                memberList.Add(roomMembers);

            }

            RoomMember roomMember = new RoomMember() { roomId = _roomId };
            roomMember.AutoInsertOrUpdate(memberList);
        }

        private void FrmBuildGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            Messenger.Default.Unregister(this);//反注册
        }
    }
}
