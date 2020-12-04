using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public enum Category {[Display(Name = "Dog")] Dog = 1, [Display(Name = "Cat")] Cat, [Display(Name = "Reptile")] Reptile, [Display(Name ="Pocket Pet")] PocketPet, [Display(Name = "Hamster")] Hamster, [Display(Name ="Gerbil")] Gerbil, [Display(Name ="Mouse")] Mouse }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Email { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public virtual ICollection<Product> Products { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
