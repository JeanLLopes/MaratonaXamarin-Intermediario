using MonkeyHubApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentsPage : ContentPage
	{
		public CommentsPage()
		{
			InitializeComponent ();
		}

        //REESCREVEMSO O METODO DE LOAD DA PAGINA 
        protected override void OnAppearing()
        {
            //CHAMA O METODO "LoadAsync" PARA FAZER O CARREGAMENTO DA TELA
            (this.BindingContext as CommentsViewModel)?.LoadAsync();
            base.OnAppearing();
        }

    }
}