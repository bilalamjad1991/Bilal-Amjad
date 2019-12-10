using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           //String [] Address=Enum.GetNames(typeof(address));
           //foreach (var n in Address)
           //{
           //    Console.WriteLine(n);
           //}
            address temp = address.city;
            //string s = Enum.GetName(typeof(address), 2);
            string s = Convert.ToString(temp);
            Console.WriteLine( s);
            int value=(int)temp;
            Console.WriteLine( value);  
            Console.ReadKey();
        }
        
    }
}
