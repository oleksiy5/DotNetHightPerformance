using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDivision t = new TestDivision();
            t.Test1();
            t.Test2();
        }
    }

    //#region boxing and unboxing

    //    int count = 1000000;

    //    var swCase1 = new Stopwatch();
    //    swCase1.Start();

    //            for (int i = 0; i<count; i++)
    //            {
    //                object tmp = 123;
    //    int number = (int)tmp;//unboxing
    //}

    //swCase1.Stop();
    //            Console.WriteLine($"Case1 ms:{swCase1.ElapsedMilliseconds}");

    //            var swCase2 = new Stopwatch();
    //swCase2.Start();

    //            for (int i = 0; i<count; i++)
    //            {
    //                int tmp = 123;
    //int number = tmp;
    //            }

    //            swCase2.Stop();
    //            Console.WriteLine($"Case2 ms:{swCase2.ElapsedMilliseconds}");
    //#region boxing and unboxing

}
