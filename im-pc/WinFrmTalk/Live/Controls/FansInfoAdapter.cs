using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Model;
using WinFrmTalk.View;

namespace WinFrmTalk.Live.Controls
{
    public class FansInfoAdapter : IBaseAdapter
    {
        private List<LiveMember> mDatas;//成员集合

        private UserLiveChat LiveChat;
        public override int GetItemCount()
        {
            if(mDatas==null)
            {
                return 0;
            }
            return mDatas.Count;
        }

        public override Control OnCreateControl(int i)
        {
            LiveMember data = mDatas[i];
            USEMange uSEMange = new USEMange();
            uSEMange.Size = new System.Drawing.Size(392, 68);
            uSEMange.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            uSEMange.AutoSize = true;
            uSEMange.MouseEnter += LiveChat.USEMange_MouseEnter;
            uSEMange.MouseLeave += LiveChat.Use_MouseLeave;
            Friend f = new Friend
            {
                //  nickName = memberLst[i].nickName,
                UserId = mDatas[i].userId.ToString()
            };

            bool a = f.ExistsFriend();//判断是否为好友
            if (!a)
            {
                if (f.UserId == Applicate.MyAccount.userId)
                {
                    f.NickName = Applicate.MyAccount.nickname;
                }
                else
                {
                    f.NickName = mDatas[i].nickName;
                }

                uSEMange.friendData = f;
            }
            else
            {
                uSEMange.friendData = f.GetByUserId();
            }
            if (mDatas[i].type == 1)
            {
                uSEMange.lblName.Text = "主播";
            }
            else if (mDatas[i].type == 2)
            {
                uSEMange.lblName.Text = "管理员";
            }
            else
            {
                uSEMange.lblName.Text = "观众";
            }

           
            ImageLoader.Instance.DisplayAvatar(data.userId.ToString(), uSEMange.pic_head);
            //  uSEMange.IsSelected = false;
             

            //  uSEMange.Click += mageng.FriendItem1_Click;
            uSEMange.Tag = mDatas[i];
            uSEMange.MouseDown += LiveChat.USEGrouops_MouseDown;

            return uSEMange;
        }
        public void SetMaengForm(UserLiveChat userLive)
        {
            this.LiveChat = userLive;
        }
        public override int OnMeasureHeight(int index)
        {
            return 68;
        }

        public override void RemoveData(int index)
        {
            mDatas.RemoveAt(index);
        }
        public void BindDatas(List<LiveMember> data)
        {

            mDatas = data;
        }
        public LiveMember GetDatas(int index)
        {

            return mDatas[index];
        }
        public int GetIndexByFansId(string userId)
        {

            for (int i = 0; i < GetItemCount(); i++)
            {
                
                if (GetDatas(i).userId.ToString().Equals(userId))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
