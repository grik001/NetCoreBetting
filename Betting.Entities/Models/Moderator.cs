using System;
using System.Collections.Generic;

namespace Betting.Entities.Models
{
    public partial class Moderator
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
