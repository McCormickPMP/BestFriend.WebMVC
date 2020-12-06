using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.OrderModel
{
    public class OrderCreate
    {
        public int OrderId { get; set; }
        //public Guid OwnerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string Email { get; set; }
        public Category Category { get; set; }
        
        public int Quantity { get; set; }

        

    }
}
