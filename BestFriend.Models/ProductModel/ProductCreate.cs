using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.ProductModel
{
    public class ProductCreate
    {
        public int ProductId { get; set; }

        public string Category { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset CreatedProduct { get; set; }
        public DateTimeOffset? ModifyProduct { get; set; }

    }
}
