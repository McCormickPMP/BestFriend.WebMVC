﻿using BestFriend.Data;
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
                    //OwnerId = _userId,
                    OrderId = model.OrderId,
                    CustomerId = model.CustomerId,
                    Email = model.Email,
                    ProductId = model.ProductId,
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
                                    CustomerId = e.CustomerId,
                                    Email = e.Email,
                                    ProductId = e.Product.ProductId,
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
                        .Single(e => e.OrderId == id && e.Customer.OwnerId == _userId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        CustomerId = entity.CustomerId,
                        ProductId = entity.Product.ProductId,
                        Email = entity.Email,
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
                        .Single(e => e.OrderId == model.OrderId && e.Customer.OwnerId == _userId);

                entity.OrderId = model.OrderId;
                entity.CustomerId = model.CustomerId;
                entity.ProductId = model.Product.ProductId;
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
                        .Single(e => e.OrderId == orderId && e.Customer.OwnerId == _userId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
