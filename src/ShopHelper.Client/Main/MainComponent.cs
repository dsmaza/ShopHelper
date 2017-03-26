using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopHelper.Client.Main
{
    public class MainComponent : IMainComponent
    {
        private readonly MainViewModel viewModel;
        private readonly IAppComponents appComponents;

        public MainComponent(MainViewModel viewModel, IAppComponents appComponents)
        {
            Guard.NotNull(viewModel, nameof(viewModel));
            Guard.NotNull(appComponents, nameof(appComponents));
            this.viewModel = viewModel;
            this.appComponents = appComponents;
            OnInit();
        }

        private void OnInit()
        {
            viewModel.ShowShoppingListCommand = new Command(async () => await ShowShoppingList());
        }

        private async Task ShowShoppingList()
        {
            var shoppingList = appComponents.GetShoppingList();
            await shoppingList.Show(appComponents.Navigation);
        }
    }
}
