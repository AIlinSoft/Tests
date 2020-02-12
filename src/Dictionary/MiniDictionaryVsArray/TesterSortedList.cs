using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniDictionaryVsArray
{
    class TesterSortedList
    {
        private int m_ValuesLength;
        private SortedList<int, int>[] m_SortedListValues;
        private int[] m_SearchValues;
        private List<long> m_Times = new List<long>();
        public TesterSortedList(int valuesLength, int[] searchValues)
        {
            m_ValuesLength = valuesLength;
            m_SearchValues = searchValues;
            m_SortedListValues = new SortedList<int, int>[searchValues.Length];
            Fill();
        }
        public void Fill()
        {
            for (int i = 0; i < m_SearchValues.Length; ++i)
            {
                m_SortedListValues[i] = new SortedList<int, int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                    m_SortedListValues[i].Add(j, j);
            }

        }
        public void Run(bool storeTime = true)
        {
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_SearchValues.Length; ++i)
            {

                if (m_SortedListValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
            if (storeTime)
                m_Times.Add(sw.Elapsed.Ticks);
        }
        public void Print()
        {
            Console.WriteLine($"Test3: values {m_ValuesLength} avg {m_Times.Average()} ticks");
        }

    }
}
