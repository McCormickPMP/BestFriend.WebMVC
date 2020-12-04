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
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        //CREATE
        public bool CreateCustomerService(CustomerCreate model)
        {
           var entity =
                new Customer()
            {
                OwnerId = _userId,
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                Address = model.Address,
                City = model.City,
                ZipCode = model.ZipCode,

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
                    .Where(e => e.OwnerId == _userId)
                    .Select(e =>
                        new CustomerList
                        {
                            CustomerId =e.CustomerId,
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
                        .Single(e => e.CustomerId == id && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {

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
                        .Single(e => e.CustomerId == model. CustomerId && e.OwnerId == _userId);
                entity.UserName = model.UserName;
                //entity.Orders = model.Orders;
                entity.Email = model.Email;
                entity.FullName = model.FullName;


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
                        .Single(e => e.CustomerId == custId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}