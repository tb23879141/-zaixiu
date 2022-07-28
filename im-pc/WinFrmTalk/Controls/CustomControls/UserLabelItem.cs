using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk
{
    public partial class UserLabelItem : UserControl
    {
        private bool isSelected;

        private FriendLabel _data;
        public FriendLabel FriendLabel
        {
            get { return _data; }
            set
            {
                _data = value;

                lblName.Text = FriendLabel.groupName + "(" + FriendLabel.GetFriendCount() + ")";
                string str = GetFriendNames();
                lblFriend.Text = str;
            }
        }

        public UserLabelItem()
        {
            InitializeComponent();
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                if (IsSelected)
                {
                    this.BagColor = ColorTranslator.FromHtml("#DCDCDC");
                }
                else
                {
                    this.BagColor = Color.Transparent;
                }
            }
        }


        public string NameText
        {
            get
            {
                return lblName.Text;
            }
        }

        internal string GetFriendNames()
        {
            List<Friend> friends = FriendLabel.GetFriendList();

            if (!UIUtils.IsNull(friends))
            {
                string str = string.Empty;

                foreach (var item in friends)
                {
                    str += item.GetRemarkName() + ",";

                    if (str.Length >= 15)
                    {
                        if (str.Last() == ',')
                        {
                            str = str.Substring(0, str.Length - 1);
                            return str;
                        }
                        else
                        {
                            return str;
                        }

                    }
                }
                if (str.Last() == ',')
                {
                    str = str.Substring(0, str.Length - 1);
                    return str;
                }
                else
                {
                    return str;
                }

            }

            return "";
        }

        public Color BagColor
        {
            get { return this.BackColor; }
            set
            {
                this.BackColor = value;
                lblName.BackColor = value;
                lblFriend.BackColor = value;
            }
        }


        /// <summary>
        /// 鼠标悬浮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLabelItem_MouseEnter(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BagColor = ColorTranslator.FromHtml("#DCDCDC");
            }
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLabelItem_MouseLeave(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BagColor = Color.Transparent;
            }
        }

        private void lblName_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
    }
}
