using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Model
{
    class MessageCourseModel
    {
        /// <summary>
        /// 
        /// </summary>
        //public object body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int direction { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sender_jid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string receiver_jid { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public long ts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string messageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double timeSend { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public long sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public long receiver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }
    }
}
