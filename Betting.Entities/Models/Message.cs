using System;
using System.Collections.Generic;

namespace Betting.Entities.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? SendOn { get; set; }
        public string TargetClientId { get; set; }
    }
}
