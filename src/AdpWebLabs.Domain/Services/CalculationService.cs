using AdpWebLabs.Domain.Domain.DTO;
using AdpWebLabs.Domain.Domain.Entities;
using AdpWebLabs.Domain.Domain.Enums;
using AdpWebLabs.Domain.Services.Interfaces;

namespace AdpWebLabs.Domain.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ITaskService _taskService;

        public CalculationService(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        public async Task<int> Calculate()
        {
            var task = await _taskService.GetTask();

            Operation operation = (Operation)Enum.Parse(typeof(Operation), value: task.Operation ?? string.Empty.ToUpper());
            var calculationResult = new Calculator(task.Left, task.Right, operation).Result;

            var submitResult = await _taskService.SubmitTask(new TaskRequest(task.Id, calculationResult));

            return (int)submitResult;
        }
    }
}
