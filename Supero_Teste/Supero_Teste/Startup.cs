using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using AutoMapper;
using Core.Services;
using Data;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Supero_Teste
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BaseRoute")));

            var jwtService = new JwtAppService();

            services.AddMvc();
            services.AddAutoMapper();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "APIs",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }}
                });

                options.DescribeAllEnumsAsStrings();

                var apiXmlDoc = $@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.Api.xml";
                if (File.Exists(apiXmlDoc))
                {
                    options.IncludeXmlComments(apiXmlDoc);
                }
            });

            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                    {
                        options.IncludeErrorDetails = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = jwtService.GetValidationParameters();
                        options.SecurityTokenValidators.Clear();

                        options.SecurityTokenValidators.Add(new JwtSecurityTokenHandler());
                    }
                );

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();
            });

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            //Services
            services.AddScoped<JwtAppService>();
            services.AddScoped<LoginAppService>();
            services.AddScoped<TaskAppService>();
            services.AddScoped<UserAppService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app. UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs"); });

            app.UseMvc();
        }
    }
}
