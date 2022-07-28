namespace WinFrmTalk.Controls.CustomControls
{
    partial class UserOfficialAccount
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lab_detial = new System.Windows.Forms.Label();
            this.lblSpiltLine = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabpal = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lab_detial);
            this.panel2.Controls.Add(this.lblSpiltLine);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 50);
            this.panel2.TabIndex = 3;
            // 
            // lab_detial
            // 
            this.lab_detial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_detial.BackColor = System.Drawing.Color.Transparent;
            this.lab_detial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_detial.Image = global::WinFrmTalk.Properties.Resources.ic_Search;
            this.lab_detial.Location = new System.Drawing.Point(686, 10);
            this.lab_detial.Name = "lab_detial";
            this.lab_detial.Size = new System.Drawing.Size(48, 30);
            this.lab_detial.TabIndex = 9;
            this.lab_detial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Lab_detial_MouseClick);
            // 
            // lblSpiltLine
            // 
            this.lblSpiltLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpiltLine.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSpiltLine.Location = new System.Drawing.Point(0, 49);
            this.lblSpiltLine.Name = "lblSpiltLine";
            this.lblSpiltLine.Size = new System.Drawing.Size(740, 1);
            this.lblSpiltLine.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(11, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 25);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "公众号";
            this.lblTitle.UseMnemonic = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 547);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.tabpal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 497);
            this.panel3.TabIndex = 4;
            // 
            // tabpal
            // 
            this.tabpal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabpal.AutoScroll = true;
            this.tabpal.Location = new System.Drawing.Point(74, 6);
            this.tabpal.Name = "tabpal";
            this.tabpal.Size = new System.Drawing.Size(577, 488);
            this.tabpal.TabIndex = 13;
            // 
            // UserOfficialAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserOfficialAccount";
            this.Size = new System.Drawing.Size(740, 547);
            this.Load += new System.EventHandler(this.UserOfficialAccount_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSpiltLine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel tabpal;
        public System.Windows.Forms.Label lab_detial;
    }
}
