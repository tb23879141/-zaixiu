using TestListView;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class UseGroupInfoChat
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
            this.groupPageMain1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupPageMain();
            this.groupPageFunc1 = new WinFrmTalk.Controls.LayouotControl.Groups.GroupPageFunc();
            this.SuspendLayout();
            // 
            // groupPageMain1
            // 
            this.groupPageMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPageMain1.BackColor = System.Drawing.Color.White;
            this.groupPageMain1.Location = new System.Drawing.Point(0, -1);
            this.groupPageMain1.Name = "groupPageMain1";
            this.groupPageMain1.Size = new System.Drawing.Size(724, 660);
            this.groupPageMain1.TabIndex = 5;
            // 
            // groupPageFunc1
            // 
            this.groupPageFunc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPageFunc1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupPageFunc1.Location = new System.Drawing.Point(0, 0);
            this.groupPageFunc1.Name = "groupPageFunc1";
            this.groupPageFunc1.Size = new System.Drawing.Size(724, 660);
            this.groupPageFunc1.TabIndex = 6;
            // 
            // UseGroupInfoChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupPageMain1);
            this.Controls.Add(this.groupPageFunc1);
            this.Name = "UseGroupInfoChat";
            this.Size = new System.Drawing.Size(724, 660);
            this.ResumeLayout(false);

        }

        #endregion
        private LayouotControl.Groups.GroupPageMain groupPageMain1;
        private LayouotControl.Groups.GroupPageFunc groupPageFunc1;
    }
}
