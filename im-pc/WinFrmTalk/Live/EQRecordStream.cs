using FFmpeg.AutoGen;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Management;

namespace WinFrmTalk.Live
{
    public sealed unsafe class EQRecordStream
    {
        public Action<bool> CloseAllData = null;
        public int exit_thread = 0;     //退出录制线程
        public int recording = 0;       //指示是否正在录制
        //const string adevice_name = "audio=麦克风 (HD Webcam C270)";

        private int OpenOutput(ref AVFormatContext* pFormatCtx_Out, string url,
            AVFormatContext* aFormatCtx_In, AVCodecContext* pCodecCtx_aac, ref int audio_index,
            AVFormatContext* vFormatCtx_In, AVCodecContext* pCodecCtx_h264, ref int video_index)
        {
            int i, result = -1;

            fixed (AVFormatContext** f_pFormatCtx_Out = &pFormatCtx_Out)
            {
                result = ffmpeg.avformat_alloc_output_context2(f_pFormatCtx_Out, null, "mp4", url);
                if (result < 0)
                {
                    LogHelper.log.Error("Couldn't open output context.");
                    Console.WriteLine("Couldn't open output context.");
                    return result;
                }
            }

            //add video stream
            for (i = 0; i < vFormatCtx_In->nb_streams; i++)
            {
                AVStream* in_stream = vFormatCtx_In->streams[0];
                AVStream* out_stream = ffmpeg.avformat_new_stream(pFormatCtx_Out, in_stream->codec->codec);
                if (out_stream == null)
                {
                    LogHelper.log.Error("Failed allocating output stream.");
                    Console.WriteLine("Failed allocating output stream.");
                    //result = ffmpeg.AVERROR_UNKNOWN;
                    return -1;
                }
                //Copy the settings of AVCodecContext
                result = ffmpeg.avcodec_copy_context(out_stream->codec, in_stream->codec);
                if (result < 0)
                {
                    LogHelper.log.Error("Failed to copy context from input to output stream codec context.");
                    Console.WriteLine("Failed to copy context from input to output stream codec context.");
                    return -1;
                }
                out_stream->codec->codec_tag = 0;
                if ((pFormatCtx_Out->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                    out_stream->codec->flags |= ffmpeg.AV_CODEC_FLAG_GLOBAL_HEADER;

                if (out_stream->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    /* Some formats want stream headers to be separate. */
                    //if ((pFormatCtx_Out->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                    //    pCodecCtx_h264->flags |= ffmpeg.AV_CODEC_FLAG_GLOBAL_HEADER; //CODEC_FLAG_GLOBAL_HEADER
                    out_stream->codec = pCodecCtx_h264;
                    video_index = out_stream->index;
                }
                out_stream->time_base.num = 1;
                out_stream->time_base.den = 25;
            }

            //add audio stream
            for (i = 0; i < aFormatCtx_In->nb_streams; i++)
            {
                AVStream* in_stream = aFormatCtx_In->streams[i];
                AVStream* out_stream = ffmpeg.avformat_new_stream(pFormatCtx_Out, in_stream->codec->codec);
                if (out_stream == null)
                {
                    LogHelper.log.Error("Failed allocating output stream.");
                    Console.WriteLine("Failed allocating output stream.");
                    result = -22;
                    return result;
                }
                result = ffmpeg.avcodec_copy_context(out_stream->codec, in_stream->codec);
                if (result < 0)
                {
                    LogHelper.log.Error("Failed to copy context from input to output stream codec context.");
                    Console.WriteLine("Failed to copy context from input to output stream codec context.");
                    return result;
                }
                out_stream->codec->codec_tag = 0;

                if (out_stream->codec->codec_type == AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    //if ((pFormatCtx_Out->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                    //    out_stream->codec->flags |= ffmpeg.AV_CODEC_FLAG_GLOBAL_HEADER; //CODEC_FLAG_GLOBAL_HEADER
                    out_stream->codec = pCodecCtx_aac;
                    audio_index = out_stream->index;
                }
            }

            if (ffmpeg.avio_open(&pFormatCtx_Out->pb, url, ffmpeg.AVIO_FLAG_READ_WRITE) < 0)
            {
                LogHelper.log.Error("Failed to open IO.");
                Console.WriteLine("Failed to open IO.");
                return -1;
            }
            //0：未初始化完全； 1：初始化完全； ERROR：<0
            if (ffmpeg.avformat_write_header(pFormatCtx_Out, null) < 0)
            {
                LogHelper.log.Error("Failed to write header.");
                Console.WriteLine("Failed to write header.");
                return -1;
            }

            return 0;
        }

        public int StartPush(string path, Action<Bitmap> camera_action)
        {
            //string adevice_name = "audio=" + GetAudioDeviceName();
            AVFormatContext* aFormatCtx_In = null, vFormatCtx_In = null, pFormatCtx_Out = null;
            AVCodecContext* pCodecCtx_audio_In = null, pCodecCtx_aac = null, pCodecCtx_h264 = null;
            int i, result = -1, audio_index = -1, video_index = -1;

            ffmpeg.av_register_all();
            ffmpeg.avdevice_register_all();
            ffmpeg.avformat_network_init();

            AudioPushBase audioPushBase = new AudioPushBase();
            VideoPushBase videoPushBase = new VideoPushBase();
            #region open input
            if (audioPushBase.OpenInput(ref aFormatCtx_In, ref pCodecCtx_audio_In) < 0)
            {
                LogHelper.log.Error("Audio open input error.");
                Console.WriteLine("Audio open input error.");
                ffmpeg.avformat_close_input(&aFormatCtx_In);
                return -1;
            }
            if (videoPushBase.OpenInput(ref vFormatCtx_In) < 0)
            {
                LogHelper.log.Error("video open input error.");
                Console.WriteLine("video open input error.");
                return -1;
            }
            #endregion

            var st = aFormatCtx_In->streams[0];
            #region open encoder
            if (audioPushBase.OpenEncoder_AAC(ref pCodecCtx_aac) < 0)
            {
                LogHelper.log.Error("Audio open encoder error.");
                Console.WriteLine("Audio open encoder error.");
                ffmpeg.avformat_close_input(&aFormatCtx_In);
                ffmpeg.avformat_close_input(&vFormatCtx_In);
                return -1;
            }
            int in_width = vFormatCtx_In->streams[0]->codec->width;
            int in_height = vFormatCtx_In->streams[0]->codec->height;
            if (videoPushBase.OpenEncoder_H264(ref pCodecCtx_h264, in_width, in_height) < 0)
            {
                LogHelper.log.Error("Audio open encoder error.");
                Console.WriteLine("Audio open encoder error.");
                ffmpeg.avformat_close_input(&aFormatCtx_In);
                ffmpeg.avformat_close_input(&vFormatCtx_In);
                return -1;
            }
            #endregion

            #region open output
            if (OpenOutput(ref pFormatCtx_Out, path,
                aFormatCtx_In, pCodecCtx_aac, ref audio_index,
                vFormatCtx_In, pCodecCtx_h264, ref video_index) < 0)
            {
                LogHelper.log.Error("Failed open output.");
                Console.WriteLine("Failed open output.");
                ffmpeg.avformat_close_input(&aFormatCtx_In);
                ffmpeg.avformat_close_input(&vFormatCtx_In);
                return -10;
            }

            #region audio parameter
            ulong out_channel_layout = pCodecCtx_aac->channel_layout;
            int out_channels = ffmpeg.av_get_channel_layout_nb_channels(out_channel_layout);
            AVSampleFormat out_sample_fmt = AVSampleFormat.AV_SAMPLE_FMT_FLTP; // pCodecCtx_audio_Out->sample_fmt;
            int out_sample_rate = pCodecCtx_aac->sample_rate;    // 44100

            #region swr setting
            SwrContext* au_convert_ctx = ffmpeg.swr_alloc();
            au_convert_ctx = audioPushBase.SwrSetting_AAC(pCodecCtx_audio_In, pCodecCtx_aac, au_convert_ctx);
            #endregion

            // audio frame
            AVFrame* aac_frame = ffmpeg.av_frame_alloc();
            //aac_frame->channels = out_channels;
            //aac_frame->channel_layout = out_channel_layout;
            //aac_frame->sample_rate = out_sample_rate;
            //aac_frame->nb_samples = pCodecCtx_aac->frame_size;
            ////conv_frame->nb_samples = pFrame->nb_samples;
            //aac_frame->format = (int)out_sample_fmt;

            ////frame.data 需要申请的字节数
            //int size = ffmpeg.av_samples_get_buffer_size(null, out_channels, pCodecCtx_aac->frame_size, out_sample_fmt, 1);
            //byte* frame_buf = (byte*)ffmpeg.av_malloc((ulong)size);
            //ffmpeg.avcodec_fill_audio_frame(aac_frame, out_channels, out_sample_fmt, frame_buf, size, 1);
            #endregion

            #region video parameter
            SwsContext* img_convert_ctx = ffmpeg.sws_getContext(in_width, in_height,
                vFormatCtx_In->streams[0]->codec->pix_fmt, pCodecCtx_h264->width, pCodecCtx_h264->height,
                AVPixelFormat.AV_PIX_FMT_YUV420P, ffmpeg.SWS_BICUBIC, null, null, null);
            AVFrame* h264_frame = ffmpeg.av_frame_alloc();
            //h264_frame->format = (int)AVPixelFormat.AV_PIX_FMT_YUV420P;
            //h264_frame->width = pCodecCtx_h264->width;
            //h264_frame->height = pCodecCtx_h264->height;
            //byte* out_buffer = (byte*)ffmpeg.av_malloc((ulong)ffmpeg.avpicture_get_size(AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx_h264->width, pCodecCtx_h264->height));
            //ffmpeg.avpicture_fill((AVPicture*)h264_frame, out_buffer, AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx_h264->width, pCodecCtx_h264->height);

            #endregion
            #endregion

            AVFrame* pframe = ffmpeg.av_frame_alloc();
            AVPacket* dec_pkt = ffmpeg.av_packet_alloc();
            ffmpeg.av_init_packet(dec_pkt);
            AVPacket* enc_pkt = ffmpeg.av_packet_alloc();
            long cur_pts_v = 0, cur_pts_a = 0;
            long a_duration = 0, v_duration = 0;
            int dec_got_frame = 0, enc_got_frame = 0;
            int framecnt = 0;
            // set form show video
            Size sourceSize = new Size(in_width, in_height);
            AVPixelFormat sourcePixelFormat = vFormatCtx_In->streams[0]->codec->pix_fmt;
            Size destinationSize = sourceSize;
            AVPixelFormat destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
            //循环读取音频帧并且编解码（发送包接收帧）
            using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
            {
                while (true)
                {
                    if (exit_thread == 1)
                        break;
                    try
                    {
                        //if (ffmpeg.av_compare_ts(cur_pts_v, vFormatCtx_In->streams[0]->time_base,
                        //    cur_pts_a, aFormatCtx_In->streams[0]->time_base) <= 0)
                        if (true)
                        {
                            if (ffmpeg.av_read_frame(vFormatCtx_In, dec_pkt) >= 0)
                            {
                                AVStream* in_stream = vFormatCtx_In->streams[0];
                                AVStream* out_stream = pFormatCtx_Out->streams[video_index];

                                long calc_duration = Convert.ToInt64((double)ffmpeg.AV_TIME_BASE / ffmpeg.av_q2d(in_stream->r_frame_rate));
                                //Parameters
                                dec_pkt->pts = Convert.ToInt64((double)(framecnt * calc_duration) / (double)(ffmpeg.av_q2d(in_stream->time_base) * ffmpeg.AV_TIME_BASE));
                                dec_pkt->dts = dec_pkt->pts;
                                dec_pkt->duration = Convert.ToInt64((double)calc_duration / (double)(ffmpeg.av_q2d(in_stream->time_base) * ffmpeg.AV_TIME_BASE));

                                pframe = ffmpeg.av_frame_alloc();
                                if (pframe == null)
                                {
                                    //result = ffmpeg.AVERROR(ENOMEM);
                                    return -1;
                                }

                                result = ffmpeg.avcodec_send_packet(in_stream->codec, dec_pkt);
                                //result = ffmpeg.avcodec_decode_video2(vFormatCtx_In->streams[video_index]->codec, pframe,
                                //    &dec_got_frame, dec_pkt);   //解码
                                if (result < 0)
                                {
                                    ffmpeg.av_frame_free(&pframe);
                                    ffmpeg.av_log(null, ffmpeg.AV_LOG_ERROR, "Decoding failed\n");
                                    continue;
                                }
                                //if (dec_got_frame != 0)
                                while (ffmpeg.avcodec_receive_frame(in_stream->codec, pframe) == 0)
                                {
                                    // 展示到窗体中
                                    AVFrame frmFrame = vfc.Convert(pframe);
                                    using (var bitmap = new Bitmap(frmFrame.width, frmFrame.height, frmFrame.linesize[0], PixelFormat.Format24bppRgb, (IntPtr)frmFrame.data[0]))
                                    {
                                        camera_action(bitmap);
                                    }

                                    //是否开始了录制（非挂机状态）
                                    if (recording == 1)
                                    {
                                        //initialization frame
                                        h264_frame = ffmpeg.av_frame_alloc();
                                        h264_frame->format = (int)AVPixelFormat.AV_PIX_FMT_YUV420P;
                                        h264_frame->width = pCodecCtx_h264->width;
                                        h264_frame->height = pCodecCtx_h264->height;
                                        byte* out_buffer = (byte*)ffmpeg.av_malloc((ulong)ffmpeg.avpicture_get_size(AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx_h264->width, pCodecCtx_h264->height));
                                        ffmpeg.avpicture_fill((AVPicture*)h264_frame, out_buffer, AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx_h264->width, pCodecCtx_h264->height);

                                        ffmpeg.sws_scale(img_convert_ctx, pframe->data, pframe->linesize, 0, pCodecCtx_h264->height, h264_frame->data, h264_frame->linesize);
                                        h264_frame->pts = pframe->pts;
                                        h264_frame->pkt_dts = pframe->pkt_dts;
                                        h264_frame->pkt_pts = pframe->pkt_pts;
                                        h264_frame->pkt_duration = pframe->pkt_duration;
                                        //h264_frame->repeat_pict = 10000;

                                        ffmpeg.av_init_packet(enc_pkt);
                                        enc_pkt->data = null;
                                        enc_pkt->size = 0;
                                        //encodec
                                        result = ffmpeg.avcodec_send_frame(pCodecCtx_h264, h264_frame);
                                        if (result < 0)
                                        {
                                            ffmpeg.av_packet_unref(dec_pkt);
                                            ffmpeg.av_frame_free(&pframe);
                                            ffmpeg.av_frame_free(&h264_frame);
                                            ffmpeg.av_free(out_buffer);
                                            ffmpeg.av_packet_unref(enc_pkt);
                                            ffmpeg.av_log(null, ffmpeg.AV_LOG_ERROR, "Encoding failed\n");
                                            continue;
                                        }
                                        //result = ffmpeg.avcodec_encode_video2(pCodecCtx_h264, enc_pkt, h264_frame, &enc_got_frame);
                                        //if (enc_got_frame == 1)
                                        while (ffmpeg.avcodec_receive_packet(pCodecCtx_h264, enc_pkt) == 0)
                                        {

                                            //Console.WriteLine("Succeed to encode frame: %5d\tsize:%5d\n", framecnt, enc_pkt->size);
                                            framecnt++;
                                            enc_pkt->stream_index = pFormatCtx_Out->streams[video_index]->index;

                                            enc_pkt->pts = ffmpeg.av_rescale_q_rnd(dec_pkt->pts, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                                            enc_pkt->dts = ffmpeg.av_rescale_q_rnd(dec_pkt->dts, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                                            //enc_pkt->pts = ffmpeg.av_rescale_q(dec_pkt->pts, in_stream->time_base, out_stream->time_base);
                                            //enc_pkt->dts = ffmpeg.av_rescale_q(dec_pkt->dts, in_stream->time_base, out_stream->time_base);
                                            enc_pkt->duration = (int)ffmpeg.av_rescale_q(dec_pkt->duration, in_stream->time_base, out_stream->time_base);
                                            //enc_pkt->pts = ffmpeg.av_rescale_q(framecnt * calc_duration, time_base_q, time_base);
                                            //enc_pkt->dts = enc_pkt->pts;
                                            //enc_pkt->duration = ffmpeg.av_rescale_q(calc_duration, time_base_q, time_base); //(double)(calc_duration)*(double)(av_q2d(time_base_q)) / (double)(av_q2d(time_base));
                                            enc_pkt->pos = -1;

                                            //Delay
                                            //long pts_time = ffmpeg.av_rescale_q(enc_pkt->dts, time_base, time_base_q);
                                            //long now_time = ffmpeg.av_gettime() - start_time;
                                            //if (pts_time > now_time)
                                            //    ffmpeg.av_usleep(Convert.ToUInt32(Math.Abs(pts_time - now_time)));

                                            Console.WriteLine(string.Format("Video pts is {0}, dts is {1}, duration is {2}", dec_pkt->pts, dec_pkt->dts, dec_pkt->duration));
                                            result = ffmpeg.av_interleaved_write_frame(pFormatCtx_Out, enc_pkt);
                                        }
                                        ffmpeg.av_packet_unref(enc_pkt);
                                        ffmpeg.av_frame_free(&h264_frame);
                                        ffmpeg.av_free(out_buffer);
                                    }
                                }
                                long diff = dec_pkt->pts - cur_pts_v;
                                cur_pts_v = dec_pkt->pts;
                                v_duration = dec_pkt->duration;
                                //Console.WriteLine("video pts: " + dec_pkt->pts);
                                //Console.WriteLine("video diff: " + diff);
                                //Console.WriteLine("av_gettime: " + ffmpeg.av_gettime());
                                //Console.WriteLine("video duration: " + v_duration);
                                //Console.WriteLine("video pts + duration: " + (cur_pts_v + v_duration));

                                ffmpeg.av_packet_unref(dec_pkt);
                                ffmpeg.av_frame_free(&pframe);
                            }
                        }
                        else
                        {
                            if(ffmpeg.av_read_frame(aFormatCtx_In, dec_pkt) >= 0)
                            {
                                AVStream* in_stream = aFormatCtx_In->streams[0];
                                AVStream* out_stream = pFormatCtx_Out->streams[audio_index];

                                result = ffmpeg.avcodec_send_packet(pCodecCtx_audio_In, dec_pkt);
                                if (result != 0)
                                {
                                    LogHelper.log.Error("audio send packet error.");
                                    Console.WriteLine("audio send packet error.");
                                    ffmpeg.av_packet_unref(dec_pkt);
                                    continue;
                                }
                                pframe = ffmpeg.av_frame_alloc();
                                pframe->channel_layout = (ulong)ffmpeg.AV_CH_LAYOUT_STEREO;
                                while (ffmpeg.avcodec_receive_frame(pCodecCtx_audio_In, pframe) == 0)
                                {
                                    // audio frame
                                    aac_frame = ffmpeg.av_frame_alloc();
                                    aac_frame->channels = out_channels;
                                    aac_frame->channel_layout = out_channel_layout;
                                    aac_frame->sample_rate = out_sample_rate;
                                    aac_frame->nb_samples = AudioPushBase.audio_buffer_size * out_sample_rate / 1000;
                                    aac_frame->format = (int)out_sample_fmt;

                                    //frame.data 需要申请的字节数
                                    int buff_size = ffmpeg.av_samples_get_buffer_size(null, out_channels, aac_frame->nb_samples, out_sample_fmt, 1);
                                    byte* frame_buff = (byte*)ffmpeg.av_malloc((ulong)buff_size);
                                    ffmpeg.avcodec_fill_audio_frame(aac_frame, out_channels, out_sample_fmt, frame_buff, buff_size, 1);

                                    //重采样
                                    result = ffmpeg.swr_convert(au_convert_ctx, aac_frame->extended_data, aac_frame->nb_samples, pframe->extended_data, pframe->nb_samples);
                                    if (result < 0)
                                    {
                                        LogHelper.log.Error("Failed swr convert.");
                                        Console.WriteLine("Failed swr convert.");
                                        ffmpeg.av_frame_free(&aac_frame);
                                        ffmpeg.av_free(frame_buff);
                                        ffmpeg.av_frame_free(&pframe);
                                        ffmpeg.av_packet_unref(dec_pkt);
                                        break;
                                    }
                                    aac_frame->linesize[1] = aac_frame->linesize[0];
                                    //初始化pack
                                    ffmpeg.av_init_packet(enc_pkt);
                                    enc_pkt->data = null;
                                    enc_pkt->size = 0;

                                    result = ffmpeg.avcodec_send_frame(pCodecCtx_aac, aac_frame);
                                    if (result == 0)
                                    {
                                        //result = ffmpeg.avcodec_encode_audio2(pCodecCtx_audio_aac, enc_pack, conv_frame, &enc_got_frame);
                                        //if (enc_got_frame == 1)
                                        //{
                                        while (ffmpeg.avcodec_receive_packet(pCodecCtx_aac, enc_pkt) == 0)
                                        {
                                            enc_pkt->stream_index = pFormatCtx_Out->streams[audio_index]->index;
                                            enc_pkt->pts = ffmpeg.av_rescale_q_rnd(dec_pkt->pts, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                                            enc_pkt->dts = enc_pkt->pts;
                                            enc_pkt->duration = ffmpeg.av_rescale_q_rnd(dec_pkt->duration, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                                            enc_pkt->pos = -1;
                                            //Console.WriteLine(string.Format("Audio pts is {0}, dts is {1}, duration is {2}", dec_pkt->pts, dec_pkt->dts, dec_pkt->duration));
                                            if (recording == 1)
                                            {
                                                ffmpeg.av_interleaved_write_frame(pFormatCtx_Out, enc_pkt);
                                            }
                                        }
                                        //}
                                        ffmpeg.av_packet_unref(enc_pkt);
                                    }
                                    ffmpeg.av_frame_free(&aac_frame);
                                    ffmpeg.av_free(frame_buff);
                                }
                                a_duration = dec_pkt->duration;
                                cur_pts_a = dec_pkt->dts;
                                //Console.WriteLine("audio dts: " + cur_pts_a);
                                //Console.WriteLine("audio duration: " + a_duration);
                                //Console.WriteLine("pts: " + enc_pkt->pts);

                                ffmpeg.av_frame_free(&pframe);
                                ffmpeg.av_packet_unref(dec_pkt);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.log.Error("推流过程中出错：" + ex.Message);
                        Console.WriteLine("推流过程中出错：" + ex.Message);
                        break;
                    }
                }
            }


            #region End
            //Write file trailer
            result = ffmpeg.av_write_trailer(pFormatCtx_Out);
            if (result == -10053)
            {
                HttpUtils.Instance.ShowTip("断网状态下无法正常结束直播，直播地址将被占用。");
            }

            //Clean
            if (pFormatCtx_Out->streams[audio_index] != null)
                ffmpeg.avcodec_close(pFormatCtx_Out->streams[audio_index]->codec);
            if (pFormatCtx_Out->streams[video_index] != null)
                ffmpeg.avcodec_close(pFormatCtx_Out->streams[video_index]->codec);
            ffmpeg.avio_close(pFormatCtx_Out->pb);
            ffmpeg.av_frame_free(&aac_frame);
            ffmpeg.av_frame_free(&h264_frame);
            ffmpeg.avformat_close_input(&aFormatCtx_In);
            ffmpeg.avformat_close_input(&vFormatCtx_In);
            ffmpeg.avformat_free_context(pFormatCtx_Out);
            ffmpeg.sws_freeContext(img_convert_ctx);
            ffmpeg.swr_free(&au_convert_ctx);
            #endregion

            //通知界面关闭窗体
            CloseAllData?.Invoke(true);

            return 0;
        }
    }
}
