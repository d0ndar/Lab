using System;
using System.Drawing;
using System.Threading.Channels;
namespace GTFO;
class Program
{
    static void Main(string[] args)
    {
        bool field1 = ValidateInput.SimpleInputBool("Введите первое логическое значение(1-true, 0 - false):");
        bool field2 = ValidateInput.SimpleInputBool("Введите второе логическое значение(1-true, 0 - false):");

        Field xz = new Field(field1, field2);
        Console.WriteLine("Введённые значения:");
        Console.WriteLine(xz.ToString());
        Console.WriteLine($"итог импликации:{xz.Implication()}");
        Console.WriteLine();


        Console.WriteLine("Введите состояние двери(1- открыта, 0 - закрыта) и название двери с локацией:");
        IDK idk = ValidateInput.GetInput();

        Console.WriteLine(idk.ToString());
        Console.WriteLine("Закрытые двери: " + idk.FindClosedDores());
        Console.WriteLine("");

        Console.WriteLine("Введите название двери для закрытия: ");
        var ost = idk.CloseTheDoor(Console.ReadLine());
        Console.WriteLine(idk);
        Console.ReadLine();
    }

}