using DomainContext.DataModels;
using TodoProject.BLL.Models;

namespace TodoProject.BLL.Mappers
{
    /// <summary>
    /// TodoItem object mapper
    /// </summary>
    public static class TodoItemMapper
    {
        /// <summary>
        /// Maps TodoItem to TodoItemDto
        /// </summary>
        /// <param name="todoItem">TodoItem model</param>
        /// <returns>TodoItemDto</returns>
        public static TodoItemDto MapToTodoItemDto(this TodoItem todoItem) => new TodoItemDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };
    }
}
