﻿using System;
using System.Collections.Generic;

namespace HouseCannith.Data.Models
{
    public partial class Item
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Cost { get; set; }
        public string Rarity { get; set; }
        public string SourceBook { get; set; }
        public string Content { get; set; }
    }
}
