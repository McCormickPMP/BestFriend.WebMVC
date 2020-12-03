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

        [Required]
     
        [Display(Name = "Product Name")]
        public string Name { get; set; }
    
        public string Description { get; set; }
        //public Category Category { get; set; }

        public decimal Price { get; set; }
      
        [Display(Name = "# In Stock")]
        public int InventoryCount { get; set; }
        public int Rating { get; set; }

    }
}
