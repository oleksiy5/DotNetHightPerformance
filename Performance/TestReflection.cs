using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    class TestReflection
    {
        int _count = 10000000;

        public void Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < _count; i++)
            {
                Book book = new Book();
                Type type = book.GetType();
                MethodInfo methodInfo = type.GetMethod("ShowPage");
                if (methodInfo == null)
                {
                    Console.WriteLine(
                        $"Book doesn't contain ShowPage.");
                }
            }
            sw.Stop();
            Console.WriteLine(string.Format("Reflection: {0}ms",
                sw.ElapsedMilliseconds));
        }

        public void Test2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                Book book = new Book();

                if (!book.IsContain_ShowPage)
                {
                    Console.WriteLine(
                        $"Book doesn't contain ShowPage.");
                }
            }

            sw.Stop();
            Console.WriteLine(string.Format("NO-Reflection: {0}ms",
                sw.ElapsedMilliseconds));
        }
    }

    class Book
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public readonly bool IsContain_ShowPage = true;

        public void ShowPage(int page)
        {
            Console.WriteLine($"show page {1}");
        }
    }
}
