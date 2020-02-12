﻿using System;
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
        public TesterDictionary(int valuesLength, int[] searchValues)
        {
            m_ValuesLength = valuesLength;
            m_SearchValues = searchValues;
            m_DictValues = new Dictionary<int, int>[searchValues.Length];
            Fill();
        }
        public void Fill()
        {
            for (int i = 0; i < m_SearchValues.Length; ++i)
            {
                m_DictValues[i] = new Dictionary<int, int>(m_ValuesLength);
                for (int j = 0; j < m_ValuesLength; ++j)
                {
                    m_DictValues[i][j] = j;
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
            if (storeTime)
                m_Times.Add(sw.Elapsed.Ticks);
        }
        public void Print()
        {
            Console.WriteLine($"TesterDictionary: values {m_ValuesLength} avg {m_Times.Average()} ticks");
        }
    }
}
