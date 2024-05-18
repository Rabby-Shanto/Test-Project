using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class DeleteProductHandler(IProductRepository productRepository) : IHandler<Query, DeleteProductResponse>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<DeleteProductResponse> Handle(Query requests)
        {
            var Data = await _productRepository.DeleteProduct(requests.Id);

            return new DeleteProductResponse
            {
                Message = "Product Deleted Successfully",
            };
            
        }
    }
}
