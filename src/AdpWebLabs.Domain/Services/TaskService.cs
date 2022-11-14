using AdpWebLabs.Domain.Domain.DTO;
using AdpWebLabs.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace AdpWebLabs.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly string _baseAdpApiUrl;

        const string getTaskUrl = "/api/v1/get-task";
        const string submitTaskUrl = "api/v1/submit-task";

        public TaskService(IConfiguration configuration) => _baseAdpApiUrl = configuration.GetSection("URL:adpeai").Value;

        public async Task<TaskResponse> GetTask()
        {
            try
            {
                var client = new RestClient(_baseAdpApiUrl);
                var request = new RestRequest(getTaskUrl, Method.Get);

                var taskResult = await client.GetAsync<TaskResponse>(request);

                return taskResult ?? new TaskResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("An error occurred while trying to get a task");
            }
        }

        public async Task<HttpStatusCode> SubmitTask(TaskRequest taskRequest)
        {
            try
            {
                var client = new RestClient(_baseAdpApiUrl);

                var request = new RestRequest(submitTaskUrl, Method.Post);
                request.AddJsonBody(JsonSerializer.Serialize(taskRequest));

                var taskResult = await client.PostAsync(request);

                return taskResult.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("An error occurred while trying to submit a task");
            }
        }
    }
}
