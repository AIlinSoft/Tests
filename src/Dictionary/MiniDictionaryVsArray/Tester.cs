using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniDictionaryVsArray
{
    class Tester
    {
        struct Entry<TValue>
        {
            public int[] Keys;
            public TValue[] Values;
            public Entry(int count)
            {
                Keys = new int[count];
                Values = new TValue[count];
            }
            public bool TryGetValue(int key, out TValue value)
            {
                for (int j = 0; j < Keys.Length; ++j)
                {
                    if (Keys[j] == key)
                    {
                        value = Values[j];
                        return true;
                    }
                }
                value = default(TValue);
                return false;
            }
        }
        private static readonly int m_ArrayLength = 50000;
        private int m_ValuesLength;
        private Dictionary<int, int>[] m_DictValues = new Dictionary<int, int>[m_ArrayLength];
        private Entry<int>[] m_ArrayValues = new Entry<int>[m_ArrayLength];
        private SortedList<int, int>[] m_SortedListValues = new SortedList<int, int>[m_ArrayLength];
        private int[] m_SearchValues = new int[m_ArrayLength];
        private List<long> m_Test1Times = new List<long>();
        private List<long> m_Test2Times = new List<long>();
        private List<long> m_Test3Times = new List<long>();
        private bool m_Test1Run;
        private bool m_Test2Run;
        private bool m_Test3Run;
        public Tester(int valuesLength, bool test1Run = true, bool test2Run = true, bool test3Run = true)
        {
            m_ValuesLength = valuesLength;
            m_Test1Run = test1Run;
            m_Test2Run = test2Run;
            m_Test3Run = test3Run;
            Random rand = new Random();
            for (var i = 0; i < m_ArrayLength; ++i)
                m_SearchValues[i] = rand.Next(0, m_ValuesLength - 1);
            Test1Fill();
            Test2Fill();
            Test3Fill();
        }
        public void Start()
        {
            Test1(false);
            Test2(false);
            Test3(false);
            Test1();
            Test2();
            Test3();
            Test1();
            Test2();
            Test3();
            Test1();
            Test2();
            Test3();
            Test1();
            Test2();
            Test3();
            Test1();
            Test2();
            Test3();
            Print();
            //Test1Print();
            //Test2Print();
            //Test3Print();
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
                m_ArrayValues[i] = new Entry<int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_ArrayValues[i].Keys[j] = j;
                    m_ArrayValues[i].Values[j] = j;
                }
            }

        }
        void Test3Fill()
        {
            if (!m_Test3Run)
                return;
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                m_SortedListValues[i] = new SortedList<int, int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_SortedListValues[i].Add(j, j);
                }
            }

        }
        void Test1(bool storeTime = true)
        {
            if (!m_Test1Run)
                return;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_ArrayLength; ++i)
            {

                if (m_DictValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
          //  Console.WriteLine($"{nameof(Test1)} time: {(sw.Elapsed)}, result {result}");
            if (storeTime)
                m_Test1Times.Add(sw.Elapsed.Ticks);
        }
        void Test2(bool storeTime = true)
        {
            if (!m_Test2Run)
                return;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_ArrayLength; ++i)
            {
                if (m_ArrayValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
         //   Console.WriteLine($"{nameof(Test2)} time: {(sw.Elapsed)}, result {result}");
            if (storeTime)
                m_Test2Times.Add(sw.Elapsed.Ticks);
        }
        void Test3(bool storeTime = true)
        {
            if (!m_Test3Run)
                return;
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_ArrayLength; ++i)
            {

                if (m_SortedListValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
         //   Console.WriteLine($"{nameof(Test3)} time: {(sw.Elapsed)}, result {result}");
            if (storeTime)
                m_Test3Times.Add(sw.Elapsed.Ticks);
        }
        void Print()
        {
            //if (!m_Test1Run)
            //    return;
            Console.WriteLine($"{m_ValuesLength};{m_Test1Times.Average()*100/m_ArrayLength};{m_Test2Times.Average() * 100 / m_ArrayLength};{m_Test3Times.Average() * 100 / m_ArrayLength}");
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
        void Test3Print()
        {
            if (!m_Test3Run)
                return;
            Console.WriteLine($"Test3: values {m_ValuesLength} avg {m_Test3Times.Average()} ticks");
        }

    }
}
