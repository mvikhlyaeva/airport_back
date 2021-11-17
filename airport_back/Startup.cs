using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Linq;

namespace airport_back
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog = airportdb;Integrated Security = false;User ID = user1;Password =123"));

            //"Database=airportdb;" +
            //"Trusted_Connection=True;"
            // ));

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddMvc();
            services.AddMediatR(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseMiddleware<ExceptionCatchMiddleware>();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });

            //app.UseMiddleware<RequestLoggingMiddleware>(loggerFactory);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}
        }
    }
}