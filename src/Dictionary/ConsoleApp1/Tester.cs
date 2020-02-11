using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniDictionaryVsArray
{
    class Tester
    {
        struct Entry
        {
            public int[] Keys;
            public int[] Values;
            public Entry(int count)
            {
                Keys = new int[count];
                Values = new int[count];
            }
        }
        private static readonly int m_ArrayLength = 1000000;
        private int m_ValuesLength = 130;
        private Dictionary<int, int>[] m_DictValues = new Dictionary<int, int>[m_ArrayLength];
        private Entry[] m_ArrayValues = new Entry[m_ArrayLength];
        private int[] m_SearchValues = new int[m_ArrayLength];
        private List<long> m_Test1Times = new List<long>();
        private List<long> m_Test2Times = new List<long>();
        private bool m_Test1Run;
        private bool m_Test2Run;
        public Tester(int valuesLength, bool test1Run = true, bool test2Run = true)
        {
            m_ValuesLength = valuesLength;
            m_Test1Run = test1Run;
            m_Test2Run = test2Run;
            Random rand = new Random();
            for (var i = 0; i < m_ArrayLength; ++i)
                m_SearchValues[i] = rand.Next(0, m_ValuesLength - 1);
            Test1Fill();
            Test2Fill();
        }
        public void Start()
        {
            Test1(false);
            Test2(false);
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
            Test1Print();
            Test2Print();
        }
        void Test1Fill()
        {
            if (!m_Test1Run)
                return;
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                m_DictValues[i] = new Dictionary<int, int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_DictValues[i][j] = j;
                }
            }

        }
        void Test2Fill()
        {
            if (!m_Test2Run)
                return;
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                m_ArrayValues[i] = new Entry(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_ArrayValues[i].Keys[j] = j;
                    m_ArrayValues[i].Values[j] = j;
                }
            }

        }
        void Test1(bool storeTime = true)
        {
            if (!m_Test1Run)
                return;
            int t = m_ValuesLength / 2;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_ArrayLength; ++i)
            {

                if (m_DictValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
            Console.WriteLine($"{nameof(Test1)} time: {(sw.Elapsed)}, result {result}");
            if (storeTime)
                m_Test1Times.Add(sw.Elapsed.Ticks);
        }
        void Test2(bool storeTime = true)
        {
            if (!m_Test2Run)
                return;
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
                    if (temp[j] == t1)
                    {
                        result += m_ArrayValues[i].Values[j];
                        break;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"{nameof(Test2)} time: {(sw.Elapsed)}, result {result}");
            if (storeTime)
                m_Test2Times.Add(sw.Elapsed.Ticks);
        }
        void Test1Print()
        {
            if (!m_Test1Run)
                return;
            Console.WriteLine($"Test1: values {m_ValuesLength} avg {m_Test1Times.Average()} ticks");
        }
        void Test2Print()
        {
            if (!m_Test2Run)
                return;
            Console.WriteLine($"Test2: values {m_ValuesLength} avg {m_Test2Times.Average()} ticks");
        }
    }
}
