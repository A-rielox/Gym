﻿using API.Data;
using API.Interfaces;
using API.Services;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddAplicationServices(
                            this IServiceCollection services,
                            IConfiguration config
                            )
    {
        services.AddCors();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IClassRepository, ClassRepository>();


        //services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        //services.AddScoped<IPhotoService, PhotoService>();

        //services.AddScoped<LogUserActivity>();

        //services.AddScoped<ILikesRepository, LikesRepository>();
        //services.AddScoped<IMessageRepository, MessageRepository>();


        return services;
    }
}
