using CommunityToolkit.Mvvm.ComponentModel;
using MauiToDoList.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiToDoList.Models;

public partial class TaskItems : ObservableObject
{
    [ObservableProperty]
    private string taskName;
    [ObservableProperty]
    private EnumStatus status;
    [ObservableProperty]
    private DateTime dateCreated;
    [ObservableProperty]
    private ImageSource imageUrl;
}
