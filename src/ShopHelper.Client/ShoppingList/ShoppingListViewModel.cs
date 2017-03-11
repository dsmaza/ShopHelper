using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopHelper.Client.ShoppingList
{
    public class ShoppingListViewModel : ViewModel<ShoppingListView>
    {
        private ObservableCollection<ShoppingListItem> items;
        private ICommand refreshDataCommand;
        private ICommand addShoppingListItemCommand;
        private string newShoppingListItemValue;

        public ShoppingListViewModel(ShoppingListView view) 
            : base(view)
        {
        }

        public string Title => "Your Shopping List";

        public ObservableCollection<ShoppingListItem> ShoppingListItems
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public ICommand RefreshDataCommand
        {
            get { return refreshDataCommand; }
            set { SetProperty(ref refreshDataCommand, value); }
        }

        public ICommand AddShoppingListItemCommand
        {
            get { return addShoppingListItemCommand; }
            set { SetProperty(ref addShoppingListItemCommand, value); }
        }

        public string NewShoppingListItemValue
        {
            get { return newShoppingListItemValue; }
            set { SetProperty(ref newShoppingListItemValue, value); }
        }
    }
}
