using System;
namespace mo;
class Program
{
    static void Main(string[] args)
    {
        uint rubles = ValidateInput.InputUint("Введите количество рублей: ");
        byte kopeks = ValidateInput.InputByte("Введите количество копеек: ");
        Money ret = new(rubles, kopeks);
        byte mkopeks = ValidateInput.InputByte("Введите количество копеек, которые нужно отнять: ");
        ret = ret.DecreaseByKopeks(mkopeks);
        Console.WriteLine("оставшиеся деньги после вычита");
        Console.WriteLine(ret.ToString());
        //-1
        Console.WriteLine("-1 к копейкам");
        ret--;
        Console.WriteLine(ret);
        //+1
        Console.WriteLine("+1 к копейкам");
        ret++;
        Console.WriteLine(ret);
        //рубли в юинт
        Console.WriteLine("Вывод рублей");
        uint u = ((uint)ret);
        Console.WriteLine(u);
        // ==0
        Console.WriteLine("Вывод если = 0");
        bool b = ((bool)ret);
        Console.WriteLine(b);
        //-м сдвиг?
        Console.WriteLine("сдвиг на m правосторонний");
        byte m = ValidateInput.InputByte("введите м");
        ret = ret - m;
        Console.WriteLine(b);
        Console.WriteLine("money a - money b");
        uint rublesb = ValidateInput.InputUint("Введите количество рублей: ");
        byte kopeksb = ValidateInput.InputByte("Введите количество копеек: ");
        Money ret2 = new(rublesb, kopeksb);
        Console.WriteLine(ret - ret2);
    }
}