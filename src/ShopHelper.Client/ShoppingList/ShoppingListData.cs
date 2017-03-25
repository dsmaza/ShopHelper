using System.Collections.Generic;

namespace ShopHelper.Client.ShoppingList
{
    public class ShoppingListData
    {
        public List<ShoppingListItem> Items { get; set; }

        public System.DateTime Saved { get; set; }
    }
}
