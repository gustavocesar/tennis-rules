using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Entities;
using Domain.Services;
using Domain.Services.Contracts;
using Application.Services;
using Application.Services.Contracts;
using Domain.Repositories.Contracts;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;

namespace Presentation
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
            services.AddControllersWithViews();

            services.AddDbContext<TennisContext>(opt => opt.UseInMemoryDatabase(databaseName: "Test"));

            services.AddTransient<IGameApplicationService, GameApplicationService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameRepository, GameRepository>();

            services.AddTransient<IJogadorApplicationService, JogadorApplicationService>();
            services.AddTransient<IJogadorRepository, JogadorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TennisContext>();
                MySeeds(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void MySeeds(TennisContext context)
        {
            context.Jogadores.Add(new Jogador("Rafael Nadal"));
            context.Jogadores.Add(new Jogador("Gustavo Kuerten"));
            context.SaveChanges();
        }
    }
}
