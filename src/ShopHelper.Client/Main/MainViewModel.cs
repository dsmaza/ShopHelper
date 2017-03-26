using System.Windows.Input;

namespace ShopHelper.Client.Main
{
    public class MainViewModel : ViewModel<IMainView>
    {
        private ICommand showShoppingListCommand;

        public MainViewModel(IMainView view) : base(view)
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
