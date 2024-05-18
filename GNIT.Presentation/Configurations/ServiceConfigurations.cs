using GNIT.Application.Handlers;
using GNIT.Application.Handlers.Contracts;
using GNIT.Application.Handlers.Handle;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Product;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure;
using GNIT.Infrastructure.Abstrations;
using GNIT.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GNIT.Presentation.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IIndividualUserRepository, IndividualRepository>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ICorporateRepository, CorporateRepository>();
            services.AddScoped<IProductHandler,ProductHandler>();
            services.AddScoped<IIndividualUserHandler, IndividualUserhandler>();
            services.AddScoped<ICorporateHandler, CorporateHandler>();

            #region Handlers

            services.AddScoped<IHandler<Product, ProductUpdated>, UpdateProductHandler>();
            services.AddScoped<IHandler<Product, ProductCreated>, CreateProductHandler>();
            services.AddScoped<IHandler<Query, GetProductResponse>, GetProductHandler>();
            services.AddScoped<IHandler<Query, IEnumerable<Product>>, GetAllProductHandler>();
            services.AddScoped<IHandler<Query, DeleteProductResponse>, DeleteProductHandler>();
            services.AddScoped<IHandler<Individual, UserResponse>, IndividualUserCreateHandler>();
            services.AddScoped<IHandler<Corporate, UserResponse>, CorporateCreateHandler>();
            services.AddScoped<IHandler<Query, IEnumerable<Corporate>>, GetAllCorporateHandler>();
            services.AddScoped<IHandler<Query, IEnumerable<Individual>>, GetAllIndividualUserHandler>();

            #endregion
            return services;
        }
    }
}
