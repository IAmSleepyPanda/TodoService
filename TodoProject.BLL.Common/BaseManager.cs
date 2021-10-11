using TodoProject.BLL.Common.Models;

namespace TodoProject.BLL.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ManagerResult<T> Ok<T>(T result, string message = null) =>
            new ManagerResult<T>
            {
                IsSuccess = true,
                Message = message,
                Result = result
            };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ManagerResult Ok() =>
            new ManagerResult
            {
                IsSuccess = true
            };


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public ManagerResult<T> OperationFailed<T>(string message) =>
            new ManagerResult<T>
            {
                Message = message,
                IsSuccess = false
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ManagerResult OperationFailed(string message) => new ManagerResult
        {
            Message = message,
            IsSuccess = false
        };
    }
}
