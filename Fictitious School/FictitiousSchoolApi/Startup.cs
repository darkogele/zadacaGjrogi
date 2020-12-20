using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolApi.Contracts;
using SchoolApi.Data.SchoolDbContext;

namespace FictitiousSchoolApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Connection to Database, type of driver config 
            services.AddDbContext<SchoolDbContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
            });

            services.AddCors();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FictitiousSchoolApi", Version = "v1" });
            });


            // Dependency injection resolvers
            services.AddScoped<ICourseRepository, CourseRository>();
            services.AddScoped<ICompanyRepository, CompanyRepo>();
            services.AddScoped<IParticipantsRepository, ParticipantsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FictitiousSchoolApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
