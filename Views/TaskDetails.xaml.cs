using System.ComponentModel;
using Tasks.Enuns;
using Tasks.Model;

namespace Tasks.Views;

public partial class TaskDetails : ContentPage
{

    public string Description { get; set; }
    public bool Concluded { get; set; }
    public PriorityEnum Priority { get; set; }

    public List<string> Priorities { get; set; }


    public List<TaskModel> tasks = new List<TaskModel>();   
    public TaskDetails(TaskModel taskModel)
	{
		InitializeComponent();

        if (taskModel.Id != 0)
        {
            Description = taskModel.Description;
            Priority = taskModel.Priority;
            Concluded = taskModel.Concluded;
        }
        else 
        {
            //

        }


        Priorities = new List<string>();
        Priorities = Enum.GetValues(typeof(PriorityEnum))
            .Cast<PriorityEnum>()
            .Select(priority => priority.GetLabel())
            .ToList();  

        BindingContext = this;


        ConcludedSwitch.IsToggled = false;
        PriorityPicker.SelectedIndex = 0;
    }
    public void OnPriorityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Priority = (PriorityEnum)picker.SelectedIndex;
    }

    public async void OnClickedButton(object sender, EventArgs e) 
    {
        TaskModel taskModel = new TaskModel();  
        taskModel.Description = Description;
        taskModel.Priority = Priority;
        taskModel.Concluded = Concluded;
        taskModel.Id = 1;

        tasks.Add(taskModel);

        Console.WriteLine(taskModel.Priority.GetLabel());
        
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