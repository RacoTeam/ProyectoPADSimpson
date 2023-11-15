using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace ProyectoBlazor
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
            // Otras configuraciones...

            // Configura políticas CORS en ConfigureServices
            services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Resto de las configuraciones de servicios...
        }

        public void Configure(IApplicationBuilder app)
        {
            // Otras configuraciones...
            
            // Usa la política CORS en Configure
            app.UseCors("NuevaPolitica");

            // Otras configuraciones...

            // Configura el enrutamiento y otras configuraciones...
        }
    }
}

