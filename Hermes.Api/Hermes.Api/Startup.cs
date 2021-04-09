using Hermes.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Hermes.Api.Models;
using Microsoft.AspNetCore.Identity;
using Hermes.Api.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hermes.Api.Services;

namespace Hermes.Api
{
    public class Startup
    {
        private readonly string DevelopmentPolicy = "_DevelopmentPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          


            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(d=> {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddCors(options =>
            {
                options.AddPolicy(DevelopmentPolicy,
                builder =>
                {
                    builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .WithMethods("*")
                        .AllowAnyHeader();
                });
            });

            services.AddMvc().AddNewtonsoftJson();

           
            services.AddControllers();
            services.AddTransient<SeedDb>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IArticuloService, ArticuloService>();
            services.AddScoped<ITipoComprobanteService, TipoComprobanteService>();
            services.AddScoped<ITipoIdentificacionService, TipoIdentificacionService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IClienteService, ClienteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsDevelopment())
            {
                app.UseCors(DevelopmentPolicy);
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
