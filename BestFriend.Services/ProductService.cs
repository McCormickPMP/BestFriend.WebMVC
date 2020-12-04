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
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
           _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    Price = model.Price,
                    Rating = model.Rating,
                    InventoryCount= model.InventoryCount,
                  
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Name = e.Name,
                                    Category = e.Category,
                                    Description = e.Description,
                                    Price = e.Price,
                                    Rating = e.Rating,
                                    InventoryCount = e.InventoryCount,
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
                        .Single(e => e.ProductId == id && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Category = entity.Category,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        Rating = entity.Rating,
                        InventoryCount = entity.InventoryCount,

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
                        .Single(e => e.ProductId == model.ProductId && e.OwnerId == _userId);

                entity.ProductId = model.ProductId;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.Rating = model.Rating;
                entity.InventoryCount = model.InventoryCount;
               

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
                        .Single(e => e.ProductId == productId && e.OwnerId ==_userId );

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
