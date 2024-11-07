using CalculatorAPI.Models;

namespace CalculatorAPI.Services
{
    public interface ICalculatorService
    {
        CalculatorResponse Calculate(CalculatorRequest request);
    }
}
