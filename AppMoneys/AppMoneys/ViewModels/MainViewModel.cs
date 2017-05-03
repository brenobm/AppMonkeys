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
        private readonly IMonkeyHubApiService _mokeyHubApiService;

        public ObservableCollection<Tag> Tags { get; }

        public Command AboutCommand { get; }

        public Command ShowCategoriaCommand { get; }

        public MainViewModel(IMonkeyHubApiService mokeyHubApiService)
        {
            this.Tags = new ObservableCollection<Tag>();
            this._mokeyHubApiService = mokeyHubApiService;
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

        public override async Task LoadAsync()
        {
            var tags = await _mokeyHubApiService.GetTagsAsync();

            System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", tags.Count);
            Tags.Clear();

            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }

            OnPropertyChanged(nameof(Tags));
        }
    }
}
