namespace TodoProject.BLL.Common.Models
{
    /// <summary>
    /// Manager execution result model
    /// </summary>
    public class ManagerResult
    {
        /// <summary>
        /// Operation success
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Exeption message
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Manager execution result model
    /// </summary>
    /// <typeparam name="T">Type of result model</typeparam>
    public class ManagerResult<T> : ManagerResult
    {
        /// <summary>
        /// Result model
        /// </summary>
        public T Result { get; set; }
    }
}
