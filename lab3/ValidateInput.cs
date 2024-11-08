using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace lab3;
class ValidateInput
{
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
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
            }
        } while (!ok);
        return a;
    }
    static public int Input1or0(string s)
    {
        bool ok;
        int a;
        do
        {
            Console.WriteLine(s);
            ok = int.TryParse(Console.ReadLine(), out a);
            if (a != 0 & a != 1) ok = false;
            if (!ok)
            {
                Console.WriteLine($"\nВведенные данные имеют неверный формат");
                Console.WriteLine("Повторите ввод\n");
            }
        } while (!ok);
        return a;
    }
}