using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.OrderModel
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Guid OrderGuid { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        //public int CustomerId { get; set; }
        //public int StatusId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreateOrder { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifyOrder { get; set; }
    }
}
