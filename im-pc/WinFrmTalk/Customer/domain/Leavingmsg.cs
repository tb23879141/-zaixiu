using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Customer
{
    /// <summary>
    /// 留言实体类
    /// </summary>
    public class Leavingmsg
    {
        /// <summary>
        /// 留言编号
        /// </summary>
        public string MsgNumber { get; set; }

        /// <summary>
        /// 发送人名字
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 发送人手机
        /// </summary>
        public string SenderPhone { get; set; }


        /// <summary>
        /// 发送人邮箱
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// 渠道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 状态
        /// <para>-1：未分配，0：未处理，1：已解决</para>
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 分配
        /// </summary>
        public string Allocation { get; set; }

        /// <summary>
        /// 客服的回复内容（JSON集合）
        /// </summary>
        public string ReplyMsgs { get; set; }
    }
}
