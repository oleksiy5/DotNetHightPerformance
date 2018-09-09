﻿using System;
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

            int count = 90000000;

            int[] arr = new int[count];
            for (int i = 0; i < count; ++i)
                arr[i] = i + 1;
            arr = arr.Reverse().ToArray();

            var sw = new Stopwatch();
            sw.Start();

            //int maxValue = arr.Max<int>();
            //Console.WriteLine(maxValue);
            ArrayReader ar2 = new ArrayReader(arr);
            ar2.FindMaxValue();

            sw.Stop();
            Console.WriteLine("safe ms " + sw.ElapsedMilliseconds);

            for (int i = 0; i < count; ++i)
                arr[i] = i + 1;
            arr = arr.Reverse().ToArray();

            var sw2 = new Stopwatch();
            sw2.Start();

            ArrayReader ar = new ArrayReader(arr);
            ar.FindMaxValueThread(2);

            sw2.Stop();
            Console.WriteLine("unsafe ms " + sw2.ElapsedMilliseconds);

            //var test = new TestSafeVsUnsafeArray();
            //test.Test1();
            //test.Test2();

            Console.ReadLine();
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