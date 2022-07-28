using System.Timers;
using WinFrmTalk.Model;

namespace WinFrmTalk
{
    /// <summary>
    /// �ط���Ϣר��Timer
    /// </summary>
    public class MessageTimer : Timer
    {
        #region �޲ι��캯��
        /// <summary>
        /// �޲ι��캯��
        /// </summary>
        public MessageTimer() : base()
        {
            this.Interval = 2000;//Ĭ��Ϊ20�뷢��ʱ��
            ReSendCount = 0;
        }
        #endregion

        #region ���캯��
        /// <summary>
        /// ��������Interval�Ĺ��캯��
        /// </summary>
        public MessageTimer(double interval) : base(interval)
        {
            ReSendCount = 0;
        }
        #endregion

        /// <summary>
        /// Xmpp��Ϣ
        /// </summary>
        public MessageObject TmpMsg { get; set; }

        /// <summary>
        /// ��Ӧ��MessageId
        /// </summary>
        public string MessageId { get; set; } = "";

        /// <summary>
        /// �ط�����
        /// </summary>
        public int ReSendCount { get; set; }

    }
}
