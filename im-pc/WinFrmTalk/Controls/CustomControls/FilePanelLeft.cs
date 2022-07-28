using System;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.View;

namespace WinFrmTalk
{
    public partial class FilePanelLeft : UserControl
    {
        /// <summary>
        ///记录文件是否正在下载
        /// </summary>
        public bool isDownloading { get; set; }
        public string localPath { get; set; }
        public string FileName
        {
            get
            {
                return lab_fileName.Text;
            }
            internal set
            {
                lab_fileName.Text = value;
                lab_icon.SizeMode = PictureBoxSizeMode.StretchImage;
                FrmHistoryChat.TypeFileToImage(value, lab_icon);
            }
        }

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lab_txt.Text = LanguageXmlUtils.GetValue("File", lab_txt.Text);
        }

        public FilePanelLeft()
        {
            InitializeComponent();
        }

        private void FilePanel_Load(object sender, EventArgs e)
        {
            this.Size = new Size(panel_file.Width + 2, panel_file.Height + 2);
        }
    }
}
