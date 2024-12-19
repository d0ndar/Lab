using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6;

internal class Dog : INoise
{
    private string Name;
    public Dog(string Name)
    {
        if (Name == null || Name == string.Empty)
        {
            throw new ArgumentException("Такого имени не может быть");
        }
        this.Name = Name;
    }
    public override string ToString()
    {
        return $"собака: {Name}";
    }
    public void meow()
    {
        Console.WriteLine($"{Name}: гав!");
    }
    public void meow(int n)
    {
        try
        {
            string result = string.Join("-", Enumerable.Repeat("гав", n));
            Console.WriteLine($"{Name}: {result}!");
        }
        catch
        {
            Console.WriteLine("Число должно быть больше 0");
        }
    }
}
