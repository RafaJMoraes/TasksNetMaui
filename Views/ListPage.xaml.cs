

using Tasks.Model;

namespace Tasks.Views
{
    public partial class ListPage : ContentPage
    {

        public static List<TaskModel> listaTarefas = new List<TaskModel>();

        public ListPage()
        {
            InitializeComponent();

            taskListView.ItemsSource = listaTarefas;
        }

        public async void OnDetails(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails(new TaskModel()));
        }
    }

}
