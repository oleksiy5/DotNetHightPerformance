using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestFasterArraySearch
    {
       
    }

    unsafe class ReaderIntArr
    {
        int[] _arr;
        int _count;

        public ReaderIntArr(int[] arr)
        {
            _arr = arr;
            _count = _arr.Length;
        }

        public void FindByValue(int value)
        {
            fixed (int* p = &_arr[0])
            {
                for (int* pCur = p, pEnd = p + _count; pCur < pEnd; ++pCur)
                {
                    int val = *pCur;
                    if (val == value)
                        Console.WriteLine(val);
                    //*pCur = val;
                }
            }
        }

        public int FindMaxValue()
        {
            fixed (int* p = &_arr[0])
            {
                int maxValue = 0;
                for (int* pCur = p, pEnd = p + _count; pCur < pEnd; ++pCur)
                {
                    int val = *pCur;
                    if (val > maxValue)
                        maxValue = val;
                }
                return maxValue;
            }
        }

        public int FindMaxValue(int taskCount)
        {
            int[] results = new int[taskCount];
            List<Task> tasks = new List<Task>();
            int i = 0;
            do
            {
                int taskIndex = i;
                Task t1 = new Task(() =>
                    {
                        int indexCount = _count / taskCount;
                        int indexStart = indexCount * taskIndex;

                        fixed (int* p = &_arr[indexStart])
                        {
                            int maxValue = 0;
                            for (int* pCur = p, pEnd = p + indexCount; pCur < pEnd; ++pCur)
                            {
                                int val = *pCur;
                                if (val > maxValue)
                                    maxValue = val;
                            }
                            results[taskIndex] = maxValue;
                        }
                    }
                    );
                tasks.Add(t1);
                t1.Start();
                i++;
            }
            while (i < taskCount);

            Task.WaitAll(tasks.ToArray());

            int length = results.Length;
            int result = 0;
            for (int ndx = 0; ndx < length; ndx++) 
            {
                if (result < results[ndx])
                    result = results[ndx];                
            }

            return result;
        }
    }
}
