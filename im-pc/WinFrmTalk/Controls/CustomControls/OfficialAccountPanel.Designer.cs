namespace WinFrmTalk.Controls.CustomControls
{
    partial class OfficialAccountPanel
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.xlvTabel = new TestListView.XListView();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnQuery.FlatAppearance.BorderSize = 0;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(246, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(64, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查找";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnQuery_MouseClick);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Font = new System.Drawing.Font("宋体", 10F);
            this.txtKeyWord.Location = new System.Drawing.Point(10, 10);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(229, 23);
            this.txtKeyWord.TabIndex = 6;
            this.txtKeyWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyWord_KeyPress);
            // 
            // xlvTabel
            // 
            this.xlvTabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xlvTabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xlvTabel.Location = new System.Drawing.Point(10, 50);
            this.xlvTabel.Name = "xlvTabel";
            this.xlvTabel.ScrollBarWidth = 10;
            this.xlvTabel.Size = new System.Drawing.Size(300, 422);
            this.xlvTabel.TabIndex = 8;
            // 
            // OfficialAccountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.xlvTabel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtKeyWord);
            this.Name = "OfficialAccountPanel";
            this.Size = new System.Drawing.Size(320, 485);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtKeyWord;
        public TestListView.XListView xlvTabel;
    }
}
