using System.Threading.Tasks;
using ShopHelper.Client.ShoppingList;
using Xamarin.Forms;

namespace ShopHelper.Client.Main
{
    public class MainComponent
    {
        private readonly MainViewModel viewModel;
        private bool running;
        private NavigationPage rootNavigationPage;

        public MainComponent()
        {
            viewModel = new MainViewModel(new MainView());
            OnInit();
        }

        private void OnInit()
        {
            viewModel.ShowShoppingListCommand = new Command(async () => await ShowShoppingList());
        }

        public void Run(Application app)
        {
            if (!running)
            {
                app.MainPage = rootNavigationPage = new NavigationPage(viewModel.View);
                running = true;
            }
        }

        private async Task ShowShoppingList()
        {
            var shoppingList = new ShoppingListComponent();
            await shoppingList.Show(rootNavigationPage.Navigation);
        }
    }
}
