using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.OrderModel
{
    public class OrderUpdate
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

  
    }
}
