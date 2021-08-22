using System;

namespace Task1
{
    public class Calc : ICalc
    {
        public Calc(double a, char oper, double b)
        {
            A = a;
            Oper = oper;
            B = b;
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
                        Console.WriteLine("\nПроизошла ошибка: " + e.Message);
                    }

                    break;
                case '%':
                    return A % B;
                default:
                    Console.WriteLine("\nДействие неопределено.");
                    break;
            }

            return 0;
        }
    }
}