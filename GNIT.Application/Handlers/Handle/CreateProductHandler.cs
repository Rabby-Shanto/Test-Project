using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Product;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class CreateProductHandler : IHandler<Product, ProductCreated>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductCreated> Handle(Product requests)
        {
            var Data = await _productRepository.CreateProduct(requests);
            return new ProductCreated
            {
                Error = "0",
                Message = "Product Created Successfully",
                Data = Data
            };
            
        }
    }
}
