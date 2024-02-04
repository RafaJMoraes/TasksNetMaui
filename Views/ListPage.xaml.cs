

using System.Linq;
using Tasks.Data;
using Tasks.Model;

namespace Tasks.Views
{
    public partial class ListPage : ContentPage
    {

        TaskModelDataBase db;

        public static List<TaskModel> listaTarefas = new List<TaskModel>();
        public List<TaskModel> listaOrdenada = new List<TaskModel>();

        public ListPage()
        {
            InitializeComponent();

            db = new TaskModelDataBase();

            //iniciaLista();

            //listaOrdenada = (List<TaskModel>)listaTarefas.OrderBy(t => t.Priority).Reverse();

            //taskListView.ItemsSource = listaOrdenada;
        }

        protected override async void OnAppearing() 
        {
            base.OnAppearing();
            listaOrdenada = await db.getAllTasks();
            taskListView.ItemsSource = listaOrdenada.OrderBy(t => t.Priority).Reverse().ToList();

        }

        private async void iniciaLista() { 
            var lista = await db.getAllTasks();
            listaOrdenada = lista.OrderBy(t => t.Priority).Reverse().ToList();
            taskListView.ItemsSource = listaOrdenada;
        }

        public async void OnDetails(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails(new TaskModel()));
            iniciaLista();
        }

        private async void taskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails((TaskModel)e.Item));

            // reiniciar a lista
            //taskListView.ItemsSource = listaOrdenada;

        }
    }

}
