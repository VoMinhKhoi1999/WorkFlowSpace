using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data;
using WorkFlowSpace.infrastructure.Repository;

namespace WorkFlowSpace.infrastructure
{
    public static class InfrastructureRequistration
    {
        public static IServiceCollection InfrastructureConfigration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IGroupsRepository, GroupsRepository>();
            //services.AddScoped<ITabsRepository, TabsRepository>();
            //services.AddScoped<ITasksRepository, TasksRepository>();

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
