using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.BLL.Services.Mediates;
using Racksincor.BLL.Validators;

namespace Racksincor.BLL
{
    public static class DependencyInjection
    {
        public static void AddAuthMediate(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void AddEntityMediates(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMediateService<,>), typeof(PromotionService<,>));
            services.AddScoped<IMediateService<CompanyDTO, CompanyQuery>, CompanyService>();
            services.AddScoped<IMediateService<ShopDTO, ShopQuery>, ShopService>();
            services.AddScoped<IMediateService<RackDTO, RackQuery>, RackService>();
            services.AddScoped<IMediateService<ReactionDTO, ReactionQuery>, ReactionService>();
            services.AddScoped<IMediateService<ProductDTO, ProductQuery>, ProductService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CompanyDTO>, CompanyValidator>();
            services.AddScoped<IValidator<ShopDTO>, ShopValidator>();
            services.AddScoped<IValidator<RegisterDTO>, RegisterValidator>();
            services.AddScoped<IValidator<UserDTO>, UserValidator>();

        }
    }
}
