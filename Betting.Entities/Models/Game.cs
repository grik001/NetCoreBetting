using System;
using System.Collections.Generic;

namespace Betting.Entities.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
