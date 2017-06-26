using System;
using System.Collections.Generic;

namespace HouseCannith.Data.Models
{
    public partial class Ritual
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string ComponentCost { get; set; }
        public string Price { get; set; }
        public string KeySkillDescription { get; set; }
        public string SourceBook { get; set; }
        public string Content { get; set; }
    }
}
