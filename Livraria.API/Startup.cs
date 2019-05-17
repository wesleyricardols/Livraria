using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Models.Exemplar.Repositories;
using Livraria.ApplicationCore.Models.Exemplar.Services;
using Livraria.ApplicationCore.Models.Exemplar.Services.Interfaces;
using Livraria.ApplicationCore.Models.Livros.Repositories;
using Livraria.ApplicationCore.Models.Livros.Services;
using Livraria.ApplicationCore.Models.Livros.Services.Interfaces;
using Livraria.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<LivrariaContext>();
            
            // Domain - Services 
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IExemplarService, ExemplarService>();

            // Domain - Repository
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IExemplarRepository, ExemplarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
