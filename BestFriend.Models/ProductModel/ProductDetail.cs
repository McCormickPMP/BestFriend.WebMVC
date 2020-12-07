using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.ProductModel
{
    public class ProductDetail
    {

        public int ProductId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
  
        public int InventoryCount { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }

    }
}
