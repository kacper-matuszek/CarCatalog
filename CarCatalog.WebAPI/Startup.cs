using CarCatalog.Database;
using CarCatalog.Utils.Registers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CarCatalog.WebAPI
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
            services.AddDbContext<CarCatalogContext>(opt =>
                opt
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("CarCatalogContext")))
                .RegisterAutomapper()
                .RegisterRepositories()
                .AddCors(opt => opt.AddPolicy("ApiCorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:52761").AllowAnyMethod().AllowAnyHeader();
                }))
                .AddMvc()
                .AddNewtonsoftJson(options => 
                    options.UseMemberCasing())
                .RegisterValidators();
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

            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
