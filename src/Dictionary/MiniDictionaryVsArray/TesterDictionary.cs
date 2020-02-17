using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniDictionaryVsArray
{
    class TesterDictionary
    {
        private int m_ValuesLength;
        private Dictionary<int, int>[] m_DictValues;
        private int[] m_SearchValues;
        private List<long> m_Times = new List<long>();
        int m_Result = 0;
        public TesterDictionary(int valuesLength, int[] searchValues, int[][] fillValues)
        {
            m_ValuesLength = valuesLength;
            m_SearchValues = searchValues;
            m_DictValues = new Dictionary<int, int>[searchValues.Length];
            Fill(fillValues);
        }
        public void Fill(int[][] fillValues)
        {
            for (int i = 0; i < m_SearchValues.Length; ++i)
            {
                m_DictValues[i] = new Dictionary<int, int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_DictValues[i][fillValues[i][j]] = fillValues[i][j];
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

                if (m_DictValues[i].TryGetValue(m_SearchValues[i], out var val))
                    result += val;
            }
            sw.Stop();
            //  Console.WriteLine($"{nameof(Test1)} time: {(sw.Elapsed)}, result {result}");
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
            Console.WriteLine($"TesterDictionary: values {m_ValuesLength} avg {m_Times.Average()} ticks, result {m_Result}");
        }
    }
}
