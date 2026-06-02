using BlazorApps.Data;

namespace BlazorApps.Services;

/// <summary>
/// Simulates a database-backed todo service.
/// In production, replace with actual EF Core DbContext + SQLite/SQL Server.
/// </summary>
public class TodoDbService
{
    private readonly List<TodoDbItem> _items = new();
    private int _nextId = 1;

    public Task<List<TodoDbItem>> GetAllAsync()
        => Task.FromResult(_items.OrderBy(t => t.CreatedAt).ToList());

    public Task<TodoDbItem> AddAsync(string title)
    {
        var item = new TodoDbItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false,
            CreatedAt = DateTime.Now
        };
        _items.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(TodoDbItem item)
    {
        var existing = _items.FirstOrDefault(t => t.Id == item.Id);
        if (existing != null)
        {
            existing.Title = item.Title;
            existing.IsCompleted = item.IsCompleted;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var item = _items.FirstOrDefault(t => t.Id == id);
        if (item != null) _items.Remove(item);
        return Task.CompletedTask;
    }

    public Task ClearAllAsync()
    {
        _items.Clear();
        return Task.CompletedTask;
    }
}
