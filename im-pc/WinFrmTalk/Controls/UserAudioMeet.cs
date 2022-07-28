using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    public partial class UserAudioMeet : UserControl
    {
        public UserAudioMeet()
        {
            InitializeComponent();
        }

        private string _NickName;
        private string _Userid;
        private string _roomjid;
        private int _currentRole;


        public RoomMember member { get; set; }

        /// <summary>
        /// userid
        /// </summary>
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }

        /// <summary>
        /// 群roojid
        /// </summary>
        public string roomjid
        {
            get { return _roomjid; }
            set { _roomjid = value; }
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }

        public void CenterPic()
        {
            this.pics.Location = new Point(30, 28);
        }
    }
}
