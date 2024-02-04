using Tasks.Views;

namespace Tasks;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("taskDetails", typeof(TaskDetails));
	}


	
}
