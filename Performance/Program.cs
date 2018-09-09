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
                int count = 50*1000*1000;
                Random rn = new Random();
                int[] arr = new int[count];
                for (int i = 0; i < count; ++i)
                    arr[i] = i * rn.Next(0,5);
                //arr = arr.Reverse().ToArray();

                var sw = new Stopwatch();
                sw.Start();

                //int maxValue = arr.Max<int>();
                //Console.WriteLine(maxValue);
                ReaderIntArr ar2 = new ReaderIntArr(arr);
                Console.WriteLine(ar2.FindMaxValue());

                sw.Stop();
                Console.WriteLine("safe ms " + sw.ElapsedMilliseconds);

                //for (int i = 0; i < count; ++i)
                //    arr[i] = i + 1;
                //arr = arr.Reverse().ToArray();

                var sw2 = new Stopwatch();
                sw2.Start();

                ReaderIntArr ar = new ReaderIntArr(arr);
                Console.WriteLine(ar.FindMaxValue(10));

                sw2.Stop();
                Console.WriteLine("unsafe ms " + sw2.ElapsedMilliseconds);

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
