using System;
using CanvasScene.Auth;
using CanvasScene.DAL;
using CanvasScene.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CanvasScene
{
    public partial class Startup
    {

        public void AddAuthentication(IServiceCollection services)
        {
            services.AddSingleton<IJwtBuilder, JwtBuilder>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            var signingKey = new SymmetricSecurityKey(Constants.GetKey());

            Configuration.Bind("JwtIssuerOptions", new JwtIssuerOptions());
            var opts = services.AddOptions<JwtIssuerOptions>("JwtIssuerOptions");

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = Constants.Issuer;
                options.Audience = Constants.Audience;
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Constants.Issuer,

                ValidateAudience = true,
                ValidAudience = Constants.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = Constants.Issuer;
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, //Constants.Strings.JwtClaims.ApiAccess));
            //});

            var builder = services.AddIdentityCore<AppUser>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();
        }

    }
}