using CalculatorAPI.Models;
using CalculatorAPI.Services;
using Xunit;
using System;

namespace CalculatorAPI.Tests.Services
{
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            // Instantiate the CalculatorService directly since it has no dependencies
            _calculatorService = new CalculatorService();
        }

        [Theory]
        [InlineData(4, 2, "+", 6)]
        [InlineData(4, 2, "-", 2)]
        [InlineData(4, 2, "*", 8)]
        [InlineData(4, 2, "/", 2)]
        public void Calculate_ValidInputs_ReturnsExpectedResult(double operand1, double operand2, string operation, double expected)
        {
            // Arrange
            var request = new CalculatorRequest { Operand1 = operand1, Operand2 = operand2, Operation = operation };

            // Act
            var response = _calculatorService.Calculate(request);

            // Assert
            Assert.Equal(expected, response.Result);
        }

        [Fact]
        public void Calculate_DivideByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var request = new CalculatorRequest { Operand1 = 4, Operand2 = 0, Operation = "/" };

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculatorService.Calculate(request));
        }

        [Fact]
        public void Calculate_InvalidOperation_ThrowsArgumentException()
        {
            // Arrange
            var request = new CalculatorRequest { Operand1 = 4, Operand2 = 2, Operation = "?" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculatorService.Calculate(request));
        }
    }
}
