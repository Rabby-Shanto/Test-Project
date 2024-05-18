using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Product;
using GNIT.Domain.Query;

namespace GNIT.Application.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IHandler<Product, ProductCreated> _createProductHandler;
        private readonly IHandler<Product, ProductUpdated> _updateProductHandler;
        private readonly IHandler<Query, GetProductResponse> _getProductHandler;
        private readonly IHandler<Query, IEnumerable<Product>> _getProductsHandler;
        private readonly IHandler<Query, DeleteProductResponse> _deleteProductHandler;

        public ProductHandler(IHandler<Product, ProductCreated> createProductHandler, IHandler<Product, ProductUpdated> updateProductHandler, IHandler<Query, GetProductResponse> getProductHandler, IHandler<Query, IEnumerable<Product>> getProductsHandler, IHandler<Query, DeleteProductResponse> deleteProductHandler)
        {
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _getProductHandler = getProductHandler;
            _getProductsHandler = getProductsHandler;
            _deleteProductHandler = deleteProductHandler;
        }
        public Task<ProductCreated> CreateProduct(Product product)
        {
            return _createProductHandler.Handle(product);
        }

        public Task<DeleteProductResponse> DeleteProduct(Query query)
        {
            return _deleteProductHandler.Handle(query);
        }

        public Task<GetProductResponse> GetProduct(Query query)
        {
            return _getProductHandler.Handle(query);
        }

        public Task<IEnumerable<Product>> GetProducts(Query query)
        {
            return _getProductsHandler.Handle(query);
        }

        public Task<ProductUpdated> UpdateProduct(Product product)
        {
            return _updateProductHandler.Handle(product);
            
        }
    }
}
