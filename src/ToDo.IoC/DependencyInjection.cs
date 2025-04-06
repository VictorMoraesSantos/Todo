using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Repositories;

namespace ToDo.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoListService, TodoListServices>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<ITodoItemService, TodoItemServices>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Database")!;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<ILabelTodoItemRepository, LabelTodoItemRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            return services;
        }
    }
}
