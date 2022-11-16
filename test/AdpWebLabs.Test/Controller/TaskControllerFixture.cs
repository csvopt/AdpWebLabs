using AdpWebLabs.Api.Controllers;
using Moq.AutoMock;

namespace AdpWebLabs.Test.Controller
{
    [CollectionDefinition(nameof(TaskControllerCollection))]
    public class TaskControllerCollection : ICollectionFixture<TaskControllerFixture> { }

    public class TaskControllerFixture : IDisposable
    {
        public AutoMocker Mocker = new();
        public TaskController? TaskController;

        public TaskController GetTaskService()
        {
            TaskController = Mocker.CreateInstance<TaskController>();
            return TaskController;
        }

        public void Dispose() { }
    }
}
