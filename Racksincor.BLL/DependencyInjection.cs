using Microsoft.Extensions.DependencyInjection;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.BLL.Services.Mediates;

namespace Racksincor.BLL
{
    public static class DependencyInjection
    {
        public static void AddAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void AddMediateServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMediateService<,>), typeof(PromotionService<,>));
            services.AddScoped<IMediateService<CompanyDTO, CompanyQuery>, CompanyService>();
            services.AddScoped<IMediateService<ShopDTO, ShopQuery>, ShopService>();
            services.AddScoped<IMediateService<RackDTO, RackQuery>, RackService>();
            services.AddScoped<IMediateService<ReactionDTO, ReactionQuery>, ReactionService>();
            services.AddScoped<IMediateService<ProductDTO, ProductQuery>, ProductService>();
        }
    }
}
