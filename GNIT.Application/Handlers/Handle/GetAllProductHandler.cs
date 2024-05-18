using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Product;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class GetAllProductHandler(IProductRepository productRepository) : IHandler<Query, IEnumerable<Product>>
    {
        public IProductRepository _productRepository = productRepository;

        public async Task<IEnumerable<Product>> Handle(Query requests)
        {
            var data = await _productRepository.GetProducts(requests);
            return data;

        }
    }
}
