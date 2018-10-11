using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Models
{
    public class UserAppsGames
    {
        public int UserAppId { get; set; }
        public UserApp UserApp { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
