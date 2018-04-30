using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;

namespace MonkeyHubApp
{
	public partial class MainPage : ContentPage
	{
        private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainPageViewModel(new MonkeyHubApiService());

            //CLIQUE DO BOTAO DE ITEM SELECIONADO
            this.ListViewJornalistas.ItemSelected += (sender, e) =>
             {
                 ViewModel.ShowPostCommand.Execute(e.SelectedItem);
             };


            //AQUI NOS LIGAMOS A VIEWMODEL A TELA
            //BindingContext = new MainPageViewModel();

            //PARA CLIARMOS O CLICK DE UM BOTAO COM NAVEGAÇÃO
            //BtnNavegar.Clicked += async (sender, e) =>
            //{
            //    await Navigation.PushAsync(new SearchPage());
            //};
        }

        //REESCREVEMSO O METODO DE LOAD DA PAGINA 
        protected override void OnAppearing()
        {
            //CHAMA O METODO "LoadAsync" PARA FAZER O CARREGAMENTO DA TELA
            (this.BindingContext as MainPageViewModel)?.LoadAsync();
            base.OnAppearing();
        }

    }
}
