using System;
using System.Collections.Generic;

namespace HouseCannith.Data.Models
{
    public partial class Glossary
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string SourceBook { get; set; }
        public string Content { get; set; }
    }
}
