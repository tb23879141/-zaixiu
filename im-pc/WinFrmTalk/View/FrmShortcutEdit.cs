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
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmShortcutEdit : FrmBase
    {





        ShortcutListAdapter mAdapter;

        public FrmShortcutEdit()
        {
            InitializeComponent();
            //   frmShortcut.S、how

            //var screen = Screen.GetBounds(this);
            //SetBounds((this.Width - screen.Width) / 2, (this.Height - screen.Height) / 2, Width, Height, BoundsSpecified.Location);

            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标

            //this.MdiParent = Applicate.GetWindow<FrmMain>();
            //this.StartPosition = FormStartPosition.CenterParent;
            mAdapter = new ShortcutListAdapter();
            mAdapter.ShortcutPage = this;

        }



        public void LoadData()
        {

            CommonText commonText = new CommonText();

            var commonTextlst = commonText.GetListByCreateid();

            if (!UIUtils.IsNull(commonTextlst))
            {
                commonTextlst.Reverse();
            }

            mAdapter.BindFriendData(commonTextlst);

            xListView.SetAdapter(mAdapter);

        }

        private UserChatSometime mSelect;

        internal void Picdeleate_Click(object sender, EventArgs e)
        {
            var item = sender as UserChatSometime;

            OnDeleteLableFriend(item.CommonData.contentid);

        }

        internal void Usertext_MouseDown(object sender, MouseEventArgs e)
        {

        }


        public void OnDeleteLableFriend(string commID)
        {
            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "CustomerService/commonText/delete")
              .AddParams("access_token", Applicate.Access_Token)
              .AddParams("commonTextId", commID)//常用语文本id
              .Build().Execute((susee, datalist) =>
              {
                  if (susee)
                  {

                      int index = mAdapter.GetIndexByid(commID);
                      if (index > -1)
                      {
                          xListView.RemoveItem(index);
                          mAdapter.RemoveData(index);

                          CommonText commonTex = new CommonText() { contentid = commID };
                          var result = commonTex.DeleteByUserId();
                      }
                  }
              });
        }

        // 新增常用语
        private void btnInsert_Click(object sender, EventArgs e)
        {

            string input = textBox.Text.ToString().Trim();

            if (UIUtils.IsNull(input))
            {
                HttpUtils.Instance.ShowTip("输入为空");
                return;
            }


            ShowLodingDialog(xListView);//等待符

            HttpUtils.Instance.Get().Url(Applicate.URLDATA.data.apiUrl + "CustomerService/commonText/add")
                .AddParams("access_token", Applicate.Access_Token)
                .AddParams("companyId", "0")
                  .AddParams("createUserId", Applicate.MyAccount.userId)
                  .AddParams("content", input)
                .Build().Execute((susee, datalist) =>
                {
                    if (susee)
                    {
                        CloseLoading();

                        textBox.Text = "";//清空输入框

                        CommonText commonTex = new CommonText();
                        // UIUtils.LimitTextLength(UIUtils.DecodeString(datalist, "content"), 25, true);
                        commonTex.content = UIUtils.DecodeString(datalist, "content");

                        commonTex.contentid = UIUtils.DecodeString(datalist, "id");
                        commonTex.createtime = UIUtils.DecodeDouble(datalist, "createTime");
                        commonTex.createUserId = UIUtils.DecodeString(datalist, "createUserId");
                        commonTex.modifyUserId = UIUtils.DecodeString(datalist, "modifyUserId");
                        commonTex.InsertAuto();

                        mAdapter.InsertData(0, commonTex);
                        xListView.InsertItem(0);

                    }
                    ///将数据绑定在列表中
                    HttpUtils.Instance.ShowTip("添加成功");
                    //}
                });
        }




        private LodingUtils loding;//等待符

        private void ShowLodingDialog(Control control)
        {
            if (loding == null)
            {
                loding = new LodingUtils { };


                loding.parent = control;
                loding.Title = LanguageXmlUtils.GetValue("loading", "加载中");
                loding.start();
            }

        }

        private void CloseLoading()
        {
            if (loding != null)
            {
                loding.stop();
                loding = null;
            }
        }
    }
}
