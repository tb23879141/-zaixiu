using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls;
using WinFrmTalk.Model;

namespace WinFrmTalk.View.list
{
    public class MemberLstAdapter : IBaseAdapter
    {
        private List<RoomMember> mDatas;//成员集合
        private FrmMoreMember frmMoreMember;
        public override int GetItemCount()
        {
            return mDatas.Count;
        }
        public void SetMenberForm(FrmMoreMember moreMember)
        {
            this.frmMoreMember = moreMember;
        }
        public void BindDatas(List<RoomMember> data)
        {

            mDatas = data;
        }


        public override Control OnCreateControl(int index)
        {

            UseRoleMember uSEGrouops = new UseRoleMember();

            // uSEGrouops.Size = new Size(320, 60);
            uSEGrouops.BackColor = Color.White;
            string tiptext = string.Empty;
            if (mDatas[index].role.ToString() == "1")
            {
                tiptext = LanguageXmlUtils.GetValue("leader", "群主");
            }
            else if (mDatas[index].role.ToString() == "2")
            {
                tiptext = LanguageXmlUtils.GetValue("administrator", "管理员");
            }
            else if (mDatas[index].role.ToString() == "4")
            {
                tiptext = LanguageXmlUtils.GetValue("administrator", "隐身人");
            }
            else
            {
                tiptext = LanguageXmlUtils.GetValue("ordinary", "普通成员");
            }
            //ImageLoader.Instance.DisplayAvatar(frienddata.userId, this.pic_head);//设置头像
            if (mDatas[index].role == 1)
            {
                frmMoreMember.RoleHoste.UserId = mDatas[index].userId;
                if (frmMoreMember.RoleHoste.ExistsFriend())
                {
                    frmMoreMember.RoleHoste = frmMoreMember.RoleHoste.GetByUserId();
                }
                else
                {
                    frmMoreMember.RoleHoste.NickName = mDatas[index].nickName;
                }
            }
            uSEGrouops.roomjid = frmMoreMember.mfriend.UserId;
            Friend f = new Friend
            {
                UserId = mDatas[index].userId
            };
            string nickname = mDatas[index].nickName;
            string name = mDatas[index].GetSetname();
            if (UIUtils.IsNull(name))
            {
                f.NickName = nickname;
            }
            else
            {
                f.NickName = name;
            }
            uSEGrouops.friendData = f;

            //不允许私聊
            //if (frmMoreMember.mfriend.AllowSendCard == 0 && frmMoreMember. Role != 1)
            //{
            uSEGrouops.pic_head.Click -= uSEGrouops.pic_head_Click;
            uSEGrouops.pic_head.Click += frmMoreMember.Pic_head_Click;
            //}
            if (frmMoreMember.issum)
            {
                //if (mDatas[index].userId == Applicate.MyAccount.userId)
                //{
                //    return null;
                //}
                uSEGrouops.Click += frmMoreMember.USEGrouops_Click;
            }
            else
            {

            }

            uSEGrouops.CurrentRole = tiptext;

            ImageLoader2.Instance.DisplayAvatar(f.UserId, (bitmap) =>
            {
                uSEGrouops.pic_head.Image = bitmap;
            }, true, name);

            uSEGrouops.pic_head.ChangeMemberRole(mDatas[index].role);

            //ImageLoader.Instance.DisplayGroupManager(f.UserId, uSEGrouops.pic_head, mDatas[index].role);//设置头像);

            //if (frmMoreMember.Role == 4 && frmMoreMember. Role != 1)
            //{
            //    return null;//此时的uSEGrouops应该需要返回到下一个
            //}

            return uSEGrouops;
        }

        public override int OnMeasureHeight(int index)
        {
            return 50;
        }

        public override void RemoveData(int index)
        {
            mDatas.RemoveAt(index);
        }
        public int GetIndexByFriendId(string userId)
        {

            for (int i = 0; i < GetItemCount(); i++)
            {
                if (GetDatas(i).userId.Equals(userId))
                {
                    return i;
                }
            }

            return -1;
        }
        public RoomMember GetDatas(int index)
        {

            return mDatas[index];
        }

    }
}
