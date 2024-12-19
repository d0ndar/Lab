using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Вариант 13");
        bool exit = true;
        Dog typa = new Dog("Тяпа");
        Cat knopa = new Cat("кнопка");
        Cat barsik = new Cat("Барсик");
        while (exit)
        {
            
            Console.WriteLine("");
            Console.WriteLine("1. Задание 1.1");
            Console.WriteLine("2. Задание 1.2 1.3");
            Console.WriteLine("3. Задание 2");
            Console.WriteLine("0. выход");
            Console.Write("Выберите номер задания:");


            int TaskNumber = Convert.ToInt32(Console.ReadLine());

            
            switch (TaskNumber)
            {
                default:
                    Console.WriteLine("Нет такого!");
                    break;
                case 0:
                    exit = false;
                    break;
                case 1:
                    barsik = new Cat("Барсик");
                    barsik.meow();
                    barsik.meow(3);
                    break;
                case 2:
                    
                    NoiseMaker.MakeNoise(barsik, typa, knopa);
                    NoiseMaker.MakeNoise(barsik);
                    NoiseMaker.PrintMeowCounts();
                    break;
                case 3:
                    Fraction f1 = new Fraction(1, 3);
                    Fraction f2 = new Fraction(2, 3);
                    Fraction f3 = new Fraction(3, 6);
                    Fraction f4 = new Fraction(2, 6);
                    Fraction f5 = new Fraction(-3, 6);

                    //сложение
                    Console.WriteLine("сложение");
                    var f6 = f1 + f2;
                    Console.WriteLine($"{f1}+{f2}={f6}");
                    //var f7 = 1 + f1;
                    //Console.WriteLine($"1+{f1}={f7}");
                    //var f8 = f1 + 1;
                    //Console.WriteLine($"1+{f1}={f7}");

                    //вычитание
                    Console.WriteLine("вычитание");
                    var f9 = f1 - 1;
                    Console.WriteLine($"{f1}-1={f9}");
                    //var f10 = 1 - f1;
                    //Console.WriteLine($"1-{f1}={f10}");
                    //var f11 = f1 - f2;
                    //Console.WriteLine($"{f1}-{f2}={f11}");

                    //деление
                    Console.WriteLine("деление");
                    var f12 = f1 / 2;
                    Console.WriteLine($"{f1}:2={f12}");
                    //var f13 = 2 / f1;
                    //Console.WriteLine($"2:{f1}={f13}");
                    //var f14 = f1 / f2;
                    //Console.WriteLine($"{f1}:{f2}={f14}");


                    //умножение
                    Console.WriteLine("умножение");
                    var f15 = f1 * 2;
                    Console.WriteLine($"{f1}*2={f15}");
                    //var f16 = 2 * f1;
                    //Console.WriteLine($"2*{f1}={f16}");
                    //var f17 = f1 * f2;
                    //Console.WriteLine($"{f1}*{f2}={f17}");

                    var f18 = f1 + f2 / f3 - 5;
                    //я посчитал и это внатуре -10\3
                    Console.WriteLine($"{f1}+{f2}:{f3}-5 = {f18}");

                    Console.WriteLine($"Сравниваем {f1} и {f4}: " + f1.Equals(f4));

                    Fraction clonedFraction = (Fraction)f1.Clone();
                    Console.WriteLine($"Изначальная дробь: {f1}");
                    Console.WriteLine($"Клонированная дробь: {clonedFraction}");
                    break;
            }

        }
    }
}