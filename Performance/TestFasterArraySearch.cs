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
            if (_count == 0)
                throw new Exception("arr can't be without items");
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
                Task task = new Task(() =>
                    {
                        int endCount = _count / taskCount;
                        int startPosition = endCount * taskIndex;

                        fixed (int* p = &_arr[startPosition])
                        {
                            int maxValue = 0;
                            for (int* pCur = p, pEnd = p + endCount; pCur < pEnd; ++pCur)
                            {
                                int val = *pCur;
                                if (val > maxValue)
                                    maxValue = val;
                            }
                            results[taskIndex] = maxValue;
                        }
                    }
                    );
                tasks.Add(task);
                task.Start();
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
