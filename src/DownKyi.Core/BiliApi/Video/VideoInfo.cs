﻿using DownKyi.Core.BiliApi.Video.Models;
using DownKyi.Core.BiliApi.VideoStream.Models;
using DownKyi.Core.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DownKyi.Core.BiliApi.Video
{
    public static class VideoInfo
    {
        /// <summary>
        /// 获取视频详细信息(web端)
        /// </summary>
        /// <param name="bvid"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static VideoView VideoViewInfo(string bvid = null, long aid = -1)
        {
            // https://api.bilibili.com/x/web-interface/view/detail?bvid=BV1Sg411F7cb&aid=969147110&need_operation_card=1&web_rm_repeat=1&need_elec=1&out_referer=https%3A%2F%2Fspace.bilibili.com%2F42018135%2Ffavlist%3Ffid%3D94341835
            string baseUrl = "https://api.bilibili.com/x/web-interface/view";
            string referer = "https://www.bilibili.com";
            string url;
            if (bvid != null) { url = $"{baseUrl}?bvid={bvid}"; }
            else if (aid > -1) { url = $"{baseUrl}?aid={aid}"; }
            else { return null; }

            string response = WebClient.RequestWeb(url, referer);

            try
            {
                var videoView = JsonConvert.DeserializeObject<VideoViewOrigin>(response);
                if (videoView != null) { return videoView.Data; }
                else { return null; }
            }
            catch (Exception e)
            {
                Utils.Debugging.Console.PrintLine("VideoInfo()发生异常: {0}", e);
                LogManager.Error("VideoInfo", e);
                return null;
            }
        }

        /// <summary>
        /// 获取视频简介
        /// </summary>
        /// <param name="bvid"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static string VideoDescription(string bvid = null, long aid = -1)
        {
            string baseUrl = "https://api.bilibili.com/x/web-interface/archive/desc";
            string referer = "https://www.bilibili.com";
            string url;
            if (bvid != null) { url = $"{baseUrl}?bvid={bvid}"; }
            else if (aid >= -1) { url = $"{baseUrl}?aid={aid}"; }
            else { return null; }

            string response = WebClient.RequestWeb(url, referer);

            try
            {
                var desc = JsonConvert.DeserializeObject<VideoDescription>(response);
                if (desc != null) { return desc.Data; }
                else { return null; }
            }
            catch (Exception e)
            {
                Utils.Debugging.Console.PrintLine("VideoDescription()发生异常: {0}", e);
                LogManager.Error("VideoInfo", e);
                return null;
            }
        }

        /// <summary>
        /// 查询视频分P列表 (avid/bvid转cid)
        /// </summary>
        /// <param name="bvid"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static List<VideoPage> VideoPagelist(string bvid = null, long aid = -1)
        {
            string baseUrl = "https://api.bilibili.com/x/player/pagelist";
            string referer = "https://www.bilibili.com";
            string url;
            if (bvid != null) { url = $"{baseUrl}?bvid={bvid}"; }
            else if (aid > -1) { url = $"{baseUrl}?aid={aid}"; }
            else { return null; }

            string response = WebClient.RequestWeb(url, referer);

            try
            {
                var pagelist = JsonConvert.DeserializeObject<VideoPagelist>(response);
                if (pagelist != null) { return pagelist.Data; }
                else { return null; }
            }
            catch (Exception e)
            {
                Utils.Debugging.Console.PrintLine("VideoPagelist()发生异常: {0}", e);
                LogManager.Error("VideoInfo", e);
                return null;
            }
        }

        /// <summary>
        /// 查询互动视频节点列表
        /// </summary>
        /// <param name="bvid"></param>
        /// <returns></returns>
        public static EdgeInfoV2 VideoNodelist(string bvid ,long graphVersion,long edgeId)
        {
            string baseUrl = "https://api.bilibili.com/x/stein/edgeinfo_v2";
            string referer = "https://www.bilibili.com";
            string url = $"{baseUrl}?bvid={bvid}&graph_version={graphVersion}&edge_id={edgeId}";

            string response = WebClient.RequestWeb(url, referer);

            try
            {
                var nodelist = JsonConvert.DeserializeObject<EdgeInfoV2Origin>(response);
                if (nodelist != null) { return nodelist.Data; }
                else { return null; }
            }
            catch (Exception e)
            {
                Utils.Debugging.Console.PrintLine("VideoNodelist()发生异常: {0}", e);
                LogManager.Error("VideoInfo", e);
                return null;
            }
        }
    }
}
