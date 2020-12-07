using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public enum Category {[Display(Name = "Dog")] Dog = 1, [Display(Name = "Cat")] Cat, [Display(Name = "Reptile")] Reptile, [Display(Name = "Pocket Pet")] PocketPet, [Display(Name = "Hamster")] Hamster, [Display(Name = "Gerbil")] Gerbil, [Display(Name = "Mouse")] Mouse }

    public class Product
    {
       [Key]
        public int ProductId { get; set; }
        public Category Category { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int InventoryCount { get; set; }
        public int Rating { get; set; }

        [ForeignKey(nameof(Order))]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
       
    }
}
