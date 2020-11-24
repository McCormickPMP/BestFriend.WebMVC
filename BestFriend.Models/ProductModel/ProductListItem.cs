using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.ProductModel
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        public string Category { get; set; }
        
        public string Title { get; set; }
     
        public string Description { get; set; }
        public decimal Price { get; set; }
     
        public int InventoryCount { get; set; }
        public int Rating { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedProduct { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifyProduct { get; set; }
    }
}
