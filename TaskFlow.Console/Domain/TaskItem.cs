
namespace TaskFlow.Console.Domain;

public class TaskItem
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }

    public TaskItem(int id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
    }

    public void Complete()
    {
        IsCompleted = true;
    }
}
