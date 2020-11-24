using BestFriend.Data;
using BestFriend.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Services
{
    public class CustomerService
    {
        private readonly Guid _custId;
        public CustomerService(Guid custId)
        {
            _custId = custId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CustId = _custId,
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
        public IEnumerable<CustomerList> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.CustId == _custId)
                        .Select(
                            e =>
                                new CustomerList
                                {
                                    CustomerID = e.CustomerID,
                                    UserName = e.UserName,
                                    Email = e.Email,
                                    FullName = e.FullName,
                                    CreateCustomer = e.CreateCustomer,
                                    ModifyCustomer = e.ModifyCustomer
                                }
                        );

                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == id && e.CustId == _custId);
                return
                    new CustomerDetail
                    {
                        CustomerID = entity.CustomerID,
                        UserName = entity.UserName,
                        Email = entity.Email,
                        CreateCustomer = entity.CreateCustomer,
                        ModifyCustomer = entity.ModifyCustomer
                    };
            }
        }
        public bool UpdateCustomer(CustomerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerID == model.CustomerID && e.CustId == _custId);

                entity.UserName = model.UserName;
                entity.Email = model.Email;
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
                        .Single(e => e.CustomerID == custId && e.CustId == _custId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}