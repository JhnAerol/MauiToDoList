using MauiToDoList.ViewModels;

namespace MauiToDoList.Views;

public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
        BindingContext = new TaskListPageViewModel();
    }

}