using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notes.DAL;
using Notes.Repositories;
using Notes.Services;
using Notes.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI
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
            services.AddDbContext<NotesDbContext>(op => op.UseInMemoryDatabase("Test"));               

            services.AddControllers();
            services.AddScoped<INoteService, NoteService>();

            services.AddCors(options => options.AddPolicy("NoteAppCorsPolicy", builder =>
            {
                builder
                    .WithOrigins(@"http://localhost:3000", "http://127.0.0.1:3000")
                    .AllowAnyMethod()//("GET, POST, PUT, DELETE, OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("Location"); ;
            }));
            services.AddScoped<NotesUoW>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("NoteAppCorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
