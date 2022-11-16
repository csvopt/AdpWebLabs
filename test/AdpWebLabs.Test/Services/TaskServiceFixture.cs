using AdpWebLabs.Domain.Domain.DTO;
using AdpWebLabs.Domain.Services;
using Bogus;
using Moq.AutoMock;

namespace AdpWebLabs.Test.Services
{
    [CollectionDefinition(nameof(TaskServiceCollection))]
    public class TaskServiceCollection : ICollectionFixture<TaskServiceFixture> { }

    public class TaskServiceFixture : IDisposable
    {
        public AutoMocker Mocker = new();
        public TaskService? TaskService;

        public TaskService GetTaskService()
        {
            TaskService = Mocker.CreateInstance<TaskService>();
            return TaskService;
        }

        public TaskGetResponse TaskGetResponse(double left, double right, string operation)
        {
            var result = new Faker<TaskGetResponse>()
                .RuleFor(x => x.Left, y => left)
                .RuleFor(x => x.Right, y => right)
                .RuleFor(x => x.Operation, y => operation);

            return result;
        }

        public void Dispose() {}
    }
}
