using GenshinSchedule.SyncServer.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenshinSchedule.SyncServer
{
    public class Startup
    {
        readonly IConfiguration _configuration;
        readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _environment   = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson();

            services.AddAuthentication(AuthHandler.SchemeName)
                    .AddScheme<AuthOptions, AuthHandler>(AuthHandler.SchemeName, null);

            services.AddDbContextPool<SyncDbContext>(options => options.UseNpgsql(_configuration.GetConnectionString(nameof(SyncDbContext))));

            services.AddSingleton<AuthHelper>()
                    .AddSingleton<HashHelper>();

            if (_environment.IsProduction())
            {
                services.AddSingleton<IMetricsService, MetricsService>()
                        .AddTransient<IHostedService>(s => s.GetService<IMetricsService>());
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(cors => cors.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}