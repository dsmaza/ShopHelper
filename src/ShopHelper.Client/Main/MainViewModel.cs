using System.Windows.Input;

namespace ShopHelper.Client.Main
{
    public class MainViewModel : ViewModel<MainView>
    {
        private ICommand showShoppingListCommand;

        public MainViewModel(MainView view) : base(view)
        {
        }

        public string Title => "ShopHelper";

        public ICommand ShowShoppingListCommand
        {
            get { return showShoppingListCommand; }
            set { SetProperty(ref showShoppingListCommand, value); }
        }
    }
}
