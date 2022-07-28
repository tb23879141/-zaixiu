using TestListView;

namespace WinFrmTalk.Controls
{
    partial class UserMyColleague
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
            this.DeleteDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDepartmentName = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMember = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSubdivisions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDepartment = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmCreateDepart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDepartChat = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCompany = new CCWin.SkinControl.SkinContextMenuStrip();
            this.tsmCreateCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.tsmDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReplaceDepar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStaff = new CCWin.SkinControl.SkinContextMenuStrip();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreate = new LollipopButton();
            this.tvwColleague = new WinFrmTalk.NewTreeView();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.pnlMyColleague = new TestListView.XListView();
            this.cmsDepartment.SuspendLayout();
            this.cmsCompany.SuspendLayout();
            this.cmsStaff.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeleteDepartment
            // 
            this.DeleteDepartment.Name = "DeleteDepartment";
            this.DeleteDepartment.Size = new System.Drawing.Size(148, 22);
            this.DeleteDepartment.Text = "删除部门";
            this.DeleteDepartment.Click += new System.EventHandler(this.DeleteDepartment_Click);
            // 
            // EditDepartmentName
            // 
            this.EditDepartmentName.Name = "EditDepartmentName";
            this.EditDepartmentName.Size = new System.Drawing.Size(148, 22);
            this.EditDepartmentName.Text = "修改部门名";
            this.EditDepartmentName.Click += new System.EventHandler(this.EditDepartmentName_Click);
            // 
            // AddMember
            // 
            this.AddMember.Name = "AddMember";
            this.AddMember.Size = new System.Drawing.Size(148, 22);
            this.AddMember.Text = "添加成员";
            this.AddMember.Click += new System.EventHandler(this.AddMember_Click);
            // 
            // AddSubdivisions
            // 
            this.AddSubdivisions.Name = "AddSubdivisions";
            this.AddSubdivisions.Size = new System.Drawing.Size(148, 22);
            this.AddSubdivisions.Text = "添加子部门";
            this.AddSubdivisions.Click += new System.EventHandler(this.AddSubdivisions_Click);
            // 
            // cmsDepartment
            // 
            this.cmsDepartment.Arrow = System.Drawing.Color.Black;
            this.cmsDepartment.Back = System.Drawing.Color.White;
            this.cmsDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsDepartment.BackRadius = 4;
            this.cmsDepartment.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsDepartment.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsDepartment.Fore = System.Drawing.Color.Black;
            this.cmsDepartment.HoverFore = System.Drawing.Color.Black;
            this.cmsDepartment.ItemAnamorphosis = false;
            this.cmsDepartment.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsDepartment.ItemBorderShow = false;
            this.cmsDepartment.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsDepartment.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsDepartment.ItemRadius = 4;
            this.cmsDepartment.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsDepartment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSubdivisions,
            this.AddMember,
            this.EditDepartmentName,
            this.DeleteDepartment,
            this.tsmCreateDepart,
            this.tsmDepartChat});
            this.cmsDepartment.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsDepartment.Name = "contextMenuStrip2";
            this.cmsDepartment.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsDepartment.Size = new System.Drawing.Size(149, 136);
            this.cmsDepartment.SkinAllColor = true;
            this.cmsDepartment.Tag = "";
            this.cmsDepartment.TitleAnamorphosis = true;
            this.cmsDepartment.TitleColor = System.Drawing.Color.White;
            this.cmsDepartment.TitleRadius = 4;
            this.cmsDepartment.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsmCreateDepart
            // 
            this.tsmCreateDepart.Name = "tsmCreateDepart";
            this.tsmCreateDepart.Size = new System.Drawing.Size(148, 22);
            this.tsmCreateDepart.Text = "创建部门群";
            this.tsmCreateDepart.Click += new System.EventHandler(this.tsmCreateDepart_Click);
            // 
            // tsmDepartChat
            // 
            this.tsmDepartChat.Name = "tsmDepartChat";
            this.tsmDepartChat.Size = new System.Drawing.Size(148, 22);
            this.tsmDepartChat.Text = "创建部门群聊";
            this.tsmDepartChat.Visible = false;
            this.tsmDepartChat.Click += new System.EventHandler(this.tsmDepartChat_Click);
            // 
            // DeleteCompany
            // 
            this.DeleteCompany.Name = "DeleteCompany";
            this.DeleteCompany.Size = new System.Drawing.Size(136, 22);
            this.DeleteCompany.Text = "删除公司";
            this.DeleteCompany.Click += new System.EventHandler(this.DeleteCompany_Click);
            // 
            // QuitCompany
            // 
            this.QuitCompany.Name = "QuitCompany";
            this.QuitCompany.Size = new System.Drawing.Size(136, 22);
            this.QuitCompany.Text = "退出公司";
            this.QuitCompany.Click += new System.EventHandler(this.QuitCompany_Click);
            // 
            // EditCompany
            // 
            this.EditCompany.Name = "EditCompany";
            this.EditCompany.Size = new System.Drawing.Size(136, 22);
            this.EditCompany.Text = "修改公司名";
            this.EditCompany.Click += new System.EventHandler(this.EditCompany_Click);
            // 
            // AddDepartment
            // 
            this.AddDepartment.Name = "AddDepartment";
            this.AddDepartment.Size = new System.Drawing.Size(136, 22);
            this.AddDepartment.Text = "添加部门";
            this.AddDepartment.Click += new System.EventHandler(this.AddDepartment_Click);
            // 
            // cmsCompany
            // 
            this.cmsCompany.Arrow = System.Drawing.Color.Black;
            this.cmsCompany.Back = System.Drawing.Color.White;
            this.cmsCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCompany.BackRadius = 4;
            this.cmsCompany.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCompany.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsCompany.Fore = System.Drawing.Color.Black;
            this.cmsCompany.HoverFore = System.Drawing.Color.Black;
            this.cmsCompany.ItemAnamorphosis = false;
            this.cmsCompany.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCompany.ItemBorderShow = false;
            this.cmsCompany.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCompany.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsCompany.ItemRadius = 4;
            this.cmsCompany.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsCompany.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDepartment,
            this.EditCompany,
            this.QuitCompany,
            this.DeleteCompany,
            this.tsmCreateCompany});
            this.cmsCompany.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsCompany.Name = "contextMenuStrip1";
            this.cmsCompany.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsCompany.Size = new System.Drawing.Size(137, 114);
            this.cmsCompany.SkinAllColor = true;
            this.cmsCompany.Tag = "";
            this.cmsCompany.TitleAnamorphosis = true;
            this.cmsCompany.TitleColor = System.Drawing.Color.White;
            this.cmsCompany.TitleRadius = 4;
            this.cmsCompany.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // tsmCreateCompany
            // 
            this.tsmCreateCompany.Name = "tsmCreateCompany";
            this.tsmCreateCompany.Size = new System.Drawing.Size(136, 22);
            this.tsmCreateCompany.Text = "创建公司群";
            this.tsmCreateCompany.Visible = false;
            this.tsmCreateCompany.Click += new System.EventHandler(this.tsmCreateCompany_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(275, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "已选择：";
            this.label1.UseMnemonic = false;
            // 
            // lblNodeName
            // 
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNodeName.Location = new System.Drawing.Point(337, 20);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(39, 17);
            this.lblNodeName.TabIndex = 27;
            this.lblNodeName.Text = "NULL";
            this.lblNodeName.UseMnemonic = false;
            // 
            // tsmDetails
            // 
            this.tsmDetails.Name = "tsmDetails";
            this.tsmDetails.Size = new System.Drawing.Size(124, 22);
            this.tsmDetails.Text = "详情";
            this.tsmDetails.Click += new System.EventHandler(this.tsmDetails_Click);
            // 
            // tsmReplaceDepar
            // 
            this.tsmReplaceDepar.Name = "tsmReplaceDepar";
            this.tsmReplaceDepar.Size = new System.Drawing.Size(124, 22);
            this.tsmReplaceDepar.Text = "更换部门";
            // 
            // tsmEditPosition
            // 
            this.tsmEditPosition.Name = "tsmEditPosition";
            this.tsmEditPosition.Size = new System.Drawing.Size(124, 22);
            this.tsmEditPosition.Text = "修改职位";
            this.tsmEditPosition.Click += new System.EventHandler(this.tsmEditPosition_Click);
            // 
            // tsmDeleteStaff
            // 
            this.tsmDeleteStaff.Name = "tsmDeleteStaff";
            this.tsmDeleteStaff.Size = new System.Drawing.Size(124, 22);
            this.tsmDeleteStaff.Text = "删除员工";
            this.tsmDeleteStaff.Click += new System.EventHandler(this.tsmDeleteStaff_Click);
            // 
            // cmsStaff
            // 
            this.cmsStaff.Arrow = System.Drawing.Color.Black;
            this.cmsStaff.Back = System.Drawing.Color.White;
            this.cmsStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsStaff.BackRadius = 4;
            this.cmsStaff.Base = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsStaff.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.cmsStaff.Fore = System.Drawing.Color.Black;
            this.cmsStaff.HoverFore = System.Drawing.Color.Black;
            this.cmsStaff.ItemAnamorphosis = false;
            this.cmsStaff.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsStaff.ItemBorderShow = false;
            this.cmsStaff.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsStaff.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.cmsStaff.ItemRadius = 4;
            this.cmsStaff.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsStaff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDetails,
            this.tsmReplaceDepar,
            this.tsmEditPosition,
            this.tsmDeleteStaff});
            this.cmsStaff.ItemSplitter = System.Drawing.Color.Silver;
            this.cmsStaff.Name = "cmsStaff";
            this.cmsStaff.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.cmsStaff.Size = new System.Drawing.Size(125, 92);
            this.cmsStaff.SkinAllColor = true;
            this.cmsStaff.TitleAnamorphosis = true;
            this.cmsStaff.TitleColor = System.Drawing.Color.White;
            this.cmsStaff.TitleRadius = 4;
            this.cmsStaff.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(25, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 25);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "公司";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.UseMnemonic = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.tvwColleague);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 660);
            this.panel2.TabIndex = 35;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.BGColor = "26, 173, 25";
            this.btnCreate.FontColor = "#ffffff";
            this.btnCreate.Location = new System.Drawing.Point(75, 613);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(110, 28);
            this.btnCreate.TabIndex = 31;
            this.btnCreate.Text = "创建公司";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tvwColleague
            // 
            this.tvwColleague.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvwColleague.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tvwColleague.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwColleague.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvwColleague.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tvwColleague.HotTracking = true;
            this.tvwColleague.Indent = 20;
            this.tvwColleague.ItemHeight = 30;
            this.tvwColleague.Location = new System.Drawing.Point(3, 41);
            this.tvwColleague.Name = "tvwColleague";
            this.tvwColleague.SetBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tvwColleague.Size = new System.Drawing.Size(255, 554);
            this.tvwColleague.TabIndex = 28;
            this.tvwColleague.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.newTreeView1_NodeMouseClick);
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(260, 39);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(832, 1);
            this.skinLine1.TabIndex = 36;
            this.skinLine1.Text = "skinLine1";
            // 
            // pnlMyColleague
            // 
            this.pnlMyColleague.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMyColleague.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMyColleague.Location = new System.Drawing.Point(261, 41);
            this.pnlMyColleague.Name = "pnlMyColleague";
            this.pnlMyColleague.ScrollBarWidth = 10;
            this.pnlMyColleague.Size = new System.Drawing.Size(838, 617);
            this.pnlMyColleague.TabIndex = 26;
            // 
            // UserMyColleague
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.lblNodeName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMyColleague);
            this.Name = "UserMyColleague";
            this.Size = new System.Drawing.Size(1099, 658);
            this.cmsDepartment.ResumeLayout(false);
            this.cmsCompany.ResumeLayout(false);
            this.cmsStaff.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem DeleteDepartment;
        private System.Windows.Forms.ToolStripMenuItem EditDepartmentName;
        private System.Windows.Forms.ToolStripMenuItem AddMember;
        private System.Windows.Forms.ToolStripMenuItem AddSubdivisions;
        private CCWin.SkinControl.SkinContextMenuStrip cmsDepartment;
        private System.Windows.Forms.ToolStripMenuItem DeleteCompany;
        private System.Windows.Forms.ToolStripMenuItem QuitCompany;
        private System.Windows.Forms.ToolStripMenuItem EditCompany;
        private System.Windows.Forms.ToolStripMenuItem AddDepartment;
        private CCWin.SkinControl.SkinContextMenuStrip cmsCompany;
        private System.Windows.Forms.Label label1;
        public NewTreeView tvwColleague;
        private System.Windows.Forms.Label lblNodeName;
        private XListView pnlMyColleague;
        private System.Windows.Forms.ToolStripMenuItem tsmDetails;
        public System.Windows.Forms.ToolStripMenuItem tsmReplaceDepar;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPosition;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteStaff;
        private CCWin.SkinControl.SkinContextMenuStrip cmsStaff;
        private System.Windows.Forms.Label lblTitle;
        private LollipopButton btnCreate;
        private System.Windows.Forms.Panel panel2;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateCompany;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateDepart;
        private System.Windows.Forms.ToolStripMenuItem tsmDepartChat;
    }
}
