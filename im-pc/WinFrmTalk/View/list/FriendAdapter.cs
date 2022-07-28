using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class FriendAdapter : IBaseAdapter
    {
        private List<Friend> mDatas;
        public FrmMain MainForm { get; set; }

        public FriendListLayout FriendList { get; set; }

        public Dictionary<int, Friend> isHeadFriend = new Dictionary<int, Friend>();

        private bool isHeadItem(Friend friend)
        {
            if (friend.fristAscII == 0)
            {
                friend.fristAscII = friend.GetFristASCIICode();
            }

            if (HeadContainsKey(friend.fristAscII))
            {
                var head = GetHeadKey(friend.fristAscII);
                return friend.UserId.Equals(head.UserId);
            };

            return false;
        }

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

            if (!isHeadItem(friend))
            {
                var item = ModelToControl(friend);
                return item;
            }
            else
            {

                Panel panel = new Panel();
                panel.Size = new System.Drawing.Size(264, 94);

                var item = ModelToControl(friend);
                var colums = new FriendColumnItem();
                colums.FristText = friend.GetColumnTitle();
                panel.Controls.Add(colums);
                panel.Controls.Add(item);
                item.Location = new System.Drawing.Point(0, 34);
                if (friend.UserId == Friend.ID_NEW_FRIEND)
                {
                    colums.HideFristLine();
                }
                return panel;
            }
        }

        public override int OnMeasureHeight(int index)
        {

            Friend friend = GetDatas(index);

            if (friend.fristAscII == 0)
            {
                friend.fristAscII = friend.GetFristASCIICode();
            }

            // 有没有出现过
            if (HeadContainsKey(friend.fristAscII))
            {
                var head = GetHeadKey(friend.fristAscII);

                if (friend.UserId.Equals(head.UserId))
                {
                    return 94;
                }
                else
                {
                    return 60;
                }
            }
            else
            {
                AddHeadKey(friend.fristAscII, friend);
                return 94;
            }


            //if (isHeadItem(friend))
            //{
            //    return 84;
            //}
            //else
            //{
            //    return 50;
            //}

            //return 50;

            //Friend  head = isHeadFriend[friend.fristChar];

            //if (head.UserId.Equals(friend.UserId))
            //{
            //    return 84;
            //}
            //else
            //{
            //    return 50;
            //}

            //Friend  head = isHeadFriend[friend.fristChar];

            //if (head.UserId.Equals(friend.UserId))
            //{
            //    return 84;
            //}
            //else
            //{
            //    return 50;
            //}
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
            var friend = GetDatas(index);
            if (HeadContainsKey(friend.fristAscII))
            {
                var head = GetHeadKey(friend.fristAscII);
                if (friend.UserId.Equals(head.UserId))
                {
                    RemoveContainsKey(friend.fristAscII);
                }
            }

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
                Size = new System.Drawing.Size(264, 60)
            };

            item.Name = "FriendItem";
            item.MouseDown += FriendList.MouseDownItem;

            // 只要不是黑名单和新的朋友 就可以双击发消息
            if (item.FriendData.UserType != FriendType.NEWFRIEND_TYPE)
            {
                item.DoubleClick += DoubleFriendItem;
            }


            item = BindContextMenu(item);

            return item;
        }
        #endregion

        #region 设置右键菜单
        public FriendItem BindContextMenu(FriendItem item)
        {
            if (item.FriendData.UserType == FriendType.NEWFRIEND_TYPE)
            {
                return item;
            }

            var cm = new ContextMenu();
            var sendmsgitem = new MenuItem("发消息", (sen, eve) =>
            {
                MainForm.SendMessageToFriend(item.FriendData);
            });
            //var detailitem = new MenuItem("查看详情", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.SHOW_DETAIL); });     //禅道#10652
            var sendcard = new MenuItem("发送名片", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.SEND_FRIEND_CARD); });
            var blockitem = new MenuItem("加入黑名单", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.BLOCK_FRIENDITEM); });
            var deleteitem = new MenuItem("删除好友", (sen, eve) => { Messenger.Default.Send(true, FriendListLayout.DELETE_FRIENDITEM); });





            cm.MenuItems.Add(sendmsgitem);

            // 可以删除普通用户
            if (item.FriendData.UserType != FriendType.DEVICE_TYPE)
            {
                //cm.MenuItems.Add(detailitem);     //禅道#10652


                // 修改公众号可以被拉黑和删除的问题
                if (item.FriendData.UserType <= 1)
                {
                    cm.MenuItems.Add(sendcard);
                    cm.MenuItems.Add(blockitem);
                    cm.MenuItems.Add(deleteitem);
                }

            }

            item.ContextMenu = cm;//设置右键菜单
            return item;
        }
        #endregion


        #region 双击朋友进入聊天
        private void DoubleFriendItem(object sender, EventArgs e)
        {
            FriendItem item = sender as FriendItem;
            MainForm.SendMessageToFriend(item.FriendData);
        }


        internal void MoveData(int fromIndex, int toIndex)
        {
            Friend temp = mDatas[fromIndex];

            // 从 1 --->   3
            if (fromIndex < toIndex)
            {
                int next = fromIndex + 1;
                while (next <= toIndex)
                {
                    // 移动数据
                    mDatas[next - 1] = mDatas[next];
                    next++;
                }
            }
            else
            {
                // 从 5---->  2
                int next = fromIndex - 1;
                while (next >= toIndex)
                {
                    // 移动数据
                    mDatas[next + 1] = mDatas[next];
                    next--;
                }
            }

            mDatas[toIndex] = temp;
        }
        #endregion



        public bool HeadContainsKey(int fristascII)
        {
            if (fristascII > 90)
            {
                return isHeadFriend.ContainsKey(91);
            }
            else
            {
                return isHeadFriend.ContainsKey(fristascII);
            }
        }

        public Friend GetHeadKey(int fristascII)
        {
            if (fristascII > 90)
            {
                return isHeadFriend[91];
            }
            else
            {
                return isHeadFriend[fristascII];
            }
        }

        public void AddHeadKey(int fristascII, Friend friend)
        {
            if (fristascII > 90)
            {
                isHeadFriend.Add(91, friend);
            }
            else
            {
                isHeadFriend.Add(fristascII, friend);
            }
        }

        public bool RemoveContainsKey(int fristascII)
        {
            if (fristascII > 90)
            {
                return isHeadFriend.Remove(91);
            }
            else
            {
                return isHeadFriend.Remove(fristascII);
            }
        }
    }
}
