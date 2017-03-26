using System;

namespace ShopHelper.Client.Services
{
    public static class ServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService(typeof(TService));
            if (service == null)
            {
                throw new InvalidOperationException($"Service '{typeof(TService).Name}' not registered!");
            }
            return (TService)service;
        }
    }
}
