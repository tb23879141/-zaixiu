using System;
using WinFrmTalk.Properties;

namespace WinFrmTalk
{
    public partial class FormTest : FrmBase
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // groupFuncTools1.SetToolbarData("一级菜单", 10, true);
            imageViewxFloder21.FolderType = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // groupFuncTools1.SetToolbarData("一级菜单/二级菜单", 10, false);

            imageViewxFloder21.FolderType = 1;
            imageViewxFloder21.Image = Resources.ic_group_floder5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageViewxFloder21.FolderType = 1;
            imageViewxFloder21.Image = Resources.ic_group_active_defalt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imageViewxFloder21.FolderType = 1;
            imageViewxFloder21.Image = null;
        }
    }
}
