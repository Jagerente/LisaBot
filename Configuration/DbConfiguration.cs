using Newtonsoft.Json;

namespace LisaBot.Configuration
{
    public class DbConfiguration
    {
        [JsonProperty("host")]
        public string Host { get; set; }
        [JsonProperty("port")]
        public string Port { get; set; }
        [JsonProperty("database")]
        public string Database { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
