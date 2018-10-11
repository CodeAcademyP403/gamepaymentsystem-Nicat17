using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        [Required]
        [Range(1,100)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
    }
}
