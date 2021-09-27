using EventApp.Entities;
using EventApp.InterfaceAdapters.DataStorage;
using EventApp.InterfaceAdapters.RestApi.Utils;
using EventApp.UseCases;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace EventApp.InterfaceAdapters.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            var session = SessionFactoryCreator.Create().OpenSession();
            services.AddSingleton(session);

            services.AddSingleton<IRepository<Message>, NHibernateRepository<Message>>();
            services.AddSingleton<IRepository<User>, NHibernateRepository<User>>();
            services.AddSingleton<IRepository<Hobby>, NHibernateRepository<Hobby>>();
            services.AddSingleton<IRepository<Campaign>, NHibernateRepository<Campaign>>();

            services.AddSingleton<UserService>();
            services.AddSingleton<HobbyService>();
            services.AddSingleton<CampaignService>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
