using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
   
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Email { get; set; }
        
        //public Guid OwnerId { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        [Required]
        public int Quantity { get; set; }
             
        [Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }


       [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

    }
}
