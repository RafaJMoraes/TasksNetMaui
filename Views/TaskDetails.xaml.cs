using System.ComponentModel;
using Tasks.Data;
using Tasks.Enuns;
using Tasks.Model;

namespace Tasks.Views;

public partial class TaskDetails : ContentPage
{

    TaskModelDataBase db;

    public string titleDetails {get; set;}
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Concluded { get; set; }
    public PriorityEnum Priority { get; set; }

    public List<string> Priorities { get; set; }

    TaskModel _taskModel;


    public List<TaskModel> tasks = new List<TaskModel>();   
    public TaskDetails(TaskModel taskModel)
	{
		InitializeComponent();
        db = new TaskModelDataBase();

        if (taskModel.Id != 0)
        {
            _taskModel = taskModel;
            Description = _taskModel.Description;
            Priority = _taskModel.Priority;
            Concluded = _taskModel.Concluded;
            Id = _taskModel.Id;

            PriorityPicker.SelectedIndex = Priority.GetValue();

            titleDetails = "Atualizar Tarefa";
        }
        else 
        {
            _taskModel = new TaskModel();

            PriorityPicker.SelectedIndex = 0;

            titleDetails = "Nova Tarefa";


        }


        Priorities = new List<string>();
        Priorities = Enum.GetValues(typeof(PriorityEnum))
            .Cast<PriorityEnum>()
            .Select(priority => priority.GetLabel())
            .ToList();  

        BindingContext = this;

    }
    public void OnPriorityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Priority = (PriorityEnum)picker.SelectedIndex;
    }

    public async void OnClickedButton(object sender, EventArgs e) 
    {
        
            _taskModel.Description = Description;
            _taskModel.Priority = Priority;
            _taskModel.Concluded = Concluded;

        if(String.IsNullOrEmpty(Description))
        {
            await DisplayAlert("Ops", "Descrição é obrigatória.", "OK");
            return;
        }

        var result = await db.AddOrUpdateTaskModelAsync(_taskModel);

        if (result == 1) {
            await DisplayAlert("Atençao", "Salvo com sucesso", "OK");
        }
        else
        {
            await DisplayAlert("Atençao", "Erro Inesperado", "OK");
        }


        await Navigation.PopAsync();
    }

    private void PrioridadeCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var prioridadeSelecionada = e.CurrentSelection[0].ToString();
            Priority = Enum.GetValues(typeof(PriorityEnum)).Cast<PriorityEnum>()
                                                .FirstOrDefault(priority => priority.GetLabel().Equals(prioridadeSelecionada));
        }
    }

    private async void BtnDeletar_Clicked(object sender, EventArgs e)
    {
        var result = await db.removeTask(_taskModel);
        if (result == 1)
        {
            await DisplayAlert("Atençao", "Removida com sucesso", "OK");
        }
        else
        {
            await DisplayAlert("Atençao", "Erro Inesperado", "OK");
        }
        await Navigation.PopAsync();
    }
}