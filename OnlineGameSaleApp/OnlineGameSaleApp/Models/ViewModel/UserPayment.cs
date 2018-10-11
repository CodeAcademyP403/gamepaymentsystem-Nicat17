using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Models.ViewModel
{
    public class UserPayment
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
