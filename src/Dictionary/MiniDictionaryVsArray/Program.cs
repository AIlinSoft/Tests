using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiniDictionaryVsArray
{
    class Program
    {
        class KeyValPair
        {
            public int[] Keys;
            public int[] Values;
            public KeyValPair(int count)
            {
                Keys = new int[count];
                Values = new int[count];
            }
        }
        private static int m_ArrayLength = 1000000;
        private static int m_ValuesLength = 80;
        private static Dictionary<int, int>[] m_DictValues = new Dictionary<int, int>[m_ArrayLength];
        private static KeyValPair[] m_ArrayValues = new KeyValPair[m_ArrayLength];
        private static int[] m_SearchValues = new int[m_ArrayLength];
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (var i = 0; i < m_ArrayLength; ++i)
                m_SearchValues[i] = rand.Next(0, m_ValuesLength - 1);
            Test1Fill();
            Test2Fill();
            Test1();
            Test2();
            Test1();
            Test2();
            Test1();
            Test2();
            Test1();
            Test2();
            Test1();
            Test2();
            Test1();
            Test2();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        static void Test1Fill()
        {
            for(int i = 0; i < m_ArrayLength; ++i)
            {
                m_DictValues[i] = new Dictionary<int, int>(m_ValuesLength);
                for(int j = 0; j < m_ValuesLength; ++j)
                {
                    m_DictValues[i][j] = j;
                }
            }

        }
        static void Test2Fill()
        {
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                m_ArrayValues[i] = new KeyValPair(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_ArrayValues[i].Keys[j] = j;
                    m_ArrayValues[i].Values[j] = j;
                }
            }

        }
        static void Test1()
        {
            int t = m_ValuesLength / 2;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i = 0; i < m_ArrayLength; ++i)
            {

                if (m_DictValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
            Console.WriteLine($"{nameof(Test1)} time: {(sw.Elapsed)}, result {result}");
        }
        static void Test2()
        {
            int t = m_ValuesLength / 2;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                var temp = m_ArrayValues[i].Keys;
                int t1 = m_SearchValues[i];
                for (int j = 0; j < temp.Length; ++j)
                {
                    if(temp[j] == t1)
                    {
                        result += m_ArrayValues[i].Values[j];
                        break;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"{nameof(Test2)} time: {(sw.Elapsed)}, result {result}");
        }
    }
}
