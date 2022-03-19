using DownKyi.Core.BiliApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DownKyi.Core.BiliApi.VideoStream.Models
{
    public class InteractionInfo : BaseModel
    {
        [JsonProperty("error_toast")]
        public string ErrorToast { get; set; }
        [JsonProperty("graph_version")]
        public long GraphVersion { get; set; }
        [JsonProperty("history_node")]
        public Node HistoryNode { get; set; }
        [JsonProperty("mark")]
        public long Mark { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("need_reload")]
        public long NeedReload { get; set; }
    }
}
