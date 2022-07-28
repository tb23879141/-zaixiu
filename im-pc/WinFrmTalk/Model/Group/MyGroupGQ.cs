using System;
using System.Collections.Generic;
using WinFrmTalk.Model;



//如果好用，请收藏地址，帮忙分享。
public class MyGroupGQ_Businessinfo
{
    /// <summary>
    /// 
    /// </summary>
    public string address { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> businessPicture { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string businessScope { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string capital { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string companyType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string credit { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string establishDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string expirationDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ifCreditValid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
}

public class MyGroupGQ_MembersItem
{
    /// <summary>
    /// 
    /// </summary>
    public long active { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long beginMsgTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long createTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long followStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isOpenTopChat { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long loginTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long modifyTime { get; set; }
    /// <summary>
    /// 测试账号3
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long offlineNoPushMsg { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long onlinestate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long openTopChatTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long role { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long sub { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long talkTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userId { get; set; }
}

public class MyGroupGQ_Notice
{
    /// <summary>
    /// 
    /// </summary>
    public string forward { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isMemberDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isPublic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isWatchDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long modifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long time { get; set; }
}

public class MyGroupGQModel
{
    /// <summary>
    /// 
    /// </summary>
    public int allowConference { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowHostUpdate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowInviteFriend { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowOpenLive { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowSendCard { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowSpeakCourse { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowUploadFile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int allowWalkieTalkie { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MyGroupGQ_Businessinfo businessinfo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long chargeOrNot { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long chargeUser { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long chatRecordTimeOut { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long communityId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long communityType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long control { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long countStorage { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long createTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long customer { get; set; }
    /// <summary>
    /// 动态
    /// </summary>
    public string desc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string disabledPic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long disabledTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string disabledUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long encryptType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string groupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long inside { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isAttritionNotice { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int isLook { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int isNeedVerify { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long isSecretGroup { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string jid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string joined { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long latitude { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long liveStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long longitude { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long maxOfficialGroupUserSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long maxStorageSpace { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long maxUserSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long modifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long moveStatus { get; set; }
    /// <summary>
    /// 到了
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 测试账号3
    /// </summary>
    public string nickname { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string officialGroupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long reportSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long reportingTaboo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long s { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int showMember { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int showRead { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long storageSpace { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string subject { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public long talkTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long userSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long watchTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long withdrawTime { get; set; }

    public int movingState { get; set; }
    public long endTime { get; set; }
    public Member member { get; set; }

    public Friend ToRoom(bool mem = true)
    {
        Friend friend = new Friend();
        friend.UserId = this.jid;
        friend.ShowRead = this.showRead;
        friend.AllowUploadFile = this.allowUploadFile;//允许普通群成员上传文件
        friend.AllowSpeakCourse = this.allowSpeakCourse;//允许普通群成员发起讲课
        friend.AllowConference = this.allowSpeakCourse;
        friend.AllowConference = this.allowConference;//允许普通群成员召开会议
        friend.AllowInviteFriend = this.allowInviteFriend;//允许普通群成员邀请好友
        friend.ShowMember = this.showMember;
        friend.AllowSendCard = this.allowSendCard;//允许普通群成员私聊

        // this.talkTime > 0 开启了全体禁言，本地朋友表丢失此字段
        friend.CreateTime = (int)this.createTime;
        if (type == 2)
        {
            if (businessinfo != null)
            {
                friend.NickName = businessinfo.name;
            }
            else
            {
                friend.NickName = this.name;
            }
        }
        else
        {
            friend.NickName = this.name;
        }

        friend.RoomId = id;
        friend.Status = 2;
        friend.IsGroup = 1;
        friend.Description = this.desc;
        friend.IsNeedVerify = this.isNeedVerify;
        //  0普通群；2官方群；3商城群；4临时群；5个人粉丝群；11官方群1级主群；12官方群二级分群；13官方群三级之群；13官方群四级子群...
        friend.GroupType = this.type;
        friend.deleteTime = this.endTime;
        friend.movingState = this.movingState;
        friend.OfficialGroupId = this.officialGroupId;

        friend.Role = this.member == null ? "-1" : "0";
        if (mem)
        {
            if (member != null)
            {
                friend.Nodisturb = member.offlineNoPushMsg;
                friend.TopTime = member.openTopChatTime;

                friend.Role = Convert.ToString(this.member.role);
            }
        }
        return friend;

    }
}


