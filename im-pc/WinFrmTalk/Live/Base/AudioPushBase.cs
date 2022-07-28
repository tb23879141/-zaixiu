using FFmpeg.AutoGen;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace WinFrmTalk.Live
{
    public sealed unsafe class AudioPushBase
    {
        public const int audio_buffer_size = 21;

        public static string GetAudioDeviceName()
        {
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity  WHERE (PNPClass = 'AudioEndpoint')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");

            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            //foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            //{
            //    try
            //    {
            //        //if (device.ToString().IndexOf("{0.0.1.00000000}") > 0)
            //        //{
            //            string device_name = device["Caption"].ToString();
            //            return device_name;
            //        //}
            //    }
            //    catch { continue; }
            //}
            //return "";

            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity  WHERE (PNPClass = 'AudioEndpoint')");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    if (device.ToString().IndexOf("{0.0.1.00000000}") > 0)
                    {
                        Console.WriteLine("PNPClass: " + device["PNPClass"] + "  Caption: " + device["Caption"]);
                        string device_name = device["Caption"].ToString();
                        return device_name;
                    }
                }
                catch { continue; }
            }
            return "";
        }

        public int OpenInput(ref AVFormatContext* pFormatCtx_In, ref AVCodecContext* pCodecCtx_audio_In)
        {
            string adevice_name = "audio=" + GetAudioDeviceName();
            if (string.IsNullOrEmpty(adevice_name))
            {
                LogHelper.log.Error("Failed get audio device name.");
                Console.WriteLine("Failed get audio device name.");
                return -1;
            }
            int i, result = -1, audio_index = -1;
            AVInputFormat* ifmt = ffmpeg.av_find_input_format("dshow");
            AVDictionary* tmp = null;
            ffmpeg.av_dict_set_int(&tmp, "sample_rate", 44100, 0);     //我的设备不支持8000,先采44100在重采样成8000
            ffmpeg.av_dict_set_int(&tmp, "sample_size", 16, 0);
            ffmpeg.av_dict_set_int(&tmp, "channels", 2, 0);
            ffmpeg.av_dict_set_int(&tmp, "audio_buffer_size", audio_buffer_size, 0);  //buffer大小是以采样率44100计算的,设置了采样率也无效
            //open input
            fixed (AVFormatContext** f_pFormatCtx_In = &pFormatCtx_In)
                result = ffmpeg.avformat_open_input(f_pFormatCtx_In, adevice_name, ifmt, &tmp);
            if (result < 0)
            {
                LogHelper.log.Error("Couldn't open input stream.（无法打开输入流）");
                Console.WriteLine("Couldn't open input stream.（无法打开输入流）");
                return -1;
            }

            //find stream
            if (ffmpeg.avformat_find_stream_info(pFormatCtx_In, null) < 0)
            {
                Console.WriteLine("Couldn't find stream information.\n");
                return -1;
            }
            for (i = 0; i < pFormatCtx_In->nb_streams; i++)
            {
                if (pFormatCtx_In->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    audio_index = i;
                }
            }

            if (audio_index == -1)
            {
                LogHelper.log.Error("Couldn't find a audio stream.（没有找到音频流）");
                Console.WriteLine("Couldn't find a audio stream.（没有找到音频流）");
                return -1;
            }
            //pFormatCtx_In->probesize = 2 * 1024;    //5000000
            //pFormatCtx_In->max_analyze_duration = 1000;

            pCodecCtx_audio_In = pFormatCtx_In->streams[audio_index]->codec;
            AVCodec* pCodec_audio_In = ffmpeg.avcodec_find_decoder(pCodecCtx_audio_In->codec_id);
            if (ffmpeg.avcodec_open2(pCodecCtx_audio_In, pCodec_audio_In, null) < 0)
            {
                LogHelper.log.Error("Open audio decoder error.");
                Console.WriteLine("Open audio decoder error.");
                return -1;
            }

            return 0;
        }

        public int OpenEncoder_AAC(ref AVCodecContext* pCodecCtx_AAC)
        {
            AVCodec* pCodec_audio_enc = ffmpeg.avcodec_find_encoder(AVCodecID.AV_CODEC_ID_AAC);
            pCodecCtx_AAC = ffmpeg.avcodec_alloc_context3(pCodec_audio_enc);
            pCodecCtx_AAC->codec_id = AVCodecID.AV_CODEC_ID_AAC;
            pCodecCtx_AAC->codec_type = AVMediaType.AVMEDIA_TYPE_AUDIO;
            pCodecCtx_AAC->sample_fmt = AVSampleFormat.AV_SAMPLE_FMT_FLTP;
            pCodecCtx_AAC->sample_rate = 48000; // 44100;
            pCodecCtx_AAC->channel_layout = (ulong)ffmpeg.AV_CH_LAYOUT_STEREO;
            pCodecCtx_AAC->channels = ffmpeg.av_get_channel_layout_nb_channels(pCodecCtx_AAC->channel_layout);
            //pCodecCtx_AAC->bit_rate = 64000;
            pCodecCtx_AAC->time_base.num = 1;
            pCodecCtx_AAC->time_base.den = 48000;
            pCodecCtx_AAC->qmin = 2;
            pCodecCtx_AAC->qmax = 31;

            if (ffmpeg.avcodec_open2(pCodecCtx_AAC, pCodec_audio_enc, null) < 0)
            {
                LogHelper.log.Error("Open audio encoder error.");
                Console.WriteLine("Open audio encoder error.");
                return -1;
            }

            return 0;
        }

        public SwrContext* SwrSetting_AAC(AVCodecContext* pCodecCtx_audio_In, AVCodecContext* pCodecCtx_audio_aac, SwrContext* au_convert_ctx)
        {
            ulong out_channel_layout = pCodecCtx_audio_aac->channel_layout;
            int out_channels = ffmpeg.av_get_channel_layout_nb_channels(out_channel_layout);
            AVSampleFormat out_sample_fmt = AVSampleFormat.AV_SAMPLE_FMT_FLTP; // pCodecCtx_audio_Out->sample_fmt;
            int out_sample_rate = pCodecCtx_audio_aac->sample_rate;    // 44100
            long in_channel_layout = ffmpeg.av_get_default_channel_layout(pCodecCtx_audio_In->channels);
            au_convert_ctx = ffmpeg.swr_alloc_set_opts(au_convert_ctx,
                (long)out_channel_layout,           // 3
                out_sample_fmt,                     // AV_SAMPLE_FMT_FLTP
                out_sample_rate,                    // 44100
                in_channel_layout,                  // 3
                pCodecCtx_audio_In->sample_fmt,     // AV_SAMPLE_FMT_S16
                pCodecCtx_audio_In->sample_rate,    // 44100
                0, null);
            ffmpeg.swr_init(au_convert_ctx);

            return au_convert_ctx;
        }
    }
}
