using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.OrderModel
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Display(Name ="Quantity Ordered")]
        public int Quantity { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        
        public int StatusId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Count { get; set; }
        public DateTimeOffset CreateOrder { get; set; }
        public DateTimeOffset ModifyOrder { get; set; }

    }
}

