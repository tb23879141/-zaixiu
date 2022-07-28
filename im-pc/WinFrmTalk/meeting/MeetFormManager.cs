using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WinFrmTalk;
using WinFrmTalk.Model;
using WinFrmTalk.View;

public class MeetFormManager
{
    #region 全局变量
    private static MeetFormManager _instance;
    public static MeetFormManager Instance => _instance ?? (_instance = new MeetFormManager());
    private const int STATE_IDLE = 0; // 空闲中
    private const int STATE_DIALING = 1; // 拨号中 - 等待对方接听
    private const int STATE_ANSWERING = 2; // 响铃中 - 等待我接听
    private const int STATE_CALLING = 3; // 接听中 - 通话中
    private int mCurrState = STATE_IDLE;
    public bool isRecovePhone;//是否正在通话

    public delegate void DelegateChangeUser(string tag, string url, string name);
    public delegate void DelegateMeetLoad();
    #endregion

    #region 参数传递
    /// <summary>
    ///  显示拨号界面
    /// </summary>
    public void ShowDialForm(MessageObject message, string url, bool isGroup = false)
    {
        Friend friend = message.GetFriend();
        //好友
        if (!isGroup)
        {
            if (mCurrState == STATE_IDLE && Applicate.IsOpenFrom)
            {
                //拨打界面
                FrmDial frmDial = new FrmDial();
                frmDial.CallPhone(friend, url, message.type == kWCMessageType.VideoChatAsk);
                mCurrState = STATE_DIALING;
                Applicate.IsOpenFrom = false;
                return;
            }
        }
        //群组
        else
        {
            if (mCurrState == STATE_IDLE && Applicate.IsOpenFrom)
            {
                mCurrState = STATE_CALLING;
                Applicate.IsOpenFrom = false;

                // 群组会议直接进入会话界面
                int meettype = ToMeetType(message.type);

                if (meettype == 0)
                {
                    FrmVoiceMeetRoom voiceMeet = new FrmVoiceMeetRoom();
                    string userName = UIUtils.QuotationName(message.fromUserName);
                    friend.UserId = message.objectId;
                    friend = friend.GetByUserId();
                    voiceMeet.ConnectVoiceMeet(friend, url, userName);
                    voiceMeet.Show();
                    voiceMeet.BringToFront();
                }
                else
                {
                    FrmRecivePhone frmRecive = new FrmRecivePhone();
                    //通话界面
                    frmRecive.ShowGroup(friend, url, true, meettype, message);
                }

                return;
            }

        }
        //不等于0发忙线
        if (mCurrState != STATE_IDLE)
        {
            ShiKuManager.SendBusyMeetMessage(friend);
        }
    }

    /// <summary>
    /// 显示接听界面
    /// </summary>
    public void ShowAnswerForm(MessageObject message, string url, bool isGroup = false)
    {

        Friend friend = message.GetFriend();
        //好友
        if (!isGroup)
        {
            if (mCurrState == STATE_IDLE)
            {
                FrmAnswer frm = new FrmAnswer();
                frm.fillDataFrined(friend, message, message.type == kWCMessageType.VideoChatAsk, url);
                mCurrState = STATE_ANSWERING;
                Applicate.IsOpenFrom = false;
                return;
            }

        }
        //群组
        else
        {
            if (mCurrState == STATE_IDLE)
            {
                FrmAnswer frm = new FrmAnswer();
                frm.fillDataGroup(friend, message, message.type == kWCMessageType.VideoMeetingInvite, true);
                frm.Url = url;
                mCurrState = STATE_ANSWERING;
                Applicate.IsOpenFrom = false;
                return;
            }

        }
        //不等于0发忙线
        if (mCurrState != STATE_IDLE)
        {
            ShiKuManager.SendBusyMeetMessage(friend);
        }
    }

    /// <summary>
    /// 显示通话中界面
    /// </summary>
    public void ShowRecivePhoneForm(MessageObject message, string url, bool isMyDail, bool isGroup = false)
    {
        Friend friend = message.GetFriend();

        //群组
        if (isGroup)
        {
            if (!isRecovePhone)
            {

                int meettype = ToMeetType(message.type);
                mCurrState = STATE_CALLING;
                Applicate.IsOpenFrom = false;

                StopWiatSound();

                if (meettype == 0)
                {
                    FrmVoiceMeetRoom voiceMeet = new FrmVoiceMeetRoom();
                    string name = UIUtils.QuotationName(message.fromUserName);
                    voiceMeet.ConnectVoiceMeet(friend, url, name);
                    voiceMeet.Show();
                    voiceMeet.BringToFront();
                }
                else
                {
                    FrmRecivePhone frmRecive = new FrmRecivePhone();
                    //通话界面
                    frmRecive.ShowGroup(friend, url, true, meettype, message);
                }
                return;
            }
        }
        //好友
        else
        {
            if (!isRecovePhone)
            {
                int meettype = ToMeetType(message.type);
                mCurrState = STATE_CALLING;
                Applicate.IsOpenFrom = false;

                StopWiatSound();

                if (meettype == 0)
                {
                    var meetvoice = new FrmVoiceMeetUser();
                    meetvoice.ConnectVoice(friend, url);
                    meetvoice.Show();
                    mCurrState = STATE_CALLING;
                    return;
                }
                else
                {
                    FrmRecivePhone meetHtml = new FrmRecivePhone();
                    meetHtml.fillDataFrined(friend, meettype, url);
                }
                return;

            }
        }
        if (mCurrState != STATE_IDLE)
        {
            ShiKuManager.SendBusyMeetMessage(friend);
        }
    }
    /// <summary>
    /// 初始化状态
    /// </summary>
    public void InitFrom()
    {
        mCurrState = STATE_IDLE;
        Applicate.IsOpenFrom = true;
    }

    public void OtherRecive()
    {
        mCurrState = STATE_CALLING;
        Applicate.IsOpenFrom = false;
    }


    #endregion

    /// <summary>
    /// 判断通话类型
    /// </summary>
    /// <returns></returns>
    private int ToMeetType(kWCMessageType type)
    {
        switch (type)
        {
            case kWCMessageType.VideoMeetingInvite:
            case kWCMessageType.VideoChatAccept:
            case kWCMessageType.VideoChatAsk:
                return 1;
            case kWCMessageType.AudioMeetingInvite:
            case kWCMessageType.AudioChatAccept:
            case kWCMessageType.AudioChatAsk:
                return 0;
            case kWCMessageType.ScreenMeetInvite:
            case kWCMessageType.ScreenMeetAccept:
            case kWCMessageType.ScreenMeetAsk:
                return 2;
            default:
                return 0;
        }
    }


    SoundPlayer soundPlayer;
    internal void PlayWiatSound()
    {
        if (soundPlayer == null)
        {
            soundPlayer = new SoundPlayer("Ring.wav");
            soundPlayer.PlayLooping();
        }

    }

    internal void StopWiatSound()
    {
        if (soundPlayer != null)
        {
            soundPlayer.Stop();
            soundPlayer = null;
        }
    }




    /// <summary>
    /// 网页回调类
    /// </summary>
    public class MeetCallEvent
    {
        private Action<string, string, string> mUserlistener;
        private Action mLoadListener;

        /// <summary>
        /// 群成员变动的监听
        /// </summary>
        /// <param name="listener"></param>
        public void SetUserChangeListener(Action<string, string, string> listener)
        {
            mUserlistener = listener;
        }

        /// <summary>
        /// 网页加载监听
        /// </summary>
        /// <param name="listener"></param>
        public void SetLoadListener(Action listener)
        {
            mLoadListener = listener;
        }

        #region 网页回调

        public void OnUserChanged(string tag, string avatarUrl, string name)
        {
            mUserlistener?.Invoke(tag, avatarUrl, name);
        }

        public void OnLoaded()
        {
            mLoadListener?.Invoke();
        }
        #endregion
    }

    public static string IntercaptUserId(string avatarUrl)
    {
        var name = FileUtils.GetFileName(avatarUrl);
        if (UIUtils.IsNull(name))
        {
            return "";
        }

        return name.Replace(FileUtils.GetFileExtension(avatarUrl), "");

    }
}
