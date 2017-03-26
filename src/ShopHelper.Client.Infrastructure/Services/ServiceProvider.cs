using System;
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
            container.Register<IFileService, FileService>();
            container.Register<IShoppingListService, ShoppingListService>();

            return new ServiceProvider(container);
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
    }
}
