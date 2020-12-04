using BestFriend.Data;
using BestFriend.Models;
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
        private readonly Guid _userId;
        public OrderService(Guid userId)
        {
            _userId = userId;
        }
        //CREATE
        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    OwnerId = _userId,
                    CustomerId = model.CustomerId,
                    Email = model.Email,
                    Products = model.Products,
                    Quantity = model.Quantity,

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
                        .Select(e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerId = e.OrderId,
                                    Products = e.Products,
                                    Quantity = e.Quantity,

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
                        .Single(e => e.OrderId == id && e.OwnerId == _userId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        CustomerId = entity.OrderId,
                        Products = entity.Products,
                        Quantity = entity.Quantity,

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
                        .Single(e => e.OrderId == model.OrderId && e.OwnerId == _userId);

                entity.OrderId = model.OrderId;
                entity.CustomerId = model.CustomerId;
                entity.Quantity = model.Quantity;
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
                        .Single(e => e.OrderId == orderId && e.OwnerId == _userId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
