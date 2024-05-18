using GNIT.Domain.Product;
using GNIT.Domain.Query;
using GNIT.Infrastructure.Abstrations;
using GNIT.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GNIT.Infrastructure
{
    public class ProductRepository(ApplicationDbContext db) : IProductRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var createProduct = new Product
                {
                    Name = product.Name,
                    Unit = product.Unit,
                    Quantity = product.Quantity,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                var result = await _db.Products.AddAsync(createProduct);
                await _db.SaveChangesAsync();
                return result.Entity;

            }
            catch
            {
                throw;
            }

        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return true;
        }


        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var product = await _db.Products.FindAsync(id);
                if (product == null)
                {
                    return null!;
                }
                return product;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts(Query query)
        {
            try
            {
                return await _db.Products
                    .Skip((query.PageNo - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToListAsync();

            }
            catch
            {
                throw;
            }
            
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = await _db.Products.FindAsync(product.Id);

                if (existingProduct == null)
                {
                    return null!;
                }

                existingProduct.Name = product.Name;
                existingProduct.Unit = product.Unit;
                existingProduct.Quantity = product.Quantity;
                existingProduct.ModifiedDate = DateTime.Now;

                await _db.SaveChangesAsync();

                return existingProduct;

            }
            catch
            {
                throw;
            }
            
        }
    }
}
