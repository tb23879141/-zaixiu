using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 秀吧气泡
    /// </summary>
    public partial class ResourexSocialPanel : UserControl
    {

        public ResourexSocialPanel()
        {
            InitializeComponent();

            this.tvTitle.MouseClick += Item_MouseClick;
            this.ivImage.MouseClick += Item_MouseClick;
            this.lab_lineSilver.MouseClick += Item_MouseClick;
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetItemData(string title, string url)
        {
            tvTitle.Text = title;
            ImageLoader.Instance.Load(url).Into(ivImage);
        }

    }
}
