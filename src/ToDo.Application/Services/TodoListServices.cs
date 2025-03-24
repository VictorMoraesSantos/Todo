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

        public async Task<TodoListDto> GetByIdAsync(int id)
        {
            TodoList list = await _todoListRepository.GetById(id)!;
            return list != null ? TodoListMapper.ToDto(list) : null;
        }

        public async Task<IEnumerable<TodoListDto>> GetAllAsync()
        {
            IEnumerable<TodoList> lists = await _todoListRepository.GetAll();
            IEnumerable<TodoListDto> todoListsDto = lists.Select(TodoListMapper.ToDto);
            return todoListsDto;
        }

        public async Task AddAsync(TodoListDto entity)
        {
            if (entity != null)
            {
                TodoList todoList = TodoListMapper.ToEntity(entity);
                await _todoListRepository.Add(todoList);
            }
        }

        public async Task UpdateAsync(TodoListDto dto)
        {
            TodoList entity = await _todoListRepository.GetById(dto.Id)!;
            if (entity == null)
                throw new DomainException("Entidade não encontrada.");

            entity.UpdateList(dto.Title, dto.Description);

            await _todoListRepository.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            if (id != null)
            {
                TodoList todoList = await _todoListRepository.GetById(id);
                await _todoListRepository.Delete(todoList);
            }
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

        public async Task<IEnumerable<TodoListDto>> GetByStatusAsync(TodoListStatus status)
        {
            IEnumerable<TodoList> todoLists = await _todoListRepository.GetByStatusAsync(status);

            IEnumerable<TodoListDto> todoListsDto = todoLists.Select(TodoListMapper.ToDto);

            return todoListsDto;
        }

        public async Task<IEnumerable<TodoListDto>> GetFavoritesAsync(bool favorited = true)
        {
            IEnumerable<TodoList> todoLists = await _todoListRepository.GetFavoritesAsync(favorited);

            IEnumerable<TodoListDto> todoListsDto = todoLists.Select(TodoListMapper.ToDto);

            return todoListsDto;
        }
    }
}
