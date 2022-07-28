using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFrmTalk;
using WinFrmTalk.Model;
using WinFrmTalk.Properties;

public class ImageLoader2
{

    // 单例模式 
    private ImageLoader2()
    {
        mConfig = new ImageLoadConfig();
    }

    private static ImageLoader2 _instance;
    public static ImageLoader2 Instance => _instance ?? (_instance = new ImageLoader2());


    private ImageLoadConfig mConfig;

    public ImageRequstBuild Load(string url)
    {
        ImageRequstBuild build = new ImageRequstBuild(mConfig);
        build.LoadUrl(url);
        return build;
    }

    public GroupAppendBuild Load(List<string> urls)
    {
        GroupAppendBuild build = new GroupAppendBuild(urls);
        return build;
    }


    internal void DisplayAvatar(string userId, Action<Bitmap> compte, bool isThumb = false, string drawText = "")
    {
        if (UIUtils.IsNull(userId))
        {
            // 加载默认头像
            compte?.Invoke(Resources.avatar_default);
            return;
        }

        if (IsOtherHead(userId, compte))
        {
            return;
        }


        int userIdInt = -1;
        try
        {
            userIdInt = int.Parse(userId);
        }
        catch (Exception)
        {
            // 加载默认头像 可能是群组
            compte?.Invoke(Resources.avatar_group);
        }

        if (userIdInt == -1 || userIdInt == 0)
        {
            // 加载默认头像// 加载默认头像
            compte?.Invoke(Resources.avatar_default);
            return;
        }

        int dirName = userIdInt % 10000;

        string url = null;
        if (isThumb)
        {
            url = Applicate.URLDATA.data.downloadAvatarUrl + "avatar/t/" + dirName + "/" + userId + ".jpg";
        }
        else
        {
            url = Applicate.URLDATA.data.downloadAvatarUrl + "avatar/o/" + dirName + "/" + userId + ".jpg";
        }

        PictureBox box = null;
        Load(url).Error(Resources.avatar_default).Error(drawText).Avatar().Gray().CompteListener(compte).Into(box);
    }


    internal bool IsOtherHead(string userId, Action<Bitmap> compte)
    {
        Bitmap image = null;
        if (Friend.ID_SYSTEM.Equals(userId))
        {
            // 系统号
            image = Resources.avatar_notice;
        }

        if (Friend.ID_NEW_FRIEND.Equals(userId))
        {
            // 新的朋友头像
            image = Resources.avatar_newfriends;
        }

        if (Friend.ID_PUBLIC_LIST.Equals(userId))
        {
            // 新的朋友头像
            image = Resources.avatar_notice;
        }


        if (Friend.ID_BAN_LIST.Equals(userId))
        {
            // 黑名单的头像            
            image = Resources.ic_head_black;
        }


        if ("android".Equals(userId))
        {
            // android手机
            image = Resources.ic_head_android;
        }

        if ("ios".Equals(userId))
        {
            // ios手机
            image = Resources.ic_head_phone;
        }
        if ("mac".Equals(userId) || "web".Equals(userId))
        {
            // 电脑
            image = Resources.ic_head_pc;
        }


        if (userId.Length > 8)
        {
            return true;
        }

        if (!BitmapUtils.IsNull(image))
        {
            compte?.Invoke(image);
            return true;
        }

        return false;
    }


    internal void DisplayGroupAvatar(string roomJid, string roomId, Action<Bitmap> compte = null)
    {
        int roomJidCode = UIUtils.HashCode(roomJid);
        int a = Math.Abs(roomJidCode % 10000);
        int b = Math.Abs(roomJidCode % 20000);

        string roomUrl = Applicate.URLDATA.data.downloadAvatarUrl + "avatar/o/" + a + "/" + b + "/" + roomJid + ".jpg";

        Load(roomUrl).Error((str) =>
        {
            AppendRoomHead(roomId, compte);

        }).Into((bit, path) =>
        {
            compte?.Invoke(bit);
        });
    }


    private void AppendRoomHead(string roomId, Action<Bitmap> compte = null)
    {

        RoomMember roomMember = new RoomMember() { roomId = roomId };
        List<RoomMember> menbers = roomMember.GetRommMemberListByHead();

        if (menbers == null || menbers.Count < 2)
        {
            // 加载群头像
            Bitmap bitmap = Resources.avatar_group;
            compte?.Invoke(bitmap);
        }
        else
        {
            List<string> urls = new List<string>();

            int count = Math.Min(menbers.Count, 5);
            for (int i = 0; i < count; i++)
            {
                urls.Add(GetHeadUrl(menbers[i].userId));
            }

            Load(urls).CompteListener(compte).Into(null);
        }
    }


    internal void SetAppConfig(ImageLoadConfig loadConfig)
    {
        mConfig = loadConfig;
        ImageCacheManager.Instance.SetMaxCount(loadConfig.maxCount);
    }

    public string GetHeadUrl(string userId, bool isThumb = true)
    {
        if (string.IsNullOrEmpty(userId) || userId.Length > 8)
        {
            // 加载默认头像
            return "";
        }

        int userIdInt = -1;
        try
        {
            userIdInt = int.Parse(userId);
        }
        catch (Exception)
        {
            // 加载默认头像
            //可能是群组
        }

        if (userIdInt == -1 || userIdInt == 0)
        {
            // 加载默认头像
            return "";
        }

        int dirName = userIdInt % 10000;

        string url = null;

        if (isThumb)
        {
            url = Applicate.URLDATA.data.downloadAvatarUrl + "avatar/t/" + dirName + "/" + userId + ".jpg";
        }
        else
        {
            url = Applicate.URLDATA.data.downloadAvatarUrl + "avatar/o/" + dirName + "/" + userId + ".jpg";
        }

        //LogUtils.Log("头像地址" + url);

        return url;
    }

}
