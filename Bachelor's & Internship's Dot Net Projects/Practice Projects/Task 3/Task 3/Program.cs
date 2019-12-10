using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter date of birth: dd-mm-yy:");
         
            DateTime n = Convert.ToDateTime(Console.ReadLine());
            DateTime t = DateTime.Today;
            
          // int d= DateTime.Now-n;
            TimeSpan l=new TimeSpan(n);
            Console.WriteLine(n);
            //Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
