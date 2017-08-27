using Betting.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Data.DataModels.BrandX
{
    public interface IGameDataModel
    {
        List<Game> Get();

        Game Get(int id);

        Game Insert(Game game);

        Game Update(Game game);

        bool Delete(int id);

        bool Exists(string code);
        bool Exists(int id);
    }
}
