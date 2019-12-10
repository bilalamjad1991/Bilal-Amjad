using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc
{
    class ProductClass
    {
        public delegate void Pricer();
        public event Pricer PriceChanged;

        string _name;
        int _price;
        public ProductClass(string n, int p)
        {
            _name = n;
            _price = p;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }   
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                if (PriceChanged != null)
                {
                    PriceChanged.Invoke();
                }
            }
        }

        #region Delegate
        public delegate void MyDelegate();

        public void Function()
        {
            Console.WriteLine("Function");
        }
        public void Function1()
        {
            Console.WriteLine("Function1");
        }
        public void Function2()
        {
            Console.WriteLine("Function2");
        }
        public void Function3()
        {
            Console.WriteLine("Function3");
        }
        #endregion

    }
}
