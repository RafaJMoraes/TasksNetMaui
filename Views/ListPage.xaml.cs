

using Tasks.Model;

namespace Tasks.Views
{
    public partial class ListPage : ContentPage
    {

        public static List<TaskModel> listaTarefas = new List<TaskModel>();
        public static List<TaskModel> listaOrdenada = new List<TaskModel>();

        public ListPage()
        {
            InitializeComponent();

            TaskModel taskModel = new TaskModel();
            taskModel.Id = 2;
            taskModel.Priority = Enuns.PriorityEnum.LOW;
            taskModel.Description = "Tarefa Mocada";
            taskModel.Concluded = true;

            TaskModel taskModel1 = new TaskModel();
            taskModel1.Id = 3;
            taskModel1.Priority = Enuns.PriorityEnum.HIGH;
            taskModel1.Description = "Tarefa Mocada 1";
            taskModel1.Concluded = false;

            TaskModel taskModel2 = new TaskModel();
            taskModel2.Id = 4;
            taskModel2.Priority = Enuns.PriorityEnum.MEDIUM;
            taskModel2.Description = "Tarefa Mocada 2";
            taskModel2.Concluded = false;

            TaskModel taskModel3 = new TaskModel();
            taskModel3.Id = 5;
            taskModel3.Priority = Enuns.PriorityEnum.MEDIUM;
            taskModel3.Description = "Tarefa Mocada 3";
            taskModel3.Concluded = false;

            listaTarefas.Add(taskModel);
            listaTarefas.Add(taskModel1);
            listaTarefas.Add(taskModel2);
            listaTarefas.Add(taskModel3);

            listaOrdenada = (List<TaskModel>)listaTarefas.OrderBy(t => t.Priority).Reverse();

            taskListView.ItemsSource = listaOrdenada;
        }

        public async void OnDetails(object Sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails(new TaskModel()));
            taskListView.ItemsSource = listaOrdenada;
        }

        private async void taskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskDetails((TaskModel)e.Item));

            // reiniciar a lista
            taskListView.ItemsSource = listaOrdenada;

        }
    }

}
