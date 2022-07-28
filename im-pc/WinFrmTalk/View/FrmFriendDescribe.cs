using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmFriendDescribe : FrmBase
    {
        private Friend mFriend;
        private PhoneRemarkAdapter adapter;


        public FrmFriendDescribe()
        {
            InitializeComponent();
            adapter = new PhoneRemarkAdapter();
            adapter.DescribePage = this;
        }

        public void ShowFriend(Friend friend)
        {
            mFriend = friend;

            // 描述
            if (!UIUtils.IsNull(mFriend.Description))
            {
                textBox2.Text = mFriend.Description;
                box2HasText = true;
            }

            // 备注
            if (!UIUtils.IsNull(mFriend.RemarkName))
            {
                textBox1.Text = mFriend.RemarkName;
                box1HasText = true;
            }

            // 手机号列表
            if (!UIUtils.IsNull(mFriend.RemarkPhone))
            {
                string[] arrPhone = mFriend.RemarkPhone.Split(';');
                adapter.BindData(arrPhone.ToList());
                xListView1.SetAdapter(adapter);
            }
            else
            {
                xListView1.SetAdapter(adapter);
            }

            textBox1_Leave(null, null);
            textBox2_Leave(null, null);
            textBox3_Leave(null, null);
        }


        // 更新备注
        private void UpdateRemarkName(string name)
        {
            name = name.Replace("请输入备注,回车确认", "");
            if (!string.IsNullOrEmpty(mFriend.RemarkName) && mFriend.RemarkName.Equals(name))
            {
                return;
            }

            mFriend.RemarkName = name;

            string arrphone = adapter.GetRemarkPhoneStr();
            string url = Applicate.URLDATA.data.apiUrl + "friends/remark";
            HttpUtils.Instance.Get().Url(url)
                            .AddParams("access_token", Applicate.Access_Token)
                            .AddParams("toUserId", mFriend.UserId)
                            .AddParams("remarkName", name)
                            .AddParams("describe", mFriend.Description)
                            .Build().Execute((suss, data) =>
                            {
                                if (suss)
                                {
                                    ShowTip("修改成功");
                                }
                            });
        }


        // 更新描述
        private void UpdateDescribe(string desc)
        {
            desc = desc.Replace("请输入描述,回车确认", "");
            if (string.Equals(desc, mFriend.Description))
            {
                return;
            }

            mFriend.Description = desc;

            string url = Applicate.URLDATA.data.apiUrl + "friends/remark";
            HttpUtils.Instance.Get().Url(url)
                            .AddParams("access_token", Applicate.Access_Token)
                            .AddParams("toUserId", mFriend.UserId)
                            .AddParams("describe", desc)
                            .AddParams("remarkName", mFriend.RemarkName)
                            .Build().Execute((suss, data) =>
                            {
                                if (suss)
                                {
                                    //Messenger.Default.Send(myfriend, MessageActions.UPDATE_FRIEND_REMARKSPHONE);
                                    ShowTip("修改成功");
                                }
                            });
        }


        // 更新手机号
        private void UpdateRemarkPhone()
        {
            string arrphone = adapter.GetRemarkPhoneStr();
            string url = Applicate.URLDATA.data.apiUrl + "friends/modify/phoneRemark";
            HttpUtils.Instance.Get().Url(url)
                            .AddParams("access_token", Applicate.Access_Token)
                            .AddParams("toUserId", mFriend.UserId)
                            .AddParams("phoneRemark", arrphone)
                            .Build().Execute((suss, data) =>
                            {
                                if (suss)
                                {
                                    ShowTip("修改成功");
                                    mFriend.RemarkPhone = arrphone;
                                    Messenger.Default.Send(mFriend, MessageActions.UPDATE_FRIEND_REMARKSPHONE);
                                    //Messenger.Default.Send(myfriend, MessageActions.UPDATE_FRIEND_REMARKSPHONE);
                                }
                            });
        }



        #region 描述文本框事件处理
        private bool box1HasText;
        /// <summary>
        /// textbox获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (box1HasText == false)
                textBox1.Text = "";

            textBox1.ForeColor = Color.Black;
        }

        /// <summary>
        /// textbox失去焦点  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入备注,回车确认";
                textBox1.ForeColor = Color.LightGray;
                box1HasText = false;
            }
            else
            {
                box1HasText = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            //{
            //    //if (!UIUtils.IsNull(textBox1.Text))
            //    //{
            //        UpdateRemarkName(textBox1.Text.Trim());
            //    //}
            //}


        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//这是允许输入退格键
            {
                e.Handled = true;
                textBox4.Focus();
            }

            if (e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }


        #endregion


        #region 描述文本框事件处理
        private bool box2HasText;
        /// <summary>
        /// textbox获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (box2HasText == false)
                textBox2.Text = "";

            textBox2.ForeColor = Color.Black;
        }

        /// <summary>
        /// textbox失去焦点  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "请输入描述,回车确认";
                textBox2.ForeColor = Color.LightGray;
                box2HasText = false;
            }
            else
            {
                box2HasText = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            //{
            //    //if (!UIUtils.IsNull(textBox2.Text))
            //    //{
            //        UpdateDescribe(textBox2.Text.Trim());
            //    //}
            //}
        }

        private void textBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//这是允许输入退格键
            {
                e.Handled = true;
                textBox4.Focus();
            }
        }


        #endregion

        #region 手机号文本框事件处理

        private bool textboxHasText = false;//判断输入框是否有文本 

        internal void OnDelPhone_Click(object sender, EventArgs e)
        {
            var item = sender as UserChatSometime;
            var text = item.Sometimetext;
            int index = adapter.GetIndexByText(text);

            if (index > -1)
            {
                xListView1.RemoveItem(index);
                adapter.RemoveData(index);

                UpdateRemarkPhone();
            }
        }

        /// <summary>
        /// textbox获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox3.Text = "";

            textboxHasText = true;
            textBox3.ForeColor = Color.Black;
        }

        /// <summary>
        /// textbox失去焦点  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "请输入手机号,回车确认";
                textBox3.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
            {
                textboxHasText = true;
            }
        }


        private void linkLabel1_Click(object sender, EventArgs e)
        {
            xListView1.Location = new Point(7, 260);
            textBox3.Visible = true;
            textBox1_Leave(this, null);
        }

        private void textBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == 22)
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string Text = (string)iData.GetData(DataFormats.Text);
                    List<string> arr = UIUtils.GetPhonesFromStr(Text);

                    StringBuilder sb = new StringBuilder();
                    if (!UIUtils.IsNull(arr))
                    {
                        foreach (var item in arr)
                        {
                            sb.Append(item);
                            sb.Append(Environment.NewLine);
                        }
                        textBox3.Text = sb.ToString();
                    }
                }
            }

            Console.WriteLine("textBox3：" + textBox3.Text);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {

                xListView1.Location = new Point(7, 225);

                if (!UIUtils.IsNull(textBox3.Text))
                {

                    string[] arr = textBox3.Text.ToString().Trim().Split('\r', '\n');
                    for (int i = arr.Length - 1; i > -1; i--)
                    {

                        string str = arr[i];
                        if (!UIUtils.IsNull(str))
                        {
                            adapter.InsertData(0, str);
                            xListView1.InsertItem(0);
                        }
                    }
                    UpdateRemarkPhone();
                }
                textBox3.Text = "";
                textBox3.Visible = false;
            }
        }

        #endregion

        private void FrmFriendDescribe_Load(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!UIUtils.IsNull(textBox1.Text))
            {
                UpdateRemarkName(textBox1.Text.Trim());
            }
            if (!UIUtils.IsNull(textBox2.Text))
            {
                UpdateDescribe(textBox2.Text.Trim());
            }
            xListView1.Location = new Point(7, 225);

            if (!UIUtils.IsNull(textBox3.Text) && textboxHasText)
            {

                string[] arr = textBox3.Text.ToString().Trim().Split('\r', '\n');
                for (int i = arr.Length - 1; i > -1; i--)
                {

                    string str = arr[i];
                    if (!UIUtils.IsNull(str))
                    {
                        adapter.InsertData(0, str);
                        xListView1.InsertItem(0);
                    }
                }
                UpdateRemarkPhone();
            }
            textBox3.Text = "请输入手机号,回车确认";
            textboxHasText = false;
            textBox3.ForeColor = Color.LightGray;
            textBox3.Visible = false;
            HttpUtils.Instance.PopView(this);
            this.Close();
        }
    }
}
