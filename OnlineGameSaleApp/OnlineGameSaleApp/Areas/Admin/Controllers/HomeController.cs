using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGameSaleApp.Areas.Admin.Models.ListModel;
using OnlineGameSaleApp.Data;
using OnlineGameSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly GameDbContext _gameDb;
        public HomeController(GameDbContext gameDb)
        {
            _gameDb = gameDb;
        }

        public IActionResult Index()
        {
            //Payment uzerinden Game alib, Game uzerindende Userlara getmek lazimdir. Ama alinmir

            //List<Payment> payments = _gameDb.Payments.Include(x => x.Game)
            //                            .Include(x=>x.Game.UserAppsGames
            //                                .Include(z=>z.UserApp))
            //                                    .ToList();

            List<Payment> payments = _gameDb.Payments.Include(x => x.Game).ToList();

            return View(payments);
        }
    }
}
