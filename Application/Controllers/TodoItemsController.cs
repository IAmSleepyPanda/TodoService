using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoProject.BLL.Managers;
using TodoProject.BLL.Models;

namespace TodoApiDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : BaseController
    {
        private readonly TodoManager _manager;

        public TodoItemsController(TodoManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Gets all TodoItems
        /// </summary>
        /// <returns>Cписок ToDoItems</returns>
        [HttpGet]
        [Route("GetTodoItems")]
        public async Task<IActionResult> GetTodoItemsAsync() => CreateResult(await _manager.GetTodoItemsAsync());

        /// <summary>
        /// Gets TodoItem by id
        /// </summary>
        /// <param name="id">Id ToDoItem</param>
        [HttpGet]
        [Route("GetTodoItem")]
        public async Task<IActionResult> GetTodoItemAsync(long id) => CreateResult(await _manager.GetTodoItemAsync(id));

        /// <summary>
        /// Updates ToDoItem 
        /// </summary>
        /// <param name="id">Id ToDoItem</param>
        /// <param name="todoItemDto">ToDoItem model for update</param>
        [HttpPut]
        [Route("UpdateTodoItem")]
        public async Task<IActionResult> UpdateTodoItemAsync(long id, TodoItemDto todoItemDto) =>
            CreateEmptyResult(await _manager.UpdateTodoItemAsync(id, todoItemDto));

        /// <summary>
        /// Creates TodoItem
        /// </summary>
        /// <param name="todoItemDto">ToDoItem model for create</param>
        [HttpPost]
        [Route("CreateTodoItem")]
        public async Task<IActionResult> CreateTodoItemAsync(TodoItemDto todoItemDto) =>
            CreateResult(await _manager.CreateTodoItemAsync(todoItemDto));

        /// <summary>
        /// Deletes ToDoItem
        /// </summary>
        /// <param name="id">Id ToDoItem</param>
        [HttpDelete]
        [Route("DeleteTodoItem")]
        public async Task<IActionResult> DeleteTodoItemAsync(long id) =>
            CreateEmptyResult(await _manager.DeleteTodoItemAsync(id));
    }
}
