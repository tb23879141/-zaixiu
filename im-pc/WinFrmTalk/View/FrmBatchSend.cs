using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.View.list;
using System.Drawing;

namespace WinFrmTalk.View
{
    // 群发消息
    public partial class FrmBatchSend : FrmBase
    {


        // 好友适配器
        private BatchSendFriendAdapter mFriendAdapter;

        public FrmBatchSend()
        {
            InitializeComponent();

            //加载icon图标
            this.Icon = Icon.FromHandle(Properties.Resources.Icon.Handle);
            this.FormClosed += FrmBatchSend_FormClosed;
            this.Load += FrmBatchSend_Load;
            this.chatSendView.OnSendMessage += ChatSendView_OnSendMessage;
            mFriendAdapter = new BatchSendFriendAdapter();
        }


        public void SetFriendList(Dictionary<string, Friend> friend)
        {
            var datas = new List<Friend>();

            foreach (var item in friend)
            {
                datas.Add(item.Value);
            }

            tvBatchTitle.Text = string.Format("你将给此列表中 {0} 位好友群发消息", datas.Count);
            mFriendAdapter.BindDatas(datas);
            friendListView.SetAdapter(mFriendAdapter);
        }

        private void FrmBatchSend_Load(object sender, EventArgs e)
        {

        }

        private void FrmBatchSend_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ChatSendView_OnSendMessage(MessageObject message)
        {

        }
    }
}
