using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls.LayouotControl.GroupTree
{
    public partial class GroupTreeNodeItem : UserControl
    {
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }

        public int LookWidth
        {
            get
            {
                if (btnLook.Visible)
                {
                    return btnLook.Width + 5;
                }
                else
                {
                    return 10;
                }
            }
        }

        public GroupTreeNodeItem()
        {
            InitializeComponent();
        }


        public GroupTreeData itemData;
        public void Expend(bool isexpend)
        {
            if (isexpend)
            {
                pic_ex.Image = WinFrmTalk.Properties.Resources.ic_group_tree_ex;
            }
            else
            {
                pic_ex.Image = WinFrmTalk.Properties.Resources.ic_group_tree_ec;
            }
        }



        public void SetItemData(GroupTreeData itemData)
        {
            this.itemData = itemData;

            tvName.Text = itemData.name;

            pic_ex.Visible = itemData.type != 14;

            // 外部群  且 可以被查看时， 才能围观
            if (itemData.inside == 1 && itemData.isLook != 0)
            {
                btnLook.Visible = true;
                if (itemData.isLook == -1)
                {
                    btnLook.Image = Resources.ic_group_look0;
                }
                else
                {
                    btnLook.Image = Resources.ic_group_look1;
                }
            }
            else
            {
                if (itemData.type == 99)
                {
                    // 客服
                    btnLook.Visible = true;
                    btnLook.Image = Resources.ic_group_tree_chat;


                    pic_ex.Visible = false;
                }
                else if (itemData.type == 98)
                {
                    // 销售
                    btnLook.Visible = true;
                    btnLook.Image = Resources.ic_group_tree_chat;

                    pic_ex.Visible = false;
                }
            }




            SetLevelIcon(itemData);


            Expend(itemData.IsExpand);

            ModifyLocation(itemData.NodeLevel);
        }

        private void SetLevelIcon(GroupTreeData itemData)
        {
            switch (itemData.type)
            {
                case 2:
                    ivCurrtLevel.Image = Resources.groupGQ;
                    break;
                case 11:
                    ivCurrtLevel.Image = Resources.ic_group_org4;
                    break;
                case 12:
                    ivCurrtLevel.Image = Resources.ic_group_org3;
                    break;
                case 13:
                    ivCurrtLevel.Image = Resources.ic_group_org2;
                    break;
                case 14:
                    ivCurrtLevel.Image = Resources.ic_group_org1;
                    break;
                case 98:
                    ivCurrtLevel.Image = Resources.ic_group_tree_mem2;
                    break;
                case 99:
                    ivCurrtLevel.Image = Resources.ic_group_tree_mem1;
                    break;
                default:

                    break;
            }
        }

        internal void ModifyLocation(int nodeLevel)
        {
            var posx = nodeLevel * 15;
            ModifyLocation(posx, pic_ex);
            ModifyLocation(posx, ivCurrtLevel);
            ModifyLocation(posx, tvName);

            tvName.Width = this.Width - tvName.Location.X - LookWidth;
        }

        public void ModifyLocation(int locaX, Control control)
        {
            var loca = control.Location;
            loca.X += locaX;
            control.Location = loca;
        }


        public void FriendItem_MouseEnter(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BackColor = ColorTranslator.FromHtml("#D8D8D9");//悬浮颜色
                tvName.BackColor = ColorTranslator.FromHtml("#D8D8D9");//悬浮颜色
            }
        }
        public void Parent_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);

        }
        private void Parent_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
        public void Parent_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        public void FriendItem_MouseLeave(object sender, EventArgs e)
        {

            //非选中状态
            if (!IsSelected)
            {
                //离开时变回默认的颜色
                this.BackColor = Color.Transparent;
                tvName.BackColor = Color.White;
            }
        }



        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Look_MouseClick(object sender, MouseEventArgs e)
        {
            this.FindForm().Close();


            var data = ItemDataToFriend();

            if (itemData.type == 99 || itemData.type == 98)
            {
                data.IsGroup = 0;
                Messenger.Default.Send(data, FrmMain.START_NEW_CHAT);
            }
            else
            {
                data.IsGroup = 1;
                Messenger.Default.Send<Friend>(data, MessageActions.WATCH_GROUP);
            }
        }


        public Friend ItemDataToFriend()
        {
            Friend friend = new Friend();
            friend.UserId = itemData.UserId;
            friend.GroupType = itemData.type;
            friend.NickName = itemData.name;
            friend.RoomId = itemData.RoomId;
            return friend;
        }
    }
}