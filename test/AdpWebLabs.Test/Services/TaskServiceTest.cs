using AdpWebLabs.Domain.Domain.DTO;
using AdpWebLabs.Domain.Domain.Entities;
using AdpWebLabs.Domain.Domain.Enums;
using AdpWebLabs.Domain.Infra.Data;
using AdpWebLabs.Domain.Infra.Data.Repository.Interfaces;
using AdpWebLabs.Domain.Services;
using Moq;

namespace AdpWebLabs.Test.Services
{
    [Collection(nameof(TaskServiceCollection))]
    public class TaskServiceTest
    {
        private readonly TaskServiceFixture _fixture;
        private readonly TaskService _taskService;

        public TaskServiceTest(TaskServiceFixture fixture)
        {
            _fixture = fixture;
            _taskService = _fixture.GetTaskService();
        }

        [Theory]
        [InlineData(32, 32, Operation.ADDITION)]
        [InlineData(25, 32, Operation.SUBTRACTION)]
        [InlineData(2, 17, Operation.MULTIPLICATION)]
        [InlineData(9, 3, Operation.DIVISION)]
        [InlineData(17, 3, Operation.REMAINDER)]
        public void Calculator_Addition_ShouldReturnCorrectValue(double left, double right, Operation operation)
        {

            //Arrange //Act
            var calculator = new Calculator(left, right, operation);
            double actual = calculator.Result;

            double expect = 0;

            switch (operation)
            {
                case Operation.ADDITION:
                    expect = 64;
                    break;
                case Operation.SUBTRACTION:
                    expect = -7;
                    break;
                case Operation.MULTIPLICATION:
                    expect = 34;
                    break;
                case Operation.DIVISION:
                    expect = 3;
                    break;
                case Operation.REMAINDER:
                    expect = 2;
                    break;
            }       

            //Assert
            Assert.Equal(expect, actual);
        }

        [Fact]
        public async Task TaskService_Calculate_ShouldReturnCorrect()
        {
            //Arrange
            var getResponse = _fixture.TaskGetResponse(10.232, 7.982, "addition");
            _fixture.Mocker.GetMock<ITaskContext>().Setup(x => x.GetTask()).ReturnsAsync(getResponse);

            var submitResponse = new KeyValuePair<int, object>(200, "Correct");
            _fixture.Mocker.GetMock<ITaskContext>().Setup(x => x.SubmitTask(It.IsAny<TaskSubmitRequest>())).ReturnsAsync(submitResponse);

            //Act
            var result = await _taskService.Calculate();

            //Assert
            _fixture.Mocker.GetMock<ICalculatorRepository>().Verify(x=> x.SaveAsync(It.IsAny<Calculator>()), Times.Once());
            Assert.Equal(result, submitResponse);
        }
    }
}
