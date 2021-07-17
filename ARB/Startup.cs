using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ARB.Startup))]
namespace ARB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);  
        }
        public void ConfigureServices(IServiceCollection services)
        {
           /* var cors = new EnableCorsAttribute("*", "*", "*");*/
            services.AddCors();
         /*   services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
*/
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader() 
                );


        }
    }
}
