using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopHelper.Client.ShoppingList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingListView : ContentPage, IView
	{
		public ShoppingListView()
		{
			InitializeComponent();
		}
	}
}
