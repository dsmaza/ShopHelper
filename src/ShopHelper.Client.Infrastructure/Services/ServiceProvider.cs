using System;
using ShopHelper.Client.Logging;
using ShopHelper.Client.ShoppingList;
using SimpleInjector;

namespace ShopHelper.Client.Services
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly Container container;

        private ServiceProvider(Container container)
        {
            Guard.NotNull(container, nameof(container));
            this.container = container;
        }

        public static IServiceProvider Create()
        {
            var container = new Container();
            container.RegisterSingleton<IFileService, FileService>();
            container.RegisterSingleton<FileLogBuilder>();
            container.Register<IShoppingListService, ShoppingListService>();       
            container.Register(typeof(ILogger<>), typeof(FileLogger<>));  

            return new ServiceProvider(container);
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
    }
}
