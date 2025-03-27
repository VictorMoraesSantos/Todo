using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class TodoListServices : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListServices(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task<ReadTodoListDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser menor ou igual a zero.");

            TodoList list = await _todoListRepository.GetById(id)!;
            ReadTodoListDto todoListDto = TodoListMapper.ToDto(list);
            return todoListDto;
        }

        public async Task<IEnumerable<ReadTodoListDto>> GetAllAsync()
        {
            IEnumerable<TodoList> lists = await _todoListRepository.GetAll();
            IEnumerable<ReadTodoListDto> todoListsDto = lists.Select(TodoListMapper.ToDto);
            return todoListsDto;
        }

        public async Task AddAsync(CreateTodoListDto entity)
        {
            if (entity == null)
                throw new DomainException("O DTO não pode ser nulo.");

            TodoList todoList = TodoListMapper.ToEntity(entity);
            await _todoListRepository.Add(todoList);
        }

        public async Task UpdateAsync(CreateTodoListDto dto)
        {
            TodoList entity = await _todoListRepository.GetById(dto.Id)!;
            if (entity == null)
                throw new DomainException("Entidade não encontrada.");

            entity.UpdateList(dto.Title, dto.Description);
            await _todoListRepository.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser menor ou igual a zero.");

            TodoList todoList = await _todoListRepository.GetById(id);
            await _todoListRepository.Delete(todoList);
        }

        public async Task MarkAsActiveAsync(int id)
        {
            TodoList todoList = await _todoListRepository.GetById(id);
            todoList.MarkAsActive();
            await _todoListRepository.Update(todoList);
        }

        public async Task MarkAsFavoriteAsync(int id)
        {
            TodoList todoList = await _todoListRepository.GetById(id);
            todoList.MarkAsFavorite();
            await _todoListRepository.Update(todoList);
        }

        public async Task UnmarkAsFavoriteAsync(int id)
        {
            TodoList todoList = await _todoListRepository.GetById(id);
            todoList.UnmarkAsFavorite();
            await _todoListRepository.Update(todoList);
        }

        public async Task MarkAsArchivedAsync(int id)
        {
            TodoList todoList = await _todoListRepository.GetById(id);
            todoList.MarkAsArchived();
            await _todoListRepository.Update(todoList);
        }

        public async Task MarkAsDeletedAsync(int id)
        {
            TodoList todoList = await _todoListRepository.GetById(id);
            todoList.MarkAsDeleted();
            await _todoListRepository.Update(todoList);
        }

        public async Task<IEnumerable<ReadTodoListDto>> GetByStatusAsync(TodoListStatus status)
        {
            IEnumerable<TodoList> todoLists = await _todoListRepository.GetByStatusAsync(status);
            IEnumerable<ReadTodoListDto> todoListsDto = todoLists.Select(TodoListMapper.ToDto);
            return todoListsDto;
        }

        public async Task<IEnumerable<ReadTodoListDto>> GetFavoritesAsync(bool favorited = true)
        {
            IEnumerable<TodoList> todoLists = await _todoListRepository.GetFavoritesAsync(favorited);
            IEnumerable<ReadTodoListDto> todoListsDto = todoLists.Select(TodoListMapper.ToDto);
            return todoListsDto;
        }
    }
}
