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

namespace Betting.API.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IAspNetUserDataModel _aspNetUserDataModel;
        private ILogger _logger;

        public ClientsController(IAspNetUserDataModel aspNetUserDataModel, ILogger logger)
        {
            this._aspNetUserDataModel = aspNetUserDataModel;
            this._logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            ResultViewModel result = new ResultViewModel();

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

            return new ObjectResult(result);
        }
    }
}