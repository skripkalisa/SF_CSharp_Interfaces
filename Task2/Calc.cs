using System;

namespace Task2
{
    public interface ICalc
    {
        double GetResult();
    }
    
    public class Calc : ICalc
    {
        internal Calc(ILogger logger)
        {
            Logger = logger;
        }

        private  ILogger Logger { get; }

        private  void LogEvent(){
            Logger.Event("Logging Event");
        }

        private  void LogError()
        {
            Logger.Error("Logging Error");
        }

        private Calc(double a, char oper, double b, ILogger logger)
        {
            A = a;
            Oper = oper;
            B = b;
            Logger = logger;
        }

        private double A { get; }
        private char Oper { get; }
        private double B { get; }

        public double GetResult()
        {
            Console.Write($"{A} {Oper} {B} = ");
            switch (Oper)
            {
                case '+':
                    return A + B;
                case '-':
                    return A - B;
                case '*':
                    return A * B;
                case '/':
                    try
                    {
                        return A / B;
                    }
                    catch (Exception e)
                    {
                        LogError();
                        Console.WriteLine("\nПроизошла ошибка: " + e.Message);
                    }

                    break;
                case '%':
                    return A % B;
                default:
                    LogError();
                    Console.WriteLine("\nДействие неопределено.");
                    break;
            }

            return 0;
        }
        
        internal void GetInput()
        {
            char[] operators = { '+', '-', '*', '/', '%' };
            LogEvent();
            Console.WriteLine("Введите первое число:");
            var a = CheckDouble();
            LogEvent();
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
                    LogError();
                    Console.WriteLine("Ошибка! Пустая строка вместо оператора. " + e.Message);
                    Console.WriteLine("Использую оператор: '+'");
                }

            LogEvent();
            Console.WriteLine("Введите второе число:");
            var b = CheckDouble();

            LogEvent();
            Console.WriteLine(new Calc(a, oper, b, Logger).GetResult());
        }

        private  double CheckDouble()
        {
            var num = double.TryParse(Console.ReadLine(), out var dblNum);
            if (num)
                return dblNum;
            LogError();
            Console.WriteLine("Введённые данные не являются числом. Использую значение: '0'.");
            return 0;
        }
    }
}