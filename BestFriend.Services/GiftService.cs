using BestFriend.Data;
using BestFriend.Models;
using BestFriend.Models.GiftModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift = BestFriend.Data.Gift;

namespace BestFriend.Services
{
    public class GiftService
    {
        private readonly Guid _donationId;

        public GiftService(Guid donationId)
        {
            _donationId = donationId;
        }
        public bool CreateGift(GiftCreate model)
        {
            var entity =
                new Gift()
                {
                    DonationId = _donationId,
                    //CustomerId = model.CustomerId,
                    TType = (Data.TType)model.TType,
                    CreatedGift = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gifts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GiftListItem> GetGifts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Gifts
                        .Where(e => e.DonationId == _donationId)
                        .Select(
                            e =>
                                new GiftListItem
                                {
                                    GiftId = e.GiftId,
                                    //CustomerId = e.CustomerId,
                                    TType = (Models.GiftModel.TType)e.TType,
                                    CreatedGift = e.CreatedGift
                                }
                        );

                return query.ToArray();
            }
        }
        public GiftDetail GetGiftById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Gifts
                        .Single(e => e.GiftId == id && e.DonationId == _donationId);
                return
                    new GiftDetail
                    {
                        GiftId = entity.GiftId,
                       // CustomerId = entity.CustomerId,
                        TType = (Models.GiftModel.TType)entity.TType,
                        CreatedGift = entity.CreatedGift,
                        RedeemGift = entity.RedeemGift
                    };
            }
        }
        public bool UpdateGift(GiftUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Gifts
                        .Single(e => e.GiftId== model.GiftId && e.DonationId == _donationId);

                //entity.CustomerId = model.CustomerId;
                entity.TType = (Data.TType)model.TType;
                entity.RedeemGift = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int giftId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Gifts
                        .Single(e => e.GiftId == giftId && e.DonationId == _donationId);

                ctx.Gifts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
