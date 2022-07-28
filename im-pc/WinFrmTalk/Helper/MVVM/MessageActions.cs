public class MessageActions
{


    #region ��Ϣ״̬���
    /// <summary>
    /// �Ѷ���Ϣ���ͳɹ����Ѷ����ͷ����������ݿ�ԭ��Ϣ�Ѷ���־λ������δ�����UI ����  messageObject
    /// </summary>
    public const string XMPP_UPDATE_SEND_READ = "update_send_read";

    /// <summary>
    /// �յ��Է��Ѷ���Ϣ ���Ѷ����շ�������UI�Ѷ���־  ����  messageObject
    /// </summary>
    public const string XMPP_UPDATE_RECEIVED_READ = "update_received_read";
    /// <summary>
    /// ������
    /// </summary>
    public const string RED_UPDATE_COMMAND = "red_update_command";
    public const string RED_OPEN_COMMAND = "red_open_command";
    /// <summary>
    /// ����UI��Ϣ����ʧ�ܱ�־ ��Ϣ�ѷ���ʧ�� ���� messageObject
    /// </summary>
    public const string XMPP_UPDATE_SEND_FAILED = "update_message_failed";

    /// <summary>
    /// ����UI�ʹ��־ ��Ϣ�ѷ��ͳɹ� ���� messageObject
    /// </summary>
    public const string XMPP_UPDATE_SEND_SUCCESS = "update_message_success";
    #endregion

    #region ��Ϣ���
    /// <summary>
    /// ����UI �յ�һ���µ���ͨ��Ϣ ���� messageObject
    /// </summary>
    public const string XMPP_UPDATE_NORMAL_MESSAGE = "update_normal_message";

    /// <summary>
    /// ����UI �յ�һ����Ϣ���� messageObject
    /// </summary>
    public const string XMPP_UPDATE_RECALL_MESSAGE = "update_recall_message";

    /// <summary>
    /// ����UI �յ���һ��������֤��Ϣ messageObject
    /// </summary>
    public const string XMPP_UPDATE_VERIFY_MESSAGE = "update_verify_message";

    /// <summary>
    /// ����UI �յ���һ��������֤��ִ messageObject
    /// </summary>
    public const string XMPP_UPDATE_VERIFY_RECEPIT = nameof(XMPP_UPDATE_VERIFY_RECEPIT);

    /// <summary>
    /// ����UI �յ���һ��Ⱥ�������Ϣ messageObject
    /// </summary>
    public const string XMPP_UPDATE_ROOM_CHANGE_MESSAGE = "update_room_message";
    /// <summary>
    ///�յ�ֱ���������Ϣ
    /// </summary>
    public const string XMPP_UPDATE_lIVEROOMCTL_MESSAGE = "update_liveroomctl_message";
    /// <summary>
    /// ����UI �յ���һ������ƵЭ����Ϣ messageObject
    /// </summary>
    public const string XMPP_UPDATE_MEETING_MESSAGE = "update_meeting_message";

    /// <summary>
    /// ����UI �յ���һ������ƵЭ����Ϣ��ִ messageObject
    /// </summary>
    public const string XMPP_UPDATE_MEETING_RECEIPT = "update_meeting_receipt";
    /// <summary>
    /// ����UI �յ���һ���ͷ�Э����ϢmessageObject
    /// </summary>
    public const string XMPP_UPDATE_CUSTOMERSERVICE = "update_customerservice";

    /// <summary>
    /// ����UI �յ���һ���ͷ�Э����ϢmessageObject
    /// </summary>
    public const string XMPP_REFRESH_MESSAGE = "refresh_message_content";

    /// <summary>
    /// ����UI Ⱥ����Կ��ʧ״̬����
    /// </summary>
    public const string UPDATE_CHATKEY_STATE = "refresh_chatkey_state";

    /// <summary>
    /// ��̨����Ⱥ��
    /// </summary>
    public const string UPDATE_SERVICE_LOCK = "refresh_service_lock";


    public const string CLEAR_DRAG = "clear_drag";


    #endregion

    #region Ⱥ�����
    /// <summary>
    /// ����UI ���˳���ĳһ��Ⱥ��(�����뿪)messageObject
    /// </summary>
    public const string XMPP_UPDATE_ROOM_DELETE = "update_room_del";


    /// <summary>
    /// ����UI Xmpp״̬��� ����state��xmpp���ӣ��Ͽ����������ߵȣ�
    /// </summary>
    public const string XMPP_UPDATE_STATE = "update_xmpp_state";

    /// <summary>
    /// ����UI ���˳���ĳһ��Ⱥ��(�����뿪)messageObject
    /// </summary>
    public const string Room_UPDATE_ROOM_DELETE = "liuhuan_del_room_";

    /// <summary>
    /// ��Ӻ���
    /// </summary>
    public const string Room_UPDATE_ROOM_ADD = "liuhuan_add_room_";
    /// <summary>
    /// ɾ��Ⱥ����
    /// </summary>
    public const string Room_Deleate_ROOM_TIPS = "liuhuan_deleate_roomTips";
    /// <summary>
    /// ����       �ұ�����Ա������    Ⱥ��������ȫ������ ���� MessageObject
    /// </summary>
    public const string ROOM_UPDATE_BANNED_TALK = "ROOM_BANNED_TALK";


    /// <summary>
    /// ���룬�ұ����뵽һ���µ�Ⱥ��ˢ���б� ����meessageObject
    /// </summary>
    public const string ROOM_UPDATE_INVITE = "ROOM_UPDATE_INVITE";


    /// <summary>
    /// ������ص�@Ⱥ��Ա��Ϣ  ����Friend
    /// </summary>
    public const string ROOM_UPDATE_AT_ME = "ROOM_UPDATE_AT_ME";

    /// <summary>
    /// ����¼ͬ���ҵı�ǩ
    /// </summary>
    public const string UPDATE_DEVICE_LABLE = "update_friend_lable_deivce";



    /// <summary>
    /// Χ��Ⱥ
    /// </summary>
    public const string WATCH_GROUP = "WATCH_GROUP";

    /// <summary>
    /// ��תȺ
    /// </summary>
    public const string MAIN_JUMP_GROUP = "MAIN_JUMP_GROUP";
    #endregion

    #region �������
    /// <summary>
    /// ���º��ѱ�ע
    /// </summary>
    public const string UPDATE_FRIEND_REMARKS = "update_friend_remarks";
    /// <summary>
    /// ���º��ѱ�ע
    /// </summary>
    public const string UPDATE_FRIEND_REMARKSPHONE = "update_friend_remarkphone";
    /// <summary>
    /// ɾ������
    /// </summary>
    public const string DELETE_FRIEND = "delete_friend";


    /// <summary>
    /// ���������
    /// </summary>
    public const string ADD_BLACKLIST = "add_blacklist";

    /// <summary>
    /// ���һ�����ѵ������¼ ���� string: userid
    /// </summary>
    public const string CLEAR_FRIEND_MSGS = "clear_friend_msgs";

    /// <summary>
    /// ����һ�����ѵ����һ�������¼ ���� Friend
    /// </summary>
    public const string UPDATE_FRIEND_LAST_CONTENT = "update_friend_last_content";


    // Ȧ��
    public const string ShowGroupSocial = "ShowGroupSocial";
    // ��Դ
    public const string ShowGroupResource = "ShowGroupResource";
    public const string ShowGroupActive = "ShowGroupActive";
    public const string ShowGroupNotify = "ShowGroupNotify";


    /// <summary>
    /// ����������
    /// </summary>
    public const string SearchEventRecent = "SearchEventRecent";
    public const string SearchEventFriend = "SearchEventFriend";
    public const string SearchEventGroups = "SearchEventGroups";
    public const string SearchEventSquare = "SearchEventSquare";
    public const string SearchEventCollec = "SearchEventCollec";
    public const string SearchEventLabels = "SearchEventLabels";

    /// <summary>
    /// �������˵�
    /// </summary>
    public const string MenuEventRecent = "MenuEventRecent";
    public const string MenuEventFriend = "MenuEventFriend";
    public const string MenuEventGroups = "MenuEventGroups";
    public const string MenuEventSquare = "MenuEventSquare";
    public const string MenuEventCollec = "MenuEventCollec";
    public const string MenuEventLabels = "MenuEventLabels";

    /// <summary>
    /// Ⱥ�������޸�
    /// </summary>
    public const string XMPP_COMPANY_NAME_CHANGE_MESSAGE = "XMPP_COMPANY_NAME_CHANGE_MESSAGE";
    #endregion



    #region �б����

    /// <summary>
    /// ��ʾһ����Ϣ(�������Ϣ�б�)
    /// </summary>
    public const string XMPP_SHOW_SINGLE_MESSAGE = "show_single_message";

    /// <summary>
    /// �յ�������Ϣ��һ����ˢ��(�������Ϣ�б�)
    /// </summary>
    public const string XMPP_SHOW_ALL_MESSAGE = "show_all_message";

    /// <summary>
    /// ����������Ϣ�ö�
    /// </summary>
    public const string UPDATE_FRIEND_TOP = "friend_message_top";


    /// <summary>
    /// ����������Ϣ�����
    /// </summary>
    public const string UPDATE_FRIEND_DISTURB = "friend_message_disturb";

    /// <summary>
    /// ����������Ϣ�ĺ󼴷�
    /// </summary>
    public const string UPDATE_FRIEND_READDEL = "friend_message_readdel";
    /// <summary>
    /// �����Ϣ�б��������
    /// </summary>
    public const string DOWN_CHATLIST_COMPT = "down_chats_compte";

    /// <summary>
    /// ������������¼-ˢ���б�
    /// </summary>
    public const string UPDATE_CHATLIST_CLEAR_FRIEND = "update_chatlist_clear_friend";


    /// <summary>
    /// ����Ⱥ��״̬
    /// </summary>
    public const string UPDATE_GROUP_STATE = "update_group_state";
    #endregion


    #region ����¼
    /// <summary>
    /// ����¼����������Ϣ
    /// </summary>
    public const string UPDATE_DEVICE_STATE = "update_device_state";
    internal const string FILE_DOWN_COMPT = "FILE_DOWN_COMPT";

    #endregion

    #region ˢ��ͷ��
    public const string UPDATE_HEAD = "update_head";
    #endregion
    #region ˢ��ͷ��
    public const string TXTMSG_REEDIT = "txtmsg_reedit";
    #endregion
    #region ˢ������
    public const string UPDATE_CONFIG = "update_config";
    public const string SHOW_LOGINFORM = "show_login_form";
    public const string UPDATE_COLLECT_LIST = "update_collect_list";
    public const string UPDATE_COURSE_LIST = "update_course_list";  // �����ҵĽ���
    public const string UPDATE_LABLE_LIST = "update_lable_list";// 
    public const string RESTART_APP = "restart_app";// ��������
    public const string CLOSE_NOTIFY_INCO = "close_notifyinco";// �ر�������ͼ��
    public const string OPEN_WAIT_DELAY_COMPTE = "open_wait_delay_compte";
    public const string uimsg_imgfolder_doubleclick = "uimsg_imgfolder_doubleclick";
    public const string groupmsg_wg = "groupmsg_wg";


    #endregion
}
