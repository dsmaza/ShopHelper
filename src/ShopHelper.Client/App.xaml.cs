using ShopHelper.Client.Main;
using ShopHelper.Client.Services;
using Xamarin.Forms;

namespace ShopHelper.Client
{
    public partial class App : Application
	{
        private readonly MainComponent mainComponent;

		public App()
		{
			InitializeComponent();

            var mainView = new MainView();
            MainPage = new NavigationPage(mainView);
            var mainViewModel = new MainViewModel(mainView);
            var appComponents = new AppComponents(MainPage.Navigation, ServiceProvider.Create());
            mainComponent = new MainComponent(mainViewModel, appComponents);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
