using System;
internal class Program
{
    public double fraction(double x)
    {
        return Math.Abs(x) - (int)Math.Abs(x);
    }

    private static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine("Вариант нечётный");

        Console.WriteLine("1. Задание 1");
        Console.WriteLine("2. Задание 2");
        Console.WriteLine("3. Задание 3");
        Console.WriteLine("4. Задание 4");
        Console.Write("Выберите номер задания:");
        int TaskNumber = Convert.ToInt32(Console.ReadLine());

        switch (TaskNumber)
        {
            case 1:
                Console.WriteLine("Список заданий:");
                Console.WriteLine("1. Задание 1");
                Console.WriteLine("2. Задание 3");
                Console.WriteLine("3. Задание 5");
                Console.WriteLine("4. Задание 7");
                Console.WriteLine("5. Задание 9");
                Console.Write("Выберите номер задания:");
                int Task = Convert.ToInt32(Console.ReadLine());
                switch (Task)
                {
                    case 1:
                        Console.Write("введите дробное число:");
                        double UserInput = Convert.ToDouble(Console.ReadLine());
                        double FractionPart = p.fraction(UserInput);
                        Console.WriteLine($"Дробной частью числа {UserInput} является {FractionPart}");
                        break;
                }
                break;

        }
    }
}