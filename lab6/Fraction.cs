using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6;

internal class Fraction : Icloneable
{
    private int verx { get; set; }
    private int niz { get; set; }
    public Fraction(int Verx, int Niz)
    {
        if (Niz <= 0)
        {
            throw new ArgumentException("Знаменатель не может быть отрицательным.");
        }

        this.verx = Verx;
        this.niz = Niz;
    }
    public override string ToString()
    {
        return $"{verx}/{niz}";
    }

    public Fraction Simplify()
    {
        bool check = true;
        if (verx < 0 || niz<0)
        {
            check = false;
        }
        int gcd = GCD(Math.Abs(niz),Math.Abs(verx));
        if(check) return new Fraction(verx / gcd, niz / gcd);
        return new Fraction( verx / gcd, niz / gcd);
    }

    public int GCD(int b, int a)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    public override bool Equals(Object obj)
    {
        if (obj == this)
        {
            return true;
        }
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }
        
        Fraction obj2 = (Fraction)obj;
        this.Simplify();
        obj2 = obj2.Simplify();
        return (obj2.niz == this.niz) && (obj2.verx == this.verx);
    }



    public Icloneable Clone()
    {
        return new Fraction(verx, niz);
    }

    //Умножение
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.verx * f2.verx;
        int newDenominator = f1.niz * f2.niz;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }
    public static Fraction operator *(Fraction f1, int f2)
    {
        int newNumerator = f1.verx * f2;
        int newDenominator = f1.niz;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }
    public static Fraction operator *(int f1, Fraction f2)
    {
        int newNumerator = f2.verx * f1;
        int newDenominator = f2.niz;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }


    //Деление
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.verx * f2.niz;
        int newDenominator = f1.niz * f2.verx;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }
    public static Fraction operator /(Fraction f1, int f2)
    {
        int newNumerator = f1.verx;
        int newDenominator = f1.niz * f2;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }
    public static Fraction operator /(int f1, Fraction f2)
    {
        int newNumerator = f2.verx;
        int newDenominator = f2.niz * f1;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }




    //Вычитание
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int newniz = f1.niz * f2.niz;
        int newverx = f1.verx * f2.niz - f2.verx * f1.niz;
        if(newniz<0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }
    public static Fraction operator -(Fraction f1, int f2)
    {
        int newniz = f1.niz;
        int newverx = f1.verx - f2 * f1.niz;
        if (newniz < 0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }
    public static Fraction operator -(int f1, Fraction f2)
    {
        int newniz = f2.niz;
        int newverx = f1 * f2.niz - f2.verx;
        if (newniz < 0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }

    //Сложение
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int newniz = f1.niz * f2.niz;
        int newverx = f1.verx * f2.niz + f2.verx * f1.niz;
        if (newniz < 0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }
    public static Fraction operator +(Fraction f1, int f2)
    {
        int newniz = f1.niz;
        int newverx = f1.verx + f2 * f1.niz;
        if (newniz < 0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }
    public static Fraction operator +(int f1, Fraction f2)
    {
        int newniz = f2.niz;
        int newverx = f1 * f2.niz + f2.verx;
        if (newniz < 0)
        {
            newniz = -newniz;
            newverx = -newverx;
        }
        return new Fraction(newverx, newniz).Simplify();
    }
}
