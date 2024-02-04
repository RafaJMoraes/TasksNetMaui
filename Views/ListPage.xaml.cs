

using Tasks.Model;

namespace Tasks.Views
{
    public partial class ListPage : ContentPage
    {

        public static List<TaskModel> listaTarefas = new List<TaskModel>();

        public ListPage()
        {
            InitializeComponent();

            TaskModel taskModel = new TaskModel();
            taskModel.Id = 2;
            taskModel.Priority = Enuns.PriorityEnum.LOW;
            taskModel.Description = "Tarefa Mocada";
            taskModel.Concluded = true;

            TaskModel taskModel1 = new TaskModel();
            taskModel1.Id = 2;
            taskModel1.Priority = Enuns.PriorityEnum.HIGH;
            taskModel1.Description = "Tarefa Mocada 1";
            taskModel1.Concluded = false;

            listaTarefas.Add(taskModel);
            listaTarefas.Add(taskModel1);

            taskListView.ItemsSource = listaTarefas;
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
