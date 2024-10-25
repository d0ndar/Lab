using System;

namespace mo;
public class Money
{
    protected uint rubles;
    protected byte kopeks;

    public Money(uint rubles, byte kopeks)
    {
        this.rubles = rubles;
        this.kopeks = kopeks;
    }
    // уменшить баланс на mkopeks копеек
    public Money DecreaseByKopeks(byte mkopeks)
    {
        uint frubles = rubles;
        byte fkopeks = kopeks;
        if (mkopeks <= kopeks)
        {
            kopeks -= mkopeks;
            mkopeks = 0;
        }
            
        else
        {
            if (rubles < 1)
            {
                Console.WriteLine("не можем столько вычесть");
                return new Money(frubles, fkopeks);
            }
            rubles -= 1;
            kopeks += 100;
            kopeks -= mkopeks;
        }
        while ((mkopeks - mkopeks % 100)/100 > 0)
        {
            if (rubles < 1)
            {
                Console.WriteLine("не можем столько вычесть");
                return new Money(frubles, fkopeks);
            }
            mkopeks -= 100;
            Console.WriteLine(mkopeks);
            rubles -= 1;
            Console.WriteLine(rubles);
        }
        if (kopeks>=100)
        {
            kopeks -= 100;
            rubles += 1;
        }

        
        return new Money(rubles, kopeks);
    }
    // - 1 к копейкам
    public static Money operator --(Money a)
    {
        if (a.kopeks > 0) return new Money(a.rubles, Convert.ToByte(a.kopeks - 1));
        else
        {
            if (a.rubles == 0 & a.kopeks == 0)
            {
                Console.WriteLine("Не можу вычесть");
                return new Money(a.rubles, a.kopeks);
            }
            return new Money(a.rubles - 1, Convert.ToByte(a.kopeks + 99));
        }    
    }
    // + 1 к копейкам
    public static Money operator ++(Money a)
    {
        a.kopeks += 1;
        while (a.kopeks >=100)
            {
                a.kopeks -= 100;
                a.rubles += 1;
            }

        return new Money(a.rubles, a.kopeks);
    }
    //возвращаем целое число рублей
    public static explicit operator uint(Money a)
    {
        return (uint)a.rubles;
    }
    //проверяем если баланс 0
    public static explicit operator bool(Money a)
    {
        return (a.rubles == 0 & a.kopeks == 0);
    }
    //левостороннее и правостороннее
    public static Money operator -(Money a, byte m)
    {
        return new Money(a.DecreaseByKopeks(m));
    }
    public static Money operator -(byte m, Money a)
    {
        return new Money(a.DecreaseByKopeks(m));
    }
    //бинарыне
    public static Money operator -(Money a, Money b)
    {
        if (a.rubles < b.rubles & a.kopeks < b.kopeks)
        {
            Console.WriteLine("Не можу вычесть");
            return new Money(a.rubles, a.kopeks);
        }
        Money f = a.DecreaseByKopeks(a.kopeks);
        if (a.rubles > b.rubles) return new Money(f.rubles - b.rubles, f.kopeks);
        else
        {
            Console.WriteLine("Не могу вычесть");
            return new Money(a.rubles, a.kopeks);
        }
    }

    public override string ToString()
    {
        return $"Рублей: {rubles}, Копеек: {kopeks}";
    }
}


