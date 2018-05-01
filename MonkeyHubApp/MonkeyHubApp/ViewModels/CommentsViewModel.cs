using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class CommentsViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private readonly PostModel _postModel;
        public ObservableCollection<CommentsModel> Comments { get; }
        public Command AboutCommand { get; }


        public CommentsViewModel(IMonkeyHubApiService monkeyHubApiService, PostModel postModel)
        {
            _postModel = postModel;
            _monkeyHubApiService = monkeyHubApiService;
            Comments = new ObservableCollection<CommentsModel>();
            AboutCommand = new Command(ExecuteAboutCommand);

        }

        private async void ExecuteAboutCommand(object obj)
        {
            await PushAsync<AboutViewModel>();

        }

        public PostModel PostModel { get; }

        public CommentsViewModel(PostModel postModel)
        {
            PostModel = postModel;
        }


        public async Task LoadAsync()
        {
            var contents = await _monkeyHubApiService.GetCommentsByIdAsync(_postModel.Id);

            Comments.Clear();
            foreach (var item in contents)
            {
                Comments.Add(item);
            }
        }

    }
}
