using System.Collections.Generic;
using Newtonsoft.Json;

using LisaBot.Models.Guides;

namespace LisaBot.Models
{
    public class Tag
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public IList<Category> RelatedCategories { get; set; }

        [JsonIgnore]
        public IList<Guide> RelatedGuides { get; set; }
    }
}
