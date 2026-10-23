
using TaskFlow.Console.Services;

namespace TaskFlow.Tests.Unit;

public class TaskManagerTests
{
    [Fact]
    public void AddTask_ShouldCreateTaskWithAutomaticId()
    {
        var manager = new TaskManager();

        var task = manager.AddTask("Estudar C#");

        Assert.Equal(1, task.Id);
        Assert.Equal("Estudar C#", task.Title);
        Assert.False(task.IsCompleted);
    }

    [Fact]
    public void GetAllTasks_ShouldReturnAllCreatedTasks()
    {
        var manager = new TaskManager();

        manager.AddTask("Estudar C#");
        manager.AddTask("Fazer exercícios");

        var tasks = manager.GetAllTasks();

        Assert.Equal(2, tasks.Count);
    }

    [Fact]
    public void CompleteTask_ShouldMarkTaskAsCompleted()
    {
        var manager = new TaskManager();
        var task = manager.AddTask("Estudar testes");

        var result = manager.CompleteTask(task.Id);

        Assert.True(result);
        Assert.True(task.IsCompleted);
    }

    [Fact]
    public void RemoveTask_ShouldRemoveExistingTask()
    {
        var manager = new TaskManager();
        var task = manager.AddTask("Revisar código");

        var result = manager.RemoveTask(task.Id);

        Assert.True(result);
        Assert.Empty(manager.GetAllTasks());
    }

    [Fact]
    public void CompleteTask_ShouldReturnFalseForMissingId()
    {
        var manager = new TaskManager();

        var result = manager.CompleteTask(999);

        Assert.False(result);
    }

    
    [Fact]
    public void RemoveTask_ShouldReturnFalseForMissingId()
    {
        var manager = new TaskManager();

        var result = manager.RemoveTask(999);

        Assert.False(result);
    }

    [Fact]
    public void GetTaskById_ShouldReturnNullForMissingId()
    {
        var manager = new TaskManager();

        var task = manager.GetTaskById(999);

        Assert.Null(task);
    }
}
