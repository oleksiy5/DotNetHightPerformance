using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestDivision
    {
        int _count = 9*1000*1000;
        public void Test1()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                int result = i / 2;
            }
            sw.Stop();
            Console.WriteLine($"DIV (/): {sw.ElapsedMilliseconds} ms");
        }


        public void Test2()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                int result = i >> 1;
            }

            sw.Stop();
            Console.WriteLine($"SHIFT (>>): {sw.ElapsedMilliseconds} ms");
        }
    }
}
