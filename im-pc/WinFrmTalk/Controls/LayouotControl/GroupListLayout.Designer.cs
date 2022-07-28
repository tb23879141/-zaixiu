using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk
{
    partial class GroupListLayout
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabLayoutPanel1 = new WinFrmTalk.Controls.TabLayoutPanel();
            this.xListView = new TestListView.XListView();
            this.SuspendLayout();
            // 
            // tabLayoutPanel1
            // 
            this.tabLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.tabLayoutPanel1.DelimitLineHeight = 18;
            this.tabLayoutPanel1.ItemMaginLeft = -1;
            this.tabLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabLayoutPanel1.Name = "tabLayoutPanel1";
            this.tabLayoutPanel1.Size = new System.Drawing.Size(275, 38);
            this.tabLayoutPanel1.TabIndex = 29;
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.xListView.Location = new System.Drawing.Point(0, 38);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(275, 572);
            this.xListView.TabIndex = 26;
            // 
            // GroupListLayout
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.tabLayoutPanel1);
            this.Controls.Add(this.xListView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GroupListLayout";
            this.Size = new System.Drawing.Size(275, 610);
            this.ResumeLayout(false);

        }
        private TestListView.XListView xListView;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.TabLayoutPanel tabLayoutPanel1;

        #endregion
        /*
        private System.Windows.Forms.TextBox txtSearch;
        private MyTabLayoutPanel tlpRoomList;
        private System.Windows.Forms.Button btnPlus;
        */
    }
}
