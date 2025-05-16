namespace TodoApi.Models;

public record TodoItem(Guid Id, string Text, bool IsComplete, DateTime CreatedAt);
