using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestReadValue
    {
        int _count = 100000000;

        public void Test1()
        {
            int[] arr = new int[_count];
            for (int i = 0; i < _count; i++)
                arr[i] = 1;
            
            var sw = new Stopwatch();
            sw.Start();
           
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            sw.Stop();
            Console.WriteLine($"arr.Length ms:{sw.ElapsedMilliseconds}");
        }


        public void Test2()
        {
            int[] arr = new int[_count];
            for (int i = 0; i < _count; i++)
                arr[i] = 1;
            int lenght = arr.Length;

            var sw = new Stopwatch();
            sw.Start();
           
            for (int i = 0; i < lenght; i++)
            {
                arr[i] = i;
            }        

            sw.Stop();
            Console.WriteLine($"lenght ms:{sw.ElapsedMilliseconds}");
        }
    }
}
