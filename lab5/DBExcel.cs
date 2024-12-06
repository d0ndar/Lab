using Aspose.Cells;
using Aspose.Cells.Charts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab5;

internal class DBExcel
{
    private List<Accounts> accounts;
    private List<Currencys> currencys;
    private List<Charges> charges;
    private string FilePath;
    private string DBFilePath;

    public DBExcel(string FilePath, string DBFilePath)
    {
        accounts = new List<Accounts>();
        currencys = new List<Currencys>();
        charges = new List<Charges>();
        this.FilePath = FilePath;
        this.DBFilePath = DBFilePath;
    }

    public void SaveDB()
    {
        Log.WriteToLog(FilePath, $"Начинаем сохранение данных");
        Workbook wb = new Workbook(DBFilePath);
        WorksheetCollection collection = wb.Worksheets;
        for (int h = 0; h < wb.Worksheets.Count; h++)
        {
            collection[h].Cells.Clear();
        }

        collection[0].Cells[0, 0].Value = "ID";
        collection[0].Cells[0, 1].Value = "ФИО";
        collection[0].Cells[0, 2].Value = "Дата открытия вклада";
        for (int i = 0; i < accounts.Count; i++)
        {
            string str = string.Format("{0:dd/MM/yyyy}", accounts[i].DateOfOpening);
            collection[0].Cells[i + 1, 0].Value = accounts[i].ID;
            collection[0].Cells[i + 1, 1].Value = accounts[i].HolderFullName;
            collection[0].Cells[i + 1, 2].Value = str;
        }

        collection[1].Cells[0, 0].Value = "ID";
        collection[1].Cells[0, 1].Value = "Буквенный код";
        collection[1].Cells[0, 2].Value = "Курс";
        collection[1].Cells[0, 3].Value = "Полное  наименование";
        for (int i = 0; i < currencys.Count; i++)
        {
            collection[1].Cells[i + 1, 0].Value = currencys[i].ID;
            collection[1].Cells[i + 1, 1].Value = currencys[i].Code;
            collection[1].Cells[i + 1, 2].Value = currencys[i].Currency;
            collection[1].Cells[i + 1, 3].Value = currencys[i].Name;
        }

        collection[2].Cells[0, 0].Value = "ID";
        collection[2].Cells[0, 1].Value = "ID счёта";
        collection[2].Cells[0, 2].Value = "ID валюты";
        collection[2].Cells[0, 3].Value = "Дата";
        collection[2].Cells[0, 4].Value = "Сумма";
        for (int i = 0; i < charges.Count; i++)
        {
            string str = string.Format("{0:dd/MM/yyyy}", charges[i].Date);
            collection[2].Cells[i + 1, 0].Value = charges[i].ID;
            collection[2].Cells[i + 1, 1].Value = charges[i].AccountID;
            collection[2].Cells[i + 1, 2].Value = charges[i].CurrencyID;
            collection[2].Cells[i + 1, 3].Value = str;
            collection[2].Cells[i + 1, 4].Value = charges[i].Amount;
        }
        wb.Save(DBFilePath);
        Log.WriteToLog(FilePath, $"Сохранение данных прошло успешно");
    }
    public void Read()
    {
        Log.WriteToLog(FilePath, $"Начинаем запись");
        if (!File.Exists(DBFilePath))
        {
            Console.WriteLine("Не можем найти дб!");
            Log.WriteToLog(FilePath, "Во время чтения не смогли найти файл с бд");
            return;
        }

        Workbook wb = new Workbook(DBFilePath);
        WorksheetCollection collection = wb.Worksheets;


        if (collection[0].Name != "Счета" || collection[1].Name != "Курс валют" || collection[2].Name != "Поступления")
        {
            Console.WriteLine("Не найден один или несколько листов!");
            Log.WriteToLog(FilePath, "Во время чтения не найден один или несколько листов!");
            return;
        }


        Worksheet worksheet = collection[0];

        int rows = worksheet.Cells.MaxDataRow;

        for (int i = 1; i <= rows; i++)
        {
            accounts.Add(new Accounts(Convert.ToInt32(worksheet.Cells[i, 0].Value), worksheet.Cells[i, 1].Value.ToString(), DateTime.Parse(worksheet.Cells[i, 2].Value.ToString()).Date));
        }


        worksheet = collection[1];
        rows = worksheet.Cells.MaxDataRow;

        for (int i = 1; i <= rows; i++)
        {
            currencys.Add(new Currencys(Convert.ToInt32(worksheet.Cells[i, 0].Value), worksheet.Cells[i, 1].Value.ToString(), Convert.ToDouble(worksheet.Cells[i, 2].Value), worksheet.Cells[i, 3].Value.ToString()));
        }


        worksheet = collection[2];
        rows = worksheet.Cells.MaxDataRow;

        for (int i = 1; i <= rows; i++)
        {
            charges.Add(new Charges(Convert.ToInt32(worksheet.Cells[i, 0].Value), Convert.ToInt32(worksheet.Cells[i, 1].Value), Convert.ToInt32(worksheet.Cells[i, 2].Value), DateTime.Parse(worksheet.Cells[i, 3].Value.ToString()), Convert.ToDouble(worksheet.Cells[i, 4].Value)));
        }
        Log.WriteToLog(FilePath, $"Запись закончена успешно");
    }
    public void PrintDB(int name)
    {
        switch (name)
        {
            default:
                Console.WriteLine("Нет такого номера");
                break;
            case 1:
                Console.WriteLine("Счёт");
                foreach (var account in accounts) Console.WriteLine(account);
                Log.WriteToLog(FilePath, $"Отображаем таблицу Счёт");
                break;
            case 2:
                Console.WriteLine("Курс валют");
                foreach (var currency in currencys) Console.WriteLine(currency);
                Log.WriteToLog(FilePath, $"Отображаем таблицу Курс валют");
                break;
            case 3:
                Console.WriteLine("Начисления");
                foreach (var charge in charges) Console.WriteLine(charge);
                Log.WriteToLog(FilePath, $"Отображаем таблицу Начисления");
                break;

        }
    }

    public void Del()
    {
        Workbook wb = new Workbook(DBFilePath);
        WorksheetCollection collection = wb.Worksheets;
        Worksheet worksheet = collection[0];

        Console.WriteLine("1.Начисления");
        Console.WriteLine("2.Счета");
        Console.WriteLine("3.Курс валют");
        Console.WriteLine("Выберете из какой таблицы удалять:");
        int choise = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите ID дял удалеиня:");

        int ID = int.Parse(Console.ReadLine());
        switch (choise)
        {
            default:
                Console.WriteLine("Нет такой таблицы!");
                break;
            case 1:
                Log.WriteToLog(FilePath, $"Удаляем ID:{ID} из Начисления");
                charges.RemoveAll(x => x.ID == ID);
                break;
            case 2:
                Log.WriteToLog(FilePath, $"Удаляем ID:{ID} из Счета");
                accounts.RemoveAll(x => x.ID == ID);
                charges.RemoveAll(x => x.AccountID == ID);
                break;
            case 3:
                Log.WriteToLog(FilePath, $"Удаляем ID:{ID} из Курс валют");
                currencys.RemoveAll(x => x.ID == ID);
                break;
        }
    }
    public void EditDB()
    {
        Workbook wb = new Workbook(DBFilePath);
        WorksheetCollection collection = wb.Worksheets;
        Worksheet worksheet = collection[0];



        Console.WriteLine("1.Начисления");
        Console.WriteLine("2.Счета");
        Console.WriteLine("3.Курс валют");
        Console.WriteLine("Выберете в какой таблице изменять:");
        int choise = Convert.ToInt32(Console.ReadLine());
        int choise2 = 0;
        switch (choise)
        {
            default:
                Console.WriteLine("Нет такой таблицы!");
                break;
            case 1:
                Console.WriteLine("выберете ID для изменения:");
                choise2 = Convert.ToInt32(Console.ReadLine());
                
                try
                {
                    var charge = charges.First(x => x.ID == choise2);
                    Console.WriteLine("Введите новый номер счёта:");
                    charge.AccountID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите новый номер валюты:");
                    charge.CurrencyID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите новое время:");
                    charge.Date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите новое количество:");
                    charge.Amount = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }
                Log.WriteToLog(FilePath, $"Изменяем ID:{choise2} в Начислеиня");
                break;
            case 2:
                Console.WriteLine("выберете ID для изменения:");
                choise2 = Convert.ToInt32(Console.ReadLine());

                try
                {
                    var account = accounts.First(x => x.ID == choise2);
                    Console.WriteLine("Введите новое ФИО:");
                    account.HolderFullName = Console.ReadLine();
                    Console.WriteLine("Введите новое время:");
                    account.DateOfOpening = Convert.ToDateTime(Console.ReadLine());
                    //мб фигануть автоматом
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }

                Log.WriteToLog(FilePath, $"Изменяем ID:{choise2} в Счета");
                break;
            case 3:
                Console.WriteLine("выберете ID для изменения:");
                choise2 = Convert.ToInt32(Console.ReadLine());

                try
                {
                    var currency = currencys.First(x => x.ID == choise2);
                    Console.WriteLine("Введите новый код:");
                    currency.Code = Console.ReadLine();
                    Console.WriteLine("Введите значение валюты:");
                    currency.Currency = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите новое имя:");
                    currency.Name = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }

                Log.WriteToLog(FilePath, $"Изменяем ID:{choise2} в Курс валют");
                break;
        }
    }
    public void AddEl()
    {
        Workbook wb = new Workbook(DBFilePath);
        WorksheetCollection collection = wb.Worksheets;
        Worksheet worksheet = collection[0];

        Console.WriteLine("1.Начисления");
        Console.WriteLine("2.Счета");
        Console.WriteLine("3.Курс валют");
        Console.WriteLine("Выберете в какой таблице изменять:");
        int choise = Convert.ToInt32(Console.ReadLine());

        switch (choise)
        {
            default:
                Console.WriteLine("Нет такой таблицы!");
                break;
            case 1:
                try
                {
                    Console.WriteLine("Введите новый номер счёта:");
                    var AccountID = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Введите новый номер валюты:");
                    var CurrencyID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите новое время:");
                    var Date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите новое количество:");
                    var Amount = Convert.ToDouble(Console.ReadLine());
                    int ID = Convert.ToInt32(collection[0].Cells.MaxDataRow) + 1;
                    charges.Add(new Charges(ID, AccountID, CurrencyID, Date, Amount));
                    
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }
                Log.WriteToLog(FilePath, "Успешко изменили данные в таблице Начисления");
                break;
            case 2:
                try
                {


                    Console.WriteLine("Введите Имя Владельца:");
                    var HolderFullName = Console.ReadLine();
                    Console.WriteLine("Введите время:");
                    var DateOfOpening = Convert.ToDateTime(Console.ReadLine());

                    int ID = Convert.ToInt32(collection[0].Cells.MaxDataRow) + 1;
                    accounts.Add(new Accounts(ID, HolderFullName, DateOfOpening));
                    
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }
                Log.WriteToLog(FilePath, "Успешко изменили данные в таблице Счета");
                break;
            case 3:
                try
                {
                    Console.WriteLine("Введите код валюты:");
                    var Code = Console.ReadLine();
                    Console.WriteLine("Введите курс:");
                    var Currency = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите название валюты:");
                    var Name = Console.ReadLine();

                    int ID = Convert.ToInt32(collection[0].Cells.MaxDataRow) + 1;
                    currencys.Add(new Currencys(ID, Code, Currency, Name));
                    
                }
                catch
                {
                    Console.WriteLine("вы неверно ввели данные");
                    return;
                }
                Log.WriteToLog(FilePath, "Успешко изменили данные в таблице Курс валют");
                break;
                
        }

    }
    public void task1()
    {
        var list = from x in charges
                   where x.Amount > 4.9
                   select x;

        foreach(var n in list) Console.WriteLine(n);
        Log.WriteToLog(FilePath, "Вывод строк где начисления за раз больше 4.9.");
    }
    public void task2()
    {
        var summ = charges.GroupBy(x => x.AccountID)
                  .Select(g => new { AccountID = g.Key, Sum = g.Sum(x => x.Amount) });
        var fio = summ.OrderByDescending(u => u.Sum).FirstOrDefault().AccountID;
        var res = accounts.Find(x => x.ID == fio).HolderFullName;
        Console.WriteLine(res);
        Log.WriteToLog(FilePath, "Вывод ФИО номера с самым большим количеством поступлений");
    }

}
