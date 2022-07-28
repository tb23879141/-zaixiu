﻿using System;
using System.Collections.Generic;

namespace WinFrmTalk
{
    #region 配置
    public class ConfigData
    {
        /// <summary>
        /// 
        /// </summary>
        public string XMPPDomain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string XMPPHost { get; set; }

        /// <summary>
        /// Xmpp超时时间
        /// </summary>
        public int XMPPTimeout { get; set; }

        /// <summary>
        /// Xmpp心跳包间隔
        /// </summary>
        public int xmppPingTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string androidAppUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string androidExplain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int androidVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string apiUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string audioLen { get; set; }

        public string website { get; set; }

        /// <summary>
        /// 是否开启红包
        /// </summary>
        public int displayRedPacket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int distance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string downloadAvatarUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string downloadUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string freeswitch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string helpUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iosAppUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iosExplain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int iosVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string liveUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string meetingHost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shareUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string softUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uploadUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string videoLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xMPPDomain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xMPPHost { get; set; }

        /// <summary>
        /// Jisti服务器
        /// </summary>
        public string jitsiServer { get; set; }
        /// <summary>
        /// pc下载地址
        /// </summary>
        public string pcAppUrl { get; set; }
        /// <summary>
        /// pc下载地址
        /// </summary>
        public string pcZipUrl { get; set; }
        public string pcDisable { get; set; }
        public string pcExplain { get; set; }
        /// <summary>
        /// pc版本号
        /// </summary>
        public string pcVersion { get; set; }
        /// <summary>
        /// 用户名是否为用户名或手机号注册 0：使用手机号注册，1：使用用户名注册
        /// </summary>
        public int regeditPhoneOrName { get; set; }
        /// <summary>
        /// 注册邀请码
        /// </summary>
        public int registerInviteCode { get; set; }
        /// <summary>
        /// 是否开启位置相关服务 0：开启，1：关闭
        /// </summary>
        public int isOpenPositionService { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string companyName { get; set; }
        /// <summary>
        /// 版权所有
        /// </summary>
        public string copyright { get; set; }

        /// <summary>
        /// 当前电脑IP地址
        /// </summary>
        public string ipAddress { get; set; }
        /// <summary>
        /// 是否开启短信验证码,0 关闭 1开启
        /// </summary>
        public int isOpenSMSCode { get; set; }

        /// <summary>
        /// 是否开启群组搜索功能,0开启1关闭
        /// </summary>
        public int isOpenRoomSearch { get; set; }

        /// <summary>
        /// 是否开启在线状态
        /// </summary>
        public int isOpenOnlineStatus { get; set; }

        /// <summary>
        /// 是否开启端到端加密
        /// </summary>
        public int isOpenSecureChat { get; set; }

        /// <summary>
        /// 是否开启公众号
        /// </summary>
        public int enableMpModule { get; set; }
        /// <summary>
        /// 是否开启注册
        /// </summary>
        public int isOpenRegister { get; set; }

        /// <summary>
        /// 好友关系
        /// </summary>
        public Dictionary<string, int> friendStatus { get; set; }

        /// <summary>
        /// 个人申请直播转账账户
        /// </summary>
        public string bandCard { get; set; }

        /// <summary>
        /// 协议
        /// </summary>
        public Privacy privacy { get; set; }
    }
    public class Privacy
    {
        /// <summary>
        /// 隐私条例
        /// </summary>
        public string privacy { get; set; }
        /// <summary>
        /// 用户协议
        /// </summary>
        public string agreement { get; set; }
        /// <summary>
        /// 直播协议
        /// </summary>
        public string liveAgreement { get; set; }
        /// <summary>
        /// 充值协议
        /// </summary>
        public string rechargeDamindAgreement { get; set; }
    }

    #endregion

    /// <summary>
    /// 配置信息
    /// </summary>
    public class JsonConfigData : JsonBase
    {
        #region 配置文件
        public JsonConfigData()
        {
            data = new ConfigData();
        }
        #endregion

        /// <summary>
        /// 配置
        /// </summary>
        public ConfigData data { get; set; }
    }
}

