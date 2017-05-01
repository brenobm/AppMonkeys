using AppMoneys.Models;
using AppMoneys.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace AppMoneys.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private string _searchTerm;

        private readonly IMonkeyHubApiService _mokeyHubApiService;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if(SetPropery(ref _searchTerm, value))
                {
                    SearchCommand.ChangeCanExecute();
                }
            }
        }

        public ObservableCollection<Tag> Results { get; }

        public Command SearchCommand { get; }

        public Command AboutCommand { get; }

        public Command ShowCategoriaCommand { get; }

        public MainViewModel(IMonkeyHubApiService mokeyHubApiService)
        {
            this.Results = new ObservableCollection<Tag>();
            this._mokeyHubApiService = mokeyHubApiService;
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaViewModel>(_mokeyHubApiService, tag);
        }

        private async void ExecuteAboutCommand(object obj)
        {
            await PushAsync<AboutViewModel>();
        }

        async void ExecuteSearchCommand(object obj)
        {
            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por {this._searchTerm}", "Sim", "Não");

            if (resposta)
            {
                Results.Clear();

                var returnTags = await _mokeyHubApiService.GetTagsAsync();

                if (returnTags != null)
                {
                    foreach(var tag in returnTags)
                    {
                        Results.Add(tag);
                    }
                }
            }
        }

        bool CanExecuteSearchCommand(object arg)
        {
            return !string.IsNullOrWhiteSpace(this._searchTerm);
        }
    }
}
