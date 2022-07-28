using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WinFrmTalk
{
    public class LocalConfig
    {
        #region Private Member

        private string tempFilepath;
        private string videoPath;
        private string voicePath;
        private string filePath;
        private string imagePath;
        private string messageDatabasePath;
        private string emojiFolderPath;
        private string gifFolderPath;
        private string roomFileFolderPath;
        #endregion

        #region Public Member


        /// <summary>
        /// 聊天记录下载临时数据路径
        /// </summary>
        public string TempFilepath
        {
            get
            {
                if (!Directory.Exists(tempFilepath))
                {
                    Directory.CreateDirectory(tempFilepath);
                }
                return tempFilepath;
            }

            set => tempFilepath = value;
        }


        /// <summary>
        /// 消息数据库路径
        /// </summary>
        public string MessageDatabasePath
        {
            get
            {
                if (!Directory.Exists(messageDatabasePath))
                {
                    Directory.CreateDirectory(messageDatabasePath);
                }
                return messageDatabasePath;
            }
            set { messageDatabasePath = value; }
        }

        /// <summary>
        /// emoji表情目录
        /// </summary>
        public string EmojiFolderPath
        {
            get
            {
                if (!Directory.Exists(emojiFolderPath))
                {
                    Directory.CreateDirectory(emojiFolderPath);
                }
                Applicate.copyDir(Applicate. AppCurrentDirectory + @"Res", Applicate.AppPublicDirectory);//由于res文件夹中的内容无法加载到最新的路径下，通过复制的方式
                return emojiFolderPath;
            }
            set => emojiFolderPath = value;
        }

        /// <summary>
        /// 动画图片目录
        /// </summary>
        public string GifFolderPath
        {
            get
            {
                if (!Directory.Exists(gifFolderPath))
                {
                    Directory.CreateDirectory(gifFolderPath);
                }
                return gifFolderPath;
            }
            set => gifFolderPath = value;
        }


        /// <summary>
        /// 视频目录
        /// </summary>
        public string VideoFolderPath
        {
            get
            {
                if (!Directory.Exists(videoPath))
                {
                    Directory.CreateDirectory(videoPath);
                }
                return videoPath;
            }
            set => videoPath = value;
        }


        /// <summary>
        /// 下载图片目录
        /// </summary>
        public string ImageFolderPath
        {
            get
            {
                if(imagePath ==null)
                {
                    imagePath= Applicate.LocalConfigData.ImageFolderPath = Applicate.AppPublicDirectory + "Downloads\\ShikuIM\\Image\\";
                }
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                // 创建缩略图地址
                if (!Directory.Exists(imagePath+"\\t"))
                {
                    Directory.CreateDirectory(imagePath+"\\t");
                }
                

                return imagePath;
            }
            set => imagePath = value;
        }



        /// <summary>
        /// 音频路径
        /// </summary>
        public string VoiceFolderPath
        {
            get
            {
                if (!Directory.Exists(voicePath))
                {
                    Directory.CreateDirectory(voicePath);
                }
                return voicePath;
            }
            set { voicePath = value; }
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileFolderPath
        {
            get
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                return filePath;
            }
            set { filePath = value; }
        }

        /// <summary>
        /// 群文件路径
        /// </summary>
        public string RoomFileFolderPath
        {
            get
            {
                if (!Directory.Exists(roomFileFolderPath))
                {
                    Directory.CreateDirectory(roomFileFolderPath);
                }
                return roomFileFolderPath;
            }
            set { roomFileFolderPath = value; }
        }
        #endregion
    }
}
