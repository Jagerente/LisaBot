using System;
using System.Collections.Generic;
using System.Text;

using LisaBot.Models.Guides;

namespace LisaBot.Models
{
    public class TagGuide
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public Guide GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
