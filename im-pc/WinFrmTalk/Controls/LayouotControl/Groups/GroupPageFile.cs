using System.Windows.Forms;
using WinFrmTalk.View;

namespace WinFrmTalk.Controls.LayouotControl.Groups
{
    public partial class GroupPageFile : UserControl
    {
        public GroupPageFile()
        {
            InitializeComponent();

            this.filePanel.MouseClick += Item_MouseClick;
            this.tvFileName.MouseClick += Item_MouseClick;
            this.label1.MouseClick += Item_MouseClick;

            this.filePanel.MouseDown += Item_MouseDown;
            this.tvFileName.MouseDown += Item_MouseDown;
            this.label1.MouseDown += Item_MouseDown;
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetControlData(Information information)
        {
            tvTitle.Text = information.title;
            tvFileName.Text = information.FindName;

            tvFileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            FrmHistoryChat.TypeFileToImage(information.url, tvFileIcon);
        }

    }
}
