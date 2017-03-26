using System;
using ShopHelper.Client.ShoppingList;

namespace ShopHelper.Client.Services
{
    public class ServiceProvider : IServiceProvider
    {
        private ServiceProvider()
        {

        }

        public static IServiceProvider Create()
        {
            return new ServiceProvider();
        }

        public object GetService(Type serviceType)
        {
            // TODO DI
            if (serviceType == typeof(IFileService))
            {
                return new FileService();
            }
            else if (serviceType == typeof(IShoppingListService))
            {
                return new ShoppingListService(new FileService());
            }
            return null;
        }
    }
}
