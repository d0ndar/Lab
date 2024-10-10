using System;
internal class Program
{
    public double fraction(double x)
    {
        return Math.Abs(x) - (int)Math.Abs(x);
    }
    public int charToNum(char x)
    {
        return x - 48;
    }
    public bool is2Digits(int x)
    {
        return (x / 100 == 0) && (x/10 != 0);
    }
    public bool isInRange(int a, int b, int num)
    {
        return (a > b && num >= b && num <= a) || (a < b && num >= a && num <= b);
    }
    public bool isEqual(int a, int b, int c)
    {
        return a == b && b == c;
    }
    public int abs(int x)
    {
        if (x < 0) return -x;
        else return x;
    }
    public bool is35(int x)
    {
        if ((x % 3 == 0 && x % 5 != 0) || (x % 3 != 0 && x % 5 == 0)) return true;
        else return false;
    }
    public int max3(int x, int y, int z)
    {
        if ((x>y) && (x>z)) return x;
        if ((y>x) && (y>z)) return y;
        return z;
    }
    public int sum2(int x, int y)
    {
        if ((x + y >= 10) && (x + y <= 19)) return 20;
        return x + y;
    }
    public String day(int x)
    {
        switch (x)
        {
            case 1: return "Понедельник";
            case 2: return "вторник";
            case 3: return "среда";
            case 4: return "четверг";
            case 5: return "пятница";
            case 6: return "суббота";
            case 7: return "воскресенье";
            default: return "Это не день недели!";
        }
    }
    public String listNums(int x)
    {
        string result = "";
        for (int i = 0; i <= x; i++) result += i + " ";
        return result;
    }
    public String chet(int x)
    {
        string result = "";
        for (int i = 0; i <= x; i += 2) result += i + " ";
        return result;
    }
    public int numLen(long x)
    {
        int ans = 0;
        while (Math.Abs(x)>0)
        {
            x = x / 10;
            ans++;
        }
        return ans;
    }
    public void square(int x)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j <x; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
    }
    public void rightTriangle(int x)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 1; j <= x - i; j++) Console.Write(" ");
            for (int g = 1; g <= i; g++) Console.Write("*");
            Console.WriteLine("");
        }
    }
    public int findFirst(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (x == arr[i]) return i;
        }
        return -1;
    }
    public int maxAbs(int[] arr)
    {
        int x = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (Math.Abs(x) < Math.Abs(arr[i])) x = arr[i];
        }
        return x;
    }
    public int[] add(int[] arr, int[] ins, int pos)
    {
        int[] ans = new int[arr.Length + ins.Length];
        for (int i = 0; i < pos; i++) ans[i] = arr[i];
        for (int i = pos; i - pos < ins.Length; i++) ans[i] = ins[i-pos];
        for (int i = ins.Length + pos; i - ins.Length < arr.Length; i++) ans[i] = arr[i - ins.Length];
        return ans;
    }
    public int[] reverseBack(int[] arr)
    {
        int[] ans = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) ans[i] = arr[arr.Length - i - 1];
        return ans;
    }
    public int[] findAll(int[] arr, int x)
    {
        int j = 0;
        for (int i = 0; i < arr.Length; i++) if (x == arr[i]) j++;
        int[] ans = new int[j];
        j = 0;
        for (int i = 0; i < arr.Length; i++) if (x == arr[i]) ans[j++] = i;
        return ans;
    }

    private static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine("Вариант нечётный");

        
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("");
            Console.WriteLine("1. Задание 1");
            Console.WriteLine("2. Задание 2");
            Console.WriteLine("3. Задание 3");
            Console.WriteLine("4. Задание 4");
            Console.WriteLine("5. выход");
            Console.Write("Выберите номер задания:");
            int TaskNumber = Convert.ToInt32(Console.ReadLine());
            switch (TaskNumber)
            {
                case 1:
                    Console.WriteLine("Список заданий:");
                    Console.WriteLine("1. Задание 1");
                    Console.WriteLine("2. Задание 3");
                    Console.WriteLine("3. Задание 5");
                    Console.WriteLine("4. Задание 7");
                    Console.WriteLine("5. Задание 9");
                    Console.Write("Выберите номер задания:");
                    int Task1 = Convert.ToInt32(Console.ReadLine());
                    switch (Task1)
                    {
                        case 1:
                            Console.Write("введите дробное число:");
                            double x1 = Convert.ToDouble(Console.ReadLine());
                            double result1 = p.fraction(x1);
                            Console.WriteLine($"Дробной частью числа {x1} является {result1}");
                            break;
                        case 2:
                            Console.Write("Введите число от 0 до 9: ");
                            char x2 = Console.ReadLine()[0];
                            int result2 = p.charToNum(x2);
                            Console.WriteLine("Результат: " + result2);
                            break;
                        case 3:
                            Console.Write("введите число: ");
                            int x3 = Convert.ToInt32(Console.ReadLine());
                            bool result3 = p.is2Digits(x3);
                            Console.WriteLine($"Число {x3} {(result3 ? "является" : "не является")} двузначным.");
                            break;
                        case 4:
                            Console.Write("введите a: ");
                            int a4 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите b: ");
                            int b4 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите num: ");
                            int num4 = Convert.ToInt32(Console.ReadLine());
                            bool result4 = p.isInRange(a4,b4,num4);
                            Console.WriteLine("Результат: " + result4); 
                            break;
                        case 5:
                            Console.Write("введите a: ");
                            int a5 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите b: ");
                            int b5 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите c: ");
                            int c5 = Convert.ToInt32(Console.ReadLine());
                            bool result5 = p.isEqual(a5,b5,c5);
                            Console.WriteLine("Результат: " + result5);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Список заданий:");
                    Console.WriteLine("1. Задание 1");
                    Console.WriteLine("2. Задание 3");
                    Console.WriteLine("3. Задание 5");
                    Console.WriteLine("4. Задание 7");
                    Console.WriteLine("5. Задание 9");
                    Console.Write("Выберите номер задания:");
                    int Task2 = Convert.ToInt32(Console.ReadLine());
                    switch (Task2)
                    {
                        case 1:
                            Console.Write("введите x: ");
                            int x1 = Convert.ToInt32(Console.ReadLine());
                            int result1 = p.abs(x1);
                            Console.WriteLine("Результат: " + result1);
                            break;
                        case 2:
                            Console.Write("введите x: ");
                            int x2 = Convert.ToInt32(Console.ReadLine());
                            bool result2 = p.is35(x2);
                            Console.WriteLine("Результат: " + result2);
                            break;
                        case 3:
                            Console.Write("введите x: ");
                            int x3 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите y: ");
                            int y3 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите z: ");
                            int z3 = Convert.ToInt32(Console.ReadLine());
                            int result3 = p.max3(x3,y3,z3);
                            Console.WriteLine("Результат: " + result3); 
                            break;
                        case 4:
                            Console.Write("введите x: ");
                            int x4 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите y: ");
                            int y4 = Convert.ToInt32(Console.ReadLine());
                            int result4 = p.sum2(x4,y4);
                            Console.WriteLine("Результат: " + result4);
                            break;
                        case 5:
                            Console.Write("введите x: ");
                            int x5 = Convert.ToInt32(Console.ReadLine());
                            string result5 = p.day(x5);
                            Console.WriteLine(result5);
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Список заданий:");
                    Console.WriteLine("1. Задание 1");
                    Console.WriteLine("2. Задание 3");
                    Console.WriteLine("3. Задание 5");
                    Console.WriteLine("4. Задание 7");
                    Console.WriteLine("5. Задание 9");
                    Console.Write("Выберите номер задания:");
                    int Task3 = Convert.ToInt32(Console.ReadLine());
                    switch (Task3)
                    {
                        case 1:
                            Console.Write("введите x: ");
                            int x1 = Convert.ToInt32(Console.ReadLine());
                            string result1 = p.listNums(x1);
                            Console.WriteLine(result1); 
                            break;
                        case 2:
                            Console.Write("введите x: ");
                            int x2 = Convert.ToInt32(Console.ReadLine());
                            string result2 = p.chet(x2);
                            Console.WriteLine(result2); 
                            break;
                        case 3:
                            Console.Write("введите x: ");
                            long x3 = Convert.ToInt64(Console.ReadLine());
                            int result3 = p.numLen(x3);
                            Console.WriteLine(result3);
                            break;
                        case 4:
                            Console.Write("введите x: ");
                            int x4 = Convert.ToInt32(Console.ReadLine());
                            p.square(x4);
                            break;
                        case 5:
                            Console.Write("введите x: ");
                            int x5 = Convert.ToInt32(Console.ReadLine());
                            p.rightTriangle(x5);
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Список заданий:");
                    Console.WriteLine("1. Задание 1");
                    Console.WriteLine("2. Задание 3");
                    Console.WriteLine("3. Задание 5");
                    Console.WriteLine("4. Задание 7");
                    Console.WriteLine("5. Задание 9");
                    Console.Write("Выберите номер задания:");
                    int Task4 = Convert.ToInt32(Console.ReadLine());
                    switch (Task4)
                    {
                        case 1:
                            Console.Write("введите x: ");
                            int x1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите arr: ");
                            string[] s = Console.ReadLine().Split(' ');
                            int[] arr1 = new int[s.Length];
                            for (int i = 0; i < s.Length; i++) arr1[i] = Convert.ToInt32(s[i]);
                            int result1 = p.findFirst(arr1,x1);
                            Console.WriteLine(result1);
                            break;
                        case 2:
                            Console.Write("введите arr: ");
                            string[] s2 = Console.ReadLine().Split(' ');
                            int[] arr2 = new int[s2.Length];
                            for (int i = 0; i < s2.Length; i++) arr2[i] = Convert.ToInt32(s2[i]);
                            int result2 = p.maxAbs(arr2);
                            Console.WriteLine(result2); 
                            break;
                        case 3:
                            Console.Write("введите ins: ");
                            string[] ins3 = Console.ReadLine().Split(' ');
                            int[] ins = new int[ins3.Length];
                            for (int i = 0; i < ins3.Length; i++) ins[i] = Convert.ToInt32(ins3[i]);

                            Console.Write("введите arr: ");
                            string[] s3 = Console.ReadLine().Split(' ');
                            int[] arr3 = new int[s3.Length];
                            for (int i = 0; i < s3.Length; i++) arr3[i] = Convert.ToInt32(s3[i]);

                            Console.Write("введите pos: ");
                            int pos = Convert.ToInt32(Console.ReadLine());

                            int[] result3 = p.add(arr3,ins,pos);
                            Console.WriteLine("Результат: [" + string.Join(", ", result3) + "]");
                            break;
                        case 4:
                            Console.Write("введите arr: ");
                            string[] s4 = Console.ReadLine().Split(' ');
                            int[] arr4 = new int[s4.Length];
                            for (int i = 0; i < s4.Length; i++) arr4[i] = Convert.ToInt32(s4[i]);
                            int[] result4 = p.reverseBack(arr4);
                            Console.WriteLine("Результат: [" + string.Join(", ", result4) + "]");
                            break;
                        case 5:
                            Console.Write("введите x: ");
                            int x5 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("введите arr: ");
                            string[] s5 = Console.ReadLine().Split(' ');
                            int[] arr5 = new int[s5.Length];
                            for (int i = 0; i < s5.Length; i++) arr5[i] = Convert.ToInt32(s5[i]);
                            int[] result5 = p.findAll(arr5, x5);
                            Console.WriteLine("Результат: [" + string.Join(", ", result5) + "]");
                            break;
                    }
                    break;
                case 5:
                    exit = false;
                    break;
            }
        }
    }
}