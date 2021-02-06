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
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.WithOrigins("http://10.5.50.75:4200 ")
                .AllowAnyMethod()
                .AllowAnyHeader() 
                );

        }
    }
}
