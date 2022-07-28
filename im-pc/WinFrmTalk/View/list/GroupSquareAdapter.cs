using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class GroupSquareAdapter : IBaseAdapter
    {

        private List<Friend> datas;

        public FrmMain MainForm { get; set; }

        public GroupSquareLayout GroupSquare { get; set; }

        public void BindFriendData(List<Friend> data)
        {
            datas = data;
        }

        public override int GetItemCount()
        {
            if (UIUtils.IsNull(datas))
            {
                return 0;
            }

            return datas.Count;
        }


        public override Control OnCreateControl(int index)
        {
            Friend friend = datas[index];
            int weiguan=1;
            if (friend.IsSecretGroup == 1) weiguan = 2;
             FriendItem item = new FriendItem(0);
            item.FriendData = friend;
            item.Click += GroupSquare.GroupItem_Click;
            //item.btnRegister.Click += GroupSquare.GroupItemWG_Click;
            item.DoubleClick += GroupSquare.DoubleGroupItem;
            //item.MouseDown += GroupSquare.MouseDownItem;
            //GroupSquare.BindContextMenu(item);

            return item;
        }


        public override int OnMeasureHeight(int index)
        {
            return 50;
        }


        public void InsertData(int index, Friend data)
        {
            datas.Insert(index, data);
        }

        public override void RemoveData(int index)
        {
            datas.RemoveAt(index);
        }

        public void ChangeData(int index, Friend friend)
        {
            datas[index] = friend;
        }

        public int GetIndexByFriendId(string userId)
        {

            for (int i = 0; i < GetItemCount(); i++)
            {
                if (datas[i].UserId.Equals(userId))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
