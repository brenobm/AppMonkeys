using AppMoneys.Models;
using AppMoneys.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMoneys.ViewModels
{
    public class CategoriaViewModel: BaseViewModel
    {
        private readonly IMonkeyHubApiService _mokeyHubApiService;
        private readonly Tag _tag;

        public ObservableCollection<Content> Contents { get; }

        public Command ShowContentCommand { get; }

        public CategoriaViewModel(IMonkeyHubApiService mokeyHubApiService, Tag tag)
        {
            _mokeyHubApiService = mokeyHubApiService;
            _tag = tag;

            Contents = new ObservableCollection<Content>();
            ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);
        }

        private async void ExecuteShowContentCommand(Content content)
        {
            //await PushAsync<ContentWebViewModel>(content);
        }

        public async Task LoadAsync()
        {
            var contents = await _mokeyHubApiService.GetContentsByTagIdAsync(_tag.Id);

            Contents.Clear();

            foreach(var content in contents)
            {
                Contents.Add(content);
            }
        }
    }
}
