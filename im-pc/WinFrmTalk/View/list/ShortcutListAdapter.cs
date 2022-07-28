using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    class ShortcutListAdapter : IBaseAdapter
    {
        private List<CommonText> datas;

        public FrmShortcutEdit ShortcutPage { get; set; }

        public void BindFriendData(List<CommonText> data)
        {
            datas = data;
        }



        public override int GetItemCount()
        {
            if (datas != null)
            {
                return datas.Count;
            }

            return 0;
        }


        public CommonText GetDatas(int index)
        {
            return datas[index];
        }

        public override Control OnCreateControl(int index)
        {
            CommonText common = GetDatas(index);


            UserChatSometime usertext = new UserChatSometime();
            // usertext.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            usertext.Width = 520;
            usertext.CommonData = common;
            usertext.MouseDown += ShortcutPage.Usertext_MouseDown;
            usertext.OnitemDel += ShortcutPage.Picdeleate_Click;
            
            return usertext;
        }

        public override int OnMeasureHeight(int index)
        {
            return 48;
        }

        public override void RemoveData(int index)
        {
            datas.RemoveAt(index);
        }

        public void InsertData(int index, CommonText data)
        {
            if (UIUtils.IsNull(datas))
            {
                datas = new List<CommonText>();
                datas.Add(data);

                return;
            }

            datas.Insert(index, data);
        }



        public int GetIndexByid(string userId)
        {
            for (int i = 0; i < GetItemCount(); i++)
            {
                if (GetDatas(i).contentid.Equals(userId))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
