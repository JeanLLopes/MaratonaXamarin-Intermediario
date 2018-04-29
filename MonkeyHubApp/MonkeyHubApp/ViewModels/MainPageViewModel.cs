using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        //propfull
        private string _descricao;

        public string Descricao
        {
            get { return _descricao;  }
            set
            {
                //_descricao = value;

                //if (PropertyChanged != null)
                //{
                //AQUI NOS ATUALIZAMOS A VIEW USANDO 
                //A INTERFACE "INotifyPropertyChanged"
                //AO INVES DE PASSAR O NOME DA PROPRIEDADE EM "Descricao"
                //VAMOS USAR O NAMEOF nameof(Descricao)
                //
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Descricao)));

                //}


                //PARA EVITAR MAIORES ERROS VAMOS USAR UM 
                //UNICO METODO PARA FAZER A ALTERÃÇÃO DO ITEM
                //OnPropertyChanged();

                //CHAMAMOS O MÉTODO SetProperty
                SetProperty(ref _descricao, value);
            }
        }

        //propfull
        //private string _nome;
        //public string Nome
        //{
        //    get { return _nome; }
        //    set
        //    {
        //        SetProperty(ref _descricao, value);
        //    }
        //}

        //propfull
        private int _idade;

        public int Idade
        {
            get { return _idade; }
            set { SetProperty(ref _idade, value); }
        }

        public MainPageViewModel()
        {
            Descricao = "Olá Viewmodel";

            //PARA NOTIFICAR A VIEW DA ATUALIZAÇÃO
            //DEVEMOS USAR UMA INTERFACE "INotifyPropertyChanged"
            Task.Delay(3000).ContinueWith(async x =>
            {
                Descricao = "Meu Texto Mudou";

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    Descricao = $"Meu Texto mudou {i}";
                }
            });
        }

    }
}
