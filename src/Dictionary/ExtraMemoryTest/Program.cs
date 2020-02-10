using System;
using System.Collections.Generic;
using System.Runtime;

namespace ExtraMemoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
        /// <summary>
        /// Тест последовательного добавления элементов в словарь и замера занятой им памяти
        /// </summary>
        private static void Test()
        {
            int count = 13000000;
            List<int> t = new List<int>();
            for (int i = 500000; i < 13500000; i += 500000)
                t.Add(i);
            var steps = t.ToArray();
            int currentStep = 0;
            Dictionary<int, int> test = new Dictionary<int, int>(500000);
            for (int i = 0; i <= count && currentStep < steps.Length; ++i)
            {
                test.Add(i, i);
                if (i == steps[currentStep])
                {
                    currentStep++;
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect(2, GCCollectionMode.Forced, true, true);
                    long bytesCount = GC.GetTotalMemory(true);
                    Console.Write(i.ToString());
                    Console.Write("; ");
                    Console.WriteLine(bytesCount);
                }
            }
        }
    }
}
