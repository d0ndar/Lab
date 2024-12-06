using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab5;

internal class Accounts
{
    public int ID;
    public string HolderFullName;
    public DateTime DateOfOpening;

    public Accounts(int ID, string HolderFullName, DateTime DateOfOpening)
    {
        this.ID = ID;
        this.HolderFullName = HolderFullName;
        this.DateOfOpening = DateOfOpening;
    }

    public override string ToString()
    {
        return $"ID: {ID}| ФИО держателя: {HolderFullName}| Дата открытия: {DateOfOpening}";
    }
}
