using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View
{
    public partial class FrmRemarkPhone : FrmSuspension
    {
        public FrmRemarkPhone()
        {
            InitializeComponent();
        }
        private string RemarkPhone;
        private Friend myfriend;
        private List<string> phonelst = new List<string>();
        public void setData( string remarkphone, Friend friend)
        {
            RemarkPhone = remarkphone;
            myfriend = friend;
            UserChatSometime useadd = new UserChatSometime();
            useadd.Size = new Size(useadd.Size.Width, 230);
            useadd.picdeleate.Visible = false;
            useadd.lbltext.Click += Useadd_Click;
            useadd.Sometimetext = "添加电话号码";
            useadd.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            useadd.Click += Useadd_Click;
            pnlRemarkPhone.Controls.Add(useadd);
            if (!UIUtils.IsNull(RemarkPhone))
            {

                string[] remarkphones = RemarkPhone.Split(';');
                for (int i = 0; i < remarkphones.Length; i++)
                {

                    UserChatSometime usertext = new UserChatSometime();
                    //  usertext.BackColor = Color.White;
                    usertext.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    usertext.picdeleate.Click += Picdeleate_Click;
                    usertext.picdeleate.Visible = true;
                    usertext.Sometimetext = remarkphones[i];
                    //if (this.Height <= 48)
                    //{
                        pnlRemarkPhone.Height += 48;
                        this.Height += 48;
                    //}
                    phonelst.Add(remarkphones[i]);
                    pnlRemarkPhone.Controls.Add(usertext);
                    pnlRemarkPhone.Controls.SetChildIndex(usertext, 0);

                }
            }
            
        }
        private LodingUtils loding;//等待符
        /// <summary>
        /// 添加电话号码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Useadd_Click(object sender, EventArgs e)
        {
            List<string> phoneadds = new List<string>();
            //FrmSingleSet frmparent= (FrmSingleSet)this.Parent;
            //frmparent.IsClose = false;
            FrmMyColleagueEidt frm = new FrmMyColleagueEidt();
            //  frm.NameEdit = SelectItem.Position;
            frm.FormClosed += (sen, eve) =>
            {
               // frmparent.IsClose = true;
            };
            frm.txtName.GotFocus += (sen, eve) =>
             { 
                 IDataObject iData = Clipboard.GetDataObject();
                 if (iData != null)
                 {
                    
                     if (iData.GetDataPresent(DataFormats.Text))
                     {
                         phoneadds= UIUtils.GetPhonesFromStr((string)iData.GetData(DataFormats.Text));
                         if(phoneadds.Count>0)
                         {
                             for (int i = 0; i < phoneadds.Count; i++)
                             {
                                 frm.txtName.Text += phoneadds[i];
                             }
                         }
                        
                     }
                        
                 }

             };
             frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);
            string addphone = string.Empty;
            frm.ColleagueName((su) =>
            {
                phonelst.Add(su);
                for (int i = 0; i < phonelst.Count; i++)
                {
                    addphone += phonelst[i] + ";";
                }
                addphone = addphone.Substring(0, addphone.Length - 1);
                frm.Close();
                string url = Applicate.URLDATA.data.apiUrl + "friends/modify/phoneRemark";
                HttpUtils.Instance.Get().Url(url)
                                .AddParams("access_token", Applicate.Access_Token)
                                .AddParams("toUserId", myfriend.UserId)
                                .AddParams("phoneRemark", addphone)
                                .Build().Execute((suss, data) =>
                                {
                                    if (suss)
                                    {
                                        UserChatSometime usertext = new UserChatSometime();
                                        usertext.BackColor = Color.White;
                                        usertext.picdeleate.Click += Picdeleate_Click;
                                        usertext.Sometimetext = su;
                                        phonelst.Add(su);
                                        pnlRemarkPhone.Controls.Add(usertext);
                                        pnlRemarkPhone.Controls.SetChildIndex(usertext, 0);
                                        Messenger.Default.Send(myfriend, MessageActions.UPDATE_FRIEND_REMARKSPHONE);
                                    }
                                }
    
                  );
                //frmprent.IsClose = true;
            }

            );

            string title = LanguageXmlUtils.GetValue("title_modify_groupname", "添加手机号备注");
            string name = LanguageXmlUtils.GetValue("name_group_name", "手机号", true);
            frm.ShowThis(title, name);
        }

     /// <summary>
     /// 删除电话号码
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void Picdeleate_Click(object sender, EventArgs e)
        {
            UserChatSometime usertext =((UserChatSometime) (( PictureBox) sender).Parent);
            string delephone = usertext.Sometimetext;
            string phone = string.Empty;
            for (int i = phonelst.Count-1; i >-1; i--)
            {
                if(usertext.Sometimetext.Equals(phonelst[i]))
                {
                    phonelst.Remove(phonelst[i]);
                    
                }
                else
                {
                    phone += phonelst[i] + ";";
                }
              
            }
            phone.Substring(0, phone.Length - 1);
            string url = Applicate.URLDATA.data.apiUrl + "friends/modify/phoneRemark";
            HttpUtils.Instance.Get().Url(url)
                            .AddParams("access_token", Applicate.Access_Token)
                            .AddParams("toUserId", myfriend.UserId)
                            .AddParams("phoneRemarkName", phone)
                            .Build().Execute((suss, data) =>
                            {
                                if (suss)
                                {
                                    for (int i = 0; i < pnlRemarkPhone.Controls.Count; i++)
                                    {
                                        UserChatSometime usephone = (UserChatSometime)pnlRemarkPhone.Controls[i];
                                       if(usephone.Sometimetext.Equals(delephone))
                                        {
                                            pnlRemarkPhone.Controls.Remove(pnlRemarkPhone.Controls[i]);
                                            pnlRemarkPhone.Height -= 48;
                                            this.Height -= 48;
                                            Messenger.Default.Send(myfriend, MessageActions.UPDATE_FRIEND_REMARKSPHONE);
                                        }
                                    }
                                }
                            });
        }

        public void modifyphone(string modifyphone)
        {

          
        }
    }
}
