using BestFriend.Data;
using BestFriend.Models;
using BestFriend.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestFriend.Data.ApplicationDbContext;

namespace BestFriend.Services
{
    public class ProductService
    {
        private readonly Guid _ownerId;
        public ProductService(Guid ownerId)
        {
            _ownerId = ownerId;
        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _ownerId,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    InventoryCount= model.InventoryCount,
                    CreatedProduct = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        //.Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Title = e.Title,
                                    Description = e.Description,
                                    Price = e.Price,
                                    InventoryCount = e.InventoryCount,
                                    CreatedProduct = e.CreatedProduct,
                                    ModifyProduct = e.ModifyProduct
                                }
                        );

                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == id );
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Price = entity.Price,
                        InventoryCount = entity.InventoryCount,
                        CreatedProduct = entity.CreatedProduct,
                        ModifyProduct = entity.ModifyProduct
                    };
            }
        }
        public bool UpdateProduct(ProductUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId );

                entity.ProductId = model.ProductId;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.InventoryCount = model.InventoryCount;
                entity.ModifyProduct = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId );

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
