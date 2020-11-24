using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.GiftModel
{
    public class GiftCreate
    {
      
        public int GiftId { get; set; }
        public int CustomerId { get; set; }
        public int DonationId { get; set; }
        public char TType { get; set; }
        public DateTimeOffset CreatedGift { get; set; }
        public DateTimeOffset RedeemGift { get; set; }
        public enum Ttype 
        {
            dollars,
            specificProduct,
            giftBasket
        }

    }
}
