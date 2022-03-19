using DownKyi.Core.BiliApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DownKyi.Core.BiliApi.VideoStream.Models
{
    public class Node : BaseModel
    {
        [JsonProperty("edge_id")]
        public long EdgeId { get; set; }
        [JsonProperty("node_id")]
        public long NodeId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("cid")]
        public long Cid { get; set; }
        [JsonProperty("start_pos")]
        public string StartPos { get; set; }
        [JsonProperty("cover")]
        public string Cover { get; set; }
    }
}
