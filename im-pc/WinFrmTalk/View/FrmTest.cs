using System;
using System.Windows.Forms;

namespace WinFrmTalk
{
    public partial class FrmTest : FrmBase
    {
        public FrmTest()
        {
            InitializeComponent();
            this.Load += FrmTest_Load;

        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            mainPageLayout1.SelectedIndex = MainTabIndex.RecentListPage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPageLayout1.SelectedIndex = MainTabIndex.FriendsPage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPageLayout1.SelectedIndex = MainTabIndex.Square;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cover = @"C:\Users\q8382\Desktop\2.jpg";

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ImageLoader.Instance.Load(cover).Center().Into(pictureBox1);
        }
    }
}
