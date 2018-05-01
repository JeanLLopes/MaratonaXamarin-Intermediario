using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private readonly UserModel _userModel;

        public ObservableCollection<PostModel> Posts { get; }
        public Command<PostModel> ShowPostsCommand { get; set; }
        public Command AboutCommand { get; }


        public PostViewModel(IMonkeyHubApiService monkeyHubApiService, UserModel userModel)
        {
            _monkeyHubApiService = monkeyHubApiService;
            _userModel = userModel;

            Posts = new ObservableCollection<PostModel>();
            ShowPostsCommand = new Command<PostModel>(ExecuteShowPostsCommand);
            AboutCommand = new Command(ExecuteAboutCommand);

        }

        private async void ExecuteAboutCommand(object obj)
        {
            await PushAsync<AboutViewModel>();
        }

        private async void ExecuteShowPostsCommand(PostModel postModel)
        {
            await PushAsync<CommentsViewModel>(_monkeyHubApiService, postModel);
        }


        //
        public async Task LoadAsync()
        {
            var contents = await _monkeyHubApiService.GetPostsByUserIdAsync(_userModel.Id);

            Posts.Clear();
            foreach (var item in contents)
            {
                item.Title = item.Title.ToUpper();
                Posts.Add(item);
            }
        }
    }
}
