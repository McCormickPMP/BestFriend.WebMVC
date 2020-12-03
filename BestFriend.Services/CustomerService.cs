using BestFriend.Data;
using BestFriend.Models;
using BestFriend.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestFriend.Data.ApplicationDbContext;

namespace BestFriend.Services
{
    public class CustomerService
    {
        //private readonly ApplicationDbContext _context  = new ApplicationDbContext();
       
        //CREATE
        public bool CreateCustomerService(CustomerCreate model)
        {
           var entity =
                new Customer()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                CreateCustomer = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            { 
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //GET ALL
        public IEnumerable<CustomerList> GetCustomers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Select(e =>
                        new CustomerList
                        {
                            CustomerId = e.CustomerId,
                            UserName = e.UserName,
                            Email = e.Email,
                            FullName = e.FullName
                        }
                   );
                return query.ToArray();
            }
        }


        ///GET BY ID
        public CustomerDetail GetCustomerById(int id)
       
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id);
                return
                    new CustomerDetail
                    {
                        CustomerId =entity.CustomerId,
                        UserName = entity.UserName,
                        Email = entity.Email,
                        FullName = entity.FullName,
                        Orders = entity.Orders
                    };
            }
         }
        //UPDATE
        public bool UpdateCustomer(CustomerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId );
                entity.UserName = model.UserName;
                entity.Orders = model.Orders;
                entity.Email = model.Email;
                entity.FullName = model.FullName;
                entity.ModifyCustomer = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int custId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == custId );

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}