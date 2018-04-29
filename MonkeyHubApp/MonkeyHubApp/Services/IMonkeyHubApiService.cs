using MonkeyHubApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyHubApp.Services
{
    public interface IMonkeyHubApiService
    {
        Task<List<UserModel>> GetUsersAsync();
        Task<List<PostModel>> GetPostsByUserIdAsync(int idUser);
        Task<PostModel> GetPostByIdAsync(int IdPost);
        Task<List<CommentsModel>> GetCommentsByIdAsync(int IdPost);
    }
}
