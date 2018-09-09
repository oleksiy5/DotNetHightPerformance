using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestStringNoCaseSense
    {
        int _count = 10000000;

        public void Test1()
        {
            string str1 = "AbC2";
            string str2 = "aBc3";
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                if (str1.ToLower() == str2.ToLower())
                    Console.WriteLine("str1 is equal str2");
            }

            sw.Stop();
            Console.WriteLine($"ToLower() ms:{sw.ElapsedMilliseconds}");
        }
        public void Test2()
        {
            string str1 = "AbC2";
            string str2 = "aBc3";

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                if (String.Compare(str1,str2,true) == 0)
                    Console.WriteLine("str1 is equal str2");
            }

            sw.Stop();
            Console.WriteLine($"String.Compare() ms:{sw.ElapsedMilliseconds}");
        }
    }
}
