using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public  class Gift
    {
        [Key]
        public int GiftId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public char TType { get; set; }
        public DateTimeOffset CreatedGift { get; set; }
        public DateTimeOffset RedeemGift { get; set; }
    }
}
