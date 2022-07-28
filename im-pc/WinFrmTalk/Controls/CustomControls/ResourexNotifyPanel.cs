using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 资源气泡
    /// </summary>
    public partial class ResourexNotifyPanel : UserControl
    {

        public ResourexNotifyPanel()
        {
            InitializeComponent();

            this.tvTitle.MouseClick += Item_MouseClick;
            this.tvContent.MouseClick += Item_MouseClick;
            this.lab_lineSilver.MouseClick += Item_MouseClick;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetItemData(string title, string text)
        {
            tvTitle.Text = title;
            tvContent.Text = text;
            this.Height = tvContent.Height + 50;
        }

        private void ResourexNotifyPanel_Load(object sender, System.EventArgs e)
        {

        }
    }
}
