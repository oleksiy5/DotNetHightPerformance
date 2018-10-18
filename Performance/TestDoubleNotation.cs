using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestDoubleNotation
    {
        int _count = 100 * 1000 * 1000;

        public void Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string s = null;
            for (int i = 0; i < _count; i++)
            {
                if (s != null & s == "3")
                    Console.WriteLine("true");
            }

            sw.Stop();
            Console.WriteLine($" & {sw.ElapsedMilliseconds} ms");
        }

        public void Test2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string s2 = null;
            for (int i = 0; i < _count; i++)
            {
                if (s2 != null && s2 == "3")
                    Console.WriteLine("true");
            }

            sw.Stop();
            Console.WriteLine($" && {sw.ElapsedMilliseconds} ms");
        }
    }
}
