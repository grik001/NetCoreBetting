using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Betting.Entities.Models;
using Betting.Data.DataModels.BrandX;

namespace Betting.Data.DataModels
{
    public class MessageDataModel : IMessageDataModel
    {
        public List<Message> Get()
        {
            using (var context = new BrandxStoreContext())
            {
                return context.Message.ToList();
            }
        }

        public List<Message> GetDescending(int? limit = null)
        {
            using (var context = new BrandxStoreContext())
            {
                var query = context.Message.OrderByDescending(x => x.EntryTime);

                if (!limit.HasValue)
                {
                    return query.ToList();
                }
                else
                {
                    return query.Take(limit.Value).ToList();
                }
            }
        }

        public Message Get(int id)
        {
            using (var context = new BrandxStoreContext())
            {
                return context.Message.FirstOrDefault(x => x.Id == id);
            }
        }

        public Message Insert(Message message)
        {
            using (var context = new BrandxStoreContext())
            {

                context.Add(message);
                context.SaveChanges();
                return message;
            }
        }

        public Message Update(Message message)
        {
            using (var context = new BrandxStoreContext())
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
                return message;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new BrandxStoreContext())
            {
                var value = context.Message.FirstOrDefault(x => x.Id == id);

                if (value != null)
                {
                    context.Remove(value);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
