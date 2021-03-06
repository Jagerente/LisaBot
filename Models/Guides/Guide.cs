﻿using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LisaBot.Models.Guides
{
    public class Guide
    {
        //[JsonProperty("id")]
        [JsonIgnore] //Ignoring because we do not need this info while saving?
        public int Id { get; set; }

        [JsonIgnore] //Ignoring this property because it is used for linking to Category from DB, but we do not need this in case of saving JSON
        public Category Category { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("info")]
        public GuideInfo Information { get; set; }

        [JsonIgnore]
        public string TagString { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string[] Tags
        {
            get
            {
                return TagString.Split('/');
            }
        }

        //[JsonIgnore]
        //public IList<TagGuide> GuideTags { get; set; }
    }
}
