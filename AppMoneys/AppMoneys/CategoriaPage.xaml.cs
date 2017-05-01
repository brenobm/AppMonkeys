using AppMoneys.Models;
using AppMoneys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMoneys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (BindingContext as CategoriaViewModel)?.LoadAsync();

            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var content = (sender as ListView).SelectedItem as Content;
            (BindingContext as CategoriaViewModel)?.ShowContentCommand.Execute(content);
        }
    }
}
