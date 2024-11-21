using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace lab4;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вариант 13");


        bool exit = true;
        while (exit)
        {
            Console.WriteLine("");
            Console.WriteLine("1. Задание 1");
            Console.WriteLine("2. Задание 4");
            Console.WriteLine("3. Задание 5");
            Console.WriteLine("4. Задание 6");
            Console.WriteLine("5. Задание 7");
            Console.WriteLine("6. выход");
            Console.Write("Выберите номер задания:");
            int TaskNumber = Convert.ToInt32(Console.ReadLine());
            switch (TaskNumber)
            {
                default:
                    Console.WriteLine("Нет такого!");
                    break;
                case 1:
                    //Задание 1
                    int l1 = ValidateInput.InputInteger("Введите количество эл-ов в 1 списке:");
                    int l2 = ValidateInput.InputInteger("Введите количество эл-ов во 2 списке:");
                    Console.WriteLine("Список L:" + string.Join(",", Tasks.CreateL(l1,l2).Select(x => x.ToString())));
                    break;
                case 2:
                    //Задание 2
                    int n = ValidateInput.InputInteger("Введите количество эл-ов в 1 списке:");
                    Console.WriteLine("Итоговый список:" + string.Join(",", Tasks.DeleteRange(n).Select(x => x.ToString())));
                    break;
                case 3:
                    //Задание 3
                    Dictionary<string, HashSet<string>> Dict = new Dictionary<string, HashSet<string>>();
                    HashSet<string> TVShows = new HashSet<string>{ "sw1", "sw2", "sw3", "sw4", "sw5" };

                    var amat1 = new HashSet<string> { "sw1", "sw2", "sw3", "sw4"};
                    var amat2 = new HashSet<string> { "sw1", "sw2", "sw3"};
                    var amat3 = new HashSet<string> { "sw1", "sw2"};        //sw2, sw3, sw4 - some, sw1 - all, sw5 - none
                    var amat4 = new HashSet<string> { "sw1",};

                    //int n = Console.ReadLine("Введите количество любителей ТВ-шоу");
                    //Tasks.Task4(n);

                    Dict.Add("amateur1", amat1); 
                    Dict.Add("amateur2", amat2);
                    Dict.Add("amateur3", amat3);
                    Dict.Add("amateur4", amat4);
                    foreach (var i in Dict)
                        Console.WriteLine(i.Key +": "+ string.Join(",", i.Value.Select(x => x.ToString())));
                    Tasks.TVHash(TVShows, Dict);
                    break;
                case 4:
                    //Задание 4
                    string FilePath = "xz.txt";
                    

                    Console.WriteLine("Введите содержимое файла:");
                    string text = Console.ReadLine();
                    
                    using (var writer = new StreamWriter(FilePath)) writer.WriteLine(text);
                    Console.WriteLine("Используемые числа:" + string.Join(",", Tasks.Findnumbers(FilePath).Select(x => x.ToString())));
                    break;
                case 5:
                    //Задание 5
                    break;
                case 6:
                    exit = false;
                    break;
            }
        }
    }
}
