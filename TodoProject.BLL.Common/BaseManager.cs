using TodoProject.BLL.Common.Models;

namespace TodoProject.BLL.Common
{
    /// <summary>
    /// Provides base manager
    /// </summary>
    public class BaseManager
    {
        /// <summary>
        /// Returns success manager result
        /// </summary>
        /// <typeparam name="T">Type of result model</typeparam>
        /// <param name="result">Result model</param>
        /// <param name="message">Message</param>
        /// <returns>Success manager result</returns>
        public ManagerResult<T> Ok<T>(T result, string message = null) =>
            new ManagerResult<T>
            {
                IsSuccess = true,
                Message = message,
                Result = result
            };

        /// <summary>
        /// Returns success manager result
        /// </summary>
        /// <returns>Success manager result</returns>
        public ManagerResult Ok() =>
            new ManagerResult
            {
                IsSuccess = true
            };


        /// <summary>
        /// Returns failed manager result
        /// </summary>
        /// <typeparam name="T">Type of result model</typeparam>
        /// <param name="message">Error message</param>
        /// <returns>Error manager result</returns>
        public ManagerResult<T> OperationFailed<T>(string message) =>
            new ManagerResult<T>
            {
                Message = message,
                IsSuccess = false
            };

        /// <summary>
        /// Returns error manager result
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns>Error manager result</returns>
        public ManagerResult OperationFailed(string message) => new ManagerResult
        {
            Message = message,
            IsSuccess = false
        };
    }
}
