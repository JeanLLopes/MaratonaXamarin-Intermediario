using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private readonly UserModel _userModel;

        public ObservableCollection<PostModel> Contents { get; }
        public Command<PostModel> ShowPostsCommand { get; set; }


        public PostViewModel(IMonkeyHubApiService monkeyHubApiService, UserModel userModel)
        {
            _monkeyHubApiService = monkeyHubApiService;
            _userModel = userModel;

            Contents = new ObservableCollection<PostModel>();
            ShowPostsCommand = new Command<PostModel>(ExecuteShowPostsCommand);
        }

        private async void ExecuteShowPostsCommand(PostModel postModel)
        {
            await PushAsync<CommentsViewModel>(_monkeyHubApiService, postModel);
        }


        //
        public async Task LoadAsync()
        {
            var contents = await _monkeyHubApiService.GetPostsByUserIdAsync(_userModel.Id);

            Contents.Clear();
            foreach (var item in contents)
            {
                Contents.Add(item);
            }
        }
    }
}
