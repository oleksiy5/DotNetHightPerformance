using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Performance
{
    class TestTaskvsThread
    {
        int _count = 4;

        public void Test1()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Task.Factory.StartNew(() => { });
            }

            sw.Stop();
            Console.WriteLine("TASK ms " + sw.ElapsedMilliseconds);

        }


        public void Test2()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                new Thread(() => { }).Start();
            }

            sw.Stop();
            Console.WriteLine("THREAD ms " + sw.ElapsedMilliseconds);
        }
    }
}
