using System;
using BestFriend.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.GiftModel
{
    public enum TType { Dollars = 1,  SpecificProduct,  GiftBasket }

    public class GiftCreate
    {
      
        public int GiftId { get; set; }
       // public int CustomerId { get; set; }
        public Guid DonationId { get; set; }
        public TType TType { get; set; }
        public DateTimeOffset CreatedGift { get; set; }
        public DateTimeOffset RedeemGift { get; set; }
        
    }
}
