using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entities.ViewModels
{
    public class ResultViewModel
    {
        public dynamic Entity { get; set; }
        public bool IsComplete { get; set; }
        public bool HasErrors { get; set; }
        public List<string> Messages { get; set; }
        public string Token { get; set; }

        public ResultViewModel(dynamic entity, bool isComplete, bool hasErrors, List<string> messages)
        {
            this.Entity = entity;
            this.IsComplete = isComplete;
            this.HasErrors = hasErrors;
            this.Messages = messages;
        }

        public ResultViewModel()
        {
            this.IsComplete = false;
        }

        public void AddMessage(string message)
        {
            if (Messages == null)
                Messages = new List<string>();

            Messages.Add(message);
        }
    }
}
