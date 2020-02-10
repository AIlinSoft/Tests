using System;
using System.Collections.Generic;
using System.Runtime;

namespace ExtraMemoryWithRefKeyValueTest
{
    class Program
    {
        class Key
        {
            public int Item { get; set; }
            public Key(int item)
            {
                Item = item;
            }
            public override bool Equals(object obj)
            {
                return Item.Equals(obj);
            }
            public override int GetHashCode()
            {
                return Item.GetHashCode();
            }
        }
        class Value
        {
            public int Item { get; set; }
            public Value(int item)
            {
                Item = item;
            }

        }

        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        /// <summary>
        /// Тест последовательного добавления элементов ссылочного типа в словарь и замера занятой им памяти
        /// </summary>
        private static void Test()
        {
            int count = 13000000;
            List<int> t = new List<int>();
            for (int i = 500000; i < 13500000; i += 500000)
                t.Add(i);
            var steps = t.ToArray();
            int currentStep = 0;
            Dictionary<Key, Value> test = new Dictionary<Key, Value>(500000);
            for (int i = 0; i <= count && currentStep < steps.Length; ++i)
            {
                test.Add(new Key(i), new Value(i));
                if (i == steps[currentStep])
                {
                    currentStep++;
                    GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                    GC.Collect(2, GCCollectionMode.Forced, true, true);
                    long bytesCount = GC.GetTotalMemory(true);
                    Console.Write(i.ToString());
                    Console.Write(";");
                    Console.WriteLine(bytesCount);
                }
            }

        }
    }
}
