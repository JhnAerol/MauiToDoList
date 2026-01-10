using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiToDoList.Models;
using MauiToDoList.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiToDoList.ViewModels;

public partial class TaskListPageViewModel : ObservableObject
{
    public ObservableCollection<TaskItems> _allTasks = new();

    public ObservableCollection<TaskItems> ArchivedTasks { get; } = new();


    public ObservableCollection<TaskItems> Tasks { get; } = new();

    [ObservableProperty]
    private EnumStatus? selectedFilter;

    [ObservableProperty]
    private EnumStatus selectedStatus;

    [ObservableProperty]
    private string tasknames;

    public void ApplyFilter()
    {
        Tasks.Clear();

        IEnumerable<TaskItems> filtered = _allTasks;

        if (SelectedFilter != null)
        {
            filtered = _allTasks
                .Where(t => t.Status == SelectedFilter);
        }

        foreach (var task in filtered)
            Tasks.Add(task);
    }

    [RelayCommand]
    void AddTask()
    {
        var task = new TaskItems
        {
            TaskName = Tasknames,
            Status = EnumStatus.ToDo,
            ImageUrl = "yellow.png",
            DateCreated = DateTime.Now
        };

        _allTasks.Add(task);
        ApplyFilter();
    }

    [RelayCommand]
    void Filter(EnumStatus status)
    {
        if (SelectedFilter == status)
            SelectedFilter = null;
        else
            SelectedFilter = status;

        ApplyFilter();
    }

    [RelayCommand]
    void ClearFilter()
    {
        SelectedFilter = null;
        ApplyFilter();
    }

    [RelayCommand]
    void SelectStatus(EnumStatus status)
    {
        SelectedStatus = status;
    }
}
