using System;


namespace lab3;

public class matrixs
{
    private int[,] matrix;
    public matrixs()
    {
        matrix = new int[0, 0];
    }
    //1
    public  matrixs(int rowCount, int columnCount)
    {
        int index, x, y;

        int[,] array = new int[rowCount, columnCount];
        x = rowCount - 1;
        y = 0;

        for (index = 1; index <= rowCount * columnCount; index++)
        {
            array[x, y] = index;
            int x0, y0;

            x0 = x;
            y0 = y;

            if ((x != 0) && (y != 0))
            {
                x--;
                y--;
            }
            else if ((y == 0) && (x == 0))
            {
                x = rowCount - 2;
                y = columnCount - 1;
            }
            else if (y == 0)
            {
                y = columnCount - x0;
                x = rowCount - 1;
            }
            else if (x == 0)
            {
                x = rowCount - 2 - y0;
                y = columnCount - 1;
            }
        }

        for (x = 0; x < rowCount; x++)
        {
            for (y = 0; y < columnCount; y++)
            {
                Console.Write($"{array[x, y],4}");
            }

            Console.WriteLine();
        }
    }
    //2
    public matrixs(int n)
    {
        int rowIndex, columnIndex;

        int[,] matrix = new int[n + 1, n + 1];
        Random randomGenerator = new Random();
        for (rowIndex = 1; rowIndex <= n; rowIndex++)
        {
            for (columnIndex = 1; columnIndex <= n; columnIndex++)
            {
                matrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex - 1] - randomGenerator.Next(5) - 1;
            }
        }

        for (rowIndex = 1; rowIndex <= n; rowIndex++)
        {
            for (columnIndex = 1; columnIndex <= n; columnIndex++)
                Console.Write(" " + matrix[rowIndex, columnIndex]);
            Console.WriteLine();
        }
    }

    //3
    public  matrixs(int n,int x,int y)
    {
        
        int  d, max, i, j;

        int[,] result = new int[n+1, n+1];
        y = 0;
        x = 1;
        max = 1;
        i = n;
        d = 1;

        while (i >= 1)
        {
            for (j = i; j >= 1; j--)
            {
                y = y + d;
                result[y, x] = max;
                max++;
            }
            i--;
            for (j = i; j >= 1; j--)
            {
                x = x + d;
                result[y, x] = max;
                max++;
            }
            d = d * (-1);
        }

        for (i = 1; i <= n; i++)
        {
            Console.WriteLine();
            for (j = 1; j <= n; j++)
            {
                Console.Write(result[i, j].ToString().PadLeft(2) + " ");
            }
        }
        Console.WriteLine();
    }


    //задание 2
    public static string CreateAndCalculate(int n)
    {
        int[,] matrix = new int[n+1,2];
        int j = n;
        while (n>0)
        {
            matrix[n, 0] = ValidateInput.Input1or0("Введите 1(да) или 0(нет) для первого голоса депутата");
            matrix[n, 1] = ValidateInput.Input1or0("Введите 1(да) или 0(нет) для второго голоса депутата");
            n--;
        }
        
        int calc1 = 0;
        int calc2 = 0;
        for (int i=0; i<j;i++)
        {
            if (matrix[i,0] == matrix[i,1]) calc1 += 1;
        }
        if (calc1 == calc2) return "Их поровну";
        if (calc1 > calc2) return "Тех кто не поменял свой голос больше";
        return "Тех кто поменял голос больше";
    }

}
