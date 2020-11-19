using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BestFriend.Services
{
    public class ProductService
    {

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                  
                    Title = model.Title,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
