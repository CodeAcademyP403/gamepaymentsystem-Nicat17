using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGameSaleApp.Data;
using OnlineGameSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameDbContext _gameDbContext;
        public HomeController(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Game> games = _gameDbContext.Games.ToList();

            return View(games);
        }
    }
}
