using Betting.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entities.ViewModels
{
    public class MessageViewModel : Message
    {
        public int[] TargetClients { get; set; }
    }
}
