using TestListView;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class UseLiveList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tvLiveTitle = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.flpLiveList = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.btnStartLive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvLiveTitle
            // 
            this.tvLiveTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvLiveTitle.Location = new System.Drawing.Point(17, 0);
            this.tvLiveTitle.Name = "tvLiveTitle";
            this.tvLiveTitle.Size = new System.Drawing.Size(92, 27);
            this.tvLiveTitle.TabIndex = 6;
            this.tvLiveTitle.Text = "直播列表";
            this.tvLiveTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(0, 54);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(777, 1);
            this.skinLine1.TabIndex = 2;
            this.skinLine1.Text = "skinLine1";
            // 
            // flpLiveList
            // 
            this.flpLiveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpLiveList.AutoScroll = true;
            this.flpLiveList.Location = new System.Drawing.Point(3, 61);
            this.flpLiveList.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.flpLiveList.Name = "flpLiveList";
            this.flpLiveList.Size = new System.Drawing.Size(771, 442);
            this.flpLiveList.TabIndex = 7;
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight.BackColor = System.Drawing.Color.Black;
            this.lblRight.Location = new System.Drawing.Point(703, 533);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(44, 28);
            this.lblRight.TabIndex = 11;
            this.lblRight.Visible = false;
            this.lblRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblRight_MouseDown);
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLeft.BackColor = System.Drawing.Color.Black;
            this.lblLeft.Location = new System.Drawing.Point(30, 533);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(44, 28);
            this.lblLeft.TabIndex = 10;
            this.lblLeft.Visible = false;
            this.lblLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblLeft_MouseClick);
            // 
            // btnStartLive
            // 
            this.btnStartLive.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartLive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnStartLive.FlatAppearance.BorderSize = 0;
            this.btnStartLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartLive.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnStartLive.ForeColor = System.Drawing.Color.White;
            this.btnStartLive.Location = new System.Drawing.Point(308, 518);
            this.btnStartLive.Name = "btnStartLive";
            this.btnStartLive.Size = new System.Drawing.Size(161, 38);
            this.btnStartLive.TabIndex = 24;
            this.btnStartLive.Text = "发起直播";
            this.btnStartLive.UseVisualStyleBackColor = false;
            this.btnStartLive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnStartLive_MouseClick);
            // 
            // UseLiveList
            // 
            this.Controls.Add(this.btnStartLive);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.flpLiveList);
            this.Controls.Add(this.tvLiveTitle);
            this.Controls.Add(this.skinLine1);
            this.Name = "UseLiveList";
            this.Size = new System.Drawing.Size(777, 571);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tvLiveTitle;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.FlowLayoutPanel flpLiveList;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button btnStartLive;
    }
}
