﻿using Microsoft.Extensions.Configuration;
using Sm5sh.Interfaces;
using Sm5sh.Mods.Music;
using Sm5sh.Mods.Music.Interfaces;
using Sm5sh.Mods.Music.ResourceProviders;
using Sm5sh.Mods.Music.Services;
using Sm5sh.ResourceProviders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Sm5shMusicDependencyInjectionExtensions
    {
        public static IServiceCollection AddSm5shMusic(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Sm5shMusicOptions>(configuration);
            services.AddSingleton<ISm5shMod, BgmMod>();
            services.AddSingleton<IResourceProvider, BgmPropertyProvider>();
            services.AddSingleton<IResourceProvider, MsbtResourceProvider>();
            services.AddSingleton<IResourceProvider, PrcResourceProvider>();
            services.AddTransient<IAudioStateService, AudioStateService>();
            services.AddSingleton<IAudioMetadataService, VGAudioMetadataService>();
            services.AddSingleton<INus3AudioService, Nus3AudioService>();
            return services;
        }
    }
}
