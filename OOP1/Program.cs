using System;

namespace OOP1
{
    class Program
    {
        static void Main()
        {
            var calc = new Calculator.Calculator();
            
            try
            {
                string str = calc.Calculate(Console.ReadLine());

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
