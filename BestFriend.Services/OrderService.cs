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
                    CustomerId = model.CustomerId,
                    Products = model.Products,
                    Quantity = model.Quantity,
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
                        .Select(e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerId = e.OrderId,
                                    Products = e.Products,
                                    Quantity = e.Quantity,
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
                        .Single(e => e.OrderId == id);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        CustomerId = entity.OrderId,
                        Products = entity.Products,
                        Quantity = entity.Quantity,
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
                        .Single(e => e.OrderId == model.OrderId);

                entity.OrderId = model.OrderId;
                entity.CustomerId = model.CustomerId;
                entity.Quantity = model.Quantity;
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
                        .Single(e => e.OrderId == orderId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
