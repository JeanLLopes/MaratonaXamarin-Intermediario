using MonkeyHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.Services
{
    public interface IMonkeyHubApiService
    {
        Task<List<PostModel>> GetPostsAsync();
        Task<PostModel> GetPostByIdAsync(int Id);
    }
}
