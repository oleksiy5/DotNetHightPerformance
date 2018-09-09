using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestSafeVsUnsafeArray
    {
        int _count = 50000000;

        public void Test1()
        {
            int[] arr = new int[_count];
            for (int i = 0; i < _count; ++i)
                arr[i] = i + 1;

            var sw = new Stopwatch();
            sw.Start();            
            
            for (int i = 0; i < _count; i++)
            {
                int val = arr[i];
                arr[i] = val;

            }

            sw.Stop();
            Console.WriteLine($"SAFE ARRAY ms:{sw.ElapsedMilliseconds}");
        }


        public void Test2()
        {
            int[] arr = new int[_count];
            for (int i = 0; i < _count; ++i)
                arr[i] = i + 1;

            var sw = new Stopwatch();
            sw.Start();

            unsafe
            {
                fixed (int* p = &arr[0])
                {
                    for (int* pCur = p, pEnd = p + _count; pCur < pEnd; ++pCur)
                    {
                        int val = *pCur;
                        *pCur = val;
                    }

                }
            }
            
            sw.Stop();
            Console.WriteLine($"UNSAFE ARRAY ms:{sw.ElapsedMilliseconds}");
        }
    }
}
