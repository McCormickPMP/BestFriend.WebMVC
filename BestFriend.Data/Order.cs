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
        public Guid OrderGuid { get; set; }
        [Required]
        public int Quantity { get; set; }
       
        public int ItemId { get; set; }
        
        [ForeignKey(nameof(ItemId))]
        public virtual Product Product { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
       
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTimeOffset CreateOrder{ get; set; }
        public DateTimeOffset ModifyOrder { get; set; }

    }
}
