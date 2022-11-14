using AdpWebLabs.Domain.Domain.DTO;
using System.Net;

namespace AdpWebLabs.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        /// <summary>
        /// Retrieves the task from the adp api
        /// </summary>
        /// <returns>The values and operation to calculate</returns>
        Task<TaskResponse> GetTask();

        /// <summary>
        /// Submits the task with the id and result to the adp api
        /// </summary>
        /// <param name="taskRequest"></param>
        /// <returns>The corresponding status code</returns>
        Task<HttpStatusCode> SubmitTask(TaskRequest taskRequest);
    }
}
