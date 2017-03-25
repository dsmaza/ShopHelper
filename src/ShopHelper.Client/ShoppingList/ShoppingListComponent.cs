using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopHelper.Client.ShoppingList
{
    public class ShoppingListComponent
    {
        private readonly ShoppingListViewModel viewModel;
        private readonly ShoppingListService service;

        public ShoppingListComponent()
        {
            viewModel = new ShoppingListViewModel(new ShoppingListView());
            service = new ShoppingListService();
            OnInit();
        }

        private void OnInit()
        {
            viewModel.ShoppingListItems = new ObservableCollection<ShoppingListItem>();
            viewModel.RefreshDataCommand = new Command(async () => await RefreshData());
            viewModel.AddShoppingListItemCommand = new Command(async () => await AddShoppingListItem());
        }

        private async Task RefreshData()
        {
            viewModel.Refreshing = true;

            var items = await service.Get();
            viewModel.ShoppingListItems.Clear();
            foreach (var item in items)
            {
                viewModel.ShoppingListItems.Add(item);
            }

            viewModel.Refreshing = false;
        }

        private async Task AddShoppingListItem()
        {
            string newValue = viewModel.NewShoppingListItemValue;
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                var newItem = new ShoppingListItem
                {
                    Title = newValue
                };

                await service.Add(newItem);
                viewModel.ShoppingListItems.Add(newItem);              
                viewModel.NewShoppingListItemValue = null;
            }
        }

        public async Task Show(INavigation navigation)
        {
            Guard.NotNull(navigation, nameof(navigation));
            await navigation.PushAsync(viewModel.View);
            await RefreshData();
        }
    }
}
