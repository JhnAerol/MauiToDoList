using MauiToDoList.Models;
using MauiToDoList.Models.Enums;
using MauiToDoList.ViewModels;
using System.Security.Cryptography;

namespace MauiToDoList.Views;

public partial class ArchivePage : ContentPage
{
	private TaskListPageViewModel _viewModel;
	private TaskItems _selectedTask;

	public ArchivePage(TaskListPageViewModel viewModel  )
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		hasArchive();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	private void OpenOption(object sender, EventArgs e)
	{
        var image = sender as Image;
        if (image == null)
            return;

        _selectedTask = (TaskItems)image.BindingContext;
        if (_selectedTask == null) return;

        OpenOptionOverlay();
	}

	private void hasArchive()
	{
		if (_viewModel.ArchivedTasks.Count > 0)
			noTaskOverlay.IsVisible = false;
	}

	private void UnarchiveButton(object sender, EventArgs e)
	{
		if (_selectedTask == null)
			return;

		_viewModel.ArchivedTasks.Remove(_selectedTask);

		_selectedTask.Status = EnumStatus.ToDo;
		_selectedTask.ImageUrl = "yellow.png";
		_viewModel._allTasks.Add(_selectedTask);

		_viewModel.ApplyFilter();

		optionOverlay.IsVisible = false;
	}

	private void DeleteButton(object sender, EventArgs e)
	{
        if (_selectedTask == null)
            return;

		_viewModel.ArchivedTasks.Remove(_selectedTask);

        optionOverlay.IsVisible = false;
		deleteConfirmationOverlay.IsVisible = false;
    }

	private void OnTapOpenConfirmation(object sender, EventArgs e)
	{
		OpenConfirmationOverlay();
    }

	private async void OpenConfirmationOverlay()
	{
        deleteConfirmationOverlay.IsVisible = true;
        deleteConfirmationContent.Opacity = 0;
        deleteConfirmationContent.Scale = 0.8;

        await Task.WhenAll(
            deleteConfirmationContent.FadeTo(1, 200),
            deleteConfirmationContent.ScaleTo(1, 200)
        );
    }

    private void OpenOptionOverlay()
	{
		optionOverlay.IsVisible = true;
	}

	private void CancelButton(object sender, EventArgs e)
	{
		optionOverlay.IsVisible = false;
        deleteConfirmationOverlay.IsVisible= false;
    }

	private async void BackToTaskPage()
	{
		await Navigation.PopAsync();
	}

	private void BackToTaskPageButton(object sender, EventArgs e)
	{
		BackToTaskPage();
	}
}