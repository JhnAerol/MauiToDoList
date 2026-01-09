using MauiToDoList.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiToDoList.Models;

public class TaskItems
{
    public string TaskName { get; set; }
    public EnumStatus Status { get; set; }
    public DateTime DateCreated { get; set; }
}
