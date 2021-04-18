
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Application;
using Microsoft.OpenApi.Models;


namespace API
{
    public class Startup
    {
        readonly string CorsPolicy = "Corspolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddMediatR(typeof(GetCustomerService.Handler).Assembly);
            services.AddControllers().AddNewtonsoftJson(options =>
                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                    );
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                                    builder =>
                                    {
                                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                                    });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
