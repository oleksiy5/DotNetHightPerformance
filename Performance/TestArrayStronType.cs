using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestArrayStronType
    {
        int _count = 10000000;

        public void Test1()
        {
            var sw = new Stopwatch();
            sw.Start();

            Object[] arr = new Object[_count];
            
            for (int i = 0; i < _count; i++)
            {
                arr[i] = i;
            }

            sw.Stop();
            Console.WriteLine($"OBJECT ARRAY ms:{sw.ElapsedMilliseconds}");
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

            sw.Stop();
            Console.WriteLine($"INT ARRAY ms:{sw.ElapsedMilliseconds}");
        }
    }
}
