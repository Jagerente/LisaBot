using Newtonsoft.Json;

namespace LisaBot.Modules.Guides
{
    public class Category
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("list")]
        public Guide[] List { get; set; }

        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            builder.AppendLine($"Title: {Title}");

            builder.Append("List: \n");

            foreach (Guide guide in List)
            {
                builder.AppendLine(guide.ToString());
            }

            return builder.ToString();
        }

    }
    public class Guide
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }

        public override string ToString()
        {
            return $"{Title}, {Info.ToString()}";
        }
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

        public override string ToString()
        {
            return $"Link: {Link}, desc: {Description}, premium: {Premium}, early? {EarlyAccess}";
        }
    }
}