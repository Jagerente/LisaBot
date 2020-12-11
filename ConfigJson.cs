using Newtonsoft.Json;

namespace LisaBot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
