using BestFriend.Data;
using BestFriend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

                    Title = model.Title,
                    Description = model.Description,
                    CreatedAt = DateTimeOffset.Now
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
                                    Title = e.Title,
                                    CreatedAt = e.CreatedAt
                                }
                        );

                return query.ToArray();
            }
        }
    }
    
}
