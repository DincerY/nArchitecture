using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<PLDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionSting")));

            serviceCollection.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();

            return serviceCollection;
        }
    }
}
