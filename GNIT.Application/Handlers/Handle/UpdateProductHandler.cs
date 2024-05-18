using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Product;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class UpdateProductHandler : IHandler<Product, ProductUpdated>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductUpdated> Handle(Product requests)
        {
            var Data = await _productRepository.UpdateProduct(requests);
            return new ProductUpdated
            {
                Error = "0",
                Message = "Product Updated Successfully",
                Data = Data
            };
        }
    }
}
