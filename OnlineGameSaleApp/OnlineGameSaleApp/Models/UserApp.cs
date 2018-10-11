using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Models
{
    public class UserApp
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<UserAppsGames> UserAppsGames { get; set; }
    }
}
