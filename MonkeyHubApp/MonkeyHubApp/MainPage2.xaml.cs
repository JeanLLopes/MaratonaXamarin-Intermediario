using MonkeyHubApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage2 : ContentPage
	{
		public MainPage2 ()
		{
			InitializeComponent ();
            //AQUI NOS LIGAMOS A VIEWMODEL A TELA
            BindingContext = new MainPage2ViewModel();
        }
    }
}