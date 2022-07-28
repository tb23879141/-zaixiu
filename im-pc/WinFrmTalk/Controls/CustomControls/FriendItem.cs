using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    // 好友列表项&群组列表项
    public partial class FriendItem : UserControl
    {

        #region Member
        private bool isSelected;
        private bool query;

        internal void TextMaxSize(int v)
        {
            query = true;
            lab_name.MaximumSize = new Size(155, 20);
            lab_name.AutoEllipsis = true;
        }

        private Friend frienddata = new Friend();

        private Image mImage;// 头像图片
        private int redCount;

        // 是否正在绘制
        private bool IsDrawing = false;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                if (IsSelected)
                {
                    this.BackColor = ColorTranslator.FromHtml("#CAC8C6");
                }
                else
                {
                    this.BackColor = Color.Transparent;
                }
                if (frienddata != null && frienddata.UserId == "10001")
                {
                    LoadHeadImage();
                }
            }
        }

        /// <summary>
        /// 保存整个好友实体类
        /// </summary>
        public Friend FriendData
        {
            get { return frienddata; }
            set
            {
                frienddata = value;
                redCount = frienddata.MsgNum;

                LoadHeadImage();

                if (frienddata.isLook != 0)
                {
                    btnLook.Visible = true;
                    if (frienddata.isLook == -1)
                    {
                        btnLook.Image = Resources.ic_group_look0;
                    }
                    else
                    {
                        btnLook.Image = Resources.ic_group_look1;
                    }
                }

                if (frienddata.GroupType == 2) // || type > 10
                {
                    ivLogo.Visible = true;
                    lab_name.Location = new Point(ivLogo.Location.X + ivLogo.Width + 2, lab_name.Location.Y);
                }
                else if (frienddata.GroupType == 4)
                {

                    lab_name.Location = new Point(lab_name.Location.X, 11);
                    // 临时群
                    var temp = new Label();
                    temp.AutoSize = true;
                    temp.ForeColor = Color.FromArgb(255, 49, 49);
                    temp.BackColor = System.Drawing.Color.Transparent;
                    temp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    temp.Location = new System.Drawing.Point(lab_name.Location.X, 33);
                    temp.Name = "lab_temp";
                    temp.Text = string.Format("(此群{0})后自动解散", TimeUtils.FromatTime(frienddata.deleteTime, "yyyy-MM-dd"));
                    temp.UseMnemonic = false;
                    this.Controls.Add(temp);
                }

                ChangeFriendName();
            }
        }

        #endregion

        #region 构造方法
        public FriendItem(int type = 0)
        {
            InitializeComponent();


            #region 子控件事件传递
            //Click Event
            lab_name.Click += Parent_Click;
            pic_head.Click += Parent_Click;
            btnLook.Click += Parent_Click;
            ivLogo.Click += Parent_Click;

            //Double Click Event
            lab_name.DoubleClick += Parent_DoubleClick;
            pic_head.DoubleClick += Parent_DoubleClick;

            //MouseClick Event
            lab_name.MouseClick += Parent_MouseClick;
            pic_head.MouseClick += Parent_MouseClick;
            btnLook.MouseClick += Parent_MouseClick;
            ivLogo.MouseClick += Parent_MouseClick;

            //MouseLeave Event
            lab_name.MouseLeave += Parent_MouseLeave;
            pic_head.MouseLeave += Parent_MouseLeave;

            //MouseEnter Event
            lab_name.MouseEnter += Parent_MouseEnter;
            pic_head.MouseEnter += Parent_MouseEnter;
            ivLogo.MouseEnter += Parent_MouseEnter;
            btnLook.MouseEnter += Parent_MouseEnter;

            //MouseEnter Event
            lab_name.MouseDown += Parent_MouseDown;
            pic_head.MouseDown += Parent_MouseDown;
            ivLogo.MouseDown += Parent_MouseDown;
            btnLook.MouseDown += Parent_MouseDown;
            #endregion

            this.pic_head.BackgroundImageLayout = ImageLayout.Zoom;


        }
        #endregion

        public int CurrtIndex { get; set; }


        //刷新朋友关系
        public void RefreshFriend()
        {
            if (Applicate.URLDATA.data.friendStatus == null)
                return;
            if (!UIUtils.IsNull(FriendData.UserId) && Applicate.URLDATA.data.friendStatus.ContainsKey(FriendData.UserId))
            {
                if (Applicate.URLDATA.data.friendStatus[FriendData.UserId] == 1)
                {
                    this.pic_Nonfriends.Visible = true;
                }
                else
                {
                    this.pic_Nonfriends.Visible = false;
                }
            }
        }

        #region Parent Event
        private void Parent_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void Parent_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }

        private void Parent_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        private void Parent_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);

        }

        private void Parent_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Parent_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void FriendItem_MouseEnter(object sender, EventArgs e)
        {
            if (!IsSelected)
            {
                this.BackColor = ColorTranslator.FromHtml("#D8D8D9");//悬浮颜色
            }
        }

        private void FriendItem_MouseLeave(object sender, EventArgs e)
        {

            //非选中状态
            if (!IsSelected)
            {
                //离开时变回默认的颜色
                this.BackColor = Color.Transparent;
            }
        }

        #endregion


        #region 加载头像方法
        public void LoadHeadImage()
        {
            if (FriendData.IsGroup == 1)
            {
                ImageLoader.Instance.DisplayGroupAvatar(FriendData.UserId, FriendData.RoomId, pic_head, (bitmap) =>
                {
                    mImage = BitmapUtils.ChangeSize(bitmap, pic_head.Width, pic_head.Height);
                    pic_head.BackgroundImage = mImage;
                    if (frienddata != null && frienddata.UserType == FriendType.NEWFRIEND_TYPE)
                    {
                        DrawUnRead(redCount);
                    }
                });
            }
            else
            {
                ImageLoader.Instance.DisplayAvatar(FriendData, (bitmap) =>
                {
                    mImage = BitmapUtils.ChangeSize(bitmap, pic_head.Width, pic_head.Height);
                    pic_head.BackgroundImage = mImage;
                    if (frienddata != null && frienddata.UserType == FriendType.NEWFRIEND_TYPE)
                    {
                        DrawUnRead(redCount);
                    }
                });
            }
        }

        #endregion

        #region 改变朋友名称

        public void ChangeFriendName()
        {
            int look = btnLook.Visible ? btnLook.Width + 8 : 0;
            int maxWidth = this.Width - lab_name.Location.X - look;
            if (!query)
            {
                lab_name.MaximumSize = new Size(maxWidth, 20);
            }

            lab_name.Text = frienddata.GetRemarkName();
            toolTip1.SetToolTip(lab_name, lab_name.Text);
        }
        #endregion

        #region 改变头像大小和位置适配红点
        /// <summary>
        /// 头像需要跟随红点改变位置和大小
        /// </summary>
        private void ModifyPicLocation()
        {
            if (redCount > 0)
            {
                pic_head.Size = new Size(45, 45);
                pic_head.Location = new Point(6, 0);
            }
            else
            {
                pic_head.Size = new Size(35, 35);
                pic_head.Location = new Point(6, 8);
            }
        }

        #endregion

        #region 画未读角标
        public void DrawUnRead(int unreadcount)
        {
            redCount = unreadcount;

            if (BitmapUtils.IsNull(mImage))
            {
                return;
            }

            if (redCount <= 0)
            {
                ModifyPicLocation();
                if (BitmapUtils.IsNull(mImage))
                {
                    LoadHeadImage();
                }
                else
                {
                    pic_head.isDrawRound = false;
                    pic_head.BackgroundImage = mImage;
                }
            }
            else
            {
                DrawUnReadCount();
            }

        }

        #endregion

        private void DrawUnReadCount()
        {
            ChangeFriendName();

            ModifyPicLocation();

            //显示红点和数字
            if (redCount > 0 && !IsDrawing)
            {
                IsDrawing = true;
                int p_width = 20, p_heigh = 20;

                Bitmap bmpRedP = EQControlManager.DrawRoundPic(p_width, p_heigh, Color.Red);
                using (Graphics g = Graphics.FromImage(bmpRedP))
                {
                    //实线画刷
                    SolidBrush mysbrush1 = new SolidBrush(Color.DarkOrchid);
                    mysbrush1.Color = Color.FromArgb(250, Color.White);
                    //字体居中
                    PointF pointF;
                    //长度为0时只显示红点不显示数字

                    string str = redCount.ToString();

                    if (str.Length == 1)
                    {
                        pointF = new PointF(5, 3);
                    }
                    else if (str.Length == 2)
                    {
                        pointF = new PointF(2, 3);
                    }
                    else
                    {
                        pointF = new PointF(0, 3);
                    }

                    //写入未读数量
                    g.DrawString(str, new Font(Applicate.SetFont, 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134))), mysbrush1, pointF);
                    mysbrush1.Dispose();
                    g.Dispose();
                }

                Bitmap headImage = new Bitmap(mImage);
                //绘制红点
                Bitmap bmpBack = BitmapUtils.CombineRedPointToImg(bmpRedP, headImage);
                pic_head.isDrawRound = false;
                pic_head.BackgroundImage = bmpBack;
                IsDrawing = false;
            }
        }

        private void FriendItem_Load(object sender, EventArgs e)
        {
            var toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pic_Nonfriends, @"你已被对方删除");

            RefreshFriend();
        }
    }
}
