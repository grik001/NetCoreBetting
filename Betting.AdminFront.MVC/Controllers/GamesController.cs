using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Betting.AdminFront.MVC.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}