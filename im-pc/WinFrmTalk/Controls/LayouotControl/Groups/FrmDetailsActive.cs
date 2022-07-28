using RichTextBoxLinks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Controls.CustomControls;
using WinFrmTalk.Properties;


namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class FrmDetailsActive : FrmBase
    {
        private string ActiveId;
        private bool charged;
        private bool isJoin;
        private bool mLoaded = false;

        public FrmDetailsActive()
        {
            InitializeComponent();
            AddCrlMouseWheel(panel1);
            this.btnJoin.MouseClick += BtnJoin_MouseClick;
        }

        private void BtnJoin_MouseClick(object sender, MouseEventArgs e)
        {
            //?signUpEnd=1652685901000&id=627f5959ab2c7a2190b40223&language=zh&

            //https://test-xiu.tnshow.com/community/getActivityInfo?id=627f5959ab2c7a2190b40223&pageSize=15&pageIndex=0&language=zh&access_token=9012bbdd9d7e409588ee9b59bfcb728f&salt=1652882907591&secret=rf0DEG2BTTdUgxjKReuqTg%3D%3D

            if (charged)
            {
                this.ShowTipBox("付费活动请前往手机端报名");
                return;
            }

            var curr = TimeUtils.CurrentTimeMillis();
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "community/joinActivity")
                .AddParams("signUpEnd", curr.ToString())
                .AddParams("id", ActiveId)
                .NoErrorTip()
                .Build()
                .AddErrorListener((code, msg) =>
                {
                    var frm = FindForm() as FrmBase;
                    frm.ShowTip(msg);
                })
                .Execute((sccess, data) =>
                {
                    if (sccess)
                    {
                        this.btnJoin.Enabled = false;
                        this.btnJoin.Image = Resources.ic_group_active_Join0;

                        HttpLoadMembers(ActiveId);
                    }
                    else
                    {

                    }
                });

        }

        public void HttpLoadMembers(string id)
        {
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "community/getActivityInfo")
                .AddParams("id", id)
                .NoErrorTip()
                .Build()
                .ExecuteJson<List<GroupActivity_Member>>((sccess, data) =>
                {
                    flowLayoutPanel1.Controls.Clear();
                    bool joined = false;
                    if (sccess && !UIUtils.IsNull(data))
                    {

                        foreach (var item in data)
                        {
                            var mem = CreateMemeberControl(item.userId, item.nickName);
                            flowLayoutPanel1.Controls.Add(mem);

                            if (Applicate.MyAccount.userId == item.userId)
                            {
                                joined = true;
                            }
                        }



                        tvJoinCount.Text = String.Format("{0}人已报名", data.Count);
                    }
                    else
                    {
                        tvJoinCount.Text = String.Format("0人已报名");

                        btnJoin.Location = new Point(btnJoin.Location.X, flowLayoutPanel1.Location.Y + 50);
                    }


                    if (!joined)
                    {
                        this.btnJoin.Enabled = true;
                        this.btnJoin.Image = Resources.ic_group_active_Join1;
                    }
                    else
                    {
                        this.btnJoin.Enabled = false;
                        this.btnJoin.Image = Resources.ic_group_active_Join0;
                    }
                });

        }

        public void HttpLoadData(string id)
        {
            this.ActiveId = id;
            // 请求活动
            HttpUtils.Instance.Post().Url(Applicate.URLDATA.data.apiUrl + "community/getActivityDetailInfo")
                  .AddParams("id", id)
                  .NoErrorTip()
                  .Build()
                  .ExecuteJson<MyGroupActivity>((sccess, data) =>
                  {
                      if (sccess)
                      {
                          FillData(data);
                      }
                  });
            HttpLoadMembers(id);
        }


        private Control CreateMemeberControl(string userId, string nickName)
        {
            var ivImage = new PictureBox();
            ivImage.Size = new System.Drawing.Size(48, 48);
            ivImage.Margin = new System.Windows.Forms.Padding(0, 5, 20, 10);

            // 放置群成员头像
            ImageLoader.Instance.DisplayAvatar(userId, nickName, ivImage);

            ivImage.MouseWheel += View_MouseWheel;
            toolTip1.SetToolTip(ivImage, nickName);
            return ivImage;
        }

        public void FillData(MyGroupActivity data)
        {
            this.charged = data.charge == 0;
            this.ivCharge.Image = charged ? Resources.ic_group_active_charge0 : Resources.ic_group_active_charge1;
            this.tvTitle.Text = data.title;
            this.tvCreateName.Text = data.nickname;
            this.tvPhone.Text = data.contactPhone;
            this.tvMoney.Text = string.Format("{0}元", data.money);
            this.tvRoomId.Text = UIUtils.IsNull(data.activityGroupId) ? "暂无" : data.activityGroupId;
            this.tvType.Text = data.type;
            this.tvAddress.Text = data.address;
            this.tvCreateTime.Text = TimeUtils.FromatTime(data.endTime, "yyyy-MM-dd HH:mm:ss");
            var curr = TimeUtils.CurrentTimeMillis();
            if (curr < data.endTime)
            {
                ivState.Image = Resources.ActivityJXZ;
            }
            else
            {
                ivState.Image = Resources.ActivityYJS;
            }

            this.tvNotice.Text = data.notice;
            this.tvRule.Text = data.rule;
            this.tvTime1.Text = TimeUtils.FromatTime(data.time, "yyyy-MM-dd HH:mm:ss");
            this.tvTime2.Text = TimeUtils.FromatTime(data.endTime, "yyyy-MM-dd HH:mm:ss");
            this.tvTime3.Text = TimeUtils.FromatTime(data.signUpBegin, "yyyy-MM-dd HH:mm:ss");
            this.tvTime4.Text = TimeUtils.FromatTime(data.signUpEnd, "yyyy-MM-dd HH:mm:ss");



            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Height = 0;
            if (data.contents != null)
            {
                int height = 0;
                foreach (var content in data.contents)
                {
                    if (content.type == 1)
                    {
                        var text = CreateTextControl(content.content);
                        flowLayoutPanel2.Controls.Add(text);
                        height += (text.Height + text.Margin.Bottom);
                    }
                    else if (content.type == 2)
                    {
                        var text = CreateImageControl(content);
                        flowLayoutPanel2.Controls.Add(text);
                        height += (text.Height + text.Margin.Bottom);
                    }
                }

                flowLayoutPanel2.Height = height;
            }
            else if (!UIUtils.IsNull(data.webUrl))
            {
                int height = 0;
                var text = CreateTextControl(data.webUrl, true);
                flowLayoutPanel2.Controls.Add(text);
                height += (text.Height + text.Margin.Bottom);
                flowLayoutPanel2.Height = height;
            }

            panel2.Location = new Point(0, flowLayoutPanel2.Location.Y + flowLayoutPanel2.Height + 5);
            panel1.Height = panel2.Location.Y + panel2.Height + 5;
            panel1.Location = new Point(0, 0);
            mLoaded = true;
        }

        private Control CreateTextControl(string text1, bool isLink = false)
        {
            var text = new RichTextBoxEx();
            text.BackColor = flowLayoutPanel1.BackColor;
            text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            text.DetectUrls = true;
            text.ForeColor = System.Drawing.Color.FromArgb(153, 153, 153);
            text.Font = new System.Drawing.Font("微软雅黑", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            text.Text = text1;
            text.Size = new Size(flowLayoutPanel1.Width, 9999);
            int lineNumber = text.GetLineFromCharIndex(text.TextLength) + 1;

            text.Height = Convert.ToInt32(lineNumber * 30);
            text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            text.MouseWheel += View_MouseWheel;
            text.ReadOnly = true;
            text.WordWrap = true;
            text.SetReadMode();

            //点击超链接
            text.LinkClicked += (sender, e) =>
            {
                System.Diagnostics.Process.Start(e.LinkText);
            };

            CSetLineSpace.SetLineSpace(text, 30);
            return text;
        }

        private Control CreateImageControl(MyGroupActivity_ContentsItem data)
        {
            if (EQControlManager.IsImage(data.content))
            {
                var ivImage = new PictureBox();
                ivImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ivImage.Size = new System.Drawing.Size(450, 900);
                ivImage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
                ImageLoader.Instance.Load(data.content).Into((bit, path) =>
                {
                    if (bit != null)
                    {
                        int height = Convert.ToInt32((float)bit.Height / bit.Width * ivImage.Width);
                        ivImage.Height = height;
                        ivImage.Image = bit;

                        if (mLoaded)
                        {
                            flowLayoutPanel2.Height += (height - 900);
                            panel1.Height += (height - 900);
                        }
                    }
                });
                ivImage.MouseWheel += View_MouseWheel;
                return ivImage;

            }
            else
            {
                var item = new WinFrmTalk.Controls.LayouotControl.Items.GroupFileItem();

                item.Size = new Size(450, 105);
                item.SetContentData(data);
                item.Margin = new Padding(0, 0, 0, 15);
                item.Tag = data;
                //item.MouseClick += File_MouseClick;

                item.MouseWheel += View_MouseWheel;

                item.BackColor = System.Drawing.Color.FromArgb(230, 229, 229);
                return item;
            }
        }

        #region 给子控件添加滚轮事件
        private void AddCrlMouseWheel(Control crl)
        {
            crl.MouseWheel += View_MouseWheel;

            AddCrlMouseWheelList(crl.Controls);
        }

        private void AddCrlMouseWheelList(Control.ControlCollection controls)
        {
            if (controls == null)
            {
                return;
            }

            foreach (Control item in controls)
            {

                AddCrlMouseWheel(item);
            }
        }


        /// <summary>
        /// 鼠标滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_MouseWheel(object sender, MouseEventArgs e)
        {

            if (panel1.Height <= limitPanel.Height)
            {
                return;
            }

            int totleHeight = panel1.Height - limitPanel.Height;


            int movey = e.Delta > 0 ? 40 : -40;

            if (panel1.Location.Y + movey > 0)
            {
                movey = -panel1.Location.Y;
            }
            else if (panel1.Location.Y + movey < -totleHeight)
            {
                movey = Math.Abs(panel1.Location.Y) - totleHeight;
            }


            // 移动panel
            ModifyLocation(panel1, movey, false);

            // 同步滚动条
            var pro = Math.Abs(panel1.Location.Y) / (float)totleHeight * 100;
            xScrollBar1.SetProgress((int)pro);
        }


        /// <summary>
        /// 修改控件位置
        /// </summary>
        /// <param name="control"></param>
        /// <param name="loc_y"></param>
        /// <param name="abs">是否绝对坐标</param>
        private void ModifyLocation(Control control, int loc_y, bool abs = true)
        {
            Point point = control.Location;

            if (abs)
            {
                point.Y = loc_y;
            }
            else
            {
                point.Y = point.Y + loc_y;
            }

            control.Location = point;
        }

        private int last_progress;
        private void xScrollBar1_ScrollChangeListener()
        {
            if (xScrollBar1.Value == last_progress)
            {
                return;
            }

            if (limitPanel.Height > panel1.Height)
            {
                return;
            }


            last_progress = xScrollBar1.Value;


            float max = panel1.Height - limitPanel.Height;

            int movey = Convert.ToInt32(last_progress / 100f * max * -1);

            // 移动panel
            ModifyLocation(panel1, movey, true);
        }

        #endregion
    }
}
