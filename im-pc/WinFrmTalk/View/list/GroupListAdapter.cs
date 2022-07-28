using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class GroupListAdapter : IBaseAdapter
    {
        private List<Friend> datas;

        public int ListWidth { get; set; }
        public event MouseEventHandler MouseDown;

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
            FriendItem item = new FriendItem(friend.GroupType);
            item.Size = new System.Drawing.Size(ListWidth - 1, 60);
            item.FriendData = friend;
            item.MouseDown += MouseDown;
            return item;
        }


        public override int OnMeasureHeight(int index)
        {
            return 60;
        }


        public void InsertData(int index, Friend data)
        {
            if (datas == null)
            {
                datas = new List<Friend>();
            }

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

        public List<Friend> GetListBySearch(string text)
        {
            List<Friend> list = new List<Friend>();
            for (int i = 0; i < GetItemCount(); i++)
            {
                if (datas[i].NickName.Contains(text))
                {
                    list.Add(datas[i]);
                }
            }
            return list;
        }

        internal int AddRange(List<Friend> mMainDatas)
        {
            if (datas == null)
            {
                datas = new List<Friend>();
            }
            int index = datas.Count;

            datas.AddRange(mMainDatas);
            return index;
        }
    }
}
