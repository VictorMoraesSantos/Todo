using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

public static class TodoListMapper
{
    public static TodoListDto ToDto(TodoList todoList)
    {
        if (todoList == null) return null!;

        TodoListDto todoListDto = new TodoListDto(
            Id: todoList.Id,
            ExternalId: todoList.ExternalId,
            CreatedAt: todoList.CreatedAt,
            Title: todoList.Title,
            Description: todoList.Description,
            Status: todoList.Status,
            IsFavorite: todoList.IsFavorite,
            UserId: todoList.UserId,
            TodoItems: todoList.TodoItems.Select(TodoItemMapper.ToDto).ToList()
        );

        return todoListDto;
    }

    public static TodoList ToEntity(TodoListDto todoListDto)
    {
        if (todoListDto == null) return null!;

        TodoList todoList = new TodoList(
            title: todoListDto.Title,
            description: todoListDto.Description,
            userId: todoListDto.UserId,
            todoItems: todoListDto.TodoItems.Select(TodoItemMapper.ToEntity).ToList()
        );

        if (todoListDto.IsFavorite)
            todoList.MarkAsFavorite();

        return todoList;
    }
}
