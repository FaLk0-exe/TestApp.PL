using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Repositories;
using TestApp.BLL.Services;
using TestApp.DAL.EF;

namespace TestApp.BLL.Dependency_Injection
{
    public static class DIExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<TestContext>();
            services.AddTransient<ProductService>();
        }
    }
}
