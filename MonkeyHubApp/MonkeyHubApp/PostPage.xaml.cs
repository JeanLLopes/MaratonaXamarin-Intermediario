using MonkeyHubApp.Models;
using MonkeyHubApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostPage : ContentPage
	{
		public PostPage()
		{
			InitializeComponent();
		}


        //REESCREVEMSO O METODO DE LOAD DA PAGINA 
        protected override void OnAppearing()
        {
            //CHAMA O METODO "LoadAsync" PARA FAZER O CARREGAMENTO DA TELA
            (this.BindingContext as PostViewModel)?.LoadAsync();
            base.OnAppearing();
        }


        private void ListView_OnItemSelected(object sender, EventArgs e)
        {
            var content = (sender as ListView).SelectedItem as PostModel;
            (BindingContext as PostViewModel)?.ShowPostsCommand.Execute(content);
        }


    }
}