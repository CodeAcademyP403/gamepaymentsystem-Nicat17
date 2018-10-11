using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Models
{
    public class Game
    {
        public Game()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public string Url { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<UserAppsGames> UserAppsGames { get; set; }
    }
}
