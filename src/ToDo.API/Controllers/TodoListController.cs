using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Application.Responses;
using ToDo.Domain.Enums;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet("{id}")]
        public async Task<GetHttpResponseDto<ReadTodoListDto>> GetById(int id)
        {
            ReadTodoListDto list = await _todoListService.GetByIdAsync(id);
            return GetHttpResponseDto<ReadTodoListDto>.Ok(list);
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<GetHttpResponseDto<IEnumerable<ReadTodoListDto>>> GetAll()
        {
            IEnumerable<ReadTodoListDto> lists = await _todoListService.GetAllAsync();
            return GetHttpResponseDto<IEnumerable<ReadTodoListDto>>.Ok(lists);
        }

        [HttpPatch("{id}/active")]
        public async Task<ActionResult> MarkAsActive(int id)
        {
            await _todoListService.MarkAsActiveAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/favorite")]
        public async Task<ActionResult> MarkAsFavorite(int id)
        {
            await _todoListService.MarkAsFavoriteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/unfavorite")]
        public async Task<ActionResult> UnmarkAsFavorite(int id)
        {
            await _todoListService.UnmarkAsFavoriteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/archive")]
        public async Task<ActionResult> MarkAsArchived(int id)
        {
            await _todoListService.MarkAsArchivedAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/delete")]
        public async Task<ActionResult> MarkAsDeleted(int id)
        {
            await _todoListService.MarkAsDeletedAsync(id);
            return NoContent();
        }

        [HttpGet("status/{status}")]
        public async Task<GetHttpResponseDto<IEnumerable<ReadTodoListDto>>> GetByStatus(TodoListStatus status)
        {
            IEnumerable<ReadTodoListDto> lists = await _todoListService.GetByStatusAsync(status);
            return GetHttpResponseDto<IEnumerable<ReadTodoListDto>>.Ok(lists);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTodoListDto todoListDto)
        {
            if (todoListDto == null)
                return BadRequest();

            await _todoListService.AddAsync(todoListDto);
            return CreatedAtAction(nameof(GetById), new { id = todoListDto.Id }, todoListDto);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreateTodoListDto todoListDto)
        {
            if (todoListDto == null)
                return BadRequest();

            await _todoListService.UpdateAsync(todoListDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoListService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("favorites")]
        public async Task<GetHttpResponseDto<IEnumerable<ReadTodoListDto>>> GetFavorites(bool favorited = true)
        {
            IEnumerable<ReadTodoListDto> lists = await _todoListService.GetFavoritesAsync(favorited);
            return GetHttpResponseDto<IEnumerable<ReadTodoListDto>>.Ok(lists);
        }
    }
}
