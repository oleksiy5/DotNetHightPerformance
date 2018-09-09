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

    unsafe class ArrayReader
    {
        int[] _arr;
        int _count;

        public ArrayReader(int[] arr)
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

        public void FindMaxValue()
        {
            fixed (int* p = &_arr[0])
            {
                int maxValue = 0;
                for (int* pCur = p, pEnd = p + _count; pCur < pEnd; ++pCur)
                {
                    int val = *pCur;
                    if (val > maxValue)
                        maxValue = val;
                    //*pCur = val;
                }
                Console.WriteLine(maxValue);
            }
        }

        public void FindMaxValueThread(int taskCount)
        {
            int[] resultsMax = new int[taskCount];
            List<Task> tasks = new List<Task>();
            int i = 0;
            do
            {
                int taskNumber = i;
                Task t1 = new Task(() =>
                    {
                        int indexCount = _count / taskCount;
                        int indexStart = indexCount * taskNumber;

                        fixed (int* p = &_arr[indexStart])
                        {
                            int maxValue = 0;
                            for (int* pCur = p, pEnd = p + indexCount; pCur < pEnd; ++pCur)
                            {
                                int val = *pCur;
                                if (val > maxValue)
                                    maxValue = val;
                            }
                            resultsMax[taskNumber] = maxValue;
                        }
                    }
                    );
                tasks.Add(t1);
                t1.Start();
                i++;
            }
            while (i < taskCount);

            //Task t1 = new Task(() =>
            //    {
            //        int indexCount = _count / taskCount;
            //        int indexStart = 0;

            //        fixed (int* p = &_arr[indexStart])
            //        {
            //            int maxValue = 0;
            //            for (int* pCur = p, pEnd = p + indexCount; pCur < pEnd; ++pCur)
            //            {
            //                int val = *pCur;
            //                if (val > maxValue)
            //                    maxValue = val;
            //            }
            //            resultsMax[0] = maxValue;
            //        }
            //    }
            //    );
            //tasks.Add(t1);
            //t1.Start();

            //Task t2 = new Task(() =>
            //{
            //    int indexCount = _count / taskCount;
            //    int indexStart = indexCount * 1;

            //    fixed (int* p = &_arr[indexStart])
            //    {
            //        int maxValue = 0;
            //        for (int* pCur = p, pEnd = p + indexCount; pCur < pEnd; ++pCur)
            //        {
            //            int val = *pCur;
            //            if (val > maxValue)
            //                maxValue = val;
            //        }
            //        resultsMax[1] = maxValue;
            //    }
            //});
            //tasks.Add(t2);
            //t2.Start();

            Task.WaitAll(tasks.ToArray());
            int resultLength = resultsMax.Length;
            int maxResult = 0;
            for (int ndx = 0; ndx < resultLength; ndx++) 
            {
                if (maxResult < resultsMax[ndx])
                    maxResult = resultsMax[ndx];                
            }

            Console.WriteLine(maxResult);
        }
    }
}
