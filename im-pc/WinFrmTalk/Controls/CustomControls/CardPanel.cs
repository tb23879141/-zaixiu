using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

namespace WinFrmTalk.Controls
{
    public partial class CardPanel : UserControl
    {
        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lab_txt.Text = LanguageXmlUtils.GetValue("Card", lab_txt.Text);
        }

        public CardPanel()
        {
            InitializeComponent();
            LoadLanguageText();

            foreach (Control crl in this.Controls)
            {
                crl.MouseClick += Item_MouseClick; ;
            }
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }



        internal void SetItemData(MessageObject messageObject)
        {
            tvName.Text = messageObject.content;

            if (messageObject.timeLen == 1)
            {
                ImageLoader.Instance.DisplayGroupAvatar(messageObject.objectId, messageObject.signature, ivIcon);
                this.BackgroundImage = Resources.ic_card_bg1;
                lab_txt.Text = "群名片";
                tvAccount.Text = string.Format("群号 {0}", messageObject.fileName);

                tvName.ForeColor = Color.FromArgb(51, 51, 51);
                lab_txt.ForeColor = Color.FromArgb(51, 51, 51);
                tvAccount.ForeColor = Color.FromArgb(51, 51, 51);

            }
            else
            {
                ImageLoader.Instance.DisplayAvatar(messageObject.objectId, messageObject.content, ivIcon);
                tvAccount.Text = string.Format("在秀号 {0}", messageObject.fileName);
                this.BackgroundImage = Resources.ic_card_bg;
                lab_txt.Text = "个人名片";

            }

        }
    }
}
