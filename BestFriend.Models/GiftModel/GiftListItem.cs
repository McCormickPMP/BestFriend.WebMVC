using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.GiftModel
{
    public class GiftListItem
    {
        public int GiftId { get; set; }
        public Guid DonationId { get; set; }
        public int CustomerId { get; set; }
        public char TType { get; set; }
        public enum Ttype { dollars, specificProduct, giftBasket }
        public DateTimeOffset CreatedGift { get; set; }
        public DateTimeOffset RedeemGift { get; set; }
    }
}
