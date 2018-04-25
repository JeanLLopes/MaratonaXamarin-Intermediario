using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainPage2ViewModel : BaseViewModel
    {
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                //SE O VALOR FOI ALTERADO VIA set
                //ELE VAI REAVALIAR SE O BOTAO DEVE SE HABILITADO OU NAO
                if (SetProperty(ref _searchTerm, value))
                {
                    SearchCommand.ChangeCanExecute(); 
                }
            }
        }

        public MainPage2ViewModel()
        {
            SearchCommand = new Command(ExecuteSeachCommand, CanExecuteSearchCommand);
        }


        //PARA USAR OS COMMANDS QUE USAM O VIEW COM A TELA
        //SearchCommand VAI SER APENAS GET
        //NÃO SERA set, POIS NÃO TERÃO ALTERAÇÕES NELA
        //DO JEITO QUE ELA FOR CRIADA ELA VAI FICAR
        //COMO UMA PROPRIEDADE readonly
        public Command SearchCommand { get; }


        //DETERMINA QUANDO O PODE SER EXECUTADO
        //COMO SE FOSSE UM HABILITAR E DESABILITAR O BOTAO
        //SE RETORNA "TRUE" BOTAO ESTA HABILITADO
        //SE RETORNA "FALSE" BOTAO ESTA DESABILITADO
        private bool CanExecuteSearchCommand(object arg)
        {
            //AVALIA SE O TEXTO ESTA PREENCHIDO
            return !string.IsNullOrWhiteSpace(SearchTerm); 
        }

        private async void ExecuteSeachCommand(object obj)
        {
            //AQUI FAZEMOS A LOGICA DO BOTÃO
            //Debug.WriteLine($"Clicou no botão {DateTime.Now.ToString()}");

            //APRESENTANDO O DISPLAY ALERT
            //await App.Current.MainPage.DisplayAlert("App Name", $"Você pesquisou por {SearchTerm}", "OK");

            //USANDO UMA ARVORE DE DECISÃO
            bool result = await App.Current.MainPage.DisplayAlert("App Name", $"Você pesquisou por {SearchTerm}", "Sim", "Não");

            if (result)
            {
                await App.Current.MainPage.DisplayAlert("App Name", "Você clicou em SIM", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("App Name", "Você clicou em NÃO", "OK");
            }
        }
    }
}
