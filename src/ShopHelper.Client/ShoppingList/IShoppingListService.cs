using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopHelper.Client.ShoppingList
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingListItem>> Get();

        Task Add(ShoppingListItem item);
    }
}
