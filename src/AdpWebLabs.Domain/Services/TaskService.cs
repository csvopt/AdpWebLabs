using AdpWebLabs.Domain.Domain.DTO;
using AdpWebLabs.Domain.Domain.Entities;
using AdpWebLabs.Domain.Domain.Enums;
using AdpWebLabs.Domain.Infra.Data;
using AdpWebLabs.Domain.Infra.Data.Repository.Interfaces;
using AdpWebLabs.Domain.Services.Interfaces;

namespace AdpWebLabs.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskContext _taskContext;
        private readonly ICalculatorRepository _calculatorRepository;

        public TaskService(ITaskContext taskContext, ICalculatorRepository calculatorRepository)
        {
            this._taskContext = taskContext;
            _calculatorRepository = calculatorRepository;
        }

        public async Task<KeyValuePair<int, object>> Calculate()
        {
            var task = await _taskContext.GetTask();

            Operation operation = (Operation)Enum.Parse(typeof(Operation), task.Operation?.ToUpper() ?? string.Empty);
            var calculator = new Calculator(task.Left, task.Right, operation);

            await _calculatorRepository.SaveAsync(calculator);

            var submitResult = await _taskContext.SubmitTask(new TaskSubmitRequest(task.Id, calculator.Result));

            return submitResult;
        }
    }
}
