using MonkeyHubApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyHubApp.ViewModels
{
    public class CommentsViewModel : BaseViewModel
    {
        public PostModel PostModel { get; }

        public CommentsViewModel(PostModel postModel)
        {
            PostModel = postModel;
        }
    }
}
