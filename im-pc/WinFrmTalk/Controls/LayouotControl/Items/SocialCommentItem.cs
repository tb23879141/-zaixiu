using System.Windows.Forms;
using WinFrmTalk.Controls.LayouotControl.Groups;

namespace WinFrmTalk.Controls.LayouotControl.Items
{
    public partial class SocialCommentItem : UserControl
    {
        public SocialCommentItem()
        {
            InitializeComponent();

            //tvTitle.MouseDown += Item_MouseDown;
            //ivIcon.MouseDown += Item_MouseDown;
            //tvTime.MouseDown += Item_MouseDown;
            //tvFileName.MouseDown += Item_MouseDown;

            //label1.MouseClick += Item_MouseClick;
            //tvTitle.MouseClick += Item_MouseClick;
            //ivIcon.MouseClick += Item_MouseClick;
            //tvTime.MouseClick += Item_MouseClick;
            //tvFileName.MouseClick += Item_MouseClick;
            //tvSize.MouseClick += Item_MouseClick;

            //label1.MouseMove += Item_MouseMove;
            //tvTitle.MouseMove += Item_MouseMove;
            //ivIcon.MouseMove += Item_MouseMove;
            //tvTime.MouseMove += Item_MouseMove;
            //tvFileName.MouseMove += Item_MouseMove;
            //tvSize.MouseMove += Item_MouseMove;

            //label1.MouseUp += Item_MouseUp;
            //tvTitle.MouseUp += Item_MouseUp;
            //ivIcon.MouseUp += Item_MouseUp;
            //tvTime.MouseUp += Item_MouseUp;
            //tvFileName.MouseUp += Item_MouseUp;
            //tvSize.MouseUp += Item_MouseUp;
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



        internal void SetContentData(SocialCommentData data)
        {
            ImageLoader.Instance.DisplayAvatar(data.userId, data.nickname, ivIcon);
            tvTitle.Text = data.nickname;
            tvFileName.Text = data.body;
            tvTime.Text = TimeUtils.FromatTime(data.time, "yyyy/MM/dd HH:mm");

            this.Height = tvFileName.Height + 66;
        }
    }
}
