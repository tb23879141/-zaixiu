using FFmpeg.AutoGen;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Management;
using System.Text;

namespace WinFrmTalk.Live
{
    public sealed unsafe class RecordPush
    {
        //Show Device  
        void show_dshow_device()
        {
            AVFormatContext* pFmtCtx = ffmpeg.avformat_alloc_context();
            AVDictionary* options = null;
            ffmpeg.av_dict_set(&options, "list_devices", "true", 0);
            AVInputFormat* iformat = ffmpeg.av_find_input_format("dshow");
            Console.WriteLine("Device Info=============\n");
            ffmpeg.avformat_open_input(&pFmtCtx, "video=Logitech HD Webcam C270", iformat, &options);
            Console.WriteLine("========================\n");
        }

        public int exit_thread = 0;
        //DWORD WINAPI MyThreadFunction(LPVOID lpParam)
        //{
        //    while ((getchar()) != '\n')
        //        ;
        //    exit_thread = 1;
        //    return 0;
        //}

        private string GetAudioDeviceName()
        {
            ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity  WHERE (PNPClass = 'AudioEndpoint')");
            //ManagementObjectSearcher VoiceDeviceSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity");
            foreach (var device in VoiceDeviceSearcher.Get())//循环遍历WMI实例中的每一个对象
            {
                try
                {
                    //Console.WriteLine("PNPClass: " + device["PNPClass"] + "  Caption: " + device["Caption"]);
                    if (device.ToString().IndexOf("{0.0.1.00000000}") > 0)
                    {
                        string device_name = device["Caption"].ToString();
                        return device_name;
                    }
                }
                catch { continue; }
            }
            return "";
        }

        private string GetVideoDeviceName()
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
        }

        public int StartPush(string url, Action<Bitmap> camera_action)
        {
            string vdevice_name = "video=" + GetVideoDeviceName();
            //string adevice_name = "audio=" + GetAudioDeviceName();
            if (string.IsNullOrEmpty(vdevice_name) /*|| string.IsNullOrEmpty(adevice_name)*/)
                return -1;
            AVFormatContext* ifmt_ctx = null;
            AVFormatContext* ofmt_ctx;
            AVInputFormat* ifmt;
            AVStream* video_st;
            AVCodecContext* pCodecCtx;
            AVCodec* pCodec;
            AVPacket* dec_pkt;
            AVPacket enc_pkt;
            AVFrame* pframe, pFrameYUV;
            SwsContext* img_convert_ctx;
            //int framecnt = 0;
            int videoIndex = -1/*, audioIndex = -1*/;
            int i;
            int ret;
            //HANDLE hThread;

            string out_path = url;
            int dec_got_frame, enc_got_frame;

            ffmpeg.av_register_all();
            //Register Device
            ffmpeg.avdevice_register_all();
            ffmpeg.avformat_network_init();

            //Show Dshow Device  
            //show_dshow_device();

            //sprintf(device_name, "video=screen-capture-recorder");
            ifmt = ffmpeg.av_find_input_format("dshow");
            //Set own video device's name
            ret = ffmpeg.avformat_open_input(&ifmt_ctx, vdevice_name, ifmt, null);
            if (ret != 0)
            {
                Console.WriteLine("Couldn't open input stream.（无法打开输入流）\n");
                return -1;
            }
            //Set own audio device's name
            //if (ffmpeg.avformat_open_input(&ifmt_ctx, adevice_name, ifmt, null) != 0)
            //{
            //    Console.WriteLine("Couldn't open input stream.（无法打开输入流）\n");
            //    return -1;
            //}
            //input initialize
            if (ffmpeg.avformat_find_stream_info(ifmt_ctx, null) < 0)
            {
                Console.WriteLine("Couldn't find stream information.（无法获取流信息）\n");
                return -1;
            }
            for (i = 0; i < ifmt_ctx->nb_streams; i++)
            {
                if (ifmt_ctx->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    videoIndex = i;
                }
                //if (ifmt_ctx->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_AUDIO)
                //{
                //    audioIndex = i;
                //}
            }

            if (videoIndex == -1)
            {
                Console.WriteLine("Couldn't find a video stream.（没有找到视频流）\n");
                return -1;
            }
            //if (audioIndex == -1)
            //{
            //    Console.WriteLine("Couldn't find a audio stream.（没有找到音频流）\n");
            //    return -1;
            //}

            //ifmt_ctx->probesize = 1 * 1024;
            //ifmt_ctx->max_analyze_duration = 1 * ffmpeg.AV_TIME_BASE;

            if (ffmpeg.avcodec_open2(ifmt_ctx->streams[videoIndex]->codec, ffmpeg.avcodec_find_decoder(ifmt_ctx->streams[videoIndex]->codec->codec_id), null) < 0)
            {
                //if (ffmpeg.avcodec_open2(ifmt_ctx->streams[audioIndex]->codec, ffmpeg.avcodec_find_decoder(ifmt_ctx->streams[audioIndex]->codec->codec_id), null) < 0)
                {
                    Console.WriteLine("Could not open codec.（无法打开解码器）\n");
                    return -1;
                }
            }

            //output initialize
            ffmpeg.avformat_alloc_output_context2(&ofmt_ctx, null, "flv", out_path);
            //output encoder initialize
            pCodec = ffmpeg.avcodec_find_encoder(AVCodecID.AV_CODEC_ID_H264);
            if (pCodec == null)
            {
                Console.WriteLine("Can not find encoder! (没有找到合适的编码器！)\n");
                return -1;
            }

            pCodecCtx = ffmpeg.avcodec_alloc_context3(pCodec);
            pCodecCtx->pix_fmt = AVPixelFormat.AV_PIX_FMT_YUV420P;
            pCodecCtx->width = ifmt_ctx->streams[videoIndex]->codec->width;
            pCodecCtx->height = ifmt_ctx->streams[videoIndex]->codec->height;
            pCodecCtx->time_base.num = 1;
            pCodecCtx->time_base.den = 25;
            pCodecCtx->bit_rate = 400000;
            pCodecCtx->gop_size = 250;
            /* Some formats want stream headers to be separate. */
            if ((ofmt_ctx->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                pCodecCtx->flags |= 0x00400000; //CODEC_FLAG_GLOBAL_HEADER


            //H264 codec param
            //pCodecCtx->me_range = 16;
            //pCodecCtx->max_qdiff = 4;
            //pCodecCtx->qcompress = 0.6;
            pCodecCtx->qmin = 10;
            pCodecCtx->qmax = 51;
            //Optional Param
            pCodecCtx->max_b_frames = 3;
            // Set H264 preset and tune
            AVDictionary* param = null;
            ffmpeg.av_dict_set(&param, "rtbufsize", "256M", 0);
            ffmpeg.av_dict_set(&param, "preset", "ultrafast", 0);
            ffmpeg.av_dict_set(&param, "tune", "zerolatency", 0);

            if (ffmpeg.avcodec_open2(pCodecCtx, pCodec, &param) < 0)
            {
                Console.WriteLine("Failed to open encoder! (编码器打开失败！)\n");
                return -1;
            }

            //Add a new stream to output,should be called by the user before avformat_write_header() for muxing
            //video_st = ffmpeg.avformat_new_stream(ofmt_ctx, pCodec);
            //audio_st = ffmpeg.avformat_new_stream(ofmt_ctx, ifmt_ctx->streams[audioIndex]->codec->codec);
            //if (video_st == null)
            //{
            //    return -1;
            //}
            for (i = 0; i < ifmt_ctx->nb_streams; i++)
            {
                //Create output AVStream according to input AVStream
                AVStream* in_stream = ifmt_ctx->streams[i];
                AVStream* out_stream = ffmpeg.avformat_new_stream(ofmt_ctx, in_stream->codec->codec);
                if (out_stream == null)
                {
                    Console.WriteLine("Failed allocating output stream\n");
                    ret = ffmpeg.AVERROR_UNKNOWN;
                    return -1;
                }
                //Copy the settings of AVCodecContext
                ret = ffmpeg.avcodec_copy_context(out_stream->codec, in_stream->codec);
                if (ret < 0)
                {
                    Console.WriteLine("Failed to copy context from input to output stream codec context\n");
                    return -1;
                }
                out_stream->codec->codec_tag = 0;
                if ((ofmt_ctx->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                    out_stream->codec->flags |= 0x00400000; //CODEC_FLAG_GLOBAL_HEADER
            }
            video_st = ofmt_ctx->streams[videoIndex];
            video_st->time_base.num = 1;
            video_st->time_base.den = 25;
            video_st->codec = pCodecCtx;


            //Open output URL,set before avformat_write_header() for muxing
            if (ffmpeg.avio_open(&ofmt_ctx->pb, out_path, ffmpeg.AVIO_FLAG_READ_WRITE) < 0)
            {
                Console.WriteLine("Failed to open output file! (输出文件打开失败！)\n");
                return -1;
            }


            //Show some Information
            ffmpeg.av_dump_format(ofmt_ctx, 0, out_path, 1);


            //Write File Header
            ffmpeg.avformat_write_header(ofmt_ctx, null);


            //prepare before decode and encode
            dec_pkt = (AVPacket*)ffmpeg.av_malloc((ulong)sizeof(AVPacket));
            //enc_pkt = (AVPacket *)av_malloc(sizeof(AVPacket));
            //camera data has a pix fmt of RGB,convert it to YUV420
            img_convert_ctx = ffmpeg.sws_getContext(ifmt_ctx->streams[videoIndex]->codec->width, ifmt_ctx->streams[videoIndex]->codec->height,
                ifmt_ctx->streams[videoIndex]->codec->pix_fmt, pCodecCtx->width, pCodecCtx->height, AVPixelFormat.AV_PIX_FMT_YUV420P, ffmpeg.SWS_BICUBIC, null, null, null);
            pFrameYUV = ffmpeg.av_frame_alloc();
            pFrameYUV->format = (int)AVPixelFormat.AV_PIX_FMT_YUV420P;
            pFrameYUV->width = pCodecCtx->width;
            pFrameYUV->height = pCodecCtx->height;
            byte* out_buffer = (byte*)ffmpeg.av_malloc((ulong)ffmpeg.avpicture_get_size(AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx->width, pCodecCtx->height));
            ffmpeg.avpicture_fill((AVPicture*)pFrameYUV, out_buffer, AVPixelFormat.AV_PIX_FMT_YUV420P, pCodecCtx->width, pCodecCtx->height);


            Console.WriteLine("\n --------call started----------\n\n");
            Console.WriteLine("Press enter to stop...");
            /*hThread = CreateThread(
                null,                   // default security attributes
                    0,                      // use default stack size  
                MyThreadFunction,       // thread function name
                null,          // argument to thread function 
                    0,                      // use default creation flags 
                null);   // returns the thread identifier */


            //为了让我们的代码发送流的速度，相当于整个视频播放的数据。需要记录程序开始的时间
            //后面再根据，每一帧的时间。做适当的延迟，防止我们的代码发送的太快了
            long start_time = ffmpeg.av_gettime();
            //记录视频帧的index，用来计算pts
            long frame_index = 0;

            Size sourceSize = new Size(ifmt_ctx->streams[videoIndex]->codec->width, ifmt_ctx->streams[videoIndex]->codec->height);
            AVPixelFormat sourcePixelFormat = ifmt_ctx->streams[videoIndex]->codec->pix_fmt;
            Size destinationSize = sourceSize;
            AVPixelFormat destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
            using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
            {
                while (ffmpeg.av_read_frame(ifmt_ctx, dec_pkt) >= 0)
                {
                    if (exit_thread == 1)
                    {
                        ffmpeg.av_free_packet(dec_pkt);
                        break;
                    }
                    ffmpeg.av_log(null, ffmpeg.AV_LOG_DEBUG, "Going to reencode the frame\n");
                    pframe = ffmpeg.av_frame_alloc();
                    if (pframe == null)
                    {
                        //ret = ffmpeg.AVERROR(ENOMEM);
                        return -1;
                    }

                    AVStream* in_stream = ifmt_ctx->streams[dec_pkt->stream_index];
                    AVStream* out_stream = ofmt_ctx->streams[dec_pkt->stream_index];

                    //AVRational time_base：时基。通过该值可以把PTS，DTS转化为真正的时间。
                    //先得到流中的time_base
                    AVRational time_base = ofmt_ctx->streams[dec_pkt->stream_index]->time_base;
                    //AV_TIME_BASE_Q 用小数表示的时间基数。等于时间基数的倒数
                    AVRational time_base_q = new AVRational { num = 1, den = ffmpeg.AV_TIME_BASE };
                    //开始处理延迟.只有等于视频的帧，才会处理
                    //if (dec_pkt->stream_index == videoIndex)
                    if(true)
                    {
                        ret = ffmpeg.avcodec_decode_video2(ifmt_ctx->streams[dec_pkt->stream_index]->codec, pframe,
                               &dec_got_frame, dec_pkt);
                        if (ret < 0)
                        {
                            ffmpeg.av_frame_free(&pframe);
                            ffmpeg.av_log(null, ffmpeg.AV_LOG_ERROR, "Decoding failed\n");
                            break;
                        }
                        if (dec_got_frame != 0)
                        {
                            ret = ffmpeg.sws_scale(img_convert_ctx, pframe->data, pframe->linesize, 0, pCodecCtx->height, pFrameYUV->data, pFrameYUV->linesize);

                            if (exit_thread != 1)
                            {
                                #region 展示到窗体中
                                AVFrame convertedFrame = vfc.Convert(pframe);
                                using (var bitmap = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]))
                                {
                                    //var bitmap = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]);
                                    //bitmap.Save("D:\\testCamera.jpg");
                                    camera_action(bitmap);
                                }
                                #endregion
                            }

                            enc_pkt.data = null;
                            enc_pkt.size = 0;
                            ffmpeg.av_init_packet(&enc_pkt);
                            ret = ffmpeg.avcodec_encode_video2(pCodecCtx, &enc_pkt, pFrameYUV, &enc_got_frame);
                            ffmpeg.av_frame_free(&pframe);
                            if (enc_got_frame == 1)
                            {
                                enc_pkt.stream_index = video_st->index;

                                enc_pkt.pts = ffmpeg.av_rescale_q(dec_pkt->pts, in_stream->time_base, out_stream->time_base);
                                enc_pkt.dts = ffmpeg.av_rescale_q(dec_pkt->dts, in_stream->time_base, out_stream->time_base);
                                enc_pkt.duration = (int)ffmpeg.av_rescale_q(dec_pkt->duration, in_stream->time_base, out_stream->time_base);
                                Console.WriteLine("video dts + duration = : " + enc_pkt.dts + " + " + enc_pkt.duration + "=" + (enc_pkt.dts + enc_pkt.duration).ToString());
                                ////再次标记字节流的位置，-1表示不知道字节流的位置
                                //enc_pkt.pos = -1;

                                #region 自己计算dts
                                //没有显示时间的时候，才会进入计算和校验
                                //没有封装格式的裸流（例如H.264裸流）是不包含PTS、DTS这些参数的。在发送这种数据的时候，需要自己计算并写入AVPacket的PTS，DTS，duration等参数。如果没有pts，则进行计算
                                //if (dec_pkt->pts == long.MaxValue || dec_pkt->pts == long.MinValue) // AV_NOPTS_VALUE = ((int64_t)UINT64_C(0x8000000000000000))
                                //{
                                //开始校对pts和 dts.通过time_base和dts转成真正的时间
                                //得到的是每一帧的时间
                                /*
                                r_frame_rate 基流帧速率 。取得是时间戳内最小的帧的速率 。每一帧的时间就是等于 time_base/r_frame_rate
                                av_q2d 转化为double类型
                                */
                                //long calc_duration = Convert.ToInt64((double)ffmpeg.AV_TIME_BASE / ffmpeg.av_q2d(ifmt_ctx->streams[videoIndex]->r_frame_rate));
                                ////配置参数  这些时间，都是通过 av_q2d(time_base) * AV_TIME_BASE 来转成实际的参数
                                //enc_pkt.pts = ffmpeg.av_rescale_q(frame_index * calc_duration, time_base_q, time_base);
                                ////一个GOP中，如果存在B帧的话，只有I帧的dts就不等于pts
                                //enc_pkt.dts = enc_pkt.pts;
                                //enc_pkt.duration = ffmpeg.av_rescale_q(calc_duration, time_base_q, time_base);
                                //}
                                #endregion
                                enc_pkt.pos = -1;

                                //计算视频播放的时间. 公式等于 dec_pkt->dts * time_base / time_base_r`
                                //.其实就是 stream中的time_base和定义的time_base直接的比例
                                long pts_time = ffmpeg.av_rescale_q(enc_pkt.dts, time_base, time_base_q);
                                //计算实际视频的播放时间。 视频实际播放的时间=代码处理的时间？？
                                long now_time = ffmpeg.av_gettime() - start_time;

                                //cout << time_base.num << " " << time_base.den << "  " << dec_pkt->dts << "  " << dec_pkt->pts << "   " << pts_time << endl;
                                //如果显示的pts time 比当前的时间迟，就需要手动让程序睡一会，再发送出去，保持当前的发送时间和pts相同
                                //if (pts_time > now_time)
                                //{
                                //    //睡眠一段时间（目的是让当前视频记录的播放时间与实际时间同步）
                                //    ffmpeg.av_usleep((uint)(pts_time - now_time));
                                //}

                                //如果当前的帧是视频帧，则将我们定义的frame_index往后推
                                //Console.WriteLine("Send %8d video frames to output URL\n", frame_index);

                                //发送！！！
                                ret = ffmpeg.av_interleaved_write_frame(ofmt_ctx, &enc_pkt);
                                ffmpeg.av_free_packet(&enc_pkt);
                                if (ret < 0)
                                {
                                    Console.WriteLine("发送数据包出错\n");
                                    break;
                                }
                                frame_index++;
                            }
                        }
                        else
                        {
                            ffmpeg.av_frame_free(&pframe);
                        }
                    }
                    else
                    {
                        //if (frame_index < 1)
                        //    continue;
                        //重新开始指定时间戳
                        //计算延时后，重新指定时间戳。 这次是根据 in_stream 和 output_stream之间的比例
                        //计算dts时，不再直接用pts，因为如有有B帧，就会不同
                        //pts，dts，duration都也相同
                        dec_pkt->pts = ffmpeg.av_rescale_q_rnd(dec_pkt->pts, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                        dec_pkt->dts = ffmpeg.av_rescale_q_rnd(dec_pkt->dts, in_stream->time_base, out_stream->time_base, AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX);
                        dec_pkt->duration = (int)ffmpeg.av_rescale_q(dec_pkt->duration, in_stream->time_base, out_stream->time_base);
                        Console.WriteLine("audio dts + duration = : " + dec_pkt->dts + " + " + dec_pkt->duration + "=" + (dec_pkt->dts + dec_pkt->duration).ToString());

                        //long calc_duration = Convert.ToInt64((double)ffmpeg.AV_TIME_BASE / ffmpeg.av_q2d(ifmt_ctx->streams[videoIndex]->r_frame_rate));
                        ////配置参数  这些时间，都是通过 av_q2d(time_base) * AV_TIME_BASE 来转成实际的参数
                        //dec_pkt->pts = ffmpeg.av_rescale_q(frame_index * calc_duration, time_base_q, time_base);
                        ////一个GOP中，如果存在B帧的话，只有I帧的dts就不等于pts
                        //dec_pkt->dts = dec_pkt->pts;
                        //dec_pkt->duration = ffmpeg.av_rescale_q(calc_duration, time_base_q, time_base);

                        //再次标记字节流的位置，-1表示不知道字节流的位置
                        dec_pkt->pos = -1;

                        //发送！！！
                        ret = ffmpeg.av_interleaved_write_frame(ofmt_ctx, dec_pkt);
                        if (ret < 0)
                        {
                            Console.WriteLine("发送数据包出错\n");
                            break;
                        }
                    }
                    ffmpeg.av_free_packet(dec_pkt);

                }
            }

        stop:
            //Flush Encoder
            ret = Flush_Encoder(ifmt_ctx, ofmt_ctx, 0, frame_index);
            if (ret < 0)
            {
                Console.WriteLine("Flushing encoder failed\n");
                return -1;
            }


            ////Write file trailer
            //ffmpeg.av_write_trailer(ofmt_ctx);


            ////Clean
            //if (video_st != null)
            //    ffmpeg.avcodec_close(video_st->codec);
            //ffmpeg.av_free(out_buffer);
            //ffmpeg.av_free(pFrameYUV);
            //ffmpeg.avio_close(ofmt_ctx->pb);
            //ffmpeg.avformat_free_context(ofmt_ctx);
            //ffmpeg.avformat_close_input(&ifmt_ctx);
            //ffmpeg.avformat_free_context(ifmt_ctx);
            //CloseHandle(hThread);

            //写文件尾（Write file trailer）  
            ffmpeg.av_write_trailer(ofmt_ctx);


            //Clean
            if (ofmt_ctx->streams[videoIndex] != null)
                ffmpeg.avcodec_close(ofmt_ctx->streams[videoIndex]->codec);
            ffmpeg.av_free(out_buffer);
            ffmpeg.av_free(pFrameYUV);
            ffmpeg.avio_close(ofmt_ctx->pb);
            ffmpeg.avformat_close_input(&ifmt_ctx);
            ffmpeg.avformat_free_context(ofmt_ctx);
            //ffmpeg.avformat_close_input(&ifmt_ctx);
            ///* close output */
            //if (ifmt_ctx != null && ((ofmt_ctx->flags & ffmpeg.AVFMT_NOFILE) == 0))
            //    ffmpeg.avio_close(ofmt_ctx->pb);
            //ffmpeg.avformat_free_context(ofmt_ctx);
            return 0;
        }



        private int Flush_Encoder(AVFormatContext* ifmt_ctx, AVFormatContext* ofmt_ctx, uint stream_index, long framecnt)
        {
            int ret;
            int got_frame;
            AVPacket enc_pkt;
            if ((ofmt_ctx->streams[stream_index]->codec->codec->capabilities & 0x0020 /*CODEC_CAP_DELAY*/) != 0)
                return 0;
            while (true)
            {
                enc_pkt.data = null;
                enc_pkt.size = 0;
                ffmpeg.av_init_packet(&enc_pkt);
                ret = ffmpeg.avcodec_encode_video2(ofmt_ctx->streams[stream_index]->codec, &enc_pkt, null, &got_frame);
                ffmpeg.av_frame_free(null);
                if (ret < 0)
                    break;
                if (got_frame == 0)
                {
                    ret = 0;
                    break;
                }
                Console.WriteLine("Flush Encoder: Succeed to encode 1 frame!\tsize:" + enc_pkt.size);


                //Write PTS
                AVRational time_base = ofmt_ctx->streams[stream_index]->time_base;//{ 1, 1000 };
                AVRational r_framerate1 = ifmt_ctx->streams[stream_index]->r_frame_rate;// { 50, 2 };
                AVRational time_base_q = new AVRational { num = 1, den = ffmpeg.AV_TIME_BASE };
                //Duration between 2 frames (us)
                long calc_duration = Convert.ToInt64((double)(ffmpeg.AV_TIME_BASE) * (1 / ffmpeg.av_q2d(r_framerate1)));    //内部时间戳
                //Parameters
                enc_pkt.pts = ffmpeg.av_rescale_q(framecnt * calc_duration, time_base_q, time_base);
                enc_pkt.dts = enc_pkt.pts;
                enc_pkt.duration = ffmpeg.av_rescale_q(calc_duration, time_base_q, time_base);


                /* copy packet*/
                //转换PTS/DTS（Convert PTS/DTS）
                enc_pkt.pos = -1;
                framecnt++;
                ofmt_ctx->duration = enc_pkt.duration * framecnt;


                /* mux encoded frame */
                ret = ffmpeg.av_interleaved_write_frame(ofmt_ctx, &enc_pkt);
                if (ret < 0)
                    break;
            }
            return ret;
        }
    }
}
