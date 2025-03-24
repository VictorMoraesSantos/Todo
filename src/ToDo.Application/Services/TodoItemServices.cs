using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class TodoItemServices : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemServices(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task AddAsync(TodoItemDto dto)
        {
            if (dto != null)
            {
                TodoItem todoItem = TodoItemMapper.ToEntity(dto);
                await _todoItemRepository.Add(todoItem);
            }
        }

        public async Task DeleteAsync(int id)
        {
            TodoItem todoItem = await _todoItemRepository.GetById(id);
            await _todoItemRepository.Delete(todoItem);
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllAsync()
        {
            IEnumerable<TodoItem> todoItems = await _todoItemRepository.GetAll();
            IEnumerable<TodoItemDto> todoItemsDto = todoItems.Select(TodoItemMapper.ToDto);
            return todoItemsDto;
        }

        public async Task<TodoItemDto> GetByIdAsync(int id)
        {
            TodoItem todoItem = await _todoItemRepository.GetById(id);
            TodoItemDto todoItemDto = TodoItemMapper.ToDto(todoItem);
            return todoItemDto;
        }

        public async Task<IEnumerable<TodoItemDto>> GetByPriorityAsync(TodoItemPriority priority)
        {
            IEnumerable<TodoItem> todoItems = await _todoItemRepository.GetByPriority(priority);
            IEnumerable<TodoItemDto> todoItemsDto = todoItems.Select(TodoItemMapper.ToDto);
            return todoItemsDto;
        }

        public async Task<IEnumerable<TodoItemDto>> GetByStatusAsync(TodoItemStatus status)
        {
            IEnumerable<TodoItem> todoItems = await _todoItemRepository.GetByStatus(status);
            IEnumerable<TodoItemDto> todoItemsDto = todoItems.Select(TodoItemMapper.ToDto);
            return todoItemsDto;
        }

        public async Task SetPriorityAsync(int id, TodoItemPriority priority)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser nulo.");
            if (!Enum.IsDefined(typeof(TodoItemPriority), priority))
                throw new DomainException("Prioridade inválida.");

            TodoItem todoItem = await _todoItemRepository.GetById(id)!;
            todoItem.SetPriority(priority);
            await _todoItemRepository.Update(todoItem);
        }

        public async Task SetStatusAsync(int id, TodoItemStatus status)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser nulo.");
            if (!Enum.IsDefined(typeof(TodoItemStatus), status))
                throw new DomainException("Status inválido.");

            TodoItem todoItem = await _todoItemRepository.GetById(id)!;
            todoItem.SetStatus(status);
            await _todoItemRepository.Update(todoItem);
        }

        public async Task UpdateAsync(TodoItemDto dto)
        {
            TodoItem todoItem = await _todoItemRepository.GetById(dto.Id)!;
            if (todoItem == null)
                throw new DomainException("Entidade não pode ser nula.");

            todoItem.UpdateTodoItem(dto.Title, dto.Description, dto.DueDate, dto.Priority);
            await _todoItemRepository.Update(todoItem);
        }
    }
}
