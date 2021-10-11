using System.Collections.Generic;
using System.Threading.Tasks;
using TodoProject.BLL.Models;

namespace TodoProject.BLL.Providers.Interfaces
{
    /// <summary>
    /// Provider for working with TodoItems
    /// </summary>
    public interface ITodoItemsProvider
    {
        /// <summary>
        /// Gets all TodoItems
        /// </summary>
        /// <returns>List of TodoItems</returns>
        Task<IEnumerable<TodoItemDto>> GetTodoItemsAsync();

        /// <summary>
        /// Gets TodoItem by id
        /// </summary>
        /// <param name="id">TodoItem id</param>
        /// <returns>TodoItem found by Id</returns>
        Task<TodoItemDto> GetTodoItemAsync(long id);

        /// <summary>
        /// Creates TodoItem
        /// </summary>
        /// <param name="todoItemDto">TodoItem model</param>
        /// <returns>New TodoItem id</returns>
        Task<long> CreateTodoItemAsync(TodoItemDto todoItemDto);

        /// <summary>
        /// Updates TodoItem
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        /// <param name="todoItemDto">TodoItem update model</param>
        Task UpdateTodoItemAsync(long id, TodoItemDto todoItem);

        /// <summary>
        /// Deletes TodoItem
        /// </summary>
        /// <param name="id">TodoItem Id</param>
        Task DeleteTodoItemAsync(long id);
    }
}
