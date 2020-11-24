using BestFriend.Data;
using BestFriend.Models.WishListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Services
{
    public class WishService
    {
        private readonly Guid _wishGuid;

        public WishService(Guid wishGuid)
        {
            _wishGuid = wishGuid;
        }
        public bool CreateWish(WishCreate model)
        {
            var entity =
                new WishList()
                {
                    Money = model.Money,
                    Item = model.Item,
                    Supplier = model.Supplier,
                    CreateWish = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WishLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WishListItem> GetWishes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WishLists
                        .Where(e => e.WishGuid == _wishGuid)
                        .Select(
                            e =>
                                new WishListItem
                                {
                                    WishId = e.WishId,
                                    Money = e.Money,
                                    Item = e.Item,
                                    Supplier = e.Supplier,
                                    CreateWish = e.CreateWish
                                }
                        );

                return query.ToArray();
            }
        }
        public WishDetail GetWishById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WishLists
                        .Single(e => e.WishId == id && e.WishGuid == _wishGuid);
                return
                    new WishDetail
                    {
                        WishId = entity.WishId,
                        Money = entity.Money,
                        Item = entity.Item,
                        Supplier = entity.Supplier,
                        CreateWish = entity.CreateWish,
                        ModifyWish = entity.ModifyWish
                    };
            }
        }
        public bool UpdateWish(WishUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WishLists
                        .Single(e => e.WishId == model.WishId && e.WishGuid == _wishGuid);

                entity.Money = model.Money;
                entity.Item = model.Item;
                entity.ModifyWish = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWishList(int wishId)
        {
            using (var ctx = new Data.ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WishLists
                        .Single(e => e.WishId == wishId && e.WishGuid == _wishGuid);

                ctx.WishLists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
