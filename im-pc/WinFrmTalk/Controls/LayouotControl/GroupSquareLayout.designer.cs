using WinFrmTalk.Controls.CustomControls;

namespace WinFrmTalk
{
    partial class GroupSquareLayout
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
            this.TimerSearch = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelGroupType = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGroupManage = new System.Windows.Forms.Label();
            this.labelGroupMain = new System.Windows.Forms.Label();
            this.flowLayoutPanelFL = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanelFL2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlus = new System.Windows.Forms.Button();
            this.GroupSearch = new WinFrmTalk.Controls.CustomControls.UserSearch();
            this.xListView = new TestListView.XListView();
            this.panelGroupType.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerSearch
            // 
            this.TimerSearch.Interval = 300;
            this.TimerSearch.Tick += new System.EventHandler(this.TimerSearch_Tick);
            // 
            // panelGroupType
            // 
            this.panelGroupType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGroupType.Controls.Add(this.label2);
            this.panelGroupType.Controls.Add(this.label1);
            this.panelGroupType.Controls.Add(this.labelGroupManage);
            this.panelGroupType.Controls.Add(this.labelGroupMain);
            this.panelGroupType.Location = new System.Drawing.Point(0, 5);
            this.panelGroupType.Name = "panelGroupType";
            this.panelGroupType.Size = new System.Drawing.Size(232, 29);
            this.panelGroupType.TabIndex = 28;
            this.panelGroupType.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGroupType_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择分类 ->";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "|";
            // 
            // labelGroupManage
            // 
            this.labelGroupManage.AutoSize = true;
            this.labelGroupManage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGroupManage.Location = new System.Drawing.Point(88, 8);
            this.labelGroupManage.Name = "labelGroupManage";
            this.labelGroupManage.Size = new System.Drawing.Size(29, 12);
            this.labelGroupManage.TabIndex = 1;
            this.labelGroupManage.Text = "社群";
            this.labelGroupManage.Click += new System.EventHandler(this.labelGroupManage_Click);
            // 
            // labelGroupMain
            // 
            this.labelGroupMain.AutoSize = true;
            this.labelGroupMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGroupMain.Location = new System.Drawing.Point(25, 8);
            this.labelGroupMain.Name = "labelGroupMain";
            this.labelGroupMain.Size = new System.Drawing.Size(31, 12);
            this.labelGroupMain.TabIndex = 0;
            this.labelGroupMain.Text = "官群";
            this.labelGroupMain.Click += new System.EventHandler(this.labelGroupMain_Click);
            // 
            // flowLayoutPanelFL
            // 
            this.flowLayoutPanelFL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFL.Location = new System.Drawing.Point(0, 35);
            this.flowLayoutPanelFL.Name = "flowLayoutPanelFL";
            this.flowLayoutPanelFL.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelFL.Size = new System.Drawing.Size(235, 402);
            this.flowLayoutPanelFL.TabIndex = 29;
            this.flowLayoutPanelFL.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutPanelFL2
            // 
            this.flowLayoutPanelFL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelFL2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFL2.Location = new System.Drawing.Point(226, 29);
            this.flowLayoutPanelFL2.Name = "flowLayoutPanelFL2";
            this.flowLayoutPanelFL2.Size = new System.Drawing.Size(100, 260);
            this.flowLayoutPanelFL2.TabIndex = 0;
            this.flowLayoutPanelFL2.Visible = false;
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.BackgroundImage = global::WinFrmTalk.Properties.Resources.ic_friend_add_normal;
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Location = new System.Drawing.Point(195, 12);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(25, 25);
            this.btnPlus.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnPlus, "查找群组");
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Visible = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // GroupSearch
            // 
            this.GroupSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(217)))), ((int)(((byte)(216)))));
            this.GroupSearch.Location = new System.Drawing.Point(13, 14);
            this.GroupSearch.LoseFocusResume = true;
            this.GroupSearch.Name = "GroupSearch";
            this.GroupSearch.Size = new System.Drawing.Size(173, 22);
            this.GroupSearch.TabIndex = 27;
            this.GroupSearch.Visible = false;
            // 
            // xListView
            // 
            this.xListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xListView.BackColor = System.Drawing.Color.White;
            this.xListView.Location = new System.Drawing.Point(0, 71);
            this.xListView.Name = "xListView";
            this.xListView.ScrollBarWidth = 10;
            this.xListView.Size = new System.Drawing.Size(235, 364);
            this.xListView.TabIndex = 26;
            // 
            // GroupSquareLayout
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelGroupType);
            this.Controls.Add(this.flowLayoutPanelFL2);
            this.Controls.Add(this.flowLayoutPanelFL);
            this.Controls.Add(this.GroupSearch);
            this.Controls.Add(this.xListView);
            this.Controls.Add(this.btnPlus);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GroupSquareLayout";
            this.Size = new System.Drawing.Size(235, 437);
            this.Load += new System.EventHandler(this.GroupSquareLayout_Load);
            this.panelGroupType.ResumeLayout(false);
            this.panelGroupType.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Timer TimerSearch;
        private TestListView.XListView xListView;
        private UserSearch GroupSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelGroupType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGroupManage;
        private System.Windows.Forms.Label labelGroupMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFL2;

        #endregion
        /*
        private System.Windows.Forms.TextBox txtSearch;
        private MyTabLayoutPanel tlpRoomList;
        private System.Windows.Forms.Button btnPlus;
        */
    }
}
