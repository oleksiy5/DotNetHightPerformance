using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestSealedClasses
    {
        int _count = 10000000;

        public void Test1()
        {          
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Log l = new Log();
                l.DoSomething(i);
            }

            sw.Stop();
            Console.WriteLine($"no SEALED ms:{sw.ElapsedMilliseconds}");
        }
        public void Test2()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Log2 l = new Log2();
                l.DoSomething(i);
            }

            sw.Stop();
            Console.WriteLine($"SEALED ms:{sw.ElapsedMilliseconds}");
        }
    }

    class Log
    {
        public void DoSomething(int number)
        {
            int i = number;
        }
    }

    sealed class Log2
    {
        public void DoSomething(int number)
        {
            int i = number;
        }
    }
}
