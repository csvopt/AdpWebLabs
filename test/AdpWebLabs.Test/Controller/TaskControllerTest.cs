using AdpWebLabs.Api.Controllers;
using AdpWebLabs.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AdpWebLabs.Test.Controller
{
    [Collection(nameof(TaskControllerCollection))]
    public class TaskControllerTest
    {
        private readonly TaskControllerFixture _fixture;
        private readonly TaskController _taskController;

        public TaskControllerTest(TaskControllerFixture fixture)
        {
            _fixture = fixture;
            _taskController = _fixture.GetTaskService();
        }

        [Fact]
        public async Task TaskController_Get_ShouldReturnOkResult()
        {
            //Arrange
            var getResponse = new KeyValuePair<int, object>(200, "Correct");
            _fixture.Mocker.GetMock<ITaskService>().Setup(x => x.Calculate()).ReturnsAsync(getResponse);

            //Act
            var result = await _taskController.Get();

            //Assert
            Assert.IsType<ObjectResult>(result);
        }
    }
}
