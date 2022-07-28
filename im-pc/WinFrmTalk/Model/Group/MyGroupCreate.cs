//如果好用，请收藏地址，帮忙分享。
using System.Collections.Generic;

public class MyGroupCreate_Businessinfo
{
    /// <summary>
    /// 
    /// </summary>
    public string address { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > businessPicture { get; set; }
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

public class MyGroupCreate_InviteUsersItem
{
    /// <summary>
    /// 
    /// </summary>
    public double MyGroupCreate_InviteTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double MyGroupCreate_InviteUserId { get; set; }
}

public class MyGroupCreate_Invite
{
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <MyGroupCreate_InviteUsersItem > MyGroupCreate_InviteUsers { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string jid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double userId { get; set; }
}

public class MyGroupCreate_Member
{
    /// <summary>
    /// 
    /// </summary>
    public string account { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double active { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double beginMsgTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string call { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string chatKeyGroup { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double createTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double followStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string fromRoomId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string fromRoomName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MyGroupCreate_Invite MyGroupCreate_Invite { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ipAddress { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string isOpenTopChat { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double loginTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double modifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double offlineNoPushMsg { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double onlinestate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double openTopChatTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string remarkName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double role { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roomId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double sub { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double talkTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double userId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string videoMeetingNo { get; set; }
}

public class MyGroupCreate_MembersItem
{
}

public class MyGroupCreate_ForwardInfoListItem
{
    /// <summary>
    /// 
    /// </summary>
    public string forwardRoomId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double isDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roomJid { get; set; }
}

public class MyGroupCreate_Notice
{
    /// <summary>
    /// 
    /// </summary>
    public string forward { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string forwardId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <MyGroupCreate_ForwardInfoListItem > forwardInfoList { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double isMyGroupCreate_MemberDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double isPublic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double isWatchDownload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double modifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nickname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <string > picPath { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roomId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double time { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double userId { get; set; }
}

public class MyGroupCreate_NoticesItem
{
}

public class MyGroupCreate_OfficialGroupId
{
    /// <summary>
    /// 
    /// </summary>
    public double counter { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string date { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double machineIdentifier { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double processIdentifier { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double time { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double timeSecond { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double timestamp { get; set; }
}

public class QuestionsItem
{
    /// <summary>
    /// 
    /// </summary>
    public string answer { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string question { get; set; }
}

public class MyGroupCreate
{
    /// <summary>
    /// 
    /// </summary>
    public string allowConference { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowHostUpdate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowMyGroupCreate_InviteFriend { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowOpenLive { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowSendCard { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowSpeakCourse { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string allowUploadFile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double allowWalkieTalkie { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double areaId { get; set; }
  
    /// <summary>
    /// 
    /// </summary>
    public string call { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double category { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double chargeMoney { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double chargeOrNot { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double chargeUser { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double chatRecordTimeOut { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double cityId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double communityType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double countStorage { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double countryId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double createTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double customer { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string desc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string disabledPic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double disabledTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string disabledUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string encryptType { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double endTime { get; set; }
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
    public double inside { get; set; }
 
    /// <summary>
    /// 
    /// </summary>
    public string isLook { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string isNeedVerify { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string isSecretGroup { get; set; }
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
    public string labelName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double latitude { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string liveStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double liveUserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string liveUserName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string localRoomKey { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string logo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double longitude { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double maxOfficialGroupUserSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double maxStorageSpace { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double maxUserSize { get; set; }
 
    /// <summary>
    /// 
    /// </summary>
    public double modifier { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double modifyTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double moveStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string nickname { get; set; }
 
    /// <summary>
    /// 
    /// </summary>
    public string parentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string promotionUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double provinceId { get; set; }
   
    /// <summary>
    /// 
    /// </summary>
    public double reportSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double reportingTaboo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roomTitleUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string s { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string shopId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string showMyGroupCreate_Member { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string showRead { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double storageSpace { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string subject { get; set; }
  
    /// <summary>
    /// 
    /// </summary>
    public double talkTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double userId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double userSize { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string videoMeetingNo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double watchTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double withdrawTime { get; set; }
}

 