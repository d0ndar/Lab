using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static lab3.files;

namespace lab3;

public static class files
{
    public static void DisplayBinary(string path)
    {
        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
    public static void DisplayFile(string path)
    {
        var numbers = File.ReadAllLines(path);
        Console.WriteLine(string.Join(" ", numbers));
    }

    public static void Randomtron(string path, int count)
    {
        Random random = new Random();
        using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
                writer.Write(random.Next(1, 100));
        }
    }
    public static void RandomtronFile(string path, int count)
    {
        var random = new Random();
        using (var writer = new StreamWriter(path))
        {
            for (int i = 0; i < count; i++)
                writer.WriteLine(random.Next(1, 100));
        }
    }

    public static void RemoveDuplicates(string inputFile, string outputFile)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        using (var reader = new BinaryReader(File.Open(inputFile, FileMode.Open)))
        using (var writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (uniqueNumbers.Add(number))
                {
                    writer.Write(number);
                }
            }
        }
    }



    [Serializable]
    public class Toy
    {
        public string Name { get; set; }
        public int cost { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public Toy() { }

        public Toy(string name, int FromAge,int ToAge, int cost)
        {
            this.Name = name;
            this.FromAge = FromAge;
            this.ToAge = ToAge;
            this.cost = cost;
        }
        public override string ToString()
        {
            return Name + " " + cost + " " + FromAge + " " + ToAge;
        }
    }

}
