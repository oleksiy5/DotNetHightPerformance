using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestAsVsCast
    {
        int _count = 1000;
        public void Test1()
        {
            var sw = new Stopwatch();
            sw.Start();

            object o = new object();
            for (int i = 0; i < _count; i++)
            {
                try
                {
                    Bee b;
                    b = (Bee)o;
                    //do something
                }
                catch
                {
                }
            }
            sw.Stop();
            Console.WriteLine($"CAST ms:{sw.ElapsedMilliseconds}");
        }


        public void Test2()
        {
            var sw = new Stopwatch();
            sw.Start();
            
            object o = new object();
            for (int i = 0; i < _count; i++)
            {
                Bee b;
                b = o as Bee;
                if (b != null)
                {
                    //do something
                }
            }        

            sw.Stop();
            Console.WriteLine($"AS ms:{sw.ElapsedMilliseconds}");
        }
    }

    class Bee
    {

    }
}
