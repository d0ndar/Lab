using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5;

internal class Currencys
{
    public int ID;
    public string Code;
    public double Currency;
    public string Name;

    public Currencys(int ID,  string Code, double Currency, string Name)
    {
        this.ID = ID;
        this.Code = Code;
        this.Currency = Currency;
        this.Name = Name;
    }

    public override string ToString()
    {
        return $"ID: {ID}| Буквенный код: {Code}| Курс: {Currency}| Название валюты: {Name}";
    }
}
