using IncidentTracker.Application.DI;
using IncidentTracker.Application.Settings;
using IncidentTracker.Infrastructure.DI;
using IncidentTracker.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace IncidentTracker.Api;

public static class Configuration {
    public static void AddDependencies(this WebApplicationBuilder builder) {
        builder.ConfigureSettings();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();




        builder.Services.AddSwagger();
        builder.AddAuthentication();

    }
    public static void AddSwagger(this IServiceCollection services) {
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "3.1.0" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });



        });

    }
    public static void AddAuthentication(this WebApplicationBuilder builder) {

        var tokenSetting = new TokenSettings();
        builder.Configuration.GetSection(nameof(TokenSettings)).Bind(tokenSetting);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options => {
         options.TokenValidationParameters = new TokenValidationParameters {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,

             ValidIssuer = tokenSetting.Issuer,
             ValidAudience = tokenSetting.Audience,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSetting.IssuerSigningKey))
         };
     });

        builder.Services.AddAuthorization();
    }
    private static void ConfigureSettings(this WebApplicationBuilder builder) {
        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection(nameof(TokenSettings)));
        builder.Services.Configure<DbSettings>(builder.Configuration.GetSection(nameof(DbSettings)));
    }





}
