using System.Collections.Generic;
using Newtonsoft.Json;

namespace LisaBot.Models.Guides
{
    public class Category
    {
        [JsonIgnore] //Ignore because we do not need this when saving/reading from file (not sure tho)
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("list")]
        public IList<Guide> Guides { get; set; }
        [JsonIgnore]
        public IList<Tag> Tags { get; set; }
    }
}
