using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;
using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.GerencimentoTarefas.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServiceConfigurations(this IServiceCollection services)
        {
            string connectionString = "server=localhost;database=taskflow;uid=root;pwd=GH#@Mn47spW!HH$yvv76";

            services.AddDbContext<GerenciamentoTarefasContext>(opt =>
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
    }
}
