using Betting.Common.Helpers.IHelpers;
using Betting.Data.DataModels.BrandX;
using Betting.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Betting.Common.Constants;

namespace Betting.API.REST.Helpers
{
    public class GamesCacheHelper
    {
        private IGameDataModel _gameDataModel;
        private ICacheHelper _cacheHelper;

        public GamesCacheHelper(IGameDataModel gameDataModel, ICacheHelper cachehelper)
        {
            this._gameDataModel = gameDataModel;
            this._cacheHelper = cachehelper;
        }

        public void RefreshGameCache()
        {
            List<Game> games = null;
            games = _gameDataModel.Get();
            _cacheHelper.SetData<List<Game>>(CacheKey.GameList.ToString(), games);
        }
    }
}
