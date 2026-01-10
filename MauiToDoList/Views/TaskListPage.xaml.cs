using MauiToDoList.Models;
using MauiToDoList.Models.Enums;
using MauiToDoList.ViewModels;

namespace MauiToDoList.Views;

public partial class TaskListPage : ContentPage
{
    private TaskItems _selectedTask;
    private TaskListPageViewModel _viewModel;

    public TaskListPage(TaskListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void AddTaskButton(object sender, EventArgs e)
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

        noTaskOverlay.IsVisible = false; 
    }

    private void CancelButton(object sender, EventArgs e)
    {
        addTaskOverlay.IsVisible = false;
        optionOverlay.IsVisible = false;
        updateOverlay.IsVisible = false;
        txtAddTask.Text = null;
        txtUpdateTask.Text = null;

        if (_viewModel.Tasks.Count <= 0)
            noTaskOverlay.IsVisible = true;
    }

    private void OpenOption(object sender, EventArgs e)
    {
        var image = sender as Image;
        if(image == null) 
            return;

        _selectedTask = (TaskItems)image.BindingContext;
        if (_selectedTask == null) return;

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

        noTaskOverlay.IsVisible = false;
    }

    private void UpdateButton(object sender, EventArgs e)
    {
        if (_selectedTask == null) return;

        txtUpdateTask.Text = _selectedTask.TaskName;
        _viewModel.SelectedStatus = _selectedTask.Status;

        ResetStates();
        VisualStateManager.GoToState(
            _selectedTask.Status switch
            {
                EnumStatus.Completed => CompletedFrame,
                EnumStatus.Important => ImportantFrame,
                _ => TodoFrame
            },
            "Selected");

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

        noTaskOverlay.IsVisible = false;

    }

    private void DeleteButton(object sender, EventArgs e)
    {
        if(_selectedTask == null) return;

        _selectedTask.Status = EnumStatus.Archived;
        _selectedTask.ImageUrl = "black.png";
        _viewModel.ArchivedTasks.Add(_selectedTask);

        _viewModel._allTasks.Remove( _selectedTask);
        _viewModel.Tasks.Remove(_selectedTask);

        optionOverlay.IsVisible = false;
    }

    private void ConfirmUpdateButton(object sender, EventArgs e)
    {
        if (_selectedTask == null)
            return;

        _selectedTask.TaskName = txtUpdateTask.Text;

        _selectedTask.Status = _viewModel.SelectedStatus;

        _selectedTask.ImageUrl = _viewModel.SelectedStatus
        switch
        {
            EnumStatus.Completed => "green.png",
            EnumStatus.Important => "red.png",
            _ => "yellow.png"
        };

        updateOverlay.IsVisible = false;
    }

    private void ResetStates()
    {
        VisualStateManager.GoToState(TodoFrame, "Normal");
        VisualStateManager.GoToState(CompletedFrame, "Normal");
        VisualStateManager.GoToState(ImportantFrame, "Normal");
        VisualStateManager.GoToState(ImportantFilterFrame, "Normal");
        VisualStateManager.GoToState(CompletedFilterFrame, "Normal");
        VisualStateManager.GoToState(TodoFilterFrame, "Normal");
    }

    private Frame _activeFrame = null;

    private void ToggleFilter(Frame tappedFrame)
    {
        if (_activeFrame == tappedFrame)
        {
            VisualStateManager.GoToState(tappedFrame, "Normal");
            _activeFrame = null;
            return;
        }

        ResetStates();

        VisualStateManager.GoToState(tappedFrame, "Selected");
        _activeFrame = tappedFrame;
    }

    private void OnTapTodoFilter(object sender, EventArgs e)
    {
        ToggleFilter(TodoFilterFrame);
    }

    private void OnTapCompletedFilter(object sender, EventArgs e)
    {
        ToggleFilter(CompletedFilterFrame);
    }

    private void OnTapImportantFilter(object sender, EventArgs e)
    {
        ToggleFilter(ImportantFilterFrame);
    }

    private void OnTodoTapped(object sender, EventArgs e)
    {
        ResetStates();
        VisualStateManager.GoToState(TodoFrame, "Selected");
    }

    private void OnCompletedTapped(object sender, EventArgs e)
    {
        ResetStates();
        VisualStateManager.GoToState(CompletedFrame, "Selected");
    }

    private void OnImportantTapped(object sender, EventArgs e)
    {
        ResetStates();
        VisualStateManager.GoToState(ImportantFrame, "Selected");
    }

    private void OnTapFilter(object sender, EventArgs e)
    {
        _viewModel.ClearFilterCommand.Execute(this);
    }

    public void OpenArchivePage(object sender, EventArgs e)
    {
        OpenArchive();
    }

    private async void OpenArchive()
    {
        await Navigation.PushAsync(new ArchivePage(_viewModel));
    }
}