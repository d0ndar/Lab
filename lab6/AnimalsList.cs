using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6;

public class NoiseMaker
{
    private static Dictionary<INoise, int> meowCount = new Dictionary<INoise, int>();

    public static void MakeNoise(params INoise[] animals)
    {
        foreach (var animal in animals)
        {
            if (!meowCount.ContainsKey(animal))
            {
                meowCount[animal] = 0;
            }

            animal.meow();
            meowCount[animal]++;
        }
    }

    public static void PrintMeowCounts()
    {
        foreach (var animal in meowCount)
        {
            Console.WriteLine($"{animal.Key} издал звук: {animal.Value} раз");
        }
    }
}
