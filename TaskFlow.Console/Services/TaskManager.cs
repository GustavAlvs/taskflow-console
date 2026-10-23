
using TaskFlow.Console.Domain;

namespace TaskFlow.Console.Services;

public class TaskManager
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem(_nextId++, title);
        _tasks.Add(task);

        return task;
    }

    public List<TaskItem> GetAllTasks()
    {
        return _tasks;
    }

    public TaskItem? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(task => task.Id == id);
    }

    public bool CompleteTask(int id)
    {
        var task = GetTaskById(id);

        if (task is null)
            return false;

        task.Complete();
        return true;
    }

    public bool RemoveTask(int id)
    {
        var task = GetTaskById(id);

        if (task is null)
            return false;

        return _tasks.Remove(task);
    }
}
