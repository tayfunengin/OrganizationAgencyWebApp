using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repository;
using Repository.Authentication;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public static class IocContainer
    {
        public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<AppUser>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 4;
                x.Password.RequireNonAlphanumeric = false;
            }).AddRoles<AppUserRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(/*CookieAuthenticationDefaults.AuthenticationScheme*/)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                 options =>
                 {
                     options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/login");
                     options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                     {
                         Name = "AgencyAppCookie"
                     };
                     options.SlidingExpiration = true;
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
                     
                 });

            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                //x.AccessDeniedPath= new Microsoft.AspNetCore.Http.PathString("Path");
                x.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name = "AgencyAppCookie"
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(3);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                
            })
                .AddIdentityCookies();


            services.AddHttpContextAccessor();
            // Identity services
            services.TryAddScoped<IUserValidator<AppUser>, UserValidator<AppUser>>();
            services.TryAddScoped<IPasswordValidator<AppUser>, PasswordValidator<AppUser>>();
            services.TryAddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<AppUserRole>, RoleValidator<AppUserRole>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<AppUser>>();
            services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<AppUser>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<AppUser>, UserClaimsPrincipalFactory<AppUser, AppUserRole>>();
            services.TryAddScoped<UserManager<AppUser>>();
            services.TryAddScoped<SignInManager<AppUser>>();
            services.TryAddScoped<RoleManager<AppUserRole>>();
        }
    }
}
