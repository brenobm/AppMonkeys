using AppMoneys.Models;
using AppMoneys.Services;
using AppMoneys.ViewModels;
using Xamarin.Forms;

namespace AppMoneys
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();
            var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();

            BindingContext = new MainViewModel(monkeyHubApiService);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }
    }
}
