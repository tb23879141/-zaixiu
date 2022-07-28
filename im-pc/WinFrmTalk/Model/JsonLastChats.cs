using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFrmTalk.Model;

namespace WinFrmTalk
{
    public class JsonLastChats
    {
        /// <summary>
        /// 
        /// </summary>
        public long currentTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int resultCode { get; set; }
    }



    public class DataItem
    {
        public string jid { get; set; }
        public int type { get; set; }
        public string messageId { get; set; }
        public long timeSend { get; set; }
        public string content { get; set; }
        public string userId { get; set; }
        public int isRoom { get; set; }
        public bool isEncrypt { get; set; }

        public int encryptType { get; set; }

        public string from { get; set; }
        public string fromUserName { get; set; }
        public string to { get; set; }
        public string toUserName { get; set; }


        //public void UpdateRange()
        //{

            //friend.IsGroup = this.isRoom;
            //friend.LastMsgTime = (int)this.timeSend;
            //friend.Content = this.content;
            //friend.UserId = isRoom == 1 ? jid : userId;
            //friend.LastMsgType = type;

        //    //result = DBSetting.SQLiteDBContext.Updateable(kkc).ExecuteCommand();

        //}
    }





}