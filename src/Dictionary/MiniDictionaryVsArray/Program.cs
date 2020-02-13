using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;

namespace MiniDictionaryVsArray
{
    class Program
    {
        private static readonly int m_ArrayLength = 50000;
        static void Main(string[] args)
        {
            int[] searchValues = new int[m_ArrayLength];
            List<double> array1 = new List<double>();
            List<double> dict1 = new List<double>();
            List<double> dictInt1 = new List<double>();
            List<double> sortedList1 = new List<double>();


            List<double> array2 = new List<double>();
            List<double> dict2 = new List<double>();
            List<double> dictInt2 = new List<double>();
            List<double> sortedList2 = new List<double>();
            
            for (int i = 10; i < 200; i+=10)
            {
                Random rand = new Random();
                for (var j = 0; j < searchValues.Length; ++j)
                    searchValues[j] = rand.Next(0, i - 1);

                TesterArray testerArray = new TesterArray(i, searchValues);
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                for (int j = 0; j < 10; ++j)
                    testerArray.Run(j > 0);
                array1.Add(testerArray.GetAverageTicks());
                array2.Add(GC.GetTotalMemory(false));
                testerArray.Print();
                testerArray = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                
                TesterDictionary testerDictionary = new TesterDictionary(i, searchValues);
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                for (int j = 0; j < 10; ++j)
                    testerDictionary.Run(j > 0);
                dict1.Add(testerDictionary.GetAverageTicks());
                dict2.Add(GC.GetTotalMemory(false));
                testerDictionary.Print();
                testerDictionary = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                
                TesterDictionaryInt testerDictionaryInt = new TesterDictionaryInt(i, searchValues);
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                for (int j = 0; j < 10; ++j)
                    testerDictionaryInt.Run(j > 0);
                dictInt1.Add(testerDictionaryInt.GetAverageTicks());
                dictInt2.Add(GC.GetTotalMemory(false));
                testerDictionaryInt.Print();
                testerDictionaryInt = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                
                TesterSortedList testerSortedList = new TesterSortedList(i, searchValues);
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
                for (int j = 0; j < 10; ++j)
                    testerSortedList.Run(j > 0);
                sortedList1.Add(testerSortedList.GetAverageTicks());
                sortedList2.Add(GC.GetTotalMemory(false));
                testerSortedList.Print();
                testerSortedList = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
            }

            Console.WriteLine($"TesterArray times");
            foreach (var item in array1)
                Console.WriteLine(item * 100 / m_ArrayLength);

            Console.WriteLine($"TesterDictionary times");
            foreach (var item in dict1)
                Console.WriteLine(item * 100 / m_ArrayLength);

            Console.WriteLine($"TesterDictionaryInt times");
            foreach (var item in dictInt1)
                Console.WriteLine(item * 100 / m_ArrayLength);

            Console.WriteLine($"TesterSortedList times");
            foreach (var item in sortedList1)
                Console.WriteLine(item * 100 / m_ArrayLength);

            Console.WriteLine($"TesterArray memory");
            foreach (var item in array2)
                Console.WriteLine(item / 1024 / 1024);

            Console.WriteLine($"TesterDictionary memory");
            foreach (var item in dict2)
                Console.WriteLine(item / 1024 / 1024);

            Console.WriteLine($"TesterDictionaryInt memory");
            foreach (var item in dictInt2)
                Console.WriteLine(item / 1024 / 1024);

            Console.WriteLine($"TesterSortedList memory");
            foreach (var item in sortedList2)
                Console.WriteLine(item / 1024 / 1024);


            Console.WriteLine("Done!");
            Console.ReadLine();
        }


    }
}
