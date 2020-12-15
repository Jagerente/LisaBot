using Newtonsoft.Json;

namespace LisaBot.Modules.Guides
{
    public class Category
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("list")]
        public Guide[] List { get; set; }
        
    }
    public class Guide
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }
    }

    public class Info
    {
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("premium")]
        public bool Premium { get; set; }
        [JsonProperty("earlyAccess")]
        public bool EarlyAccess { get; set; }
    }
}