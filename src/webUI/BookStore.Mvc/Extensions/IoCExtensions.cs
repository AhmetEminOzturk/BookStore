using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using BookStore.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Mvc.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            //IoC
            services.AddDbContext<BookStoreDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
