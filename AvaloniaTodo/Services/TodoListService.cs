using System.Collections;
using System.Collections.Generic;
using AvaloniaTodo.Models;

namespace AvaloniaTodo.Services;

public class TodoListService
{
    public IEnumerable<TodoItem> GetItems() => new[]
    {
        new TodoItem { Description = "Walk the Cat" },
        new TodoItem() { Description = "Buy some whiskey" },
        new TodoItem() { Description = "Win Lottery", IsChecked = true }
    };
}
