using AdpWebLabs.Domain.Domain.DTO;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace AdpWebLabs.Domain.Infra.Data
{
    public interface ITaskContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<TaskGetResponse> GetTask();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submitRequest"></param>
        /// <returns></returns>
        Task<KeyValuePair<int, object>> SubmitTask(TaskSubmitRequest submitRequest);
    }


    public class TaskContext : ITaskContext
    {

        private readonly string _baseAdpApiUrl;

        const string getTaskUrl = "/api/v1/get-task";
        const string submitTaskUrl = "api/v1/submit-task";

        public TaskContext(IConfiguration configuration) => _baseAdpApiUrl = configuration.GetSection("URL:adpeai").Value ?? string.Empty;

        public async Task<TaskGetResponse> GetTask()
            => await GetAsync<TaskGetResponse>(getTaskUrl) ?? new TaskGetResponse();

        public async Task<KeyValuePair<int, object>> SubmitTask(TaskSubmitRequest submitRequest)
        {
            var result = await PostAsync(submitTaskUrl, submitRequest);
            return new KeyValuePair<int, object>((int)result.StatusCode, result.Content ?? string.Empty);
        }

        private async Task<T?> GetAsync<T>(string request)
        {
            try
            {
                var restClient = new RestClient(_baseAdpApiUrl);
                var restRequest = new RestRequest(request, Method.Get);

                var response = await restClient.GetAsync<T>(restRequest);
                return response;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private async Task<RestResponse> PostAsync(string request, object body)
        {
            try
            {
                var restClient = new RestClient(_baseAdpApiUrl);

                var restRequest = new RestRequest(request, Method.Post);
                restRequest.AddJsonBody(JsonSerializer.Serialize(body));

                var response = await restClient.PostAsync(restRequest);

                return response;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
