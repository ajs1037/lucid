using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lucid
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            // db context configuration
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            // services configuration
            // 
            // In ASP.NET MVC, services.AddScoped is used to register a service with a scoped lifetime. A service registered as
            // scoped will be created once per HTTP request and will be shared by any component that needs it during that request.

            // When you call services.AddScoped in the ConfigureServices method of your application's Startup class, you're telling the ASP.NET
            // runtime to create an instance of the service when it's first requested during a given HTTP request. That instance will be reused by
            // any component that needs it within the same request, but then discarded at the end of the request.

            // In an ASP.NET Core application, when you register a service with the dependency injection (DI) container, you typically
            // register it as an interface and a concrete implementation class that implements that interface. This is a common design
            // pattern known as the Dependency Inversion Principle (DIP), which states that:

            // "High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not
            // depend on details. Details should depend on abstractions."

            // By registering services as interfaces and implementations, you decouple the code that depends on those services from the
            // specific implementation details of those services. Instead, the code depends only on the abstractions( i.e., the interfaces )
            // that define the services. This makes it easier to maintain and test your code, as you can easily swap out different
            // implementations of a service by changing the registration of the service with the DI container.

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITeamService, TeamService>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( "/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapRazorPages();
            } );

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}" );
            } );
        }
    }
}
