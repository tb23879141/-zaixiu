using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrmTalk.Model
{
    public class LiveModel
    {
        public string PcIcon { get; set; }

        public string Name { get; set; }

        public string PcUrl { get; set; }

        public string PcStatus { get; set; }
    }
    public class LiveCardBean
    {
        /// <summary>
        /// 
        /// </summary>
        public double createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int currentState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// qqqw@一颗丸子酱 邀你成为抖音好友；复制这条信息 ##t5Ak6j7w700## 打开【抖音】
        /// </summary>
        public string notice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int numbers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roomId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 是否打开该直播窗
        /// </summary>
        public bool isOpen { get; set; }
        /// <summary>
        /// 直播的群组Id（群内直播）
        /// </summary>
        public string liveRoomId { get; set; }

        /// <summary>
        /// 清除直播间开启后无用的数据，只留下关键数据
        /// </summary>
        public void ClearLiveData()
        {
            //numbers = 0;
            isOpen = false;
        }

        /// <summary>
        ///1 分享  2 娱乐
        /// </summary>
        public string roomType { get; set; } = "1";
    }
    public class LiveApplyModel
    {
        public string userId { get; set; }

        public double createTime { get; set; }

        public double modifyTime { get; set; }
        /// <summary>
        /// 申请直播信息ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        ///直播类型 1 个人申请   2 企业申请
        /// </summary>
        public string type { get; set; } = "1";
        /// <summary>
        /// 名字或企业名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 身份证号或营业执照号
        /// </summary>
        public string idCardLincence { get; set; }
        /// <summary>
        /// 银行卡号或者企业公账号
        /// </summary>
        public string bandCard { get; set; }

        public string rejectContent { get; set; }

        /// <summary>
        /// 个人或者法人身份证正面
        /// </summary>
        public string upCardUrl { get; set; }
        /// <summary>
        /// 个人或者法人身份证反面
        /// </summary>
        public string downCardUrl { get; set; }
        /// <summary>
        /// 直播描述或者企业直播内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 手机号或者企业邮箱
        /// </summary>
        public string phoneEmail { get; set; }
        /// <summary>
        /// 打款记录截图或企业营业执照照片
        /// </summary>
        public string screenLicence { get; set; }
        /// <summary>
        /// 粉丝数量截图
        /// </summary>
        public string screenfans { get; set; }
        /// <summary>
        /// 打款金额，前端随机生成一个指定区间的  个人申请
        /// </summary>
        public string money { get; set; }
        /// <summary>
        /// 开户名  企业申请
        /// </summary>
        public string openName { get; set; }
        /// <summary>
        /// 司开户行支行  企业申请
        /// </summary>
        public string openBank { get; set; }
        /// <summary>
        /// 银行地址  企业申请
        /// </summary>
        public string bankLoc { get; set; }
        /// <summary>
        ///1 分享  2 娱乐
        /// </summary>
        public string roomType { get; set; } = "1";
        /// <summary>
        /// 申请状态 -1未申请 0刚申请  1通过  2驳回
        /// </summary>
        public string status { get; set; }
    }
}
