using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestStringManipulation
    {
        int _count = 1000 * 10;

        public void Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string s = "";
            for (int i = 0; i < _count; i++)
            {
                s += i.ToString();
            }

            sw.Stop();
            Console.WriteLine($" string:{sw.ElapsedMilliseconds} ms");
        }

        public void Test2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _count; i++)
            {
                sb.Append(i);
            }

            sw.Stop();
            Console.WriteLine($" StringBuilder:{sw.ElapsedMilliseconds} ms");
        }
    }
}
