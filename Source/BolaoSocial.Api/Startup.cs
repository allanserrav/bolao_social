using BolaoSocial.Api.Filters;
using BolaoSocial.Data;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BolaoSocial.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IDataRead, EFDataContext>();
            services.AddScoped<IDataWrite, EFDataContext>();

            services.AddScoped<CompeticaoService>();
            services.AddScoped<EventoService>();
            services.AddScoped<AgrupamentoService>();

            services.AddDbContext<EFDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new ValidateModelStateFilter());
                })
                // https://cecilphillip.com/fluent-validation-rules-with-asp-net-core/
                .AddFluentValidation(fvc =>
                {
                    fvc.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();
        }
    }
}
