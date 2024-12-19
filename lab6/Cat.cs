using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6;

public class Cat : INoise
{
    private string Name { get; set; }
    public Cat(string Name)
    {
        if (Name == null || Name == string.Empty)
        {
            throw new ArgumentException("Такого имени не может быть");
        }
        this.Name = Name;
    }
    public override string ToString()
    {
        return $"кот: {Name}";
    }
    public void meow()
    {
        Console.WriteLine($"{Name}: мяу!");
    }
    public void meow(int n)
    {
        try
        {
            string result = string.Join("-", Enumerable.Repeat("мяу", n));
            Console.WriteLine($"{Name}: {result}!");
        }
        catch
        {
            Console.WriteLine("Число должно быть больше 0");
        }
        
    }
}
