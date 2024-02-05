

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Tasks.Data;
using Tasks.Enuns;
using Tasks.Model;

namespace Tasks.Views
{
    public partial class ListPage : ContentPage, INotifyPropertyChanged
    {

        TaskModelDataBase db;


        public ListPage()
        {
            InitializeComponent();

            db = new TaskModelDataBase();

        }

        protected override async void OnAppearing() 
        {
            base.OnAppearing();

            var lista = await db.getAllTasks();

            taskListView.ItemsSource = lista.OrderBy(t => t.Priority).Reverse().ToList();

        }

 

        public async void OnDetails(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails(new TaskModel()));
         
        }

        private async void taskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails((TaskModel)e.Item));
        }
   
    }

}
