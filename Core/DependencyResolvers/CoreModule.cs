using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColleciton)
        {
            serviceColleciton.AddMemoryCache();
            serviceColleciton.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceColleciton.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceColleciton.AddSingleton<Stopwatch>();

        }
    }
}
