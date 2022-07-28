using CCWin.SkinControl;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFrmTalk.Dictionarys
{
    public class KWTypeMenuStripDictionary
    {
        private static Dictionary<kWCMessageType, MenuStripVisible> kwTypeMenuStrip = new Dictionary<kWCMessageType, MenuStripVisible>();

        private void AddDictionary()
        {
            kwTypeMenuStrip.Add(kWCMessageType.Image, new MenuStripVisibleImage());
            kwTypeMenuStrip.Add(kWCMessageType.Text, new MenuStripVisibleText());
            kwTypeMenuStrip.Add(kWCMessageType.Voice, new MenuStripVisibleVoice());
            kwTypeMenuStrip.Add(kWCMessageType.Video, new MenuStripVisibleVideo());
            kwTypeMenuStrip.Add(kWCMessageType.File, new MenuStripVisibleFile());
            kwTypeMenuStrip.Add(kWCMessageType.Location, new MenuStripVisibleLocation());
            kwTypeMenuStrip.Add(kWCMessageType.Card, new MenuStripVisibleCard());
            kwTypeMenuStrip.Add(kWCMessageType.Gif, new MenuStripVisibleGif());
            kwTypeMenuStrip.Add(kWCMessageType.Reply, new MenuStripVisibleReplay());
            kwTypeMenuStrip.Add(kWCMessageType.Link, new MenuStripVisibleGif());
            kwTypeMenuStrip.Add(kWCMessageType.History, new MenuStripVisibleHistory());
            kwTypeMenuStrip.Add(kWCMessageType.ProductPush, new MenuStripVisibleProduct());
        }

        public void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, kWCMessageType kw_type, bool isOneself = true, bool isReadDel = false)
        {
            bool custmizeRes = false;

            if (kw_type == kWCMessageType.ResouresNotify || kw_type == kWCMessageType.ResouresActive || kw_type == kWCMessageType.ResouresResoures || kw_type == kWCMessageType.ResouresSocial)
            {
                custmizeRes = true;
            }

            if (kwTypeMenuStrip.Count < 1)
                AddDictionary();
            //该类型不存在右键菜单
            if (!kwTypeMenuStrip.ContainsKey(kw_type))
            {
                foreach (ToolStripItem item in contextMenuScript.Items)
                {
                    if (custmizeRes)
                    {
                        if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                        {
                            switch (item.Text)
                            {
                                case "撤回":
                                    item.Visible = isOneself == true ? true : false;
                                    break;
                                case "转发":
                                case "多选":
                                case "回复":
                                case "删除":
                                case "保存":
                                    item.Visible = true;
                                    break;
                                default:
                                    item.Visible = false;
                                    break;
                            }
                        }
                        else
                        {
                            item.Visible = false;
                        }
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                return;
            }
            kwTypeMenuStrip[kw_type].SettingMenuStripVisible(ref contextMenuScript, isOneself, isReadDel);
        }
    }

    /// <summary>
    /// 父类（基类）
    /// </summary>
    public abstract class MenuStripVisible
    {
        public abstract void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel);
    }

    #region 音频
    public class MenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "用默认浏览器打开":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "保存":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 图片
    public class MenuStripVisibleImage : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_two":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "separator_three":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "复制":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "回复":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "保存":
                            item.Visible = (isReadDel && !isOneself) ? false : true;

                            break;
                        case "存表情":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        //case "编辑":
                        //    item.Visible = true;
                        //    break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "在文件夹中显示":
                            item.Visible = (isReadDel && !isOneself) ? false : true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 文本
    public class MenuStripVisibleText : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_two":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "复制":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "撤回":
                            item.Visible = isOneself ? true : false;
                            break;
                        case "转发":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "保存":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 商品信息
    public class MenuStripVisibleProduct : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_two":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "复制":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "撤回":
                            item.Visible = isOneself ? true : false;
                            break;
                        case "转发":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = isReadDel ? false : true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 回复
    public class MenuStripVisibleReplay : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "复制":
                            item.Visible = true;
                            break;
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "保存":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 视频
    public class MenuStripVisibleVideo : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "静音播放":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "保存":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "在文件夹中显示":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 文件
    public class MenuStripVisibleFile : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = true;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "保存":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        case "下载":
                            item.Visible = isOneself == false ? true : false;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "在文件夹中显示":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 位置
    public class MenuStripVisibleLocation : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 名片
    public class MenuStripVisibleCard : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 动画
    public class MenuStripVisibleGif : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 历史消息记录
    public class MenuStripVisibleHistory : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "撤回":
                            item.Visible = isOneself == true ? true : false;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "回复":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 保存的音频
    public class SaveMusicMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion
    #region 保存的文件
    public class SaveFileMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "重命名":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion
    #region 保存的视频
    public class SaveVedioMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "静音播放":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;
                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "重命名":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion
    #region 保存的相册文件夹
    public class SaveImgFolderMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;

                        case "新建文件夹":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;
                        case "重命名":
                            item.Visible = true;
                            break;
                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 保存的相册
    public class SaveImgFileMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;

                        case "转发":
                            item.Visible = true;
                            break;
                        case "存表情":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;

                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region 保存的相册
    public class SaveOtherMenuStripVisibleVoice : MenuStripVisible
    {
        public override void SettingMenuStripVisible(ref SkinContextMenuStrip contextMenuScript, bool isOneself, bool isReadDel)
        {
            foreach (ToolStripItem item in contextMenuScript.Items)
            {
                if (string.Equals(item.GetType().Name, "ToolStripSeparator"))
                    switch (item.Name)
                    {
                        case "separator_one":
                            item.Visible = true;
                            break;
                        case "separator_two":
                            item.Visible = true;
                            break;
                        case "separator_three":
                            item.Visible = isOneself ? true : false; ;
                            break;
                        case "separator_four":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                if (string.Equals(item.GetType().Name, "ToolStripMenuItem"))
                {
                    switch (item.Text)
                    {
                        case "打开":
                            item.Visible = true;
                            break;
                        case "复制":
                            item.Visible = true;
                            break;

                        case "转发":
                            item.Visible = true;
                            break;
                        case "多选":
                            item.Visible = true;
                            break;
                        case "另存为...":
                            item.Visible = true;
                            break;

                        case "删除":
                            item.Visible = true;
                            break;
                        default:
                            item.Visible = false;
                            break;
                    }
                }
            }
        }
    }
    #endregion
}
