using Microsoft.AspNetCore.Mvc;
using TodoProject.BLL.Common.Models;

namespace TodoApiDTO.Controllers
{
    /// <summary>
    /// Provides base controller
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Creates result of manager method execution
        /// </summary>
        /// <typeparam name="T">Type of result</typeparam>
        /// <param name="result">Result model of manager execution</param>
        protected IActionResult CreateResult<T>(ManagerResult<T> result)
        {
            return result.IsSuccess ? (IActionResult) Ok(result.Result) : BadRequest(result.Message);
        }

        /// <summary>
        /// Creates result of manager method execution
        /// </summary>
        /// <param name="result">Result model of manager execution</param>
        protected IActionResult CreateEmptyResult(ManagerResult result)
        {
            return result.IsSuccess ? (IActionResult)Ok() : BadRequest(result.Message);   
        }
    }
}
