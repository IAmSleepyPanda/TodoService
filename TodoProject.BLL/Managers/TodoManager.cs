using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoProject.BLL.Common;
using TodoProject.BLL.Common.Models;
using TodoProject.BLL.Models;
using TodoProject.BLL.Providers.Interfaces;

namespace TodoProject.BLL.Managers
{
    /// <summary>
    /// Manager for working with TodoItems
    /// </summary>
    public class TodoManager : BaseManager
    {
        private readonly ITodoItemsProvider _todoItemsProvider;
        private readonly ILogger<TodoManager> _logger;

        public TodoManager(ITodoItemsProvider todoItemsProvider, ILogger<TodoManager> logger)
        {
            _todoItemsProvider = todoItemsProvider;
            _logger = logger;
        }

        /// <summary>
        /// Gets all TodoItems
        /// </summary>
        /// <returns>Result of getting all TodoItems</returns>
        public async Task<ManagerResult<IEnumerable<TodoItemDto>>> GetTodoItemsAsync()
        {
            try
            {
                return Ok(await _todoItemsProvider.GetTodoItemsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return OperationFailed<IEnumerable<TodoItemDto>>(ex.Message);
            }
        }

        /// <summary>
        /// Gets TodoItem by id
        /// </summary>
        /// <param name="id">TodoItem id</param>
        /// <returns>Result of getting all TodoItem by id</returns>
        public async Task<ManagerResult<TodoItemDto>> GetTodoItemAsync(long id)
        {
            try
            {
                return Ok(await _todoItemsProvider.GetTodoItemAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return OperationFailed<TodoItemDto>(ex.Message);
            }
        }

        /// <summary>
        /// Creates TodoItem
        /// </summary>
        /// <param name="itemDto">TodoItem model for create</param>
        /// <returns>Result of creating TodoItem</returns>
        public async Task<ManagerResult<long>> CreateTodoItemAsync(TodoItemDto itemDto)
        {
            try
            {
                return Ok(await _todoItemsProvider.CreateTodoItemAsync(itemDto));
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while creating new item with Name = {itemDto.Name}";
                _logger.LogError(ex, errorMessage);
                return OperationFailed<long>(errorMessage);
            }
        }

        /// <summary>
        /// Updates TodoItem
        /// </summary>
        /// <param name="id">TodoItem id</param>
        /// <param name="itemDto">TodoItem model for update</param>
        /// <returns>Result of updating TodoItem</returns>
        public async Task<ManagerResult> UpdateTodoItemAsync(long id, TodoItemDto itemDto)
        {
            try
            {
                await _todoItemsProvider.UpdateTodoItemAsync(id, itemDto);
                return Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while updating item with Id = {id}";
                _logger.LogError(ex, errorMessage);
                return OperationFailed(errorMessage);
            }
        }

        /// <summary>
        /// Deletes TodoItem
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <returns>Result of deleting TodoItem</returns>
        public async Task<ManagerResult> DeleteTodoItemAsync(long id)
        {
            try
            {
                await _todoItemsProvider.DeleteTodoItemAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while deleting item with Id = {id}";
                _logger.LogError(ex, errorMessage);
                return OperationFailed(errorMessage);
            }
        }
    }
}
