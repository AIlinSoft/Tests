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

            for (int i = 10; i < 200; i+=10)
            {
                Random rand = new Random();
                for (var j = 0; j < searchValues.Length; ++j)
                    searchValues[j] = rand.Next(0, i - 1);

                TesterDictionary t = new TesterDictionary(i, searchValues);
                t.Run();
                t = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }


    }
}
