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
            Random rn = new Random();
            for (int ii = 0; ii < 5; ii++)
            {
                Console.WriteLine($"--Performance-- test_{ii}");

                int count = 100000021;
                int[] arr = new int[count];
                for (int i = 0; i < count; ++i)
                    arr[i] = i * rn.Next(0,5);

                TestFasterArraySearch test = new TestFasterArraySearch();
                test.Test_LINQ(arr);
                test.Test_FOR(arr);
                test.Test_UNSAFE(arr);
                test.Test_UNSAFE_TASK(arr);
                
                Console.ReadLine();
            }
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
