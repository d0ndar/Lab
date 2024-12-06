using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5;

internal class Charges
{
    public int ID;
    public int AccountID;
    public int CurrencyID;
    public DateTime Date;
    public double Amount;

    public Charges(int ID, int AccountID, int CurrencyID, DateTime Date, double Amount)
    {
        this.ID = ID;
        this.AccountID = AccountID;
        this.CurrencyID = CurrencyID;
        this.Date = Date;
        this.Amount = Amount;
    }
    public override string ToString()
    {
        return $"ID: {ID}| ID счёта: {AccountID}| ID валюты: {CurrencyID}| Дата операции: {Date}| Сумма: {Amount}";
    }
}
