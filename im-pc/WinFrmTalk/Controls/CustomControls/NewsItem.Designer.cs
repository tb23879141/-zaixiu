using System.Windows.Forms;
using WinFrmTalk.View.Common;

namespace WinFrmTalk.Controls.CustomControls
{
    partial class NewsItem
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
            this.components = new System.ComponentModel.Container();
            this.lab_time = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.lab_readNum = new System.Windows.Forms.Label();
            this.pic_head = new System.Windows.Forms.PictureBox();
            this.recentTextBoxEx1 = new WinFrmTalk.Controls.CustomControls.RecentTextBoxEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_time
            // 
            this.lab_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_time.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_time.ForeColor = System.Drawing.Color.DimGray;
            this.lab_time.Location = new System.Drawing.Point(172, 12);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(80, 18);
            this.lab_time.TabIndex = 6;
            this.lab_time.Text = "2019/11/11";
            this.lab_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_name
            // 
            this.lab_name.AutoEllipsis = true;
            this.lab_name.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.lab_name.Location = new System.Drawing.Point(48, 10);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(112, 20);
            this.lab_name.TabIndex = 7;
            this.lab_name.Text = "Name";
            this.lab_name.UseMnemonic = false;
            // 
            // lab_readNum
            // 
            this.lab_readNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_readNum.AutoSize = true;
            this.lab_readNum.BackColor = System.Drawing.Color.Transparent;
            this.lab_readNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_readNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.lab_readNum.Location = new System.Drawing.Point(230, 31);
            this.lab_readNum.Name = "lab_readNum";
            this.lab_readNum.Size = new System.Drawing.Size(25, 17);
            this.lab_readNum.TabIndex = 10;
            this.lab_readNum.Text = "🔕";
            this.lab_readNum.Visible = false;
            // 
            // pic_head
            // 
            this.pic_head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_head.Location = new System.Drawing.Point(6, 12);
            this.pic_head.Name = "pic_head";
            this.pic_head.Size = new System.Drawing.Size(35, 35);
            this.pic_head.TabIndex = 11;
            this.pic_head.TabStop = false;
            // 
            // recentTextBoxEx1
            // 
            this.recentTextBoxEx1.AtMe = 0;
            this.recentTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recentTextBoxEx1.ForeColor = System.Drawing.Color.DimGray;
            this.recentTextBoxEx1.Location = new System.Drawing.Point(50, 31);
            this.recentTextBoxEx1.Name = "recentTextBoxEx1";
            this.recentTextBoxEx1.Size = new System.Drawing.Size(174, 25);
            this.recentTextBoxEx1.TabIndex = 13;
            this.recentTextBoxEx1.Text = "";
            // 
            // NewsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.recentTextBoxEx1);
            this.Controls.Add(this.pic_head);
            this.Controls.Add(this.lab_time);
            this.Controls.Add(this.lab_readNum);
            this.Controls.Add(this.lab_name);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NewsItem";
            this.Size = new System.Drawing.Size(250, 60);
            this.Load += new System.EventHandler(this.NewsItem_Load);
            this.MouseEnter += new System.EventHandler(this.NewsItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NewsItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label lab_time;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label lab_readNum;
        public PictureBox pic_head;
        private RecentTextBoxEx recentTextBoxEx1;
        private ToolTip toolTip1;
    }
}
