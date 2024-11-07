using CalculatorAPI.Models;

namespace CalculatorAPI.Services
{
    public class CalculatorService : ICalculatorService
    {
        public CalculatorResponse Calculate(CalculatorRequest request)
        {
            double result = request.Operation switch
            {
                "+" => request.Operand1 + request.Operand2,
                "-" => request.Operand1 - request.Operand2,
                "*" => request.Operand1 * request.Operand2,
                "/" => request.Operand2 != 0 ? request.Operand1 / request.Operand2 : throw new DivideByZeroException("Error: Cannot divide by zero."),
                _ => throw new ArgumentException("Error: Invalid operation")
            };

            return new CalculatorResponse
            {
                Result = result,
                Message = "Success: Calculation completed."
            };
        }
    }
}
