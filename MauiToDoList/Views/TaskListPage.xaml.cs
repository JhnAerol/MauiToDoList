using MauiToDoList.ViewModels;

namespace MauiToDoList.Views;

public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
        BindingContext = new TaskListPageViewModel();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        showAddTaskOverlay();
    }

    private async void showAddTaskOverlay()
    {
        addTaskOverlay.IsVisible = true;
        addTaskContent.Opacity = 0;
        addTaskContent.Scale = 0.8;

        await Task.WhenAll(
            addTaskContent.FadeTo(1, 200),
            addTaskContent.ScaleTo(1, 200)
        );
    }

    private void CancelButton(object sender, EventArgs e)
    {
        addTaskOverlay.IsVisible = false;
        optionOverlay.IsVisible = false;
        updateOverlay.IsVisible = false;
        txtAddTask.Text = null;
    }

    private void OpenOption(object sender, EventArgs e)
    {
        showOptionOverlay();
    }

    private async void showOptionOverlay()
    {
        optionOverlay.IsVisible = true;
        optionContent.Opacity = 0;
        optionContent.Scale = 0.8;

        await Task.WhenAll(
            optionContent.FadeTo(1, 200),
            optionContent.ScaleTo(1, 200)
        );
    }

    private void UpdateButton(object sender, EventArgs e)
    {
        showUpdateOverlay();
        optionOverlay.IsVisible = false;
    }

    private async void showUpdateOverlay()
    {
        updateOverlay.IsVisible = true;
        updateContent.Opacity = 0;
        updateContent.Scale = 0.8;

        await Task.WhenAll(
            updateContent.FadeTo(1, 200),
            updateContent.ScaleTo(1, 200)
        );
    }

    private void DeleteButton(object sender, EventArgs e)
    {

    }
}