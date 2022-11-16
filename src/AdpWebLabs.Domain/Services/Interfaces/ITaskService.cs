namespace AdpWebLabs.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        /// <summary>
        /// Get the task, calculate and submit
        /// </summary>
        /// <returns></returns>
        Task<KeyValuePair<int, object>> Calculate();
    }
}
