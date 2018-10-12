using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGameSaleApp.Data;
using OnlineGameSaleApp.Models;
using OnlineGameSaleApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly GameDbContext _gameDbContext;
        private readonly IHttpContextAccessor _accessor;

        public AccountController(GameDbContext gameDbContext,IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _gameDbContext = gameDbContext;
        }

        [HttpGet]
        public IActionResult Register(int id)
        {
            Game game = _gameDbContext.Games.Find(id);

            string gameName = game.Name;
            string gameId = game.Id.ToString();
            decimal minAmount = game.MinAmount;
            decimal maxAmount = game.MaxAmount;

            HttpContext.Session.SetString("gameName", gameName);
            HttpContext.Session.SetString("gameId", gameId);
            HttpContext.Session.SetString("minAmount", minAmount.ToString());
            HttpContext.Session.SetString("maxAmount", maxAmount.ToString());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserPayment userPayment)
        {
            if (ModelState.IsValid)
            {
                UserApp userApp = new UserApp()
                {
                    Name= userPayment.UserName
                };

                _gameDbContext.UserApps.Add(userApp);
                _gameDbContext.SaveChanges();

                string IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

                int gameId = Convert.ToInt32(HttpContext.Session.GetString("gameId"));

                if (IP!=null)
                {
                    Payment payment = new Payment()
                    {
                        Amount = userPayment.Amount,
                        DateTime = userPayment.Date,
                        Status = true,
                        Ip = IP,
                        GameId=gameId
                    };

                    _gameDbContext.Payments.Add(payment);
                    _gameDbContext.SaveChanges();

                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }
    }
}
