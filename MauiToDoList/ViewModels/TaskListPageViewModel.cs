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
    public ObservableCollection<TaskItems> Tasks { get; } = new();

    [ObservableProperty]
    private string tasknames;

    [RelayCommand]
    void AddTask()
    {
        Tasks.Add(new TaskItems
        {
            TaskName = Tasknames,
            Status = EnumStatus.ToDo,
            ImageUrl = "yellow.png",
            DateCreated = DateTime.Now
        });
    }

    [RelayCommand]
    void UpdateStatus()
    {

    }
}
