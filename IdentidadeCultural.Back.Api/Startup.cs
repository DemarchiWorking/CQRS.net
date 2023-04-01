using IdentidadeCultural.Aplicacao.Servico.Commands;
using IdentidadeCultural.Aplicacoes.Queries.Servicos.BuscarServico;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentidadeCultural.Api
{
    public class Startup
    {
        //.AddMediatR(Assembly.GetExecutingAssembly());
        public Startup(IConfiguration configuration)
        {   
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddMediatR(typeof(AdicionarServicoCommand));
            services.AddMediatR(typeof(BuscarServicosQuery));
            services.AddMediatR(typeof(AdicionarServicoCommand));
            //services.AddSingleton<BuscarServicosQueryHandler>;
            //services.AddMediatR(typeof(AdicionarServicoCommand));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //builder.Services.AddScoped<BuscarServicosQueryHandler>();

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
