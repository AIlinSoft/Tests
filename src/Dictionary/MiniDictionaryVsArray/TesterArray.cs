using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniDictionaryVsArray
{
    class TesterArray
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
        private int m_ValuesLength;
        private Entry<int>[] m_ArrayValues;
        private int[] m_SearchValues;
        private List<long> m_Times = new List<long>();
        int m_Result = 0;
        public TesterArray(int valuesLength, int[] searchValues, int[][] fillValues)
        {
            m_ValuesLength = valuesLength;
            m_SearchValues = searchValues;
            m_ArrayValues = new Entry<int>[searchValues.Length];
            Fill(fillValues);
        }
        public void Fill(int[][] fillValues)
        {
            for (int i = 0; i < fillValues.Length; ++i)
            {
                m_ArrayValues[i] = new Entry<int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_ArrayValues[i].Keys[j] = fillValues[i][j];
                    m_ArrayValues[i].Values[j] = fillValues[i][j];
                }
            }

        }
        public void Run(bool storeTime = true)
        {
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < m_SearchValues.Length; ++i)
            {
                if (m_ArrayValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
            m_Result = result;
            if (storeTime)
                m_Times.Add(sw.Elapsed.Ticks);
        }
        public double GetAverageTicks()
        {
            return m_Times.Average();
        }
        public void Print()
        {
            Console.WriteLine($"TesterArray: values {m_ValuesLength} avg {m_Times.Average()} ticks, result {m_Result}");
        }
    }
}
