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


        Console.WriteLine("Введите координаты нижнего левого угла прямоугольника (x =0/1,y=0/1) и размеры (ширина, высота):");
        IDK idk = ValidateInput.GetInput();

        Console.WriteLine(idk.ToString());
        Console.WriteLine("Площадь: " + idk.Area());
        Console.WriteLine("");

        var topLeft = idk.GetBottomLeftCorner();
        Console.WriteLine($"Координаты нижнего левого угла: ({topLeft.x}, {topLeft.y})");
        Console.ReadLine();
    }

}