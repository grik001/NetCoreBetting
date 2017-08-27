using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Collections.Generic;
using Betting.Entities.Models;
using System.Linq;
using Betting.Entities.ViewModels;
using System;
using Betting.Data.DataModels.BrandX;
using Betting.Data.DataModels;

namespace Betting.API.REST.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private IGameDataModel _gameDataModel;

        public GamesController(IGameDataModel gameDataModel)
        {
            this._gameDataModel = gameDataModel;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]bool? status = true)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                List<Game> games = null;
                games = _gameDataModel.Get();
                games = games.Where(x => x.IsActive == status).ToList();

                result.Entity = games;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                //Log
                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                Game game = null;
                game = _gameDataModel.Get(id);

                result.Entity = game;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]Game game)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                if (!_gameDataModel.Exists(game.Code))
                {
                    game.EntryTime = DateTime.UtcNow;
                    game = _gameDataModel.Insert(game);
                }

                result.Entity = game;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                //Log
                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Game game)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var gameDb = _gameDataModel.Get(id);

                if (gameDb != null)
                {
                    gameDb.Code = game.Code;
                    gameDb.Description = game.Description;
                    gameDb.IsActive = game.IsActive;
                    gameDb = _gameDataModel.Update(gameDb);

                    result.IsComplete = true;
                    result.Entity = gameDb;
                }
            }
            catch (Exception ex)
            {
                //Log
                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpPut("{id}/{status}")]
        public IActionResult Put(int id, bool status)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var gameDb = _gameDataModel.Get(id);

                if (gameDb != null)
                {
                    gameDb.IsActive = status;
                    gameDb = _gameDataModel.Update(gameDb);

                    result.IsComplete = true;
                    result.Entity = gameDb;
                }

            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var deleted = _gameDataModel.Delete(id);
                result.Entity = id;
                result.IsComplete = deleted;

                if (!deleted)
                {
                    this.Response.StatusCode = 400;
                }
            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

    }
}