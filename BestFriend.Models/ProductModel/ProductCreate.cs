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
        public int? ProductId { get; set; }
        [Required]
     
        [Display(Name = "Product Name")]
        public string Name { get; set; }
    
        public string Description { get; set; }
        //public Category Category { get; set; }

        public decimal Price { get; set; }
      
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }

    }
}
