using AppMoneys.Models;
using AppMoneys.Services;
using AppMoneys.ViewModels;
using Xamarin.Forms;

namespace AppMoneys
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(new MonkeyHubApiService());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tag = (sender as ListView)?.SelectedItem as Tag;
            (BindingContext as MainViewModel)?.ShowCategoriaCommand.Execute(tag);
        }
    }
}
