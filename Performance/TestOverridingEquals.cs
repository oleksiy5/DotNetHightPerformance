using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestOverridingEquals
    {
        int _count = 10000000;

        public void Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Beer b_1 = new Beer() { Alco = 9 };
            Beer b_2 = new Beer() { Alco = 10 };

            for (int i = 0; i < _count; i++)
            {
                if (b_1.Equals(b_2))
                    Console.Write("==");
            }

            sw.Stop();
            Console.WriteLine(string.Format("Beer-OVERRIDE: {0}ms", 
                sw.ElapsedMilliseconds));
        }

        public void Test2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Beer2 b2_1 = new Beer2() { Alco = 9 };
            Beer2 b2_2 = new Beer2() { Alco = 10 };

            for (int i = 0; i < _count; i++)
            {
                if (b2_1.Equals(b2_2))
                    Console.Write("==");
            }

            sw.Stop();
            Console.WriteLine(string.Format("Beer-NO-OVERRIDE: {0}ms", 
                sw.ElapsedMilliseconds));
        }

        public struct Beer
        {
            public int Alco { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is Beer)
                {
                    return this.Alco == ((Beer)obj).Alco;
                }
                else
                    return false;
            }
        }

        public struct Beer2
        {
            public int Alco { get; set; }
        }
    }
}
