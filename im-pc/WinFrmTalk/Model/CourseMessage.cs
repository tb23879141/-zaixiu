using Newtonsoft.Json;

using PBMessage;
using System;

namespace WinFrmTalk.Model
{
    class CourseMessage
    {
        public string courseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string courseMessageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }

        /// <summary>

        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string messageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }


        public MessageObject ToMessageObject()
        {
            try
            {
                string text = message.Replace("&quot;", "\"");

                var body = JsonConvert.DeserializeObject<ChatMessage>(text);

                var msg = ShiKuManager.mSocketCore.ToMessageObject(body);

                return msg;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
