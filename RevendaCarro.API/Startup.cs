using Rebus.Config;
using Rebus.Messages;
using System.Reflection;
using Rebus.Routing.TypeBased;
using Microsoft.OpenApi.Models;
using RevendaCarro.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RevendaCarro.Domain.Events.Brand;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RevendaCarro.Infra.Repositories.Interface;
using RevendaCarro.Infra.Repositories;
using RevendaCarro.Infra.Services.Interfaces;
using RevendaCarro.Infra.Services;

namespace RevendaCarro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var mqQueue = "queue.exg";
            services
                .AddRebus(configure => configure
                    .Transport(t => t.UseRabbitMq("amqp://localhost:15672", mqQueue))
                    .Routing(r =>
                    {
                        r.TypeBased()
                            .MapAssemblyOf<Message>(mqQueue)
                            .MapAssemblyOf<BrandCreatedEvent>(mqQueue)
                            .MapAssemblyOf<BrandUpdatedEvent>(mqQueue);
                    })
                    .Options(o =>
                    {
                        o.SetNumberOfWorkers(1);
                        o.SetMaxParallelism(1);
                        o.SetBusName("RevendaCarro");
                    })
                )
                .AddHttpContextAccessor()
                .AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name)));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items"                   
                });
            });

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

    }
}
