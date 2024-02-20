using AvaloniaTodo.Services;

namespace AvaloniaTodo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public TodoListViewModel TodoList { get; }

    public MainWindowViewModel()
    {
        var service = new TodoListService();
        TodoList = new TodoListViewModel(service.GetItems());
    }
}
