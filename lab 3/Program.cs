using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json.Serialization.Metadata;
using System.Xml.Serialization;
class Program
{
    static void SortArray()
    {
        int length = ReadLength();
        int[] array1 = CreateArray(length);
        int[] array2 = CopyArray(array1);
        Console.WriteLine("массив до сортировки");
        PrintArray(array1);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        InsertionSort(array1);
        sw.Stop();
        double time1 = sw.Elapsed.TotalSeconds;

        sw.Restart();
        BubbleSort(array2);
        sw.Stop();
        double time2 = sw.Elapsed.TotalSeconds;
        Console.WriteLine("после сортировки вставками:");
        PrintArray(array1);
        Console.WriteLine("после сортировки пузырем:");
        PrintArray(array2);
        Console.WriteLine($"время вставки{time1}");
        Console.WriteLine($"время пузырьком{time2}");
    }
    static bool AskExit()
    {
        string answer = "";
        while (answer != "y" && answer != "n")
        {
            Console.WriteLine("выйти y/n");
            answer = Console.ReadLine();
            if (answer != "y" && answer != "n")
            {
                Console.WriteLine("ошибка");
            }
        }
        if (answer == "y")
            return true;
        else
            return false;
    }

    static int ReadInt(string prompt)
    {
        int number = 0;
        bool ok = false;
        while (!ok)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
                ok = true;
            else
                Console.WriteLine("Ошибка!");
        }
        return number;
    }

    static double ReadDouble(string prompt)
    {
        double result = 0;
        bool ok = false;
        while (!ok)
        {
            Console.WriteLine(prompt);
            if (double.TryParse(Console.ReadLine(), out result))
                ok = true;
            else
                Console.WriteLine("Ошибка! Введи число.");
        }
        return result;
    }



    static double Calculate(double a, double b)
    {
        return Math.Pow(Math.Log(b), 2) / (Math.Cos(a) - 1);
    }


    static void GuessGame(double res)
    {
        int tries = 3;
        bool guess = false;
        while (tries > 0 && !guess)
        {
            Console.WriteLine("каков результат вычисления?");
            double ans = ReadDouble("какой результат?");
            ans = Math.Round(ans, 2);
            if (res == ans)
                guess = true;
            else
                tries--;
            Console.WriteLine($"попыток осталось {tries}");
        }
        if (guess)
            Console.WriteLine("правильно");

        else
        {
            Console.WriteLine($"правильный ответ {res}");
        }
    }
    static int ReadLength()
    {
        int length = ReadInt("введи длину массива");
        while (length <= 0)
        {
            Console.WriteLine("длина должна быть больше 0!");
            length = ReadInt("введи длину массива");
        }
        return length;
    }
    static int[] CreateArray(int length)
    {
        int[] list = new int[length];
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            list[i] = rnd.Next(1, 100);

        }
        return list;
    }
    static int[] CopyArray(int[] list)
    {
        return (int[])list.Clone();
    }
    static void PrintArray(int[] list)
    {
        if (list.Length > 10)
        {
            Console.WriteLine("массивы не выведены тк длина больше 10");
            return;
        }
        foreach (int i in list)
        {
            Console.WriteLine($"{i}");

        }
    }
    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int index = i - 1;
            while (index >= 0 && array[index] > key)
            {
                array[index + 1] = array[index];
                index--;
            }
            array[index + 1] = key;
        }
        //return array;
    }


    static int[] BubbleSort(int[] array)
    {
        int length = array.Length;
        while (length != 0)
        {
            int maxIndex = 0;
            for (int i = 1; i < length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    int temp = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp;
                    maxIndex = i;
                }
            }
            length = maxIndex;
        }
        return array;
    }


    static void About()
    {
        Console.WriteLine("Чекалин Арсений Олегович \n 6104-090301D");
    }
    static void Game()
    {
        Console.WriteLine("отгадай ответ");
        Console.WriteLine("ln^2b");
        Console.WriteLine("------");
        Console.WriteLine("cos(a)-1");
        double alpha = ReadDouble("введи alpha");
        double znamenatel = (Math.Cos(alpha) - 1);
        while (Math.Abs(znamenatel) < 0.01)
        {
            Console.WriteLine("знаменатель равен нулю");
            alpha = ReadDouble("введи alpha");
            znamenatel = (Math.Cos(alpha) - 1);
        }

        double b = ReadDouble("введи b:");
        while (b <= 0)
        {
            Console.WriteLine("b=0");
            b = ReadDouble("введи b");
        }

        double res = Calculate(alpha, b);
        res = Math.Round(res, 2);
        GuessGame(res);
    }


    private static void Main(string[] args)
    {
        bool working = true;

        while (working)
        {
            Console.Write("1) отгадай ответ\n2) Об авторе\n3) выход\n 4)сортировка массива\n ");
            int a = ReadInt("введи число");

            switch (a)
            {
                case 1:
                    Game();
                    break;
                case 2:
                    About();
                    break;
                case 3:
                    if (AskExit())
                    {
                        working = false;
                    }
                    break;
                default:
                    Console.WriteLine(" работает только  1 2 3 4");
                    break;
                case 4:
                    SortArray();
                    break;


            }
        }
    }
}
