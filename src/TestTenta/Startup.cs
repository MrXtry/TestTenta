using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using TestTenta.Repositories.Db;
using TestTenta.Repositories;
using Microsoft.Data.Entity;
using TestTenta.Models;

namespace TestTenta
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=TestTenta;Integrated Security=True;Pooling=False";

            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(
                    options => options.UseSqlServer(connString)
                );

            services.AddMvc();

            services.AddTransient<IArtistRepository, DbArtistRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/StatusCodes/StatusCode{0}");
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
