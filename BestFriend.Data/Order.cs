﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Guid OrderGuid { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTimeOffset CreateOrder{ get; set; }
        public DateTimeOffset ModifyOrder { get; set; }

    }
}
