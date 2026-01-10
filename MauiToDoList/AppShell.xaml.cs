
using MauiToDoList.Views;

namespace MauiToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ArchivePage), typeof(ArchivePage));
        }
    }
}
