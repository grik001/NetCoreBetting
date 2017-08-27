using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Betting.Entities.Models;
using Betting.Data.DataModels.BrandX;

namespace Betting.Data.DataModels
{
    public class GameDataModel : IGameDataModel
    {
        public List<Game> Get()
        {
            using (var context = new BrandxStoreContext())
            {
                return context.Game.ToList();
            }
        }

        public Game Get(int id)
        {
            using (var context = new BrandxStoreContext())
            {
                return context.Game.FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Exists(string code)
        {
            using (var context = new BrandxStoreContext())
            {
                var searchCode = context.Game.Select(x => x.Code).FirstOrDefault(x => x == code);
                return string.IsNullOrEmpty(searchCode) ? false : true;
            }
        }

        public bool Exists(int id)
        {
            using (var context = new BrandxStoreContext())
            {
                int? searchId = context.Game.Select(x => x.Id).FirstOrDefault(x => x == id);
                return searchId == null ? false : true;
            }
        }

        public Game Insert(Game game)
        {
            using (var context = new BrandxStoreContext())
            {

                context.Add(game);
                context.SaveChanges();
                return game;
            }
        }

        public Game Update(Game game)
        {
            using (var context = new BrandxStoreContext())
            {
                context.Entry(game).State = EntityState.Modified;
                context.SaveChanges();
                return game;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new BrandxStoreContext())
            {
                var value = context.Game.FirstOrDefault(x => x.Id == id);

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
