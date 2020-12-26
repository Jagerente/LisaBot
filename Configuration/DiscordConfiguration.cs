using Newtonsoft.Json;

namespace LisaBot.Configuration
{
    public class DiscordConfiguration : ApiConfiguration
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
