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
    }
}
