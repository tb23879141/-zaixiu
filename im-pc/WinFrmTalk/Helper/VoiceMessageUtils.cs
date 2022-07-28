using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFrmTalk.Model;

namespace WinFrmTalk.Helper
{
    public class VoiceMessageUtils
    {
        #region 单例模式

        private static readonly VoiceMessageUtils instance = new VoiceMessageUtils();

        private MP3Player mp3;
        /// <summary>
        /// 显式的静态构造函数用来告诉C#编译器在其内容实例化之前不要标记其类型
        /// </summary>
        static VoiceMessageUtils() { }

        private VoiceMessageUtils()
        {
        }

        public static VoiceMessageUtils Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion


        public bool IsOpenRecordVoice { get; set; }



        private Panel view;
        private MessageObject message;

        private void InitVoiceAnim()
        {
            if (view != null && !view.IsDisposed)
            {
                //if (isMyMsg)
                //    action = new Action(() =>
                //    {
                //        image = Image.FromFile(Applicate.AppPublicDirectory + @"Res\VoiceBg\voice_paly_right_" + frames + ".png");
                //        ((Panel)sender).BackgroundImage = new Bitmap(image, 23, 23);
                //    });
                //else
                //    action = new Action(() =>
                //    {
                //        image = Image.FromFile(Applicate.AppPublicDirectory + @"Res\VoiceBg\voice_paly_left_" + frames + ".png");
                //        ((Panel)sender).BackgroundImage = new Bitmap(image, 23, 23);
                //    });

                //image = Image.FromFile(bg_filePath);
                //((Panel)sender).BackgroundImage = new Bitmap(image, 23, 23);
            }
        }

        public void PlayVoice(string path, MessageObject msg, Panel panel_voice)
        {

            if (mp3 == null)
            {
                mp3 = new MP3Player();

                view = panel_voice;

                message = msg;


                // 播放语音文件   
                mp3.FilePath = path;
                mp3.Play();

                // 播放动画
                //PlayVoiceAnim();
            }
            else
            {
                InitVoiceAnim();


            }



            //#region 语音异步播放动画
            ////语音长度
            //int timeLen = msg.timeLen;
            ////记录语音的帧数
            //int frames = 0;
            ////当前播放到第几秒
            //int num = 0;
            ////播放语音动画
            //Timer voice_timer = new Timer();
            //voice_timer.Interval = 1000;
            //voice_timer.Enabled = true;
            //voice_timer.Start();
            //voice_timer.Tick += (s, ev) =>
            //{
            //    frames++;
            //    num++;
            //    //调用方法
            //    Action action;
            //    if (isMyMsg)
            //        action = new Action(() =>
            //        {
            //            image = Image.FromFile(Applicate.AppPublicDirectory + @"Res\VoiceBg\voice_paly_right_" + frames + ".png");
            //            ((Panel)sender).BackgroundImage = new Bitmap(image, 23, 23);
            //        });
            //    else
            //        action = new Action(() =>
            //        {
            //            image = Image.FromFile(Applicate.AppPublicDirectory + @"Res\VoiceBg\voice_paly_left_" + frames + ".png");
            //            ((Panel)sender).BackgroundImage = new Bitmap(image, 23, 23);
            //        });
            //    action.Invoke();
            //    //播放三帧则重置
            //    frames = frames % 3 == 0 ? 0 : frames;


            //    //播放完毕
            //    if (num > timeLen)
            //    {
            //        //结束计时
            //        voice_timer.Stop();
            //        voice_timer.Dispose();

            //        //修改回默认图片
                  

            //        //阅后即焚
            //        if (msg.isReadDel == 1 && msg.fromUserId != Applicate.MyAccount.userId)
            //            Messenger.Default.Send<string>(msg.messageId, token: EQFrmInteraction.RemoveMsgOfPanel);
            //    }
            //};

        }

    }
}
