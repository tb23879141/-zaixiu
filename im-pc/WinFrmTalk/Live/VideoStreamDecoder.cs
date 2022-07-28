using FFmpeg.AutoGen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmTalk.Live
{
    public sealed unsafe class VideoStreamDecoder : IDisposable
    {
        private readonly AVCodecContext* _pCodecContext;
        private readonly AVFormatContext* _pFormatContext;
        private readonly int _streamIndex;
        private readonly AVFrame* _pFrame;
        private readonly AVPacket* _pPacket;

        public VideoStreamDecoder(string url, ref bool result)
        {
            try
            {
                //创建一个内存
                _pFormatContext = ffmpeg.avformat_alloc_context();

                var pFormatContext = _pFormatContext;
                //写入
                ffmpeg.avformat_open_input(&pFormatContext, url, null, null).ThrowExceptionIfError();

                ffmpeg.avformat_find_stream_info(_pFormatContext, null).ThrowExceptionIfError();

                //查找第一个视频流
                AVStream* pStream = null;
                for (var i = 0; i < _pFormatContext->nb_streams; i++)
                    if (_pFormatContext->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                    {
                        pStream = _pFormatContext->streams[i];
                        break;
                    }

                if (pStream == null) throw new InvalidOperationException("Could not found video stream.");

                _streamIndex = pStream->index;
                _pCodecContext = pStream->codec;

                var codecId = _pCodecContext->codec_id;
                var pCodec = ffmpeg.avcodec_find_decoder(codecId);
                if (pCodec == null) throw new InvalidOperationException("Unsupported codec.");

                ffmpeg.avcodec_open2(_pCodecContext, pCodec, null).ThrowExceptionIfError();

                CodecName = ffmpeg.avcodec_get_name(codecId);
                FrameSize = new Size(_pCodecContext->width, _pCodecContext->height);
                PixelFormat = _pCodecContext->pix_fmt;

                _pPacket = ffmpeg.av_packet_alloc();
                _pFrame = ffmpeg.av_frame_alloc();

                result = true;
            }
            catch (Exception ex)
            {
                LogHelper.log.Error("-------------连接直播时出错：", ex);
                result = false;
            }
        }

        public void GetAVFormatContext(string out_filename)
        {

            AVFormatContext* ofmt_ctx;
            ffmpeg.avformat_alloc_output_context2(&ofmt_ctx, null, "flv", out_filename); //RTMP

            ffmpeg.av_interleaved_write_frame(ofmt_ctx, _pPacket);
            //查找第一个视频流
            AVStream* pStream = null;
            for (var i = 0; i < _pFormatContext->nb_streams; i++)
                if (_pFormatContext->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    pStream = _pFormatContext->streams[i];
                    AVStream* out_stream = ffmpeg.avformat_new_stream(ofmt_ctx, pStream->codec->codec);
                    break;
                }

        }



        public string CodecName { get; }
        public Size FrameSize { get; }
        public AVPixelFormat PixelFormat { get; }

        public void Dispose()
        {
            ffmpeg.av_frame_unref(_pFrame);
            ffmpeg.av_free(_pFrame);

            ffmpeg.av_packet_unref(_pPacket);
            ffmpeg.av_free(_pPacket);

            ffmpeg.avcodec_close(_pCodecContext);
            var pFormatContext = _pFormatContext;
            ffmpeg.avformat_close_input(&pFormatContext);
        }

        public bool TryDecodeNextFrame(out AVFrame frame)
        {
            ffmpeg.av_frame_unref(_pFrame);
            int error;
            do
            {
                try
                {
                    do
                    {
                        error = ffmpeg.av_read_frame(_pFormatContext, _pPacket);
                        if (error == ffmpeg.AVERROR_EOF)
                        {
                            frame = *_pFrame;
                            return false;
                        }

                        error.ThrowExceptionIfError();
                    } while (_pPacket->stream_index != _streamIndex);

                    ffmpeg.avcodec_send_packet(_pCodecContext, _pPacket).ThrowExceptionIfError();
                }
                finally
                {
                    ffmpeg.av_packet_unref(_pPacket);
                }

                error = ffmpeg.avcodec_receive_frame(_pCodecContext, _pFrame);
            } while (error == ffmpeg.AVERROR(ffmpeg.EAGAIN));

            error.ThrowExceptionIfError();
            frame = *_pFrame;
            return true;
        }

        public IReadOnlyDictionary<string, string> GetContextInfo()
        {
            AVDictionaryEntry* tag = null;
            var result = new Dictionary<string, string>();
            while ((tag = ffmpeg.av_dict_get(_pFormatContext->metadata, "", tag, ffmpeg.AV_DICT_IGNORE_SUFFIX)) != null)
            {
                var key = Marshal.PtrToStringAnsi((IntPtr)tag->key);
                var value = Marshal.PtrToStringAnsi((IntPtr)tag->value);
                result.Add(key, value);
            }

            return result;
        }
    }
}
