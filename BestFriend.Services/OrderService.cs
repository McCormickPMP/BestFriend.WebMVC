using BestFriend.Data;
using BestFriend.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Services
{
    public class OrderService
    {
        private readonly Guid _orderGuid;

        public OrderService(Guid orderGuid)
        {
            _orderGuid = orderGuid;
        }
        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    OrderGuid = _orderGuid,
                    ItemId = model.ItemId,
                    Quantity = model.Quantity,
                    CustomerId = model.CustomerId,
                    //StatusId = model.StatusId,
                    CreateOrder = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       
        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Orders
                        .Where(e => e.OrderGuid == _orderGuid)
                        .Select(e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    Quantity = e.Quantity,
                                    ItemId = e.ItemId,
                                    CustomerId = e.CustomerId,
                                    //StatusId = e.StatusId,
                                    CreateOrder = DateTimeOffset.Now
                                }
                        );

                return query.ToArray();
            }
        }
        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == id && e.OrderGuid == _orderGuid);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        Quantity = entity.Quantity,
                        ItemId = entity.ItemId,
                        CustomerId = entity.CustomerId,
                       // StatusId = entity.StatusId,
                        CreateOrder = DateTimeOffset.Now
                    };
            }
        }
        public bool UpdateOrder(OrderUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == model.OrderId && e.OrderGuid == _orderGuid);

                entity.OrderId = model.OrderId;
                entity.Quantity = model.Quantity;
                entity.ItemId = model.ItemId;
                entity.CustomerId = model.CustomerId;
                //entity.StatusId = model.StatusId;
                entity.ModifyOrder = DateTimeOffset.Now;
                  

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId && e.OrderGuid == _orderGuid);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
