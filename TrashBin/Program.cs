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
        public static bool Flag=false;
        public static Stopwatch stw = new Stopwatch();
        public static event Action Timer;
        public MyClass(int i)
        {
            k = i;
            countflag++;
        }

        // Деструктор
        ~MyClass()
        {
            //Console.WriteLine("Объект {0} уничтожен", k);
            Timer?.Invoke();
                
                /*if (countflag!=0 && countflag!=1)Console.WriteLine(countflag+"!");
                            countflag = 0;*/
                
            
            
            
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
            MyClass.Timer += MyClass_Timer;
            int i = 1;
            MyClass obj = new MyClass(0);

            for (; i < 1200000; i++)
            {
                obj.objectGenerator(i);
                if (MyClass.Flag == true)
                {
                    MyClass.stw.Stop();
                    Console.WriteLine(MyClass.stw.ElapsedTicks);
                    
                }
                MyClass.Flag = false;                
            }

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Конец");
            
            //Console.ReadLine();
        }

        private static void MyClass_Timer()
        {
            MyClass.stw.Start();
            MyClass.Flag = true;
            MyClass.Timer -= MyClass_Timer;
        }
    }
}