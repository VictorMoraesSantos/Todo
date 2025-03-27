﻿using ToDo.Domain.Entities;
using ToDo.Application.Dtos;
using ToDo.Application.Mapping;

public static class TodoItemMapper
{
    public static TodoItemDto ToDto(TodoItem todoItem)
    {
        if (todoItem == null) return null;

        List<LabelDto> labels = todoItem.LabelTodoItems?
            .Where(lti => lti.Label != null)
            .Select(lti => LabelMapper.ToDto(lti.Label))
            .ToList();

        return new TodoItemDto(
            Id: todoItem.Id,
            ExternalId: todoItem.ExternalId,
            CreatedAt: todoItem.CreatedAt,
            Title: todoItem.Title,
            Description: todoItem.Description,
            DueDate: todoItem.DueDate,
            Priority: todoItem.Priority,
            Status: todoItem.Status,
            ListId: todoItem.ListId,
            Labels: labels
        );
    }

    public static TodoItem ToEntity(TodoItemDto todoItemDto)
    {
        if (todoItemDto == null) return null;

        return new TodoItem(
            title: todoItemDto.Title,
            description: todoItemDto.Description,
            dueDate: todoItemDto.DueDate ?? DateTime.Now,
            priority: todoItemDto.Priority,
            listId: todoItemDto.ListId
        );
    }
}
