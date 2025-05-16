namespace TodoApi.DTOs;

public record UpdateTodoRequest(string Text, bool IsComplete);
