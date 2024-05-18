using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class GetProductHandler(IProductRepository productRepository) : IHandler<Query, GetProductResponse>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<GetProductResponse> Handle(Query requests)
        {
            var Data = await _productRepository.GetProduct(requests.Id);
            if(Data == null)
            {
                return new GetProductResponse
                {
                    Message = "Product Not Found",
                    Data = null
                };
            }

            return new GetProductResponse
            {
                Message = "Product Retrieved Successfully",
                Data = Data
            };
        }
    }
}
