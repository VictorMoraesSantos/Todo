using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mapping
{
    public static class CommentMapper
    {
        public static CommentDto ToDto(Comment comment)
        {
            return new CommentDto(
                comment.Id,
                comment.ExternalId,
                comment.CreatedAt,
                comment.Text,
                comment.TodoItemId
            );
        }

        public static Comment ToEntity(CommentDto dto)
        {
            Comment comment = new Comment(dto.Text, dto.TodoItemId);
            typeof(Comment).GetProperty(nameof(Comment.Id))?.SetValue(comment, dto.Id);
            return comment;
        }
    }
}
