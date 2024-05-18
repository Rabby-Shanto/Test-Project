using GNIT.Domain.Product;
using GNIT.Domain.Query;

namespace GNIT.Infrastructure.Abstrations
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts(Query query);
        Task<bool> DeleteProduct(int id);
    }
}
