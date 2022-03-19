using DownKyi.Core.BiliApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using DownKyi.Core.BiliApi.VideoStream.Models;

namespace DownKyi.Core.BiliApi.Video.Models
{
    public class EdgeInfoV2Origin : BaseModel
    {
        //[JsonProperty("code")]
        //public int Code { get; set; }
        //[JsonProperty("message")]
        //public string Message { get; set; }
        //[JsonProperty("ttl")]
        //public int Ttl { get; set; }
        [JsonProperty("data")]
        public EdgeInfoV2 Data { get; set; }
    }

    public class EdgeInfoV2Choice : BaseModel
    {
        [JsonProperty("cid")]
        public long Cid { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("is_default")]
        public long isDefault { get; set; }
        [JsonProperty("native_action")]
        public string nativeAction { get; set; }
        [JsonProperty("option")]
        public string option { get; set; }
        [JsonProperty("platform_action")]
        public string platformAction { get; set; }
    }

    public class EdgeInfoV2Questions : BaseModel
    {
        [JsonProperty("choices")]
        public List<EdgeInfoV2Choice> choices { get; set; }
        [JsonProperty("duration")]
        public long duration { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("pause_video")]
        public long pauseVideo { get; set; }
        [JsonProperty("start_time_r")]
        public long startTimeR { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("type")]
        public long type { get; set; }
    }

    public class EdgeInfoV2Edges : BaseModel
    {
        [JsonProperty("questions")]
        public List<EdgeInfoV2Questions> questions { get; set; }
    }

    public class EdgeInfoV2 : BaseModel
    {
        [JsonProperty("edge_id")]
        public long edgeId { get; set; }
        [JsonProperty("edges")]
        public EdgeInfoV2Edges edges { get; set; }
        [JsonProperty("story_list")]
        public List<Node> StoryList { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
