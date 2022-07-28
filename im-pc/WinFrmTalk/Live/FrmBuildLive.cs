using CCWin.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmTalk.Live
{
    public partial class FrmBuildLive : FrmBase
    {
        private string name;
        private string notice;

        public string live_name { get; private set; }
        public string live_notice { get; private set; }
        public int live_type { get; set; } = 1;//直播类型 1 分享  2 娱乐

        public int roomType
        {
            get => live_type; 
            set 
           {
                live_type = value;
                if (value == 2)
                {
                    checkShare.Checked = false;
                    checkRecreation.Checked = true;
                    this.labelShare.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    this.labelShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
                    this.labelShare.Location = new System.Drawing.Point(90, 12);
                    this.labelRecreation.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    this.labelRecreation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
                    this.labelRecreation.Location = new System.Drawing.Point(363, 13);
                    this.textRecreation.Visible = true;
                    this.textShare.Visible = false;
                }
                else
                {
                    checkShare.Checked = true;
                    checkRecreation.Checked = false;
                    this.labelRecreation.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
                    this.labelRecreation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
                    this.labelRecreation.Location = new System.Drawing.Point(373, 13);
                    this.labelShare.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    this.labelShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
                    this.labelShare.Location = new System.Drawing.Point(80, 12);
                    this.textRecreation.Visible = false;
                    this.textShare.Visible = true;
                }
            }
        }//直播类型 1 分享  2 娱乐
        public string txtName_Text
        {
            get => name;
            set
            {
                name = value;
                if (value.Length > 20)
                {
                    txtName.Text = value.Remove(17) + "...";
                }
                else
                {
                    txtName.Text = value;
                }
            }
        }
        public string txtNotice_Text
        {
            get => notice;
            set
            {
                notice = value;
                if (value.Length > 100)
                {
                    txtNotice.Text = value.Remove(97) + "...";
                }
                else
                {
                    txtNotice.Text = value;
                }
            }
        }
        public string btnStartLive_Text { get => btnStartLive.Text; set => btnStartLive.Text = value; }

        public FrmBuildLive()
        {
            InitializeComponent();
        }

        private void BtnStartLive_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                live_name = txtName.Text.Trim();
                live_notice = txtNotice.Text.Trim();
                txtName_Text = txtName.Text.Trim(); 
                txtNotice_Text = txtNotice.Text.Trim();
                if (!string.IsNullOrEmpty(live_name) && !string.IsNullOrEmpty(live_notice))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    HttpUtils.Instance.ShowTip("直播间的名称和公告必须填写！！");
            }
        }

        private void FrmBuildLive_Load(object sender, EventArgs e)
        {
            ImageLoader.Instance.DisplayAvatar(Applicate.MyAccount.userId, pic_myIcon);//设置头像
        }

        private void labelRecreation_Click(object sender, EventArgs e)
        {
            
        }
        private void labelShare_Click(object sender, EventArgs e)
        {
            
        }
        private void checkRecreation_Click(object sender, EventArgs e)
        {
            live_type = 2;
            checkShare.Checked = false;
            checkRecreation.Checked = true;
            this.labelShare.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.labelShare.Location = new System.Drawing.Point(90, 12);
            this.labelRecreation.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRecreation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.labelRecreation.Location = new System.Drawing.Point(363, 13);
            this.textRecreation.Visible = true;
            this.textShare.Visible = false;
        }

        private void checkShare_Click(object sender, EventArgs e)
        {
            live_type = 1;
            checkShare.Checked = true;
            checkRecreation.Checked = false;
            this.labelRecreation.Font = new System.Drawing.Font("微软雅黑", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            this.labelRecreation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.labelRecreation.Location = new System.Drawing.Point(373, 13);
            this.labelShare.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(24)))), ((int)(((byte)(219)))));
            this.labelShare.Location = new System.Drawing.Point(80, 12);
            this.textRecreation.Visible = false;
            this.textShare.Visible = true;
        }
    }
}
