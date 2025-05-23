﻿using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem>? GetById(int id)
        {
            return await _context.TodoItems
                .Include(x => x.Comments)
                .Include(x => x.LabelTodoItems)
                    .ThenInclude(lti => lti.Label)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems
                .AsNoTracking()
                .Include(x => x.Comments)
                .Include(x => x.LabelTodoItems)
                    .ThenInclude(lti => lti.Label)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetByPriority(TodoItemPriority priority)
        {
            return await _context.TodoItems
                .AsNoTracking()
                .Where(x => x.Priority == priority)
                .Include(x => x.Comments)
                .Include(x => x.LabelTodoItems)
                    .ThenInclude(lti => lti.Label)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetByStatus(TodoItemStatus status)
        {
            return await _context.TodoItems
                .AsNoTracking()
                .Where(x => x.Status == status)
                .Include(x => x.Comments)
                .Include(x => x.LabelTodoItems)
                    .ThenInclude(lti => lti.Label)
                .ToListAsync();
        }

        public async Task Add(TodoItem entity)
        {
            await _context.TodoItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoItem entity)
        {
            _context.TodoItems.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TodoItem entity)
        {
            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetComments(int todoItemId)
        {
            return await _context.Comments
                .AsNoTracking()
                .Where(t => t.TodoItemId == todoItemId)
                .ToListAsync();
        }

        public async Task<Comment?> GetComment(int todoItemId, int commentId)
        {
            return await _context.Comments
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == commentId);
        }

        public async Task AddComment(int todoItemId, Comment comment)
        {
            TodoItem todoItem = await _context.TodoItems
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == todoItemId);

            if (todoItem == null)
                throw new Exception("TodoItem não encontrado.");

            todoItem.AddComment(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditComment(int todoItemId, Comment comment)
        {
            TodoItem todoItem = await _context.TodoItems
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == todoItemId);

            if (todoItem == null)
                throw new Exception("TodoItem não encontrado.");

            todoItem.EditComment(comment.Id, comment.Text);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int todoItemId, int commentId)
        {
            TodoItem todoItem = await _context.TodoItems
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == todoItemId);

            todoItem.DeleteComment(commentId);
            await _context.SaveChangesAsync();
        }
    }
}
