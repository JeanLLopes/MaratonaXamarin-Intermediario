using System.ComponentModel;
using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Descricao { get; set; }

        public MainViewModel()
        {
            Descricao = "Olá Viewmodel";

            //PARA NOTIFICAR A VIEW DA ATUALIZAÇÃO
            //DEVEMOS USAR UMA INTERFACE "INotifyPropertyChanged"
            Task.Delay(3000).ContinueWith(x =>
            {
                Descricao = "Meu Texto Mudou";


                if (PropertyChanged != null)
                {
                    //AQUI NOS ATUALIZAMOS A VIEW USANDO 
                    //A INTERFACE "INotifyPropertyChanged"
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Descricao"));

                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
