namespace TodoProject.BLL.Models
{
    /// <summary>
    /// TodoItem data transfer object
    /// </summary>
    public class TodoItemDto
    {
        /// <summary>
        /// TodoItem id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// TodoItem name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// TodoItem isComplete
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
