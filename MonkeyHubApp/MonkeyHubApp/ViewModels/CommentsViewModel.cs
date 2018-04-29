using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class CommentsViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private readonly PostModel _postModel;
        public ObservableCollection<CommentsModel> Comments { get; }


        public CommentsViewModel(IMonkeyHubApiService monkeyHubApiService, PostModel postModel)
        {
            _postModel = postModel;
            _monkeyHubApiService = monkeyHubApiService;
            Comments = new ObservableCollection<CommentsModel>();
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
