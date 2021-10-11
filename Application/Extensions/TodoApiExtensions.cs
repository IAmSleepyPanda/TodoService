using DomainContext;
using DomainContext.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApiDTO.Configurations;
using TodoProject.BLL.Managers;
using TodoProject.BLL.Providers;
using TodoProject.BLL.Providers.Interfaces;

namespace TodoApiDTO.Extensions
{
    /// <summary>
    /// Provides extensions for TodoApi
    /// </summary>
    public static class TodoApiExtensions
    {
        /// <summary>
        /// Adds transient for services
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<ITodoItemsProvider, TodoItemsProvider>();
            serviceCollection.AddTransient<TodoManager>();
        }

        /// <summary>
        /// Adds Swagger
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="swaggerConfiguration"></param>
        public static void AddSwagger(this IServiceCollection serviceCollection, SwaggerConfiguration swaggerConfiguration)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerConfiguration.Name, swaggerConfiguration.OpenApiInfo);
                c.IncludeXmlComments("TodoApiDTO.xml");
            });
        }

        /// <summary>
        /// Uses Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="swaggerConfiguration"></param>
        public static void UseSwagger(this IApplicationBuilder app, SwaggerConfiguration swaggerConfiguration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerConfiguration.Url, swaggerConfiguration.Name);
            });
        }
    }
}
