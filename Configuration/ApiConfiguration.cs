using Newtonsoft.Json;

namespace LisaBot.Configuration
{
    public class ApiConfiguration
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
