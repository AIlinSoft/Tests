using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDictionaryVsArrayFramework2
{
    class Program
    {
        class Pair
        {
            public int Number;
            public int Text;
            public Pair(int number, int text)
            {
                Number = number;
                Text = text;
            }
        }

        static void Main(string[] args)
        {
            int numbersCount = 20;
            int[] numbers = new int[numbersCount];
            Pair[] values1 = new Pair[numbers.Length];
            Dictionary<int, int> values2 = new Dictionary<int, int>(numbers.Length);
            Random t = new Random();
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = t.Next(1147483647, int.MaxValue);
                values1[i] = new Pair(numbers[i], 1);
                values2[numbers[i]] = 1;
            }
            numbers = numbers.Reverse().ToArray();
            int count = 10000000;
            Method1(numbersCount, numbers, values1, count);
            Method2(numbersCount, numbers, values2, count);
            Method1(numbersCount, numbers, values1, count);
            Method2(numbersCount, numbers, values2, count);
            Method1(numbersCount, numbers, values1, count);
            Method2(numbersCount, numbers, values2, count);



            Console.WriteLine("Конец");
            Console.ReadKey();
        }

        private static void Method1(int numbersCount, int[] numbers, Pair[] values1, int count)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long counter = 0;
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < numbersCount; ++j)
                {
                    int numForSearch = numbers[j];

                    for (int k = 0; k < numbersCount; ++k)
                    {
                        if (values1[k].Number == numForSearch)
                        {
                            counter += values1[k].Text;
                            //counter += values1[k].Text.Length;
                            break;
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Затратили на массив {sw.Elapsed}, результат {counter}");
        }
        private static void Method2(int numbersCount, int[] numbers, Dictionary<int, int> values1, int count)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long counter = 0;
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < numbersCount; ++j)
                {
                    int numForSearch = numbers[j];
                    var val = values1[numForSearch];
                    counter += val;
                  //  counter += val.Length;
                }
            }
            sw.Stop();
            Console.WriteLine($"Затратили на словарь {sw.Elapsed}, результат {counter}");
        }
    }
}
