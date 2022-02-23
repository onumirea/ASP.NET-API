using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Model.Constants;
using Proiect_O_A.Repositories;
using Proiect_O_A.Repositories.AutorRepository;
using Proiect_O_A.Repositories.IngredientMagazinRepository;
using Proiect_O_A.Repositories.IngredientRepository;
using Proiect_O_A.Repositories.MagazinRepository;
using Proiect_O_A.Repositories.RecenzieRepository;
using Proiect_O_A.Repositories.RetetaIngredientRepository;
using Proiect_O_A.Repositories.RetetaRepository;
using Proiect_O_A.Seed;
using Proiect_O_A.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_O_A
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";//
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
            //

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Proiect_O_A", Version = "v1" });
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ProiectOAContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy("User", policy => policy.RequireRole(UserRoleType.User));
                options.AddPolicy("Bucatar", policy => policy.RequireRole(UserRoleType.Bucatar));
                options.AddPolicy("ResponsabilMag", policy => policy.RequireRole(UserRoleType.ResponsabilMag));
                
            });
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth")),
                    ValidateIssuerSigningKey = true
                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                };
            });
            
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<ProiectOAContext>(options => options.UseSqlServer("Data Source=DESKTOP-ROLAIE2;Initial Catalog=ProiectOA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IMagazinRepository, MagazinRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRetetaRepository, RetetaRepository>();
            services.AddTransient<IRecenzieRepository, RecenzieRepository>();
            services.AddTransient<IRetetaIngredientRepository, RetetaIngredientRepository>();
            services.AddTransient<IIngredientMagazinRepository, IngredientMagazinRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            

            services.AddScoped<SeedDb>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, SeedDb seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProiectOA v1"));
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);//
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            try 
            {
                seed.SeedRoles().Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
