using System;
using System.Collections.Generic;
using System.Runtime;

namespace LeaksTest
{
    class Program
    {
        private static Dictionary<int, int> m_Test = new Dictionary<int, int>(500000);
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
        /// <summary>
        /// Тест занятой памяти в словаре после удаления из него данных
        /// </summary>
        private static void Test1()
        {
            Console.WriteLine($"Запустили тест без TrimExcess()");
            int count = 13000000;
            for (int i = 0; i <= count; ++i)
                m_Test.Add(i, i);
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            long bytesCount = GC.GetTotalMemory(true);
            Console.WriteLine($"Заполнили {bytesCount}");
            for (int i = 0; i <= count; ++i)
                m_Test.Remove(i);
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            bytesCount = GC.GetTotalMemory(true);
            Console.WriteLine($"Очистили {bytesCount}");
        }
        /// <summary>
        /// Тест занятой памяти в словаре после удаления из него данных с освобождением памяти через TrimExcess() 
        /// </summary>
        private static void Test2()
        {
            Console.WriteLine($"Запустили тест с TrimExcess()");
            int count = 13000000;
            for (int i = 0; i <= count; ++i)
                m_Test.Add(i, i);
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            long bytesCount = GC.GetTotalMemory(true);
            Console.WriteLine($"Заполнили {bytesCount}");
            for (int i = 0; i <= count; ++i)
                m_Test.Remove(i);
            m_Test.TrimExcess();
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            bytesCount = GC.GetTotalMemory(true);
            Console.WriteLine($"Очистили {bytesCount}");
        }
    }
}
