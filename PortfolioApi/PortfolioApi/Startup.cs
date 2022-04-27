using FluentValidation;
using FluentValidation.AspNetCore;
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
using PortfolioApi.Api.Admin.AdminDTOs.ABlogDto;
using PortfolioApi.Api.Admin.AdminDTOs.AContactDto;
using PortfolioApi.Api.Admin.AdminDTOs.AdminDto;
using PortfolioApi.Api.Admin.AdminDTOs.AEducationDto;
using PortfolioApi.Api.Admin.AdminDTOs.APortfolioUserDto;
using PortfolioApi.Api.Admin.AdminDTOs.ASkillDto;
using PortfolioApi.Api.Admin.AdminDTOs.ASocialDto;
using PortfolioApi.Api.Admin.AdminDTOs.ATagDto;
using PortfolioApi.Api.Admin.AdminDTOs.AWorkExperience;
using PortfolioApi.Api.Client.DTOs.ContactMessageDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using PortfolioApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));

            }).AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllers().AddFluentValidation();


            services.AddScoped<IJwtServices, JwtServices>();
            services.AddTransient<IValidator<MessageCreateDto>, MessageCreateDtoValidator>();
            services.AddTransient<IValidator<AContactCreateDto>, AContactCreateDtoValidator>();
            services.AddTransient<IValidator<APortfolioUserCreateDto>, APortfolioUserCreateDtoValidator>();
            services.AddTransient<IValidator<ASocialCreateDto>, ASocialCreateDtoValidator>();
            services.AddTransient<IValidator<AWorkExperienceCreateDto>, AWorkExperienceCreateDtoValidator>();
            services.AddTransient<IValidator<AEducationCreateDto>, AEducationCreateDtoValidator>();
            services.AddTransient<IValidator<ASkillCreateDto>, ASkillCreateDtoValidator>();
            services.AddTransient<IValidator<ATagCreateDto>, ATagCreateDtoValidator>();
            services.AddTransient<IValidator<ABlogCreateDto>, ABlogCreateDtoValidator>();
            services.AddTransient<IValidator<AdminLoginDto>, AdminLoginDtoValidator>();

            

            services.AddAutoMapper(typeof(Startup));



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidIssuer = Configuration.GetSection("JWT:Issuer").Value,
                        ValidAudience = Configuration.GetSection("JWT:Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:Key").Value))

                    };


                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
