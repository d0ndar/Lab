using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GTFO;
class ValidateInput
{

    static public byte InputByte (string s)
    {
        bool ok;
        byte a;
        do
        {
            Console.WriteLine(s);
            ok = byte.TryParse(Console.ReadLine(), out a);
            if (!ok)
            {
                ConsoleColor tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
                Console.ForegroundColor = tmp;
            }
        } while (!ok);
        return a;
    }
    static public uint InputUint(string s)
    {
        bool ok;
        uint a;
        do
        {
            Console.WriteLine(s);
            ok = uint.TryParse(Console.ReadLine(), out a);
            if (!ok)
            {
                ConsoleColor tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
                Console.ForegroundColor = tmp;
            }
        } while (!ok);
        return a;
    }
    static public int InputInteger(string s)
    {
        bool ok;
        int a;
        do
        {
            Console.WriteLine(s);
            ok = int.TryParse(Console.ReadLine(), out a);
            if (a <= 0) ok = false;
            if (!ok)
            {
                ConsoleColor tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
                Console.ForegroundColor = tmp;
            }
        } while (!ok);
        return a;
    }


    static public bool SimpleInputBool(string s)
    {
        //"Введите первое логическое значение(1-true, 0 - false):"
        //ввод чисел для координат через жопу в диапозоне от 0, до 1
        bool ok;
        int a;
        do
        {
            Console.WriteLine(s);
            ok = int.TryParse(Console.ReadLine(), out a);
            if (ok)
                if (a != 1 & a != 0)
                    ok = false;
            if (!ok)
            {
                ConsoleColor tmp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
                Console.ForegroundColor = tmp;
            }
        } while (!ok);
        if (a == 1) return true;
        return false;
    }
}