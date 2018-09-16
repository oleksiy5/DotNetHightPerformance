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
        public void Test_LINQ(int[] arr)
        {
            var sw = new Stopwatch();
            sw.Start();

            int maxValue = arr.Max<int>();

            sw.Stop();
            Console.WriteLine($"LINQ Max(): {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"Search result: {maxValue}");
            Console.WriteLine($"----------------------------");
        }

        public void Test_FOR(int[] arr)
        {
            var sw = new Stopwatch();
            sw.Start();

            ReaderIntArr ar = new ReaderIntArr(arr);
            int maxValue = ar.FindMaxValue_For();
            
            sw.Stop();
            Console.WriteLine($"Loop FOR: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"Search result: {maxValue}");
            Console.WriteLine($"----------------------------");
        }

        public void Test_UNSAFE(int[] arr)
        {
            var sw = new Stopwatch();
            sw.Start();

            ReaderIntArr ar = new ReaderIntArr(arr);
            int maxValue = ar.FindMaxValue();

            sw.Stop();
            Console.WriteLine($"UNSAFE: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"Search result: {maxValue}");
            Console.WriteLine($"----------------------------");

        }

        public void Test_UNSAFE_TASK(int[] arr)
        {
            var sw = new Stopwatch();
            sw.Start();

            ReaderIntArr ar = new ReaderIntArr(arr);
            int maxValue = ar.FindMaxValue(5);

            sw.Stop();
            Console.WriteLine($"UNSAFE+TASK: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"Search result: {maxValue}");
            Console.WriteLine($"----------------------------");
        }
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

        public int FindMaxValue_For()
        {
            int maxValue = int.MinValue;
            for (int i=0;i<_count;i++)
            {
                int val = _arr[i];
                if (val > maxValue)
                    maxValue = val;
            }
            return maxValue;
        }

        public int FindMaxValue()
        {
            fixed (int* p = &_arr[0])
            {
                int maxValue = int.MinValue;
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
            if (taskCount > _count)
                taskCount = 1;

            int[] results = new int[taskCount];
            List<Task> tasks = new List<Task>(taskCount);
            int i = 0;
            int restCount = _count % taskCount;
            int endCount = (_count - restCount) / taskCount;
            do
            {
                int taskIndex = i;
                Task task = new Task(() =>
                    {
                        int startPosition = endCount * taskIndex;
                        if ((taskIndex + 1) == taskCount)
                            endCount = endCount + restCount;
                        fixed (int* p = &_arr[startPosition])
                        {
                            int maxValue = int.MinValue;
                            for (int* pCur = p, pEnd = p + endCount; pCur < pEnd; ++pCur)
                            {
                                if (*pCur > maxValue)
                                    maxValue = *pCur;
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
