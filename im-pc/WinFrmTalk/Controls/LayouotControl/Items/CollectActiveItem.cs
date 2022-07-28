using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class CollectActiveItem : UserControl
    {
        public GroupFilesx ItemData { get; private set; }

        public CollectActiveItem()
        {
            InitializeComponent();

            this.tvName.MouseClick += Item_MouseClick;
            this.tvDay.MouseClick += Item_MouseClick;
            this.tvMonth.MouseClick += Item_MouseClick;
            this.tvLength.MouseClick += Item_MouseClick;

            this.tvName.MouseDown += Item_MouseDown;
            this.tvDay.MouseDown += Item_MouseDown;
            this.tvMonth.MouseDown += Item_MouseDown;
            this.tvLength.MouseDown += Item_MouseDown;


            tvName.MouseMove += Item_MouseMove;
            tvDay.MouseMove += Item_MouseMove;
            tvMonth.MouseMove += Item_MouseMove;
            tvLength.MouseMove += Item_MouseMove;

            tvName.MouseUp += Item_MouseUp;
            tvDay.MouseUp += Item_MouseUp;
            tvMonth.MouseUp += Item_MouseUp;
            tvLength.MouseUp += Item_MouseUp;

            toolTip1.Popup += new PopupEventHandler(toolTip1_Popup);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (Content != null && Content.Length > 100)
            {
                e.ToolTipSize = MeasureUtils.MeasureString(Content, new Font("宋体", 9f), 580, null, false);
            }
        }

        private void Item_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }
        private void Item_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public int ListWidth { get; internal set; }
        public string Content { get; set; }


        internal void SetContentData(GroupFilesx data, bool header)
        {
            this.ItemData = data;

            var test = UIUtils.IsNull(data.title) ? data.msg : data.title;
            Content = test;
            this.tvName.Text = test;
            //var size = MeasureUtils.MeasureString(test, this.tvName.Font, this.ListWidth - 63);
            //this.tvName.Size = size;
            this.Size = new Size(ListWidth, tvName.Height + 45);

            toolTip1.SetToolTip(this.tvName, test);

            this.tvLength.Text = string.Format("来自:{0}", data.collectSource);

            if (header)
            {
                tvDay.Text = TimeUtils.FromatTime(data.createTime, "dd");
                tvMonth.Text = TimeUtils.FromatTime(data.createTime, "MM月");
            }
            else
            {
                tvDay.Visible = false;
                tvMonth.Visible = false;
                icRound.Visible = false;
            }
        }

        public ResourcexType ResType
        {

            get
            {
                if (ItemData.collectType == 5 && ItemData.type == 5)
                {
                    return ResourcexType.notify;
                }
                else if (ItemData.collectType == 4 && ItemData.type == 5)
                {
                    return ResourcexType.active;
                }
                else if (ItemData.collectType == 2 && ItemData.type == 5)
                {
                    return ResourcexType.social;
                }
                else if (ItemData.collectType == 3 && ItemData.type == 5)
                {
                    return ResourcexType.res;
                }
                else if (ItemData.collectType == 5 && ItemData.type == 0)
                {
                    return ResourcexType.msg;
                }

                return ResourcexType.msg;
            }

        }

        internal CollectionSave toCollection()
        {

            CollectionSave item = new CollectionSave();
            item.title = this.ItemData.title;
            item.shareURL = this.ItemData.shareURL;
            item.msg = this.ItemData.msg;
            return item;

        }
    }

    public enum ResourcexType
    {
        notify,
        active,
        social,
        res,
        msg,
        file,
        image,
        video,
    }
}
