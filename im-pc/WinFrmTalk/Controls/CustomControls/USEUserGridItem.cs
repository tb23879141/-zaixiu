using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class USEUserGridItem : UserControl
    {

        public USEUserGridItem()
        {
            InitializeComponent();
        }

        private string _nickName;
        private string _userid;
        private string _roomjid;
        // 用户身份
        private int _memberRole;
        // 我的身份
        private int _myRole;

        /// <summary>
        /// userid
        /// </summary>
        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        /// <summary>
        /// 群roojid
        /// </summary>
        public string roomjid
        {
            get { return _roomjid; }
            set { _roomjid = value; }
        }

        public int CurrentRole
        {
            get { return _myRole; }
            set { _myRole = value; }
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
                tv_name.Text = _nickName;
            }
        }


        /// <summary>
        /// 鼠标放在图像上显示卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicHead_Click(object sender, EventArgs e)
        {
            FrmFriendsBasic frmFriendsBasic = new FrmFriendsBasic();
            frmFriendsBasic.ShowUserInfoByRoom(_userid, _roomjid, _myRole);
            frmFriendsBasic.Show();
        }

        // 修改鼠标指针
        private void PicHead_MouseHover(object sender, EventArgs e)
        {

        }

        internal void ChangeRole(int role)
        {
            this._memberRole = role;
            PicHead.ChangeMemberRole(role);
        }
    }
}

