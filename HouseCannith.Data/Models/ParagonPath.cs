using System;
using System.Collections.Generic;

namespace HouseCannith.Data.Models
{
    public partial class ParagonPath
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string SourceBook { get; set; }
        public string Content { get; set; }
    }
}
