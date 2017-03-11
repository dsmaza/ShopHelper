using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopHelper.Client.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage, IView
	{
		public MainView()
		{
			InitializeComponent();
		}
	}
}
