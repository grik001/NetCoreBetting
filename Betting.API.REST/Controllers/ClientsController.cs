using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Betting.Entities.ViewModels;
using Betting.Data.DataModels.BrandX;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Betting.API.REST.Helpers;
using Newtonsoft.Json;

namespace Betting.API.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IAspNetUserDataModel _aspNetUserDataModel;
        private ILogger _logger;

        public ClientsController(IAspNetUserDataModel aspNetUserDataModel, ILogger<ClientsController> logger)
        {
            this._aspNetUserDataModel = aspNetUserDataModel;
            this._logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var token = Guid.NewGuid();
            _logger.LogInformation($"Received message using Token:{token} Clients/Get values supplied");

            ResultViewModel result = new ResultViewModel();
            result.Token = token.ToString();

            try
            {
                var clients = _aspNetUserDataModel.GetClients();

                result.Entity = clients;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEventCode.Exception, ex, $"Get-Clients failed");
                result.HasErrors = true;
            }

            _logger.LogInformation($"Clients/Get processed using Token:{token} sending result : {JsonConvert.SerializeObject(result)}");
            return new ObjectResult(result);
        }
    }
}