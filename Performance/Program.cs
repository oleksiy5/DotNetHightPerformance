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
            for (int ii = 0; ii < 5; ii++)
            {
                Console.WriteLine($"--Performance-- test_{ii}");

                int count = 100000021
                    ;
                Random rn = new Random();
                int[] arr = new int[count];
                for (int i = 0; i < count; ++i)
                    arr[i] = i;// * rn.Next(0,5);

                var sw = new Stopwatch();
                sw.Start();

                int maxValue = arr.Max<int>();

                sw.Stop();
                Console.WriteLine($"LINQ Max(): {sw.ElapsedMilliseconds}ms");
                Console.WriteLine($"Search result: {maxValue}");
                Console.WriteLine($"----------------------------");


                var sw2 = new Stopwatch();
                sw2.Start();

                ReaderIntArr ar = new ReaderIntArr(arr);
                int maxValue2 = ar.FindMaxValue(5);


                sw2.Stop();
                Console.WriteLine($"Loop FOR: {sw2.ElapsedMilliseconds}ms");
                Console.WriteLine($"Search result: {maxValue2}");
                Console.WriteLine($"----------------------------");


                var sw3 = new Stopwatch();
                sw3.Start();

                ReaderIntArr ar3 = new ReaderIntArr(arr);
                int maxValue3 = ar3.FindMaxValue();

                sw3.Stop();
                Console.WriteLine($"UNSAFE: {sw3.ElapsedMilliseconds}ms");
                Console.WriteLine($"Search result: {maxValue3}");
                Console.WriteLine($"----------------------------");


                var sw4 = new Stopwatch();
                sw4.Start();

                ReaderIntArr ar4 = new ReaderIntArr(arr);
                int maxValue4 = ar4.FindMaxValue(5);

                sw4.Stop();
                Console.WriteLine($"UNSAFE+TASK: {sw4.ElapsedMilliseconds}ms");
                Console.WriteLine($"Search result: {maxValue4}");
                Console.WriteLine($"----------------------------");

                //var test = new TestSafeVsUnsafeArray();
                //test.Test1();
                //test.Test2();

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
