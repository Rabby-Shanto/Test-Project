using GNIT.Domain.EntityBase;
using GNIT.Domain.Product;
using GNIT.Domain.Query;

namespace GNIT.Application.Handlers.Contracts
{
    public interface IProductHandler
    {
        Task<ProductCreated> CreateProduct(Product product);
        Task<ProductUpdated> UpdateProduct(Product product);
        Task<GetProductResponse> GetProduct(Query id);
        Task<IEnumerable<Product>> GetProducts(Query quey);
        Task<DeleteProductResponse> DeleteProduct(Query id);
    }
}
