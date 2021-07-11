using System;
using Calculator;

namespace OOP1
{
    class Program
    {
        static void Main()
        {
            
            try
            {
                string str = Calculator.Calculator.Calculate("2*(-2)+3*(-1+3-10/2)+(2*(10/(2+3)))+1*(-1)");

                Console.WriteLine($"result: {str}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }

            



        }
    }
}
