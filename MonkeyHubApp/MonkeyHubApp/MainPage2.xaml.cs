using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage2 : ContentPage
	{
		public MainPage2 ()
		{
			InitializeComponent();
            //AQUI NOS LIGAMOS A VIEWMODEL A TELA
            BindingContext = new MainPage2ViewModel(new MonkeyHubApiService());
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = (sender as ListView).SelectedItem as UserModel;
            (BindingContext as MainPage2ViewModel)?.ShowPostCommand.Execute(user);
        }

        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new MainPage());
        //}
        //private void ButtonModal_OnClicked(object sender, EventArgs e)
        //{
        //    //Navigation.PushModalAsync(new MainPage());

        //    //PARA NAO DAR CRASH DE NAVEGAÇÃO DENTRO DE MODAL
        //    //NOS PODE HABILITAR UMA NOVA NAVIGATION DENTRO DO MODAL
        //    Navigation.PushModalAsync(new NavigationPage(new MainPage2()));
        //}

        ////VOLTA A NAVEGAÇÃO
        ////MATANDO A ULTIMA TELA QUE SUBIU
        //private void ButtonVoltarModal_OnClicked(object sender, EventArgs e)
        //{
        //    Navigation?.PopModalAsync();
        //}
    }
}