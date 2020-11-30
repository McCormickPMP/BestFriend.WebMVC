using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public enum Ttype {[Display(Name = "Dollars")] Dollars = 1, [Display(Name = "Specific Product")] SpecificProduct, [Display(Name ="Gift Basket")] GiftBasket }
    public  class Gift
    {
        [Key]
        public int GiftId { get; set; }
        public Guid DonationId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
       
        [Required]
        public char TType { get; set; }
        public DateTimeOffset CreatedGift { get; set; }
        public DateTimeOffset RedeemGift { get; set; }
    }
}
