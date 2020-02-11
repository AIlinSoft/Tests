using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;

namespace MiniDictionaryVsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 10; i < 200; i += 10)
            {
                Tester t = new Tester(i);
                t.Start();
                t = null;
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect(2, GCCollectionMode.Forced, true, true);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }


    }
}
