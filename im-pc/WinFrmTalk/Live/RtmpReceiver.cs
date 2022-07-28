using FFmpeg.AutoGen;
using System;
using System.IO;
using System.Threading;
using WinFrmTalk.Helper.MVVM;

namespace WinFrmTalk.Live
{
    public sealed unsafe class RtmpReceiver
    {
        [Obsolete]
        public static unsafe void ReceiverRtmp(object wMPPlay)
        {
            //'1': Use H.264 Bitstream Filter 
            const int USE_H264BSF = 0;
            //是否正在播放中，如果是则不再触发回调
            bool isPlaying = false;
            AVBitStreamFilterContext* h264bsfc = null;
            AVOutputFormat* ofmt = null;
            //Input AVFormatContext and Output AVFormatContext
            AVFormatContext* ifmt_ctx = null, ofmt_ctx = null;
            AVPacket pkt;
            string in_filename, out_filename;
            int ret, i;
            int videoindex = -1;
            int frame_index = 0;
            //in_filename  = "rtp://233.233.233.233:6666";
            //out_filename = "receive.ts";
            //out_filename = "receive.mkv";
            
            if (wMPPlay is WMPPlay wMPPlay1)
            {
                in_filename = wMPPlay1.rtmp_url;
                out_filename = wMPPlay1.outFile_url;
            }
            else
            {
                HttpUtils.Instance.ShowTip("传递的参数不正确。");
                ret = -1;
                goto end;
            }

            //if (File.Exists(out_filename))
            //    File.Delete(out_filename);

            ffmpeg.av_register_all();
            //Network
            ffmpeg.avformat_network_init();
            //Input
            if ((ret = ffmpeg.avformat_open_input(&ifmt_ctx, in_filename, null, null)) < 0)
            {
                Console.WriteLine("Could not open input file.");
                goto end;
            }
            if ((ret = ffmpeg.avformat_find_stream_info(ifmt_ctx, null)) < 0)
            {
                Console.WriteLine("Failed to retrieve input stream information");
                goto end;
            }

            for (i = 0; i < ifmt_ctx->nb_streams; i++)
                if (ifmt_ctx->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    videoindex = i;
                    break;
                }

            //RTMP
            ffmpeg.av_dump_format(ifmt_ctx, 0, in_filename, 0);

            //Output
            ffmpeg.avformat_alloc_output_context2(&ofmt_ctx, null, null, out_filename);

            if (ofmt_ctx == null)
            {
                Console.WriteLine("Could not create output context\n");
                ret = ffmpeg.AVERROR_UNKNOWN;
                goto end;
            }
            ofmt = ofmt_ctx->oformat;
            for (i = 0; i < ifmt_ctx->nb_streams; i++)
            {
                //Create output AVStream according to input AVStream
                AVStream* in_stream = ifmt_ctx->streams[i];
                AVStream* out_stream = ffmpeg.avformat_new_stream(ofmt_ctx, in_stream->codec->codec);
                if (out_stream == null)
                {
                    Console.WriteLine("Failed allocating output stream\n");
                    ret = ffmpeg.AVERROR_UNKNOWN;
                    goto end;
                }
                //Copy the settings of AVCodecContext
                ret = ffmpeg.avcodec_copy_context(out_stream->codec, in_stream->codec);
                if (ret < 0)
                {
                    Console.WriteLine("Failed to copy context from input to output stream codec context\n");
                    goto end;
                }
                out_stream->codec->codec_tag = 0;
                if ((ofmt_ctx->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) != 0)
                    out_stream->codec->flags |= 0x00400000; //CODEC_FLAG_GLOBAL_HEADER
            }
            //Dump Format------------------
            ffmpeg.av_dump_format(ofmt_ctx, 0, out_filename, 1);
            //Open output URL
            if ((ofmt->flags & ffmpeg.AVFMT_NOFILE) == 0)
            {
                ret = ffmpeg.avio_open(&ofmt_ctx->pb, out_filename, ffmpeg.AVIO_FLAG_WRITE);
                if (ret < 0)
                {
                    Console.WriteLine("Could not open output URL '" + out_filename + "'");
                    goto end;
                }
            }
            //Write file header
            ret = ffmpeg.avformat_write_header(ofmt_ctx, null);
            if (ret < 0)
            {
                Console.WriteLine("Error occurred when opening output URL\n");
                goto end;
            }

            if (USE_H264BSF == 1)
            {
                h264bsfc = ffmpeg.av_bitstream_filter_init("h264_mp4toannexb");
            }

            while (true)
            {
                AVStream* in_stream, out_stream;
                //Get an AVPacket
                ret = ffmpeg.av_read_frame(ifmt_ctx, &pkt);
                if (ret < 0)
                    break;

                in_stream = ifmt_ctx->streams[pkt.stream_index];
                out_stream = ofmt_ctx->streams[pkt.stream_index];
                /* copy packet */
                //Convert PTS/DTS
                pkt.pts = ffmpeg.av_rescale_q_rnd(pkt.pts, in_stream->time_base, out_stream->time_base, (AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX));
                pkt.dts = ffmpeg.av_rescale_q_rnd(pkt.dts, in_stream->time_base, out_stream->time_base, (AVRounding.AV_ROUND_NEAR_INF | AVRounding.AV_ROUND_PASS_MINMAX));
                pkt.duration = ffmpeg.av_rescale_q(pkt.duration, in_stream->time_base, out_stream->time_base);
                pkt.pos = -1;
                //Print to Screen
                if (pkt.stream_index == videoindex)
                {
                    //Console.WriteLine("Receive "+ frame_index + " video frames from input URL\n");
                    frame_index++;

                    if (USE_H264BSF == 1)
                    {
                        ffmpeg.av_bitstream_filter_filter(h264bsfc, in_stream->codec, null, &pkt.data, &pkt.size, pkt.data, pkt.size, 0);
                    }
                }
                //ret = av_write_frame(ofmt_ctx, &pkt);
                ret = ffmpeg.av_interleaved_write_frame(ofmt_ctx, &pkt);

                if (ret < 0)
                {
                    Console.WriteLine("Error muxing packet\n");
                    break;
                }

                ffmpeg.av_free_packet(&pkt);

                //拉流直播成功
                if (File.Exists(out_filename) && new FileInfo(out_filename).Length > 500000 && !isPlaying)
                {
                    //    Messenger.Default.Send(out_filename, token: EQFrmInteraction.StartPlayFlvByRtmp);
                    isPlaying = true;
                    wMPPlay1.action();
                }
            }

            if (USE_H264BSF == 1)
            {
                ffmpeg.av_bitstream_filter_close(h264bsfc);
            }

            //Write file trailer
            ffmpeg.av_write_trailer(ofmt_ctx);
        end:
            ffmpeg.avformat_close_input(&ifmt_ctx);
            /* close output */
            if (ofmt_ctx != null && (ofmt->flags & ffmpeg.AVFMT_NOFILE) == 0)
                ffmpeg.avio_close(ofmt_ctx->pb);
            ffmpeg.avformat_free_context(ofmt_ctx);
            if (ret < 0 && ret != ffmpeg.AVERROR_EOF)
            {
                Console.WriteLine("Error occurred.\n");
                //return -1;
                return;
            }
            //return 0;
            return;
        }
    }
}
