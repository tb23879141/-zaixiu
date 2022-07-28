namespace WinFrmTalk
{
    partial class Frminvitefriend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.leftList = new TestListView.XListView();
            this.rightList = new TestListView.XListView();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.userSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.lbltips = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(393, 445);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(68, 25);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(475, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // leftList
            // 
            this.leftList.BackColor = System.Drawing.Color.White;
            this.leftList.Location = new System.Drawing.Point(0, 64);
            this.leftList.Name = "leftList";
            this.leftList.ScrollBarWidth = 10;
            this.leftList.Size = new System.Drawing.Size(280, 414);
            this.leftList.TabIndex = 8;
            // 
            // rightList
            // 
            this.rightList.BackColor = System.Drawing.Color.White;
            this.rightList.Location = new System.Drawing.Point(295, 64);
            this.rightList.Name = "rightList";
            this.rightList.ScrollBarWidth = 10;
            this.rightList.Size = new System.Drawing.Size(266, 375);
            this.rightList.TabIndex = 9;
            // 
            // skinLine2
            // 
            this.skinLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinLine2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skinLine2.LineColor = System.Drawing.Color.DimGray;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(280, 0);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(1, 485);
            this.skinLine2.TabIndex = 13;
            this.skinLine2.Text = "skinLine2";
            // 
            // userSearch
            // 
            this.userSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.userSearch.Location = new System.Drawing.Point(24, 31);
            this.userSearch.LoseFocusResume = true;
            this.userSearch.Name = "userSearch";
            this.userSearch.Size = new System.Drawing.Size(230, 21);
            this.userSearch.TabIndex = 16;
            // 
            // lbltips
            // 
            this.lbltips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltips.ForeColor = System.Drawing.Color.Gray;
            this.lbltips.Location = new System.Drawing.Point(298, 25);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(163, 36);
            this.lbltips.TabIndex = 49;
            this.lbltips.Text = "请勾选需要添加的联系人";
            this.lbltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(469, 35);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(81, 17);
            this.lblCount.TabIndex = 48;
            this.lblCount.Text = "0/15人";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frminvitefriend
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 485);
            this.Controls.Add(this.lbltips);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.userSearch);
            this.Controls.Add(this.skinLine2);
            this.Controls.Add(this.rightList);
            this.Controls.Add(this.leftList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frminvitefriend";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "选择好友";
            this.TitleColor = System.Drawing.Color.Gray;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmFriendSelect_KeyPress);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private TestListView.XListView leftList;
        private TestListView.XListView rightList;
        private CCWin.SkinControl.SkinLine skinLine2;
        private Controls.CustomControls.UserSearch userSearch;
        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.Label lblCount;

        #endregion

        /*private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewImageColumn HeadImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn NickName;*/
    }
}