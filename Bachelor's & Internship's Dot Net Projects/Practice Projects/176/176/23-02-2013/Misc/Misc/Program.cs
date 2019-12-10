using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {
            //MiscClass m = new MiscClass(10, 15);

            //ThirdClass t = new ThirdClass();
            //Console.WriteLine(t.FunctionTwo());


            //Conflict c = new ConflictingClass();
            //Console.WriteLine(c.A());
            //Conflict1 c2 = new ConflictingClass();
            //Console.WriteLine(c2.A());

            //Console.WriteLine(testEnum.Value1);

            #region Delegate
            //ProductClass p = new ProductClass();
            //ProductClass.MyDelegate m = new ProductClass.MyDelegate(p.Function3);
            //ProductClass.MyDelegate severalFunction = new ProductClass.MyDelegate(p.Function1);
            //ProductClass.MyDelegate severalFunction2 = new ProductClass.MyDelegate(p.Function2);

            //ProductClass.MyDelegate functions = m + severalFunction;

            //Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics"); Console.WriteLine("Some Logics");

            //m.Invoke();

            //functions();

            //functions = functions + severalFunction2;

            //TODO: subtract Delegate

            #endregion


            ProductClass p = new ProductClass("ProductName", 50);
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Price);
            p.Price = 89;
            // Subscribe
            p.PriceChanged+=new ProductClass.Pricer(PriceChangedByClass);
            p.Price = 100;
            p.Price = 100;
            p.Price = 100;
            p.Price = 100;
            p.Price = 100;
            p.Price = 800;

            if (p.Price == 800)
            {
                // TODO:-unSubscribe
            }

            MiscClass o = new MiscClass(10, 20, 30);
            Console.WriteLine(o.A);
            Console.WriteLine(o.B);
            Console.WriteLine(o.C);
        }

        public static void PriceChangedByClass()
        {
            Console.WriteLine("event was raised by Procduct class and handled by Main");
        }
    }
}
