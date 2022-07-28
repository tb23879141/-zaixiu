using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class BatchSendFriendAdapter : IBaseAdapter
    {
        private List<Friend> mDatas;


        public override int GetItemCount()
        {
            if (mDatas != null)
            {
                return mDatas.Count;
            }

            return 0;
        }

        public override Control OnCreateControl(int index)
        {
            Friend friend = GetDatas(index);
            FriendItem item = ModelToControl(friend);
            return item;
        }

        public override int OnMeasureHeight(int index)
        {
            return 50;
        }

        public Friend GetDatas(int index)
        {

            return mDatas[index];
        }


        public void BindDatas(List<Friend> data)
        {

            mDatas = data;
        }

        public int GetIndexByFriendId(string userId)
        {

            for (int i = 0; i < GetItemCount(); i++)
            {
                if (GetDatas(i).UserId.Equals(userId))
                {
                    return i;
                }
            }

            return -1;
        }

        public void InsertData(int index, Friend data)
        {
            mDatas.Insert(index, data);
        }

        public override void RemoveData(int index)
        {
            mDatas.RemoveAt(index);
        }

        #region Friend实体类转控件
        private FriendItem ModelToControl(Friend friend)
        {
            var item = new FriendItem
            {
                //如果有备注名则优先显示
                FriendData = friend,
                //Dock = DockStyle.Fill
            };

            item.Size = new System.Drawing.Size(260, 50);
            item = BindContextMenu(item);

            return item;
        }
        #endregion

        #region 设置右键菜单
        public FriendItem BindContextMenu(FriendItem item)
        {
            //if (item.FriendData.UserType == FriendType.NEWFRIEND_TYPE)
            //{
            //    return item;
            //}

            //var cm = new ContextMenu();
            //var sendmsgitem = new MenuItem("发消息", (sen, eve) =>
            //{
            //    MainForm.SendMessageToFriend(item.FriendData);
            //});
            //var detailitem = new MenuItem("查看详情", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.SHOW_DETAIL); });
            //var sendcard = new MenuItem("发送名片", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.SEND_FRIEND_CARD); });
            //var blockitem = new MenuItem("加入黑名单", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.BLOCK_FRIENDITEM); });
            //var deleteitem = new MenuItem("删除好友", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.DELETE_FRIENDITEM); });

            //cm.MenuItems.Add(sendmsgitem);

            //// 可以删除普通用户
            //if (item.FriendData.UserType != FriendType.DEVICE_TYPE)
            //{
            //    cm.MenuItems.Add(detailitem);
            //    cm.MenuItems.Add(sendcard);
            //    cm.MenuItems.Add(blockitem);
            //    cm.MenuItems.Add(deleteitem);
            //}

            //item.ContextMenu = cm;//设置右键菜单
            return item;
        }
        #endregion



    }
}
