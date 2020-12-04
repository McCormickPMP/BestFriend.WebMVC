using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.OrderModel
{
    public class OrderListItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int Quantity { get; set; }

    }
}
