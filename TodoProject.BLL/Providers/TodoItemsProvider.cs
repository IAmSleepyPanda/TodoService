using DomainContext;
using DomainContext.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProject.BLL.Mappers;
using TodoProject.BLL.Models;
using TodoProject.BLL.Providers.Interfaces;

namespace TodoProject.BLL.Providers
{
    /// <summary>
    /// Provider for working with TodoItems
    /// </summary>
    public class TodoItemsProvider : ITodoItemsProvider
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoItemsProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all TodoItems
        /// </summary>
        /// <returns>List of TodoItems</returns>
        public async Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync()
        {
            var todoItems = await _unitOfWork.GetGenericRepository<TodoItem>().AllAsync();
            return todoItems.Select(t => t.MapToTodoItemDto());
        }

        /// <summary>
        /// Gets TodoItem by id
        /// </summary>
        /// <param name="id">TodoItem id</param>
        /// <returns>TodoItem found by Id</returns>
        public async Task<TodoItemDto> GetTodoItemAsync(long id)
        {
            var todoItemById = await FirstOrDefaultOrThrowException(id);
            return todoItemById.MapToTodoItemDto();
        }

        /// <summary>
        /// Creates TodoItem
        /// </summary>
        /// <param name="todoItemDto">TodoItem model</param>
        /// <returns>New TodoItem id</returns>
        public async Task<long> CreateTodoItemAsync(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDto.IsComplete,
                Name = todoItemDto.Name
            };

            _unitOfWork.GetGenericRepository<TodoItem>().Insert(todoItem);
            await _unitOfWork.SaveAsync();

            return todoItem.Id;
        }

        /// <summary>
        /// Updates TodoItem
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <param name="todoItemDto">TodoItem update model</param>
        public async Task UpdateTodoItemAsync(long id, TodoItemDto todoItemDto)
        {
            if (id != todoItemDto.Id)
                throw new Exception($"Values are different. Model Id = {todoItemDto.Id} and id = {id}.");

            var todoItem = await FirstOrDefaultOrThrowException(id);

            todoItem.Name = todoItemDto.Name;
            todoItem.IsComplete = todoItemDto.IsComplete;
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Deletes TodoItem
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        public async Task DeleteTodoItemAsync(long id)
        {
            var todoItem = await FirstOrDefaultOrThrowException(id);

            _unitOfWork.GetGenericRepository<TodoItem>().Delete(todoItem);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets TodoItem by id and throw exception if not found
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <returns>TodoItem model</returns>
        private async Task<TodoItem> FirstOrDefaultOrThrowException(long id) =>
            await _unitOfWork.GetGenericRepository<TodoItem>().FirstOrDefaultAsync(t => t.Id == id) ??
            throw new Exception($"Element not found by Id = {id}");
    }
}
