using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Application.Responses;
using ToDo.Domain.Enums;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{id}")]
        public async Task<GetHttpResponseDto<TodoItemDto>> GetById(int id)
        {
            TodoItemDto item = await _todoItemService.GetByIdAsync(id);
            return GetHttpResponseDto<TodoItemDto>.Ok(item);
        }

        [HttpGet]
        public async Task<GetHttpResponseDto<IEnumerable<TodoItemDto>>> GetAll()
        {
            IEnumerable<TodoItemDto> items = await _todoItemService.GetAllAsync();
            return GetHttpResponseDto<IEnumerable<TodoItemDto>>.Ok(items);
        }

        [HttpGet("status/{status}")]
        public async Task<GetHttpResponseDto<IEnumerable<TodoItemDto>>> GetByStatus(TodoItemStatus status)
        {
            IEnumerable<TodoItemDto> items = await _todoItemService.GetByStatusAsync(status);
            return GetHttpResponseDto<IEnumerable<TodoItemDto>>.Ok(items);
        }

        [HttpGet("priority/{priority}")]
        public async Task<GetHttpResponseDto<IEnumerable<TodoItemDto>>> GetByPriority(TodoItemPriority priority)
        {
            IEnumerable<TodoItemDto> items = await _todoItemService.GetByPriorityAsync(priority);
            return GetHttpResponseDto<IEnumerable<TodoItemDto>>.Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Add(TodoItemDto item)
        {
            await _todoItemService.AddAsync(item);
            return NoContent();
        }

        [HttpPut()]
        public async Task<ActionResult> Update(TodoItemDto item)
        {
            await _todoItemService.UpdateAsync(item);
            return NoContent();
        }

        [HttpPatch("{id}/status/{status}")]
        public async Task<ActionResult> SetStatus(int id, TodoItemStatus status)
        {
            await _todoItemService.SetStatusAsync(id, status);
            return NoContent();
        }

        [HttpPatch("{id}/priority/{priority}")]
        public async Task<ActionResult> SetPriority(int id, TodoItemPriority priority)
        {
            await _todoItemService.SetPriorityAsync(id, priority);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
