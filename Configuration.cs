using Newtonsoft.Json;

namespace LisaBot
{
    public struct Configuration
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
