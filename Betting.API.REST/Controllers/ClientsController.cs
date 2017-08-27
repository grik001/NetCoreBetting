using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Betting.Entities.ViewModels;
using Betting.Data.DataModels.BrandX;

namespace Betting.API.REST.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IAspNetUserDataModel _aspNetUserDataModel;

        public ClientsController(IAspNetUserDataModel aspNetUserDataModel)
        {
            this._aspNetUserDataModel = aspNetUserDataModel;
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
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }
    }
}