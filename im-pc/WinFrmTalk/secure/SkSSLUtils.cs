using System;
using WinFrmTalk;
using WinFrmTalk.Model;

/// <summary>
/// 非端到端版本 视酷加解密类
/// 2019-12-10 15:01:32
/// </summary>
public class SkSSLUtils
{
    public const bool encrypt_chat = false;

    #region xmpp 消息加密

    /// <summary>
    /// 消息加密——专用于xmpp 发消息
    /// </summary>
    public static void EncryptMessage(Friend friend, MessageObject message)
    {
        if (friend == null)
        {
            message.isEncrypt = 0;
            return;
        }

        if (friend.IsEncrypt == 0)
        {
            if (friend.IsGroup == 1 && !UIUtils.IsNull(friend.ChatKeyGroup) && friend.IsLostKeyGroup == 0)
            {
                friend.IsEncrypt = 3;
            }
            else
            {
                message.isEncrypt = 0;
                return;
            }
        }

        if (friend.IsEncrypt == 1)
        {
            // old 3des
            EncryptMessage_3DES(message);
            return;
        }
        else if (friend.IsEncrypt == 2)
        {
            // aes
            EncryptMessage_AES(message);
            return;
        }
        else if (friend.IsEncrypt == 3)
        {
            if (friend.IsGroup == 1)
            {
                // 群聊消息dh加密
                GroupEncryptMessage(message, friend);
            }
            else
            {
                // 单聊消息dh加密
                SingleEncryptMessage(message, friend);
            }
        }
    }


    /// <summary>
    /// 群聊消息加密  dh
    /// </summary>
    public static void GroupEncryptMessage(MessageObject message, Friend friend)
    {
        EncryptMessage_3DES(message);
    }


    /// <summary>
    /// 单聊dh消息加密
    /// </summary>
    private static void SingleEncryptMessage(MessageObject message, Friend friend)
    {
        EncryptMessage_3DES(message);
    }


    /// <summary>
    /// aes消息加密
    /// </summary>
    public static void EncryptMessage_AES(MessageObject message)
    {
        EncryptMessage_3DES(message);
    }


    /// <summary>
    /// 3des消息加密
    /// 的这个方法需要把timesend * 1000
    /// </summary>
    public static void EncryptMessage_3DES(MessageObject message)
    {
        long timeSend = Convert.ToInt64(message.timeSend * 1000);
        var data = DES.EncryptMessage(message.content, timeSend, message.messageId, Applicate.API_KEY);

        if (!UIUtils.IsNull(data))
        {
            message.content = data;
            message.isEncrypt = 1;
        }
    }

    #endregion

    #region 课程消息解密
    /// <summary>
    /// 讲课消息解密
    /// </summary>
    /// <param name="message"></param>
    /// <param name="isGroup"></param>
    public static void DecryptRecordMessage(MessageObject message, bool isGroup)
    {
        if (message.isEncrypt == 1)
        {
            DecryptMessage_3DES(message);
        }
        else if (message.isEncrypt == 2)
        {
            DecryptMessage_AES(message);
        }
        else if (message.isEncrypt == 3)
        {
            // 取出好友
            var friend = message.GetFriend();
            if (isGroup)
            {
                // 群聊dh解密
                if (friend != null && !UIUtils.IsNull(friend.ChatKeyGroup))
                {
                    // 算出群组对称密钥
                    string key = GetGroupChatkey(message.ChatJid, friend.ChatKeyGroup);
                    DecryptMessage_DH1(message, key);
                }
            }
            else
            {
                // 单聊解密
                if (friend != null && !UIUtils.IsNull(friend.DhPublicKey))
                {
                    // 算出朋友对称密钥
                    string key = GetSingleChatkey(friend.DhPublicKey);
                    DecryptMessage_DH1(message, key);
                }
            }
        }
    }


    #endregion

    #region 消息列表最后一条消息解密
    /// <summary>
    /// 专用于最后一条消息内容解密
    /// </summary>
    /// <param name="message"></param>
    /// <param name="isGroup"></param>
    public static string DecryptLastMessage(DataItem lastMessage)
    {
        // 兼容老版本
        if (lastMessage.isEncrypt && lastMessage.encryptType == 0)
        {
            lastMessage.encryptType = 1;
        }

        if (lastMessage.encryptType == 1)
        {
            long timeSend = lastMessage.timeSend;
            var content = DES.DecryptMessage(lastMessage.content, timeSend, lastMessage.messageId, Applicate.API_KEY);
            if (!UIUtils.IsNull(content))
            {
                return content;
            }
            else
            {
                return lastMessage.content;
            }
        }
        else if (lastMessage.encryptType == 2)
        {
            return "非端到端版本,不支持显示aes加密消息";
        }
        else if (lastMessage.encryptType == 3)
        {
            return "非端到端版本,不支持显示aes加密消息";
        }

        return lastMessage.content;
    }

    #endregion

    #region XMPP接收消息解密

    /// <summary>
    /// 消息解密- 专用于xmpp
    /// </summary>
    public static void DecryptXmppMessage(MessageObject message, bool isGroup)
    {
        if (message.isEncrypt == 1)
        {
            DecryptMessage_3DES(message);
        }
        else if (message.isEncrypt == 2)
        {
            DecryptMessage_AES(message);
        }
        else if (message.isEncrypt == 3)
        {
            if (isGroup)
            {
                // 群聊dh解密
                GroupDecryptMessage(message);
            }
            else
            {
                // 单聊消息dh解密
                SingleDecryptMessage(message);
            }
        }
    }


    /// <summary>
    /// 群聊消息解密 dh
    /// </summary>
    private static void GroupDecryptMessage(MessageObject message)
    {
        message.type = kWCMessageType.Text;
        message.content = "非端到端版本，不支持显示端到端加密消息";
        message.isEncrypt = 0;

    }


    /// <summary>
    /// 单聊dh消息解密
    /// </summary>
    private static void SingleDecryptMessage(MessageObject message)
    {
        message.type = kWCMessageType.Text;
        message.content = "非端到端版本，不支持显示端到端加密消息";
        message.isEncrypt = 0;
    }

    #endregion

    #region 获取密钥后解密本地未解密的消息

    /// <summary>
    /// 专用于别人给我发送密钥成功后，解密本地以前未解密成功的消息
    /// </summary>
    /// <param name="dhPublicKey"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static bool DHDecryptFailMessage(string chatKeyGroup, MessageObject message)
    {
        message.type = kWCMessageType.Text;
        message.content = "非端到端版本，不支持显示端到端加密消息";
        message.isEncrypt = 0;

        return true;
    }

    #endregion

    #region 消息解密

    /// <summary>
    /// dh消息解密
    /// </summary>
    public static void DecryptMessage_DH1(MessageObject message, string key)
    {
        message.type = kWCMessageType.Text;
        message.content = "非端到端版本，不支持显示端到端加密消息";
        message.isEncrypt = 0;
    }

    /// <summary>
    /// aes消息解密
    /// </summary>
    public static void DecryptMessage_AES(MessageObject message)
    {
        message.type = kWCMessageType.Text;
        message.content = "非端到端版本，不支持显示端到端加密消息";
        message.isEncrypt = 0;
    }


    /// <summary>
    /// 3des消息解密
    /// </summary>
    public static void DecryptMessage_3DES(MessageObject message)
    {

        long timeSend = (long)(message.timeSend * 1000);
        var data = DES.DecryptMessage(message.content, timeSend, message.messageId, Applicate.API_KEY);
        if (!UIUtils.IsNull(data))
        {
            message.content = data;
            message.isEncrypt = 0;
        }
        else
        {
            message.IsDecryptFail = 1;
        }
    }

    #endregion

    //------------------------------------解密帮助  

    /// <summary>
    /// 修改密码&忘记密码验参
    /// </summary>
    /// <param name="password"></param>
    /// <param name="authCode">修改密码时 authCode == 验证码，， 忘记密码时authCode == 明文手机号  </param>
    /// <returns></returns>
    public static string SignatureUpdateKeys(string password, string authCode)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(authCode))
        {
            return "";
        }

        string hex = SecureChatUtil.CiphertextPwd(password);
        byte[] bytesAES = AES.Encrypt(RSA.ToByte(Applicate.API_KEY), Convert.FromBase64String(hex));
        return MAC.EncodeBase64(bytesAES, authCode);
    }

    public static string GetSingleChatkey(string dhPublicKey)
    {
        return string.Empty;
    }

    public static string GetGroupChatkey(string roomJid, string chatKeyGroup)
    {
        return string.Empty;
    }


    public class KeyBen
    {
        public string key;
        public long time;
    }
}
