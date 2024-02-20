using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaTodo.Models;

namespace AvaloniaTodo.ViewModels;

public class TodoListViewModel : ViewModelBase
{
    public ObservableCollection<TodoItem> ListItems { get; }

    public TodoListViewModel(IEnumerable<TodoItem> items)
    {
        ListItems = new ObservableCollection<TodoItem>(items);
    }
}
