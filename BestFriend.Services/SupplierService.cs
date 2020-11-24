using BestFriend.Data;
using BestFriend.Models.SupplierModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier = BestFriend.Data.Supplier;

namespace BestFriend.Services
{
    public class SupplierService
    {
        private readonly Guid _supplierGuid;

        public SupplierService(Guid supplierGuid)
        {
            _supplierGuid = supplierGuid;
        }
        public bool CreateSupplier(SupplierCreate model)
        {
            var entity =
                new Supplier()
                {

                    SupplierId = model.SupplierId,
                    SupplierName = model.SupplierName,
                    Phone = model.Phone,
                    SuppAddress = model.SuppAddress,
                    SuppCity = model.SuppCity,
                    SuppZipcode = model.SuppZipcode,
                    SuppEmail = model.SuppEmail,
                    CreateSupp = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Suppliers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SupplierListItem> GetSuppliers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Suppliers
                        .Where(e => e.SupplierGuid == _supplierGuid)
                        .Select(
                            e =>
                                new SupplierListItem
                                {
                                    SupplierId = e.SupplierId,
                                    SupplierName = e.SupplierName,
                                    SuppEmail = e.SuppEmail,
                                    CreateSupp = DateTimeOffset.Now

                                }
                        );

                return query.ToArray();
            }
        }
        public SupplierDetail GetSupplierById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == id && e.SupplierGuid == _supplierGuid);
                return
                    new SupplierDetail
                    {
                        SupplierId = entity.SupplierId,
                        SupplierName = entity.SupplierName,
                        SuppEmail = entity.SuppEmail,
                        CreateSupp = DateTimeOffset.Now

                    };
            }
        }
        public bool UpdateSupplier(SupplierUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == model.SupplierId && e.SupplierGuid == _supplierGuid);

                entity.SupplierId = model.SupplierId;
                entity.SupplierName = model.SupplierName;
                entity.Phone = model.Phone;
                entity.SuppAddress = model.SuppAddress;
                entity.SuppCity = model.SuppCity;
                entity.SuppZipcode = model.SuppZipcode;
                entity.SuppEmail = model.SuppEmail;
                    
                entity.ModifySupp = DateTimeOffset.Now;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSupplier(int supplierId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Suppliers
                        .Single(e => e.SupplierId == supplierId && e.SupplierGuid == _supplierGuid);

                ctx.Suppliers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
