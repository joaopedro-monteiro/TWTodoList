namespace TWTodoList.Models;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Title { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }

    public Todo(string? title, DateTime date, bool isCompleted = false)
    {
        Title = title;
        Date = date.Date;
        IsCompleted = isCompleted;
    }
}
