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
using Betting.Common.Helpers.IHelpers;
using static Betting.Common.Constants;
using System.Net;
using Betting.API.REST.Helpers;
using Betting.API.REST.Helpers.WebSocketHelpers;
using Microsoft.Extensions.Logging;

namespace Betting.API.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private IGameDataModel _gameDataModel;
        private ICacheHelper _cacheHelper;
        private INotificationsMessageHandler _notificationsMessageHandler { get; set; }
        private ILogger _logger { get; set; }


        public GamesController(IGameDataModel gameDataModel, ICacheHelper cachehelper, INotificationsMessageHandler notificationsMessageHandler
            ,ILogger<GamesController> logger)
        {
            this._gameDataModel = gameDataModel;
            this._cacheHelper = cachehelper;
            this._notificationsMessageHandler = notificationsMessageHandler;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]bool? status)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Get values supplied : status {status}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString(); 

            try
            {
                List<Game> games = null;
                games = _cacheHelper.GetData<List<Game>>(CacheKey.GameList.ToString());

                if (games == null)
                {
                    games = _gameDataModel.Get();
                    _cacheHelper.SetData<List<Game>>(CacheKey.GameList.ToString(), games);
                }

                if (status.HasValue)
                    games = games.Where(x => x.IsActive == status).ToList();

                games = games.OrderBy(x => x.Code).ToList();

                result.Entity = games;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Get Game failed values supplied : status {status}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Get processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Get-ByID values supplied : id {id}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                Game game = null;
                game = _gameDataModel.Get(id);

                result.Entity = game;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Get-ByID Game failed values supplied : id {id}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Get-ByID processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]Game game)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Insert values supplied : game {JsonConvert.SerializeObject(game)}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                if (game != null && !_gameDataModel.Exists(game.Code) && !String.IsNullOrWhiteSpace(game.Code))
                {
                    game.EntryTime = DateTime.UtcNow;
                    game = _gameDataModel.Insert(game);

                    new GamesCacheHelper(_gameDataModel, _cacheHelper).RefreshGameCache();
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToAll(SocketMessageType.SingleGame, game);
                    result.IsComplete = true;
                }

                result.Entity = game;
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Insert Message failed values supplied : game {JsonConvert.SerializeObject(game)}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Insert processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Game game)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Put values supplied : id {id} - game {JsonConvert.SerializeObject(game)}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                var gameDb = _gameDataModel.Get(id);

                if (game != null && gameDb != null)
                {
                    gameDb.Code = game.Code;
                    gameDb.Description = game.Description;
                    gameDb.IsActive = game.IsActive;
                    gameDb.ImageUrl = game.ImageUrl;
                    gameDb = _gameDataModel.Update(gameDb);

                    new GamesCacheHelper(_gameDataModel, _cacheHelper).RefreshGameCache();
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToAll(SocketMessageType.SingleGame, gameDb);

                    result.IsComplete = true;
                    result.Entity = gameDb;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Put Game failed values supplied : id {id} -  game {JsonConvert.SerializeObject(game)}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Put processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> Put(int id, bool status)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Put-UpdateStatus values supplied : id {id} - status {status}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                var gameDb = _gameDataModel.Get(id);

                if (gameDb != null)
                {
                    gameDb.IsActive = status;
                    gameDb = _gameDataModel.Update(gameDb);

                    new GamesCacheHelper(_gameDataModel, _cacheHelper).RefreshGameCache();
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToAll(SocketMessageType.SingleGame, gameDb);

                    result.IsComplete = true;
                    result.Entity = gameDb;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Put-UpdateStatus Game failed values supplied : id {id} -  status {status}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Put-UpdateStatus processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Games/Delete values supplied : id {id}");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                var deleted = _gameDataModel.Delete(id);
                result.Entity = id;
                result.IsComplete = deleted;

                if (!deleted)
                {
                    this.Response.StatusCode = (int)HttpStatusCode.BadGateway;
                }
                else
                {
                    new GamesCacheHelper(_gameDataModel, _cacheHelper).RefreshGameCache();
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToAll(SocketMessageType.DeleteGame, id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Delete Game failed values supplied : id {id}");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Games/Delete processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }

    }
}