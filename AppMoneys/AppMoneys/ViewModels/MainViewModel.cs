using AppMoneys.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;

namespace AppMoneys.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tag>>(
                        await new StreamReader(responseStream)
                        .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        private string _searchTerm = "Texto Inicial";

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

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
            this.Results = new ObservableCollection<Tag>();
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

                var returnTags = await GetTagsAsync();

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
