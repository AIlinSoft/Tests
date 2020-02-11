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
        static Dictionary<int, int> test = new Dictionary<int, int>(500000);
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
           // Dictionary<int, int> test = new Dictionary<int, int>(500000);
            int currentCapacity = test.EnsureCapacity(0);
           // int count1 = GC.CollectionCount(2);
            int sumCapacity = currentCapacity;
            for (int i = 0; i <= count && currentStep < steps.Length; ++i)
            {
                test.Add(i, i);
                if (currentCapacity != test.EnsureCapacity(0))
                {
                    currentCapacity = currentCapacity = test.EnsureCapacity(0);
                    sumCapacity += currentCapacity;
                }
                if (i == steps[currentStep])
                {
                    currentStep++;
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect(2, GCCollectionMode.Forced, true, true);
                    long bytesCount = GC.GetTotalMemory(false);
                    Console.Write(i.ToString());
                    Console.Write("; ");
                    Console.WriteLine(bytesCount);
                }
            }
         //   int count2 = GC.CollectionCount(2);
            Console.WriteLine($"Sum capacity {sumCapacity}");
         //   Console.WriteLine($"Сollection count1 {(count1)} count2 {(count2)} currentStep {currentStep}");
        }
    }
}
