using System;
using System.Windows.Forms;

namespace WinFrmTalk.Controls
{
    /// <summary>
    /// 接龙
    /// </summary>
    public partial class SolitairePanel : UserControl
    {

        public SolitairePanel()
        {
            InitializeComponent();

            foreach (Control item in this.Controls)
            {
                item.MouseClick += Item_MouseClick;
            }
        }

        private void Item_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        public void SetItemData(SolitaireData data)
        {
            if (!UIUtils.IsNull(data.name))
            {
                if (data.name.Length > 5)
                {
                    tvDescript.Text = data.name.Substring(5, data.name.Length - 5);

                }
                else
                {
                    tvDescript.Text = data.name;
                }
            }
            else
            {
                tvDescript.Text = "";
            }

            tvFromat.Text = data.example;

            if (data.solitaireBodies != null)
            {
                int count = Math.Min(3, data.solitaireBodies.Count);

                if (count > 0)
                {
                    tvLabel1.Visible = true;
                    tvLabel1.Text = String.Format("1. {0}:{1}", data.solitaireBodies[0].userName, data.solitaireBodies[0].body);
                }

                if (count > 1)
                {
                    tvLabel2.Visible = true;
                    tvLabel2.Text = String.Format("2. {0}:{1}", data.solitaireBodies[1].userName, data.solitaireBodies[1].body);
                }

                if (count > 2)
                {
                    if (data.solitaireBodies.Count == 3)
                    {
                        tvLabel3.Text = String.Format("3. {0}:{1}", data.solitaireBodies[2].userName, data.solitaireBodies[2].body);
                    }
                    else
                    {
                        tvLabel3.Text = "......";
                    }

                    tvLabel3.Visible = true;
                }

                this.Height = count * 25 + 70;
            }
            else
            {
                this.Height = 70;
            }

        }

    }
}
