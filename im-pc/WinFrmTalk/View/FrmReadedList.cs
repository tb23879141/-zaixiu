using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;

namespace WinFrmTalk.View
{
    public partial class FrmReadedList : FrmBase
    {

        GroupReadAdapter mAdapter;

        public Friend GetFriend { get; set; }

        private static FrmReadedList frm = null;
        public static FrmReadedList CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmReadedList();
            }
            if (frm != null)
            {
                frm.Activate();
            }
            return frm;
        }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            this.Text = LanguageXmlUtils.GetValue("frmReadedList_title", this.Text);
        }

        public FrmReadedList()
        {
            InitializeComponent();
            LoadLanguageText();

            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);//加载icon图标
            //this.Text = "已读列表";       //不需要重复赋值
            mAdapter = new GroupReadAdapter();
        }


        public void DesMessage(MessageObject msg)
        {
            List<MessageObject> msgLst = new List<MessageObject>();

            msgLst = msg.GetReadPersonsList(GetFriend.RoomId, msg.messageId, 0);
            mAdapter.BindDatas(msgLst);
            xListView1.SetAdapter(mAdapter);
        }
    }
}
