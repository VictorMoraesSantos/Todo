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

        [HttpGet("{todoItemId}/comments")]
        public async Task<GetHttpResponseDto<IEnumerable<CommentDto>>> GetComments(int todoItemId)
        {
            var comments = await _todoItemService.GetCommentsAsync(todoItemId);
            return GetHttpResponseDto<IEnumerable<CommentDto>>.Ok(comments);
        }

        [HttpGet("{todoItemId}/comments/{commentId}")]
        public async Task<GetHttpResponseDto<CommentDto>> GetComment(int todoItemId, int commentId)
        {
            var comment = await _todoItemService.GetCommentAsync(todoItemId, commentId);
            return GetHttpResponseDto<CommentDto>.Ok(comment);
        }

        [HttpPost("{todoItemId}/comments")]
        public async Task<ActionResult> AddComment(int todoItemId, CommentDto commentDto)
        {
            await _todoItemService.AddCommentAsync(todoItemId, commentDto);
            return NoContent();
        }

        [HttpPut("{todoItemId}/comments")]
        public async Task<ActionResult> EditComment(int todoItemId, CommentDto commentDto)
        {
            await _todoItemService.EditCommentAsync(todoItemId, commentDto);
            return NoContent();
        }

        [HttpDelete("{todoItemId}/comments/{commentId}")]
        public async Task<ActionResult> DeleteComment(int todoItemId, int commentId)
        {
            await _todoItemService.DeleteCommentAsync(todoItemId, commentId);
            return NoContent();
        }
    }
}
