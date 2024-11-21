using System;
using static lab3.files;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace lab3;
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
            Console.WriteLine("6. Задание 8");
            Console.WriteLine("7. выход");
            Console.Write("Выберите номер задания:");
            int TaskNumber = Convert.ToInt32(Console.ReadLine());
            switch (TaskNumber)
            {
                default:
                    Console.WriteLine("Нет такого!");
                    break;
                case 1:
                    int rowCount = ValidateInput.InputInteger("Введите n= ");
                    int columnCount = ValidateInput.InputInteger("Введите m= ");
                    matrixs a = new matrixs(rowCount,columnCount);

                    int n = ValidateInput.InputInteger("Введите порядок матрицы n= ");
                    matrixs b = new matrixs(n);


                    int j = ValidateInput.InputInteger("Введите порядок матрицы n= ");
                    matrixs c = new matrixs(j,1,0);
                    int k = ValidateInput.InputInteger("Введите количество депутатов n= ");
                    Console.WriteLine(matrixs.CreateAndCalculate(k));
                    break;
                case 2:
                    string InputFile = "input.bin";
                    string OutputFile = "output.bin";

                    
                    files.Randomtron(InputFile, 10);
                    Console.WriteLine("Изначальное содержимое:");
                    files.DisplayBinary(InputFile);

                    
                    files.RemoveDuplicates(InputFile, OutputFile);
                    Console.WriteLine("Содержимое после удаления повторов:");
                    files.DisplayBinary(OutputFile);
                    break;
                case 3:
                    List<Toy> toy = new List<Toy>();
                    toy.Add(new Toy("bear", 3,5, 300));
                    toy.Add(new Toy("doll", 3,10, 200));
                    toy.Add(new Toy("paints", 0,5, 600));
                    toy.Add(new Toy("train", 8,12, 800));
                    toy.Add(new Toy("toygun", 3,6, 500));


                    XmlSerializer xml = new XmlSerializer(toy.GetType());
                    FileStream f = new FileStream("serialization.xml",FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                    xml.Serialize(f, toy);
                    Toy max = new Toy();
                    int FromAge = ValidateInput.InputInteger("Введите возраст с которого можно играть с игрушкой");
                    int ToAge = ValidateInput.InputInteger("Введите возраст до которого можно играть с игрушкой");
                    foreach (Toy i in toy)
                    {
                        if (i.cost > max.cost && FromAge <= i.FromAge && ToAge >= i.ToAge) max = i;
                    }
                    Console.WriteLine(max);
                    break;
                    
                case 4:
                    files.RandomtronFile("xz2", 5);
                    files.DisplayFile("xz2");
                    int n4 = ValidateInput.InputInteger("Введите на что должно заканчиваться число:");
                    int sum = 0;
                    foreach (var line in File.ReadLines("xz2"))
                    {
                        if (int.TryParse(line, out int num) && (num % 10) == n4)
                        {
                            sum += num;
                        }
                    }
                    Console.WriteLine("Итоговая сумма: "+sum);
                    break;
                case 5:
                    files.RandomtronFile("xz2", 5);
                    files.DisplayFile("xz2");
                    int min = int.MaxValue;
                    bool ok = true;
                    int sum5 = 0;
                    foreach (var line in File.ReadLines("xz2"))
                    {
                        if (ok)
                        {
                            int.TryParse(line, out int num5);
                            sum5 += num5;
                            ok = false;
                        }

                        if (int.TryParse(line, out int num) && num < min) min = num;
                    }
                    sum5 -= min;
                    Console.WriteLine("Итоговая сумма: " + sum5);
                    break;
                case 6:
                    using (var writer = new StreamWriter("xz3"))
                    {
                        writer.WriteLine("Имеется спорная точка зрения, гласящая");
                        writer.WriteLine("неоднозначны и будут ассоциативно распределены по отраслям.");
                        writer.WriteLine("планирование предоставляет широкие возможности для");
                        writer.WriteLine("Картельные сговоры не допускают ситуации, при которой");
                        writer.WriteLine("как может показаться: перспективное планирование напрямую");
                        writer.WriteLine("материально-технической и кадровой базы.");
                    }
                    using (var reader = new StreamReader("xz3"))
                    using (var writer = new StreamWriter("xz4"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!line.Any(char.IsPunctuation))
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
                    files.DisplayFile("xz4");
                    break;
                case 7:
                    exit = false;
                    break;
            }
        }
    }
}
