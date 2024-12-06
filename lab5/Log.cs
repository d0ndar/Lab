using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace lab5;

internal class Log
{
    public static void NewLog(string FilePath)
    {
        using (FileStream fs = File.Create(FilePath));
        Log.WriteToLog(FilePath, "Создали новый лог-файл");
    }
    public static void OldLog(string FilePath)
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("Ошибка, не можем найти старый файл!");
            Console.WriteLine("Создаём новый с таким назваинем");
            NewLog(FilePath);
        }
        Console.WriteLine($"Лог будет записываться в файл: {FilePath}");
    }
    public static void WriteToLog(string FilePath, string text)
    {
        using (StreamWriter writer = new StreamWriter(FilePath, true))
        {
            writer.WriteLine($"{DateTime.Now.ToString()}: {text}");
        }
    }
}
