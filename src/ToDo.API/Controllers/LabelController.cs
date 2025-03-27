using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos;
using ToDo.Application.Interfaces;
using ToDo.Application.Responses;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpGet("{id}")]
        public async Task<GetHttpResponseDto<LabelDto>> GetById(int id)
        {
            LabelDto label = await _labelService.GetByIdAsync(id);
            return GetHttpResponseDto<LabelDto>.Ok(label);
        }

        [HttpGet]
        public async Task<GetHttpResponseDto<IEnumerable<LabelDto>>> GetAll()
        {
            IEnumerable<LabelDto> labels = await _labelService.GetAllAsync();
            return GetHttpResponseDto<IEnumerable<LabelDto>>.Ok(labels);
        }

        [HttpPost]
        public async Task<ActionResult> Add(LabelDto label)
        {
            await _labelService.AddAsync(label);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(LabelDto label)
        {
            await _labelService.UpdateAsync(label);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _labelService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("associate")]
        public async Task<ActionResult> Associate(LabelTodoItemDto association)
        {
            await _labelService.AddAssociationAsync(association);
            return NoContent();
        }

        [HttpPost("disassociate")]
        public async Task<ActionResult> Disassociate(LabelTodoItemDto association)
        {
            await _labelService.RemoveAssociationAsync(association);
            return NoContent();
        }

        [HttpPost("todoitems")]
        public async Task<GetHttpResponseDto<IEnumerable<TodoItemDto>>> GetTodoItemsByLabel([FromBody] LabelTodoItemDto dto)
        {
            IEnumerable<TodoItemDto> items = await _labelService.GetTodoItemsByLabelAsync(dto);
            return GetHttpResponseDto<IEnumerable<TodoItemDto>>.Ok(items);
        }

        [HttpPost("labels")]
        public async Task<GetHttpResponseDto<IEnumerable<LabelDto>>> GetLabelsByTodoItem([FromBody] LabelTodoItemDto dto)
        {
            IEnumerable<LabelDto> labels = await _labelService.GetLabelsByTodoItemAsync(dto);
            return GetHttpResponseDto<IEnumerable<LabelDto>>.Ok(labels);
        }
    }
}
