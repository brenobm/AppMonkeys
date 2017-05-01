using AppMoneys.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMoneys.Services
{
    public interface IMonkeyHubApiService
    {
        Task<List<Tag>> GetTagsAsync();
        Task<List<Content>> GetContentsByTagIdAsync(string tagId);
        Task<List<Content>> GetContentsByFilterAsync(string filter);
    }
}
