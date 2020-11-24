using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.ProductModel
{
    public class ProductUpdate
    {
        public int ProductId { get; set; }

        public string Category { get; set; }
      
        [Display(Name = "Product Name")]
        public string Title { get; set; }
       
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset CreatedProduct { get; set; }
        public DateTimeOffset? ModifyProduct { get; set; }

    }
}
