namespace Task2
{
    class Program
    {
        static ILogger Logger { get; set; }

        static void Main(string[] args)
        {
            Logger = new Logger();
            var calc = new Calc(Logger);
            calc.GetInput();
        }
    }
}