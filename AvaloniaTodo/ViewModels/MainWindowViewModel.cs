using System;
using System.Reactive.Linq;
using AvaloniaTodo.Models;
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
        AddItemViewModel addItemViewModel = new();
        Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (TodoItem?)null))
            .Take(1)
            .Subscribe(newItem =>
            {
                if (newItem is not null)
                {
                    TodoList.ListItems.Add(newItem);
                }

                ContentViewModel = TodoList;
            });
        ContentViewModel = addItemViewModel;
    }
}
