using FFmpeg.AutoGen;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Management;

namespace WinFrmTalk.Live
{
    public sealed unsafe class VideoPushBase
    {
        public static string GetVideoDeviceName()
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    string device_name = device["Caption"].ToString();
                    return device_name;
                }
                catch { continue; }
            }
            return "";

            //string device_name = "";
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            //foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            //{
            //    foreach (var property in device.Properties)
            //    {
            //        if (property.Value != null && property.Name.Contains("PNPClass") && (property.Value.ToString() == "Image" || property.Value.ToString() == "Camera"))
            //            device_name = device["Caption"].ToString();
            //        if (property.Name.ToLower().Contains("caption"))
            //        {
            //            if (property.Value != null&& property.Value.ToString().ToLower().Contains("camera"))
            //            {
            //                device_name = device["Caption"].ToString();
            //            }
            //        }
            //    }
            //}
            //return device_name;
        }

        public int OpenInput(ref AVFormatContext* pFormatCtx_In)
        {
            int videoIndex = -1;
            string vdevice_name = "video=" + GetVideoDeviceName();
            if (string.IsNullOrEmpty(vdevice_name))
            {
                LogHelper.log.Error("Failed get video device name.");
                Console.WriteLine("Failed get video device name.");
                return -1;
            }
            ////这里可以加参数打开，例如可以指定采集帧率
            AVDictionary* options = null;
            ffmpeg.av_dict_set(&options, "framerate", "25", 0);
            //ffmpeg.av_dict_set(&options, "max_interleave_delta", "15000000", 0);
            //ffmpeg.av_dict_set(&options, "video_size", "1280x720", 0);
            //ffmpeg.av_dict_set(&options, "probesize", "2048",0);
            //ffmpeg.av_dict_set(&options, "max_analyze_duration", "10", 0);
            AVInputFormat* ifmt = ffmpeg.av_find_input_format("dshow");
            //Set own video device's name
            fixed (AVFormatContext** f_pFormatCtx_In = &pFormatCtx_In)
            {
                if (ffmpeg.avformat_open_input(f_pFormatCtx_In, vdevice_name, ifmt, &options) != 0)
                {
                    LogHelper.log.Error("Couldn't open input stream.（无法打开输入流）");
                    Console.WriteLine("Couldn't open input stream.（无法打开输入流）");
                    return -1;
                }
            }
            //检查视频流
            for (int i = 0; i < pFormatCtx_In->nb_streams; i++)
            {
                if (pFormatCtx_In->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    videoIndex = i;
                }
            }
            if (videoIndex == -1)
            {
                LogHelper.log.Error("Couldn't find a video stream.（没有找到视频流）");
                Console.WriteLine("Couldn't find a video stream.（没有找到视频流）");
                return -1;
            }
            pFormatCtx_In->probesize = 5000000; // 2 * 1024;
            pFormatCtx_In->max_analyze_duration = 0;
            //找到解码器
            AVCodec* codec = ffmpeg.avcodec_find_decoder(pFormatCtx_In->streams[videoIndex]->codec->codec_id);
            if (codec == null)
            {
                LogHelper.log.Error("Could not open codec.（无法找到解码器)");
                Console.WriteLine("Could not find codec.（无法找到解码器）");
                return -1;
            }
            //打开解码器
            if (ffmpeg.avcodec_open2(pFormatCtx_In->streams[videoIndex]->codec, codec, null) < 0)
            {
                LogHelper.log.Error("Could not open codec.（无法打开解码器)");
                Console.WriteLine("Could not open codec.（无法打开解码器）");
                return -1;
            }

            return 0;
        }

        public int OpenEncoder_H264(ref AVCodecContext* pCodecCtx_H264, int width, int height)
        {
            AVCodec* pCodec_Video = ffmpeg.avcodec_find_encoder(AVCodecID.AV_CODEC_ID_H264);
            if (pCodec_Video == null)
            {
                LogHelper.log.Error("Can not find encoder! (没有找到合适的编码器！)");
                Console.WriteLine("Can not find encoder! (没有找到合适的编码器！)");
                return -1;
            }

            pCodecCtx_H264 = ffmpeg.avcodec_alloc_context3(pCodec_Video);
            pCodecCtx_H264->pix_fmt = AVPixelFormat.AV_PIX_FMT_YUV420P;
            pCodecCtx_H264->width = width;
            pCodecCtx_H264->height = height;
            pCodecCtx_H264->time_base.num = 1;
            pCodecCtx_H264->time_base.den = 25;
            pCodecCtx_H264->bit_rate = 400000;
            pCodecCtx_H264->gop_size = 12;


            //H264 codec param
            //pCodecCtx->me_range = 16;
            //pCodecCtx->max_qdiff = 4;
            //pCodecCtx->qcompress = 0.6;
            pCodecCtx_H264->qmin = 2;
            pCodecCtx_H264->qmax = 31;
            //Optional Param
            //pCodecCtx_H264->max_b_frames = 3;
            // Set H264 preset and tune
            AVDictionary* param = null;
            ffmpeg.av_dict_set(&param, "rtbufsize", "256M", 0);
            ffmpeg.av_dict_set(&param, "preset", "superfast", 0);
            ffmpeg.av_dict_set(&param, "tune", "zerolatency", 0);

            //添加h264的sps,pps信息
            pCodecCtx_H264->flags |= ffmpeg.AV_CODEC_FLAG_GLOBAL_HEADER; //CODEC_FLAG_GLOBAL_HEADER

            if (ffmpeg.avcodec_open2(pCodecCtx_H264, pCodec_Video, &param) < 0)
            {
                LogHelper.log.Error("Failed to open encoder! (编码器打开失败！)");
                Console.WriteLine("Failed to open encoder! (编码器打开失败！)");
                return -1;
            }

            return 0;
        }
    }
}
