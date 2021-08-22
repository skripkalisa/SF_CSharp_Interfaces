using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GetInput();
        }

        private static void GetInput()
        {
            char[] operators = { '+', '-', '*', '/', '%' };
            Console.WriteLine("Введите первое число:");
            var a = CheckDouble();
            Console.WriteLine("Введите один из операторов:");
            foreach (var op in operators)
                Console.Write($"{op} ");
            Console.WriteLine();
            var input = Console.ReadLine();
            var oper = '+';
            if (input != null)
                try
                {
                    oper = input[input.IndexOfAny(operators)];
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Ошибка! Пустая строка вместо оператора. " + e.Message);
                    Console.WriteLine("Использую оператор: '+'");
                }

            Console.WriteLine("Введите второе число:");
            var b = CheckDouble();

            Console.WriteLine(new Calc(a, oper, b).GetResult());
        }

        private static double CheckDouble()
        {
            var num = double.TryParse(Console.ReadLine(), out var dblNum);
            if (num)
                return dblNum;
            Console.WriteLine("Введённые данные не являются числом. Использую значение: '0'.");
            return 0;
        }
    }
}