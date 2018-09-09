using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestCollectionsvsArrays
    {
        int _count = 10000000;

        public void Test1()
        {
            var sw = new Stopwatch();
            sw.Start();

            var arr = new List<int>();
            for (int i = 0; i < _count; i++)
            {
                arr.Add(i);
            }

            for (int i = 0; i < _count; i++)
            {
                int v =  arr[i];
            }

            sw.Stop();
            Console.WriteLine($"COLLECTIONS ms:{sw.ElapsedMilliseconds}");
        }


        public void Test2()
        {
            var sw = new Stopwatch();
            sw.Start();

            int[] arr = new int[_count];
            for (int i = 0; i < _count; i++)
            {
                arr[i] = i;
            }

            for (int i = 0; i < _count; i++)
            {
                int v = arr[i];
            }


            sw.Stop();
            Console.WriteLine($"ARRAYS ms:{sw.ElapsedMilliseconds}");
        }
    }
}
