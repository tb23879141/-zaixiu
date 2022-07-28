using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;
using System.Threading;
using WinFrmTalk.Helper;

namespace WinFrmTalk.Controls.CustomControls
{
    public partial class UserSoundRecording : UserControl
    {
        public bool SoundState { get => nr.SoundState; set => nr.SoundState = value; }
        public NAudioRecorder nr = null;

        private void LoadLanguageText()
        {
            if (!Applicate.ENABLE_MULTI_LANGUAGE)
                return;

            lblName.Text = LanguageXmlUtils.GetValue("recording", lblName.Text);
            btnSend.Text = LanguageXmlUtils.GetValue("send", btnSend.Text);
        }

        public UserSoundRecording()
        {
            InitializeComponent();
            LoadLanguageText();
     
            nr = new NAudioRecorder(this);
            nr.times = (times) =>
            {
                lbltime.Visible = true;
                lbltime.Text = (60 - times).ToString();
            };
        }

        /// <summary>
        /// 是否可以录音（成功则直接开始录音）
        /// </summary>
        /// <returns></returns>
        public bool IsCanSoundRecord()
        {
            if (nr.StartRec())
            {
                VoiceMessageUtils.Instance.IsOpenRecordVoice = true;
                SoundState = true;
                return true;
            }
            else
            {
                File.Delete(nr.FilePath);
                return false;
            }
        }

        public void btnSend_Click(object sender, EventArgs e)
        {
            VoiceMessageUtils.Instance.IsOpenRecordVoice = false;
            nr.StopRec();
            SoundState = false;
            if (nr.PathCallback != null)
            {
                //0秒结束
                int secoudes = (int)nr.stopWatch.Elapsed.TotalSeconds;
                if (secoudes == 0)
                {
                    HttpUtils.Instance.ShowTip("录音时间过短！");
                    StopSound();
                    return;

                }
                nr.PathCallback(nr.FilePath, nr.stopWatch.Elapsed);

            }
            this.SendToBack();
        }
        public void StopSound()
        {
            lbltime.Text = "";
            SoundState = false;
            VoiceMessageUtils.Instance.IsOpenRecordVoice = false;
            this.SendToBack();
            nr.StopRec();
            File.Delete(nr.FilePath);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            StopSound();
        }
    }
}
