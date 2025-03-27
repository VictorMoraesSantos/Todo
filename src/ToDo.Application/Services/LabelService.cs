using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Application.Mapping;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;
        private readonly ILabelTodoItemRepository _labelTodoItemRepository;

        public LabelService(ILabelRepository labelRepository, ILabelTodoItemRepository labelTodoItemRepository)
        {
            _labelRepository = labelRepository;
            _labelTodoItemRepository = labelTodoItemRepository;
        }

        public async Task AddAssociationAsync(LabelTodoItemDto item)
        {
            if (item == null)
                throw new DomainException("LabelTodoItem não pode ser nulo.");

            LabelTodoItem labelTodoItem = LabelTodoItemMapper.ToEntity(item);
            await _labelTodoItemRepository.AddAssociation(labelTodoItem);
        }

        public async Task AddAsync(LabelDto entity)
        {
            if (entity == null)
                throw new DomainException("Label não pode ser nulo.");

            Label label = LabelMapper.ToEntity(entity);
            await _labelRepository.Add(label);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser menor ou igual a zero.");

            Label label = await _labelRepository.GetById(id);
            if (label == null)
                throw new DomainException($"Label com ID {id} não existe.");

            await _labelRepository.Delete(label);
        }

        public async Task<IEnumerable<LabelDto>> GetAllAsync()
        {
            IEnumerable<Label> labels = await _labelRepository.GetAll();
            IEnumerable<LabelDto> labelsDto = labels.Select(LabelMapper.ToDto);
            return labelsDto;
        }

        public async Task<LabelDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new DomainException("Id não pode ser menor ou igual a zero.");

            Label label = await _labelRepository.GetById(id);
            if (label == null)
                throw new DomainException($"Label com ID {id} não existe.");

            LabelDto labelDto = LabelMapper.ToDto(label);
            return labelDto;
        }

        public async Task<IEnumerable<LabelDto>> GetLabelsByTodoItemAsync(LabelTodoItemDto item)
        {
            if (item == null)
                throw new DomainException("LabelTodoItem não pode ser nulo.");

            LabelTodoItem labelTodoItem = LabelTodoItemMapper.ToEntity(item);
            IEnumerable<Label> labels = await _labelTodoItemRepository.GetLabelsByTodoItem(labelTodoItem);
            IEnumerable<LabelDto> labelsDto = labels.Select(LabelMapper.ToDto);
            return labelsDto;
        }

        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsByLabelAsync(LabelTodoItemDto item)
        {
            if (item == null)
                throw new DomainException("LabelTodoItem não pode ser nulo.");

            LabelTodoItem labelTodoItem = LabelTodoItemMapper.ToEntity(item);
            IEnumerable<TodoItem> todoItems = await _labelTodoItemRepository.GetTodoItemsByLabel(labelTodoItem);
            IEnumerable<TodoItemDto> todoItemsDto = todoItems.Select(TodoItemMapper.ToDto);
            return todoItemsDto;
        }

        public async Task RemoveAssociationAsync(LabelTodoItemDto item)
        {
            if (item == null)
                throw new DomainException("LabelTodoItem não pode ser nulo.");
            LabelTodoItem labelTodoItem = LabelTodoItemMapper.ToEntity(item);
            await _labelTodoItemRepository.RemoveAssociation(labelTodoItem);
        }

        public async Task UpdateAsync(LabelDto entity)
        {
            if (entity == null)
                throw new DomainException("Label não pode ser nulo.");

            var label = await _labelRepository.GetById(entity.Id);
            if (label == null)
                throw new DomainException($"Label com ID {entity.Id} não encontrada.");

            label.EditLabel(entity.Name, entity.Color);
            await _labelRepository.Update(label);
        }
    }
}
