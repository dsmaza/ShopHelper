using System;
using ShopHelper.Client.ShoppingList;
using ShopHelper.Client.Services;
using Xamarin.Forms;

namespace ShopHelper.Client
{
    public interface IAppComponents
    {
        INavigation Navigation { get; }

        IShoppingListComponent GetShoppingList();
    }

    public class AppComponents : IAppComponents
    {
        private readonly INavigation navigation;
        private readonly IServiceProvider serviceProvider;

        public AppComponents(INavigation navigation, IServiceProvider serviceProvider)
        {
            Guard.NotNull(navigation, nameof(navigation));
            Guard.NotNull(serviceProvider, nameof(serviceProvider));
            this.navigation = navigation;
            this.serviceProvider = serviceProvider;
        }

        public INavigation Navigation => navigation;

        public IShoppingListComponent GetShoppingList()
        {
            var vm = new ShoppingListViewModel(new ShoppingListView());
            var service = serviceProvider.GetService<IShoppingListService>();
            return new ShoppingListComponent(vm, service);
        }
    }
}
