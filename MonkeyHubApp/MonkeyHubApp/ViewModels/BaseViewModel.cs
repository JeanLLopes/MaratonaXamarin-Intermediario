using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //COM O "CallerMemberName", O METODO JÁ PEGA 
        //AUTOMATICAMENTE O NOME DA PROPRIEDADE 
        //ASSIM NÃO É NECESSARIO PASSAR A PROPRIEDADE POR PARAMETRO
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }


        //COM ESTE MÉTODO NOS NAO PRECISAMOS MAIS USAR 
        //O SET DAS PROPRIEDADES, POIS ESTE METODO JÁ RECEBE O VALOR 
        //VIA STRING E DEVOLVE O VALOR VIA REFERENCIA "ref"
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            //AQUI NOS FAZEMOS AS COMPARAÇÕES DOS TIPOS RECEBIDOS
            //NO EqualityComparer ELE VAI FAZER UMA COMPARAÇÃO ENTRE
            //OS TIPOS RECEBIDOS, INDEPENDENTE DE QUAIS TIPO SEJAM
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }


        #region NAVEGAÇÃO
        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);

            var viewModelTypeName = viewModelType.Name;
            var viewModelTypeLength = "ViewModel".Length;
            var viewTypeName = $"MonkeyHubApp.{viewModelTypeName.Replace("ViewModel", "Page")}";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                //DEFINI O BINDING CONTEXT CORRETO PARA A PAGE
                page.BindingContext = viewModel;
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        } 
        #endregion
    }
}
