using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Aspose.Cells;

namespace lab5;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вариант 13");


        string FilePath = "lol.txt";
        string DBFilePath = "LR5-var13.xls";
        //DBFilePath = "Excel.xlsx";
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("Записывать в старый(1) или создать новый(2)?");
            int variant = Convert.ToInt32(Console.ReadLine());
            switch (variant)
            {
                default:
                    Console.WriteLine("Нет такого!");
                    break;
                case 2:
                    Console.WriteLine("Введите название нового файла:");
                    FilePath = Console.ReadLine() + ".txt";
                    Log.NewLog(FilePath);
                    exit = false;
                    break;
                case 1:
                    Console.WriteLine("Введите название старого файла:");
                    FilePath = Console.ReadLine() + ".txt";
                    Log.OldLog(FilePath);
                    exit = false;
                    break;
            }

        }


        if (!File.Exists(DBFilePath))
        {
            Console.WriteLine("не можем найти ДБ, прекращаем работу программы.");
            Log.WriteToLog(FilePath, $"ДБ нет по адресу: {DBFilePath}");
            return;
        }

        exit = true;
        while (exit)
        {
            Console.WriteLine("");
            Console.WriteLine("1. Просмотр базы данных.");
            Console.WriteLine("2. Удаление элементов (по ключу)");
            Console.WriteLine("3. Корректировка элементов (по ключу)");
            Console.WriteLine("4. Добавление элементов.");
            Console.WriteLine("5. Вывод строк где начисления за раз больше 4.9.");
            Console.WriteLine("6. ФИО номера с самым большим количеством поступлений.");
            Console.WriteLine("7. Добавление элементов.");
            Console.WriteLine("8. Добавление элементов.");
            Console.WriteLine("0. выход");
            Console.Write("Выберите номер задания:");


            int TaskNumber = Convert.ToInt32(Console.ReadLine());
            Log.WriteToLog(FilePath, $"Выбранно задание {TaskNumber}");


            DBExcel DB = new DBExcel(FilePath, DBFilePath);
            DB.Read();
            switch (TaskNumber)
            {
                default:
                    Console.WriteLine("Нет такого!");
                    break;
                case 0:
                    exit = false;
                    break;
                case 1:
                    Console.WriteLine("1.Счёт");
                    Console.WriteLine("2.Курс валют");
                    Console.WriteLine("3.Начисления");
                    Console.WriteLine("выберите страницу для отображения:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    DB.PrintDB(num);
                    //Просмотр базы данных.
                    break;
                case 2:
                    DB.Del();
                    DB.SaveDB();
                    //Удаление элементов (по ключу)
                    break;
                case 3:
                    DB.EditDB();
                    DB.SaveDB();
                    //Корректировка элементов (по ключу)
                    break;
                case 4:
                    DB.AddEl();
                    DB.SaveDB();
                    //Добавление элементов.
                    break;
                case 5:
                    DB.task1();
                    break;
                case 6:
                    DB.task2();

                    break;
                case 7:

                    break;
                case 8:

                    break;
            }
        }
    }
}
