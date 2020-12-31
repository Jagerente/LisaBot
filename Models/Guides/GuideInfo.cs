using Newtonsoft.Json;

namespace LisaBot.Models.Guides
{
    public class GuideInfo
    {
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("premium")]
        public bool IsPremium { get; set; }
        [JsonProperty("earlyAccess")]
        public bool IsEarlyAccess { get; set; }

        public override string ToString()
        {
            return $"Link: {Link}, desc: {Description}, premium: {IsPremium}, early? {IsEarlyAccess}";
        }
    }
}
