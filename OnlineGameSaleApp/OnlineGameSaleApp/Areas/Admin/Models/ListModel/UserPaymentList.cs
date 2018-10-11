using OnlineGameSaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameSaleApp.Areas.Admin.Models.ListModel
{
    public class UserPaymentList
    {
        public UserPaymentList()
        {
            Users = new List<UserApp>();
            Payments = new List<Payment>();
        }
    
        public List<UserApp> Users { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
