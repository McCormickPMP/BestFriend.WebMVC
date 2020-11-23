using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.WishListModel
{
    public class WishList
    {
        [Key]
        public int WishId { get; set; }
        [Required]
        [Display(Name ="Amount to be sent")]
        public decimal Money { get; set; }
        [Required]
        [Display(Name ="Product to be sent")]
        public char Item { get; set; }

        public int Supplier { get; set; }
        public DateTimeOffset CreateWish { get; set; }
        public DateTimeOffset ModifyWish { get; set; }
    }
}
