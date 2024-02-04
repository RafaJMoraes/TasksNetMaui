using System.ComponentModel;
using Tasks.Data;
using Tasks.Enuns;
using Tasks.Model;

namespace Tasks.Views;

public partial class TaskDetails : ContentPage
{

    TaskModelDataBase db;

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

            //ConcludedSwitch.IsToggled = Concluded;
            PriorityPicker.SelectedIndex = Priority.GetValue();
        }
        else 
        {
            _taskModel = new TaskModel();

            //ConcludedSwitch.IsToggled = false;
            PriorityPicker.SelectedIndex = 1;

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

        var result = await db.AddOrUpdateTaskModelAsync(_taskModel);

        if (result == 1) {
            await DisplayAlert("Atençao", "Salvo com sucesso", "OK");
        }


        await Navigation.PopAsync();
    }

    private void PrioridadeCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Aqui você pode acessar o item selecionado usando e.PreviousSelection e e.CurrentSelection
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var prioridadeSelecionada = e.CurrentSelection[0].ToString();
            Priority = Enum.GetValues(typeof(PriorityEnum)).Cast<PriorityEnum>()
                                                .FirstOrDefault(priority => priority.GetLabel().Equals(prioridadeSelecionada));
        }
    }
}