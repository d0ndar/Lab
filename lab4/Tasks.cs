using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4;

internal class Tasks
{
    //Задание 1
    public static List<int> CreateL(int l1, int l2)
    {
        Random random = new Random();
        List<int> L1 = new List<int>();
        List<int> L2 = new List<int>();

        for (int i = 0; i < l1; i++) L1.Add(random.Next(1, 11));
        for (int i = 0; i < l2; i++) L2.Add(random.Next(1, 11));
        Console.WriteLine("Первый список:");
        Console.WriteLine(string.Join(",", L1.Select(x => x.ToString()).ToArray()));
        Console.WriteLine("Второй список:");
        Console.WriteLine(string.Join(",", L2.Select(x => x.ToString()).ToArray()));

        return L1.Except(L2).Union(L2.Except(L1)).ToList();
    }
    //Задание 2
    public static LinkedList<int> DeleteRange(int n)
    {
        Random random = new Random();

        LinkedList<int> num = new LinkedList<int>();
        LinkedList<int> num2 = new LinkedList<int>();


        for (int i = 0; i < n; i++) num.AddLast(random.Next(1, 11));
        Console.WriteLine("Первоначальный список:" + string.Join(",", num.Select(x => x.ToString())));

        LinkedListNode<int> nodemin = num.Find(num.Min());
        LinkedListNode<int> nodemax = num.Find(num.Max());
        LinkedListNode<int> node = num.First;

        

        //перебор до 1 максимального\минимального чилса
        while (node != nodemax & node != nodemin)
        {
            num2.AddLast(node.Value);
            node = node.Next;
            if (node == null) return num2;
        }

        num2.AddLast(node.Value);
        node = node.Next;
        //перебор до 2 максимального\минимального чилса
        while (nodemax != node & nodemin != node)
        {
            if (node == null) return num2;
            node = node.Next;
        }
        //перебор до последнего эл-та
        while (node != null)
        {
            num2.AddLast(node.Value);
            node = node.Next;
        }

        return num2;
    }
    //Задание 3
    public static void TVHash(HashSet<string> TVShows, Dictionary<string, HashSet<string>> dict)
    {
        HashSet<string> AllEnj = new HashSet<string>(TVShows);
        HashSet<string> SomeEnj = new HashSet<string>(TVShows);
        HashSet<string> NbEnj = new HashSet<string>(TVShows);

        //Nobody enjoyed
        Console.WriteLine("Никому не понравилось");
        foreach (var i in dict.Values) NbEnj.ExceptWith(i); //это исключение(есть в первом нет во втором)
        foreach (var i in NbEnj) Console.WriteLine(i);

        //all enjoyed
        Console.WriteLine("Всем понравилось:");
        foreach (var i in dict.Values) AllEnj.IntersectWith(i); //Это пересечение(есть и в первом и втором)
        foreach (var i in AllEnj) Console.WriteLine(i);

        //Somebody enjoyed
        Console.WriteLine("некоторым понравилось");
        foreach (var i in dict.Values) SomeEnj.UnionWith(i); //union, что логично это объединение
        SomeEnj.ExceptWith(AllEnj);
        SomeEnj.ExceptWith(NbEnj);
        foreach (var i in SomeEnj) Console.WriteLine(i);
    }

    //Задание 4
    public static HashSet<char> Findnumbers(string FilePath)
    {
        string text = File.ReadAllText(FilePath);

        HashSet<char> digits = new HashSet<char>();
        
        //здесь мы сравниваем побуквенно, используя от HashSet'а только уникальность значений.
        //Да, можно было бы использовать метод contains или найти пересечения, но мне уже лень думать
        foreach (char i in text) if (char.IsDigit(i)) digits.Add(i);
        return digits;
    }
}
