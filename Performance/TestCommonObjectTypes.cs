using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    public static class MyTypes
    {
        public static readonly Type TypeBool = typeof(bool);
    }
    
    class TestCommonObjectTypes
    {
        int _count = 10000000;

        public void Test1()
        {
            bool myObject = true;
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                if (myObject.GetType() == MyTypes.TypeBool)
                {
                    //do something
                }
            }
            
            sw.Stop();
            Console.WriteLine($"MyTypes ms:{sw.ElapsedMilliseconds}");
        }
        
        public void Test2()
        {
            bool myObject = true;

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _count; i++)
            {
                if (myObject.GetType() == typeof(bool))
                {
                    //do something
                }
            }

            sw.Stop();
            Console.WriteLine($"typeof(bool) ms:{sw.ElapsedMilliseconds}");
        }
    }
}
