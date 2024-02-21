using AvaloniaTodo.Services;
using ReactiveUI;

namespace AvaloniaTodo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public TodoListViewModel TodoList { get; }
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel()
    {
        var service = new TodoListService();
        TodoList = new TodoListViewModel(service.GetItems());
        _contentViewModel = TodoList;
    }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void AddItem()
    {
        ContentViewModel = new AddItemViewModel();
    }
}
