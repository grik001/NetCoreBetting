using Betting.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Data.DataModels.BrandX
{
    public interface IMessageDataModel
    {
        List<Message> Get();

        List<Message> GetDescending(int? limit = null);

        Message Get(int id);

        Message Insert(Message message);

        Message Update(Message message);

        bool Delete(int id);
    }
}
