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

    [RelayCommand]
    void AddSampleTask()
    {
        Tasks.Add(new TaskItems
        {
            TaskName = "MAKE A BREAKFAST",
            Status = EnumStatus.Important,
            DateCreated = new DateTime(2026, 1, 3, 21, 20, 16)
        });
    }
}
