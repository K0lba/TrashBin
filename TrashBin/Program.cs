using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class MyClass
    {
        int k;
        public static int countflag = 0;

        public MyClass(int i)
        {
            k = i;
            countflag++;
        }

        // Деструктор
        ~MyClass()
        {
            //Console.WriteLine("Объект {0} уничтожен", k);
            if(countflag!=0 && countflag!=1)Console.WriteLine(countflag);
            countflag = 0;
        }

        // Метод создающий и тут же уничтожающий объект
        public void objectGenerator(int i)
        {
            MyClass ob = new MyClass(i);
        }
    }

    class Program
    {
        static void Main()
        {
            Stopwatch stw = new Stopwatch();
            stw.Start();
            int i = 1;
            MyClass obj = new MyClass(0);

            for (; i < 12000000000000000; i++)
            {
                obj.objectGenerator(i);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Конец");
            stw.Stop();
            Console.WriteLine(stw.ElapsedMilliseconds);
            //Console.ReadLine();
        }
    }
}