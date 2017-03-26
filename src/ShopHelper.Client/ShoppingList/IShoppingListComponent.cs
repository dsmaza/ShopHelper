using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopHelper.Client.ShoppingList
{
    public interface IShoppingListComponent
    {
        Task Show(INavigation navigation);
    }
}
