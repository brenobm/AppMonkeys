using AppMoneys.ViewModels;
using Xamarin.Forms;

namespace AppMoneys
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void ButtonNaoModal_Clicked(object sender, System.EventArgs e)
        {
            Navigation?.PushAsync(new MainPage());
        }

        private void ButtonModal_Clicked(object sender, System.EventArgs e)
        {
            Navigation?.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}
