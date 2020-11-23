using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public class WishList
    {
        [Key]
        public int WishId { get; set; }
        [Required]
        public decimal Money { get; set; }
        [Required]
        public char Item { get; set; }
       
        public int Supplier { get; set; }
        public DateTimeOffset CreateWish { get; set; }
        public DateTimeOffset ModifyWish { get; set; }
    }
}
