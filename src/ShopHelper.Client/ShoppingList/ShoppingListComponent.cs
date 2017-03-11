using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopHelper.Client.ShoppingList
{
    public class ShoppingListComponent
    {
        private readonly ShoppingListViewModel viewModel;

        public ShoppingListComponent()
        {
            viewModel = new ShoppingListViewModel(new ShoppingListView());
            OnInit();
        }

        private void OnInit()
        {
            viewModel.ShoppingListItems = new ObservableCollection<ShoppingListItem>();
            viewModel.RefreshDataCommand = new Command(async () => await RefreshData());
            viewModel.AddShoppingListItemCommand = new Command(AddShoppingListItem);
        }

        private async Task RefreshData()
        {
            await Task.Delay(100);
        }

        private void AddShoppingListItem()
        {
            string newValue = viewModel.NewShoppingListItemValue;
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                viewModel.ShoppingListItems.Add(new ShoppingListItem
                {
                    Title = newValue
                });
                viewModel.NewShoppingListItemValue = null;
            }
        }

        public async Task Show(INavigation navigation)
        {
            Guard.NotNull(navigation, nameof(navigation));
            await navigation.PushAsync(viewModel.View);
        }
    }
}
