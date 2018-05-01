using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyHubApp.Controls
{
    public class MyListView : ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
                                       BindableProperty.Create("ItemTappedCommand",
                                       typeof(ICommand),
                                       typeof(MyListView),
                                       null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set
            {
                SetValue(ItemTappedCommandProperty, value);

            }
        }

        public MyListView(ListViewCachingStrategy strategy) : base(strategy)
        {
            this.Intitialize();
        }

        public MyListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            this.Intitialize();
        }

        private void Intitialize()
        {
            try
            {
                this.ItemSelected += (sender, e) =>
                {
                    if (ItemTappedCommand == null)
                        return;

                    if (ItemTappedCommand.CanExecute(e.SelectedItem))
                        ItemTappedCommand.Execute(e.SelectedItem);

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
